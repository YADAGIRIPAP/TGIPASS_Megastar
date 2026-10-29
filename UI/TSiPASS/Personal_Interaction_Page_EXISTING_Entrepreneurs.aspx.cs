//using IdentityModel.Client;
using AjaxControlToolkit;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
//using System.Threading;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class UI_TSiPASS_Personal_Interaction_Page_EXISTING_Entrepreneurs : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    DataSet dsvacanplots = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            UID_SEARCH_GRID.Visible = true;
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                Session["ExtResult"] = "0";
                //Grievance_Types();
                Marketing_Grievance();
                Financial_Grievance();
                //Marketing_Schemes_Types();
                MEESHO_Platform_Details();
                JUST_DIAL_Platform_Details();
                TS_GLOBAL_Platform_Details();
                WALMART_VRIDDI_Platform_Details();
                Marketing_Assistance_Scheme_Details();
                Schemes_PMS_Details();
                Scheme_SMAS_Details();
                Grievance_Status_Dropdown();
                Mandal_List();
                UID_Mandal_List();
                Social_Category_Types();
                Sector_Name_Details();
                Line_Department_List();


            }
            if (IsPostBack)
            {
                //GeneratePlatformTable();

            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    ////private void Grievance_Types()
    ////{
    ////    try
    ////    {
    ////        DataTable dataTable = new DataTable();
    ////        con.OpenConnection();
    ////        {
    ////            using (SqlCommand command = new SqlCommand("GetGrievancetype", con.GetConnection))
    ////            {
    ////                command.CommandType = CommandType.StoredProcedure;

    ////                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    ////                {
    ////                    adapter.Fill(dataTable);
    ////                    TypeOfGrievance.DataSource = dataTable;
    ////                    TypeOfGrievance.DataTextField = "GrievanceType";
    ////                    TypeOfGrievance.DataValueField = "ID";
    ////                    TypeOfGrievance.DataBind();
    ////                }
    ////                con.CloseConnection();
    ////            }
    ////        }
    ////    }
    ////    catch (Exception ex)
    ////    { throw ex; }
    ////}
    private void Marketing_Grievance()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetMarketingGrievancetypes", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        ////dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                        ////dataTable.Rows[0]["Id"] = 0;
                        ////dataTable.Rows[0]["MarketingType"] = "--Select--";
                        Marketing_Types.DataSource = dataTable;
                        Marketing_Types.DataTextField = "MarketingType";
                        Marketing_Types.DataValueField = "ID";
                        Marketing_Types.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Financial_Grievance()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetFinancialGrievancetypes", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                        dataTable.Rows[0]["Id"] = 0;
                        dataTable.Rows[0]["FinancialType"] = "--Select--";
                        Financial_Types.DataSource = dataTable;
                        Financial_Types.DataTextField = "FinancialType";
                        Financial_Types.DataValueField = "ID";
                        Financial_Types.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    //private void Marketing_Schemes_Types()
    //{
    //    try
    //    {
    //        DataTable dataTable = new DataTable();
    //        con.OpenConnection();
    //        {
    //            using (SqlCommand command = new SqlCommand("GetOtherSchemestypes", con.GetConnection))
    //            {
    //                command.CommandType = CommandType.StoredProcedure;

    //                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    //                {
    //                    adapter.Fill(dataTable);
    //                    OtherSchemesChkList.DataSource = dataTable;
    //                    OtherSchemesChkList.DataTextField = "OtherScheme";
    //                    OtherSchemesChkList.DataValueField = "ID";
    //                    OtherSchemesChkList.DataBind();
    //                }
    //                con.CloseConnection();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    { throw ex; }
    //}
    private void MEESHO_Platform_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetMeeshowBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        Meesho_Awareness_No_List.DataSource = dataTable;
                        Meesho_Awareness_No_List.DataTextField = "MeeshowBenifits";
                        Meesho_Awareness_No_List.DataValueField = "ID";
                        Meesho_Awareness_No_List.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void JUST_DIAL_Platform_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetJustDialBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        Just_Dial_Awareness_No_List.DataSource = dataTable;
                        Just_Dial_Awareness_No_List.DataTextField = "JustDialBenifits";
                        Just_Dial_Awareness_No_List.DataValueField = "ID";
                        Just_Dial_Awareness_No_List.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void TS_GLOBAL_Platform_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetTSGlobalLinkerBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        TS_GLOBAL_DETAILS_LIST.DataSource = dataTable;
                        TS_GLOBAL_DETAILS_LIST.DataTextField = "TSGLBenifits";
                        TS_GLOBAL_DETAILS_LIST.DataValueField = "ID";
                        TS_GLOBAL_DETAILS_LIST.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void WALMART_VRIDDI_Platform_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetWallmartVriddiBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        WALMART_VRIDDI_DETAILS_LIST.DataSource = dataTable;
                        WALMART_VRIDDI_DETAILS_LIST.DataTextField = "WVBenifits";
                        WALMART_VRIDDI_DETAILS_LIST.DataValueField = "ID";
                        WALMART_VRIDDI_DETAILS_LIST.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Marketing_Assistance_Scheme_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetMASBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        BulletedList1.DataSource = dataTable;
                        BulletedList1.DataTextField = "MASBenefits";
                        BulletedList1.DataValueField = "ID";
                        BulletedList1.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Schemes_PMS_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetPMSBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        BulletedList2.DataSource = dataTable;
                        BulletedList2.DataTextField = "PMSBenefits";
                        BulletedList2.DataValueField = "ID";
                        BulletedList2.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Scheme_SMAS_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetSMASBenifits", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        BulletedList3.DataSource = dataTable;
                        BulletedList3.DataTextField = "SMASBenefits";
                        BulletedList3.DataValueField = "ID";
                        BulletedList3.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Grievance_Status_Dropdown()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GetGrievanceStatus", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (Session["Role_Code"] != null)
                    {
                        string roleCode = Session["Role_Code"].ToString().TrimEnd();
                        command.Parameters.Add(new SqlParameter("@RoleCode", SqlDbType.VarChar, 50)).Value = roleCode;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                            dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                            dataTable.Rows[0]["Id"] = 0;
                            dataTable.Rows[0]["GrStatusType"] = "--Select--";
                            GrievanceStatus_dropdown.DataSource = dataTable;
                            GrievanceStatus_dropdown.DataTextField = "GrStatusType";
                            GrievanceStatus_dropdown.DataValueField = "ID";
                            GrievanceStatus_dropdown.DataBind();
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
        catch (Exception ex)
        { throw ex; }
    }
    private void Mandal_List()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GETMandal_EXISTING_ENTREPRENEURS", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
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
                        //DropDownList1.DataSource = dataTable;
                        //DropDownList1.DataTextField = "Manda_lName";
                        //DropDownList1.DataValueField = "Mandal_Id";
                        //DropDownList1.DataBind();



                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void UID_Mandal_List()
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("GetMandals", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                int district = Convert.ToInt32(Session["DistrictID"].ToString().TrimEnd());
                command.Parameters.Add(new SqlParameter("@intDistrictid", SqlDbType.Int)).Value = district;


                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                    dataTable.Rows[0]["Manda_lName"] = "--Select--";
                    DropDownList1.DataSource = dataTable;
                    DropDownList1.DataTextField = "Manda_lName";
                    DropDownList1.DataValueField = "Mandal_Id";
                    DropDownList1.DataBind();
                    ddladrsmandal.DataSource = dataTable;
                    ddladrsmandal.DataTextField = "Manda_lName";
                    ddladrsmandal.DataValueField = "Mandal_Id";
                    ddladrsmandal.DataBind();
                }
                con.CloseConnection();
            }
        }
    }
    private DataTable UID_Village_List(int mandalid)
    {
        try
        {
            DataTable VillagedataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("GETVillage_EXISTING_ENTREPRENEURS", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Mandal_ID", mandalid);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(VillagedataTable);
                        VillagedataTable.Rows.InsertAt(VillagedataTable.NewRow(), 0);
                        VillagedataTable.Rows[0]["village_name"] = "--Select--";

                        //DropDownList2.DataSource = VillagedataTable;
                        //DropDownList2.DataTextField = "village_name";
                        //DropDownList2.DataValueField = "Village_Id";
                        //DropDownList2.DataBind();
                    }
                    con.CloseConnection();
                }
            }
            return VillagedataTable;
        }
        catch (Exception ex) { throw ex; }
    }
    private void Social_Category_Types()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("getsocialcategorylist", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                        dataTable.Rows.InsertAt(dataTable.NewRow(), 6);
                        dataTable.Rows[0]["Caste_Name"] = "--Select--";
                        dataTable.Rows[6]["Caste_Name"] = "Minority";
                        Applicant_caste.DataSource = dataTable;
                        Applicant_caste.DataTextField = "Caste_Name";
                        Applicant_caste.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex) { throw ex; }
    }
    private void Sector_Name_Details()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("getSectorNames_LOA", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                        dataTable.Rows[0]["LineofActivity_Name"] = "--Select--";
                        sector_dropdown.DataSource = dataTable;
                        sector_dropdown.DataTextField = "LineofActivity_Name";
                        sector_dropdown.DataValueField = "intLineofActivityid";
                        sector_dropdown.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex) { throw ex; }
    }
    private void Line_Department_List()
    {
        try
        {
            DataTable dataTable = new DataTable();
            con.OpenConnection();
            {
                using (SqlCommand command = new SqlCommand("getLineDepartments", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                        dataTable.Rows[0]["Dept_Full_name"] = "--Select--";
                        ddlLineDepartment.DataSource = dataTable;
                        ddlLineDepartment.DataTextField = "Dept_Full_name";
                        ddlLineDepartment.DataBind();
                    }
                    con.CloseConnection();
                }
            }
        }
        catch (Exception ex) { throw ex; }
    }

    public void getVacanplots()
    {
        if (chkLand.Checked)
        {
            if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "No")
            {
                if (Applicant_Gender.Text != "" && Applicant_caste.SelectedValue != "0")
                {
                    DataSet ds = new DataSet();
                    con.OpenConnection();
                    SqlDataAdapter da = new SqlDataAdapter("Sp_GetVacanplots", con.GetConnection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Districtid", SqlDbType.Int).Value = Convert.ToInt32(Convert.ToString(Session["DistrictID"]));
                    if (Applicant_Gender.Text == "Female")
                    {
                        da.SelectCommand.Parameters.Add("@GENDER", SqlDbType.VarChar).Value = "FEMALE";
                    }
                    else
                    { da.SelectCommand.Parameters.Add("@CATEGORY", SqlDbType.VarChar).Value = Applicant_caste.SelectedItem.Text.Trim(); }

                    da.Fill(ds);
                    con.CloseConnection();
                    grdvacantplots.DataSource = ds;
                    grdvacantplots.DataBind();
                    grdvacantplots.Visible = true;
                }
                else
                {
                    //chkLand.Checked = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Gender and Social Status');", true);
                    return;
                }
            }
            else
            {
                DataSet ds = new DataSet();
                con.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("Sp_GetVacanplots", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Districtid", SqlDbType.Int).Value = Convert.ToInt32(Convert.ToString(Session["DistrictID"]));
                if (Convert.ToString(Session["Gender"]) == "Female")
                {
                    da.SelectCommand.Parameters.Add("@GENDER", SqlDbType.VarChar).Value = "FEMALE";
                }
                else
                { da.SelectCommand.Parameters.Add("@CATEGORY", SqlDbType.VarChar).Value = Convert.ToString(Session["caste"]); }

                da.Fill(ds);
                con.CloseConnection();
                grdvacantplots.DataSource = ds;
                grdvacantplots.DataBind();
                grdvacantplots.Visible = true;
            }
        }
    }

    //private void GeneratePlatformTable()
    //{
    //    DataTable dataTable = ECOMMERCE_PLATFORM_LIST();

    //    if (dataTable != null && dataTable.Rows.Count > 0)
    //    {
    //        Table platformTable = new Table();

    //        for (int i = 0; i < dataTable.Rows.Count; i++)
    //        {
    //            DataRow row = dataTable.Rows[i];

    //            TableRow tableRow = new TableRow();

    //            TableCell idCell = new TableCell();
    //            idCell.Text = row["ID"].ToString();
    //            idCell.CssClass = "platform-id-cell";

    //            TableCell platformNameCell = new TableCell();
    //            platformNameCell.Text = row["PlatformName"].ToString();
    //            platformNameCell.CssClass = "platform-name-cell";

    //            TableCell yesCell = new TableCell();
    //            TableCell noCell = new TableCell();

    //            RadioButton radioButtonYes = new RadioButton();
    //            radioButtonYes.ID = "RadioButtonYes_" + i;
    //            radioButtonYes.Text = "Yes";
    //            radioButtonYes.GroupName = "PlatformGroup_" + i;
    //            radioButtonYes.AutoPostBack = true;
    //            radioButtonYes.CheckedChanged += new EventHandler((sender, e) => RadioButtonYes_CheckedChanged(sender, e, idCell.Text));
    //            radioButtonYes.CssClass = "platform-name-cell";

    //            RadioButton radioButtonNo = new RadioButton();
    //            radioButtonNo.ID = "RadioButtonNo_" + i;
    //            radioButtonNo.Text = "No";
    //            radioButtonNo.GroupName = "PlatformGroup_" + i;
    //            radioButtonNo.AutoPostBack = true;
    //            radioButtonNo.CheckedChanged += new EventHandler((sender, e) => RadioButtonNo_CheckedChanged(sender, e, idCell.Text));

    //            yesCell.Controls.Add(radioButtonYes);
    //            noCell.Controls.Add(radioButtonNo);

    //            tableRow.Cells.Add(idCell);
    //            tableRow.Cells.Add(platformNameCell);
    //            tableRow.Cells.Add(yesCell);
    //            tableRow.Cells.Add(noCell);

    //            platformTable.Rows.Add(tableRow);
    //        }
    //        PlatformTablePlaceholder.Controls.Add(platformTable);
    //    }
    //}
    //private DataTable ECOMMERCE_PLATFORM_LIST()
    //{
    //    DataTable dataTable = new DataTable();
    //    con.OpenConnection();
    //    dataTable.Columns.Add("SelectedOption", typeof(string));

    //    using (SqlCommand command = new SqlCommand("GetEcommercePlatformtypes", con.GetConnection))
    //    {
    //        command.CommandType = CommandType.StoredProcedure;

    //        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    //        {
    //            adapter.Fill(dataTable);
    //        }
    //        con.CloseConnection();
    //    }
    //    return dataTable;
    //}
    protected void Women_Cell_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Gender = Convert.ToString(Session["Gender"]);
        if (Women_Cell.SelectedValue == "0" || Gender == "FEMALE" || Applicant_Gender.Text == "Female")
        { trwehub.Visible = true; }
        if (Women_Cell.SelectedValue == "0")
        {
            Interaction_Id.Visible = true;
        }
        else
        {
            trwehub.Visible = false;
            chkwehub.Checked = false;
            Interaction_Id.Visible = false;
            Interaction_Block.Visible = false;
            Interaction_Level_Existing.ClearSelection();
            Interaction_block_District.Visible = false;
            Interaction_Date.Value = "";
            Interaction_Venue.Text = "";
            ddl_Mandal.ClearSelection();
            Text1.Value = "";
            TextBox4.Text = "";

        }
        //if (Women_Cell.SelectedValue == "1")
        //{ tronlydate.Visible = true; }

    }
    protected void Interaction_Level_Existing_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Interaction_Level_Existing.SelectedValue == "0")
        {
            Interaction_block_District.Visible = true;
            Interaction_Date.Value = "";
            Interaction_Venue.Text = "";
            ddl_Mandal.ClearSelection();
            ddlvenuemandl.ClearSelection(); ddlvenuemandl_SelectedIndexChanged(sender, e);
        }
        else
        {
            Interaction_block_District.Visible = false;
            Text1.Value = "";
            TextBox4.Text = "";
        }
        if (Interaction_Level_Existing.SelectedValue == "1")
        {
            Interaction_Block.Visible = true;
            Text1.Value = "";
            TextBox4.Text = "";

        }
        else
        {
            Interaction_Block.Visible = false;
            Interaction_Date.Value = "";
            Interaction_Venue.Text = "";
            ddl_Mandal.ClearSelection();
            ddlvenuemandl.ClearSelection();
        }
    }
    protected void ddl_Mandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Village_List();
    }
    protected void TS_IPASS_REGISTERED_Unit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TS_IPASS_REGISTERED_Unit.SelectedValue == "0")
        {

            TS_IPASS_SEARCH_BLOCK.Visible = true;
            trmsmeqsn.Visible = false; rblMSMEreg.ClearSelection();

            trmsmeunits.Visible = false; ddlmapunits.ClearSelection();
            Applicant_Name.Text = "";
            // Applicant_Address.Text = "";
            ddladrsmandal.ClearSelection(); ddladrsmandal_SelectedIndexChanged(sender, e);
            ddladrsvlg.ClearSelection(); ddladrsvlg.Enabled = false;
            //ddladrsvlg.Items.Clear;
            Applicant_Contact.Text = "";
            Applicant_Email.Text = "";
            Applicant_caste.ClearSelection();
            Applicant_Gender.ClearSelection(); Applicant_Gender_SelectedIndexChanged(sender, e);
            Differently_able.ClearSelection();
            Applicant_Investment.Text = "";
            Applicant_Employees.Text = "";
            sector_dropdown.ClearSelection();
            Enterprise_Sector.ClearSelection();
            chkMarketing.Checked = false; chkMarketing_CheckedChanged(sender, e);
            chkFinancial.Checked = false; chkFinancial_CheckedChanged(sender, e);
            chkTechnical.Checked = false; chkTechnical_CheckedChanged(sender, e);
            chkLand.Checked = false; chkLand_CheckedChanged(sender, e);
            chkOthers.Checked = false; chkOthers_CheckedChanged(sender, e);
            if (Women_Cell.SelectedIndex == 0 || Convert.ToString(Session["Gender"]) == "FEMALE" || Applicant_Gender.SelectedIndex == 1)
            { trwehub.Visible = true; }
            if (Women_Cell.SelectedIndex != 0 && Convert.ToString(Session["Gender"]) != "FEMALE" && Applicant_Gender.SelectedIndex != 1)
            { trwehub.Visible = false; }
        }
        else
        {
            TS_IPASS_SEARCH_BLOCK.Visible = false;
            UID_SEARCHGRID.Visible = false;
            Session["UIDNO"] = ""; Financial_Grievance();
        }
        if (TS_IPASS_REGISTERED_Unit.SelectedValue == "1")
        {
            //Grievance_Identified.Enabled = true;
            TS_IPASS_REGISTRATION.Visible = true;
            trmsmeqsn.Visible = true; rblMSMEreg.ClearSelection();
            trmsmeunits.Visible = false; ddlmapunits.ClearSelection();
            //rblMSMEreg_SelectedIndexChanged(sender, e); 
            ddlmapunits.ClearSelection();
            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();
            TS_IPASS_UID_SEARCH.Text = ""; Session["Gender"] = ""; Session["UIDNO"] = "";
            if (Women_Cell.SelectedIndex == 0 || Convert.ToString(Session["Gender"]) == "FEMALE" || Applicant_Gender.SelectedIndex == 1)
            { trwehub.Visible = true; }
            if (Women_Cell.SelectedIndex != 0 && Convert.ToString(Session["Gender"]) != "FEMALE" && Applicant_Gender.SelectedIndex != 1)
            { trwehub.Visible = false; }
            Financial_Grievance();
            chkMarketing.Checked = false; chkMarketing_CheckedChanged(sender, e);
            chkFinancial.Checked = false; chkFinancial_CheckedChanged(sender, e);
            chkTechnical.Checked = false; chkTechnical_CheckedChanged(sender, e);
            chkLand.Checked = false; chkLand_CheckedChanged(sender, e);
            chkOthers.Checked = false; chkOthers_CheckedChanged(sender, e);
        }
        else
        {
            TS_IPASS_REGISTRATION.Visible = false;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "--Select--")
        {

            DropDownList2.Enabled = false;
        }
        else
        {
            UID_SEARCHGRID.Visible = false;
            DropDownList2.DataSource = UID_Village_List(Convert.ToInt32(DropDownList1.SelectedValue));
            //DropDownList2.DataSource = VillagedataTable;
            DropDownList2.DataTextField = "village_name";
            DropDownList2.DataValueField = "Village_Id";
            DropDownList2.DataBind();
            DropDownList2.Enabled = true;
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        UID_SEARCHGRID.Visible = false;

    }
    //protected void TS_IPASS_UID_SEARCH_TextChanged(object sender, EventArgs e)
    //{
    //    if (TS_IPASS_UID_SEARCH.Text.Length > 6)
    //    { SearchButton.Enabled = true; }
    //    else { SearchButton.Enabled = false; }
    //    if (TS_IPASS_UID_SEARCH.Text == "")
    //    {
    //        SearchButton.Enabled = false;
    //        UID_SEARCHGRID.Visible = false;
    //    }
    //}
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        if (TS_IPASS_UID_SEARCH.Text != "" && TS_IPASS_UID_SEARCH.Text.Length > 6 && DropDownList2.SelectedItem.Text != "--Select--")
        {
            fillGrid();
            //fillMSMEUnits(DropDownList1.SelectedItem.Value, DropDownList2.SelectedItem.Value);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Mandal, Village and enter minimum 6 Characters about UID');", true);
        }
    }
    void fillGrid()
    {
        try
        {
            DataSet dsn = new DataSet();
            dsn = GetUIDDetails(TS_IPASS_UID_SEARCH.Text.TrimStart().TrimEnd());
            {
                if (dsn.Tables[0].Rows.Count > 0)
                {
                    UID_SEARCHGRID.Visible = true;
                    UID_SEARCH_GRID.Visible = true;
                    UID_SEARCH_GRID.DataSource = dsn.Tables[0];
                    UID_SEARCH_GRID.DataBind();
                    trmsmeqsn.Visible = true;
                }
                else
                {
                    UID_SEARCHGRID.Visible = true;
                    UID_SEARCH_GRID.Visible = true;
                    UID_SEARCH_GRID.DataSource = dsn.Tables[0];
                    UID_SEARCH_GRID.DataBind();
                    trmsmeqsn.Visible = true;
                }
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Internal error has occured. Please try after some time.');", true);
        }

    }
    public void fillMSMEUnits(string mandalid, string unitname, string lineofactvty)
    {
        try
        {
            DB.DB con = new DB.DB();
            con.OpenConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SP_GET_MSMEMAPPEDUNITDETAILS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@mandalid", SqlDbType.VarChar).Value = mandalid;
            da.SelectCommand.Parameters.Add("@Districtid", SqlDbType.VarChar).Value = Session["DistrictID"].ToString();
            da.SelectCommand.Parameters.Add("@unitname", SqlDbType.VarChar).Value = unitname;
            da.SelectCommand.Parameters.Add("@lineofactvty", SqlDbType.VarChar).Value = lineofactvty;
            da.Fill(ds);
            con.CloseConnection();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlmapunits.DataSource = ds.Tables[0];
                ddlmapunits.DataTextField = "UNIT_NAME";
                ddlmapunits.DataValueField = "MSME_NO";
                ddlmapunits.DataBind();
                trmsmeunits.Visible = true;
            }
            else
            {
                trmsmeunits.Visible = false;
                rblMSMEreg.SelectedIndex = 1;
                trMSMEmap.Visible = true;
                lblnomsmeunits.Visible = true;
                lblnomsmeunits.Text = "No units were found with the given Unit Name";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('No units were found with the given Unit Name);", true);

            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Internal error has occured. Please try after some time.');", true);
        }

    }
    public DataSet GetUIDDetails(string Unitname_UID)
    {
        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UnitName_UID",SqlDbType.VarChar),
               new SqlParameter("@Village_id", SqlDbType.Int)
           };

            pp[0].Value = (Unitname_UID == "") ? "%" : "%" + Unitname_UID.ToString() + "%";
            pp[1].Value = DropDownList2.SelectedValue;

            Dsnew = gen.GenericFillDs("[USP_GET_GetUID_DETAILS]", pp);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Internal error has occured. Please try after some time.');", true);
        }
        return Dsnew;
    }
    protected void Grievance_Identified_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Grievance_Identified.SelectedValue == "0")
        {
            Grievance_Details_TXT_BOX.Visible = true;
            Grievance_Type_Block.Visible = true;
            lblmrkgrv.Visible = true; lblmrkgdnc.Visible = false;
            lblmrkgrvA2.Visible = true; lblmrkgdncA2.Visible = false;
            lblmrkgrvA3.Visible = true; lblmrkgdncA3.Visible = false;
            lbl2.Visible = true; chkFinancial.Visible = true;
            lblfncgrv.Visible = true; lblfncgdnc.Visible = false;
            lblfncgrvA3.Visible = true; lblfncgdncA3.Visible = false;
            lbl3.Visible = true; chkTechnical.Visible = true;
            lbltechgrv.Visible = true;
            //lbltechgdnc.Visible = false;
            lbltechgrvA2.Visible = true; lbltechgdncA2.Visible = false;
            lbltechgrvA3.Visible = true; lbltechgdncA3.Visible = false;

            lbl4.Visible = true; chkLand.Visible = true;
            lbllandgrv.Visible = true; lbllandgdnc.Visible = false;
            lbllandgrvA2.Visible = true; lbllandgdncA2.Visible = false;

            lbl5.Visible = true; chkOthers.Visible = true; lblothrs.Visible = true; lblothrs.InnerText = "Grievance";
            lblothrgrv.Visible = true; lblothrgdnc.Visible = false;
            Broad_Grievance.Visible = true;
            Broad_Guidance.Visible = false;
            Grievance_Resolution.Visible = true;
            Grievance_Status.Visible = true;
            chkMarketing.Checked = false; chkMarketing_CheckedChanged(sender, e);
            chkFinancial.Checked = false; chkFinancial_CheckedChanged(sender, e);
            chkTechnical.Checked = false; chkTechnical_CheckedChanged(sender, e);
            chkLand.Checked = false; chkLand_CheckedChanged(sender, e);
            chkOthers.Checked = false; chkOthers_CheckedChanged(sender, e);
            //lblwehub.Text = "14. Do you want to forward to We-Hub";
            //lblhlthclnc.Text = "15. Do you want to forawrd to Health Clinic";
            //TypeOfGrievance.ClearSelection();
            //TypeOfGrievance_SelectedIndexChanged(sender, e);
        }
        //else
        //{ Grievance_Details_TXT_BOX.Visible = false; Grievance_Type_Block.Visible = false; Broad_Grievance.Visible = false; Grievance_Resolution.Visible = false; Grievance_Status.Visible = false; Grievance_Identified_Marketing_ECOMMERCE.Visible = false; }
        if (Grievance_Identified.SelectedValue == "1")
        {
            Grievance_Details_TXT_BOX.Visible = false;
            Grievance_Details.Text = "";
            TextBox3.Text = "";
            GrievanceStatus_dropdown.ClearSelection();
            Grievance_Type_Block.Visible = true;
            lblmrkgrv.Visible = false; lblmrkgdnc.Visible = true;
            lblmrkgrvA2.Visible = false; lblmrkgdncA2.Visible = true;
            lblmrkgrvA3.Visible = false; lblmrkgdncA3.Visible = true;
            lbl2.Visible = true; chkFinancial.Visible = true;
            lblfncgrv.Visible = false; lblfncgdnc.Visible = true;
            lblfncgrvA3.Visible = false; lblfncgdncA3.Visible = true;

            lbl3.Visible = true; chkTechnical.Visible = true; chkTechnical.Checked = true;
            // lbltchNA.Visible = true;
            //lbltechgrv.Visible = false;
            //lbltechgdnc.Visible = true;
            lbltechgrvA2.Visible = false; lbltechgdncA2.Visible = true;
            lbltechgrvA3.Visible = false; lbltechgdncA3.Visible = true;

            lbl4.Visible = true; chkLand.Visible = true;
            lbllandgrv.Visible = false; lbllandgdnc.Visible = true;
            lbllandgrvA2.Visible = false; lbllandgdncA2.Visible = true;

            lbl5.Visible = true; chkOthers.Visible = true; lblothrs.Visible = true; lblothrs.InnerText = "Guidance";
            lblothrgrv.Visible = false; lblothrgdnc.Visible = true;
            chkFinancial.Visible = true;
            chkTechnical.Visible = true;
            chkLand.Visible = true;
            chkOthers.Visible = true;
            chkMarketing.Checked = false; chkMarketing_CheckedChanged(sender, e);
            chkFinancial.Checked = false; chkFinancial_CheckedChanged(sender, e);
            chkTechnical.Checked = false; chkTechnical_CheckedChanged(sender, e);
            chkLand.Checked = false; chkLand_CheckedChanged(sender, e);
            chkOthers.Checked = false; chkOthers_CheckedChanged(sender, e);

            Broad_Guidance.Visible = true;
            Broad_Grievance.Visible = false;
            Grievance_Resolution.Visible = false;
            Grievance_Status.Visible = false;

            //lblwehub.Text = "11. Do you want to forward to We-Hub";
            //lblhlthclnc.Text = "12. Do you want to forawrd to Health Clinic";
            //TypeOfGrievance.ClearSelection();
            //TypeOfGrievance_SelectedIndexChanged(sender, e);
        }
        //else { Grievance_Type_Block.Visible = false; Broad_Guidance.Visible = false; Grievance_Identified_Marketing_ECOMMERCE.Visible = false; }
    }
    //protected void TypeOfGrievance_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (TypeOfGrievance.Items[0].Selected)
    //    {
    //        MarketingTypes.Visible = true;
    //        Marketing_BLOCK_OFF.Visible = true;
    //    }
    //    else
    //    {
    //        MarketingTypes.Visible = false;
    //        Marketing_Types.ClearSelection();
    //        Marketing_BLOCK_OFF.Visible = false;
    //        clearecommercefeilds();
    //        clearotherchemesfeilds();
    //        Marketing_Others_Text_Box.Text = "";
    //    }

    //    if (TypeOfGrievance.Items[1].Selected)
    //    {
    //        FinancialTypes.Visible = true;
    //        Financial_Block_OFF.Visible = true;
    //    }
    //    else
    //    {
    //        FinancialTypes.Visible = false;
    //        Financial_Block_OFF.Visible = false;
    //        Financial_Types.ClearSelection();
    //        department_issues_type.ClearSelection();
    //        MSEFCCase_Filed.ClearSelection();
    //        MSEFC_Case_Details.Text = "";
    //        MSEFCCase_Filed_No.ClearSelection();
    //        Invoice_Mart.ClearSelection();
    //        INVOICE_MART_Registration_DATE.Value = "";
    //        No_of_Orders_received_Invoice_Mart.Text = "";
    //        Order_Value_Invoice_Mart.Text = "";
    //        No_of_Bills_Invoice_Mart.Text = "";
    //        Bills_Value_Invoice_Mart.Text = "";
    //        No_of_Bills_Sold_Invoice_Mart.Text = "";
    //        NSE.ClearSelection();
    //        RadioButtonList8.ClearSelection();
    //        RadioButtonList9.ClearSelection();
    //        SIDBI.ClearSelection();
    //        RadioButtonList19.ClearSelection();
    //    }

    //    if (TypeOfGrievance.Items[2].Selected)
    //    {
    //        Technical_block.Visible = true;
    //    }
    //    else
    //    {
    //        Technical_block.Visible = false;
    //        TechnicalType_Grievance.ClearSelection();
    //        ddlLineDepartment.ClearSelection();
    //        Technical_Others.Text = "";
    //    }

    //    if (TypeOfGrievance.Items[3].Selected)
    //    {
    //        Land_Block.Visible = true;
    //    }
    //    else
    //    {
    //        Land_Block.Visible = false;
    //        Land_Grievance.ClearSelection();
    //        RadioButtonList10.ClearSelection();
    //        TextBox1.Text = "";
    //    }

    //    if (TypeOfGrievance.Items[4].Selected)
    //    {
    //        Other_Grievance_Block.Visible = true;
    //    }
    //    else
    //    {
    //        Other_Grievance_Block.Visible = false;
    //        TextBox2.Text = "";
    //    }
    //}

    //protected void RadioButtonYes_CheckedChanged(object sender, EventArgs e, string id)
    //{
    //    if (id == "1")
    //    { Meesho_Details.Visible = true; Meesho_Details_NO.Visible = false; Meesho_Awareness_Yes.Visible = false; }
    //    else if (id == "2")
    //    { Just_Dial_Details.Visible = true; Just_Dial_NO.Visible = false; Just_Dial_Awareness_Yes.Visible = false; }
    //    else if (id == "3")
    //    { TS_Global_Details.Visible = true; TS_Global_No.Visible = false; TS_GLOBAL_Awareness_Yes.Visible = false; }
    //    else if (id == "4")
    //    { Walmart_Vriddi_Details.Visible = true; Walmart_Vriddi_NO.Visible = false; WALMART_VRIDDI_Awareness_Yes.Visible = false; }
    //}
    //protected void RadioButtonNo_CheckedChanged(object sender, EventArgs e, string id)
    //{
    //    if (id == "1")
    //    { Meesho_Details_NO.Visible = true; Meesho_Details.Visible = false; }
    //    else if (id == "2")
    //    { Just_Dial_NO.Visible = true; Just_Dial_Details.Visible = false; }
    //    else if (id == "3")
    //    { TS_Global_No.Visible = true; TS_Global_Details.Visible = false; }
    //    else if (id == "4")
    //    { Walmart_Vriddi_NO.Visible = true; Walmart_Vriddi_Details.Visible = false; }
    //}

    //private void Village_List()
    //{ 
    //    DataTable VillagedataTable = new DataTable();
    //    con.OpenConnection();
    //    {
    //        using (SqlCommand command = new SqlCommand("GETVillage_EXISTING_ENTREPRENEURS", con.GetConnection))
    //        {
    //            command.CommandType = CommandType.StoredProcedure;
    //            command.Parameters.AddWithValue("@Mandal_ID", ddl_Mandal.SelectedValue);

    //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    //            {
    //                adapter.Fill(VillagedataTable);
    //                VillagedataTable.Rows.InsertAt(VillagedataTable.NewRow(), 0);
    //                VillagedataTable.Rows[0]["village_name"] = "--Select--";
    //                ddl_Village.DataSource = VillagedataTable;
    //                ddl_Village.DataTextField = "village_name";
    //                ddl_Village.DataValueField = "Village_Id";
    //                ddl_Village.DataBind();
    //            }
    //            con.CloseConnection();
    //        }
    //    }
    //}


    //private void Grievance_Status_Dropdown()
    //{
    //    DataTable dataTable = new DataTable();
    //    con.OpenConnection();
    //    {
    //        using (SqlCommand command = new SqlCommand("GetGrievanceStatus", con.GetConnection))
    //        {
    //            command.CommandType = CommandType.StoredProcedure;
    //            string roleCode = Session["Role_Code"].ToString().TrimEnd();
    //            command.Parameters.Add(new SqlParameter("@RoleCode", SqlDbType.VarChar, 50)).Value = roleCode;

    //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    //            {
    //                adapter.Fill(dataTable);
    //                dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
    //                dataTable.Rows[0]["Id"] = 0;
    //                dataTable.Rows[0]["GrStatusType"] = "--Select--";
    //                GrievanceStatus_dropdown.DataSource = dataTable;
    //                GrievanceStatus_dropdown.DataTextField = "GrStatusType";
    //                GrievanceStatus_dropdown.DataValueField = "ID";
    //                GrievanceStatus_dropdown.DataBind();
    //            }
    //            con.CloseConnection();
    //        }
    //    }
    //}
    protected void chkMarketing_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["UIDNO"].ToString()
            //if (Convert.ToString(Session["UIDNO"]) != "" || Applicant_Investment.Text != "")
            //{
            if (chkMarketing.Checked)
            {
                //mrktngpanel.Visible = true;
                MarketingTypes.Visible = true; Marketing_BLOCK_OFF.Visible = true;
                string UID = Convert.ToString(Session["UIDNO"]);
                if ((UID != "" && UID.Contains("LRG")) || (UID != "" && UID.Contains("MEG") || (Applicant_Investment.Text != "" && Convert.ToInt64(Applicant_Investment.Text) > 100000000)))
                {
                    chkecommrce.Visible = false;
                    chkOtherSchms.Visible = false;
                }
                else
                {
                    chkecommrce.Visible = true;
                    chkOtherSchms.Visible = true;
                }
                chkmrkOthrs.Visible = true;
            }
            else
            {
                //mrktngpanel.Visible = false;
                Grievance_Identified_Marketing_ECOMMERCE.Visible = false;
                MarketingTypes.Visible = false; Marketing_BLOCK_OFF.Visible = false;
                chkecommrce.Checked = false; chkecommrce_CheckedChanged(sender, e);
                chkOtherSchms.Checked = false; chkOtherSchms_CheckedChanged(sender, e);
                chkmrkOthrs.Checked = false; chkmrkOthrs_CheckedChanged(sender, e);
                //Marketing_Types.ClearSelection(); Marketing_Types_SelectedIndexChanged(sender, e);
                clearecommercefeilds(); rblMeesho_SelectedIndexChanged(sender, e); rblJustDial_SelectedIndexChanged(sender, e);
                rblTSGlobal_SelectedIndexChanged(sender, e); rblWallmart_SelectedIndexChanged(sender, e);
                clearotherchemesfeilds();
                Marketing_Others_Text_Box.Text = "";
            }
            ////}
            ////else
            ////{
            ////    chkMarketing.Checked = false;
            ////    //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select/Fill all details under the unit registered under TS-IPASS');", true);
            ////    return;
            ////}
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void clearecommercefeilds()
    {
        // PlatformTablePlaceholder.ClearSelection();
        rblMeesho.ClearSelection();
        rblmeeshoofcrref.ClearSelection();
        Meesho_Unique_ID.Text = "";
        Meesho_Registration_Date.Value = "";
        Meesho_Awareness_No_List.ClearSelection();
        Meesho_NO.ClearSelection();
        rblMSintrsted.ClearSelection();

        rblJustDial.ClearSelection();
        rbljustdialofcrref.ClearSelection();
        Just_Dial_ID.Text = "";
        Just_Dial_Registration_Date.Value = "";
        Just_Dial_Awareness_No_List.ClearSelection();
        JustDialNOBtn.ClearSelection();
        rblJDintrsted.ClearSelection();

        rblTSGlobal.ClearSelection();
        rblTSGofcrref.ClearSelection();
        TS_Global_UNIQUE_ID.Text = "";
        TS_Global_Registration_Date.Value = "";
        TS_GLOBAL_DETAILS_LIST.ClearSelection();
        TS_Global_NO_BTN.ClearSelection();
        rblTSGintrsted.ClearSelection();

        rblWallmart.ClearSelection();
        rblwallmartofcrref.ClearSelection();
        Walmart_Vriddi_UNIQUE_ID.Text = "";
        Walmart_Vriddi_Registration_Date.Value = "";
        WALMART_VRIDDI_DETAILS_LIST.ClearSelection();
        Walmart_Vriddi_NO_Btn.ClearSelection();
        rblWMVintrsted.ClearSelection();
    }
    protected void clearotherchemesfeilds()
    {
        chkMAS.Checked = false;
        chkPMS.Checked = false;
        chkSMAS.Checked = false;
        //OtherSchemesChkList.ClearSelection();
        rblMASawrns.ClearSelection();
        rblMASintrsted.ClearSelection();
        rblPMSawrns.ClearSelection();
        rblPMSintrsted.ClearSelection();
        rblSMASawrns.ClearSelection();
        rblSMASintrsted.ClearSelection();
    }

    protected void rblMeesho_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblMeesho.SelectedIndex == -1 || rblMeesho.SelectedItem.Text == "NA")
            {
                Meesho_Details_NO.Visible = false;
                Meesho_Details.Visible = false;
                Meesho_NO.ClearSelection(); Meesho_NO_SelectedIndexChanged(sender, e);
                rblMSintrsted.ClearSelection();
                rblmeeshoofcrref.ClearSelection();
                Meesho_Unique_ID.Text = ""; Meesho_Registration_Date.Value = "";
                rblMSaftrCamps.ClearSelection(); rblMSaftrCamps_SelectedIndexChanged(sender, e);
                txtMScampdate.Text = "";
                txtmeeshocount.Text = ""; txtmeeshovalue.Text = "";
            }
            else if (rblMeesho.SelectedItem.Text == "Yes")
            {
                Meesho_Details_NO.Visible = false;
                Meesho_Details.Visible = true;
                Meesho_NO.ClearSelection(); Meesho_NO_SelectedIndexChanged(sender, e);
                rblMSintrsted.ClearSelection();
            }
            else if (rblMeesho.SelectedItem.Text == "No")
            {
                Meesho_Details.Visible = false;
                Meesho_Details_NO.Visible = true;
                rblmeeshoofcrref.ClearSelection();
                Meesho_Unique_ID.Text = ""; Meesho_Registration_Date.Value = "";
                rblMSaftrCamps.ClearSelection(); rblMSaftrCamps_SelectedIndexChanged(sender, e);
                txtMScampdate.Text = "";
                txtmeeshocount.Text = ""; txtmeeshovalue.Text = "";
                Meesho_NO.Enabled = true;

            }

        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void rblJustDial_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblJustDial.SelectedIndex == -1 || rblJustDial.SelectedItem.Text == "NA")
            {
                Just_Dial_NO.Visible = false;
                Just_Dial_Details.Visible = false;
                Just_Dial_Awareness_No_List.ClearSelection();
                JustDialNOBtn.ClearSelection();
                JustDialNOBtn_SelectedIndexChanged(sender, e);
                rblJDintrsted.ClearSelection();
                rbljustdialofcrref.ClearSelection();
                rblJDaftrCamps.ClearSelection(); rblJDaftrCamps_SelectedIndexChanged(sender, e);
                txtJDcampdate.Text = "";
                Just_Dial_ID.Text = ""; Just_Dial_Registration_Date.Value = "";
                txtjstdialcount.Text = ""; txtjstdialvalue.Text = "";
            }
            else if (rblJustDial.SelectedItem.Text == "Yes")
            {
                Just_Dial_Details.Visible = true; Just_Dial_NO.Visible = false;
                Just_Dial_Awareness_No_List.ClearSelection();
                JustDialNOBtn.ClearSelection();
                JustDialNOBtn_SelectedIndexChanged(sender, e);
                rblJDintrsted.ClearSelection();
            }
            else if (rblJustDial.SelectedItem.Text == "No")
            {
                Just_Dial_Details.Visible = false;
                Just_Dial_NO.Visible = true;
                rbljustdialofcrref.ClearSelection();
                rblJDaftrCamps.ClearSelection(); rblJDaftrCamps_SelectedIndexChanged(sender, e);
                txtJDcampdate.Text = "";
                Just_Dial_ID.Text = ""; Just_Dial_Registration_Date.Value = "";
                txtjstdialcount.Text = ""; txtjstdialvalue.Text = "";
            }
            //else
            //{
            //    Just_Dial_NO.Visible = false;
            //    Just_Dial_Details.Visible = false;
            //}
        }
        catch (Exception ex)
        { throw ex; }

    }

    protected void rblTSGlobal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblTSGlobal.SelectedIndex == -1 || rblTSGlobal.SelectedItem.Text == "NA")
            {
                TS_Global_No.Visible = false;
                TS_Global_Details.Visible = false;
                TS_GLOBAL_DETAILS_LIST.ClearSelection();
                TS_Global_NO_BTN.ClearSelection();
                TS_Global_NO_BTN_SelectedIndexChanged(sender, e);
                rblTSGintrsted.ClearSelection();
                rblTSGofcrref.ClearSelection();
                rblTSGaftrCamps.ClearSelection(); rblTSGaftrCamps_SelectedIndexChanged(sender, e);
                txtTSGcampdate.Text = "";
                TS_Global_UNIQUE_ID.Text = ""; TS_Global_Registration_Date.Value = "";
                txttsglobalcount.Text = ""; txttsglobalvalue.Text = "";
            }
            else if (rblTSGlobal.SelectedItem.Text == "Yes")
            {
                TS_Global_Details.Visible = true; TS_Global_No.Visible = false;
                TS_GLOBAL_DETAILS_LIST.ClearSelection();
                TS_Global_NO_BTN.ClearSelection();
                TS_Global_NO_BTN_SelectedIndexChanged(sender, e);
                rblTSGintrsted.ClearSelection();
            }
            else if (rblTSGlobal.SelectedItem.Text == "No")
            {
                TS_Global_Details.Visible = false;
                TS_Global_No.Visible = true;
                rblTSGofcrref.ClearSelection();
                rblTSGaftrCamps.ClearSelection(); rblTSGaftrCamps_SelectedIndexChanged(sender, e);
                txtTSGcampdate.Text = "";
                TS_Global_UNIQUE_ID.Text = ""; TS_Global_Registration_Date.Value = "";
                txttsglobalcount.Text = ""; txttsglobalvalue.Text = "";
            }
            //else
            //{
            //    TS_Global_No.Visible = false;
            //    TS_Global_Details.Visible = false;
            //}
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void rblWallmart_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblWallmart.SelectedIndex == -1 || rblWallmart.SelectedItem.Text == "NA")
            {
                Walmart_Vriddi_NO.Visible = false;
                Walmart_Vriddi_Details.Visible = false;
                WALMART_VRIDDI_DETAILS_LIST.ClearSelection();
                Walmart_Vriddi_NO_Btn.ClearSelection();
                Walmart_Vriddi_NO_Btn_SelectedIndexChanged(sender, e);
                rblWMVintrsted.ClearSelection();
                rblwallmartofcrref.ClearSelection(); rblWMVaftrCamps.ClearSelection();
                rblWMVaftrCamps_SelectedIndexChanged(sender, e);
                txtTSGcampdate.Text = "";
                Walmart_Vriddi_UNIQUE_ID.Text = "";
                Walmart_Vriddi_Registration_Date.Value = "";
                txtwallmartcount.Text = ""; txtwallmartvalue.Text = "";
            }

            else if (rblWallmart.SelectedItem.Text == "Yes")
            {
                Walmart_Vriddi_Details.Visible = true;
                Walmart_Vriddi_NO.Visible = false;
                WALMART_VRIDDI_DETAILS_LIST.ClearSelection();
                Walmart_Vriddi_NO_Btn.ClearSelection();
                Walmart_Vriddi_NO_Btn_SelectedIndexChanged(sender, e);
                rblWMVintrsted.ClearSelection();
            }
            else if (rblWallmart.SelectedItem.Text == "No")
            {
                Walmart_Vriddi_Details.Visible = false;
                Walmart_Vriddi_NO.Visible = true;
                wlmrtbnfts.Visible = true;
                wlmrtbnftslst.Visible = true;
                wlmrtNorbl.Visible = true;
                //Thread.Sleep(10000);
                rblwallmartofcrref.ClearSelection(); rblWMVaftrCamps.ClearSelection();
                rblWMVaftrCamps_SelectedIndexChanged(sender, e);
                txtTSGcampdate.Text = "";
                Walmart_Vriddi_UNIQUE_ID.Text = "";
                Walmart_Vriddi_Registration_Date.Value = "";
                txtwallmartcount.Text = ""; txtwallmartvalue.Text = "";
            }
            //else
            //{
            //    Walmart_Vriddi_NO.Visible = false;
            //    Walmart_Vriddi_Details.Visible = false;
            //}
        }
        catch (Exception ex)
        { throw ex; }

    }

    protected void chkMAS_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkMAS.Checked)
            { SCHEME_MAS_BLOCK.Visible = true; }
            else
            {
                SCHEME_MAS_BLOCK.Visible = false;
                rblMASawrns.ClearSelection(); rblMASawrns_SelectedIndexChanged(sender, e);
                rblMASintrsted.ClearSelection(); rblMASintrsted_SelectedIndexChanged(sender, e);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void chkPMS_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkPMS.Checked)
            { SCHEME_PMS_BLOCK.Visible = true; }
            else
            {
                SCHEME_PMS_BLOCK.Visible = false;
                rblPMSawrns.ClearSelection(); rblPMSawrns_SelectedIndexChanged(sender, e);
                rblPMSintrsted.ClearSelection(); rblPMSintrsted_SelectedIndexChanged(sender, e);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void chkSMAS_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkPMS.Checked)
            { SCHEME_SMAS_BLOCK.Visible = true; }
            else
            {
                SCHEME_SMAS_BLOCK.Visible = false;
                rblSMASawrns.ClearSelection(); rblSMASawrns_SelectedIndexChanged(sender, e);
                rblSMASintrsted.ClearSelection(); rblSMASintrsted_SelectedIndexChanged(sender, e);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void Meesho_NO_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Meesho_NO.SelectedValue == "0")
            { Meesho_Awareness_Yes.Visible = true; }
            else { Meesho_Awareness_Yes.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblMSintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblMSintrsted.SelectedValue == "0")
            { Div4.Visible = true; }
            else { Div4.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void JustDialNOBtn_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (JustDialNOBtn.SelectedValue == "0")
            { Just_Dial_Awareness_Yes.Visible = true; }
            else { Just_Dial_Awareness_Yes.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblJDintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblJDintrsted.SelectedValue == "0")
            { Div5.Visible = true; }
            else { Div5.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void TS_Global_NO_BTN_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (TS_Global_NO_BTN.SelectedValue == "0")
            { TS_GLOBAL_Awareness_Yes.Visible = true; }
            else { TS_GLOBAL_Awareness_Yes.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblTSGintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblTSGintrsted.SelectedValue == "0")
            { Div6.Visible = true; }
            else { Div6.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void Walmart_Vriddi_NO_Btn_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Walmart_Vriddi_NO_Btn.SelectedValue == "0")
            { WALMART_VRIDDI_Awareness_Yes.Visible = true; }
            else { WALMART_VRIDDI_Awareness_Yes.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblWMVintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblWMVintrsted.SelectedValue == "0")
            { Div7.Visible = true; }
            else { Div7.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    //protected void OtherSchemesChkList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (OtherSchemesChkList.Items[0].Selected)
    //    { SCHEME_MAS_BLOCK.Visible = true; }
    //    else { SCHEME_MAS_BLOCK.Visible = false; Div1.Visible = false; NSIC_LINK.Visible = false; }

    //    if (OtherSchemesChkList.Items[1].Selected)
    //    { SCHEME_PMS_BLOCK.Visible = true; }
    //    else { SCHEME_PMS_BLOCK.Visible = false; Div2.Visible = false; MSME_LINK.Visible = false; }

    //    if (OtherSchemesChkList.Items[2].Selected)
    //    { SCHEME_SMAS_BLOCK.Visible = true; }
    //    else { SCHEME_SMAS_BLOCK.Visible = false; Div3.Visible = false; SMAS_LINK.Visible = false; }
    //}
    protected void rblMASawrns_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblMASawrns.SelectedValue == "0")
            { Div1.Visible = true; }
            else { Div1.Visible = false; NSIC_LINK.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblMASintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblMASintrsted.SelectedValue == "0")
            { NSIC_LINK.Visible = true; }
            else { NSIC_LINK.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblPMSawrns_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblPMSawrns.SelectedValue == "0")
            { Div2.Visible = true; }
            else { Div2.Visible = false; MSME_LINK.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblPMSintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblPMSintrsted.SelectedValue == "0")
            { MSME_LINK.Visible = true; }
            else { MSME_LINK.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void rblSMASawrns_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblSMASawrns.SelectedValue == "0")
            { Div3.Visible = true; }
            else { Div3.Visible = false; SMAS_LINK.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void rblSMASintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblSMASintrsted.SelectedValue == "0")
            { SMAS_LINK.Visible = true; }
            else { SMAS_LINK.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void chkFinancial_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            //if (Convert.ToString(Session["UIDNO"]) != "" || Applicant_Investment.Text != "")
            //{
            if (chkFinancial.Checked)
            {
                Financial_Grievance();
                FinancialTypes.Visible = true; Financial_Block_OFF.Visible = true;
                string UID = Convert.ToString(Session["UIDNO"]);

                if ((UID != "" && UID.Contains("LRG")) || (UID != "" && UID.Contains("MEG") || (Applicant_Investment.Text != "" && Convert.ToInt64(Applicant_Investment.Text) > 100000000)))
                {
                    Financial_Types.Items.RemoveAt(1);

                }
                else
                {
                    Financial_Grievance();

                }
            }
            else
            {
                FinancialTypes.Visible = false;
                Financial_Block_OFF.Visible = false;
                Financial_Types.ClearSelection();
                Financial_Types_SelectedIndexChanged(sender, e);

                department_issues_type.ClearSelection();
                MSEFCCase_Filed.ClearSelection();
                MSEFC_Case_Details.Text = "";
                MSEFCCase_Filed_No.ClearSelection();
                Invoice_Mart.ClearSelection();
                InvoiceMartID.Text = "";
                INVOICE_MART_Registration_DATE.Value = "";
                No_of_Orders_received_Invoice_Mart.Text = "";
                Order_Value_Invoice_Mart.Text = "";
                No_of_Bills_Invoice_Mart.Text = "";
                Bills_Value_Invoice_Mart.Text = "";
                No_of_Bills_Sold_Invoice_Mart.Text = "";
                NSE.ClearSelection();
                rblNSEawrns.ClearSelection();
                rblNSElisted.ClearSelection();
                SIDBI.ClearSelection();
                rblSIDBIofcrref.ClearSelection();

            }
            //}
            //else
            //{
            //    chkFinancial.Checked = false;
            //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select/Fill all details under the unit registered under TS-IPASS');", true);
            //    return;
            //}
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void Financial_Types_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Financial_Types.SelectedItem.Text == "Issues related to Department")
            {
                Financial_Departmental_Issues.Visible = true;
                Invoice_Mart.ClearSelection(); Invoice_Mart_SelectedIndexChanged(sender, e);
                NSE.ClearSelection(); NSE_SelectedIndexChanged(sender, e);
                SIDBI.ClearSelection(); SIDBI_SelectedIndexChanged(sender, e);
                txtFinancialOthers.Text = "";
            }
            else
            {
                Financial_Departmental_Issues.Visible = false;
            }
            if (Financial_Types.SelectedItem.Text == "Online Platforms")
            {
                Online_Financial_Platforms_Block.Visible = true;
                department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
                txtFinancialOthers.Text = "";
            }
            else
            {
                Online_Financial_Platforms_Block.Visible = false;
            }
            if (Financial_Types.SelectedItem.Text == "Others")
            {
                divfinancialOthers.Visible = true;
            }
            else
            {
                divfinancialOthers.Visible = false; txtFinancialOthers.Text = "";
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void department_issues_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (department_issues_type.SelectedValue == "1")
            {
                MSEFC_Case_Filed_Yes.Visible = true;
            }
            else
            {
                MSEFC_Case_Filed_Yes.Visible = false;
                MSEFCCase_Filed.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
                MSEFC_Case_Details.Text = "";
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void MSEFCCase_Filed_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (MSEFCCase_Filed.SelectedValue == "0")
            { CaseDetails.Visible = true; }
            else { CaseDetails.Visible = false; MSEFC_Case_Filed_No.Visible = false; MSEFC_Case_Details.Text = ""; }
            if (MSEFCCase_Filed.SelectedValue == "1")
            { MSEFC_Case_Filed_No.Visible = true; }
            else { MSEFC_Case_Filed_No.Visible = false; MSEFCCase_Filed_No.ClearSelection(); }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void Invoice_Mart_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Invoice_Mart.SelectedValue == "0")
            { Invoice_Mart_Yes.Visible = true; }

            else
            {
                rblIMofcrref.ClearSelection();
                Invoice_Mart_Yes.Visible = false;
                InvoiceMartID.Text = "";
                INVOICE_MART_Registration_DATE.Value = "";
                No_of_Orders_received_Invoice_Mart.Text = "";
                Order_Value_Invoice_Mart.Text = "";
                No_of_Bills_Invoice_Mart.Text = "";
                Bills_Value_Invoice_Mart.Text = "";
                No_of_Bills_Sold_Invoice_Mart.Text = "";
            }
            if (Invoice_Mart.SelectedValue == "1")
            {
                Invoice_Mart_No.Visible = true;
            }
            else
            {
                Invoice_Mart_No.Visible = false;
                rblIMawrns.ClearSelection();
                rblIMawrns_SelectedIndexChanged(sender, e);
                rblIMintrsted.ClearSelection();
                rblIMintrsted_SelectedIndexChanged(sender, e);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void NSE_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (NSE.SelectedValue == "0")
            {
                NSE_YES.Visible = true;
                rblNSEawrns.ClearSelection(); rblNSEawrns_SelectedIndexChanged(sender, e);
                rblNSEintrsted.ClearSelection(); rblNSEintrsted_SelectedIndexChanged(sender, e);
            }
            else
            {
                NSE_YES.Visible = false; rblNSEofcrref.ClearSelection();
                rblNSEaftrCamps.ClearSelection(); txtNSEcampdate.Text = "";
                rblNSEFiled.ClearSelection();
                rblNSElisted.ClearSelection();
                rblNSEAudit.ClearSelection();
            }
            if (NSE.SelectedValue == "1")
            {
                NSE_No.Visible = true;
                rblNSEofcrref.ClearSelection();
                rblNSEaftrCamps.ClearSelection(); txtNSEcampdate.Text = "";
                rblNSEFiled.ClearSelection();
                rblNSElisted.ClearSelection();
                rblNSEAudit.ClearSelection();

            }
            else
            {
                NSE_No.Visible = false; rblNSEawrns.ClearSelection(); rblNSEawrns_SelectedIndexChanged(sender, e);
                rblNSEintrsted.ClearSelection(); rblNSEintrsted_SelectedIndexChanged(sender, e);
                txtNSEcampdate.Text = "";
                rblNSEFiled.ClearSelection();
                rblNSElisted.ClearSelection();
                rblNSEAudit.ClearSelection();
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void SIDBI_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (SIDBI.SelectedValue == "0")
            { tblSidbiYes.Visible = true; }
            else
            {
                tblSidbiYes.Visible = false;
                rblSIDBIofcrref.ClearSelection(); rblSIDBIaftrCamps.ClearSelection();
                rblSIDBIaftrCamps_SelectedIndexChanged(sender, e);
            }
            if (SIDBI.SelectedValue == "1")
            { trsidbiawrns.Visible = true; }
            else
            {
                trsidbiawrns.Visible = false;
                rblSIDBIawrns.ClearSelection(); rblSIDBIawrns_SelectedIndexChanged(sender, e);
                rblSIDBIintrsted.ClearSelection(); rblSIDBIintrsted_SelectedIndexChanged(sender, e);
            }
            if (SIDBI.SelectedValue == "2")
            {
                tblSidbiYes.Visible = false;
                rblSIDBIofcrref.ClearSelection();
                rblSIDBIaftrCamps.ClearSelection();
                rblSIDBIaftrCamps_SelectedIndexChanged(sender, e);
                trsidbiawrns.Visible = false;
                rblSIDBIawrns.ClearSelection(); rblSIDBIawrns_SelectedIndexChanged(sender, e);
                rblSIDBIintrsted.ClearSelection(); rblSIDBIintrsted_SelectedIndexChanged(sender, e);

            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void chkTechnical_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ////if (Convert.ToString(Session["UIDNO"]) != "" || Applicant_Investment.Text != "")
            ////{
            if (chkTechnical.Checked)
            {
                Techblock.Visible = true;
                Technical_block.Visible = true;
                ////string UID = Convert.ToString(Session["UIDNO"]);
                //////if (UID.Contains("LRG") || UID.Contains("MEG"))
                ////if (Grievance_Identified.SelectedItem.Text == "No" || (UID != "" && UID.Contains("LRG")) || (UID != "" && UID.Contains("MEG") || (Applicant_Investment.Text != "" && Convert.ToInt64(Applicant_Investment.Text) > 100000000)))
                ////{
                ////    lbltchNA.Visible = true;
                ////    Technical_block.Visible = false;
                ////}
                ////else
                ////{
                ////    lbltchNA.Visible = false;
                ////    Technical_block.Visible = true;
                ////}
            }
            else
            {
                Techblock.Visible = false;
                Technical_block.Visible = false;
                trtechissue.Visible = false;
                Technical_Others_TXT_BOX.Visible = false; Technical_Others.Text = "";
                trtechschmsothrs.Visible = false;
                TechnicalType_Grievance.ClearSelection();
                TechnicalType_Grievance_SelectedIndexChanged(sender, e);
                Line_department_block.Visible = false;
                ddlLineDepartment.ClearSelection();
                Financial_Departmental_Issues.Visible = false;
                department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
                MSEFCCase_Filed_No.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
                MSEFC_Case_Details.Text = "";
            }
            ////}
            ////else
            ////{
            ////    chkTechnical.Checked = false;
            ////    //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select/Fill all details under the unit registered under TS-IPASS');", true);
            ////    return;
            ////}
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void TechnicalType_Grievance_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (TechnicalType_Grievance.SelectedValue == "1")
            {
                Line_department_block.Visible = true;
                Technical_Others.Text = "";
            }
            else
            {
                Line_department_block.Visible = false;
                ddlLineDepartment.ClearSelection();
            }
            if (TechnicalType_Grievance.SelectedValue == "2")
            {
                Technical_Others_TXT_BOX.Visible = true; ddlLineDepartment.ClearSelection();
            }
            else
            { Technical_Others_TXT_BOX.Visible = false; Technical_Others.Text = ""; }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void chkLand_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkLand.Checked)
            {
                Land_Block.Visible = true;

            }
            else
            {
                Land_Block.Visible = false;
                Land_Grievance.ClearSelection();
                Land_Grievance_SelectedIndexChanged(sender, e);
                rblvacantplots.ClearSelection();
                grdvacantplots.Visible = false;
                TextBox1.Text = "";
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void Land_Grievance_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Land_Grievance.SelectedValue == "0")
            {
                TSIIC_LAND_Select.Visible = true;
                getVacanplots();
                TextBox1.Text = "";
            }
            else
            {
                TSIIC_LAND_Select.Visible = false;
                rblvacantplots.ClearSelection();
            }
            if (Land_Grievance.SelectedValue == "1")
            {
                Land_Text_Box.Visible = true;
                rblvacantplots.ClearSelection();
                grdvacantplots.Visible = false;
            }
            else
            {
                Land_Text_Box.Visible = false;
                TextBox1.Text = "";
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void chkOthers_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkOthers.Checked)
            {
                Other_Grievance_Block.Visible = true;
            }
            else { Other_Grievance_Block.Visible = false; TextBox2.Text = ""; }
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (ModeOfInteraction.SelectedIndex != -1 && Women_Cell.SelectedIndex != -1 && TS_IPASS_REGISTERED_Unit.SelectedIndex != -1
                && LineOfActivity.SelectedIndex != -1 && rblsick.SelectedIndex != -1 && rblPMEGP.SelectedIndex != -1 &&
                Grievance_Identified.SelectedIndex != -1)
            {
                if (Women_Cell.SelectedValue == "0")
                {

                    if (Women_Cell.SelectedValue == "0" && Interaction_Level_Existing.SelectedValue == "0")
                    {

                        if (TextBox4.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in women cell interatction');", true);
                            return;
                        }
                    }
                    else if (Women_Cell.SelectedValue == "0" && Interaction_Level_Existing.SelectedValue == "1")//district level
                    {
                        if (ddl_Mandal.SelectedIndex == -1 || ddlvenuemandl.SelectedIndex == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details women cell interatction');", true);
                            return;
                        }
                        else
                        {
                            if (ddlvenuemandl.SelectedItem.Text == "Others")
                            {
                                if (Interaction_Venue.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter Other Venue details women cell interatction');", true);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details women cell interatction District level or Mandal level');", true);
                        return;
                    }
                }

                if (TS_IPASS_REGISTERED_Unit.SelectedValue == "0")
                {
                    if (DropDownList1.SelectedIndex == -1 || DropDownList2.SelectedIndex == -1 || TS_IPASS_UID_SEARCH.Text == "" || UID_SEARCH_GRID.Rows.Count == 0 || rblMSMEreg.SelectedIndex == -1 || txtemailExistng.Text == "" || txtmobileExistng.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in unit regestered in TS-iPASS ');", true);
                        return;
                    }
                }
                else
                {
                    if (Applicant_Name.Text == "" || ddladrsmandal.SelectedIndex == 0 || ddladrsvlg.SelectedIndex == 0 || Applicant_Contact.Text == "" || Applicant_Email.Text == "" ||
                    Applicant_caste.SelectedIndex == -1 || Applicant_Gender.SelectedIndex == -1 || Applicant_Investment.Text == "" ||
                    Applicant_Employees.Text == "" || sector_dropdown.SelectedIndex == -1 || Enterprise_Sector.SelectedIndex == -1 || rblMSMEreg.SelectedIndex == -1 || Differently_able.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details of the unit');", true);
                        return;
                    }
                }
                if (Grievance_Identified.SelectedValue == "0")
                {
                    if (Grievance_Details.Text == "" || TextBox3.Text == "" || GrievanceStatus_dropdown.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in Identified Grievance');", true);
                        return;
                    }
                }
                if (chkTechnical.Checked)
                {

                    if (rblTechnSchms.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Technical Grievance Type');", true);
                        return;
                    }
                    else if (rblTechnSchms.SelectedItem.Text == "TSIPASS" || rblTechnSchms.SelectedItem.Text == "Incentives" || rblTechnSchms.SelectedItem.Text == "Raw-Material")
                    {
                        if (TechnicalType_Grievance.SelectedIndex == 1)
                        {
                            if (ddlLineDepartment.SelectedItem.Text == "--Select--")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Line Department Technical Grievance Type');", true);
                                return;
                            }
                        }
                        if (TechnicalType_Grievance.SelectedIndex == 2)
                        {
                            if (Technical_Others.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Other Technical Grievance Type');", true);
                                return;

                            }
                        }
                    }
                    else if (rblTechnSchms.SelectedItem.Text == "MSEFC")
                    {
                        //if (department_issues_type.SelectedIndex == -1)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Issues related to department');", true);
                        //    return;
                        //}
                        //else if (department_issues_type.SelectedIndex == 1)
                        //{
                        if (MSEFCCase_Filed.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select unit filed case under MSEFC or not');", true);
                            return;
                        }
                        else if (MSEFCCase_Filed.SelectedIndex == 0)
                        {
                            if (MSEFC_Case_Details.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Details of  Case filed under MSEFC');", true);
                                return;
                            }
                        }
                        else if (MSEFCCase_Filed.SelectedIndex == 1)
                        {
                            if (MSEFCCase_Filed_No.SelectedIndex == -1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Whether Awareness on Facilitation Council is given or not');", true);
                                return;
                            }
                        }

                        //}
                    }
                    else if (rblTechnSchms.SelectedItem.Text == "Others")
                    {
                        if (Technical_Others.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Other Scheme details');", true);
                            return;
                        }
                    }
                }

                if (chkMarketing.Checked)
                {
                    if (!chkecommrce.Checked && !chkOtherSchms.Checked && !chkmrkOthrs.Checked)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Marketing Grievance Type');", true);
                        return;
                    }
                    if (chkecommrce.Checked)
                    {
                        if (rblMeesho.SelectedIndex != -1)
                        {
                            if (rblMeesho.SelectedItem.Text == "Yes")
                            {
                                if (rblmeeshoofcrref.SelectedIndex == -1 || rblMSaftrCamps.SelectedIndex == -1 || Meesho_Unique_ID.Text == "" || Meesho_Registration_Date.Value == "" || txtmeeshocount.Text == "" || txtmeeshovalue.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Meesho Platform details');", true);
                                    return;
                                }
                                if (rblMSaftrCamps.SelectedValue == "0" && txtMScampdate.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in Meesho Platform details');", true);
                                    return;
                                }
                            }
                            else if (rblMeesho.SelectedItem.Text == "No")
                            {
                                if (Meesho_Awareness_No_List.SelectedIndex == -1 || Meesho_NO.SelectedIndex == -1 || rblMSintrsted.SelectedIndex == -1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Meesho Platform details');", true);
                                    return;

                                }
                            }
                            //else if (rblMeesho.SelectedItem.Text == "NA") { }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on Meesho or not');", true);
                            return;
                        }
                        if (rblJustDial.SelectedIndex != -1)
                        {
                            if (rblJustDial.SelectedItem.Text == "Yes")
                            {
                                if (rbljustdialofcrref.SelectedIndex == -1 || rblJDaftrCamps.SelectedIndex == -1 || Just_Dial_ID.Text == "" || Just_Dial_Registration_Date.Value == "" || txtjstdialcount.Text == "" || txtjstdialvalue.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter JustDial Platform details');", true);
                                    return;
                                }
                                if (rblJDaftrCamps.SelectedValue == "0" && txtJDcampdate.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in JustDial Platform details');", true);
                                    return;
                                }
                            }
                            else if (rblJustDial.SelectedItem.Text == "No")
                            {
                                if (Just_Dial_Awareness_No_List.SelectedIndex == -1 || JustDialNOBtn.SelectedIndex == -1 || rblJDintrsted.SelectedIndex == -1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter JustDial Platform details');", true);
                                    return;

                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on JustDial or not');", true);
                            return;
                        }
                        if (rblTSGlobal.SelectedIndex != -1)
                        {
                            if (rblTSGlobal.SelectedItem.Text == "Yes")
                            {
                                if (rblTSGofcrref.SelectedIndex == -1 || rblTSGaftrCamps.SelectedIndex == -1 || TS_Global_UNIQUE_ID.Text == "" || TS_Global_Registration_Date.Value == "" || txttsglobalcount.Text == "" || txttsglobalvalue.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter TS_Global Linker Platform details');", true);
                                    return;
                                }
                                if (rblTSGaftrCamps.SelectedValue == "0" && txtTSGcampdate.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in TSGlobal Linker Platform details');", true);
                                    return;
                                }
                            }
                            else if (rblTSGlobal.SelectedItem.Text == "No")
                            {
                                if (TS_GLOBAL_DETAILS_LIST.SelectedIndex == -1 || TS_Global_NO_BTN.SelectedIndex == -1 || rblTSGintrsted.SelectedIndex == -1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter TS_Global Linker Platform details');", true);
                                    return;

                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on TS_Global Linker or not');", true);
                            return;
                        }
                        if (rblWallmart.SelectedIndex != -1)
                        {
                            if (rblWallmart.SelectedItem.Text == "Yes")
                            {
                                if (rblwallmartofcrref.SelectedIndex == -1 || rblWMVaftrCamps.SelectedIndex == -1 || Walmart_Vriddi_UNIQUE_ID.Text == "" || Walmart_Vriddi_Registration_Date.Value == "" || txtwallmartcount.Text == "" || txtwallmartvalue.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter WallMart Vriddi Platform details');", true);
                                    return;
                                }
                                if (rblWMVaftrCamps.SelectedValue == "0" && txtWMVcampdate.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in TSGlobal Linker Platform details');", true);
                                    return;
                                }
                            }
                            else if (rblWallmart.SelectedItem.Text == "No")
                            {
                                if (WALMART_VRIDDI_DETAILS_LIST.SelectedIndex == -1 || Walmart_Vriddi_NO_Btn.SelectedIndex == -1 || rblWMVintrsted.SelectedIndex == -1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter WallMart Vriddi Platform details');", true);
                                    return;

                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on WallMart Vriddi or not');", true);
                            return;
                        }

                    }
                    if (chkOtherSchms.Checked)
                    {
                        if (rblMAS.SelectedIndex != -1)
                        {
                            if (rblMAS.SelectedItem.Text == "Yes")
                            {
                                if (rblMASawrns.SelectedIndex == 0)
                                {
                                    if (rblMASintrsted.SelectedIndex == -1)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select interested to onBoard onto Marketing Assistance Scheme or not');", true);
                                        return;
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness provided about the Marketing Assistance Scheme or not');", true);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Marketing Assistance Scheme (NSIC) is applicable or not');", true);
                            return;
                        }
                        if (rblPMS.SelectedIndex != -1)
                        {
                            if (rblPMS.SelectedItem.Text == "Yes")
                            {
                                if (rblPMSawrns.SelectedIndex != -1)
                                {
                                    if (rblPMSawrns.SelectedIndex == 0)
                                    {
                                        if (rblPMSintrsted.SelectedIndex == -1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select interested to onBoard onto Procurement and Marketing Assistance Scheme or not');", true);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness provided about the Procurement and Marketing Support Scheme or not');", true);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Procurement and Marketing Support Scheme (P&MS)-(MSME) is applicable or not');", true);
                            return;
                        }
                        if (rblSMAS.SelectedIndex != -1)
                        {
                            if (rblPMS.SelectedItem.Text == "Yes")
                            {
                                if (rblSMASawrns.SelectedIndex != -1)
                                {
                                    if (rblSMASawrns.SelectedIndex == 0)
                                    {
                                        if (rblSMASintrsted.SelectedIndex == -1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select interested to onBoard onto Special Marketing Assistance Scheme or not');", true);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness provided about the Special Marketing Support Scheme or not');", true);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Special Marketing Assistance Scheme (SMAS) is applicable or not');", true);
                            return;
                        }
                    }
                    if (chkmrkOthrs.Checked)
                    {
                        if (Marketing_Others_Text_Box.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Other Type Marketing Grievance');", true);
                            return;
                        }
                    }

                }
                if (chkFinancial.Checked)
                {
                    if (Financial_Types.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Financial Grievance type');", true);
                        return;
                    }
                    else if (Financial_Types.SelectedItem.Text == "Online Platforms")
                    {
                        if (Invoice_Mart.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded onto Invoice Mart or not');", true);
                            return;

                        }
                        else
                        {
                            if (Invoice_Mart.SelectedIndex == 0)
                            {
                                if (rblIMofcrref.SelectedIndex == -1 || rblIMaftrCamps.SelectedIndex == -1 || InvoiceMartID.Text == "" || INVOICE_MART_Registration_DATE.Value == "" || No_of_Orders_received_Invoice_Mart.Text == "" ||
                                    Order_Value_Invoice_Mart.Text == "" || No_of_Bills_Invoice_Mart.Text == "" || Bills_Value_Invoice_Mart.Text == ""
                                    || No_of_Bills_Sold_Invoice_Mart.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter all details about Invoice Mart');", true);
                                    return;
                                }
                                if (rblIMaftrCamps.SelectedValue == "0" && txtIMcampdate.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in Invoice Mart Platform details');", true);
                                    return;
                                }

                            }
                            else if (Invoice_Mart.SelectedIndex == 1)
                            {
                                if (rblIMawrns.SelectedIndex != -1)
                                {
                                    if (rblIMawrns.SelectedItem.Text == "Yes")
                                    {
                                        if (rblIMintrsted.SelectedIndex == -1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit is interested to onboard onto InvoiceMart or not');", true);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select awarenss provided about Factoring/ inreverse Factoring');", true);
                                    return;
                                }
                            }

                        }
                        if (NSE.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded onto NSE or not');", true);
                            return;

                        }
                        else
                        {
                            if (NSE.SelectedIndex == 0)
                            {
                                if (rblNSEofcrref.SelectedIndex == -1 || rblNSEaftrCamps.SelectedIndex == -1 || rblNSEFiled.SelectedIndex == -1 || rblNSElisted.SelectedIndex == -1 || rblNSEAudit.SelectedIndex == -1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter all details of NSE Platform');", true);
                                    return;
                                }
                                if (rblNSEaftrCamps.SelectedValue == "0" && txtNSEcampdate.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in NSE details');", true);
                                    return;
                                }
                            }
                            else if (NSE.SelectedIndex == 1)
                            {
                                if (rblNSEawrns.SelectedIndex != -1)
                                {
                                    if (rblNSEawrns.SelectedItem.Text != "Yes")
                                    {
                                        if (rblNSEintrsted.SelectedIndex == -1)
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit is intersted to onboard on to NSE or not');", true);
                                        return;
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness Provided on Listing NSE  or not');", true);
                                    return;
                                }
                            }
                        }
                        //if (SIDBI.SelectedIndex != -1)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded onto NSE or not');", true);
                        //    return;
                        //}
                        //else
                        //{
                        //    if (SIDBI.SelectedItem.Text == "Yes")
                        //    {
                        //        if (rblSIDBIofcrref.SelectedIndex == -1 || rblSIDBIaftrCamps.SelectedIndex == -1)
                        //        {
                        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded into SIDBI with officer reference or not');", true);
                        //            return;
                        //        }
                        //        if (rblSIDBIaftrCamps.SelectedValue == "0" && txtSIDBIcampdate.Text == "")
                        //        {
                        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in SIDBI details');", true);
                        //            return;
                        //        }
                        //    }
                        //    else if (SIDBI.SelectedItem.Text == "No")
                        //    {
                        //        if (rblSIDBIawrns.SelectedIndex != -1)
                        //        {
                        //            if (rblSIDBIintrsted.SelectedIndex == -1)
                        //            {
                        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit is intersted to onboard on to SIDBI or not');", true);
                        //                return;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness Provided on Listing SIDBI  or not');", true);
                        //            return;
                        //        }
                        //    }
                        //}
                    }
                }

                if (chkLand.Checked)
                {
                    if (Land_Grievance.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Land Type of Grievance related to');", true);
                        return;

                    }
                    else
                    {
                        if (TSIIC_LAND_Select.Visible == true && rblvacantplots.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select about TSIIC land');", true);
                            return;
                        }
                        if (Land_Text_Box.Visible == true && TextBox1.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter other type of land grievance');", true);
                            return;
                        }
                    }
                }
                if (Other_Grievance_Block.Visible == true && TextBox2.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter other grievance type');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details');", true);
                return;
            }

            if (Session["ExtResult"].ToString() == "0")
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString); ;
                conn.Open();
                SqlCommand command = new SqlCommand("DataBind_tbl_Existing_ENTREPRENEURS", conn);
                command.CommandType = CommandType.StoredProcedure;
                //DataTable EXISTING_ENTREPRENEUR_DATA = new DataTable();
                //con.OpenConnection();
                //using (SqlCommand command = new SqlCommand("DataBind_tbl_Existing_ENTREPRENEURS", con.GetConnection))      

                command.Parameters.AddWithValue("@InteractionType", GetSelectedValue(ModeOfInteraction));
                command.Parameters.AddWithValue("@DateofInteraction", ToDBValue(intrctiondt.Value));
                string onlydt = intrctiondt.Value.Substring(0, 10);
                command.Parameters.AddWithValue("@onlyDateofInteraction", SqlDbType.Date).Value = DateTime.ParseExact(onlydt, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@ThroughWomenCell", GetSelectedValue(Women_Cell));
                command.Parameters.AddWithValue("@forwdedtoWehub", chkwehub.Checked ? "Yes" : "No");

                command.Parameters.AddWithValue("@WomenCellIntrlevel", GetSelectedValue(Interaction_Level_Existing));
                command.Parameters.AddWithValue("@DistLevlIntractionDate", ToDBValue(Text1.Value));
                command.Parameters.AddWithValue("@DislevlIntractionVenue", ToDBValue(TextBox4.Text));
                command.Parameters.AddWithValue("@MandlLevlMandalName", GetSelectedValueddl(ddl_Mandal));
                //command.Parameters.AddWithValue("@Village", GetSelectedValue(ddl_Village));
                command.Parameters.AddWithValue("@MandlLevlIntractionDate", ToDBValue(Interaction_Date.Value));
                command.Parameters.AddWithValue("@MandllevlIntractionVenue", GetSelectedValueddl(ddlvenuemandl));
                command.Parameters.AddWithValue("@MandllevlIntractionOtherVenue", ToDBValue(Interaction_Venue.Text));
                command.Parameters.AddWithValue("@wmncellIntractionDate", ToDBValue(intrctiondt.Value));
                command.Parameters.AddWithValue("@TSiPASSReg", GetSelectedValue(TS_IPASS_REGISTERED_Unit));
                if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "Yes")
                {
                    command.Parameters.AddWithValue("@mobileExistng", ToDBValue(txtmobileExistng.Text));
                    command.Parameters.AddWithValue("@emailExistng", ToDBValue(txtemailExistng.Text));
                    if (UID_SEARCH_GRID.Rows.Count > 0)
                    {
                        foreach (GridViewRow gvrow in UID_SEARCH_GRID.Rows)
                        {
                            CheckBox chk = (CheckBox)gvrow.FindControl("SelectCheckBox");

                            if (chk != null & chk.Checked)
                            {
                                Label Name = (Label)gvrow.FindControl("Applicant_Name");
                                Label UID = (Label)gvrow.FindControl("UIDNo");
                                Label ContactNo = (Label)gvrow.FindControl("applContact");
                                Label email = (Label)gvrow.FindControl("applEmail");
                                Label Caste = (Label)gvrow.FindControl("applCaste");
                                Label Gender = (Label)gvrow.FindControl("applGender");

                                command.Parameters.AddWithValue("@UIDno", UID.Text);
                                //command.Parameters.AddWithValue("@Name", gvrow.Cells[2].Text);
                                command.Parameters.AddWithValue("@Name", Name.Text);
                                command.Parameters.AddWithValue("@Address", gvrow.Cells[3].Text);
                                command.Parameters.AddWithValue("@Contact", ContactNo.Text);
                                command.Parameters.AddWithValue("@EmailId", email.Text);
                                command.Parameters.AddWithValue("@SocialCategory", Caste.Text);
                                command.Parameters.AddWithValue("@Gender", Gender.Text);
                                command.Parameters.AddWithValue("@Differentlyabled", gvrow.Cells[8].Text);
                                command.Parameters.AddWithValue("@Investment", gvrow.Cells[9].Text);
                                command.Parameters.AddWithValue("@Employment", gvrow.Cells[10].Text);
                                command.Parameters.AddWithValue("@LineOfActivity", gvrow.Cells[11].Text);
                                command.Parameters.AddWithValue("@EnterpriseSector", gvrow.Cells[12].Text);
                                command.Parameters.AddWithValue("@IsMajor", Convert.ToString(Session["isMajorExist"]));
                            }
                        }
                    }

                }
                else
                {
                    command.Parameters.AddWithValue("@mobileExistng", ToDBValue(txtmobileExistng.Text));
                    command.Parameters.AddWithValue("@emailExistng", ToDBValue(txtemailExistng.Text));
                    command.Parameters.AddWithValue("@UIDno", ToDBValue(""));
                    command.Parameters.AddWithValue("@Name", ToDBValue(Applicant_Name.Text));
                    command.Parameters.AddWithValue("@Address", GetSelectedValueddl(ddladrsmandal) + "," + GetSelectedValueddl(ddladrsvlg));
                    command.Parameters.AddWithValue("@Contact", ToDBValue(Applicant_Contact.Text));
                    command.Parameters.AddWithValue("@EmailId", ToDBValue(Applicant_Email.Text));
                    command.Parameters.AddWithValue("@SocialCategory", GetSelectedValueddl(Applicant_caste));
                    command.Parameters.AddWithValue("@Gender", GetSelectedValueddl(Applicant_Gender));
                    command.Parameters.AddWithValue("@Differentlyabled", Differently_able.SelectedItem.Text);
                    command.Parameters.AddWithValue("@Investment", ToDBValue(Applicant_Investment.Text));
                    command.Parameters.AddWithValue("@Employment", ToDBValue(Applicant_Employees.Text));
                    command.Parameters.AddWithValue("@LineOfActivity", GetSelectedValueddl(sector_dropdown));
                    command.Parameters.AddWithValue("@EnterpriseSector", GetSelectedValueddl(Enterprise_Sector));
                    command.Parameters.AddWithValue("@IsMajor", Convert.ToString(Session["isMajorNew"]));
                }

                command.Parameters.AddWithValue("@isMSMEreg", GetSelectedValue(rblMSMEreg));
                command.Parameters.AddWithValue("@IsUnderODOP", GetSelectedValue(LineOfActivity));
                command.Parameters.AddWithValue("@IsSick", GetSelectedValue(rblsick));
                command.Parameters.AddWithValue("@forwdedtoHlthclinic", chkhlthclinc.Checked ? "Yes" : "No");

                command.Parameters.AddWithValue("@IsUnderPMEGP", GetSelectedValue(rblPMEGP));
                command.Parameters.AddWithValue("@PANno", ToDBValue(txtPAN.Text));
                command.Parameters.AddWithValue("@IsGrvnceIdentfd", GetSelectedValue(Grievance_Identified));
                command.Parameters.AddWithValue("@GrievanceDetails", ToDBValue(Grievance_Details.Text));

                //-------------------Marketring-----------------------------//
                command.Parameters.AddWithValue("@Gr_Marketing", chkMarketing.Checked ? "Yes" : "No");
                command.Parameters.AddWithValue("@GrM_ECommerce", chkecommrce.Checked ? "Yes" : "No");

                command.Parameters.AddWithValue("@GrMEC_Meesho", GetSelectedValue(rblMeesho));
                command.Parameters.AddWithValue("@GrMEC_MeeshorefbyOffcr", GetSelectedValue(rblmeeshoofcrref));
                command.Parameters.AddWithValue("@GrMEC_Meeshorefbycamp", GetSelectedValue(rblMSaftrCamps));
                if (txtMScampdate.Text == "")
                    command.Parameters.Add("@GrMEC_Meeshorefbycampdate", SqlDbType.Date).Value = ToDBValue(txtMScampdate.Text);
                else
                    command.Parameters.AddWithValue("@GrMEC_Meeshorefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtMScampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                //command.Parameters.Add("@GrMEC_Meeshorefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtMScampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@GrMEC_MeeshoId", ToDBValue(Meesho_Unique_ID.Text));
                if (Meesho_Registration_Date.Value == "")
                    command.Parameters.Add("@GrMEC_MeeshoRegDt", SqlDbType.Date).Value = ToDBValue(Meesho_Registration_Date.Value);
                else
                    command.Parameters.Add("@GrMEC_MeeshoRegDt", SqlDbType.Date).Value = DateTime.ParseExact(Meesho_Registration_Date.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@GrMEC_MeeshoTranscount", ToDBValue(txtmeeshocount.Text));
                command.Parameters.AddWithValue("@GrMEC_MeeshoTransvalue", ToDBValue(txtmeeshovalue.Text));

                command.Parameters.AddWithValue("@GrMEC_MeeshobnftsIDs", ToDBValue(""));
                command.Parameters.AddWithValue("@GrMEC_MeeshoAwareness", GetSelectedValue(Meesho_NO));
                command.Parameters.AddWithValue("@GrMEC_MeeshoIntrsted", GetSelectedValue(rblMSintrsted));

                command.Parameters.AddWithValue("@GrMEC_JustDial", GetSelectedValue(rblJustDial));
                command.Parameters.AddWithValue("@GrMEC_JustDialrefbyOffcr", GetSelectedValue(rbljustdialofcrref));
                command.Parameters.AddWithValue("@GrMEC_JustDialrefbycamp", GetSelectedValue(rblJDaftrCamps));
                if (txtJDcampdate.Text == "")
                    command.Parameters.AddWithValue("@GrMEC_JustDialrefbycampdate", SqlDbType.Date).Value = ToDBValue(txtJDcampdate.Text);
                else
                    command.Parameters.AddWithValue("@GrMEC_JustDialrefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtJDcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@GrMEC_JustDialId", ToDBValue(Just_Dial_ID.Text));
                if (Just_Dial_Registration_Date.Value == "")
                    command.Parameters.AddWithValue("@GrMEC_JustDialRegDt", SqlDbType.Date).Value = ToDBValue(Just_Dial_Registration_Date.Value);
                else
                    command.Parameters.AddWithValue("@GrMEC_JustDialRegDt", SqlDbType.Date).Value = DateTime.ParseExact(Just_Dial_Registration_Date.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@GrMEC_JustDialTranscount", ToDBValue(txtjstdialcount.Text));
                command.Parameters.AddWithValue("@GrMEC_JustDialTransvalue", ToDBValue(txtjstdialvalue.Text));

                command.Parameters.AddWithValue("@GrMEC_JustDialbnftsIDs", ToDBValue(""));
                command.Parameters.AddWithValue("@GrMEC_JustDialAwareness", GetSelectedValue(JustDialNOBtn));
                command.Parameters.AddWithValue("@GrMEC_JustDialIntrsted", GetSelectedValue(rblJDintrsted));

                command.Parameters.AddWithValue("@GrMEC_TSGlobal", GetSelectedValue(rblTSGlobal));
                command.Parameters.AddWithValue("@GrMEC_TSGlobalrefbyOffcr", GetSelectedValue(rblTSGofcrref));
                command.Parameters.AddWithValue("@GrMEC_TSGlobalrefbycamp", GetSelectedValue(rblTSGaftrCamps));
                if (txtTSGcampdate.Text == "")
                    command.Parameters.AddWithValue("@GrMEC_TSGlobalrefbycampdate", SqlDbType.Date).Value = ToDBValue(txtTSGcampdate.Text);
                else
                    command.Parameters.AddWithValue("@GrMEC_TSGlobalrefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtTSGcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@GrMEC_TSGlobalId", ToDBValue(TS_Global_UNIQUE_ID.Text));
                if (TS_Global_Registration_Date.Value == "")
                    command.Parameters.AddWithValue("@GrMEC_TSGlobalRegDt", SqlDbType.Date).Value = ToDBValue(TS_Global_Registration_Date.Value);
                else
                    command.Parameters.AddWithValue("@GrMEC_TSGlobalRegDt", SqlDbType.Date).Value = DateTime.ParseExact(TS_Global_Registration_Date.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@GrMEC_TSGlobalTranscount", ToDBValue(txttsglobalcount.Text));
                command.Parameters.AddWithValue("@GrMEC_TSGlobalTransvalue", ToDBValue(txttsglobalvalue.Text));

                command.Parameters.AddWithValue("@GrMEC_TSGlobalbnftsIDs", ToDBValue(""));
                command.Parameters.AddWithValue("@GrMEC_TSGlobalAwareness", GetSelectedValue(TS_Global_NO_BTN));
                command.Parameters.AddWithValue("@GrMEC_TSGlobalIntrsted", GetSelectedValue(rblTSGintrsted));

                command.Parameters.AddWithValue("@GrMEC_Wallmart", GetSelectedValue(rblWallmart));
                command.Parameters.AddWithValue("@GrMEC_WallmartrefbyOffcr", GetSelectedValue(rblwallmartofcrref));
                command.Parameters.AddWithValue("@GrMEC_Wallmartrefbycamp", GetSelectedValue(rblWMVaftrCamps));
                if (txtWMVcampdate.Text == "")
                    command.Parameters.AddWithValue("@GrMEC_Wallmartrefbycampdate", SqlDbType.Date).Value = ToDBValue(txtWMVcampdate.Text);
                else
                    command.Parameters.AddWithValue("@GrMEC_Wallmartrefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtWMVcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@GrMEC_WallmartId", ToDBValue(Walmart_Vriddi_UNIQUE_ID.Text));
                if (Walmart_Vriddi_Registration_Date.Value == "")
                    command.Parameters.AddWithValue("@GrMEC_WallmartRegDt", SqlDbType.Date).Value = ToDBValue(Walmart_Vriddi_Registration_Date.Value);
                else
                    command.Parameters.AddWithValue("@GrMEC_WallmartRegDt", SqlDbType.Date).Value = DateTime.ParseExact(Walmart_Vriddi_Registration_Date.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@GrMEC_WallmartTranscount", ToDBValue(txtwallmartcount.Text));
                command.Parameters.AddWithValue("@GrMEC_WallmartTransvalue", ToDBValue(txtwallmartvalue.Text));
                command.Parameters.AddWithValue("@GrMEC_WallmartbnftsIDs", ToDBValue(""));
                command.Parameters.AddWithValue("@GrMEC_WallmartAwareness", GetSelectedValue(Walmart_Vriddi_NO_Btn));
                command.Parameters.AddWithValue("@GrMEC_WallmartIntrsted", GetSelectedValue(rblWMVintrsted));

                command.Parameters.AddWithValue("@GrMEC_Others", ToDBValue(""));
                command.Parameters.AddWithValue("@GrMEC_OthersDetails", ToDBValue(""));

                command.Parameters.AddWithValue("@GrM_OtherSchemes", chkOtherSchms.Checked ? "Yes" : "No");

                command.Parameters.AddWithValue("@GrMOS_MarktngAsstScheme", GetSelectedValue(rblMAS));
                command.Parameters.AddWithValue("@GrMOS_MASawarness", GetSelectedValue(rblMASawrns));
                command.Parameters.AddWithValue("@GrMOS_MASinterested", GetSelectedValue(rblMASintrsted));

                command.Parameters.AddWithValue("@GrMOS_PandMS", GetSelectedValue(rblPMS));
                command.Parameters.AddWithValue("@GrMOS_PandMSawarness", GetSelectedValue(rblPMSawrns));
                command.Parameters.AddWithValue("@GrMOS_PandMSinterested", GetSelectedValue(rblPMSintrsted));

                command.Parameters.AddWithValue("@GrMOS_SMAS", GetSelectedValue(rblSMAS));
                command.Parameters.AddWithValue("@GrMOS_SMASawarness", GetSelectedValue(rblSMASawrns));
                command.Parameters.AddWithValue("@GrMOS_SMASinterested", GetSelectedValue(rblSMASintrsted));

                command.Parameters.AddWithValue("@GrM_Others", chkmrkOthrs.Checked ? "Yes" : "No");
                command.Parameters.AddWithValue("@GrM_OthersDetails", ToDBValue(Marketing_Others_Text_Box.Text));

                //-------------------Financial-----------------------------//
                command.Parameters.AddWithValue("@Gr_Financial", chkFinancial.Checked ? "Yes" : "No");
                command.Parameters.AddWithValue("@GrF_Type", GetSelectedValueddl(Financial_Types));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMart", GetSelectedValue(Invoice_Mart));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartrefbyOffcr", GetSelectedValue(rblIMofcrref));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartID", ToDBValue(InvoiceMartID.Text));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartrefbycamp", GetSelectedValue(rblIMaftrCamps));
                if (txtIMcampdate.Text == "")
                    command.Parameters.AddWithValue("@GrFOLP_InvoiceMartrefbycampdate", ToDBValue(txtIMcampdate.Text));
                else
                    command.Parameters.AddWithValue("@GrFOLP_InvoiceMartrefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtIMcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

                if (INVOICE_MART_Registration_DATE.Value == "")
                    command.Parameters.AddWithValue("@GrFOLP_InvoiceMartRegDt", ToDBValue(INVOICE_MART_Registration_DATE.Value));
                else
                    command.Parameters.AddWithValue("@GrFOLP_InvoiceMartRegDt", DateTime.ParseExact(INVOICE_MART_Registration_DATE.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));

                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartOrdrsRcvdCount", ToDBValue(No_of_Orders_received_Invoice_Mart.Text));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartOrdrsRcvdCost", ToDBValue(Order_Value_Invoice_Mart.Text));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartBlsUploadedCount", ToDBValue(No_of_Bills_Invoice_Mart.Text));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartBlsUploadedCost", ToDBValue(Bills_Value_Invoice_Mart.Text));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartBlsSoldCount", ToDBValue(No_of_Bills_Sold_Invoice_Mart.Text));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartAwrnsgvn", GetSelectedValue(rblIMawrns));
                command.Parameters.AddWithValue("@GrFOLP_InvoiceMartIntrsted", GetSelectedValue(rblIMintrsted));

                command.Parameters.AddWithValue("@GrFOLP_NSE", GetSelectedValue(NSE));
                command.Parameters.AddWithValue("@GrFOLP_NSErefbyOffcr", GetSelectedValue(rblNSEofcrref));
                command.Parameters.AddWithValue("@GrFOLP_NSErefbycamp", GetSelectedValue(rblNSEaftrCamps));
                if (txtNSEcampdate.Text == "")
                    command.Parameters.AddWithValue("@GrFOLP_NSErefbycampdate", ToDBValue(txtNSEcampdate.Text));
                else
                    //command.Parameters.AddWithValue("@GrFOLP_NSErefbycampdate", DateTime.ParseExact(txtNSEcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
                    command.Parameters.Add("@GrFOLP_NSErefbycampdate", SqlDbType.Date).Value = DateTime.ParseExact(txtNSEcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");



                command.Parameters.AddWithValue("@GrFOLP_NSEFiled", GetSelectedValue(rblNSEFiled));
                command.Parameters.AddWithValue("@GrFOLP_NSEListedAbout", GetSelectedValue(rblNSElisted));
                command.Parameters.AddWithValue("@GrFOLP_NSEAudit", GetSelectedValue(rblNSEAudit));

                command.Parameters.AddWithValue("@GrFOLP_NSEAwarnessgiven", GetSelectedValue(rblNSEawrns));
                command.Parameters.AddWithValue("@GrFOLP_NSEIntrsted", GetSelectedValue(rblNSEintrsted));

                command.Parameters.AddWithValue("@GrFOLP_SIDBI", GetSelectedValue(SIDBI));
                command.Parameters.AddWithValue("@GrFOLP_SIDBIrefbyOffcr", GetSelectedValue(rblSIDBIofcrref));
                command.Parameters.AddWithValue("@GrFOLP_SIDBIrefbycamp", GetSelectedValue(rblSIDBIaftrCamps));
                if (txtSIDBIcampdate.Text == "")
                    command.Parameters.AddWithValue("@GrFOLP_SIDBIrefbycampdate", ToDBValue(txtSIDBIcampdate.Text));
                else
                    command.Parameters.AddWithValue("@GrFOLP_SIDBIrefbycampdate", DateTime.ParseExact(txtSIDBIcampdate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));


                command.Parameters.AddWithValue("@GrFOLP_SIDBIAwarnessgiven", GetSelectedValue(rblSIDBIawrns));
                command.Parameters.AddWithValue("@GrFOLP_SIDBIntrsted", GetSelectedValue(rblSIDBIintrsted));

                command.Parameters.AddWithValue("@GrF_Others", ToDBValue(txtFinancialOthers.Text));

                //----------------------Technacal-----------------------------//
                command.Parameters.AddWithValue("@Gr_Technical", chkTechnical.Checked ? "Yes" : "No");
                command.Parameters.AddWithValue("@GrT_SchemeType", GetSelectedValue(rblTechnSchms));
                command.Parameters.AddWithValue("@GrT_OtherScheme", ToDBValue(txttechschmsothrs.Text));

                command.Parameters.AddWithValue("@GrT_Type", GetSelectedValue(TechnicalType_Grievance));
                command.Parameters.AddWithValue("@GrT_LineDeptName", GetSelectedValueddl(ddlLineDepartment));
                command.Parameters.AddWithValue("@GrFDptIssue", GetSelectedValue(department_issues_type));
                command.Parameters.AddWithValue("@GrFDptIssue_CaseunderMSME", GetSelectedValue(MSEFCCase_Filed));
                command.Parameters.AddWithValue("@GrFDptIssue_CaseMSMEdetails", ToDBValue(MSEFC_Case_Details.Text));
                command.Parameters.AddWithValue("@GrFDptIssue_GivenFcltionCouncil", GetSelectedValue(MSEFCCase_Filed_No));

                command.Parameters.AddWithValue("@GrT_Others", ToDBValue(Technical_Others.Text));
                if (lbltchNA.Visible == true)
                    command.Parameters.AddWithValue("@GrT_NA", ToDBValue("Yes"));
                else
                    command.Parameters.AddWithValue("@GrT_NA", ToDBValue(""));

                //-------------------Land-----------------------------//
                command.Parameters.AddWithValue("@Gr_Land", chkLand.Checked ? "Yes" : "No");
                command.Parameters.AddWithValue("@GrL_Type", GetSelectedValue(Land_Grievance));
                command.Parameters.AddWithValue("@GrL_isInfrmdabtVacantPlts", GetSelectedValue(rblvacantplots));
                command.Parameters.AddWithValue("@GrL_Others", ToDBValue(TextBox1.Text));

                //-------------------Other Grievance-----------------------------//
                command.Parameters.AddWithValue("@Gr_Others", chkOthers.Checked ? "Yes" : "No");
                command.Parameters.AddWithValue("@GrOthersDetails", ToDBValue(TextBox2.Text));

                command.Parameters.AddWithValue("@GrievanceResolution", ToDBValue(TextBox3.Text));
                command.Parameters.AddWithValue("@GrievanceStatus", GetSelectedValueddl(GrievanceStatus_dropdown));
                command.Parameters.AddWithValue("@createdby", Convert.ToInt32(Session["uid"].ToString()));
                command.Parameters.AddWithValue("@DistrictID", Convert.ToInt32(Session["DistrictID"].ToString()));
                command.Parameters.AddWithValue("@ODOPEXPORT", GetSelectedValue(rdodpexport));
                command.Parameters.AddWithValue("@IncentiveIssue", GetSelectedValue(rdincentives));
                command.Parameters.AddWithValue("@RawmaterialIssue", GetSelectedValue(rdrawmaterial)); 
                command.Parameters.Add("@Result", SqlDbType.Int);
                command.Parameters["@Result"].Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                int i = Convert.ToInt32(command.Parameters["@Result"].Value);
                Session["ExtResult"] = command.Parameters["@Result"].Value;
                con.CloseConnection();
                if (i > 0)
                {
                    SubmitBtn.Enabled = false; SubmitBtn.BackColor = Color.DarkGray;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('All Details are Submitted Successfully');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Some Internal Error occured,Details are not saved');", true);
                }
            }
        }
        catch (Exception ex)
        { throw ex; }

    }

    protected string ValidateControls()
    {
        string ErrorMsg = "";
        if (ModeOfInteraction.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select Mode of Interaction \\n";
        }
        if (intrctiondt.Value == "")
        {
            ErrorMsg = ErrorMsg + "Please Select Date of Interaction \\n";
        }
        if (Women_Cell.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select Interaction at Women cell or not \\n";
        }
        else if (Women_Cell.SelectedValue == "0")
        {
            if (Women_Cell.SelectedValue == "0" && Interaction_Level_Existing.SelectedValue == "0")
            {
                if (TextBox4.Text == "")
                {
                    ErrorMsg = ErrorMsg + "Please Enter Venue of Interaction at Women cell \\n";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in women cell interatction');", true);
                }
            }
            else if (Women_Cell.SelectedValue == "0" && Interaction_Level_Existing.SelectedValue == "1")
            {
                if (ddl_Mandal.SelectedIndex == -1 || ddlvenuemandl.SelectedIndex == 0)
                {
                    ErrorMsg = ErrorMsg + "Please Select Mandal and Venue of Interaction at Women cell \\n";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details women cell interatction');", true);
                }
                else
                {
                    if (ddlvenuemandl.SelectedItem.Text == "Others")
                    {
                        if (Interaction_Venue.Text == "")
                        {
                            ErrorMsg = ErrorMsg + "Please Enter other Venue details at Women cell \\n";
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter Other Venue details women cell interatction');", true);
                        }
                    }
                }
            }
        }

        if (TS_IPASS_REGISTERED_Unit.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select Whether the unit registered under TS-IPASS  \\n";
        }
        else if (TS_IPASS_REGISTERED_Unit.SelectedValue == "0")
        {
            if (DropDownList1.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + "Please Select Mandal of the unit registered under TS-IPASS  \\n";
            }
            if (DropDownList2.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + "Please Select Village the unit registered under TS-IPASS  \\n";
            }
            if (TS_IPASS_UID_SEARCH.Text == "")
            {
                ErrorMsg = ErrorMsg + "Please Enter UID/Unit Name of the unit registered under TS-IPASS  \\n";
            }
            if (UID_SEARCH_GRID.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in unit regestered in TS-iPASS ');", true);

            }
        }
        else if (TS_IPASS_REGISTERED_Unit.SelectedValue == "0")
        {
            if (Applicant_Name.Text == "" || ddladrsmandal.SelectedIndex == 0 || ddladrsvlg.SelectedIndex == 0 || Applicant_Contact.Text == "" || Applicant_Email.Text == "" ||
            Applicant_caste.SelectedIndex == -1 || Applicant_Gender.SelectedIndex == -1 || Applicant_Investment.Text == "" ||
            Applicant_Employees.Text == "" || sector_dropdown.SelectedIndex == -1 || Enterprise_Sector.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in unit regestered in TS-iPASS');", true);


            }
        }
        if (LineOfActivity.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select Whether  Line of Activity falls under ODOP or not  \\n";
        }
        if (LineOfActivity.SelectedIndex != -1)
        {
            if (rdodpexport.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + "Please Select Whether interest to Export or not  \\n";
            }
        }
        if (rblsick.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select  Whether the unit is Sick or not  \\n";
        }
        if (rblPMEGP.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select  Whether the unit established under PMEGP  or not  \\n";
        }
        if (Grievance_Identified.SelectedIndex == -1)
        {
            ErrorMsg = ErrorMsg + "Please Select  Whether any Grievance identified  or not  \\n";

        }

        //if (txtPAN.Text != "")
        //{
        //    ErrorMsg = ErrorMsg + "Please Enter Pan Card Details  \\n";
        //}

        if (Women_Cell.SelectedValue == "0")
        {

            if (Women_Cell.SelectedValue == "0" && Interaction_Level_Existing.SelectedValue == "0")
            {

                if (TextBox4.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in women cell interatction');", true);

                }
            }
            else if (Women_Cell.SelectedValue == "0" && Interaction_Level_Existing.SelectedValue == "1")//district level
            {
                if (ddl_Mandal.SelectedIndex == -1 || ddlvenuemandl.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details women cell interatction');", true);

                }
                else
                {
                    if (ddlvenuemandl.SelectedItem.Text == "Others")
                    {
                        if (Interaction_Venue.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter Other Venue details women cell interatction');", true);

                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details women cell interatction District level or Mandal level');", true);

            }
        }


        if (Grievance_Identified.SelectedValue == "0")
        {
            if (Grievance_Details.Text == "" || TextBox3.Text == "" || GrievanceStatus_dropdown.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all details in Identified Grievance');", true);

            }
        }

        if (chkMarketing.Checked)
        {
            if (!chkecommrce.Checked && !chkOtherSchms.Checked && !chkmrkOthrs.Checked)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Marketing Grievance Type');", true);

            }
            if (chkecommrce.Checked)
            {
                if (rblMeesho.SelectedIndex != -1)
                {
                    if (rblMeesho.SelectedItem.Text == "Yes")
                    {
                        if (rblmeeshoofcrref.SelectedIndex == -1 || rblMSaftrCamps.SelectedIndex == -1 || Meesho_Unique_ID.Text == "" || Meesho_Registration_Date.Value == "" || txtmeeshocount.Text == "" || txtmeeshovalue.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Meesho Platform details');", true);

                        }
                        if (rblMSaftrCamps.SelectedValue == "0" && txtMScampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in Meesho Platform details');", true);

                        }
                    }
                    else if (rblMeesho.SelectedItem.Text == "No")
                    {
                        if (Meesho_Awareness_No_List.SelectedIndex == -1 || Meesho_NO.SelectedIndex == -1 || rblMSintrsted.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Meesho Platform details');", true);


                        }
                    }
                    //else if (rblMeesho.SelectedItem.Text == "NA") { }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on Meesho or not');", true);

                }
                if (rblJustDial.SelectedIndex != -1)
                {
                    if (rblJustDial.SelectedItem.Text == "Yes")
                    {
                        if (rbljustdialofcrref.SelectedIndex == -1 || rblJDaftrCamps.SelectedIndex == -1 || Just_Dial_ID.Text == "" || Just_Dial_Registration_Date.Value == "" || txtjstdialcount.Text == "" || txtjstdialvalue.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter JustDial Platform details');", true);

                        }
                        if (rblJDaftrCamps.SelectedValue == "0" && txtJDcampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in JustDial Platform details');", true);

                        }
                    }
                    else if (rblJustDial.SelectedItem.Text == "No")
                    {
                        if (Just_Dial_Awareness_No_List.SelectedIndex == -1 || JustDialNOBtn.SelectedIndex == -1 || rblJDintrsted.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter JustDial Platform details');", true);


                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on JustDial or not');", true);

                }
                if (rblTSGlobal.SelectedIndex != -1)
                {
                    if (rblTSGlobal.SelectedItem.Text == "Yes")
                    {
                        if (rblTSGofcrref.SelectedIndex == -1 || rblTSGaftrCamps.SelectedIndex == -1 || TS_Global_UNIQUE_ID.Text == "" || TS_Global_Registration_Date.Value == "" || txttsglobalcount.Text == "" || txttsglobalvalue.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter TS_Global Linker Platform details');", true);

                        }
                        if (rblTSGaftrCamps.SelectedValue == "0" && txtTSGcampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in TSGlobal Linker Platform details');", true);

                        }
                    }
                    else if (rblTSGlobal.SelectedItem.Text == "No")
                    {
                        if (TS_GLOBAL_DETAILS_LIST.SelectedIndex == -1 || TS_Global_NO_BTN.SelectedIndex == -1 || rblTSGintrsted.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter TS_Global Linker Platform details');", true);


                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on TS_Global Linker or not');", true);

                }
                if (rblWallmart.SelectedIndex != -1)
                {
                    if (rblWallmart.SelectedItem.Text == "Yes")
                    {
                        if (rblwallmartofcrref.SelectedIndex == -1 || rblWMVaftrCamps.SelectedIndex == -1 || Walmart_Vriddi_UNIQUE_ID.Text == "" || Walmart_Vriddi_Registration_Date.Value == "" || txtwallmartcount.Text == "" || txtwallmartvalue.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter WallMart Vriddi Platform details');", true);

                        }
                        if (rblWMVaftrCamps.SelectedValue == "0" && txtWMVcampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in TSGlobal Linker Platform details');", true);

                        }
                    }
                    else if (rblWallmart.SelectedItem.Text == "No")
                    {
                        if (WALMART_VRIDDI_DETAILS_LIST.SelectedIndex == -1 || Walmart_Vriddi_NO_Btn.SelectedIndex == -1 || rblWMVintrsted.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter WallMart Vriddi Platform details');", true);


                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select onboarded on WallMart Vriddi or not');", true);

                }

            }
            if (chkOtherSchms.Checked)
            {
                if (!chkMAS.Checked && !chkPMS.Checked && !chkSMAS.Checked)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Marketing Grievance-Other Schemes Type');", true);

                }
                if (chkMAS.Checked)
                {
                    if (rblMASawrns.SelectedIndex != -1)
                    {
                        if (rblMASawrns.SelectedIndex == 0)
                        {
                            if (rblMASintrsted.SelectedIndex == -1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select interested to onBoard onto Marketing Assistance Scheme or not');", true);

                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness provided about the Marketing Assistance Scheme or not');", true);

                    }
                }
                if (chkPMS.Checked)
                {
                    if (rblPMSawrns.SelectedIndex != -1)
                    {
                        if (rblPMSawrns.SelectedIndex == 0)
                        {
                            if (rblPMSintrsted.SelectedIndex == -1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select interested to onBoard onto Procurement and Marketing Assistance Scheme or not');", true);

                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness provided about the Procurement and Marketing Support Scheme or not');", true);

                    }
                }
                if (chkSMAS.Checked)
                {
                    if (rblSMASawrns.SelectedIndex != -1)
                    {
                        if (rblSMASawrns.SelectedIndex == 0)
                        {
                            if (rblSMASintrsted.SelectedIndex == -1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select interested to onBoard onto Special Marketing Assistance Scheme or not');", true);

                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness provided about the Special Marketing Support Scheme or not');", true);

                    }
                }
            }
            if (chkmrkOthrs.Checked)
            {
                if (Marketing_Others_Text_Box.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Other Type Marketing Grievance');", true);

                }
            }

        }
        if (chkFinancial.Checked)
        {
            if (Financial_Types.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Financial Grievance type');", true);

            }
            else if (Financial_Types.SelectedItem.Text == "Issues related to Department")
            {
                if (department_issues_type.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Issues related to department');", true);

                }
                else if (department_issues_type.SelectedIndex == 1)
                {
                    if (MSEFCCase_Filed.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select unit filed case under MSEFC or not');", true);

                    }
                    else if (MSEFCCase_Filed.SelectedIndex == 0)
                    {
                        if (MSEFC_Case_Details.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Details of  Case filed under MSEFC');", true);

                        }
                    }
                    else if (MSEFCCase_Filed.SelectedIndex == 1)
                    {
                        if (MSEFCCase_Filed_No.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Whether Awareness on Facilitation Council is given or not');", true);

                        }
                    }

                }
            }
            else if (Financial_Types.SelectedItem.Text == "Online Platforms")
            {
                if (Invoice_Mart.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded onto Invoice Mart or not');", true);


                }
                else
                {
                    if (Invoice_Mart.SelectedIndex == 0)
                    {
                        if (rblIMofcrref.SelectedIndex == -1 || rblIMaftrCamps.SelectedIndex == -1 || InvoiceMartID.Text == "" || INVOICE_MART_Registration_DATE.Value == "" || No_of_Orders_received_Invoice_Mart.Text == "" ||
                            Order_Value_Invoice_Mart.Text == "" || No_of_Bills_Invoice_Mart.Text == "" || Bills_Value_Invoice_Mart.Text == ""
                            || No_of_Bills_Sold_Invoice_Mart.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter all details about Invoice Mart');", true);

                        }
                        if (rblIMaftrCamps.SelectedValue == "0" && txtIMcampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in Invoice Mart Platform details');", true);

                        }

                    }
                    else if (Invoice_Mart.SelectedIndex == 1)
                    {
                        if (rblIMawrns.SelectedIndex != -1)
                        {
                            if (rblIMawrns.SelectedItem.Text == "Yes")
                            {
                                if (rblIMintrsted.SelectedIndex == -1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit is interested to onboard onto InvoiceMart or not');", true);

                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select awarenss provided about Factoring/ inreverse Factoring');", true);

                        }
                    }

                }
                if (NSE.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded onto NSE or not');", true);

                }
                else
                {
                    if (NSE.SelectedIndex == 0)
                    {
                        if (rblNSElisted.SelectedIndex == -1 || rblNSEofcrref.SelectedIndex == -1 || rblNSEaftrCamps.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Whether Listed about NSE Platform');", true);

                        }
                        if (rblNSEaftrCamps.SelectedValue == "0" && txtNSEcampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in NSE details');", true);

                        }
                    }
                    else if (NSE.SelectedIndex == 1)
                    {
                        if (rblNSEawrns.SelectedIndex != -1)
                        {
                            if (rblNSEawrns.SelectedItem.Text == "Yes")
                            {
                                if (rblNSEintrsted.SelectedIndex == -1)
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit is intersted to onboard on to NSE or not');", true);

                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness Provided on Listing NSE  or not');", true);

                        }
                    }
                }
                if (SIDBI.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded onto NSE or not');", true);

                }
                else
                {
                    if (SIDBI.SelectedItem.Text == "Yes")
                    {
                        if (rblSIDBIofcrref.SelectedIndex == -1 || rblSIDBIaftrCamps.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit OnBoarded into SIDBI with officer reference or not');", true);

                        }
                        if (rblSIDBIaftrCamps.SelectedValue == "0" && txtSIDBIcampdate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter camp date in SIDBI details');", true);

                        }
                    }
                    else if (SIDBI.SelectedItem.Text == "No")
                    {
                        if (rblSIDBIawrns.SelectedIndex != -1)
                        {
                            if (rblSIDBIintrsted.SelectedIndex == -1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select unit is intersted to onboard on to SIDBI or not');", true);

                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Awareness Provided on Listing SIDBI  or not');", true);

                        }
                    }
                }
            }
        }
        if (chkTechnical.Checked)
        {
            if (lbltchNA.Visible == false)
            {
                if (TechnicalType_Grievance.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Technical Grievance Type');", true);

                }
                else
                {
                    if (rblTechnSchms.SelectedIndex == 0)
                    {
                        if (TechnicalType_Grievance.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Issue Related');", true);
                        }
                        if (TechnicalType_Grievance.SelectedIndex == 1)
                        {
                            if (ddlLineDepartment.SelectedItem.Text == "--Select--")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Line Department Technical Grievance Type');", true);

                            }
                        }
                        if (TechnicalType_Grievance.SelectedIndex == 2)
                        {
                            if (Technical_Others.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Other Technical Grievance Type');", true);
                            }
                        }
                    }
                    else if (rblTechnSchms.SelectedIndex == 1)
                    {
                        if (rdincentives.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Issue Related');", true);
                        }
                    }
                    else if (rblTechnSchms.SelectedIndex == 3)
                    {
                        if (rdrawmaterial.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Issue Related');", true);
                        }
                    }
                    else if (rblTechnSchms.SelectedIndex == 4)
                    {
                        if (MSEFCCase_Filed.SelectedIndex == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Whether Unit filed case under MSEFC');", true);
                        }
                    }
                }
            }
        }
        if (chkLand.Checked)
        {
            if (Land_Grievance.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Land Type of Grievance related to');", true);


            }
            else
            {
                if (TSIIC_LAND_Select.Visible == true && rblvacantplots.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select about TSIIC land');", true);

                }
                if (Land_Text_Box.Visible == true && TextBox1.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter other type of land grievance');", true);

                }
            }
        }
        if (Other_Grievance_Block.Visible == true && TextBox2.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter other grievance type');", true);

        }

        return ErrorMsg;
    }
    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/Personal_Interaction_Page_EXISTING_Entrepreneurs.aspx");
    }
    private object GetSelectedValue(ListControl control)
    {
        return control.SelectedItem != null ? (object)control.SelectedItem.Text : DBNull.Value;
    }
    private object GetSelectedValueddl(ListControl control)
    {
        return control.SelectedItem.Text != "--Select--" ? (object)control.SelectedItem.Text : DBNull.Value;
    }
    object ToDBValue(string str)
    {
        return string.IsNullOrEmpty(str) ? DBNull.Value : (object)str;
    }


    protected void ddlvenuemandl_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlvenuemandl.SelectedItem.Text == "Others")
            {
                lblothrvenue.Visible = true;
                Interaction_Venue.Visible = true;
            }
            else
            {
                lblothrvenue.Visible = false;
                Interaction_Venue.Visible = false;
            }
        }
        catch (Exception ex)
        { throw ex; }
    }


    protected void Marketing_Types_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (Marketing_Types.Items[0].Selected)
            {
                Marketing_BLOCK_OFF.Visible = true;
                Grievance_Identified_Marketing_ECOMMERCE.Visible = true;
            }
            else
            {
                Grievance_Identified_Marketing_ECOMMERCE.Visible = false;
                clearecommercefeilds();
            }
            if (Marketing_Types.Items[1].Selected)
            {

                Marketing_BLOCK_OFF.Visible = true;
                Grievance_Identified_Marketing_Schemes.Visible = true;
            }
            else
            {
                Grievance_Identified_Marketing_Schemes.Visible = false;
                clearotherchemesfeilds();
            }
            if (Marketing_Types.Items[2].Selected)
            {

                Grievance_Identified_Marketing_Others.Visible = true;
                //clearecommercefeilds();
                //clearotherchemesfeilds();

            }
            else
            {
                Grievance_Identified_Marketing_Others.Visible = false;
                Marketing_Others_Text_Box.Text = "";
            }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void chkecommrce_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkecommrce.Checked)
            {
                Marketing_BLOCK_OFF.Visible = true;
                Grievance_Identified_Marketing_ECOMMERCE.Visible = true;
            }
            else
            {
                clearecommercefeilds();
                Grievance_Identified_Marketing_ECOMMERCE.Visible = false;
                rblMeesho_SelectedIndexChanged(sender, e);
                rblJustDial_SelectedIndexChanged(sender, e);
                rblTSGlobal_SelectedIndexChanged(sender, e);
                rblWallmart_SelectedIndexChanged(sender, e);

            }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void chkOtherSchms_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkOtherSchms.Checked)
            {
                Marketing_BLOCK_OFF.Visible = true;
                Grievance_Identified_Marketing_Schemes.Visible = true;

                //divMAS.Visible = true;
                //divPMS.Visible = true;
                //divSMAS.Visible = true;
            }
            else
            {
                Grievance_Identified_Marketing_Schemes.Visible = false;
                clearotherchemesfeilds();
                chkMAS.Checked = false; chkMAS_CheckedChanged(sender, e);
                chkSMAS.Checked = false; chkSMAS_CheckedChanged(sender, e);
                chkPMS.Checked = false; chkPMS_CheckedChanged(sender, e);
                rblMAS.ClearSelection();
                rblPMS.ClearSelection();
                rblSMAS.ClearSelection();
            }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void chkmrkOthrs_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkmrkOthrs.Checked)
            {
                Grievance_Identified_Marketing_Others.Visible = true;
            }
            else
            {
                Grievance_Identified_Marketing_Others.Visible = false;
                Marketing_Others_Text_Box.Text = "";
            }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void SelectCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
            int index = row.RowIndex;

            CheckBox chk = (CheckBox)row.FindControl("SelectCheckBox");
            if (chk != null & chk.Checked)
            {
                Label Name = (Label)row.FindControl("Applicant_Name");
                Label UID = (Label)row.FindControl("UIDNo");
                Label applcantemail = (Label)row.FindControl("applEmail");
                Label LOAID = (Label)row.FindControl("Lineofactivity");
                Label applGender = (Label)row.FindControl("applGender");
                Label applCaste = (Label)row.FindControl("applCaste");


                Session["UIDNO"] = UID.Text;
                Session["ApplEmail"] = applcantemail.Text;
                Session["LOAID"] = LOAID.Text;
                Session["Gender"] = applGender.Text;
                Session["caste"] = applCaste.Text;
                string WomanGender = "";
                if (Women_Cell.SelectedIndex != -1)
                {
                    WomanGender = Convert.ToString(Women_Cell.SelectedItem.Text);
                }
                if (applGender.Text == "FEMALE" || WomanGender == "Yes")
                { trwehub.Visible = true; }

                if ((UID.Text != "" && UID.Text.Contains("LRG")) || (UID.Text != "" && UID.Text.Contains("MEG")))
                {
                    Session["IsMajorExist"] = "Yes";
                    chkecommrce.Visible = false; chkecommrce.Checked = false; chkecommrce_CheckedChanged(sender, e);
                    chkOtherSchms.Visible = false; chkOtherSchms.Checked = false; chkOtherSchms_CheckedChanged(sender, e);
                    Financial_Types.Items.RemoveAt(1);
                    //lbltchNA.Visible = true;
                    //Technical_block.Visible = false;
                }
                else
                {
                    Session["isMajorExist"] = "No";
                    chkecommrce.Visible = true; chkecommrce.Checked = false;
                    chkOtherSchms.Visible = true; chkOtherSchms.Checked = false;
                    Financial_Grievance();
                    //Technical_block.Visible = true;
                    //lbltchNA.Visible = false;
                }
            }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void Applicant_Investment_TextChanged(object sender, EventArgs e)
    {
        if (Applicant_Investment.Text != "")
        {
            //Grievance_Identified.Enabled = true;
            if (Convert.ToInt64(Applicant_Investment.Text) > 100000000)
            {
                Session["isMajorNew"] = "Yes";
                chkecommrce.Visible = false; chkecommrce.Checked = false; chkecommrce_CheckedChanged(sender, e);
                chkOtherSchms.Visible = false; chkOtherSchms.Checked = false; chkOtherSchms_CheckedChanged(sender, e);
                Financial_Types.Items.RemoveAt(1);
                //lbltchNA.Visible = true;
                //Technical_block.Visible = false;
            }
            else
            {
                Session["isMajorNew"] = "No";
                chkecommrce.Visible = true; chkecommrce.Checked = false;
                chkOtherSchms.Visible = true; chkOtherSchms.Checked = false;
                Financial_Grievance();
                //Technical_block.Visible = true;
                //lbltchNA.Visible = false;
            }

        }
    }

    protected void rblIMawrns_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblIMawrns.SelectedValue == "0")
            { trIMrtonbord.Visible = true; }
            else { trIMrtonbord.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void rblIMintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (rblIMintrsted.SelectedValue == "0")
            { trIMrtonbordlink.Visible = true; }
            else { trIMrtonbordlink.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }

    }

    protected void rblNSEawrns_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblNSEawrns.SelectedValue == "0")
            { trNSEonbord.Visible = true; }
            else { trNSEonbord.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void rblNSEintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblNSEintrsted.SelectedValue == "0")
            { trNSEonbordlink.Visible = true; }
            else { trNSEonbordlink.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void rblSIDBIawrns_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblSIDBIawrns.SelectedValue == "0")
            { trsidbiintrst.Visible = true; }
            else { trsidbiintrst.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void rblSIDBIintrsted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblSIDBIintrsted.SelectedValue == "0")
            { trsidblink.Visible = true; }
            else { trsidblink.Visible = false; }
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void linkMSMECatlg_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://ipass.telangana.gov.in/UI/TSiPASS/frmcapturemsmenew.aspx";
            sendLinkbymail("MSME Catalogue", link);
            linkMSMECatlg.ForeColor = System.Drawing.Color.Gray;
            linkMSMECatlg.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void LinkMeesho_Click(object sender, EventArgs e)
    {
        try
        {
            //string link = "< a href = 'https://www.meesho.com/' target = '_blank' > Meeshow </ a >.";
            string link = "https://www.meesho.com/";

            sendLinkbymail("Meesho Online Platform", link);
            LinkMeesho.ForeColor = Color.DarkGray;
            LinkMeesho.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }

    protected void LinkJustdial_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.justdial.com/";
            sendLinkbymail("Justdial Online Platform", link);
            LinkJustdial.ForeColor = Color.DarkGray;
            LinkJustdial.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void LinkTSGlobal_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://ts-msme.globallinker.com/' ";
            sendLinkbymail("TSGlobalLinker Online Platform", link);
            LinkTSGlobal.ForeColor = Color.DarkGray;
            LinkTSGlobal.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void LinkWallmart_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.walmartvriddhi.org/'";
            sendLinkbymail("walmartVriddhi Online Platform", link);
            LinkWallmart.ForeColor = Color.DarkGray;
            LinkWallmart.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void LinkMAS_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.nsic.co.in/schemes/MarketingAssistance' ";
            sendLinkbymail("Marketing Assistance Scheme", link);
            LinkMAS.ForeColor = Color.DarkGray;
            LinkMAS.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void LinkPMS_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://msme.gov.in/1-marketing-promotion-schemes' ";
            sendLinkbymail("Procurement and Marketing Support Scheme", link);
            LinkPMS.ForeColor = Color.DarkGray;
            LinkPMS.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void LinkSMAS_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://msme.gov.in/special-marketing-assistance-scheme' ";
            sendLinkbymail("Special Marketing Assistance Scheme", link);
            LinkSMAS.ForeColor = Color.DarkGray;
            LinkSMAS.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void LinkInvoice_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.invoicemart.com";
            sendLinkbymail("InvoiceMart Online Platform", link);
            LinkInvoice.ForeColor = Color.DarkGray;
            LinkInvoice.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void LinkNSE_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.nseindia.com";
            sendLinkbymail("NSE Online Platform", link);
            LinkNSE.ForeColor = Color.DarkGray;
            LinkNSE.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void SidbiLink_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.sidbi.in/en' ";
            sendLinkbymail("SIDBI Online Platform", link);
            SidbiLink.ForeColor = Color.DarkGray;
            SidbiLink.Enabled = false;

        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void linkwehub_Click(object sender, EventArgs e)
    {
        try
        {
            chkwehub.Checked = true; chkwehub.Enabled = false;
            string link = "https://wehub.telangana.gov.in/ ";
            sendLinkbymail("WeHub", link);
            linkwehub.ForeColor = System.Drawing.Color.Gray;
            linkwehub.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void chkhlthclinc_CheckedChanged(object sender, EventArgs e)
    {
        linkhealthclinic_Click(sender, e);

    }

    protected void chkwehub_CheckedChanged(object sender, EventArgs e)
    {
        linkwehub_Click(sender, e);
    }
    protected void linkhealthclinic_Click(object sender, EventArgs e)
    {

        try
        {
            chkhlthclinc.Checked = true; chkhlthclinc.Enabled = false;
            string link = "https://tihcl.telangana.gov.in ";
            sendLinkbymail("Health Clinic", link);
            linkhealthclinic.ForeColor = System.Drawing.Color.Gray;
            linkhealthclinic.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }
    protected void sendLinkbymail(string platformname, string link)
    {
        try
        {
            string to = "";
            if (TS_IPASS_REGISTERED_Unit.SelectedIndex != -1)
            {
                if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "Yes")
                { to = txtemailExistng.Text; }
                else if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "No")
                { to = Applicant_Email.Text; }
            }
            if (to != "")
            {
                //< a href = 'https://www.sidbi.in/en' target = '_blank' > SIDBI </ a >.
                string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);
                mail.Subject = platformname + "Link";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = "Dear Sir/madam, <br><br> This is the link of " + platformname + ": -" + "<a href = '" + link + "' target = '_blank' >" + platformname + "</a>" + " <br> Please click on the above link to know about " + platformname + "<br> <br>Regards,<br>Commissionerate of Industries,<br>MSME WING.";
                mail.BodyEncoding = System.Text.Encoding.UTF8;

                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                SmtpClient client = new SmtpClient();
                //Add the Creddentials- use your own email id and password

                //client.Credentials = new System.Net.NetworkCredential(from, "lrefskmlxnoowqtc");
                client.Credentials = new System.Net.NetworkCredential(from, "fqeq nive azke giwb");


                client.Port = 587; // Gmail works on this port lrefskmlxnoowqtc
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true; //Gmail works on Server Secured Layer tsipass@2016
                try
                {
                    client.Send(mail);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('An e-mail has been sent');", true);
                    //Session.Remove("File");
                    //Session.Remove("FileName");
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Error occured, EMail not sent');", true);

                    //HttpContext.Current.Response.Write(errorMessage);
                } // end try
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void ddladrsmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddladrsmandal.SelectedItem.Text == "--Select--")
        {
            ddladrsvlg.DataSource = null; ddladrsvlg.DataBind();

        }
        else
        {
            ddladrsvlg.DataSource = UID_Village_List(Convert.ToInt32(ddladrsmandal.SelectedValue));
            ddladrsvlg.DataTextField = "village_name";
            ddladrsvlg.DataValueField = "Village_Id";
            ddladrsvlg.DataBind();
            ddladrsvlg.Enabled = true;

        }

    }


    protected void rblMSaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblMSaftrCamps.SelectedValue == "0")
        { trMScampdate.Visible = true; }
        else { trMScampdate.Visible = false; txtMScampdate.Text = ""; }
    }
    protected void rblJDaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblJDaftrCamps.SelectedValue == "0")
        { trJDcampdate.Visible = true; }
        else { trJDcampdate.Visible = false; txtJDcampdate.Text = ""; }
    }

    protected void rblTSGaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblTSGaftrCamps.SelectedValue == "0")
        { trTSGcampdate.Visible = true; }
        else { trTSGcampdate.Visible = false; txtTSGcampdate.Text = ""; }

    }

    protected void rblWMVaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblWMVaftrCamps.SelectedValue == "0")
        { trWMVcampdate.Visible = true; }
        else { trWMVcampdate.Visible = false; txtWMVcampdate.Text = ""; }

    }

    protected void rblIMaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblIMaftrCamps.SelectedValue == "0")
        { trIMcampdate.Visible = true; }
        else { trIMcampdate.Visible = false; txtIMcampdate.Text = ""; }
    }
    protected void rblNSEaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblNSEaftrCamps.SelectedValue == "0")
        { trNSEcampdate.Visible = true; }
        else { trNSEcampdate.Visible = false; txtNSEcampdate.Text = ""; }
    }

    protected void rblSIDBIaftrCamps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSIDBIaftrCamps.SelectedValue == "0")
        { trSIDBIcampdate.Visible = true; }
        else { trSIDBIcampdate.Visible = false; txtSIDBIcampdate.Text = ""; }
    }





    //protected void rblWeHub_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (rblWeHub.SelectedValue == "0")
    //    { linkwehub.Visible = true; chkwehub.Visible = true; }
    //    else { linkwehub.Visible = false; chkwehub.Visible = false; }
    //    }



    protected void rblsick_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblsick.SelectedValue == "0")
        {
            trHealthclinic.Visible = true;
        }
        else
        {
            chkhlthclinc.Checked = false;
            trHealthclinic.Visible = false;
        }
    }

    //protected void rblHealthclinic_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (rblHealthclinic.SelectedValue == "0")
    //    { trhlthclnclink.Visible = true; }
    //    else trhlthclnclink.Visible = false;
    //}




    protected void rblTechnSchms_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblTechnSchms.SelectedIndex == 0)
        {
            trtechissue.Visible = true;
            trtechschmsothrs.Visible = false;
            txttechschmsothrs.Text = "";
            Financial_Departmental_Issues.Visible = false;
            department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
            MSEFCCase_Filed_No.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
            MSEFC_Case_Details.Text = "";
            trincentives.Visible = false;
            trRawmaterial.Visible = false;
        }
        else if (rblTechnSchms.SelectedIndex == 1)
        {
            trincentives.Visible = true;
            trRawmaterial.Visible = false;
            trtechissue.Visible = false;
            trtechschmsothrs.Visible = false;
            txttechschmsothrs.Text = "";
            Financial_Departmental_Issues.Visible = false;
            department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
            MSEFCCase_Filed_No.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
            MSEFC_Case_Details.Text = "";
        }
        else if (rblTechnSchms.SelectedIndex == 2)
        {
            trincentives.Visible = false;
            trRawmaterial.Visible = true;
            trtechissue.Visible = false;
            trtechschmsothrs.Visible = false;
            txttechschmsothrs.Text = "";
            Financial_Departmental_Issues.Visible = false;
            department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
            MSEFCCase_Filed_No.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
            MSEFC_Case_Details.Text = "";
        }
        else if (rblTechnSchms.SelectedItem.Text == "MSEFC")
        {
            Financial_Departmental_Issues.Visible = true;
            MSEFC_Case_Filed_Yes.Visible = true;
            trtechissue.Visible = false; TechnicalType_Grievance.ClearSelection();
            Line_department_block.Visible = false; ddlLineDepartment.ClearSelection();
            trtechschmsothrs.Visible = false;
            Technical_Others_TXT_BOX.Visible = false; Technical_Others.Text = "";
            txttechschmsothrs.Text = "";
        }
        else if (rblTechnSchms.SelectedItem.Text == "Others")
        {
            trtechschmsothrs.Visible = true;
            Technical_Others_TXT_BOX.Visible = false; Technical_Others.Text = "";
            trtechissue.Visible = false;
            TechnicalType_Grievance.ClearSelection();
            TechnicalType_Grievance_SelectedIndexChanged(sender, e);
            Line_department_block.Visible = false;
            ddlLineDepartment.ClearSelection();
            Technical_Others.Text = "";
            Financial_Departmental_Issues.Visible = false;
            department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
            MSEFCCase_Filed_No.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
            MSEFC_Case_Details.Text = "";

        }
        else
        {
            trtechissue.Visible = false;
            Technical_Others_TXT_BOX.Visible = false; Technical_Others.Text = "";
            trtechschmsothrs.Visible = false;
            TechnicalType_Grievance.ClearSelection();
            TechnicalType_Grievance_SelectedIndexChanged(sender, e);
            Line_department_block.Visible = false;
            ddlLineDepartment.ClearSelection();
            Technical_Others.Text = "";
            Financial_Departmental_Issues.Visible = false;
            department_issues_type.ClearSelection(); department_issues_type_SelectedIndexChanged(sender, e);
            MSEFCCase_Filed_No.ClearSelection(); MSEFCCase_Filed_SelectedIndexChanged(sender, e);
            MSEFC_Case_Details.Text = "";

        }
    }

    protected void rblMSMEreg_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblMSMEreg.SelectedItem.Text == "No")
        {
            trMSMEmap.Visible = true;
        }
        else
            trMSMEmap.Visible = false;
        //if (rblMSMEreg.SelectedItem.Text == "Yes")
        //{

        //    if (TS_IPASS_REGISTERED_Unit.SelectedItem.Text == "Yes")
        //    {
        //        if (Convert.ToString(Session["LOAID"]) != "" && DropDownList1.SelectedItem.Text != "--Select--" && TS_IPASS_UID_SEARCH.Text != "")
        //        {
        //            fillMSMEUnits(DropDownList1.SelectedValue, TS_IPASS_UID_SEARCH.Text, Session["LOAID"].ToString());
        //            //trmsmeunits.Visible = true;
        //        }
        //        else { }

        //    }
        //    else
        //    {
        //        if (ddladrsmandal.SelectedItem.Text != "--Select--" && Applicant_Name.Text != "" && sector_dropdown.SelectedItem.Text != "--Select--")
        //        {
        //            fillMSMEUnits(ddladrsmandal.SelectedValue, Applicant_Name.Text, sector_dropdown.SelectedValue);
        //            //trmsmeunits.Visible = true;
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please fill all the above details ');", true);
        //            return;
        //        }
        //    }
        //}
        //else
        //{
        //    trmsmeunits.Visible = false;
        //    ddlmapunits.ClearSelection();
        //}

    }


    protected void rblMAS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblMAS.SelectedItem.Text == "Yes")
        { SCHEME_MAS_BLOCK.Visible = true; }
        else
        {
            SCHEME_MAS_BLOCK.Visible = false;
            rblMASawrns.ClearSelection(); rblMASawrns_SelectedIndexChanged(sender, e);
            rblMASintrsted.ClearSelection(); rblMASintrsted_SelectedIndexChanged(sender, e);
        }

    }

    protected void rblPMS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblPMS.SelectedItem.Text == "Yes")
        { SCHEME_PMS_BLOCK.Visible = true; }
        else
        {
            SCHEME_PMS_BLOCK.Visible = false;
            rblPMSawrns.ClearSelection(); rblPMSawrns_SelectedIndexChanged(sender, e);
            rblPMSintrsted.ClearSelection(); rblPMSintrsted_SelectedIndexChanged(sender, e);
        }

    }

    protected void rblSMAS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSMAS.SelectedItem.Text == "Yes")
        { SCHEME_SMAS_BLOCK.Visible = true; }
        else
        {
            SCHEME_SMAS_BLOCK.Visible = false;
            rblSMASawrns.ClearSelection(); rblSMASawrns_SelectedIndexChanged(sender, e);
            rblSMASintrsted.ClearSelection(); rblSMASintrsted_SelectedIndexChanged(sender, e);
        }

    }



    protected void grdvacantplots_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void Applicant_caste_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Applicant_caste.SelectedItem.Text == "OBC" || Applicant_caste.SelectedItem.Text == "ST" || Applicant_caste.SelectedItem.Text == "SC" || Applicant_caste.SelectedItem.Text == "Minority")
        {
            landdesc.Text = "a-1. Whether information on vacant plots mandated to Weaker Section is informed :";
            grdvacantplots.Visible = true;
        }
        else
        {
            landdesc.Text = "a-1. Whether information on vacant plots informed :";
            grdvacantplots.Visible = false;
        }
    }
    protected void Applicant_Gender_SelectedIndexChanged(object sender, EventArgs e)
    {
        string WomanGender = "";
        if (Women_Cell.SelectedIndex != -1)
        {
            WomanGender = Convert.ToString(Women_Cell.SelectedItem.Text);
        }
        if (Applicant_Gender.SelectedItem.Text == "Female" || WomanGender == "Yes")
        { trwehub.Visible = true; }
    }

    protected void LineOfActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (LineOfActivity.SelectedValue == "0")
            {
                trodopexport.Visible = true;
                trodoplink.Visible = false;
            }
            else
            {
                trodopexport.Visible = false;
                trodoplink.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void rdodpexport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdodpexport.SelectedValue == "0")
            {
                trodopexport.Visible = true;
                trodoplink.Visible = true;
            }
            else
            {
                //trodopexport.Visible = false;
                trodoplink.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void lnkodop_Click(object sender, EventArgs e)
    {
        try
        {
            try
            {                
                string link = "https://www.dgft.gov.in/CP/ ";
                sendLinkbymail("DGFT", link);
                lnkodop.ForeColor = System.Drawing.Color.Gray;
                lnkodop.Enabled = false;
            }
            catch (Exception ex)
            { throw ex; }
        }
        catch (Exception ex)
        {

        }
    }

    protected void MSEFCCase_Filed_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(MSEFCCase_Filed_No.SelectedValue=="1")
        {
            trmsefc.Visible = true;
        }
        else
        {
            trmsefc.Visible = false;
        }
    }

    protected void lnkmsefc_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://esamadhan.nic.in/ ";
            sendLinkbymail("MSEFC", link);
            lnkodop.ForeColor = System.Drawing.Color.Gray;
            lnkodop.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }
}