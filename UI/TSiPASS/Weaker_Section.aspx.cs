using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class UI_TSiPASS_Weaker_Section : System.Web.UI.Page
{
    DropDownList ddlOfficerName;
    DB.DB con = new DB.DB();
    static DataTable dtMyTable;
    static DataTable dtMyTableCertificate;
    DataTable myDtNewRecdr = new DataTable();
    General gen = new General();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
        if (Session["uid"] == null || Session["uid"].ToString() == "")
        {
            Response.Redirect("~/TSHome.aspx");

        }
        else
        {
            if (Session["Role_Code"].ToString() == "GM")
            {
                if (!IsPostBack)
                {
                    SetInitialRow();
                    SetInitialRow_SC();
                    BindDistricts();
                    if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
                    {
                        ddldistrict.SelectedValue = Session["DistrictID"].ToString().Trim();
                        ddldistrict.Enabled = false;
                    }
                    InitializeTempDataTable();
                    BindTempGridView();
                    BindPlotsData();
                }
            }
            else
                Response.Redirect("~/TSHome.aspx");
        }
    }


    private DataTable tempDataTable;
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));

        DataRow dr = dt.NewRow();
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;

        dt.Rows.Add(dr);

        ViewState["CurrentTable"] = dt;
        grdDetails.DataSource = dt;
        grdDetails.DataBind();
    }
    private void SetInitialRow_SC()
    {
        DataTable dt_SC = new DataTable();
        dt_SC.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt_SC.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt_SC.Columns.Add(new DataColumn("Column3", typeof(string)));
        dt_SC.Columns.Add(new DataColumn("Column4", typeof(string)));

        DataRow dr = dt_SC.NewRow();
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;

        dt_SC.Rows.Add(dr);

        ViewState["CurrentTable_SC"] = dt_SC;
        SC_GridDetails.DataSource = dt_SC;
        SC_GridDetails.DataBind();
    }
    private void InitializeTempDataTable()
    {
        tempDataTable = new DataTable();
        tempDataTable.Columns.Add("IE_NAME");
        tempDataTable.Columns.Add("TSIIC_Category");
        tempDataTable.Columns.Add("Officer_Name");

    }
    private void BindTempGridView()
    {
        Weaker_Section_TEMPGrid.DataSource = tempDataTable;
        Weaker_Section_TEMPGrid.DataBind();
    }
    protected void BindPlotsData()
    {
        DataSet ds = new DataSet();
        con.OpenConnection();
        SqlDataAdapter da = new SqlDataAdapter("SP_GET_INDUSTRIALESTATEDETAILS", con.GetConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = Convert.ToString(Session["DistrictID"]);
        da.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
        da.Fill(ds);
        con.CloseConnection();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Weaker_Section_TEMPGrid.DataSource = ds;
            Weaker_Section_TEMPGrid.DataBind();
            lblIEplots.Visible = true;
        }
    }
    public void BindDistricts()
    {
        try
        {
            Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
            DataSet dsd = new DataSet();
            ddldistrict.Items.Clear();
            dsd = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "MSME");
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = dsd.Tables[0];
                ddldistrict.DataValueField = "District_Id";
                ddldistrict.DataTextField = "District_Name";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, "--Select--");
            }
            else
            {
                ddldistrict.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, "1000");
        }
    }
    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet GetDepartmentINcentiveNew(string Districtid, string usercode)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GetDepartmentIncentive_NEW_11REPORTS]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@Dept_ID", SqlDbType.VarChar).Value = Districtid;
            da.SelectCommand.Parameters.Add("@usercode", SqlDbType.VarChar).Value = usercode;
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
    protected DataTable BindOfficers()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Dept_Name");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdDetails.Rows[rowIndex].Cells[1].FindControl("txtinstituteName");
                    TextBox box2 = (TextBox)grdDetails.Rows[rowIndex].Cells[1].FindControl("txtdegree");
                    TextBox box3 = (TextBox)grdDetails.Rows[rowIndex].Cells[1].FindControl("txtgrade");
                    TextBox box4 = (TextBox)grdDetails.Rows[rowIndex].Cells[1].FindControl("txtyear");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();

                    rowIndex++;
                }
            }
        }
    }
    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        return result;
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        Button btndelete = (Button)sender;
        GridViewRow row = (GridViewRow)btndelete.NamingContainer;
        Label INDUSTRIALESTATEID = (Label)row.FindControl("LBLINDESTID_GRID");
        TextBox remarks = (TextBox)row.FindControl("txtremarks");
        if (remarks.Text == "" || remarks.Text == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter reason to delete')", true);
            remarks.Focus();
        }
        else
        {
            int returnValue = Delete_Records(INDUSTRIALESTATEID.Text, Session["uid"].ToString(), getclientIP(), remarks.Text);
            if (returnValue > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Record Deleted Successfully');", true);
                Response.Redirect("frmSupportToWeakerSection.aspx");
            }
        }
    }
    public int Delete_Records(string INDESTID_GRID, string Created_by, string IPAddress, string remarks)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[SP_DELETE_INDUSTRIALESTATEDETAILS]";

        if (INDESTID_GRID.Trim() == "" || INDESTID_GRID.Trim() == null)
            com.Parameters.Add("@INDESTID_GRID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@INDESTID_GRID", SqlDbType.VarChar).Value = INDESTID_GRID.Trim();

        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = Created_by.Trim();

        if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
            com.Parameters.Add("@IPADDRESS", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPADDRESS", SqlDbType.VarChar).Value = IPAddress.Trim();

        if (remarks.Trim() == "" || remarks.Trim() == null)
            com.Parameters.Add("@DELETEREMARKS", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DELETEREMARKS", SqlDbType.VarChar).Value = remarks.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            return com.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {

            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 6 || i == 7 || i == 8 || i == 9 || i == 10 || i == 11 ||
                    i == 12 || i == 13 || i == 14 || i == 15 || i == 16
                   || i == 17 || i == 18 || i == 19 || i == 20 || i == 21 || i == 22 || i == 23 || i == 24 || i == 25 || i == 26 || i == 27
                   || i == 28 || i == 29 || i == 30 || i == 31 || i == 32 || i == 33 || i == 34)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }


            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Total no of Plots";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Total no of Plots Mandated";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 6;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Total no of Plots Allotted";
            tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage2.ColumnSpan = 6;
            gvHeaderRowCopy.Cells.AddAt(8, tcMergePackage2);

            TableCell tcMergePackage4 = new TableCell();
            tcMergePackage4.Text = "Total no of Plots Vacant";
            tcMergePackage4.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage4.ColumnSpan = 6;
            gvHeaderRowCopy.Cells.AddAt(9, tcMergePackage4);

            TableCell tcMergePackage5 = new TableCell();
            tcMergePackage5.Text = "Total no of Plots Allotable";
            tcMergePackage5.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage5.ColumnSpan = 6;
            gvHeaderRowCopy.Cells.AddAt(10, tcMergePackage5);

        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            DataSet dsofficers = new DataSet();
            dsofficers = GetDepartmentINcentiveNew(Session["DistrictID"].ToString(), null);
            if (dsofficers != null && dsofficers.Tables.Count > 0 && dsofficers.Tables[0].Rows.Count > 0)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddlOfficerName = (DropDownList)e.Row.Cells[4].Controls[1];

                    ddlOfficerName.DataSource = dsofficers.Tables[0];
                    ddlOfficerName.DataTextField = "Dept_Name";
                    ddlOfficerName.DataValueField = "Dept_Id";
                    ddlOfficerName.DataBind();

                    AddSelect(ddlOfficerName);
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtSCmandt = (TextBox)e.Row.Cells[10].Controls[0];
                TextBox txtSTmandt = (TextBox)e.Row.Cells[11].Controls[0];
                TextBox txtBCmandt = (TextBox)e.Row.Cells[12].Controls[0];
                TextBox txtMinmandt = (TextBox)e.Row.Cells[13].Controls[0];
                TextBox txtGnrlmandt = (TextBox)e.Row.Cells[14].Controls[0];
                TextBox txtWomnmandt = (TextBox)e.Row.Cells[15].Controls[0];

                TextBox txtSCalotd = (TextBox)e.Row.Cells[16].Controls[0];
                TextBox txtSTalotd = (TextBox)e.Row.Cells[17].Controls[0];
                TextBox txtBCalotd = (TextBox)e.Row.Cells[18].Controls[0];
                TextBox txtMinalotd = (TextBox)e.Row.Cells[19].Controls[0];
                TextBox txtGnrlalotd = (TextBox)e.Row.Cells[20].Controls[0];
                TextBox txtWomnalotd = (TextBox)e.Row.Cells[21].Controls[0];

                TextBox txtSCvacant = (TextBox)e.Row.Cells[10].Controls[0];
                txtSCvacant.Text = Convert.ToString(Convert.ToInt64(txtSCmandt.Text) - Convert.ToInt64(txtSCalotd.Text));
                TextBox txtSTvacant = (TextBox)e.Row.Cells[11].Controls[0];
                TextBox txtBCvacant = (TextBox)e.Row.Cells[12].Controls[0];
                TextBox txtMinvacant = (TextBox)e.Row.Cells[13].Controls[0];
                TextBox txtGnrlvacant = (TextBox)e.Row.Cells[14].Controls[0];
                TextBox txtWomnvacant = (TextBox)e.Row.Cells[15].Controls[0];


            }
        }
        catch (Exception ex)
        { }
    }
    protected void ddlOfficerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DropDownList ddlOfficerName = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlOfficerName.NamingContainer;
            TextBox Designation = (TextBox)row.FindControl("Designation");


            if (ddlOfficerName.SelectedValue != null && ddlOfficerName.SelectedValue != "0")
            {
                DataSet dsApplicationType = new DataSet();
                dsApplicationType = GetDepartmentINcentiveNew(Session["DistrictID"].ToString(), ddlOfficerName.SelectedValue);
                if (dsApplicationType != null && dsApplicationType.Tables.Count > 0 && dsApplicationType.Tables[0].Rows.Count > 0)
                {
                    if (dsApplicationType.Tables[0].Rows[0]["Designation"].ToString() != "" &&
                        dsApplicationType.Tables[0].Rows[0]["Designation"].ToString() != null)
                    {
                        Designation.Text = dsApplicationType.Tables[0].Rows[0]["Designation"].ToString();
                    }
                }
                else
                {


                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void Plots_Alloted_SC_TextChanged(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;

        TextBox txtMandated_SC = (TextBox)row.FindControl("Plots_Mandated_SC");
        TextBox txtAlloted_SC = (TextBox)row.FindControl("Plots_Alloted_SC");
        if (txtMandated_SC.Text != "" && txtAlloted_SC.Text != "")
        {
            if (Convert.ToInt64(txtMandated_SC.Text) < Convert.ToInt64(txtAlloted_SC.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter SC Allotted Plots below Mandated Plots')", true);
                return;
            }
            TextBox txtVacant_SC = (TextBox)row.FindControl("Plots_Vacant_SC");
            TextBox txtAllotable_SC = (TextBox)row.FindControl("Plots_Allotable_SC");
            //if (txtMandated_SC.Text != "" && txtAlloted_SC.Text != "")
            //{
            txtVacant_SC.Text = Convert.ToString(Convert.ToInt64(txtMandated_SC.Text) - Convert.ToInt64(txtAlloted_SC.Text));
            txtVacant_SC.Enabled = false;
            txtAllotable_SC.Text = txtVacant_SC.Text;
            Plots_Allotable_SC_TextChanged(sender, e);
            //}
        }
    }
    protected void Plots_Alloted_ST_TextChanged(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;

        TextBox txtMandated_ST = (TextBox)row.FindControl("Plots_Mandated_ST");
        TextBox txtAlloted_ST = (TextBox)row.FindControl("Plots_Alloted_ST");
        if (txtMandated_ST.Text != "" && txtAlloted_ST.Text != "")
        {
            if (Convert.ToInt64(txtMandated_ST.Text) < Convert.ToInt64(txtAlloted_ST.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter ST Allotted Plots below Mandated Plots')", true);
                return;
            }
            TextBox txtVacant_ST = (TextBox)row.FindControl("Plots_Vacant_ST");
            TextBox txtAllotable_ST = (TextBox)row.FindControl("Plots_Allotable_ST");

            txtVacant_ST.Text = Convert.ToString(Convert.ToInt64(txtMandated_ST.Text) - Convert.ToInt64(txtAlloted_ST.Text));
            txtVacant_ST.Enabled = false;
            txtAllotable_ST.Text = txtVacant_ST.Text;
            Plots_Allotable_ST_TextChanged(sender, e);
        }

    }
    protected void Plots_Alloted_BC_TextChanged(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;

        TextBox txtMandated_BC = (TextBox)row.FindControl("Plots_Mandated_BC");
        TextBox txtAlloted_BC = (TextBox)row.FindControl("Plots_Alloted_BC");
        if (txtMandated_BC.Text != "" && txtAlloted_BC.Text != "")
        {
            if (Convert.ToInt64(txtMandated_BC.Text) < Convert.ToInt64(txtAlloted_BC.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter BC Allotted Plots below Mandated Plots')", true);
                return;
            }
            TextBox txtVacant_BC = (TextBox)row.FindControl("Plots_Vacant_BC");
            TextBox txtAllotable_BC = (TextBox)row.FindControl("Plots_Allotable_BC");

            txtVacant_BC.Text = Convert.ToString(Convert.ToInt64(txtMandated_BC.Text) - Convert.ToInt64(txtAlloted_BC.Text));
            txtVacant_BC.Enabled = false;
            txtAllotable_BC.Text = txtVacant_BC.Text;
            Plots_Allotable_BC_TextChanged(sender, e);
        }

    }
    protected void Plots_Alloted_Minority_TextChanged(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;

        TextBox txtMandated_Minority = (TextBox)row.FindControl("Plots_Mandated_Minority");
        TextBox txtAlloted_Minority = (TextBox)row.FindControl("Plots_Alloted_Minority");
        if (txtMandated_Minority.Text != "" && txtAlloted_Minority.Text != "")
        {
            if (Convert.ToInt64(txtMandated_Minority.Text) < Convert.ToInt64(txtAlloted_Minority.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Minority Allotted Plots below Mandated Plots')", true);
                return;
            }
            TextBox txtVacant_Minority = (TextBox)row.FindControl("Plots_Vacant_Minority");
            TextBox txtAllotable_Minority = (TextBox)row.FindControl("Plots_Allotable_Minority");

            txtVacant_Minority.Text = Convert.ToString(Convert.ToInt64(txtMandated_Minority.Text) - Convert.ToInt64(txtAlloted_Minority.Text));
            txtVacant_Minority.Enabled = false;
            txtAllotable_Minority.Text = txtVacant_Minority.Text;
            Plots_Allotable_Minority_TextChanged(sender, e);
        }

    }
    protected void Plots_Alloted_Women_TextChanged(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;

        TextBox txtMandated_Women = (TextBox)row.FindControl("Plots_Mandated_Women");
        TextBox txtAlloted_Women = (TextBox)row.FindControl("Plots_Alloted_Women");
        if (txtMandated_Women.Text != "" && txtAlloted_Women.Text != "")
        {
            if (Convert.ToInt64(txtMandated_Women.Text) < Convert.ToInt64(txtAlloted_Women.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Women Allotted Plots below Mandated Plots')", true);
                return;
            }
            TextBox txtVacant_Women = (TextBox)row.FindControl("Plots_Vacant_Women");
            TextBox txtAllotable_Women = (TextBox)row.FindControl("Plots_Allotable_Women");

            txtVacant_Women.Text = Convert.ToString(Convert.ToInt64(txtMandated_Women.Text) - Convert.ToInt64(txtAlloted_Women.Text));
            txtVacant_Women.Enabled = false;
            txtAllotable_Women.Text = txtVacant_Women.Text;
            Plots_Allotable_Women_TextChanged(sender, e);
        }
    }
    protected void Plots_Alloted_General_TextChanged(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;

        TextBox txtMandated_General = (TextBox)row.FindControl("Plots_Mandated_General");
        TextBox txtAlloted_General = (TextBox)row.FindControl("Plots_Alloted_General");
        if (txtMandated_General.Text != "" && txtAlloted_General.Text != "")
        {
            if (Convert.ToInt64(txtMandated_General.Text) < Convert.ToInt64(txtAlloted_General.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter General Allotted Plots below Mandated Plots')", true);
                return;
            }
            TextBox txtVacant_General = (TextBox)row.FindControl("Plots_Vacant_General");
            TextBox txtAllotable_General = (TextBox)row.FindControl("Plots_Allotable_General");

            txtVacant_General.Text = Convert.ToString(Convert.ToInt64(txtMandated_General.Text) - Convert.ToInt64(txtAlloted_General.Text));
            txtVacant_General.Enabled = false;
            txtAllotable_General.Text = txtVacant_General.Text;
            Plots_Allotable_General_TextChanged(sender, e);
        }

    }
    protected void Plots_Allotable_SC_TextChanged(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;
        TextBox txt_Allotable_SC = (TextBox)row.FindControl("Plots_Allotable_SC");
        int rowIndex = row.RowIndex;

        int rowCount;
       
        if (int.TryParse(txt_Allotable_SC.Text, out rowCount) && rowCount > 0)
        {
            DataTable dtCurrentTable_SC = new DataTable();
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column1", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column2", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column3", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column4", typeof(string)));

            for (int i = 0; i < rowCount; i++)
            {
                DataRow dr = dtCurrentTable_SC.NewRow();
                dtCurrentTable_SC.Rows.Add(dr);
            }

            ViewState["CurrentTable_SC"] = dtCurrentTable_SC;

            SC_GridDetails.Visible = true;
            SC_GridDetails.DataSource = dtCurrentTable_SC;
            SC_GridDetails.DataBind();
            tdSC.Visible = true;
        }
        else
        {
            tdSC.Visible = false;
            SC_GridDetails.Visible = false;
            SC_GridDetails.DataSource = null;
            SC_GridDetails.DataBind();
        }
    }
    protected void Plots_Allotable_ST_TextChanged(object sender, EventArgs e)
    {

        //TextBox textBox = (TextBox)sender;
        //GridViewRow row = (GridViewRow)textBox.NamingContainer;
        GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;
        TextBox txt_Allotable_ST = (TextBox)row.FindControl("Plots_Allotable_ST");

        int rowIndex = row.RowIndex;

        int rowCount;
        if (int.TryParse(txt_Allotable_ST.Text, out rowCount) && rowCount > 0)
        {
            DataTable dtCurrentTable_SC = new DataTable();
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column1", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column2", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column3", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column4", typeof(string)));

            for (int i = 0; i < rowCount; i++)
            {
                DataRow dr = dtCurrentTable_SC.NewRow();
                dtCurrentTable_SC.Rows.Add(dr);
            }

            ViewState["CurrentTable_SC"] = dtCurrentTable_SC;

            ST_GridDetails.Visible = true;
            ST_GridDetails.DataSource = dtCurrentTable_SC;
            ST_GridDetails.DataBind();
            tdST.Visible = true;
        }
        else
        {
            tdST.Visible = false;
            ST_GridDetails.Visible = false;
            ST_GridDetails.DataSource = null;
            ST_GridDetails.DataBind();
        }
    }
    protected void Plots_Allotable_BC_TextChanged(object sender, EventArgs e)
    {
        //TextBox textBox = (TextBox)sender;
        //GridViewRow row = (GridViewRow)textBox.NamingContainer;

        GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;
        TextBox txt_Allotable_BC = (TextBox)row.FindControl("Plots_Allotable_BC");

        int rowIndex = row.RowIndex;

        int rowCount;
        if (int.TryParse(txt_Allotable_BC.Text, out rowCount) && rowCount > 0)
        {
            DataTable dtCurrentTable_SC = new DataTable();
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column1", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column2", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column3", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column4", typeof(string)));

            for (int i = 0; i < rowCount; i++)
            {
                DataRow dr = dtCurrentTable_SC.NewRow();
                dtCurrentTable_SC.Rows.Add(dr);
            }

            ViewState["CurrentTable_SC"] = dtCurrentTable_SC;

            BC_GridDetails.Visible = true;
            BC_GridDetails.DataSource = dtCurrentTable_SC;
            BC_GridDetails.DataBind();
            tdBC.Visible = true;
        }
        else
        {
            tdBC.Visible = false;
            BC_GridDetails.Visible = false;
            BC_GridDetails.DataSource = null;
            BC_GridDetails.DataBind();
        }
    }
    protected void Plots_Allotable_Minority_TextChanged(object sender, EventArgs e)
    {
        //TextBox textBox = (TextBox)sender;
        //GridViewRow row = (GridViewRow)textBox.NamingContainer;
        GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;
        TextBox txt_Allotable_Minority = (TextBox)row.FindControl("Plots_Allotable_Minority");

        int rowIndex = row.RowIndex;

        int rowCount;
        if (int.TryParse(txt_Allotable_Minority.Text, out rowCount) && rowCount > 0)
        {
            DataTable dtCurrentTable_SC = new DataTable();
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column1", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column2", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column3", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column4", typeof(string)));

            for (int i = 0; i < rowCount; i++)
            {
                DataRow dr = dtCurrentTable_SC.NewRow();
                dtCurrentTable_SC.Rows.Add(dr);
            }

            ViewState["CurrentTable_SC"] = dtCurrentTable_SC;

            Minority_GridDetails.Visible = true;
            Minority_GridDetails.DataSource = dtCurrentTable_SC;
            Minority_GridDetails.DataBind();
            tdMinorty.Visible = true;
        }
        else
        {
            tdMinorty.Visible = false;
            Minority_GridDetails.Visible = false;
            Minority_GridDetails.DataSource = null;
            Minority_GridDetails.DataBind();
        }
    }
    protected void Plots_Allotable_Women_TextChanged(object sender, EventArgs e)
    {
        //TextBox textBox = (TextBox)sender;
        //GridViewRow row = (GridViewRow)textBox.NamingContainer;
        GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;
        TextBox txt_Allotable_Women = (TextBox)row.FindControl("Plots_Allotable_Women");

        int rowIndex = row.RowIndex;

        int rowCount;
        if (int.TryParse(txt_Allotable_Women.Text, out rowCount) && rowCount > 0)
        {
            DataTable dtCurrentTable_SC = new DataTable();
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column1", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column2", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column3", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column4", typeof(string)));

            for (int i = 0; i < rowCount; i++)
            {
                DataRow dr = dtCurrentTable_SC.NewRow();
                dtCurrentTable_SC.Rows.Add(dr);
            }

            ViewState["CurrentTable_SC"] = dtCurrentTable_SC;

            Women_GridDetails.Visible = true;
            Women_GridDetails.DataSource = dtCurrentTable_SC;
            Women_GridDetails.DataBind();
            tdWomen.Visible = true;
        }
        else
        {
            tdWomen.Visible = false;
            Women_GridDetails.Visible = false;
            Women_GridDetails.DataSource = null;
            Women_GridDetails.DataBind();
        }
    }
    protected void Plots_Allotable_General_TextChanged(object sender, EventArgs e)
    {
        //TextBox textBox = (TextBox)sender;
        //GridViewRow row = (GridViewRow)textBox.NamingContainer;
        GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;
        TextBox txt_Allotable_General = (TextBox)row.FindControl("Plots_Allotable_General");

        int rowIndex = row.RowIndex;

        int rowCount;
        if (int.TryParse(txt_Allotable_General.Text, out rowCount) && rowCount > 0)
        {
            DataTable dtCurrentTable_SC = new DataTable();
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column1", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column2", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column3", typeof(string)));
            dtCurrentTable_SC.Columns.Add(new DataColumn("Column4", typeof(string)));

            for (int i = 0; i < rowCount; i++)
            {
                DataRow dr = dtCurrentTable_SC.NewRow();
                dtCurrentTable_SC.Rows.Add(dr);
            }

            ViewState["CurrentTable_SC"] = dtCurrentTable_SC;

            General_GridDetails.Visible = true;
            General_GridDetails.DataSource = dtCurrentTable_SC;
            General_GridDetails.DataBind();
            tdGeneral.Visible = true;
        }
        else
        {
            tdGeneral.Visible = false;
            General_GridDetails.Visible = false;
            General_GridDetails.DataSource = null;
            General_GridDetails.DataBind();
        }
    }

    //protected void EnableCheckBox_CheckedChanged(object sender, EventArgs e)
    //{
    //    CheckBox chkSelect = (CheckBox)sender;
    //    GridViewRow Selectedrow = (GridViewRow)chkSelect.NamingContainer;

    //    foreach (GridViewRow row in grdDetails.Rows)
    //    {
    //        if (row.RowType == DataControlRowType.DataRow)
    //        {
    //            CheckBox checkBox = (CheckBox)row.FindControl("EnableCheckBox");

    //            if (checkBox != chkSelect)
    //            {
    //                if (chkSelect.Checked)
    //                {
    //                    checkBox.Enabled = false;
    //                }
    //                else
    //                {
    //                    checkBox.Enabled = true;
    //                }

    //                checkBox.Checked = false;
    //            }
    //        }
    //    }

    //    if (chkSelect.Checked)
    //    {
    //        TextBox IE_NAME = (TextBox)Selectedrow.FindControl("IE_NAME");
    //        DropDownList TSIIC_Category = (DropDownList)Selectedrow.FindControl("TSIIC_Category");
    //        TextBox Officer_Name = (TextBox)Selectedrow.FindControl("Officer_Name");
    //        TextBox Designation = (TextBox)Selectedrow.FindControl("Designation");
    //        TextBox TotalPlotAvailable = (TextBox)Selectedrow.FindControl("TotalPlotAvailable");
    //        TextBox TotalPlotsalloted = (TextBox)Selectedrow.FindControl("TotalPlotsalloted");
    //        TextBox TotalPlotsvacant = (TextBox)Selectedrow.FindControl("TotalPlotsvacant");
    //        TextBox Plots_mandatory_period = (TextBox)Selectedrow.FindControl("Plots_mandatory_period");
    //        TextBox reallocation_weaker_sections = (TextBox)Selectedrow.FindControl("reallocation_weaker_sections"); 
    //        TextBox Plots_Mandated_SC = (TextBox)Selectedrow.FindControl("Plots_Mandated_SC");

    //        TextBox Plots_Mandated_ST = (TextBox)Selectedrow.FindControl("Plots_Mandated_ST");
    //        TextBox Plots_Mandated_BC = (TextBox)Selectedrow.FindControl("Plots_Mandated_BC");
    //        TextBox Plots_Mandated_Minority = (TextBox)Selectedrow.FindControl("Plots_Mandated_Minority");
    //        TextBox Plots_Mandated_Women = (TextBox)Selectedrow.FindControl("Plots_Mandated_Women");
    //        TextBox Plots_Mandated_General = (TextBox)Selectedrow.FindControl("Plots_Mandated_General");
    //        TextBox Plots_Alloted_SC = (TextBox)Selectedrow.FindControl("Plots_Alloted_SC");
    //        TextBox Plots_Alloted_ST = (TextBox)Selectedrow.FindControl("Plots_Alloted_ST");
    //        TextBox Plots_Alloted_BC = (TextBox)Selectedrow.FindControl("Plots_Alloted_BC");

    //        TextBox Plots_Alloted_Minority = (TextBox)Selectedrow.FindControl("Plots_Alloted_Minority");
    //        TextBox Plots_Alloted_Women = (TextBox)Selectedrow.FindControl("Plots_Alloted_Women");
    //        TextBox Plots_Alloted_General = (TextBox)Selectedrow.FindControl("Plots_Alloted_General");
    //        TextBox Plots_Vacant_SC = (TextBox)Selectedrow.FindControl("Plots_Vacant_SC");
    //        TextBox Plots_Vacant_ST = (TextBox)Selectedrow.FindControl("Plots_Vacant_ST");
    //        TextBox Plots_Vacant_BC = (TextBox)Selectedrow.FindControl("Plots_Vacant_BC");
    //        TextBox Plots_Vacant_Minority = (TextBox)Selectedrow.FindControl("Plots_Vacant_Minority");
    //        TextBox Plots_Vacant_Women = (TextBox)Selectedrow.FindControl("Plots_Vacant_Women");
    //        TextBox Plots_Vacant_General = (TextBox)Selectedrow.FindControl("Plots_Vacant_General");

    //        TextBox Plots_Allotable_SC = (TextBox)Selectedrow.FindControl("Plots_Allotable_SC");
    //        TextBox Plots_Allotable_ST = (TextBox)Selectedrow.FindControl("Plots_Allotable_ST");
    //        TextBox Plots_Allotable_BC = (TextBox)Selectedrow.FindControl("Plots_Allotable_BC");
    //        TextBox Plots_Allotable_Minority = (TextBox)Selectedrow.FindControl("Plots_Allotable_Minority");
    //        TextBox Plots_Allotable_Women = (TextBox)Selectedrow.FindControl("Plots_Allotable_Women");
    //        TextBox Plots_Allotable_General = (TextBox)Selectedrow.FindControl("Plots_Allotable_General");
    //        TextBox Remarks = (TextBox)Selectedrow.FindControl("Remarks");

    //        if (IE_NAME != null || TSIIC_Category != null || Officer_Name != null || Designation != null || TotalPlotAvailable != null || TotalPlotsalloted != null
    //            || TotalPlotsvacant != null || Plots_mandatory_period != null || reallocation_weaker_sections != null || Plots_Mandated_SC != null || Plots_Mandated_ST != null || Plots_Mandated_BC != null ||
    //            Plots_Mandated_Minority != null || Plots_Mandated_Women != null || Plots_Mandated_General != null || Plots_Alloted_SC != null || Plots_Alloted_ST != null || Plots_Alloted_BC != null || 
    //            Plots_Alloted_Minority != null || Plots_Alloted_Women != null || Plots_Alloted_General != null || Plots_Vacant_SC != null || Plots_Vacant_ST != null || Plots_Vacant_BC != null
    //            || Plots_Vacant_Minority != null || Plots_Vacant_Women != null || Plots_Vacant_General != null || Plots_Allotable_SC != null || Plots_Allotable_ST != null || Plots_Allotable_BC != null || 
    //            Plots_Allotable_Minority != null || Plots_Allotable_Women != null || Plots_Allotable_General != null || Remarks != null)
    //        {
    //            IE_NAME.Enabled = true;
    //            TSIIC_Category.Enabled = true;
    //            Officer_Name.Enabled = true;
    //            Designation.Enabled = true;
    //            TotalPlotAvailable.Enabled = true   ;
    //            TotalPlotsalloted.Enabled = true;
    //            TotalPlotsvacant.Enabled = true;
    //            Plots_mandatory_period.Enabled = true;
    //            reallocation_weaker_sections.Enabled = true;
    //            Plots_Mandated_SC.Enabled = true;

    //            Plots_Mandated_ST.Enabled = true;
    //            Plots_Mandated_BC.Enabled = true;
    //            Plots_Mandated_Minority.Enabled = true;
    //            Plots_Mandated_Women.Enabled = true;
    //            Plots_Mandated_General.Enabled = true;
    //            Plots_Alloted_SC.Enabled = true;
    //            Plots_Alloted_ST.Enabled = true;
    //            Plots_Alloted_BC.Enabled = true;

    //            Plots_Alloted_Minority.Enabled = true;
    //            Plots_Alloted_Women.Enabled = true;
    //            Plots_Alloted_General.Enabled = true;
    //            Plots_Vacant_SC.Enabled = true;
    //            Plots_Vacant_ST.Enabled = true;
    //            Plots_Vacant_BC.Enabled = true;
    //            Plots_Vacant_Minority.Enabled = true;
    //            Plots_Vacant_Women.Enabled = true;
    //            Plots_Vacant_General.Enabled = true;

    //            Plots_Allotable_SC.Enabled = true;
    //            Plots_Allotable_ST.Enabled = true;
    //            Plots_Allotable_BC.Enabled = true;
    //            Plots_Allotable_Minority.Enabled = true;
    //            Plots_Allotable_Women.Enabled = true;
    //            Plots_Allotable_General.Enabled = true;
    //            Remarks.Enabled = true;
    //        }
    //    }
    //    else
    //    {
    //        TextBox IE_NAME = (TextBox)Selectedrow.FindControl("IE_NAME");
    //        DropDownList TSIIC_Category = (DropDownList)Selectedrow.FindControl("TSIIC_Category");
    //        TextBox Officer_Name = (TextBox)Selectedrow.FindControl("Officer_Name");
    //        TextBox Designation = (TextBox)Selectedrow.FindControl("Designation");
    //        TextBox TotalPlotAvailable = (TextBox)Selectedrow.FindControl("TotalPlotAvailable");
    //        TextBox TotalPlotsalloted = (TextBox)Selectedrow.FindControl("TotalPlotsalloted");
    //        TextBox TotalPlotsvacant = (TextBox)Selectedrow.FindControl("TotalPlotsvacant");
    //        TextBox Plots_mandatory_period = (TextBox)Selectedrow.FindControl("Plots_mandatory_period");
    //        TextBox reallocation_weaker_sections = (TextBox)Selectedrow.FindControl("reallocation_weaker_sections");
    //        TextBox Plots_Mandated_SC = (TextBox)Selectedrow.FindControl("Plots_Mandated_SC");

    //        TextBox Plots_Mandated_ST = (TextBox)Selectedrow.FindControl("Plots_Mandated_ST");
    //        TextBox Plots_Mandated_BC = (TextBox)Selectedrow.FindControl("Plots_Mandated_BC");
    //        TextBox Plots_Mandated_Minority = (TextBox)Selectedrow.FindControl("Plots_Mandated_Minority");
    //        TextBox Plots_Mandated_Women = (TextBox)Selectedrow.FindControl("Plots_Mandated_Women");
    //        TextBox Plots_Mandated_General = (TextBox)Selectedrow.FindControl("Plots_Mandated_General");
    //        TextBox Plots_Alloted_SC = (TextBox)Selectedrow.FindControl("Plots_Alloted_SC");
    //        TextBox Plots_Alloted_ST = (TextBox)Selectedrow.FindControl("Plots_Alloted_ST");
    //        TextBox Plots_Alloted_BC = (TextBox)Selectedrow.FindControl("Plots_Alloted_BC");

    //        TextBox Plots_Alloted_Minority = (TextBox)Selectedrow.FindControl("Plots_Alloted_Minority");
    //        TextBox Plots_Alloted_Women = (TextBox)Selectedrow.FindControl("Plots_Alloted_Women");
    //        TextBox Plots_Alloted_General = (TextBox)Selectedrow.FindControl("Plots_Alloted_General");
    //        TextBox Plots_Vacant_SC = (TextBox)Selectedrow.FindControl("Plots_Vacant_SC");
    //        TextBox Plots_Vacant_ST = (TextBox)Selectedrow.FindControl("Plots_Vacant_ST");
    //        TextBox Plots_Vacant_BC = (TextBox)Selectedrow.FindControl("Plots_Vacant_BC");
    //        TextBox Plots_Vacant_Minority = (TextBox)Selectedrow.FindControl("Plots_Vacant_Minority");
    //        TextBox Plots_Vacant_Women = (TextBox)Selectedrow.FindControl("Plots_Vacant_Women");
    //        TextBox Plots_Vacant_General = (TextBox)Selectedrow.FindControl("Plots_Vacant_General");

    //        TextBox Plots_Allotable_SC = (TextBox)Selectedrow.FindControl("Plots_Allotable_SC");
    //        TextBox Plots_Allotable_ST = (TextBox)Selectedrow.FindControl("Plots_Allotable_ST");
    //        TextBox Plots_Allotable_BC = (TextBox)Selectedrow.FindControl("Plots_Allotable_BC");
    //        TextBox Plots_Allotable_Minority = (TextBox)Selectedrow.FindControl("Plots_Allotable_Minority");
    //        TextBox Plots_Allotable_Women = (TextBox)Selectedrow.FindControl("Plots_Allotable_Women");
    //        TextBox Plots_Allotable_General = (TextBox)Selectedrow.FindControl("Plots_Allotable_General");
    //        TextBox Remarks = (TextBox)Selectedrow.FindControl("Remarks");

    //        if (IE_NAME != null || TSIIC_Category != null || Officer_Name != null || Designation != null || TotalPlotAvailable != null || TotalPlotsalloted != null
    //            || TotalPlotsvacant != null || Plots_mandatory_period != null || reallocation_weaker_sections != null || Plots_Mandated_SC != null || Plots_Mandated_ST != null || Plots_Mandated_BC != null ||
    //            Plots_Mandated_Minority != null || Plots_Mandated_Women != null || Plots_Mandated_General != null || Plots_Alloted_SC != null || Plots_Alloted_ST != null || Plots_Alloted_BC != null ||
    //            Plots_Alloted_Minority != null || Plots_Alloted_Women != null || Plots_Alloted_General != null || Plots_Vacant_SC != null || Plots_Vacant_ST != null || Plots_Vacant_BC != null
    //            || Plots_Vacant_Minority != null || Plots_Vacant_Women != null || Plots_Vacant_General != null || Plots_Allotable_SC != null || Plots_Allotable_ST != null || Plots_Allotable_BC != null ||
    //            Plots_Allotable_Minority != null || Plots_Allotable_Women != null || Plots_Allotable_General != null || Remarks != null)
    //        {
    //            IE_NAME.Enabled = false;
    //            TSIIC_Category.Enabled = false;
    //            Officer_Name.Enabled = false;
    //            Designation.Enabled = false;
    //            TotalPlotAvailable.Enabled = false;
    //            TotalPlotsalloted.Enabled = false;
    //            TotalPlotsvacant.Enabled = false;
    //            Plots_mandatory_period.Enabled = false;
    //            reallocation_weaker_sections.Enabled = false;
    //            Plots_Mandated_SC.Enabled = false;

    //            Plots_Mandated_ST.Enabled = false;
    //            Plots_Mandated_BC.Enabled = false;
    //            Plots_Mandated_Minority.Enabled = false;
    //            Plots_Mandated_Women.Enabled = false;
    //            Plots_Mandated_General.Enabled = false;
    //            Plots_Alloted_SC.Enabled = false;
    //            Plots_Alloted_ST.Enabled = false;
    //            Plots_Alloted_BC.Enabled = false;

    //            Plots_Alloted_Minority.Enabled = false;
    //            Plots_Alloted_Women.Enabled = false;
    //            Plots_Alloted_General.Enabled = false;
    //            Plots_Vacant_SC.Enabled = false;
    //            Plots_Vacant_ST.Enabled = false;
    //            Plots_Vacant_BC.Enabled = false;
    //            Plots_Vacant_Minority.Enabled = false;
    //            Plots_Vacant_Women.Enabled = false;
    //            Plots_Vacant_General.Enabled = false;

    //            IE_NAME.Text = string.Empty;
    //            TSIIC_Category.SelectedValue = "0";
    //            Officer_Name.Text = string.Empty;
    //            Designation.Text = string.Empty;
    //            TotalPlotAvailable.Text = string.Empty;
    //            TotalPlotsalloted.Text = string.Empty;
    //            TotalPlotsvacant.Text = string.Empty;
    //            Plots_mandatory_period.Text = string.Empty;
    //            reallocation_weaker_sections.Text = string.Empty;
    //            Plots_Mandated_SC.Text = string.Empty;

    //            Plots_Mandated_ST.Text = string.Empty;
    //            Plots_Mandated_BC.Text = string.Empty;
    //            Plots_Mandated_Minority.Text = string.Empty;
    //            Plots_Mandated_Women.Text = string.Empty;
    //            Plots_Mandated_General.Text = string.Empty;
    //            Plots_Alloted_SC.Text = string.Empty;
    //            Plots_Alloted_ST.Text = string.Empty;
    //            Plots_Alloted_BC.Text = string.Empty;

    //            Plots_Alloted_Minority.Text = string.Empty;
    //            Plots_Alloted_Women.Text = string.Empty;
    //            Plots_Alloted_General.Text = string.Empty;
    //            Plots_Vacant_SC.Text = string.Empty;
    //            Plots_Vacant_ST.Text = string.Empty;
    //            Plots_Vacant_BC.Text = string.Empty;
    //            Plots_Vacant_Minority.Text = string.Empty;
    //            Plots_Vacant_Women.Text = string.Empty;
    //            Plots_Vacant_General.Text = string.Empty;

    //            Plots_Allotable_SC.Text = string.Empty;
    //            Plots_Allotable_SC.Enabled = false;
    //            SC_GridDetails.DataSource = null;
    //            SC_GridDetails.DataBind();
    //            SC_GridDetails.Visible = false;

    //            Plots_Allotable_ST.Text = string.Empty;
    //            Plots_Allotable_ST.Enabled = false;
    //            ST_GridDetails.DataSource = null;
    //            ST_GridDetails.DataBind();
    //            ST_GridDetails.Visible = false;

    //            Plots_Allotable_BC.Text = string.Empty;
    //            Plots_Allotable_BC.Enabled = false;
    //            BC_GridDetails.DataSource = null;
    //            BC_GridDetails.DataBind();
    //            BC_GridDetails.Visible = false;

    //            Plots_Allotable_Minority.Text = string.Empty;
    //            Plots_Allotable_Minority.Enabled = false;
    //            Minority_GridDetails.DataSource = null;
    //            Minority_GridDetails.DataBind();
    //            Minority_GridDetails.Visible = false;

    //            Plots_Allotable_Women.Text = string.Empty;
    //            Plots_Allotable_Women.Enabled = false;
    //            Women_GridDetails.DataSource = null;
    //            Women_GridDetails.DataBind();
    //            Women_GridDetails.Visible = false;

    //            Plots_Allotable_General.Text = string.Empty;
    //            Plots_Allotable_General.Enabled = false;
    //            General_GridDetails.DataSource = null;
    //            General_GridDetails.DataBind();
    //            General_GridDetails.Visible = false;

    //            Remarks.Enabled = false;
    //            Remarks.Text = string.Empty;
    //        }
    //    }
    //}

    protected void Weaker_Section_TEMPGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("WeakerSectionDELETE"))
        {
            DataTable dt = (DataTable)ViewState["WEAKERSECTIONCURRENTTABLE"];
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int RowINdex = gvr.RowIndex;
            if (dt.Rows.Count >= 1)
            {
                dt.Rows[RowINdex].Delete();
                dt.AcceptChanges();
                ViewState["WEAKERSECTIONCURRENTTABLE"] = dt;
                Weaker_Section_TEMPGrid.DataSource = ViewState["WEAKERSECTIONCURRENTTABLE"];
                Weaker_Section_TEMPGrid.DataBind();
            }
        }
    }

    public string ValidateLandControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        GridViewRow Selectedrow = grdDetails.Rows[0];
        TextBox Plots_Allotable_SC = (TextBox)Selectedrow.FindControl("Plots_Allotable_SC");
        TextBox Plots_Allotable_ST = (TextBox)Selectedrow.FindControl("Plots_Allotable_ST");
        TextBox Plots_Allotable_BC = (TextBox)Selectedrow.FindControl("Plots_Allotable_BC");
        TextBox Plots_Allotable_Minority = (TextBox)Selectedrow.FindControl("Plots_Allotable_Minority");
        TextBox Plots_Allotable_Women = (TextBox)Selectedrow.FindControl("Plots_Allotable_Women");
        TextBox Plots_Allotable_General = (TextBox)Selectedrow.FindControl("Plots_Allotable_General");

        if (Plots_Allotable_SC.Text != "" && Plots_Allotable_SC.Text != "0")
        {
            foreach (GridViewRow row in SC_GridDetails.Rows)
            {
                //GridViewRow row = SC_GridDetails.Rows[0];
                TextBox SC_Allotable_PlotNo = (TextBox)row.FindControl("SC_Allotable_PlotNo");
                TextBox SC_PlotArea = (TextBox)row.FindControl("SC_PlotArea");
                TextBox SC_PlotCost = (TextBox)row.FindControl("SC_PlotCost");

                if (SC_Allotable_PlotNo.Text == "" || SC_PlotArea.Text == "" || SC_PlotCost.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please fill SC Plot all fields to proceed \\n";
                    slno = slno + 1;
                }
            }
        }
        else if (Plots_Allotable_SC.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Allotable SC Plots. If not alloting Enter 0.  \\n";
            slno = slno + 1;
        }
        if (Plots_Allotable_ST.Text != "" && Plots_Allotable_ST.Text != "0")
        {
            foreach (GridViewRow RowID in ST_GridDetails.Rows)
            {
                //GridViewRow RowID = ST_GridDetails.Rows[0];
                TextBox ST_Allotable_PlotNo = (TextBox)RowID.FindControl("ST_Allotable_PlotNo");
                TextBox ST_PlotArea = (TextBox)RowID.FindControl("ST_PlotArea");
                TextBox ST_PlotCost = (TextBox)RowID.FindControl("ST_PlotCost");

                if (ST_Allotable_PlotNo.Text == "" || ST_PlotArea.Text == "" || ST_PlotCost.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please fill ST Plot all fields to proceed \\n";
                    slno = slno + 1;
                }
            }
        }
        else if (Plots_Allotable_ST.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Allotable ST Plots. If not alloting Enter 0.  \\n";
            slno = slno + 1;
        }
        if (Plots_Allotable_BC.Text != "" && Plots_Allotable_BC.Text != "0")
        {
            foreach (GridViewRow RowID1 in BC_GridDetails.Rows)
            {
                //GridViewRow RowID1 = BC_GridDetails.Rows[0];
                TextBox BC_Allotable_PlotNo = (TextBox)RowID1.FindControl("BC_Allotable_PlotNo");
                TextBox BC_PlotArea = (TextBox)RowID1.FindControl("BC_PlotArea");
                TextBox BC_PlotCost = (TextBox)RowID1.FindControl("BC_PlotCost");

                if (BC_Allotable_PlotNo.Text == "" || BC_PlotArea.Text == "" || BC_PlotCost.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please fill BC Plot all fields to proceed \\n";
                    slno = slno + 1;
                }
            }
        }
        else if (Plots_Allotable_BC.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Allotable BC Plots. If not alloting Enter 0.  \\n";
            slno = slno + 1;
        }
        if (Plots_Allotable_Minority.Text != "" && Plots_Allotable_Minority.Text != "0")
        {
            foreach (GridViewRow RowID2 in Minority_GridDetails.Rows)
            {
                //GridViewRow RowID2 = Minority_GridDetails.Rows[0];
                TextBox Minority_Allotable_PlotNo = (TextBox)RowID2.FindControl("Minority_Allotable_PlotNo");
                TextBox Minority_PlotArea = (TextBox)RowID2.FindControl("Minority_PlotArea");
                TextBox Minority_PlotCost = (TextBox)RowID2.FindControl("Minority_PlotCost");

                if (Minority_Allotable_PlotNo.Text == "" || Minority_PlotArea.Text == "" || Minority_PlotCost.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please fill Minority Plot all fields to proceed \\n";
                    slno = slno + 1;
                }
            }
        }
        else if (Plots_Allotable_Minority.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Allotable Minority Plots. If not alloting Enter 0.  \\n";
            slno = slno + 1;
        }
        if (Plots_Allotable_Women.Text != "" && Plots_Allotable_Women.Text != "0")
        {
            foreach (GridViewRow RowID3 in Women_GridDetails.Rows)
            {
                //GridViewRow RowID3 = Women_GridDetails.Rows[0];
                TextBox Women_Allotable_PlotNo = (TextBox)RowID3.FindControl("Women_Allotable_PlotNo");
                TextBox Women_PlotArea = (TextBox)RowID3.FindControl("Women_PlotArea");
                TextBox Women_PlotCost = (TextBox)RowID3.FindControl("Women_PlotCost");

                if (Women_Allotable_PlotNo.Text == "" || Women_PlotArea.Text == "" || Women_PlotCost.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please fill Women Plot all fields to proceed \\n";
                    slno = slno + 1;
                }
            }
        }
        else if (Plots_Allotable_Women.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Allotable Women Plots. If not alloting Enter 0.  \\n";
            slno = slno + 1;
        }
        if (Plots_Allotable_General.Text != "" && Plots_Allotable_General.Text != "0")
        {
            foreach (GridViewRow RowID4 in General_GridDetails.Rows)
            {
                //GridViewRow RowID4 = General_GridDetails.Rows[0];
                TextBox General_Allotable_PlotNo = (TextBox)RowID4.FindControl("General_Allotable_PlotNo");
                TextBox General_PlotArea = (TextBox)RowID4.FindControl("General_PlotArea");
                TextBox General_PlotCost = (TextBox)RowID4.FindControl("General_PlotCost");

                if (General_Allotable_PlotNo.Text == "" || General_PlotArea.Text == "" || General_PlotCost.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please fill General Plot all fields to proceed \\n";
                    slno = slno + 1;
                }
            }
        }
        else if (Plots_Allotable_General.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Allotable General Plots. If not alloting Enter 0.  \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }

    protected void AddRecordBtn_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateLandControls();
        // string errormsg = "";
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("IE Name", typeof(string));
                dt.Columns.Add("TSIIC STATUS", typeof(string));
                dt.Columns.Add("OFFICER NAME", typeof(string));
                dt.Columns.Add("OFFICER DESIGNATION", typeof(string));
                dt.Columns.Add("Total Plots Available", typeof(string));
                dt.Columns.Add("Total Plots Alloted", typeof(string));
                dt.Columns.Add("Total Plots Vacant", typeof(string));
                dt.Columns.Add("Plots Not Mandatory", typeof(string));
                dt.Columns.Add("Plots Reallocated [Weaker]", typeof(string));
                dt.Columns.Add("Plots Mandated [SC]", typeof(string));
                dt.Columns.Add("Plots Mandated [ST]", typeof(string));
                dt.Columns.Add("Plots Mandated [BC]", typeof(string));
                dt.Columns.Add("Plots Mandated [MINORITY]", typeof(string));
                dt.Columns.Add("Plots Mandated [WOMEN]", typeof(string));
                dt.Columns.Add("Plots Mandated [GENERAL]", typeof(string));
                dt.Columns.Add("Plots Alloted [SC]", typeof(string));
                dt.Columns.Add("Plots Alloted [ST]", typeof(string));
                dt.Columns.Add("Plots Alloted [BC]", typeof(string));
                dt.Columns.Add("Plots Alloted [MINORITY]", typeof(string));
                dt.Columns.Add("Plots Alloted [WOMEN]", typeof(string));
                dt.Columns.Add("Plots Alloted [GENERAL]", typeof(string));
                dt.Columns.Add("Plots Vacant [SC]", typeof(string));
                dt.Columns.Add("Plots Vacant [ST]", typeof(string));
                dt.Columns.Add("Plots Vacant [BC]", typeof(string));
                dt.Columns.Add("Plots Vacant [MINORITY]", typeof(string));
                dt.Columns.Add("Plots Vacant [WOMEN]", typeof(string));
                dt.Columns.Add("Plots Vacant [GENERAL]", typeof(string));
                dt.Columns.Add("Plots Allotable [SC]", typeof(string));
                dt.Columns.Add("Plots Allotable [ST]", typeof(string));
                dt.Columns.Add("Plots Allotable [BC]", typeof(string));
                dt.Columns.Add("Plots Allotable [MINORITY]", typeof(string));
                dt.Columns.Add("Plots Allotable [WOMEN]", typeof(string));
                dt.Columns.Add("Plots Allotable [GENERAL]", typeof(string));
                dt.Columns.Add("REMARKS", typeof(string));

                //if (ViewState["INDUSTRIALESTATEDETAILS"] != null)
                //{
                //    if (ViewState["INDUSTRIALESTATEDETAILS"].ToString() != "0")
                //    {
                //        dt = (DataTable)ViewState["INDUSTRIALESTATEDETAILS"];
                //    }
                DataRow dr = dt.NewRow();

                GridViewRow row = grdDetails.Rows[0];

                dr["IE Name"] = ((TextBox)row.FindControl("IE_NAME")).Text;
                dr["TSIIC STATUS"] = ((DropDownList)row.FindControl("TSIIC_Category")).SelectedItem.Text;
                dr["OFFICER NAME"] = ((DropDownList)row.FindControl("ddlOfficerName")).SelectedItem.Text;
                dr["OFFICER DESIGNATION"] = ((TextBox)row.FindControl("Designation")).Text;
                dr["Total Plots Available"] = ((TextBox)row.FindControl("TotalPlotAvailable")).Text;
                dr["Total Plots Alloted"] = ((TextBox)row.FindControl("TotalPlotsalloted")).Text;
                dr["Total Plots Vacant"] = ((TextBox)row.FindControl("TotalPlotsvacant")).Text;
                dr["Plots Not Mandatory"] = ((TextBox)row.FindControl("Plots_mandatory_period")).Text;
                dr["Plots Reallocated [Weaker]"] = ((TextBox)row.FindControl("reallocation_weaker_sections")).Text;
                dr["Plots Mandated [SC]"] = ((TextBox)row.FindControl("Plots_Mandated_SC")).Text;
                dr["Plots Mandated [ST]"] = ((TextBox)row.FindControl("Plots_Mandated_ST")).Text;
                dr["Plots Mandated [BC]"] = ((TextBox)row.FindControl("Plots_Mandated_BC")).Text;
                dr["Plots Mandated [MINORITY]"] = ((TextBox)row.FindControl("Plots_Mandated_Minority")).Text;
                dr["Plots Mandated [WOMEN]"] = ((TextBox)row.FindControl("Plots_Mandated_Women")).Text;
                dr["Plots Mandated [GENERAL]"] = ((TextBox)row.FindControl("Plots_Mandated_General")).Text;
                dr["Plots Alloted [SC]"] = ((TextBox)row.FindControl("Plots_Alloted_SC")).Text;
                dr["Plots Alloted [ST]"] = ((TextBox)row.FindControl("Plots_Alloted_ST")).Text;
                dr["Plots Alloted [BC]"] = ((TextBox)row.FindControl("Plots_Alloted_BC")).Text;
                dr["Plots Alloted [MINORITY]"] = ((TextBox)row.FindControl("Plots_Alloted_Minority")).Text;
                dr["Plots Alloted [WOMEN]"] = ((TextBox)row.FindControl("Plots_Alloted_Women")).Text;
                dr["Plots Alloted [GENERAL]"] = ((TextBox)row.FindControl("Plots_Alloted_General")).Text;
                dr["Plots Vacant [SC]"] = ((TextBox)row.FindControl("Plots_Vacant_SC")).Text;
                dr["Plots Vacant [ST]"] = ((TextBox)row.FindControl("Plots_Vacant_ST")).Text;
                dr["Plots Vacant [BC]"] = ((TextBox)row.FindControl("Plots_Vacant_BC")).Text;
                dr["Plots Vacant [MINORITY]"] = ((TextBox)row.FindControl("Plots_Vacant_Minority")).Text;
                dr["Plots Vacant [WOMEN]"] = ((TextBox)row.FindControl("Plots_Vacant_Women")).Text;
                dr["Plots Vacant [GENERAL]"] = ((TextBox)row.FindControl("Plots_Vacant_General")).Text;
                dr["Plots Allotable [SC]"] = ((TextBox)row.FindControl("Plots_Allotable_SC")).Text;
                dr["Plots Allotable [ST]"] = ((TextBox)row.FindControl("Plots_Allotable_ST")).Text;
                dr["Plots Allotable [BC]"] = ((TextBox)row.FindControl("Plots_Allotable_BC")).Text;
                dr["Plots Allotable [MINORITY]"] = ((TextBox)row.FindControl("Plots_Allotable_Minority")).Text;
                dr["Plots Allotable [WOMEN]"] = ((TextBox)row.FindControl("Plots_Allotable_Women")).Text;
                dr["Plots Allotable [GENERAL]"] = ((TextBox)row.FindControl("Plots_Allotable_General")).Text;
                dr["REMARKS"] = ((TextBox)row.FindControl("Remarks")).Text;


                dt.Rows.Add(dr);
                Weaker_Section_TEMPGrid.DataSource = dt;
                Weaker_Section_TEMPGrid.DataBind();
                ViewState["WEAKERSECTIONCURRENTTABLE"] = dt;
                //ClearWeakerGridData();

                SUBMIT_CLEAR_BTNS.Visible = true;
                //}

                //else
                //{
                //    DataRow dr = dt.NewRow();
                //    GridViewRow row = grdDetails.Rows[0];

                //    dr["IE Name"] = ((TextBox)row.FindControl("IE_NAME")).Text;
                //    dr["TSIIC STATUS"] = ((DropDownList)row.FindControl("TSIIC_Category")).SelectedItem.Text;
                //    dr["OFFICER NAME"] = ((TextBox)row.FindControl("Officer_Name")).Text;
                //    dr["OFFICER DESIGNATION"] = ((TextBox)row.FindControl("Designation")).Text;
                //    dr["Total Plots Available"] = ((TextBox)row.FindControl("TotalPlotAvailable")).Text;
                //    dr["Total Plots Alloted"] = ((TextBox)row.FindControl("TotalPlotsalloted")).Text;
                //    dr["Total Plots Vacant"] = ((TextBox)row.FindControl("TotalPlotsvacant")).Text;
                //    dr["Plots Not Mandatory"] = ((TextBox)row.FindControl("Plots_mandatory_period")).Text;
                //    dr["Plots Reallocated [Weaker]"] = ((TextBox)row.FindControl("reallocation_weaker_sections")).Text;
                //    dr["Plots Mandated [SC]"] = ((TextBox)row.FindControl("Plots_Mandated_SC")).Text;
                //    dr["Plots Mandated [ST]"] = ((TextBox)row.FindControl("Plots_Mandated_ST")).Text;
                //    dr["Plots Mandated [BC]"] = ((TextBox)row.FindControl("Plots_Mandated_BC")).Text;
                //    dr["Plots Mandated [MINORITY]"] = ((TextBox)row.FindControl("Plots_Mandated_Minority")).Text;
                //    dr["Plots Mandated [WOMEN]"] = ((TextBox)row.FindControl("Plots_Mandated_Women")).Text;
                //    dr["Plots Mandated [GENERAL]"] = ((TextBox)row.FindControl("Plots_Mandated_General")).Text;
                //    dr["Plots Alloted [SC]"] = ((TextBox)row.FindControl("Plots_Alloted_SC")).Text;
                //    dr["Plots Alloted [ST]"] = ((TextBox)row.FindControl("Plots_Alloted_ST")).Text;
                //    dr["Plots Alloted [BC]"] = ((TextBox)row.FindControl("Plots_Alloted_BC")).Text;
                //    dr["Plots Alloted [MINORITY]"] = ((TextBox)row.FindControl("Plots_Alloted_Minority")).Text;
                //    dr["Plots Alloted [WOMEN]"] = ((TextBox)row.FindControl("Plots_Alloted_Women")).Text;
                //    dr["Plots Alloted [GENERAL]"] = ((TextBox)row.FindControl("Plots_Alloted_General")).Text;
                //    dr["Plots Vacant [SC]"] = ((TextBox)row.FindControl("Plots_Vacant_SC")).Text;
                //    dr["Plots Vacant [ST]"] = ((TextBox)row.FindControl("Plots_Vacant_ST")).Text;
                //    dr["Plots Vacant [BC]"] = ((TextBox)row.FindControl("Plots_Vacant_BC")).Text;
                //    dr["Plots Vacant [MINORITY]"] = ((TextBox)row.FindControl("Plots_Vacant_Minority")).Text;
                //    dr["Plots Vacant [WOMEN]"] = ((TextBox)row.FindControl("Plots_Vacant_Women")).Text;
                //    dr["Plots Vacant [GENERAL]"] = ((TextBox)row.FindControl("Plots_Vacant_General")).Text;
                //    dr["Plots Allotable [SC]"] = ((TextBox)row.FindControl("Plots_Allotable_SC")).Text;
                //    dr["Plots Allotable [ST]"] = ((TextBox)row.FindControl("Plots_Allotable_ST")).Text;
                //    dr["Plots Allotable [BC]"] = ((TextBox)row.FindControl("Plots_Allotable_BC")).Text;
                //    dr["Plots Allotable [MINORITY]"] = ((TextBox)row.FindControl("Plots_Allotable_Minority")).Text;
                //    dr["Plots Allotable [WOMEN]"] = ((TextBox)row.FindControl("Plots_Allotable_Women")).Text;
                //    dr["Plots Allotable [GENERAL]"] = ((TextBox)row.FindControl("Plots_Allotable_General")).Text;
                //    dr["REMARKS"] = ((TextBox)row.FindControl("Remarks")).Text;

                //    dt.Rows.Add(dr);
                //    Weaker_Section_TEMPGrid.DataSource = dt;
                //    Weaker_Section_TEMPGrid.DataBind();
                //    ViewState["WEAKERSECTIONCURRENTTABLE"] = dt;
                //    ClearWeakerGridData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public void ClearWeakerGridData()
    {
        GridViewRow row = grdDetails.Rows[0];
        ((TextBox)row.FindControl("IE_NAME")).Text = string.Empty;
        ((DropDownList)row.FindControl("TSIIC_Category")).SelectedValue = "0";
        ((TextBox)row.FindControl("Officer_Name")).Text = string.Empty;
        ((TextBox)row.FindControl("Designation")).Text = string.Empty;
        ((TextBox)row.FindControl("TotalPlotAvailable")).Text = string.Empty;
        ((TextBox)row.FindControl("TotalPlotsalloted")).Text = string.Empty;
        ((TextBox)row.FindControl("TotalPlotsvacant")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_mandatory_period")).Text = string.Empty;
        ((TextBox)row.FindControl("reallocation_weaker_sections")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Mandated_SC")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Mandated_ST")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Mandated_BC")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Mandated_Minority")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Mandated_Women")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Mandated_General")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Alloted_SC")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Alloted_ST")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Alloted_BC")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Alloted_Minority")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Alloted_Women")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Alloted_General")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Vacant_SC")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Vacant_ST")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Vacant_BC")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Vacant_Minority")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Vacant_Women")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Vacant_General")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Allotable_SC")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Allotable_ST")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Allotable_BC")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Allotable_Minority")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Allotable_Women")).Text = string.Empty;
        ((TextBox)row.FindControl("Plots_Allotable_General")).Text = string.Empty;
        ((TextBox)row.FindControl("Remarks")).Text = string.Empty;
        SC_GridDetails.DataSource = null;
        SC_GridDetails.DataBind();
        SC_GridDetails.Visible = false;
        ST_GridDetails.DataSource = null;
        ST_GridDetails.DataBind();
        ST_GridDetails.Visible = false;
        BC_GridDetails.DataSource = null;
        BC_GridDetails.DataBind();
        BC_GridDetails.Visible = false;
        Minority_GridDetails.DataSource = null;
        Minority_GridDetails.DataBind();
        Minority_GridDetails.Visible = false;
        Women_GridDetails.DataSource = null;
        Women_GridDetails.DataBind();
        Women_GridDetails.Visible = false;
        General_GridDetails.DataSource = null;
        General_GridDetails.DataBind();
        General_GridDetails.Visible = false;
    }
    protected void ClearRecordBtn_Click(object sender, EventArgs e)
    {
        ClearWeakerGridData();
    }
    protected void SUBMITRECORD_Click(object sender, EventArgs e)
    {
        try
        {
            //string errormsg = ValidateLandControls();
            GridViewRow row = grdDetails.Rows[0];
            if (((TextBox)row.FindControl("IE_NAME")).Text != "" &&
                ((DropDownList)row.FindControl("TSIIC_Category")).SelectedItem.Text != "--Select--" &&
                ((DropDownList)row.FindControl("ddlOfficerName")).SelectedItem.Text != "--Select--" &&
                ((TextBox)row.FindControl("Designation")).Text != "" &&
                ((TextBox)row.FindControl("TotalPlotAvailable")).Text != "" &&
                ((TextBox)row.FindControl("TotalPlotsalloted")).Text != "" &&
                ((TextBox)row.FindControl("TotalPlotsvacant")).Text != "" &&
                ((TextBox)row.FindControl("Plots_mandatory_period")).Text != "" &&
                ((TextBox)row.FindControl("reallocation_weaker_sections")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Mandated_SC")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Mandated_ST")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Mandated_BC")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Mandated_Minority")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Mandated_Women")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Mandated_General")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Alloted_SC")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Alloted_ST")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Alloted_BC")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Alloted_Minority")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Alloted_Women")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Alloted_General")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Vacant_SC")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Vacant_ST")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Vacant_BC")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Vacant_Minority")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Vacant_Women")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Vacant_General")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Allotable_SC")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Allotable_ST")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Allotable_BC")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Allotable_Minority")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Allotable_Women")).Text != "" &&
                ((TextBox)row.FindControl("Plots_Allotable_General")).Text != "")
            {
                DataTable IEDATA = new DataTable();
                int IE_ID;
                con.OpenConnection();
                using (SqlCommand command = new SqlCommand("SP_INSERT_DIST_INDUSTRIAL_ESTATE_DETAILS", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DISTRICT", ddldistrict.SelectedValue);
                    command.Parameters.AddWithValue("@IE_NAME", ((TextBox)row.FindControl("IE_NAME")).Text);
                    command.Parameters.AddWithValue("@TSIIC_Category", ((DropDownList)row.FindControl("TSIIC_Category")).SelectedItem.Text);
                    command.Parameters.AddWithValue("@Officer_Name", ((DropDownList)row.FindControl("ddlOfficerName")).SelectedItem.Text);
                    command.Parameters.AddWithValue("@Designation", ((TextBox)row.FindControl("Designation")).Text);
                    command.Parameters.AddWithValue("@TotalPlotAvailable", ((TextBox)row.FindControl("TotalPlotAvailable")).Text);
                    command.Parameters.AddWithValue("@TotalPlotsalloted", ((TextBox)row.FindControl("TotalPlotsalloted")).Text);
                    command.Parameters.AddWithValue("@TotalPlotsvacant", ((TextBox)row.FindControl("TotalPlotsvacant")).Text);
                    command.Parameters.AddWithValue("@Plots_mandatory_period", ((TextBox)row.FindControl("Plots_mandatory_period")).Text);
                    command.Parameters.AddWithValue("@reallocation_weaker_sections", ((TextBox)row.FindControl("reallocation_weaker_sections")).Text);
                    command.Parameters.AddWithValue("@Plots_Mandated_SC", ((TextBox)row.FindControl("Plots_Mandated_SC")).Text);
                    command.Parameters.AddWithValue("@Plots_Mandated_ST", ((TextBox)row.FindControl("Plots_Mandated_ST")).Text);
                    command.Parameters.AddWithValue("@Plots_Mandated_BC", ((TextBox)row.FindControl("Plots_Mandated_BC")).Text);
                    command.Parameters.AddWithValue("@Plots_Mandated_Minority", ((TextBox)row.FindControl("Plots_Mandated_Minority")).Text);
                    command.Parameters.AddWithValue("@Plots_Mandated_Women", ((TextBox)row.FindControl("Plots_Mandated_Women")).Text);
                    command.Parameters.AddWithValue("@Plots_Mandated_General", ((TextBox)row.FindControl("Plots_Mandated_General")).Text);
                    command.Parameters.AddWithValue("@Plots_Alloted_SC", ((TextBox)row.FindControl("Plots_Alloted_SC")).Text);
                    command.Parameters.AddWithValue("@Plots_Alloted_ST", ((TextBox)row.FindControl("Plots_Alloted_ST")).Text);
                    command.Parameters.AddWithValue("@Plots_Alloted_BC", ((TextBox)row.FindControl("Plots_Alloted_BC")).Text);
                    command.Parameters.AddWithValue("@Plots_Alloted_Minority", ((TextBox)row.FindControl("Plots_Alloted_Minority")).Text);
                    command.Parameters.AddWithValue("@Plots_Alloted_Women", ((TextBox)row.FindControl("Plots_Alloted_Women")).Text);
                    command.Parameters.AddWithValue("@Plots_Alloted_General", ((TextBox)row.FindControl("Plots_Alloted_General")).Text);
                    command.Parameters.AddWithValue("@Plots_Vacant_SC", ((TextBox)row.FindControl("Plots_Vacant_SC")).Text);
                    command.Parameters.AddWithValue("@Plots_Vacant_ST", ((TextBox)row.FindControl("Plots_Vacant_ST")).Text);
                    command.Parameters.AddWithValue("@Plots_Vacant_BC", ((TextBox)row.FindControl("Plots_Vacant_BC")).Text);
                    command.Parameters.AddWithValue("@Plots_Vacant_Minority", ((TextBox)row.FindControl("Plots_Vacant_Minority")).Text);
                    command.Parameters.AddWithValue("@Plots_Vacant_Women", ((TextBox)row.FindControl("Plots_Vacant_Women")).Text);
                    command.Parameters.AddWithValue("@Plots_Vacant_General", ((TextBox)row.FindControl("Plots_Vacant_General")).Text);
                    command.Parameters.AddWithValue("@Plots_Allotable_SC", ((TextBox)row.FindControl("Plots_Allotable_SC")).Text);
                    command.Parameters.AddWithValue("@Plots_Allotable_ST", ((TextBox)row.FindControl("Plots_Allotable_ST")).Text);
                    command.Parameters.AddWithValue("@Plots_Allotable_BC", ((TextBox)row.FindControl("Plots_Allotable_BC")).Text);
                    command.Parameters.AddWithValue("@Plots_Allotable_Minority", ((TextBox)row.FindControl("Plots_Allotable_Minority")).Text);
                    command.Parameters.AddWithValue("@Plots_Allotable_Women", ((TextBox)row.FindControl("Plots_Allotable_Women")).Text);
                    command.Parameters.AddWithValue("@Plots_Allotable_General", ((TextBox)row.FindControl("Plots_Allotable_General")).Text);
                    command.Parameters.AddWithValue("@Remarks", ((TextBox)row.FindControl("Remarks")).Text);
                    command.Parameters.AddWithValue("@CreatedBy", Session["uid"].ToString());
                    command.Parameters.Add("@IE_ID", SqlDbType.Int);
                    command.Parameters["@IE_ID"].Direction = ParameterDirection.Output;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(IEDATA);
                        IE_ID = (int)command.Parameters["@IE_ID"].Value;
                    }
                    con.CloseConnection();
                    ViewState["IE_ID"] = IE_ID;
                }
                if (SC_GridDetails.Rows.Count > 0)
                {
                    using (SqlCommand command = new SqlCommand("USP_INDUSTRIAL_ESTATE_SC_DETAILS", con.GetConnection))
                    {
                        con.OpenConnection();
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (GridViewRow rowID in SC_GridDetails.Rows)
                        {
                            //GridViewRow rowID = grdDetails.Rows[0];
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@IE_ID", IE_ID);
                            command.Parameters.AddWithValue("@DISTRICT", ddldistrict.SelectedValue);
                            command.Parameters.AddWithValue("@IE_NAME", ((TextBox)row.FindControl("IE_NAME")).Text);
                            command.Parameters.AddWithValue("@Plots_Allotable_SC", ((TextBox)row.FindControl("Plots_Allotable_SC")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_No_SC", ((TextBox)rowID.FindControl("SC_Allotable_PlotNo")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_Area_SC", ((TextBox)rowID.FindControl("SC_PlotArea")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_Cost_SC", ((TextBox)rowID.FindControl("SC_PlotCost")).Text);
                            command.Parameters.AddWithValue("@CreatedBy", Session["uid"].ToString());
                            command.ExecuteNonQuery();
                        }
                        con.CloseConnection();
                        Session["IE_ID"] = IE_ID;
                        ViewState["IE_ID"] = IE_ID;
                    }
                }
                if (ST_GridDetails.Rows.Count > 0)
                {
                    using (SqlCommand command = new SqlCommand("USP_INDUSTRIAL_ESTATE_ST_DETAILS", con.GetConnection))
                    {
                        con.OpenConnection();
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (GridViewRow rowID in ST_GridDetails.Rows)
                        {
                            //GridViewRow rowID = grdDetails.Rows[0];
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@IE_ID", IE_ID);
                            command.Parameters.AddWithValue("@DISTRICT", ddldistrict.SelectedValue);
                            command.Parameters.AddWithValue("@IE_NAME", ((TextBox)row.FindControl("IE_NAME")).Text);
                            command.Parameters.AddWithValue("@Plots_Allotable_ST", ((TextBox)row.FindControl("Plots_Allotable_ST")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_No_ST", ((TextBox)rowID.FindControl("ST_Allotable_PlotNo")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_Area_ST", ((TextBox)rowID.FindControl("ST_PlotArea")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_Cost_ST", ((TextBox)rowID.FindControl("ST_PlotCost")).Text);
                            command.Parameters.AddWithValue("@CreatedBy", Session["uid"].ToString());
                            command.ExecuteNonQuery();
                        }
                        con.CloseConnection();
                        Session["IE_ID"] = IE_ID;
                        ViewState["IE_ID"] = IE_ID;
                    }
                }
                if (BC_GridDetails.Rows.Count > 0)
                {
                    using (SqlCommand command = new SqlCommand("USP_INDUSTRIAL_ESTATE_BC_DETAILS", con.GetConnection))
                    {
                        con.OpenConnection();
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (GridViewRow rowID in BC_GridDetails.Rows)
                        {
                            //GridViewRow row = grdDetails.Rows[0];
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@IE_ID", IE_ID);
                            command.Parameters.AddWithValue("@DISTRICT", ddldistrict.SelectedValue);
                            command.Parameters.AddWithValue("@IE_NAME", ((TextBox)row.FindControl("IE_NAME")).Text);
                            command.Parameters.AddWithValue("@Plots_Allotable_BC", ((TextBox)row.FindControl("Plots_Allotable_BC")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_No_BC", ((TextBox)rowID.FindControl("BC_Allotable_PlotNo")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_Area_BC", ((TextBox)rowID.FindControl("BC_PlotArea")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_Cost_BC", ((TextBox)rowID.FindControl("BC_PlotCost")).Text);
                            command.Parameters.AddWithValue("@CreatedBy", Session["uid"].ToString());
                            command.ExecuteNonQuery();
                        }
                        con.CloseConnection();
                        Session["IE_ID"] = IE_ID;
                        ViewState["IE_ID"] = IE_ID;
                    }
                }
                if (Minority_GridDetails.Rows.Count > 0)
                {
                    using (SqlCommand command = new SqlCommand("USP_INDUSTRIAL_ESTATE_Minority_DETAILS", con.GetConnection))
                    {
                        con.OpenConnection();
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (GridViewRow rowID in Minority_GridDetails.Rows)
                        {
                            //GridViewRow rowID = grdDetails.Rows[0];
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@IE_ID", IE_ID);
                            command.Parameters.AddWithValue("@DISTRICT", ddldistrict.SelectedValue);
                            command.Parameters.AddWithValue("@IE_NAME", ((TextBox)row.FindControl("IE_NAME")).Text);
                            command.Parameters.AddWithValue("@Plots_Allotable_Minority", ((TextBox)row.FindControl("Plots_Allotable_Minority")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_No_Minority", ((TextBox)rowID.FindControl("Minority_Allotable_PlotNo")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_Area_Minority", ((TextBox)rowID.FindControl("Minority_PlotArea")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_Cost_Minority", ((TextBox)rowID.FindControl("Minority_PlotCost")).Text);
                            command.Parameters.AddWithValue("@CreatedBy", Session["uid"].ToString());
                            command.ExecuteNonQuery();
                        }
                        con.CloseConnection();
                        Session["IE_ID"] = IE_ID;
                        ViewState["IE_ID"] = IE_ID;
                    }
                }
                if (Women_GridDetails.Rows.Count > 0)
                {
                    using (SqlCommand command = new SqlCommand("USP_INDUSTRIAL_ESTATE_Women_DETAILS", con.GetConnection))
                    {
                        con.OpenConnection();
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (GridViewRow rowID in Women_GridDetails.Rows)
                        {
                            //GridViewRow rowID = grdDetails.Rows[0];
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@IE_ID", IE_ID);
                            command.Parameters.AddWithValue("@DISTRICT", ddldistrict.SelectedValue);
                            command.Parameters.AddWithValue("@IE_NAME", ((TextBox)row.FindControl("IE_NAME")).Text);
                            command.Parameters.AddWithValue("@Plots_Allotable_Women", ((TextBox)row.FindControl("Plots_Allotable_Women")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_No_Women", ((TextBox)rowID.FindControl("Women_Allotable_PlotNo")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_Area_Women", ((TextBox)rowID.FindControl("Women_PlotArea")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_Cost_Women", ((TextBox)rowID.FindControl("Women_PlotCost")).Text);
                            command.Parameters.AddWithValue("@CreatedBy", Session["uid"].ToString());
                            command.ExecuteNonQuery();
                        }
                        con.CloseConnection();
                        Session["IE_ID"] = IE_ID;
                        ViewState["IE_ID"] = IE_ID;
                    }
                }
                if (General_GridDetails.Rows.Count > 0)
                {
                    using (SqlCommand command = new SqlCommand("USP_INDUSTRIAL_ESTATE_General_DETAILS", con.GetConnection))
                    {
                        con.OpenConnection();
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (GridViewRow rowID in General_GridDetails.Rows)
                        {
                            //GridViewRow rowID = grdDetails.Rows[0];
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@IE_ID", IE_ID);
                            command.Parameters.AddWithValue("@DISTRICT", ddldistrict.SelectedValue);
                            command.Parameters.AddWithValue("@IE_NAME", ((TextBox)row.FindControl("IE_NAME")).Text);
                            command.Parameters.AddWithValue("@Plots_Allotable_General", ((TextBox)row.FindControl("Plots_Allotable_General")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_No_General", ((TextBox)rowID.FindControl("General_Allotable_PlotNo")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_Area_General", ((TextBox)rowID.FindControl("General_PlotArea")).Text);
                            command.Parameters.AddWithValue("@Allotable_Plot_Cost_General", ((TextBox)rowID.FindControl("General_PlotCost")).Text);
                            command.Parameters.AddWithValue("@CreatedBy", Session["uid"].ToString());
                            command.ExecuteNonQuery();
                        }
                        con.CloseConnection();
                        Session["IE_ID"] = IE_ID;
                        ViewState["IE_ID"] = IE_ID;
                    }
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('All Details are Successfully Submitted.');", true);
                ClearWeakerGridData();
                SUBMIT_CLEAR_BTNS.Visible = false;
            }
            else
            { ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Enter All Details in the  table.');", true); }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('ERROR SAVING THE DATA, PLEASE CONTACT ADMINISTRATOR.');", true);
        }
    }
    protected void CLEARPAGE_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/Weaker_Section.aspx");
    }




    protected void Weaker_Section_TEMPGrid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {

            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.Weaker_Section_TEMPGrid.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12
                    || i == 13 || i == 14 || i == 15 || i == 16 || i == 17 || i == 18
                    || i == 19 || i == 20 || i == 21 || i == 22 || i == 23 || i == 24
                    || i == 25 || i == 26 || i == 27 || i == 28 || i == 29 || i == 30
                    || i == 31 || i == 32 || i == 33 || i == 34 || i == 35)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }


            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Total no of Plots";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 5;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Total no of Plots Mandated";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 6;
            gvHeaderRowCopy.Cells.AddAt(8, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Total no of Plots Allotted";
            tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage2.ColumnSpan = 6;
            gvHeaderRowCopy.Cells.AddAt(9, tcMergePackage2);

            TableCell tcMergePackage4 = new TableCell();
            tcMergePackage4.Text = "Total no of Plots Vacant";
            tcMergePackage4.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage4.ColumnSpan = 6;
            gvHeaderRowCopy.Cells.AddAt(10, tcMergePackage4);

            TableCell tcMergePackage5 = new TableCell();
            tcMergePackage5.Text = "Total no of Plots Allotable";
            tcMergePackage5.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage5.ColumnSpan = 6;
            gvHeaderRowCopy.Cells.AddAt(11, tcMergePackage5);

        }

    }
}
