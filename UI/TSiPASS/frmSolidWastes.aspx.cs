using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmSolidWastes : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    PCBClass objPCB = new PCBClass();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    static DataTable dtMyTable;
    DataRow dtr;
    static DataTable dtMyTablepr;
    static DataTable dtMyTableCertificate;
    List<HazardousWastePCB> lsthazardousVo = new List<HazardousWastePCB>();
    List<NonHazardousWastePCB> lstnonhazardousVo = new List<NonHazardousWastePCB>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            // TxtBuilt_up_Area.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

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

            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque7(Session["Applid"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatus(Session["Applid"].ToString());

                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    //ResetFormControl(this);
                }

            }
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();

            dsnew = Gen.getdataofidentity(Session["Applid"].ToString(), "1");

            if (dsnew.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {
                    Response.Redirect("frmLabourDetails_New.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                }
                else
                {
                    Response.Redirect("frmWaterDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                }
            }
        }

        //if (Request.QueryString["intApplicationId"] != null)
        //{
        //    hdfFlagID0.Value = Request.QueryString["intApplicationId"];

        if (!IsPostBack)
        {
            gvHazardous.DataSource = BindHazardousDetailsGrid();
            gvHazardous.DataBind();

            gvNonHazardous.DataSource = BindNonHazardousDetailsGrid();
            gvNonHazardous.DataBind();
        }
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            //ddlPurposeDischargeWater
            //ddlModeofFinalDischarge
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];
            FillDetails();

        }
    }
    void FillDetails()
    {
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();
        try
        {
            ds = objPCB.GetHazardousDetailsPCB(hdfFlagID0.Value.ToString());

            if (ds != null && ds.Tables.Count >= 0 && ds.Tables[0].Rows.Count > 0)
            {
                string Activity = ds.Tables[0].Rows[0]["Activity"].ToString().Trim();
                if (Activity != null && Activity != "")
                {
                    string[] values = Activity.Split(',');
                    for (int i = 0; i < values.Length; i++)
                    {
                        for (int j = 0; j < chkActivity.Items.Count; j++)
                        {
                            if (chkActivity.Items[j].Value == values[i].Trim())
                            {
                                chkActivity.Items[j].Selected = true;
                            }
                        }
                    }
                }
                ViewState["dtHazardous"] = ds.Tables[0];
                gvHazardous.DataSource = ds.Tables[0];
                gvHazardous.DataBind();
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                ViewState["dtNonHazardous"] = ds.Tables[1];
                gvNonHazardous.DataSource = ds.Tables[1];
                gvNonHazardous.DataBind();
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
    protected void gvHazardous_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtHazardous"];
                DropDownList ddlSchedule = (DropDownList)gvr.FindControl("ddlSchedule");
                DropDownList ddlUnit = (DropDownList)gvr.FindControl("ddlUnit");
                BindUnits(ddlUnit);

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        ddlSchedule.SelectedValue = dt.Rows[e.Row.RowIndex]["Schedule"].ToString();
                        //ddlSchedule_SelectedIndexChanged(this, EventArgs.Empty);

                        DropDownList ddlProcess = (DropDownList)gvr.FindControl("ddlProcess");
                        BindHazardousProcessPCB(ddlProcess, ddlSchedule);
                        ddlProcess.SelectedValue = dt.Rows[e.Row.RowIndex]["Process"].ToString();
                        //ddlProcess_SelectedIndexChanged(this, EventArgs.Empty);

                        DropDownList ddlHazardousWaste = (DropDownList)gvr.FindControl("ddlHazardousWaste");
                        BindHazardousNamePCB(ddlProcess, ddlHazardousWaste);
                        ddlHazardousWaste.SelectedValue = dt.Rows[e.Row.RowIndex]["HazardousName"].ToString();

                        TextBox txtHazardousDesc = (TextBox)gvr.FindControl("txtHazardousDesc");
                        txtHazardousDesc.Text = dt.Rows[e.Row.RowIndex]["HazardousDesc"].ToString();

                        TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                        txtQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();

                        ddlUnit.SelectedValue = dt.Rows[e.Row.RowIndex]["Unit"].ToString();

                        TextBox txtStorage = (TextBox)gvr.FindControl("txtStorage");
                        txtStorage.Text = dt.Rows[e.Row.RowIndex]["Storage"].ToString();

                        TextBox txtRecyle = (TextBox)gvr.FindControl("txtRecyle");
                        txtRecyle.Text = dt.Rows[e.Row.RowIndex]["Recycle"].ToString();

                        TextBox txtDisposal = (TextBox)gvr.FindControl("txtDisposal");
                        txtDisposal.Text = dt.Rows[e.Row.RowIndex]["Disposal"].ToString();

                        TextBox txtExisting = (TextBox)gvr.FindControl("txtExisting");
                        txtExisting.Text = dt.Rows[e.Row.RowIndex]["Existing"].ToString();

                        TextBox txtProposed = (TextBox)gvr.FindControl("txtProposed");
                        txtProposed.Text = dt.Rows[e.Row.RowIndex]["Proposed"].ToString();

                        TextBox txtTotalAfter = (TextBox)gvr.FindControl("txtTotalAfter");
                        txtTotalAfter.Text = dt.Rows[e.Row.RowIndex]["Total"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
            Failure.Visible = true;
        }
    }
    protected void gvHazardous_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindHazardousDetailsGrid();
                String[] arraydata = new String[12];

                int gvrcnt = gvHazardous.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvHazardous.Rows[i];

                    DropDownList ddlSchedule = (DropDownList)gvr.FindControl("ddlSchedule");
                    arraydata[0] = ddlSchedule.SelectedValue;

                    DropDownList ddlProcess = (DropDownList)gvr.FindControl("ddlProcess");
                    arraydata[1] = ddlProcess.SelectedValue;

                    DropDownList ddlHazardousWaste = (DropDownList)gvr.FindControl("ddlHazardousWaste");
                    arraydata[2] = ddlHazardousWaste.SelectedValue;

                    TextBox txtHazardousDesc = (TextBox)gvr.FindControl("txtHazardousDesc");
                    arraydata[3] = txtHazardousDesc.Text;

                    TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                    arraydata[4] = txtQuantity.Text;

                    DropDownList ddlUnit = (DropDownList)gvr.FindControl("ddlUnit");
                    arraydata[5] = ddlUnit.SelectedValue;

                    TextBox txtStorage = (TextBox)gvr.FindControl("txtStorage");
                    arraydata[6] = txtStorage.Text;

                    TextBox txtRecyle = (TextBox)gvr.FindControl("txtRecyle");
                    arraydata[7] = txtRecyle.Text;

                    TextBox txtDisposal = (TextBox)gvr.FindControl("txtDisposal");
                    arraydata[8] = txtDisposal.Text;

                    TextBox txtExisting = (TextBox)gvr.FindControl("txtExisting");
                    arraydata[9] = txtExisting.Text;

                    TextBox txtProposed = (TextBox)gvr.FindControl("txtProposed");
                    arraydata[10] = txtProposed.Text;

                    TextBox txtTotalAfter = (TextBox)gvr.FindControl("txtTotalAfter");
                    arraydata[11] = txtTotalAfter.Text;


                    if (ddlProcess.SelectedValue == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please select Process Details";
                        lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                    }
                    if (valid == 0)
                    {
                        dt.Rows[i].ItemArray = arraydata;
                        DataRow dRow;
                        dRow = null;
                        dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }
                }

                if (valid == 0)
                {
                    ViewState["dtHazardous"] = dt;
                    gvHazardous.DataSource = dt;
                    gvHazardous.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvHazardous.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindHazardousDetailsGrid();
                    String[] arraydata = new String[12];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvHazardous.Rows[i];

                            DropDownList ddlSchedule = (DropDownList)gvr.FindControl("ddlSchedule");
                            arraydata[0] = ddlSchedule.SelectedValue;

                            DropDownList ddlProcess = (DropDownList)gvr.FindControl("ddlProcess");
                            arraydata[1] = ddlProcess.SelectedValue;

                            DropDownList ddlHazardousWaste = (DropDownList)gvr.FindControl("ddlHazardousWaste");
                            arraydata[2] = ddlHazardousWaste.SelectedValue;

                            TextBox txtHazardousDesc = (TextBox)gvr.FindControl("txtHazardousDesc");
                            arraydata[3] = txtHazardousDesc.Text;

                            TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                            arraydata[4] = txtQuantity.Text;

                            DropDownList ddlUnit = (DropDownList)gvr.FindControl("ddlUnit");
                            arraydata[5] = ddlUnit.SelectedValue;

                            TextBox txtStorage = (TextBox)gvr.FindControl("txtStorage");
                            arraydata[6] = txtStorage.Text;

                            TextBox txtRecyle = (TextBox)gvr.FindControl("txtRecyle");
                            arraydata[7] = txtRecyle.Text;

                            TextBox txtDisposal = (TextBox)gvr.FindControl("txtDisposal");
                            arraydata[8] = txtDisposal.Text;

                            TextBox txtExisting = (TextBox)gvr.FindControl("txtExisting");
                            arraydata[9] = txtExisting.Text;

                            TextBox txtProposed = (TextBox)gvr.FindControl("txtProposed");
                            arraydata[10] = txtProposed.Text;

                            TextBox txtTotalAfter = (TextBox)gvr.FindControl("txtTotalAfter");
                            arraydata[11] = txtTotalAfter.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtHazardous"] = dt;
                    gvHazardous.DataSource = dt;
                    gvHazardous.DataBind();
                }
                else
                {
                    dt = BindHazardousDetailsGrid();
                    ViewState["dtHazardous"] = dt;
                    gvHazardous.DataSource = dt;
                    gvHazardous.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvNonHazardous_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtNonHazardous"];
                DropDownList ddlNHUnit = (DropDownList)gvr.FindControl("ddlNHUnit");
                BindUnits(ddlNHUnit);

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtNHDescription = (TextBox)gvr.FindControl("txtNHDescription");
                        txtNHDescription.Text = dt.Rows[e.Row.RowIndex]["Description"].ToString();

                        TextBox txtNHQuantity = (TextBox)gvr.FindControl("txtNHQuantity");
                        txtNHQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();

                        ddlNHUnit.SelectedValue = dt.Rows[e.Row.RowIndex]["Unit"].ToString();

                        TextBox txtNHDisposal = (TextBox)gvr.FindControl("txtNHDisposal");
                        txtNHDisposal.Text = dt.Rows[e.Row.RowIndex]["Disposal"].ToString();

                        TextBox txtNHExisting = (TextBox)gvr.FindControl("txtNHExisting");
                        txtNHExisting.Text = dt.Rows[e.Row.RowIndex]["Existing"].ToString();

                        TextBox txtNHProposed = (TextBox)gvr.FindControl("txtNHProposed");
                        txtNHProposed.Text = dt.Rows[e.Row.RowIndex]["Proposed"].ToString();

                        TextBox txtNHTotalAfter = (TextBox)gvr.FindControl("txtNHTotalAfter");
                        txtNHTotalAfter.Text = dt.Rows[e.Row.RowIndex]["Total"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
            Failure.Visible = true;
        }
    }
    protected void gvNonHazardous_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindNonHazardousDetailsGrid();
                String[] arraydata = new String[7];

                int gvrcnt = gvNonHazardous.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvNonHazardous.Rows[i];

                    TextBox txtNHDescription = (TextBox)gvr.FindControl("txtNHDescription");
                    arraydata[0] = txtNHDescription.Text;

                    TextBox txtNHQuantity = (TextBox)gvr.FindControl("txtNHQuantity");
                    arraydata[1] = txtNHQuantity.Text;

                    DropDownList ddlNHUnit = (DropDownList)gvr.FindControl("ddlNHUnit");
                    arraydata[2] = ddlNHUnit.SelectedValue;

                    TextBox txtNHDisposal = (TextBox)gvr.FindControl("txtNHDisposal");
                    arraydata[3] = txtNHDisposal.Text;

                    TextBox txtNHExisting = (TextBox)gvr.FindControl("txtNHExisting");
                    arraydata[4] = txtNHExisting.Text;

                    TextBox txtNHProposed = (TextBox)gvr.FindControl("txtNHProposed");
                    arraydata[5] = txtNHProposed.Text;

                    TextBox txtNHTotalAfter = (TextBox)gvr.FindControl("txtNHTotalAfter");
                    arraydata[6] = txtNHTotalAfter.Text;


                    if (txtNHDescription.Text == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please select Description";
                        lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                    }
                    if (valid == 0)
                    {
                        dt.Rows[i].ItemArray = arraydata;
                        DataRow dRow;
                        dRow = null;
                        dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }
                }

                if (valid == 0)
                {
                    ViewState["dtNonHazardous"] = dt;
                    gvNonHazardous.DataSource = dt;
                    gvNonHazardous.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvNonHazardous.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindNonHazardousDetailsGrid();
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvNonHazardous.Rows[i];

                            TextBox txtNHDescription = (TextBox)gvr.FindControl("txtNHDescription");
                            arraydata[0] = txtNHDescription.Text;

                            TextBox txtNHQuantity = (TextBox)gvr.FindControl("txtNHQuantity");
                            arraydata[1] = txtNHQuantity.Text;

                            DropDownList ddlNHUnit = (DropDownList)gvr.FindControl("ddlNHUnit");
                            arraydata[2] = ddlNHUnit.SelectedValue;

                            TextBox txtNHDisposal = (TextBox)gvr.FindControl("txtNHDisposal");
                            arraydata[3] = txtNHDisposal.Text;

                            TextBox txtNHExisting = (TextBox)gvr.FindControl("txtNHExisting");
                            arraydata[4] = txtNHExisting.Text;

                            TextBox txtNHProposed = (TextBox)gvr.FindControl("txtNHProposed");
                            arraydata[5] = txtNHProposed.Text;

                            TextBox txtNHTotalAfter = (TextBox)gvr.FindControl("txtNHTotalAfter");
                            arraydata[6] = txtNHTotalAfter.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtNonHazardous"] = dt;
                    gvNonHazardous.DataSource = dt;
                    gvNonHazardous.DataBind();
                }
                else
                {

                    dt = BindNonHazardousDetailsGrid();
                    ViewState["dtNonHazardous"] = dt;
                    gvNonHazardous.DataSource = dt;
                    gvNonHazardous.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    private DataTable BindHazardousDetailsGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Schedule");
        dt.Columns.Add("Process");
        dt.Columns.Add("HazardousName");
        dt.Columns.Add("HazardousDesc");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Unit");
        dt.Columns.Add("Storage");
        dt.Columns.Add("Recycle");
        dt.Columns.Add("Disposal");
        dt.Columns.Add("Existing");
        dt.Columns.Add("Proposed");
        dt.Columns.Add("Total");

        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
        dr[6] = "";
        dr[7] = "";
        dr[8] = "";
        dr[9] = "";
        dr[10] = "";
        dr[11] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindNonHazardousDetailsGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Description");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Unit");
        dt.Columns.Add("Disposal");
        dt.Columns.Add("Existing");
        dt.Columns.Add("Proposed");
        dt.Columns.Add("Total");

        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
        dr[6] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    protected void ddlProcess_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)((DropDownList)sender).Parent.Parent;
        DropDownList ddlHazardousProcess = (DropDownList)gvrow.FindControl("ddlProcess");
        DropDownList ddlHazardousWaste = (DropDownList)gvrow.FindControl("ddlHazardousWaste");
        BindHazardousNamePCB(ddlHazardousProcess, ddlHazardousWaste);

    }

    private void BindHazardousNamePCB(DropDownList ddlHazardousProcess, DropDownList ddlHazardousWaste)
    {
        DataSet dsWaste = new DataSet();
        dsWaste = objPCB.GetHazardousNamePCB(ddlHazardousProcess.SelectedValue.ToString());
        if (dsWaste != null && dsWaste.Tables.Count > 0 && dsWaste.Tables[0].Rows.Count > 0)
        {
            ddlHazardousWaste.DataSource = dsWaste.Tables[0];
            ddlHazardousWaste.DataTextField = "HazarName_Desc";
            ddlHazardousWaste.DataValueField = "HazarNameId";
            ddlHazardousWaste.DataBind();
        }
    }
    protected void ddlSchedule_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)((DropDownList)sender).Parent.Parent;
        DropDownList ddlSchedule = (DropDownList)gvrow.FindControl("ddlSchedule");
        DropDownList ddlProcess = (DropDownList)gvrow.FindControl("ddlProcess");
        DataSet dsProcess = new DataSet();
        BindHazardousProcessPCB(ddlProcess, ddlSchedule);

    }

    private void BindHazardousProcessPCB(DropDownList ddlProcess, DropDownList ddlSchedule)
    {
        DataSet dsProcess = new DataSet();
        dsProcess = objPCB.GetHazardousProcessPCB(ddlSchedule.SelectedValue.ToString());
        if (dsProcess != null && dsProcess.Tables.Count > 0 && dsProcess.Tables[0].Rows.Count > 0)
        {
            ddlProcess.DataSource = dsProcess.Tables[0];
            ddlProcess.DataTextField = "HazarProcess_Desc";
            ddlProcess.DataValueField = "HazarProcessId";
            ddlProcess.DataBind();
        }
    }
    private void BindUnits(DropDownList ddlOtherCharUnits)
    {
        DataSet dsUnits = new DataSet();
        dsUnits = objPCB.GETUnitsPCB();

        if (dsUnits != null && dsUnits.Tables.Count > 0 && dsUnits.Tables[0].Rows.Count > 0)
        {
            ddlOtherCharUnits.DataSource = dsUnits.Tables[0];
            ddlOtherCharUnits.DataTextField = "Unit_Desc";
            ddlOtherCharUnits.DataValueField = "UnitID";
            ddlOtherCharUnits.DataBind();
        }
    }
    protected void btnSaveHazardousDtls_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            HazardousWastePCB HazrdousWasteVo = new HazardousWastePCB();
            string Activity = "";

            for (int i = 0; i < chkActivity.Items.Count; i++)
            {
                if (chkActivity.Items[i].Selected == true)
                {
                    if (Activity == "")
                        Activity = chkActivity.Items[i].Value;
                    else
                        Activity += "," + chkActivity.Items[i].Value;
                }
            }
            HazrdousWasteVo.Activity = Activity.ToString();

            foreach (GridViewRow gvrow in gvHazardous.Rows)
            {
                DropDownList ddlSchedule = (DropDownList)gvrow.FindControl("ddlSchedule");
                DropDownList ddlProcess = (DropDownList)gvrow.FindControl("ddlProcess");
                DropDownList ddlHazardousWaste = (DropDownList)gvrow.FindControl("ddlHazardousWaste");
                TextBox txtHazardousDesc = (TextBox)gvrow.FindControl("txtHazardousDesc");
                TextBox txtQuantity = (TextBox)gvrow.FindControl("txtQuantity");
                DropDownList ddlUnit = (DropDownList)gvrow.FindControl("ddlUnit");
                TextBox txtStorage = (TextBox)gvrow.FindControl("txtStorage");
                TextBox txtRecyle = (TextBox)gvrow.FindControl("txtRecyle");
                TextBox txtDisposal = (TextBox)gvrow.FindControl("txtDisposal");
                TextBox txtExisting = (TextBox)gvrow.FindControl("txtExisting");
                TextBox txtProposed = (TextBox)gvrow.FindControl("txtProposed");
                TextBox txtTotalAfter = (TextBox)gvrow.FindControl("txtTotalAfter");

                HazrdousWasteVo.Schedule = ddlSchedule.SelectedValue.ToString();
                HazrdousWasteVo.Process = ddlProcess.SelectedValue.ToString();
                HazrdousWasteVo.HazardousName = ddlHazardousWaste.SelectedValue.ToString();
                HazrdousWasteVo.HazardousDesc = txtHazardousDesc.Text.ToString();
                HazrdousWasteVo.Quantity = txtQuantity.Text.ToString();
                HazrdousWasteVo.Unit = ddlUnit.SelectedValue.ToString();
                HazrdousWasteVo.Storage = txtStorage.Text.ToString();
                HazrdousWasteVo.Recycle = txtRecyle.Text.ToString();
                HazrdousWasteVo.Disposal = txtDisposal.Text.ToString();
                HazrdousWasteVo.Existing = txtExisting.Text.ToString();
                HazrdousWasteVo.Proposed = txtProposed.Text.ToString();
                HazrdousWasteVo.Total = txtTotalAfter.Text.ToString();

                lsthazardousVo.Add(HazrdousWasteVo);
            }

            string Created_By = Session["uid"].ToString();
            int valid = objPCB.InsertHazardousDetails(Created_By, QuestionnaireId, lsthazardousVo);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                Label1.Text = "Hazardous Details Saved Successfully";
                btnSaveHazardousDtls.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
    protected void btnSaveNonHazardousDtls_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            foreach (GridViewRow gvrow in gvNonHazardous.Rows)
            {
                NonHazardousWastePCB NonHazardousVo = new NonHazardousWastePCB();

                TextBox txtNHDescription = (TextBox)gvrow.FindControl("txtNHDescription");
                TextBox txtNHQuantity = (TextBox)gvrow.FindControl("txtNHQuantity");
                DropDownList ddlNHUnit = (DropDownList)gvrow.FindControl("ddlNHUnit");
                TextBox txtNHDisposal = (TextBox)gvrow.FindControl("txtNHDisposal");
                TextBox txtNHExisting = (TextBox)gvrow.FindControl("txtNHExisting");
                TextBox txtNHProposed = (TextBox)gvrow.FindControl("txtNHProposed");
                TextBox txtNHTotalAfter = (TextBox)gvrow.FindControl("txtNHTotalAfter");

                NonHazardousVo.Description = txtNHDescription.Text.ToString();
                NonHazardousVo.Quantity = txtNHQuantity.Text.ToString();
                NonHazardousVo.Unit = ddlNHUnit.SelectedValue.ToString();
                NonHazardousVo.Disposal = txtNHDisposal.Text.ToString();
                NonHazardousVo.Existing = txtNHExisting.Text.ToString();
                NonHazardousVo.Proposed = txtNHProposed.Text.ToString();
                NonHazardousVo.Total = txtNHTotalAfter.Text.ToString();

                lstnonhazardousVo.Add(NonHazardousVo);
            }

            string Created_By = Session["uid"].ToString();
            int valid = objPCB.InsertNonHazardousDetails(Created_By, QuestionnaireId, lstnonhazardousVo);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                Label2.Text = "NonHazardous Details Saved Successfully";
                btnSaveHazardousDtls.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
}