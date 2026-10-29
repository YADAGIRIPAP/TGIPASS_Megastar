using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_CAMPS_CONDUCTED : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    static DataTable EDPguests;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["uid"] == null || Session["uid"].ToString() == "")
            {
                Response.Redirect("~/TSHome.aspx");

            }
            else
            {
                if (Session["Role_Code"].ToString() == "GM" )
                {
                    if (!IsPostBack)
                    {
                        EDP_OTHERS_CHK_BOX_Input.Visible = false;
                        EDP_CONTENT.Visible = false;
                        SUBMIT_CLEAR_BTNS.Visible = false;
                        bindofficers();
                    }
                    if (TYPEOFCAMPLIST.SelectedIndex.ToString() != null || chekEDPCamplist.SelectedIndex.ToString() != null)
                    {
                        Bindfileuploads();
                    }
                }
                else Response.Redirect("~/TSHome.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void bindofficers()
    {
        DataSet dsofficers = new DataSet();
        dsofficers = GetDepartmentINcentiveNew(Session["DistrictID"].ToString());
        if (dsofficers != null && dsofficers.Tables.Count > 0 && dsofficers.Tables[0].Rows.Count > 0)
        {
            chkofficers.DataSource = dsofficers.Tables[0];
            chkofficers.DataTextField = "OfficerName";
            chkofficers.DataValueField = "OfficerID";
            chkofficers.DataBind();
            campalong.Visible = true;
        }
        else
        {
            campalong.Visible = false;
        }
    }
    public DataSet GetDepartmentINcentiveNew(string Districtid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GetDepartmentOfficers_11REPORTS]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@District_ID", SqlDbType.VarChar).Value = Districtid;
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
    protected void Bindfileuploads()
    {
        try
        {
            //---------------- fileuploads---------------//
            if (TYPEOFCAMPLIST.Items[0].Selected || TYPEOFCAMPLIST.Items[1].Selected || chekEDPCamplist.SelectedIndex.ToString() != null)
            {
                if (FupEDP_Dias.HasFile)
                {
                    Session["FupEDP_Dias"] = FupEDP_Dias; FupEDP_Dias = (FileUpload)Session["FupEDP_Dias"]; HplEDP_Dias.Text = FupEDP_Dias.FileName; HplEDP_Dias.Visible = true;
                }
                else if (Session["FupEDP_Dias"] != null && (!FupEDP_Dias.HasFile))
                {
                    FupEDP_Dias = (FileUpload)Session["FupEDP_Dias"]; HplEDP_Dias.Text = FupEDP_Dias.FileName; HplEDP_Dias.Visible = true;
                }

                if (FupEDP_Speaker.HasFile)
                {
                    Session["FupEDP_Speaker"] = FupEDP_Speaker; FupEDP_Speaker = (FileUpload)Session["FupEDP_Speaker"]; HplEDP_Speaker.Text = FupEDP_Speaker.FileName; HplEDP_Speaker.Visible = true;
                }
                else if (Session["FupEDP_Speaker"] != null && (!FupEDP_Speaker.HasFile))
                {
                    FupEDP_Speaker = (FileUpload)Session["FupEDP_Speaker"]; HplEDP_Speaker.Text = FupEDP_Speaker.FileName; HplEDP_Speaker.Visible = true;
                }
                if (FupEDP_Audience.HasFile)
                {
                    Session["FupEDP_Audience"] = FupEDP_Audience; FupEDP_Audience = (FileUpload)Session["FupEDP_Audience"]; HplEDP_Audience.Text = FupEDP_Audience.FileName; HplEDP_Audience.Visible = true;
                }
                else if (Session["FupEDP_Audience"] != null && (!FupEDP_Audience.HasFile))
                {
                    FupEDP_Audience = (FileUpload)Session["FupEDP_Audience"]; HplEDP_Audience.Text = FupEDP_Audience.FileName; HplEDP_Audience.Visible = true;
                }
                if (FupEDP_Others.HasFile)
                {
                    Session["FupEDP_Others"] = FupEDP_Others; FupEDP_Others = (FileUpload)Session["FupEDP_Others"]; HplEDP_Others.Text = FupEDP_Others.FileName; HplEDP_Others.Visible = true;
                }
                else if (Session["FupEDP_Others"] != null && (!FupEDP_Others.HasFile))
                {
                    FupEDP_Others = (FileUpload)Session["FupEDP_Others"]; HplEDP_Others.Text = FupEDP_Others.FileName; HplEDP_Others.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void TYPEOFCAMPLIST_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (TYPEOFCAMPLIST.Items[0].Selected)
            {
                ChkEDP_Venue.Items.RemoveAt(1);
                ChkEDP_Venue.Items.Insert(1, "DIC Office");
                ChkEDP_Venue.Items.RemoveAt(2);
                ChkEDP_Venue.Items.Insert(2, "IE's/IP's");

            }
            else
            {
                ChkEDP_Venue.Items.RemoveAt(1);
                ChkEDP_Venue.Items.Insert(1, "College");
                ChkEDP_Venue.Items.RemoveAt(2);
                ChkEDP_Venue.Items.Insert(2, "Women's College");
            }

            if (TYPEOFCAMPLIST.Items[1].Selected)
            {
                lblindividuals.InnerText = "No.of MSME's Attended :";
                divplatfomrs.Visible = true;
            }
            else
            {
                lblindividuals.InnerText = "No.of Individuals Attended:";
                divplatfomrs.Visible = false;
            }
            if (TYPEOFCAMPLIST.Items[0].Selected || TYPEOFCAMPLIST.Items[1].Selected)
            { EDP_CONTENT.Visible = true; SUBMIT_CLEAR_BTNS.Visible = true; }
            else
            { EDP_CONTENT.Visible = false; SUBMIT_CLEAR_BTNS.Visible = false; }

            if (!TYPEOFCAMPLIST.Items[0].Selected && !TYPEOFCAMPLIST.Items[1].Selected)
            { SUBMIT_CLEAR_BTNS.Visible = false; }
            else { SUBMIT_CLEAR_BTNS.Visible = true; }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ChkEDP_Venue_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ChkEDP_Venue.Items[7].Selected)
            {
                EDP_OTHERS_CHK_BOX_Input.Visible = true;
                EDP_OTHERS_CHK_BOX_Input.Focus();
            }
            else
            {
                EDP_OTHERS_CHK_BOX_Input.Visible = false;
                //DateOfCampConducted_EDP.Focus();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void EDPGuests_Click(object sender, EventArgs e)
    {
        try
        {
            if (EDP_Guest_Name_1.Value != "" && EDP_Guest_Designation_1.Value != "" && EDP_Guest_Department_1.Value != "")
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("EDP_GuestName", typeof(string));
                dt.Columns.Add("EDP_GuestDesgn", typeof(string));
                dt.Columns.Add("EDP_GuestDept", typeof(string));

                if (ViewState["EDPGusetsTable"] != null)
                {
                    dt = (DataTable)ViewState["EDPGusetsTable"];
                }
                DataRow dr = dt.NewRow();

                dr["EDP_GuestName"] = EDP_Guest_Name_1.Value;
                dr["EDP_GuestDesgn"] = EDP_Guest_Designation_1.Value;
                dr["EDP_GuestDept"] = EDP_Guest_Department_1.Value;

                dt.Rows.Add(dr);
                gvEDPguests.Visible = true;
                gvEDPguests.DataSource = dt;
                gvEDPguests.DataBind();
                ViewState["EDPGusetsTable"] = dt;
                EDP_Guest_Name_1.Value = "";
                EDP_Guest_Designation_1.Value = "";
                EDP_Guest_Department_1.Value = "";
                EDP_Guest_Name_1.Focus();
            }
            else
                return;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvEDPguests_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (gvEDPguests.Rows.Count > 0)
            {
                ((DataTable)ViewState["EDPGusetsTable"]).Rows.RemoveAt(e.RowIndex);
                this.gvEDPguests.DataSource = ((DataTable)ViewState["EDPGusetsTable"]).DefaultView;
                this.gvEDPguests.DataBind();
                gvEDPguests.Visible = true;
                gvEDPguests.Focus();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvEDPguests_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvEDPguests.Focus();
            gvEDPguests.EditIndex = e.NewEditIndex;
            gvEDPguests.DataSource = ((DataTable)ViewState["EDPGusetsTable"]).DefaultView;
            gvEDPguests.Visible = true;
            gvEDPguests.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvEDPguests_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["EDPGusetsTable"];
            GridViewRow row = gvEDPguests.Rows[e.RowIndex];
            string name = (row.Cells[1].Controls[0] as TextBox).Text;
            string Desgn = (row.Cells[2].Controls[0] as TextBox).Text;
            string dept = (row.Cells[3].Controls[0] as TextBox).Text;

            int index = e.RowIndex;
            dt.Rows[index]["EDP_GuestName"] = name;
            dt.Rows[index]["EDP_GuestDesgn"] = Desgn;
            dt.Rows[index]["EDP_GuestDept"] = dept;
            gvEDPguests.EditIndex = -1;
            ViewState["EDPGusetsTable"] = dt;
            gvEDPguests.DataSource = dt;
            gvEDPguests.DataBind();
            gvEDPguests.Focus();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvEDPguests_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvEDPguests.EditIndex = -1;
            gvEDPguests.Visible = true;
            gvEDPguests.DataSource = ((DataTable)ViewState["EDPGusetsTable"]).DefaultView;
            gvEDPguests.DataBind();
            gvEDPguests.Focus();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        try
        {
            //FupEDP_Dias = (FileUpload)Session["FupEDP_Dias"]; FupEDP_Speaker = (FileUpload)Session["FupEDP_Speaker"];
           // FupEDP_Audience = (FileUpload)Session["FupEDP_Audience"]; FupEDP_Others = (FileUpload)Session//["FupEDP_Others"];

            if (TYPEOFCAMPLIST.Items[0].Selected || TYPEOFCAMPLIST.Items[1].Selected || chekEDPCamplist.SelectedIndex.ToString() != null)
            {
                if (chkofficers.SelectedIndex == -1 || VenueTXTEDP.Text == "" || VENUE_EDP_LOCATION.Text == "" || ChkEDP_Venue.SelectedItem.Text == "Select" || DateOfCampConducted_EDP.Text == ""
                    || ddltime_EDP.SelectedItem.Text == "Select" || NoOfMALES_ATTENDED_EDP.Text == "" || NoOfFEMALES_ATTENDED_EDP.Text == "" ||
                    gvEDPguests.Rows.Count == 0 || chkPlatforms.SelectedIndex.ToString() == null ||
                    !(FupEDP_Dias.HasFile || FupEDP_Dias.PostedFile.ContentType == "image/jpeg" || FupEDP_Dias.PostedFile.ContentType == "image/png") ||
                    !(FupEDP_Speaker.HasFile && (FupEDP_Speaker.PostedFile.ContentType == "image/jpeg" || FupEDP_Speaker.PostedFile.ContentType == "image/png")) ||
                    !(FupEDP_Audience.HasFile && (FupEDP_Audience.PostedFile.ContentType == "image/jpeg" || FupEDP_Speaker.PostedFile.ContentType == "image/png")) ||
                    !(FupEDP_Others.HasFile && (FupEDP_Others.PostedFile.ContentType == "image/jpeg" || FupEDP_Others.PostedFile.ContentType == "image/png")))

                {
                    VenueTXTEDP.Focus();
                    HplEDP_Dias.Text = ""; HplEDP_Speaker.Text = ""; HplEDP_Audience.Text = ""; HplEDP_Others.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter all details of camp including Photographs (in jpg format only)');", true);
                    return;
                }

            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString); ;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Sp_InsertGMCampDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (rblentrpnr.Items[0].Selected)
            {

                cmd.Parameters.Add("@EntrepreneurType", SqlDbType.VarChar).Value = "New";

                cmd.Parameters.Add("@EDP_camp", SqlDbType.VarChar).Value = "Y";
                if (chekEDPCamplist.Items[0].Selected)
                    cmd.Parameters.Add("@EDP_PMFME", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@EDP_PMFME", SqlDbType.VarChar).Value = DBNull.Value;
                if (chekEDPCamplist.Items[1].Selected)
                    cmd.Parameters.Add("@EDP_PMEGP", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@EDP_PMEGP", SqlDbType.VarChar).Value = DBNull.Value;
                if (chekEDPCamplist.Items[2].Selected)
                    cmd.Parameters.Add("@EDP_TSiPASS", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@EDP_TSiPASS", SqlDbType.VarChar).Value = DBNull.Value;
                if (chekEDPCamplist.Items[3].Selected)
                    cmd.Parameters.Add("@EDP_TIDEA", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@EDP_TIDEA", SqlDbType.VarChar).Value = DBNull.Value;
                if (chekEDPCamplist.Items[4].Selected)
                    cmd.Parameters.Add("@EDP_TPRIDE", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@EDP_TPRIDE", SqlDbType.VarChar).Value = DBNull.Value;
                if (chekEDPCamplist.Items[5].Selected)
                    cmd.Parameters.Add("@EDP_MUDRA", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@EDP_MUDRA", SqlDbType.VarChar).Value = DBNull.Value;
                if (chekEDPCamplist.Items[6].Selected)
                    cmd.Parameters.Add("@EDP_TASK", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@EDP_TASK", SqlDbType.VarChar).Value = DBNull.Value;
                if (chekEDPCamplist.Items[7].Selected)
                    cmd.Parameters.Add("@EDP_DEET", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@EDP_DEET", SqlDbType.VarChar).Value = DBNull.Value;
                if (chekEDPCamplist.Items[8].Selected)
                    cmd.Parameters.Add("@EDP_CGTMSE", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@EDP_CGTMSE", SqlDbType.VarChar).Value = DBNull.Value;
                if (chekEDPCamplist.Items[9].Selected)
                    cmd.Parameters.Add("@EDP_OSS", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@EDP_OSS", SqlDbType.VarChar).Value = DBNull.Value;
                if (chekEDPCamplist.Items[10].Selected)
                    cmd.Parameters.Add("@EDP_GOISchemes", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@EDP_GOISchemes", SqlDbType.VarChar).Value = DBNull.Value;

                cmd.Parameters.Add("@MSEFC_camp", SqlDbType.VarChar).Value = DBNull.Value;

                cmd.Parameters.Add("@MSME_camp", SqlDbType.VarChar).Value = DBNull.Value;
            }
            if (rblentrpnr.Items[1].Selected)
            {
                cmd.Parameters.Add("@EntrepreneurType", SqlDbType.VarChar).Value = "Existing";
                cmd.Parameters.Add("@EDP_camp", SqlDbType.VarChar).Value = DBNull.Value; ;

                cmd.Parameters.Add("@EDP_PMFME", SqlDbType.VarChar).Value = DBNull.Value;

                cmd.Parameters.Add("@EDP_PMEGP", SqlDbType.VarChar).Value = DBNull.Value;

                cmd.Parameters.Add("@EDP_TSiPASS", SqlDbType.VarChar).Value = DBNull.Value;

                cmd.Parameters.Add("@EDP_TIDEA", SqlDbType.VarChar).Value = DBNull.Value;

                cmd.Parameters.Add("@EDP_TPRIDE", SqlDbType.VarChar).Value = DBNull.Value;

                cmd.Parameters.Add("@EDP_MUDRA", SqlDbType.VarChar).Value = DBNull.Value;

                cmd.Parameters.Add("@EDP_TASK", SqlDbType.VarChar).Value = DBNull.Value;

                cmd.Parameters.Add("@EDP_DEET", SqlDbType.VarChar).Value = DBNull.Value;

                cmd.Parameters.Add("@EDP_CGTMSE", SqlDbType.VarChar).Value = DBNull.Value;

                cmd.Parameters.Add("@EDP_OSS", SqlDbType.VarChar).Value = DBNull.Value;

                cmd.Parameters.Add("@EDP_GOISchemes", SqlDbType.VarChar).Value = DBNull.Value;
                if (TYPEOFCAMPLIST.Items[0].Selected)
                    cmd.Parameters.Add("@MSEFC_camp", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@MSEFC_camp", SqlDbType.VarChar).Value = DBNull.Value;
                if (TYPEOFCAMPLIST.Items[1].Selected)
                    cmd.Parameters.Add("@MSME_camp", SqlDbType.VarChar).Value = "Y";
                else
                    cmd.Parameters.Add("@MSME_camp", SqlDbType.VarChar).Value = DBNull.Value;
            }

            cmd.Parameters.Add("@Venue", SqlDbType.VarChar).Value = VenueTXTEDP.Text;
            cmd.Parameters.Add("@LocCordinates", SqlDbType.VarChar).Value = VENUE_EDP_LOCATION.Text;
            cmd.Parameters.Add("@VenueType", SqlDbType.VarChar).Value = ChkEDP_Venue.SelectedItem.Text;
            if (EDP_OTHERS_CHK_BOX_Input.Text == "")
                cmd.Parameters.Add("@OtherVenue", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@OtherVenue", SqlDbType.VarChar).Value = EDP_OTHERS_CHK_BOX_Input.Text;
            cmd.Parameters.Add("@CampDate", SqlDbType.DateTime).Value = DateTime.ParseExact(DateOfCampConducted_EDP.Text, "dd/MM/yyyy", null);
            cmd.Parameters.Add("@Camptime", SqlDbType.VarChar).Value = ddltime_EDP.SelectedItem.Text;
            cmd.Parameters.Add("@MalesAttended", SqlDbType.VarChar).Value = NoOfMALES_ATTENDED_EDP.Text;
            cmd.Parameters.Add("@FemalesAttended", SqlDbType.VarChar).Value = NoOfFEMALES_ATTENDED_EDP.Text;
            if (chkPlatforms.Items[0].Selected)
                cmd.Parameters.Add("@MeeshowCovered", SqlDbType.VarChar).Value = "Y";
            else
                cmd.Parameters.Add("@MeeshowCovered", SqlDbType.VarChar).Value = DBNull.Value;
            if (chkPlatforms.Items[1].Selected)
                cmd.Parameters.Add("@JustDialCovered", SqlDbType.VarChar).Value = "Y";
            else
                cmd.Parameters.Add("@JustDialCovered", SqlDbType.VarChar).Value = DBNull.Value;
            if (chkPlatforms.Items[2].Selected)
                cmd.Parameters.Add("@TSGLinkerCovered", SqlDbType.VarChar).Value = "Y";
            else
                cmd.Parameters.Add("@TSGLinkerCovered", SqlDbType.VarChar).Value = DBNull.Value;
            if (chkPlatforms.Items[3].Selected)
                cmd.Parameters.Add("@WalmartVriddiCovered", SqlDbType.VarChar).Value = "Y";
            else
                cmd.Parameters.Add("@WalmartVriddiCovered", SqlDbType.VarChar).Value = DBNull.Value;
            if (chkPlatforms.Items[4].Selected)
                cmd.Parameters.Add("@InvoiceMartCovered", SqlDbType.VarChar).Value = "Y";
            else
                cmd.Parameters.Add("@InvoiceMartCovered", SqlDbType.VarChar).Value = DBNull.Value;
            if (chkPlatforms.Items[5].Selected)
                cmd.Parameters.Add("@NSECovered", SqlDbType.VarChar).Value = "Y";
            else
                cmd.Parameters.Add("@NSECovered", SqlDbType.VarChar).Value = DBNull.Value;
            if (chkPlatforms.Items[6].Selected)
                cmd.Parameters.Add("@SIDBICovered", SqlDbType.VarChar).Value = "Y";
            else
                cmd.Parameters.Add("@SIDBICovered", SqlDbType.VarChar).Value = DBNull.Value;

            if (chkPlatforms.Items[7].Selected)
                cmd.Parameters.Add("@MASCovered", SqlDbType.VarChar).Value = "Y";
            else
                cmd.Parameters.Add("@MASCovered", SqlDbType.VarChar).Value = DBNull.Value;
            if (chkPlatforms.Items[8].Selected)
                cmd.Parameters.Add("@SMASCovered", SqlDbType.VarChar).Value = "Y";
            else
                cmd.Parameters.Add("@SMASCovered", SqlDbType.VarChar).Value = DBNull.Value;
            if (chkPlatforms.Items[9].Selected)
                cmd.Parameters.Add("@PMSCovered", SqlDbType.VarChar).Value = "Y";
            else
                cmd.Parameters.Add("@PMSCovered", SqlDbType.VarChar).Value = DBNull.Value;

            cmd.Parameters.Add("@createdbyuserid", SqlDbType.VarChar).Value = Session["user_id"].ToString();
            cmd.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Convert.ToInt32(Session["uid"].ToString());
            cmd.Parameters.Add("@Districtid", SqlDbType.Int).Value = Convert.ToInt32(Session["DistrictID"].ToString());
            cmd.Parameters.Add("@Result", SqlDbType.Int);
            cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int i = Convert.ToInt32(cmd.Parameters["@Result"].Value);

            HdnCampID.Value = Convert.ToString(i);

            if (i != 0)
            {
                try
                {
                    if (chkofficers.SelectedIndex != -1)
                    {
                        using (SqlCommand command = new SqlCommand("sp_InsertCampOfficersDetails", con.GetConnection))
                        {
                            con.OpenConnection();
                            command.CommandType = CommandType.StoredProcedure;

                            for (int p = 0; p < chkofficers.Items.Count; p++)
                            {
                                if (chkofficers.Items[p].Selected)
                                {
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@GMCampID", HdnCampID.Value);
                                    command.Parameters.AddWithValue("@OfficerName", chkofficers.Items[p].Text);
                                    command.Parameters.AddWithValue("@OfficerUserId", chkofficers.Items[p].Value);
                                    command.Parameters.AddWithValue("@Createdby", Session["uid"]);
                                    command.Parameters.AddWithValue("@DistrictID", Session["DistrictID"]);
                                    command.ExecuteNonQuery();
                                }
                            }
                            con.CloseConnection();
                        }
                    }
                    if (gvEDPguests.Rows.Count > 0)
                    {
                        using (SqlCommand command = new SqlCommand("sp_InsertCampGuestDetails", con.GetConnection))
                        {
                            con.OpenConnection();
                            command.CommandType = CommandType.StoredProcedure;

                            for (int j = 0; j < gvEDPguests.Rows.Count; j++)
                            {
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@CampId", HdnCampID.Value);
                                if (chekEDPCamplist.SelectedValue.ToString() != null)
                                    command.Parameters.AddWithValue("@EDPCamp", "EDP");
                                else
                                    command.Parameters.Add("@EDPCamp", SqlDbType.VarChar).Value = DBNull.Value;
                                if (TYPEOFCAMPLIST.Items[0].Selected)
                                    command.Parameters.AddWithValue("@MSEFCCamp", "MSEFC");
                                else
                                    command.Parameters.Add("@MSEFCCamp", SqlDbType.VarChar).Value = DBNull.Value;
                                if (TYPEOFCAMPLIST.Items[1].Selected)
                                    command.Parameters.AddWithValue("@MSMECamp", "MSME");
                                else
                                    command.Parameters.Add("@MSMECamp", SqlDbType.VarChar).Value = DBNull.Value;

                                command.Parameters.AddWithValue("@GuestName", gvEDPguests.Rows[j].Cells[1].Text);
                                command.Parameters.AddWithValue("@GuestDesignation", gvEDPguests.Rows[j].Cells[2].Text);
                                command.Parameters.AddWithValue("@GusetDept", gvEDPguests.Rows[j].Cells[3].Text);
                                command.Parameters.AddWithValue("@createdbyuserid", Session["username"]);
                                command.Parameters.AddWithValue("@Createdby", Session["uid"]);
                                command.Parameters.AddWithValue("@DistrictID", Session["DistrictID"]);

                                command.ExecuteNonQuery();
                            }
                            con.CloseConnection();
                        }

                    }

                    if (Session["FupEDP_Dias"] != null)
                    {
                        FupEDP_Dias = (FileUpload)Session["FupEDP_Dias"];
                        string serverpath = HttpContext.Current.Server.MapPath("~\\GMCampAttachments\\" + HdnCampID.Value + "\\" + "DiasPhotograph" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        FupEDP_Dias.PostedFile.SaveAs(serverpath + "\\" + FupEDP_Dias.PostedFile.FileName);
                        InsertGMCampAttachments(HdnCampID.Value, FupEDP_Dias.FileName, serverpath + FupEDP_Dias.PostedFile.FileName, Session["username"].ToString(), Session["uid"].ToString(), Session["DistrictID"].ToString());
                    }
                    if (Session["FupEDP_Speaker"] != null)
                    {
                        FupEDP_Speaker = (FileUpload)Session["FupEDP_Speaker"];
                        string serverpath = HttpContext.Current.Server.MapPath("~\\GMCampAttachments\\" + HdnCampID.Value + "\\" + "SpeakerPhotograph" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        FupEDP_Speaker.PostedFile.SaveAs(serverpath + "\\" + FupEDP_Speaker.PostedFile.FileName);
                        InsertGMCampAttachments(HdnCampID.Value, FupEDP_Speaker.FileName, serverpath + FupEDP_Speaker.PostedFile.FileName, Session["username"].ToString(), Session["uid"].ToString(), Session["DistrictID"].ToString());
                    }
                    if (Session["FupEDP_Audience"] != null)
                    {
                        FupEDP_Audience = (FileUpload)Session["FupEDP_Audience"];
                        string serverpath = HttpContext.Current.Server.MapPath("~\\GMCampAttachments\\" + HdnCampID.Value + "\\" + "AudiencePhotograph" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        FupEDP_Audience.PostedFile.SaveAs(serverpath + "\\" + FupEDP_Audience.PostedFile.FileName);
                        InsertGMCampAttachments(HdnCampID.Value, FupEDP_Audience.FileName, serverpath + FupEDP_Audience.PostedFile.FileName, Session["username"].ToString(), Session["uid"].ToString(), Session["DistrictID"].ToString());
                    }
                    if (Session["FupEDP_Others"] != null)
                    {
                        FupEDP_Others = (FileUpload)Session["FupEDP_Others"];
                        string serverpath = HttpContext.Current.Server.MapPath("~\\GMCampAttachments\\" + HdnCampID.Value + "\\" + "AnyotherPhotograph" + "\\");
                        if (!Directory.Exists(serverpath))
                        {
                            Directory.CreateDirectory(serverpath);

                        }
                        FupEDP_Others.PostedFile.SaveAs(serverpath + "\\" + FupEDP_Others.PostedFile.FileName);
                        InsertGMCampAttachments(HdnCampID.Value, FupEDP_Others.FileName, serverpath + FupEDP_Others.PostedFile.FileName, Session["username"].ToString(), Session["uid"].ToString(), Session["DistrictID"].ToString());
                    }
                    SUBMIT_CLEAR_BTNS.Visible = false;
                    //ClearControls();
                    SubmitBtn.Enabled = false; SubmitBtn.BackColor = System.Drawing.Color.Orange;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "DetailsSaveAlert", "alert('Camp Details saved successfully...');", true);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }

            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void InsertGMCampAttachments(string CampID, string filename, string filepath, string username, string uid, string DistrictID)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString); ;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Sp_InsertGMCampAttachments", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CampId", CampID);
            //cmd.Parameters.AddWithValue("@Campname", Campname);
            cmd.Parameters.AddWithValue("@filename", filename);
            cmd.Parameters.AddWithValue("@filepath", filepath);
            cmd.Parameters.AddWithValue("@createdbyuserid", username);
            cmd.Parameters.AddWithValue("@Createdby", uid);
            cmd.Parameters.AddWithValue("@DistrictID", DistrictID);
            cmd.ExecuteNonQuery();
            //conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ClearControls()
    {
        VenueTXTEDP.Text = ""; VENUE_EDP_LOCATION.Text = ""; DateOfCampConducted_EDP.Text = "";
        ddltime_EDP.SelectedItem.Text = "Select"; NoOfMALES_ATTENDED_EDP.Text = ""; NoOfFEMALES_ATTENDED_EDP.Text = "";
        gvEDPguests.Visible = false; HplEDP_Dias.Visible = false; HplEDP_Dias.Visible = false; HplEDP_Dias.Visible = false; HplEDP_Dias.Visible = false;
        Session.Remove("FupEDP_Dias"); Session.Remove("FupEDP_Speaker"); Session.Remove("FupEDP_Audience"); Session.Remove("FupEDP_Others");
        HplEDP_Dias.Text = ""; HplEDP_Speaker.Text = ""; HplEDP_Audience.Text = ""; HplEDP_Others.Text = "";
    }

    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/CAMPS_CONDUCTED.aspx");
    }

    protected void rblentrpnr_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblentrpnr.SelectedIndex == 0)
        {
            divblinkingText.Visible = true;
            divEDP.Visible = true;
            TYPEOFCAMPLIST.Visible = false;
            TYPEOFCAMPLIST.ClearSelection();
            EDP_CONTENT.Visible = false;
            SUBMIT_CLEAR_BTNS.Visible = false;
            ClearControls();
        }
        else
        {
            divblinkingText.Visible = true;
            TYPEOFCAMPLIST.Visible = true;
            divEDP.Visible = false;
            chekEDPCamplist.ClearSelection();
            EDP_CONTENT.Visible = false;
            SUBMIT_CLEAR_BTNS.Visible = false;
            ClearControls();

        }


    }
    protected void chekEDPCamplist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (chekEDPCamplist.SelectedIndex == -1)
        {
            EDP_CONTENT.Visible = false;
            SUBMIT_CLEAR_BTNS.Visible = false;

        }
        else
        {
            EDP_CONTENT.Visible = true;
            SUBMIT_CLEAR_BTNS.Visible = true;
            lblindividuals.InnerText = "No.of Individuals Attended:";
            ChkEDP_Venue.Items.RemoveAt(1);
            ChkEDP_Venue.Items.Insert(1, "College");
            ChkEDP_Venue.Items.RemoveAt(2);
            ChkEDP_Venue.Items.Insert(2, "Women's College");
        }

    }


}

