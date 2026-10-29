using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmWCEffulent : System.Web.UI.Page
{
    DataTable dt = new DataTable();

    PCBClass objPCB = new PCBClass();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    //DataRow dtrdr;
    //DataTable myDtNewRecdr = new DataTable();

    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();

    static DataTable dtMyTable;

    DataRow dtr;
    static DataTable dtMyTablepr;
    static DataTable dtMyTableCertificate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        try
        {

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
                        ResetFormControl(this);
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
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];
            if (!IsPostBack)
            {
                gvWaterSourceDtls.DataSource = BindWaterSourceGrid();
                gvWaterSourceDtls.DataBind();

                gvWaterConsumption.DataSource = BindWaterConsumptionGrid();
                gvWaterConsumption.DataBind();

                gvWasteWaterDtls.DataSource = BindWasterWaterGrid();
                gvWasteWaterDtls.DataBind();

                gvToxic.DataSource = BindToxicSubstanceGrid();
                gvToxic.DataBind();

                gvFinalDischarge.DataSource = BindFinalDischargeGrid();
                gvFinalDischarge.DataBind();

                gvPhysicalChars.DataSource = BindPhysicalCharsGrid();
                gvPhysicalChars.DataBind();

                gvOtherCharacterstics.DataSource = BindOtherCharsGrid();
                gvOtherCharacterstics.DataBind();

                gvChemicalChars.DataSource = BindChemicalCharsGrid();
                gvChemicalChars.DataBind();

                // .DataSource = ();
                //.DataBind();

                // .DataSource = ();
                //.DataBind();

            }
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                //ddlPurposeDischargeWater
                //ddlModeofFinalDischarge
                FillDetails();

            }

            //}
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }


    public void ResetFormControl(Control parent)
    {
        try
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {

    }
    protected void gvWaterSourceDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtWaterSourceDtls"];
                DropDownList ddlSourceType = (DropDownList)gvr.FindControl("ddlSourceType");
                BindWaterSourceTypes(ddlSourceType);

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtSourceName = (TextBox)gvr.FindControl("txtSourceName");
                        txtSourceName.Text = dt.Rows[e.Row.RowIndex]["SourceName"].ToString();

                        TextBox txtSourceQuantity = (TextBox)gvr.FindControl("txtSourceQuantity");
                        txtSourceQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();
                        ddlSourceType.SelectedValue = dt.Rows[e.Row.RowIndex]["Source_Type"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvWaterSourceDtls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindWaterSourceGridAdd();
                String[] arraydata = new String[3];

                int gvrcnt = gvWaterSourceDtls.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvWaterSourceDtls.Rows[i];
                    DropDownList ddlSourceType = (DropDownList)gvr.FindControl("ddlSourceType");
                    arraydata[0] = ddlSourceType.SelectedValue;
                    TextBox txtSourceName = (TextBox)gvr.FindControl("txtSourceName");
                    arraydata[1] = txtSourceName.Text;

                    TextBox txtSourceQuantity = (TextBox)gvr.FindControl("txtSourceQuantity");
                    arraydata[2] = txtSourceQuantity.Text;

                    if (txtSourceName.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Water Source Details";
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
                    ViewState["dtWaterSourceDtls"] = dt;
                    gvWaterSourceDtls.DataSource = dt;
                    gvWaterSourceDtls.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvWaterSourceDtls.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindWaterSourceGridAdd();
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvWaterSourceDtls.Rows[i];
                            DropDownList ddlSourceType = (DropDownList)gvr.FindControl("ddlSourceType");
                            arraydata[0] = ddlSourceType.SelectedValue;
                            TextBox txtSourceName = (TextBox)gvr.FindControl("txtSourceName");
                            arraydata[1] = txtSourceName.Text;

                            TextBox txtSourceQuantity = (TextBox)gvr.FindControl("txtSourceQuantity");
                            arraydata[2] = txtSourceQuantity.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);

                    ViewState["dtWaterSourceDtls"] = dt;
                    gvWaterSourceDtls.DataSource = dt;
                    gvWaterSourceDtls.DataBind();
                }
                else
                {
                    dt = BindWaterSourceGridAdd();
                    ViewState["dtWaterSourceDtls"] = dt;
                    gvWaterSourceDtls.DataSource = dt;
                    gvWaterSourceDtls.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    private DataTable BindWaterSourceGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Source_Type");

        DataRow dr = dt.NewRow();
        dr[0] = "";


        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindWaterSourceGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Source_Type");
        dt.Columns.Add("SourceName");
        dt.Columns.Add("Quantity");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindWaterConsumptionGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Purpose");

        DataRow dr = dt.NewRow();
        dr[0] = "";


        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindWaterConsumptionGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Purpose");
        dt.Columns.Add("Quantity");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindWasterWaterGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Source");

        DataRow dr = dt.NewRow();
        dr[0] = "";


        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindWasterWaterGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Source");
        dt.Columns.Add("Quantity");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindToxicSubstanceGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Source");

        DataRow dr = dt.NewRow();
        dr[0] = "";


        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindToxicSubstanceGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Source");
        dt.Columns.Add("Substance");
        dt.Columns.Add("Name");
        dt.Columns.Add("Quantity");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindFinalDischargeGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("FSource");

        DataRow dr = dt.NewRow();
        dr[0] = "";


        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindFinalDischargeGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("FSource");
        dt.Columns.Add("PointofDischarge");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindPhysicalCharsGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("PCSource");

        DataRow dr = dt.NewRow();
        dr[0] = "";


        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindPhysicalCharsGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("PCSource");
        dt.Columns.Add("Temprature");
        dt.Columns.Add("PH");
        dt.Columns.Add("Colour");
        dt.Columns.Add("Turbidity");
        dt.Columns.Add("Odour");
        dt.Columns.Add("TotalSolids");
        dt.Columns.Add("SuspendedSolids");
        dt.Columns.Add("VolatileSolids");

        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
        dr[6] = "";
        dr[7] = "";
        dr[8] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindOtherCharsGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("OSource");

        DataRow dr = dt.NewRow();
        dr[0] = "";


        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindOtherCharsGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("OSource");
        dt.Columns.Add("Item");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Units");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dt.Rows.Add(dr);
        return dt;
    }
    protected void gvWaterConsumption_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtWaterConsumptionDtls"];
                DropDownList ddlWaterConsumpPurpose = (DropDownList)gvr.FindControl("ddlWaterConsumpPurpose");
                BindWaterConsumptionPurpose(ddlWaterConsumpPurpose);

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtWaterQuantity = (TextBox)gvr.FindControl("txtWaterQuantity");
                        txtWaterQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();
                        ddlWaterConsumpPurpose.SelectedValue = dt.Rows[e.Row.RowIndex]["Purpose"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvWaterConsumption_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindWaterConsumptionGridAdd();
                String[] arraydata = new String[2];

                int gvrcnt = gvWaterConsumption.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvWaterConsumption.Rows[i];
                    DropDownList ddlWaterConsumpPurpose = (DropDownList)gvr.FindControl("ddlWaterConsumpPurpose");
                    arraydata[0] = ddlWaterConsumpPurpose.SelectedValue;

                    TextBox txtWaterQuantity = (TextBox)gvr.FindControl("txtWaterQuantity");
                    arraydata[1] = txtWaterQuantity.Text;

                    if (txtWaterQuantity.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Water Consuption Details";
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
                    ViewState["dtWaterConsumptionDtls"] = dt;
                    gvWaterConsumption.DataSource = dt;
                    gvWaterConsumption.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvWaterConsumption.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindWaterConsumptionGridAdd();
                    String[] arraydata = new String[2];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvWaterConsumption.Rows[i];
                            DropDownList ddlWaterConsumpPurpose = (DropDownList)gvr.FindControl("ddlWaterConsumpPurpose");
                            arraydata[0] = ddlWaterConsumpPurpose.SelectedValue;

                            TextBox txtWaterQuantity = (TextBox)gvr.FindControl("txtWaterQuantity");
                            arraydata[1] = txtWaterQuantity.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtWaterConsumptionDtls"] = dt;
                    gvWaterConsumption.DataSource = dt;
                    gvWaterConsumption.DataBind();
                }
                else
                {
                    dt = BindWaterConsumptionGridAdd();
                    ViewState["dtWaterConsumptionDtls"] = dt;
                    gvWaterConsumption.DataSource = dt;
                    gvWaterConsumption.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvWasteWaterDtls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindWasterWaterGridAdd();
                String[] arraydata = new String[2];

                int gvrcnt = gvWasteWaterDtls.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {
                    GridViewRow gvr = gvWasteWaterDtls.Rows[i];
                    DropDownList ddlWasteWaterSource = (DropDownList)gvr.FindControl("ddlWasteWaterSource");
                    arraydata[0] = ddlWasteWaterSource.SelectedValue;

                    TextBox txtWasteWaterQuantity = (TextBox)gvr.FindControl("txtWasteWaterQuantity");
                    arraydata[1] = txtWasteWaterQuantity.Text;

                    if (txtWasteWaterQuantity.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Waste water quantity";
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
                    ViewState["dtWasteWaterDtls"] = dt;
                    gvWasteWaterDtls.DataSource = dt;
                    gvWasteWaterDtls.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvWasteWaterDtls.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindWasterWaterGridAdd();
                    String[] arraydata = new String[2];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvWasteWaterDtls.Rows[i];
                            DropDownList ddlWasteWaterSource = (DropDownList)gvr.FindControl("ddlWasteWaterSource");
                            arraydata[0] = ddlWasteWaterSource.SelectedValue;

                            TextBox txtWasteWaterQuantity = (TextBox)gvr.FindControl("txtWasteWaterQuantity");
                            arraydata[1] = txtWasteWaterQuantity.Text;


                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtWasteWaterDtls"] = dt;
                    gvWasteWaterDtls.DataSource = dt;
                    gvWasteWaterDtls.DataBind();
                }
                else
                {
                    dt = BindWasterWaterGridAdd();
                    ViewState["dtWasteWaterDtls"] = dt;
                    gvWasteWaterDtls.DataSource = dt;
                    gvWasteWaterDtls.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvWasteWaterDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtWasteWaterDtls"];
                DropDownList ddlWasteWaterSource = (DropDownList)gvr.FindControl("ddlWasteWaterSource");
                BindWasteWaterDischargeType(ddlWasteWaterSource);

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        ddlWasteWaterSource.SelectedValue = dt.Rows[e.Row.RowIndex]["Source"].ToString();

                        TextBox txtWasteWaterQuantity = (TextBox)gvr.FindControl("txtWasteWaterQuantity");
                        txtWasteWaterQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvToxic_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtToxicDtls"];
                DropDownList ddlToxicSource = (DropDownList)gvr.FindControl("ddlToxicSource");
                DropDownList ddlToxicSubstance = (DropDownList)gvr.FindControl("ddlToxicSubstance");
                BindWasteWaterSource(ddlToxicSource);
                BindToxicSubstance(ddlToxicSubstance);
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtToxicName = (TextBox)gvr.FindControl("txtToxicName");
                        TextBox txtToxicQuantity = (TextBox)gvr.FindControl("txtToxicQuantity");
                        txtToxicName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        txtToxicQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();
                        ddlToxicSource.SelectedValue = dt.Rows[e.Row.RowIndex]["Source"].ToString();
                        ddlToxicSubstance.SelectedValue = dt.Rows[e.Row.RowIndex]["Substance"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }


    protected void gvToxic_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindToxicSubstanceGridAdd();
                String[] arraydata = new String[4];

                int gvrcnt = gvToxic.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvToxic.Rows[i];
                    DropDownList ddlToxicSource = (DropDownList)gvr.FindControl("ddlToxicSource");
                    arraydata[0] = ddlToxicSource.Text;

                    DropDownList ddlToxicSubstance = (DropDownList)gvr.FindControl("ddlToxicSubstance");
                    arraydata[1] = ddlToxicSubstance.Text;

                    TextBox txtToxicName = (TextBox)gvr.FindControl("txtToxicName");
                    arraydata[2] = txtToxicName.Text;

                    TextBox txtToxicQuantity = (TextBox)gvr.FindControl("txtToxicQuantity");
                    arraydata[3] = txtToxicQuantity.Text;

                    if (txtToxicName.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Toxic Name";
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
                    ViewState["dtToxicDtls"] = dt;
                    gvToxic.DataSource = dt;
                    gvToxic.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvToxic.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindToxicSubstanceGridAdd();
                    String[] arraydata = new String[4];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvToxic.Rows[i];
                            DropDownList ddlToxicSource = (DropDownList)gvr.FindControl("ddlToxicSource");
                            arraydata[0] = ddlToxicSource.Text;

                            DropDownList ddlToxicSubstance = (DropDownList)gvr.FindControl("ddlToxicSubstance");
                            arraydata[1] = ddlToxicSubstance.Text;

                            TextBox txtToxicName = (TextBox)gvr.FindControl("txtToxicName");
                            arraydata[2] = txtToxicName.Text;

                            TextBox txtToxicQuantity = (TextBox)gvr.FindControl("txtToxicQuantity");
                            arraydata[3] = txtToxicQuantity.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtToxicDtls"] = dt;
                    gvToxic.DataSource = dt;
                    gvToxic.DataBind();
                }
                else
                {
                    dt = BindToxicSubstanceGridAdd();
                    ViewState["dtToxicDtls"] = dt;
                    gvToxic.DataSource = dt;
                    gvToxic.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvFinalDischarge_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindFinalDischargeGridAdd();
                String[] arraydata = new String[2];

                int gvrcnt = gvFinalDischarge.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvFinalDischarge.Rows[i];
                    DropDownList ddlDischrgeSource = (DropDownList)gvr.FindControl("ddlDischrgeSource");
                    arraydata[0] = ddlDischrgeSource.SelectedValue;

                    DropDownList ddlPointofDischarge = (DropDownList)gvr.FindControl("ddlPointofDischarge");
                    arraydata[1] = ddlPointofDischarge.SelectedValue;

                    if (ddlDischrgeSource.SelectedValue == "0")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please select Discharge source";
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
                    ViewState["dtFinalDischargeDtls"] = dt;
                    gvFinalDischarge.DataSource = dt;
                    gvFinalDischarge.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvFinalDischarge.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindFinalDischargeGridAdd();
                    String[] arraydata = new String[2];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvFinalDischarge.Rows[i];
                            DropDownList ddlDischrgeSource = (DropDownList)gvr.FindControl("ddlDischrgeSource");
                            arraydata[0] = ddlDischrgeSource.SelectedValue;

                            DropDownList ddlPointofDischarge = (DropDownList)gvr.FindControl("ddlPointofDischarge");
                            arraydata[1] = ddlPointofDischarge.SelectedValue;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtFinalDischargeDtls"] = dt;
                    gvFinalDischarge.DataSource = dt;
                    gvFinalDischarge.DataBind();
                }
                else
                {
                    dt = BindFinalDischargeGridAdd();
                    ViewState["dtFinalDischargeDtls"] = dt;
                    gvFinalDischarge.DataSource = dt;
                    gvFinalDischarge.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvFinalDischarge_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtFinalDischargeDtls"];
                DropDownList ddlDischrgeSource = (DropDownList)gvr.FindControl("ddlDischrgeSource");
                DropDownList ddlPointofDischarge = (DropDownList)gvr.FindControl("ddlPointofDischarge");
                BindWasteWaterSource(ddlDischrgeSource);
                BindPointofDischarge(ddlPointofDischarge);
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        ddlDischrgeSource.SelectedValue = dt.Rows[e.Row.RowIndex]["FSource"].ToString();
                        ddlPointofDischarge.SelectedValue = dt.Rows[e.Row.RowIndex]["PointofDischarge"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }


    protected void gvPhysicalChars_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindPhysicalCharsGridAdd();
                String[] arraydata = new String[9];

                int gvrcnt = gvPhysicalChars.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvPhysicalChars.Rows[i];
                    DropDownList ddlPhyCharSource = (DropDownList)gvr.FindControl("ddlPhyCharSource");
                    arraydata[0] = ddlPhyCharSource.SelectedValue;

                    TextBox txtPhyCharTemperature = (TextBox)gvr.FindControl("txtPhyCharTemperature");
                    arraydata[1] = txtPhyCharTemperature.Text;

                    TextBox txtPhyCharPH = (TextBox)gvr.FindControl("txtPhyCharPH");
                    arraydata[2] = txtPhyCharPH.Text;

                    TextBox txtPhyCharColour = (TextBox)gvr.FindControl("txtPhyCharColour");
                    arraydata[3] = txtPhyCharColour.Text;

                    TextBox txtPhyCharTurbidity = (TextBox)gvr.FindControl("txtPhyCharTurbidity");
                    arraydata[4] = txtPhyCharTurbidity.Text;

                    TextBox txtPhyCharOdour = (TextBox)gvr.FindControl("txtPhyCharOdour");
                    arraydata[5] = txtPhyCharOdour.Text;

                    TextBox txtPhyCharTotalSolids = (TextBox)gvr.FindControl("txtPhyCharTotalSolids");
                    arraydata[6] = txtPhyCharTotalSolids.Text;
                    TextBox txtPhyCharSuspendSolids = (TextBox)gvr.FindControl("txtPhyCharSuspendSolids");
                    arraydata[7] = txtPhyCharSuspendSolids.Text;
                    TextBox txtPhyCharVolatileSolids = (TextBox)gvr.FindControl("txtPhyCharVolatileSolids");
                    arraydata[8] = txtPhyCharVolatileSolids.Text;

                    if (ddlPhyCharSource.SelectedValue == "0" || ddlPhyCharSource.SelectedValue == "" || ddlPhyCharSource.SelectedValue == "--Select--")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Physical Characterstics Details";
                        lblmsg.CssClass = "errormsg";
                        Failure.Visible = true;
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
                    ViewState["dtPhysicalChars"] = dt;
                    gvPhysicalChars.DataSource = dt;
                    gvPhysicalChars.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvPhysicalChars.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindPhysicalCharsGridAdd();
                    String[] arraydata = new String[9];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvPhysicalChars.Rows[i];
                            DropDownList ddlPhyCharSource = (DropDownList)gvr.FindControl("ddlPhyCharSource");
                            arraydata[0] = ddlPhyCharSource.SelectedValue;

                            TextBox txtPhyCharTemperature = (TextBox)gvr.FindControl("txtPhyCharTemperature");
                            arraydata[1] = txtPhyCharTemperature.Text;

                            TextBox txtPhyCharPH = (TextBox)gvr.FindControl("txtPhyCharPH");
                            arraydata[2] = txtPhyCharPH.Text;

                            TextBox txtPhyCharColour = (TextBox)gvr.FindControl("txtPhyCharColour");
                            arraydata[3] = txtPhyCharColour.Text;

                            TextBox txtPhyCharTurbidity = (TextBox)gvr.FindControl("txtPhyCharTurbidity");
                            arraydata[4] = txtPhyCharTurbidity.Text;

                            TextBox txtPhyCharOdour = (TextBox)gvr.FindControl("txtPhyCharOdour");
                            arraydata[5] = txtPhyCharOdour.Text;

                            TextBox txtPhyCharTotalSolids = (TextBox)gvr.FindControl("txtPhyCharTotalSolids");
                            arraydata[6] = txtPhyCharTotalSolids.Text;
                            TextBox txtPhyCharSuspendSolids = (TextBox)gvr.FindControl("txtPhyCharSuspendSolids");
                            arraydata[7] = txtPhyCharSuspendSolids.Text;
                            TextBox txtPhyCharVolatileSolids = (TextBox)gvr.FindControl("txtPhyCharVolatileSolids");
                            arraydata[8] = txtPhyCharVolatileSolids.Text;


                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    dt.Rows.RemoveAt(i - 1);
                    ViewState["dtPhysicalChars"] = dt;
                    gvPhysicalChars.DataSource = dt;
                    gvPhysicalChars.DataBind();
                }
                else
                {
                    dt = BindPhysicalCharsGridAdd();
                    ViewState["dtPhysicalChars"] = dt;
                    gvPhysicalChars.DataSource = dt;
                    gvPhysicalChars.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvPhysicalChars_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtPhysicalChars"];
                DropDownList ddlPhyCharSource = (DropDownList)gvr.FindControl("ddlPhyCharSource");
                BindWasteWaterSource(ddlPhyCharSource);
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtPhyCharTemperature = (TextBox)gvr.FindControl("txtPhyCharTemperature");
                        TextBox txtPhyCharPH = (TextBox)gvr.FindControl("txtPhyCharPH");
                        TextBox txtPhyCharColour = (TextBox)gvr.FindControl("txtPhyCharColour");
                        TextBox txtPhyCharTurbidity = (TextBox)gvr.FindControl("txtPhyCharTurbidity");
                        TextBox txtPhyCharOdour = (TextBox)gvr.FindControl("txtPhyCharOdour");
                        TextBox txtPhyCharTotalSolids = (TextBox)gvr.FindControl("txtPhyCharTotalSolids");
                        TextBox txtPhyCharSuspendSolids = (TextBox)gvr.FindControl("txtPhyCharSuspendSolids");
                        TextBox txtPhyCharVolatileSolids = (TextBox)gvr.FindControl("txtPhyCharVolatileSolids");

                        ddlPhyCharSource.SelectedValue = dt.Rows[e.Row.RowIndex]["PCSource"].ToString();
                        txtPhyCharTemperature.Text = dt.Rows[e.Row.RowIndex]["Temprature"].ToString();
                        txtPhyCharPH.Text = dt.Rows[e.Row.RowIndex]["PH"].ToString();
                        txtPhyCharColour.Text = dt.Rows[e.Row.RowIndex]["Colour"].ToString();
                        txtPhyCharTurbidity.Text = dt.Rows[e.Row.RowIndex]["Turbidity"].ToString();
                        txtPhyCharOdour.Text = dt.Rows[e.Row.RowIndex]["Odour"].ToString();
                        txtPhyCharTotalSolids.Text = dt.Rows[e.Row.RowIndex]["TotalSolids"].ToString();
                        txtPhyCharSuspendSolids.Text = dt.Rows[e.Row.RowIndex]["SuspendedSolids"].ToString();
                        txtPhyCharVolatileSolids.Text = dt.Rows[e.Row.RowIndex]["VolatileSolids"].ToString();

                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }


    protected void gvOtherCharacterstics_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindOtherCharsGridAdd();
                String[] arraydata = new String[4];

                int gvrcnt = gvOtherCharacterstics.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvOtherCharacterstics.Rows[i];
                    DropDownList ddlOtherCharSource = (DropDownList)gvr.FindControl("ddlOtherCharSource");
                    arraydata[0] = ddlOtherCharSource.SelectedValue;

                    TextBox txtOtherCharItemName = (TextBox)gvr.FindControl("txtOtherCharItemName");
                    arraydata[1] = txtOtherCharItemName.Text;

                    TextBox txtOtherCharQuantity = (TextBox)gvr.FindControl("txtOtherCharQuantity");
                    arraydata[2] = txtOtherCharQuantity.Text;

                    DropDownList ddlOtherCharUnits = (DropDownList)gvr.FindControl("ddlOtherCharUnits");
                    arraydata[3] = ddlOtherCharUnits.SelectedValue;

                    if (txtOtherCharItemName.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Other Characterstics Details";
                        lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                    }
                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }
                if (valid == 0)
                {
                    ViewState["dtOtherCharDtls"] = dt;
                    gvOtherCharacterstics.DataSource = dt;
                    gvOtherCharacterstics.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvOtherCharacterstics.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindOtherCharsGridAdd();
                    String[] arraydata = new String[4];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvOtherCharacterstics.Rows[i];
                            DropDownList ddlOtherCharSource = (DropDownList)gvr.FindControl("ddlOtherCharSource");
                            arraydata[0] = ddlOtherCharSource.SelectedValue;

                            TextBox txtOtherCharItemName = (TextBox)gvr.FindControl("txtOtherCharItemName");
                            arraydata[1] = txtOtherCharItemName.Text;

                            TextBox txtOtherCharQuantity = (TextBox)gvr.FindControl("txtOtherCharQuantity");
                            arraydata[2] = txtOtherCharQuantity.Text;

                            DropDownList ddlOtherCharUnits = (DropDownList)gvr.FindControl("ddlOtherCharUnits");
                            arraydata[3] = ddlOtherCharUnits.SelectedValue;

                            //if (j == 0)
                            //    dt.Rows[i - 1].ItemArray = arraydata;
                            //else
                            //    dt.Rows[i].ItemArray = arraydata;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtOtherCharDtls"] = dt;
                    gvOtherCharacterstics.DataSource = dt;
                    gvOtherCharacterstics.DataBind();
                }
                else
                {
                    dt = BindOtherCharsGridAdd();
                    ViewState["dtOtherCharDtls"] = dt;
                    gvOtherCharacterstics.DataSource = dt;
                    gvOtherCharacterstics.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvOtherCharacterstics_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtOtherCharDtls"];
                DropDownList ddlOtherCharSource = (DropDownList)gvr.FindControl("ddlOtherCharSource");
                DropDownList ddlOtherCharUnits = (DropDownList)gvr.FindControl("ddlOtherCharUnits");

                BindWasteWaterSource(ddlOtherCharSource);
                BindUnits(ddlOtherCharUnits);
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtOtherCharItemName = (TextBox)gvr.FindControl("txtOtherCharItemName");
                        TextBox txtOtherCharQuantity = (TextBox)gvr.FindControl("txtOtherCharQuantity");
                        txtOtherCharItemName.Text = dt.Rows[e.Row.RowIndex]["Item"].ToString();
                        txtOtherCharQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();
                        ddlOtherCharSource.SelectedValue = dt.Rows[e.Row.RowIndex]["OSource"].ToString();
                        ddlOtherCharUnits.SelectedValue = dt.Rows[e.Row.RowIndex]["Units"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }

    private void BindUnits(DropDownList ddlOtherCharUnits)
    {
        DataSet dsUnits = new DataSet();
        dsUnits = objPCB.GETUnitsPCB();
        ddlOtherCharUnits.Items.Clear();
        if (dsUnits != null && dsUnits.Tables.Count > 0 && dsUnits.Tables[0].Rows.Count > 0)
        {
            ddlOtherCharUnits.DataSource = dsUnits.Tables[0];
            ddlOtherCharUnits.DataTextField = "Unit_Desc";
            ddlOtherCharUnits.DataValueField = "UnitID";
            ddlOtherCharUnits.DataBind();
        }
        ddlOtherCharUnits.Items.Insert(0, "--Select--");
    }
    private void BindWaterSourceTypes(DropDownList ddlWaterSource)
    {
        DataSet dsWaterSorce = new DataSet();
        dsWaterSorce = objPCB.GetWaterSorceTypePCB();
        if (dsWaterSorce != null && dsWaterSorce.Tables.Count > 0 && dsWaterSorce.Tables[0].Rows.Count > 0)
        {
            ddlWaterSource.DataSource = dsWaterSorce.Tables[0];
            ddlWaterSource.DataTextField = "WaterSource_Desc";
            ddlWaterSource.DataValueField = "WaterSourceId";
            ddlWaterSource.DataBind();
        }
    }
    private void BindWaterConsumptionPurpose(DropDownList ddlWaterConsumpPurpose)
    {
        DataSet dsWaterConsumptionPurpose = new DataSet();
        dsWaterConsumptionPurpose = objPCB.GetWaterConsumptionTypesPCB();

        if (dsWaterConsumptionPurpose != null && dsWaterConsumptionPurpose.Tables.Count > 0 && dsWaterConsumptionPurpose.Tables[0].Rows.Count > 0)
        {
            ddlWaterConsumpPurpose.DataSource = dsWaterConsumptionPurpose.Tables[0];
            ddlWaterConsumpPurpose.DataTextField = "WaterConsumption_Desc";
            ddlWaterConsumpPurpose.DataValueField = "WaterConsumptionId";
            ddlWaterConsumpPurpose.DataBind();
        }
    }
    private void BindWasteWaterDischargeType(DropDownList ddlWasteWaterSource)
    {
        DataSet dsWasteWatSource = new DataSet();
        dsWasteWatSource = objPCB.GetWaterDischargeTypePCB();

        if (dsWasteWatSource != null && dsWasteWatSource.Tables.Count > 0 && dsWasteWatSource.Tables[0].Rows.Count > 0)
        {
            ddlWasteWaterSource.DataSource = dsWasteWatSource.Tables[0];
            ddlWasteWaterSource.DataTextField = "WaterDischarge_Desc";
            ddlWasteWaterSource.DataValueField = "WaterDischargeId";
            ddlWasteWaterSource.DataBind();
        }
    }
    private void BindToxicSubstance(DropDownList ddlToxicSubstance)
    {
        DataSet dsToxicSubstance = new DataSet();
        dsToxicSubstance = objPCB.GetToxinPCB();
        if (dsToxicSubstance != null && dsToxicSubstance.Tables.Count > 0 && dsToxicSubstance.Tables[0].Rows.Count > 0)
        {
            ddlToxicSubstance.DataSource = dsToxicSubstance.Tables[0];
            ddlToxicSubstance.DataTextField = "Toxin_Desc";
            ddlToxicSubstance.DataValueField = "ToxinId";
            ddlToxicSubstance.DataBind();
        }

    }
    private void BindDischrgeSource(DropDownList ddlDischrgeSource)
    {
        //DataSet dsToxicSubstance = new DataSet();
        //dsToxicSubstance = objPCB.GetToxinPCB();
        //if (dsToxicSubstance != null && dsToxicSubstance.Tables.Count > 0 && dsToxicSubstance.Tables[0].Rows.Count > 0)
        //{
        //    ddlToxicSubstance.DataSource = dsToxicSubstance.Tables[0];
        //    ddlToxicSubstance.DataTextField = "WaterSource_Desc";
        //    ddlToxicSubstance.DataValueField = "WaterSourceId";
        //    ddlToxicSubstance.DataBind();
        //}
    }

    private void BindPointofDischarge(DropDownList ddlPointofDischarge)
    {
        DataSet dsPointofDischarge = new DataSet();
        dsPointofDischarge = objPCB.GetDischargePCB();
        if (dsPointofDischarge != null && dsPointofDischarge.Tables.Count > 0 && dsPointofDischarge.Tables[0].Rows.Count > 0)
        {
            ddlPointofDischarge.DataSource = dsPointofDischarge.Tables[0];
            ddlPointofDischarge.DataTextField = "Discharge_Desc";
            ddlPointofDischarge.DataValueField = "DischargeId";
            ddlPointofDischarge.DataBind();
        }
    }
    private void BindWasteWaterSource(DropDownList ddlPhyCharSource)
    {
        DataSet dsWasteWaterSource = new DataSet();
        dsWasteWaterSource = objPCB.GETWasteWaterSourcePCB(Session["Applid"].ToString());
        if (dsWasteWaterSource != null && dsWasteWaterSource.Tables.Count > 0 && dsWasteWaterSource.Tables[0].Rows.Count > 0)
        {
            ddlPhyCharSource.DataSource = dsWasteWaterSource.Tables[0];
            ddlPhyCharSource.DataTextField = "WaterDischarge_Desc";
            ddlPhyCharSource.DataValueField = "WaterDischargeId";
            ddlPhyCharSource.DataBind();
        }

    }

    void FillDetails()
    {
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();
        try
        {
            ds = Gen.getPCBDetails(hdfFlagID0.Value.ToString());

            if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            {
                ViewState["dtWaterSourceDtls"] = ds.Tables[4];
                gvWaterSourceDtls.DataSource = ds.Tables[4];
                gvWaterSourceDtls.DataBind();
            }
            if (ds != null && ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
            {
                ViewState["dtWaterConsumptionDtls"] = ds.Tables[5];
                gvWaterConsumption.DataSource = ds.Tables[5];
                gvWaterConsumption.DataBind();
            }
            if (ds != null && ds.Tables.Count > 6 && ds.Tables[6].Rows.Count > 0)
            {
                ViewState["dtWasteWaterDtls"] = ds.Tables[6];
                gvWasteWaterDtls.DataSource = ds.Tables[6];
                gvWasteWaterDtls.DataBind();
            }
            if (ds != null && ds.Tables.Count > 7 && ds.Tables[7].Rows.Count > 0)
            {
                ViewState["dtToxicDtls"] = ds.Tables[7];
                gvToxic.DataSource = ds.Tables[7];
                gvToxic.DataBind();
            }
            if (ds != null && ds.Tables.Count > 8 && ds.Tables[8].Rows.Count > 0)
            {
                ViewState["dtFinalDischargeDtls"] = ds.Tables[8];
                gvFinalDischarge.DataSource = ds.Tables[8];
                gvFinalDischarge.DataBind();
            }
            if (ds != null && ds.Tables.Count > 9 && ds.Tables[9].Rows.Count > 0)
            {

                ViewState["dtPhysicalChars"] = ds.Tables[9];

                gvPhysicalChars.DataSource = ds.Tables[9];
                gvPhysicalChars.DataBind();
            }
            if (ds != null && ds.Tables.Count > 10 && ds.Tables[10].Rows.Count > 0)
            {
                ViewState["dtChemicalChars"] = ds.Tables[10];

                gvChemicalChars.DataSource = ds.Tables[10];
                gvChemicalChars.DataBind();
            }
            if (ds != null && ds.Tables.Count > 11 && ds.Tables[11].Rows.Count > 0)
            {
                ViewState["dtOtherCharDtls"] = ds.Tables[11];

                gvOtherCharacterstics.DataSource = ds.Tables[11];
                gvOtherCharacterstics.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvChemicalChars_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtChemicalChars"];
                DropDownList ddlChemicalCharSource = (DropDownList)gvr.FindControl("ddlChemicalCharSource");
                BindWasteWaterSource(ddlChemicalCharSource);
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtAcidity = (TextBox)gvr.FindControl("txtAcidity");
                        TextBox txtAlkalinity = (TextBox)gvr.FindControl("txtAlkalinity");
                        TextBox txtHardness = (TextBox)gvr.FindControl("txtHardness");
                        TextBox txtBOD = (TextBox)gvr.FindControl("txtBOD");
                        TextBox txtCOD = (TextBox)gvr.FindControl("txtCOD");
                        TextBox txtOilGreases = (TextBox)gvr.FindControl("txtOilGreases");
                        TextBox txtTotalNitrogen = (TextBox)gvr.FindControl("txtTotalNitrogen");
                        TextBox txtSulphates = (TextBox)gvr.FindControl("txtSulphates");
                        TextBox txtPhosphate = (TextBox)gvr.FindControl("txtPhosphate");
                        TextBox txtChloride = (TextBox)gvr.FindControl("txtChloride");
                        TextBox txtSodium = (TextBox)gvr.FindControl("txtSodium");
                        TextBox txtPotassium = (TextBox)gvr.FindControl("txtPotassium");
                        TextBox txtCalcium = (TextBox)gvr.FindControl("txtCalcium");
                        TextBox txtMagnesium = (TextBox)gvr.FindControl("txtMagnesium");
                        ddlChemicalCharSource.SelectedValue = dt.Rows[e.Row.RowIndex]["Source"].ToString();
                        txtAcidity.Text = dt.Rows[e.Row.RowIndex]["Acidity"].ToString();
                        txtAlkalinity.Text = dt.Rows[e.Row.RowIndex]["Alkalinity"].ToString();
                        txtHardness.Text = dt.Rows[e.Row.RowIndex]["Hardness"].ToString();
                        txtBOD.Text = dt.Rows[e.Row.RowIndex]["BOD"].ToString();
                        txtCOD.Text = dt.Rows[e.Row.RowIndex]["COD"].ToString();
                        txtOilGreases.Text = dt.Rows[e.Row.RowIndex]["Oil_Greases"].ToString();
                        txtTotalNitrogen.Text = dt.Rows[e.Row.RowIndex]["Nitrogen_Phosphate"].ToString();
                        txtSulphates.Text = dt.Rows[e.Row.RowIndex]["Sulphates"].ToString();
                        txtPhosphate.Text = dt.Rows[e.Row.RowIndex]["Total_Phosphates"].ToString();
                        txtChloride.Text = dt.Rows[e.Row.RowIndex]["Total_Chloride"].ToString();
                        txtSodium.Text = dt.Rows[e.Row.RowIndex]["Sodium"].ToString();
                        txtPotassium.Text = dt.Rows[e.Row.RowIndex]["Potassium"].ToString();
                        txtCalcium.Text = dt.Rows[e.Row.RowIndex]["Calcium"].ToString();
                        txtMagnesium.Text = dt.Rows[e.Row.RowIndex]["Magnesium"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvChemicalChars_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindChemicalCharsGridAdd();
                String[] arraydata = new String[15];

                int gvrcnt = gvChemicalChars.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvChemicalChars.Rows[i];
                    DropDownList ddlChemicalCharSource = (DropDownList)gvr.FindControl("ddlChemicalCharSource");
                    arraydata[0] = ddlChemicalCharSource.SelectedValue;

                    TextBox txtAcidity = (TextBox)gvr.FindControl("txtAcidity");
                    arraydata[1] = txtAcidity.Text;
                    TextBox txtAlkalinity = (TextBox)gvr.FindControl("txtAlkalinity");
                    arraydata[2] = txtAlkalinity.Text;
                    TextBox txtHardness = (TextBox)gvr.FindControl("txtHardness");
                    arraydata[3] = txtHardness.Text;

                    TextBox txtBOD = (TextBox)gvr.FindControl("txtBOD");
                    arraydata[4] = txtBOD.Text;
                    TextBox txtCOD = (TextBox)gvr.FindControl("txtCOD");
                    arraydata[5] = txtCOD.Text;
                    TextBox txtOilGreases = (TextBox)gvr.FindControl("txtOilGreases");
                    arraydata[6] = txtOilGreases.Text;
                    TextBox txtTotalNitrogen = (TextBox)gvr.FindControl("txtTotalNitrogen");
                    arraydata[7] = txtTotalNitrogen.Text;
                    TextBox txtSulphates = (TextBox)gvr.FindControl("txtSulphates");
                    arraydata[8] = txtSulphates.Text;
                    TextBox txtPhosphate = (TextBox)gvr.FindControl("txtPhosphate");
                    arraydata[9] = txtPhosphate.Text;
                    TextBox txtChloride = (TextBox)gvr.FindControl("txtChloride");
                    arraydata[10] = txtChloride.Text;
                    TextBox txtSodium = (TextBox)gvr.FindControl("txtSodium");
                    arraydata[11] = txtSodium.Text;
                    TextBox txtPotassium = (TextBox)gvr.FindControl("txtPotassium");
                    arraydata[12] = txtPotassium.Text;

                    TextBox txtCalcium = (TextBox)gvr.FindControl("txtCalcium");
                    arraydata[13] = txtCalcium.Text;

                    TextBox txtMagnesium = (TextBox)gvr.FindControl("txtMagnesium");
                    arraydata[14] = txtCalcium.Text;

                    if (txtAcidity.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Chemical Characterstics";
                        lblmsg.CssClass = "errormsg";
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
                    ViewState["dtChemicalChars"] = dt;
                    gvChemicalChars.DataSource = dt;
                    gvChemicalChars.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvChemicalChars.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindChemicalCharsGridAdd();
                    String[] arraydata = new String[15];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvChemicalChars.Rows[i];
                            DropDownList ddlChemicalCharSource = (DropDownList)gvr.FindControl("ddlChemicalCharSource");
                            arraydata[0] = ddlChemicalCharSource.SelectedValue;

                            TextBox txtAcidity = (TextBox)gvr.FindControl("txtAcidity");
                            arraydata[1] = txtAcidity.Text;
                            TextBox txtAlkalinity = (TextBox)gvr.FindControl("txtAlkalinity");
                            arraydata[2] = txtAlkalinity.Text;
                            TextBox txtHardness = (TextBox)gvr.FindControl("txtHardness");
                            arraydata[3] = txtHardness.Text;

                            TextBox txtBOD = (TextBox)gvr.FindControl("txtBOD");
                            arraydata[4] = txtBOD.Text;
                            TextBox txtCOD = (TextBox)gvr.FindControl("txtCOD");
                            arraydata[5] = txtCOD.Text;
                            TextBox txtOilGreases = (TextBox)gvr.FindControl("txtOilGreases");
                            arraydata[6] = txtOilGreases.Text;
                            TextBox txtTotalNitrogen = (TextBox)gvr.FindControl("txtTotalNitrogen");
                            arraydata[7] = txtTotalNitrogen.Text;
                            TextBox txtSulphates = (TextBox)gvr.FindControl("txtSulphates");
                            arraydata[8] = txtSulphates.Text;
                            TextBox txtPhosphate = (TextBox)gvr.FindControl("txtPhosphate");
                            arraydata[9] = txtPhosphate.Text;
                            TextBox txtChloride = (TextBox)gvr.FindControl("txtChloride");
                            arraydata[10] = txtChloride.Text;
                            TextBox txtSodium = (TextBox)gvr.FindControl("txtSodium");
                            arraydata[11] = txtSodium.Text;
                            TextBox txtPotassium = (TextBox)gvr.FindControl("txtPotassium");
                            arraydata[12] = txtPotassium.Text;

                            TextBox txtCalcium = (TextBox)gvr.FindControl("txtCalcium");
                            arraydata[13] = txtCalcium.Text;

                            TextBox txtMagnesium = (TextBox)gvr.FindControl("txtMagnesium");
                            arraydata[14] = txtCalcium.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtChemicalChars"] = dt;
                    gvChemicalChars.DataSource = dt;
                    gvChemicalChars.DataBind();
                }
                else
                {
                    dt = BindChemicalCharsGridAdd();
                    ViewState["dtChemicalChars"] = dt;
                    gvChemicalChars.DataSource = dt;
                    gvChemicalChars.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    private DataTable BindChemicalCharsGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Source");
        dt.Columns.Add("Acidity");
        dt.Columns.Add("Alkalinity");
        dt.Columns.Add("Hardness");
        dt.Columns.Add("BOD");
        dt.Columns.Add("COD");
        dt.Columns.Add("Oil_Greases");
        dt.Columns.Add("Nitrogen_Phosphate");
        dt.Columns.Add("Sulphates");
        dt.Columns.Add("Total_Phosphates");
        dt.Columns.Add("Total_Chloride");
        dt.Columns.Add("Sodium");
        dt.Columns.Add("Potassium");
        dt.Columns.Add("Calcium");
        dt.Columns.Add("Magnesium");
        DataRow dr = dt.NewRow();
        dr[0] = "";
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
        dr[12] = "";
        dr[13] = "";
        dr[14] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindChemicalCharsGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Source");

        DataRow dr = dt.NewRow();
        dr[0] = "";


        dt.Rows.Add(dr);
        return dt;
    }

    protected void btnSaveWaterSourceDtls_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<WaterSourcePCB> lstWaterSource = new List<WaterSourcePCB>();
            foreach (GridViewRow gvr in gvWaterSourceDtls.Rows)
            {
                WaterSourcePCB waterSourceVo = new WaterSourcePCB();
                DropDownList ddlSourceType = (DropDownList)gvr.FindControl("ddlSourceType");
                TextBox txtSourceName = (TextBox)gvr.FindControl("txtSourceName");
                TextBox txtSourceQuantity = (TextBox)gvr.FindControl("txtSourceQuantity");

                waterSourceVo.Source_Type = ddlSourceType.SelectedValue;
                waterSourceVo.SourceName = txtSourceName.Text;
                waterSourceVo.Quantity = txtSourceQuantity.Text;

                lstWaterSource.Add(waterSourceVo);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertWaterSourceDetails(Created_By, QuestionnaireId, lstWaterSource);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                Label1.Text = "Water Source Details Saved Successfully";
                btnSaveWaterSourceDtls.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
    protected void btnWaterConsumption_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<WaterConsumptionPCB> lstWaterConsumption = new List<WaterConsumptionPCB>();
            foreach (GridViewRow gvr in gvWaterConsumption.Rows)
            {
                WaterConsumptionPCB waterConsumptionvo = new WaterConsumptionPCB();
                DropDownList ddlWaterConsumpPurpose = (DropDownList)gvr.FindControl("ddlWaterConsumpPurpose");
                TextBox txtWaterQuantity = (TextBox)gvr.FindControl("txtWaterQuantity");
                waterConsumptionvo.Purpose = ddlWaterConsumpPurpose.SelectedValue;
                waterConsumptionvo.Quantity = txtWaterQuantity.Text;
                lstWaterConsumption.Add(waterConsumptionvo);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertWaterConsumptionDetails(Created_By, QuestionnaireId, lstWaterConsumption);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblConsumption.Text = "Water Consumption Details Saved Successfully";
                btnWaterConsumption.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }

    protected void btnWasteWaterDtls_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<WasteWaterDischargePCB> lstWasteWaterDtls = new List<WasteWaterDischargePCB>();
            foreach (GridViewRow gvr in gvWasteWaterDtls.Rows)
            {
                WasteWaterDischargePCB wasteWaterVo = new WasteWaterDischargePCB();
                DropDownList ddlWasteWaterSource = (DropDownList)gvr.FindControl("ddlWasteWaterSource");
                TextBox txtWasteWaterQuantity = (TextBox)gvr.FindControl("txtWasteWaterQuantity");
                wasteWaterVo.Source = ddlWasteWaterSource.SelectedValue;
                wasteWaterVo.Quantity = txtWasteWaterQuantity.Text;
                lstWasteWaterDtls.Add(wasteWaterVo);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertWasterWaterDetails(Created_By, QuestionnaireId, lstWasteWaterDtls);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblWasteWater.Text = "Waste Water Details Saved Successfully";
                btnWasteWaterDtls.Enabled = false;
                gvToxic.DataSource = BindToxicSubstanceGrid();
                gvToxic.DataBind();

                gvFinalDischarge.DataSource = BindFinalDischargeGrid();
                gvFinalDischarge.DataBind();

                gvPhysicalChars.DataSource = BindPhysicalCharsGrid();
                gvPhysicalChars.DataBind();

                gvOtherCharacterstics.DataSource = BindOtherCharsGrid();
                gvOtherCharacterstics.DataBind();

                gvChemicalChars.DataSource = BindChemicalCharsGrid();
                gvChemicalChars.DataBind();
            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
    protected void btnToxicDtls_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<ToxicSubstancePCB> lstToxics = new List<ToxicSubstancePCB>();
            foreach (GridViewRow gvr in gvToxic.Rows)
            {
                ToxicSubstancePCB toxicVo = new ToxicSubstancePCB();
                DropDownList ddlToxicSource = (DropDownList)gvr.FindControl("ddlToxicSource");
                DropDownList ddlToxicSubstance = (DropDownList)gvr.FindControl("ddlToxicSubstance");
                TextBox txtToxicName = (TextBox)gvr.FindControl("txtToxicName");
                TextBox txtToxicQuantity = (TextBox)gvr.FindControl("txtToxicQuantity");

                toxicVo.Source = ddlToxicSource.SelectedValue;
                toxicVo.Substance = ddlToxicSubstance.SelectedValue;
                toxicVo.Name = txtToxicName.Text;
                toxicVo.Quantity = txtToxicQuantity.Text;

                lstToxics.Add(toxicVo);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertToxicWaterDetails(Created_By, QuestionnaireId, lstToxics);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblToxic.Text = "Toxic Substance Details Saved Successfully";
                btnToxicDtls.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
    protected void btnFinalDischargeDtls_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<PointofFinalDischargePCB> lstFinalDischarge = new List<PointofFinalDischargePCB>();

            foreach (GridViewRow gvr in gvFinalDischarge.Rows)
            {
                PointofFinalDischargePCB finalDischargevo = new PointofFinalDischargePCB();
                DropDownList ddlDischrgeSource = (DropDownList)gvr.FindControl("ddlDischrgeSource");
                DropDownList ddlPointofDischarge = (DropDownList)gvr.FindControl("ddlPointofDischarge");

                finalDischargevo.FSource = ddlDischrgeSource.SelectedValue;
                finalDischargevo.PointofDischarge = ddlPointofDischarge.SelectedValue;
                lstFinalDischarge.Add(finalDischargevo);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertFinalDischargeDetails(Created_By, QuestionnaireId, lstFinalDischarge);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblFinalDischarge.Text = "Final Discharge Details Saved Successfully";
                btnFinalDischargeDtls.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
    protected void btnPhysicalCharDtls_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<PhysicalCharactersticsPCB> lstPhysicalCharactersticsPCB = new List<PhysicalCharactersticsPCB>();
            foreach (GridViewRow gvr in gvPhysicalChars.Rows)
            {
                PhysicalCharactersticsPCB phyCharvo = new PhysicalCharactersticsPCB();
                DropDownList ddlPhyCharSource = (DropDownList)gvr.FindControl("ddlPhyCharSource");
                TextBox txtPhyCharTemperature = (TextBox)gvr.FindControl("txtPhyCharTemperature");
                TextBox txtPhyCharPH = (TextBox)gvr.FindControl("txtPhyCharPH");
                TextBox txtPhyCharColour = (TextBox)gvr.FindControl("txtPhyCharColour");
                TextBox txtPhyCharTurbidity = (TextBox)gvr.FindControl("txtPhyCharTurbidity");
                TextBox txtPhyCharOdour = (TextBox)gvr.FindControl("txtPhyCharOdour");
                TextBox txtPhyCharTotalSolids = (TextBox)gvr.FindControl("txtPhyCharTotalSolids");
                TextBox txtPhyCharSuspendSolids = (TextBox)gvr.FindControl("txtPhyCharSuspendSolids");
                TextBox txtPhyCharVolatileSolids = (TextBox)gvr.FindControl("txtPhyCharVolatileSolids");

                phyCharvo.PCSource = ddlPhyCharSource.SelectedValue;
                phyCharvo.PH = txtPhyCharPH.Text;
                phyCharvo.Colour = txtPhyCharColour.Text;
                phyCharvo.Turbidity = txtPhyCharTurbidity.Text;
                phyCharvo.Odour = txtPhyCharOdour.Text;
                phyCharvo.TotalSolids = txtPhyCharTotalSolids.Text;
                phyCharvo.SuspendedSolids = txtPhyCharSuspendSolids.Text;
                phyCharvo.VolatileSolids = txtPhyCharVolatileSolids.Text;

                lstPhysicalCharactersticsPCB.Add(phyCharvo);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertPhysicalCharDetails(Created_By, QuestionnaireId, lstPhysicalCharactersticsPCB);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblPhysicalChar.Text = "Physical Characterstics saved Successfully";
                btnPhysicalCharDtls.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
    protected void btnChemicalChar_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<ChemicalDetailsPCB> lstChemicalDetailsPCB = new List<ChemicalDetailsPCB>();
            foreach (GridViewRow gvr in gvChemicalChars.Rows)
            {
                ChemicalDetailsPCB checmicalVo = new ChemicalDetailsPCB();
                DropDownList ddlChemicalCharSource = (DropDownList)gvr.FindControl("ddlChemicalCharSource");
                TextBox txtAcidity = (TextBox)gvr.FindControl("txtAcidity");
                TextBox txtAlkalinity = (TextBox)gvr.FindControl("txtAlkalinity");
                TextBox txtHardness = (TextBox)gvr.FindControl("txtHardness");
                TextBox txtBOD = (TextBox)gvr.FindControl("txtBOD");
                TextBox txtCOD = (TextBox)gvr.FindControl("txtCOD");
                TextBox txtOilGreases = (TextBox)gvr.FindControl("txtOilGreases");
                TextBox txtTotalNitrogen = (TextBox)gvr.FindControl("txtTotalNitrogen");
                TextBox txtSulphates = (TextBox)gvr.FindControl("txtSulphates");
                TextBox txtPhosphate = (TextBox)gvr.FindControl("txtPhosphate");
                TextBox txtChloride = (TextBox)gvr.FindControl("txtChloride");
                TextBox txtSodium = (TextBox)gvr.FindControl("txtSodium");
                TextBox txtPotassium = (TextBox)gvr.FindControl("txtPotassium");
                TextBox txtCalcium = (TextBox)gvr.FindControl("txtCalcium");
                TextBox txtMagnesium = (TextBox)gvr.FindControl("txtMagnesium");

                checmicalVo.Source = ddlChemicalCharSource.SelectedValue;
                checmicalVo.Acidity = txtAcidity.Text;
                checmicalVo.Alkalinity = txtAlkalinity.Text;
                checmicalVo.Hardness = txtHardness.Text;
                checmicalVo.BOD = txtBOD.Text;
                checmicalVo.COD = txtCOD.Text;
                checmicalVo.Oil_Greases = txtOilGreases.Text;
                checmicalVo.Nitrogen_Phosphate = txtTotalNitrogen.Text;
                checmicalVo.Sulphates = txtSulphates.Text;
                checmicalVo.Total_Phosphates = txtPhosphate.Text;
                checmicalVo.Total_Chloride = txtChloride.Text;
                checmicalVo.Sodium = txtSodium.Text;
                checmicalVo.Potassium = txtPotassium.Text;
                checmicalVo.Calcium = txtCalcium.Text;
                checmicalVo.Magnesium = txtMagnesium.Text;

                lstChemicalDetailsPCB.Add(checmicalVo);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertChemicalCharDetails(Created_By, QuestionnaireId, lstChemicalDetailsPCB);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblChemicalChar.Text = "Chemical Characterstics Saved Successfully";
                btnChemicalChar.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
    protected void btnOtherCharDtls_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<OtherCharactersticsPCB> lstOtherCharactersticsPCB = new List<OtherCharactersticsPCB>();
            foreach (GridViewRow gvr in gvOtherCharacterstics.Rows)
            {
                OtherCharactersticsPCB otherCharvo = new OtherCharactersticsPCB();
                DropDownList ddlOtherCharSource = (DropDownList)gvr.FindControl("ddlOtherCharSource");
                DropDownList ddlOtherCharUnits = (DropDownList)gvr.FindControl("ddlOtherCharUnits");
                TextBox txtOtherCharItemName = (TextBox)gvr.FindControl("txtOtherCharItemName");
                TextBox txtOtherCharQuantity = (TextBox)gvr.FindControl("txtOtherCharQuantity");

                otherCharvo.OSource = ddlOtherCharSource.SelectedValue;
                otherCharvo.Units = ddlOtherCharUnits.SelectedValue;
                otherCharvo.Item = txtOtherCharItemName.Text;
                otherCharvo.Quantity = txtOtherCharQuantity.Text;

                lstOtherCharactersticsPCB.Add(otherCharvo);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertOtherCharDetails(Created_By, QuestionnaireId, lstOtherCharactersticsPCB);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblOtherChar.Text = "Other Characterstics Saved Successfully";
                btnOtherCharDtls.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }

    }
    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    if (Session["Applid"] != null)
    //    {
    //        PCBDetailsVo pcbvo=new PCBDetailsVo();
    //        int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
    //        string Created_By = Session["uid"].ToString();
    //        int valid = 1;
    //        pcbvo.DischargeWasteWater=ddlPurposeDischargeWater.SelectedValue;
    //        pcbvo.ModeofFinalDischarge=ddlModeofFinalDischarge.SelectedValue;
    //        pcbvo.PretreatmentNecessary=rbntLstPretreatment.SelectedValue;
    //        valid = objPCB.InsertOtherCharDetails(Created_By, QuestionnaireId,);
    //        if (valid == 0)
    //        {
    //            //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
    //            lblmsg0.Text = "Other Characterstics Saved Successfully";
    //            btnOtherCharDtls.Enabled = false;

    //        }
    //    }
    //    else
    //    {
    //        Response.Redirect("~/Index.aspx");
    //    }
    //}
}
