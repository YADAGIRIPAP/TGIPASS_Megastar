using System;
using System.Activities.Validation;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_ForestTransitPermit : System.Web.UI.Page
{
    General gen = new General();
    General Gen = new General();

    int Sno = 0;
    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable myDtNewRecdr = new DataTable();
    static DataTable dtMyTable;
    static DataTable dtMyTableCertificate;
    List<Stairecases> lststire = new List<Stairecases>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                dtMyTableCertificate = createtablecrtificate();
                Session["CertificateTb2"] = dtMyTableCertificate;
            }
            //DataSet dscheck = new DataSet();
            //dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            //if (dscheck.Tables[0].Rows.Count > 0)
            //{
            //    Session["ApplidA"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            //}
            //else
            //{
            //    Session["ApplidA"] = "0";
            //}

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


        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();

            dsnew = Gen.getdataofidentityCFONewApproval(Session["ApplidA"].ToString(), "172");

            if (dsnew.Tables[0].Rows.Count > 0)
            {


                LoadForestTransitData();

            }
            else
            {


                if (Request.QueryString[1].ToString() == "N")
                {

                    Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                }

                else
                {

                    Response.Redirect("frmCFOWaterDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

                }
            }


        }
    }
    private DataTable CreateLogsDataTable()
    {
        if (ViewState["LogData"] == null)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SlNo", typeof(int));
            dt.Columns.Add("SpeciesName", typeof(string));
            dt.Columns.Add("LogNumber", typeof(string));
            dt.Columns.Add("Girth", typeof(string));
            dt.Columns.Add("Length", typeof(string));
            dt.Columns.Add("VolumeOrWeight", typeof(string));
            ViewState["LogData"] = dt;
        }
        return (DataTable)ViewState["LogData"];
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        // Retrieve DataTable from ViewState or create new if null
        DataTable dt = ViewState["LogsTable"] as DataTable;

        if (dt == null)
        {
            dt = new DataTable();
            dt.Columns.Add("SlNo", typeof(int));
            dt.Columns.Add("SpeciesName", typeof(string));
            dt.Columns.Add("LogNumber", typeof(string));
            dt.Columns.Add("Girth", typeof(string));
            dt.Columns.Add("Length", typeof(string));
            dt.Columns.Add("VolumeOrWeight", typeof(string));
        }

        // Auto-increment serial number
        int slNo = dt.Rows.Count + 1;

        // Add new row
        DataRow dr = dt.NewRow();
        dr["SlNo"] = slNo;
        dr["SpeciesName"] = ddlSpeciesName.SelectedItem.Text;
        dr["LogNumber"] = txtLogNumber.Text;
        dr["Girth"] = txtGirth.Text;
        dr["Length"] = txtLength.Text;
        dr["VolumeOrWeight"] = txtVolumeWeight.Text;

        dt.Rows.Add(dr);

        // Store updated DataTable in ViewState
        ViewState["LogsTable"] = dt;

        // Rebind the GridView
        gvLogs.DataSource = dt;
        gvLogs.DataBind();

        // Clear textboxes after adding
        ddlSpeciesName.SelectedIndex = 0;
        txtLogNumber.Text = "";
        txtGirth.Text = "";
        txtLength.Text = "";
        txtVolumeWeight.Text = "";
    }
    private void BindLogsGrid()
    {
        gvLogs.DataSource = ViewState["LogData"];
        gvLogs.DataBind();
    }

    

    protected void gvLogs_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Retrieve DataTable from ViewState
        DataTable dt = ViewState["LogsTable"] as DataTable;

        if (dt != null)
        {
            // Get the row index to delete
            int rowIndex = e.RowIndex;

            // Remove the row at the specified index
            dt.Rows.RemoveAt(rowIndex);

            // **Reassign serial numbers after deletion**
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["SlNo"] = i + 1;  // Reassign serial numbers sequentially
            }

            // Store updated DataTable in ViewState
            ViewState["LogsTable"] = dt;

            // Rebind the GridView
            gvLogs.DataSource = dt;
            gvLogs.DataBind();
        }
    }
    private DataTable dtBarriers // Stores the grid data in ViewState
    {
        get
        {
            return ViewState["dtBarriers"] as DataTable ?? CreateBariersTable();
        }
        set
        {
            ViewState["dtBarriers"] = value;
        }
    }

    private DataTable CreateBariersTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("SlNo", typeof(int));
        dt.Columns.Add("State", typeof(string));
        dt.Columns.Add("Barriers", typeof(string));
        return dt;
    }

    private void BindBariersGrid()
    {
        gvBarriers.DataSource = dtBarriers;
        gvBarriers.DataBind();
    }

    protected void btnAddBarrier_Click(object sender, EventArgs e)
    {
        DataTable dt = dtBarriers;

        // Add new row
        DataRow dr = dt.NewRow();
        dr["SlNo"] = dt.Rows.Count + 1; // Auto-increment SlNo
        dr["State"] = txtState.Text.Trim();
        dr["Barriers"] = txtBarriers.Text.Trim();
        dt.Rows.Add(dr);

        dtBarriers = dt; // Save back to ViewState
        BindBariersGrid();

        // Clear input fields after adding
        txtState.Text = "";
        txtBarriers.Text = "";
    }

    public void gvBarriers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = dtBarriers;

        if (dt.Rows.Count > e.RowIndex)
        {
            dt.Rows.RemoveAt(e.RowIndex); // Remove the selected row
        }

        // Reassign serial numbers after deletion
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["SlNo"] = i + 1;
        }

        dtBarriers = dt;
        BindBariersGrid();
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
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int transitApplID = 0;
        con.OpenConnection();

        try
        {
            using (SqlCommand cmd = new SqlCommand("SP_InsertForestTransitApplDetails", con.GetConnection))  // Using your connection method
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Pass ASPX TextBox values to stored procedure parameters
                cmd.Parameters.AddWithValue("@Created_by", Session["uid"].ToString());
                cmd.Parameters.AddWithValue("@intCFOEnterpid",Session["uid"].ToString());
                cmd.Parameters.AddWithValue("@intQuessionaireCFOid", Session["ApplidA"].ToString());
                cmd.Parameters.AddWithValue("@PermitID", txtpermitno.Text.Trim());
                cmd.Parameters.AddWithValue("@ownerName", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@ownerIdentityNo", txtIdentity.Text.Trim());
                cmd.Parameters.AddWithValue("@ownerEmail", txtemail.Text.Trim());
                cmd.Parameters.AddWithValue("@OwnerAddress", txtowneraddress.Text.Trim());
                cmd.Parameters.AddWithValue("@ownerMobile", txtmobile.Text.Trim());
                cmd.Parameters.AddWithValue("@ownerProduce", txtproduce.Text.Trim());
                cmd.Parameters.AddWithValue("@VehicleType", txtVehicleType.Text.Trim());
                cmd.Parameters.AddWithValue("@DriverLicense", txtDriverLicense.Text.Trim());
                cmd.Parameters.AddWithValue("@DriverName", txtDriverName.Text.Trim());
                cmd.Parameters.AddWithValue("@CompartmentNoObtained", txtCompartmentNo.Text.Trim());
                cmd.Parameters.AddWithValue("@RangeWhereObtained", txtRangeWhereObtained.Text.Trim());
                cmd.Parameters.AddWithValue("@CircleWhereObtained", txtCircleWhereObtained.Text.Trim());
                cmd.Parameters.AddWithValue("@AddressWhereObtained", txtAddressWhereObtained.Text.Trim());
                cmd.Parameters.AddWithValue("@DivisionWhereObtained", txtDivisionWhereObtained.Text.Trim());
                cmd.Parameters.AddWithValue("@StateDestination", txtstateDestination.Text.Trim());
                cmd.Parameters.AddWithValue("@DestRange", txtdestRange.Text.Trim());
                cmd.Parameters.AddWithValue("@DestAddress", txtdestAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@DestCircle", txtdestCircle.Text.Trim());
                cmd.Parameters.AddWithValue("@DestDivision", txtdestDivision.Text.Trim());

                // Handling nullable DateTime fields
                cmd.Parameters.AddWithValue("@DateOfIssue",
                    string.IsNullOrWhiteSpace(txtDateOfIssue.Text.Trim()) ? (object)DBNull.Value : Convert.ToDateTime(txtDateOfIssue.Text.Trim()));

                cmd.Parameters.AddWithValue("@ImprintOfTransitMark", txtImprintOfTransitMark.Text.Trim());

                cmd.Parameters.AddWithValue("@DateOfExpiryOfPermit",
                    string.IsNullOrWhiteSpace(txtDateOfExpiryOfPermit.Text.Trim()) ? (object)DBNull.Value : Convert.ToDateTime(txtDateOfExpiryOfPermit.Text.Trim()));

                

                cmd.Parameters.AddWithValue("@DesignationofOfficer", txtDesignationOfOfficial.Text.Trim());
                cmd.Parameters.AddWithValue("@OfficerTelephoneMobile", txtOfficialTelephoneMobile.Text.Trim());
                cmd.Parameters.AddWithValue("@OfficerEmail", txtOfficialEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@OfficeAddress", txtOfficeAddress.Text.Trim());

                // OUTPUT parameter for the generated TransitApplID
                SqlParameter outputIdParam = new SqlParameter("@TransitApplID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);

                // Execute Command and Retrieve ID
                cmd.ExecuteNonQuery();
                transitApplID = Convert.ToInt32(outputIdParam.Value);
            }
            if (transitApplID.ToString() != null)
            {
                foreach (GridViewRow row in gvLogs.Rows)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_InsertForestTransitLogs", con.GetConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TransitApplID", transitApplID);
                        cmd.Parameters.AddWithValue("@Created_by", Session["uid"].ToString());
                        cmd.Parameters.AddWithValue("@SpeciesName", row.Cells[1].Text.Trim());
                        cmd.Parameters.AddWithValue("@intCFOEnterpid", Session["uid"].ToString());
                        cmd.Parameters.AddWithValue("@intQuessionaireCFOid", Session["ApplidA"].ToString());
                        cmd.Parameters.AddWithValue("@LogNumber", row.Cells[2].Text.Trim());
                        cmd.Parameters.AddWithValue("@Girth", Convert.ToDecimal(row.Cells[3].Text.Trim()));
                        cmd.Parameters.AddWithValue("@Length", Convert.ToDecimal(row.Cells[4].Text.Trim()));
                        cmd.Parameters.AddWithValue("@VolumeOrWeight", Convert.ToDecimal(row.Cells[5].Text.Trim()));

                        cmd.ExecuteNonQuery();
                    }
                }
                foreach (GridViewRow row in gvBarriers.Rows)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_InsertForestTransitBarriers", con.GetConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Created_by", Session["uid"].ToString());
                        cmd.Parameters.AddWithValue("@intCFOEnterpid", Session["uid"].ToString());
                        cmd.Parameters.AddWithValue("@intQuessionaireCFOid", Session["ApplidA"].ToString());
                        cmd.Parameters.AddWithValue("@TransitApplID", transitApplID);
                        cmd.Parameters.AddWithValue("@State", row.Cells[1].Text.Trim());
                        cmd.Parameters.AddWithValue("@Barriers", row.Cells[2].Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

            }


            // Show success message with generated Transit Application ID
           // lblMessage.ForeColor = System.Drawing.Color.Green;
            lblmsg.Text = "Application saved successfully! Transit Application ID: " + transitApplID;
        }
        catch (SqlException sqlEx)
        {
            lblmsg0.ForeColor = System.Drawing.Color.Red;
            lblmsg0.Text = "Database error: " + sqlEx.Message;
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblmsg0.Text = "Error: " + ex.Message;
        }

        
    }

    private void LoadForestTransitData()
    {
        string createdBy = Session["uid"].ToString(); // Get logged-in user
        con.OpenConnection();

        
        
            using (SqlCommand cmd = new SqlCommand("SP_GetForestTransitDataByCreatedBy", con.GetConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Created_by", createdBy);

                
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    // **Table 0: Application Details**
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables[0].Rows[0]; // Only one row expected

                        txtpermitno.Text = row["PermitID"].ToString();
                        txtName.Text = row["ownerName"].ToString();
                        txtIdentity.Text = row["ownerIdentityNo"].ToString();
                        txtemail.Text = row["ownerEmail"].ToString();
                        txtowneraddress.Text = row["OwnerAddress"].ToString();
                        txtmobile.Text = row["ownerMobile"].ToString();
                        txtproduce.Text = row["ownerProduce"].ToString();
                        txtVehicleType.Text = row["VehicleType"].ToString();
                        txtDriverLicense.Text = row["DriverLicense"].ToString();
                        txtDriverName.Text = row["DriverName"].ToString();
                        txtCompartmentNo.Text = row["CompartmentNoObtained"].ToString();
                        txtRangeWhereObtained.Text = row["RangeWhereObtained"].ToString();
                        txtCircleWhereObtained.Text = row["CircleWhereObtained"].ToString();
                        txtAddressWhereObtained.Text = row["AddressWhereObtained"].ToString();
                        txtDivisionWhereObtained.Text = row["DivisionWhereObtained"].ToString();
                        txtstateDestination.Text = row["StateDestination"].ToString();
                        txtdestRange.Text = row["DestRange"].ToString();
                        txtdestAddress.Text = row["DestAddress"].ToString();
                        txtdestCircle.Text = row["DestCircle"].ToString();
                        txtdestDivision.Text = row["DestDivision"].ToString();
                        txtImprintOfTransitMark.Text = row["ImprintOfTransitMark"].ToString();
                        txtDesignationOfOfficial.Text = row["DesignationofOfficer"].ToString();
                        txtOfficialTelephoneMobile.Text = row["OfficerTelephoneMobile"].ToString();
                        txtOfficialEmail.Text = row["OfficerEmail"].ToString();
                        txtOfficeAddress.Text = row["OfficeAddress"].ToString();

                        // Handling nullable DateTime fields
                        if (row["DateOfIssue"] != DBNull.Value)
                            txtDateOfIssue.Text = Convert.ToDateTime(row["DateOfIssue"]).ToString("yyyy-MM-dd");

                        if (row["DateOfExpiryOfPermit"] != DBNull.Value)
                            txtDateOfExpiryOfPermit.Text = Convert.ToDateTime(row["DateOfExpiryOfPermit"]).ToString("yyyy-MM-dd");
                    }

                    // **Table 1: Logs Data**
                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        gvLogs.DataSource = ds.Tables[1];
                        gvLogs.DataBind();
                    }
                    else
                    {
                        gvLogs.DataSource = null;
                        gvLogs.DataBind();
                    }

                    // **Table 2: Barriers Data**
                    if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                    {
                        gvBarriers.DataSource = ds.Tables[2];
                        gvBarriers.DataBind();
                    }
                    else
                    {
                        gvBarriers.DataSource = null;
                        gvBarriers.DataBind();
                    }
                }
            
        }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCFOWaterDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        BtnSave1_Click(sender, e);
        Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

    }
}


    