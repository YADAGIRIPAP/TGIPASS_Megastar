using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmAirEmission : System.Web.UI.Page
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
        try
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
            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];
                if (!IsPostBack)
                {
                    gvStackDetails.DataSource = BindStackDetailsGrid();
                    gvStackDetails.DataBind();

                    gvFugitive.DataSource = BindFugitiveStackDetailsGrid();
                    gvFugitive.DataBind();

                    gvCompDust.DataSource = BindStackDustGrid();
                    gvCompDust.DataBind();

                    gvFDust.DataSource = BindFugitiveStackDustGrid();
                    gvFDust.DataBind();

                    gvCompGases.DataSource = BindStackGasesGrid();
                    gvCompGases.DataBind();

                    gvFGases.DataSource = BindFugitiveStackGasesGrid();
                    gvFGases.DataBind();

                    gvFuel.DataSource = BindFuelGrid();
                    gvFuel.DataBind();

                }
                if (!IsPostBack)
                {
                    DataSet ds = new DataSet();
                    //ddlPurposeDischargeWater
                    //ddlModeofFinalDischarge
                    FillDetails();

                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg.Text = ex.Message;
            Failure.Visible = true;
        }
        //}
    }
    void FillDetails()
    {

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();
        try
        {
            ds = objPCB.getAirEmissionPCBDetails(hdfFlagID0.Value.ToString());

            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                ViewState["dtStackDetails"] = ds.Tables[1];
                gvStackDetails.DataSource = ds.Tables[1];
                gvStackDetails.DataBind();
            }
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                ViewState["dtStackDust"] = ds.Tables[2];
                gvCompDust.DataSource = ds.Tables[2];
                gvCompDust.DataBind();
            }
            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                ViewState["dtStackGases"] = ds.Tables[3];
                gvCompGases.DataSource = ds.Tables[3];
                gvCompGases.DataBind();
            }
            if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            {
                ViewState["dtFugitiveStackDetails"] = ds.Tables[4];
                gvFugitive.DataSource = ds.Tables[4];
                gvFugitive.DataBind();
            }
            if (ds != null && ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
            {
                ViewState["dtFugStackDust"] = ds.Tables[5];
                gvFDust.DataSource = ds.Tables[5];
                gvFDust.DataBind();
            }
            if (ds != null && ds.Tables.Count > 6 && ds.Tables[6].Rows.Count > 0)
            {
                ViewState["dtFugitiveStackGases"] = ds.Tables[6];

                gvFGases.DataSource = ds.Tables[6];
                gvFGases.DataBind();
            }
            if (ds != null && ds.Tables.Count > 7 && ds.Tables[7].Rows.Count > 0)
            {
                ViewState["dtStackfuel"] = ds.Tables[7];
                gvFuel.DataSource = ds.Tables[7];
                gvFuel.DataBind();
            }

        }
        catch (Exception ex)
        {

            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvStackDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtStackDetails"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtStackAttached = (TextBox)gvr.FindControl("txtStackAttached");
                        txtStackAttached.Text = dt.Rows[e.Row.RowIndex]["StackAttached"].ToString();

                        TextBox txtStackHeight = (TextBox)gvr.FindControl("txtStackHeight");
                        txtStackHeight.Text = dt.Rows[e.Row.RowIndex]["StackHeight"].ToString();

                        TextBox txtTemperature = (TextBox)gvr.FindControl("txtTemperature");
                        txtTemperature.Text = dt.Rows[e.Row.RowIndex]["Temprature"].ToString();

                        TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                        txtQuantity.Text = dt.Rows[e.Row.RowIndex]["ExpectedQuantity"].ToString();

                        TextBox txtControlSystem = (TextBox)gvr.FindControl("txtControlSystem");
                        txtControlSystem.Text = dt.Rows[e.Row.RowIndex]["AirPollution"].ToString();

                        TextBox txtDiameter = (TextBox)gvr.FindControl("txtDiameter");
                        txtDiameter.Text = dt.Rows[e.Row.RowIndex]["Diameter"].ToString();

                        TextBox txtFlow = (TextBox)gvr.FindControl("txtFlow");
                        txtFlow.Text = dt.Rows[e.Row.RowIndex]["FlowRate"].ToString();

                        TextBox txtHeightGround = (TextBox)gvr.FindControl("txtHeightGround");
                        txtHeightGround.Text = dt.Rows[e.Row.RowIndex]["StackHeightGround"].ToString();

                        DropDownList ddlStackTop = (DropDownList)gvr.FindControl("ddlStackTop");
                        ddlStackTop.SelectedValue = dt.Rows[e.Row.RowIndex]["StackTop"].ToString();

                        DropDownList ddlEmission = (DropDownList)gvr.FindControl("ddlEmission");
                        ddlEmission.SelectedValue = dt.Rows[e.Row.RowIndex]["EmissionStandards"].ToString();

                        TextBox txtNumber = (TextBox)gvr.FindControl("txtNumber");
                        txtNumber.Text = dt.Rows[e.Row.RowIndex]["StackCount"].ToString();
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
    protected void gvStackDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindStackDetailsGrid();
                String[] arraydata = new String[11];

                int gvrcnt = gvStackDetails.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvStackDetails.Rows[i];

                    TextBox txtStackAttached = (TextBox)gvr.FindControl("txtStackAttached");
                    arraydata[0] = txtStackAttached.Text;

                    TextBox txtStackHeight = (TextBox)gvr.FindControl("txtStackHeight");
                    arraydata[1] = txtStackHeight.Text;

                    TextBox txtTemperature = (TextBox)gvr.FindControl("txtTemperature");
                    arraydata[2] = txtTemperature.Text;

                    TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                    arraydata[3] = txtQuantity.Text;

                    TextBox txtControlSystem = (TextBox)gvr.FindControl("txtControlSystem");
                    arraydata[4] = txtControlSystem.Text;

                    TextBox txtDiameter = (TextBox)gvr.FindControl("txtDiameter");
                    arraydata[5] = txtDiameter.Text;

                    TextBox txtFlow = (TextBox)gvr.FindControl("txtFlow");
                    arraydata[6] = txtFlow.Text;

                    TextBox txtHeightGround = (TextBox)gvr.FindControl("txtHeightGround");
                    arraydata[7] = txtHeightGround.Text;

                    DropDownList ddlStackTop = (DropDownList)gvr.FindControl("ddlStackTop");
                    arraydata[8] = ddlStackTop.SelectedValue;

                    DropDownList ddlEmission = (DropDownList)gvr.FindControl("ddlEmission");
                    arraydata[9] = ddlEmission.SelectedValue;

                    TextBox txtNumber = (TextBox)gvr.FindControl("txtNumber");
                    arraydata[10] = txtNumber.Text;

                    if (txtStackAttached.Text == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Stack Attached Details";
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
                    ViewState["dtStackDetails"] = dt;
                    gvStackDetails.DataSource = dt;
                    gvStackDetails.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvStackDetails.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindStackDetailsGrid();
                    String[] arraydata = new String[11];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvStackDetails.Rows[i];

                            TextBox txtStackAttached = (TextBox)gvr.FindControl("txtStackAttached");
                            arraydata[0] = txtStackAttached.Text;

                            TextBox txtStackHeight = (TextBox)gvr.FindControl("txtStackHeight");
                            arraydata[1] = txtStackHeight.Text;

                            TextBox txtTemperature = (TextBox)gvr.FindControl("txtTemperature");
                            arraydata[2] = txtTemperature.Text;

                            TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                            arraydata[3] = txtQuantity.Text;

                            TextBox txtControlSystem = (TextBox)gvr.FindControl("txtControlSystem");
                            arraydata[4] = txtControlSystem.Text;

                            TextBox txtDiameter = (TextBox)gvr.FindControl("txtDiameter");
                            arraydata[5] = txtDiameter.Text;

                            TextBox txtFlow = (TextBox)gvr.FindControl("txtFlow");
                            arraydata[6] = txtFlow.Text;

                            TextBox txtHeightGround = (TextBox)gvr.FindControl("txtHeightGround");
                            arraydata[7] = txtHeightGround.Text;

                            DropDownList ddlStackTop = (DropDownList)gvr.FindControl("ddlStackTop");
                            arraydata[8] = ddlStackTop.SelectedValue;

                            DropDownList ddlEmission = (DropDownList)gvr.FindControl("ddlEmission");
                            arraydata[9] = ddlEmission.SelectedValue;

                            TextBox txtNumber = (TextBox)gvr.FindControl("txtNumber");
                            arraydata[10] = txtNumber.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtStackDetails"] = dt;
                    gvStackDetails.DataSource = dt;
                    gvStackDetails.DataBind();
                }
                else
                {
                    dt = BindStackDetailsGrid();
                    ViewState["dtStackDetails"] = dt;
                    gvStackDetails.DataSource = dt;
                    gvStackDetails.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvCompDust_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindStackDustGrid();
                String[] arraydata = new String[3];

                int gvrcnt = gvCompDust.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvCompDust.Rows[i];

                    DropDownList ddlStackNameDust = (DropDownList)gvr.FindControl("ddlStackNameDust");
                    arraydata[0] = ddlStackNameDust.SelectedValue;

                    TextBox txtNature = (TextBox)gvr.FindControl("txtNature");
                    arraydata[1] = txtNature.Text;

                    TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                    arraydata[2] = txtQuantity.Text;


                    if (ddlStackNameDust.SelectedValue == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please select Stack Details";
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
                    ViewState["dtStackDust"] = dt;
                    gvCompDust.DataSource = dt;
                    gvCompDust.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvCompDust.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindStackDustGrid();
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvCompDust.Rows[i];

                            DropDownList ddlStackNameDust = (DropDownList)gvr.FindControl("ddlStackNameDust");
                            arraydata[0] = ddlStackNameDust.SelectedValue;

                            TextBox txtNature = (TextBox)gvr.FindControl("txtNature");
                            arraydata[1] = txtNature.Text;

                            TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                            arraydata[2] = txtQuantity.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtStackDust"] = dt;
                    gvCompDust.DataSource = dt;
                    gvCompDust.DataBind();
                }
                else
                {
                    dt = BindStackDustGrid();
                    ViewState["dtStackDust"] = dt;
                    gvCompDust.DataSource = dt;
                    gvCompDust.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvCompDust_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtStackDust"];
                DropDownList ddlStackNameDust = (DropDownList)gvr.FindControl("ddlStackNameDust");
                BindStackNames(ddlStackNameDust);
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        ddlStackNameDust.SelectedValue = dt.Rows[e.Row.RowIndex]["StackName"].ToString();

                        TextBox txtNature = (TextBox)gvr.FindControl("txtNature");
                        txtNature.Text = dt.Rows[e.Row.RowIndex]["NatureofDust"].ToString();

                        TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                        txtQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();
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
    protected void gvCompGases_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtStackGases"];
                DropDownList ddlCompGases = (DropDownList)gvr.FindControl("ddlCompGases");
                DropDownList ddlStackNameGases = (DropDownList)gvr.FindControl("ddlStackNameGases");

                BindGases(ddlCompGases);
                BindStackNames(ddlStackNameGases);
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        ddlStackNameGases.SelectedValue = dt.Rows[e.Row.RowIndex]["StackName"].ToString();


                        ddlCompGases.Text = dt.Rows[e.Row.RowIndex]["Gases"].ToString();

                        TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                        txtQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();
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
    protected void gvCompGases_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindStackGasesGrid();
                String[] arraydata = new String[3];

                int gvrcnt = gvCompGases.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvCompGases.Rows[i];

                    DropDownList ddlStackNameGases = (DropDownList)gvr.FindControl("ddlStackNameGases");
                    arraydata[0] = ddlStackNameGases.SelectedValue;

                    DropDownList ddlCompGases = (DropDownList)gvr.FindControl("ddlCompGases");
                    arraydata[1] = ddlCompGases.SelectedValue;

                    TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                    arraydata[2] = txtQuantity.Text;


                    if (ddlStackNameGases.SelectedValue == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please select Stack Details";
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
                    ViewState["dtStackGases"] = dt;
                    gvCompGases.DataSource = dt;
                    gvCompGases.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvCompGases.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindStackGasesGrid();
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvCompGases.Rows[i];

                            DropDownList ddlStackNameGases = (DropDownList)gvr.FindControl("ddlStackNameGases");
                            arraydata[0] = ddlStackNameGases.SelectedValue;

                            DropDownList ddlCompGases = (DropDownList)gvr.FindControl("ddlCompGases");
                            arraydata[1] = ddlCompGases.SelectedValue;

                            TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                            arraydata[2] = txtQuantity.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtStackGases"] = dt;
                    gvCompGases.DataSource = dt;
                    gvCompGases.DataBind();
                }
                else
                {
                    dt = BindStackGasesGrid();
                    ViewState["dtStackGases"] = dt;
                    gvCompGases.DataSource = dt;
                    gvCompGases.DataBind();
                    Failure.Visible = true;
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvFugitive_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtFugitiveStackDetails"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtFugStackAttached = (TextBox)gvr.FindControl("txtFugStackAttached");
                        txtFugStackAttached.Text = dt.Rows[e.Row.RowIndex]["StackAttached"].ToString();

                        TextBox txtFugStackHeight = (TextBox)gvr.FindControl("txtFugStackHeight");
                        txtFugStackHeight.Text = dt.Rows[e.Row.RowIndex]["StackHeight"].ToString();

                        TextBox txtFugTemperature = (TextBox)gvr.FindControl("txtFugTemperature");
                        txtFugTemperature.Text = dt.Rows[e.Row.RowIndex]["Temprature"].ToString();

                        TextBox txtFugQuantity = (TextBox)gvr.FindControl("txtFugQuantity");
                        txtFugQuantity.Text = dt.Rows[e.Row.RowIndex]["ExpectedQuantity"].ToString();

                        TextBox txtFugControlSystem = (TextBox)gvr.FindControl("txtFugControlSystem");
                        txtFugControlSystem.Text = dt.Rows[e.Row.RowIndex]["AirPollution"].ToString();

                        TextBox txtFugDiameter = (TextBox)gvr.FindControl("txtFugDiameter");
                        txtFugDiameter.Text = dt.Rows[e.Row.RowIndex]["Diameter"].ToString();

                        TextBox txtFugFlow = (TextBox)gvr.FindControl("txtFugFlow");
                        txtFugFlow.Text = dt.Rows[e.Row.RowIndex]["FlowRate"].ToString();

                        TextBox txtFugHeightGround = (TextBox)gvr.FindControl("txtFugHeightGround");
                        txtFugHeightGround.Text = dt.Rows[e.Row.RowIndex]["StackHeightGround"].ToString();

                        DropDownList ddlFugStackTop = (DropDownList)gvr.FindControl("ddlFugStackTop");
                        ddlFugStackTop.SelectedValue = dt.Rows[e.Row.RowIndex]["StackTop"].ToString();

                        DropDownList ddlFugEmission = (DropDownList)gvr.FindControl("ddlFugEmission");
                        ddlFugEmission.SelectedValue = dt.Rows[e.Row.RowIndex]["EmissionStandards"].ToString();

                        TextBox txtFugNumber = (TextBox)gvr.FindControl("txtFugNumber");
                        txtFugNumber.Text = dt.Rows[e.Row.RowIndex]["StackCount"].ToString();
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
    protected void gvFugitive_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindStackDetailsGrid();
                String[] arraydata = new String[11];

                int gvrcnt = gvFugitive.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvFugitive.Rows[i];

                    TextBox txtFugStackAttached = (TextBox)gvr.FindControl("txtFugStackAttached");
                    arraydata[0] = txtFugStackAttached.Text;

                    TextBox txtFugStackHeight = (TextBox)gvr.FindControl("txtFugStackHeight");
                    arraydata[1] = txtFugStackHeight.Text;

                    TextBox txtFugTemperature = (TextBox)gvr.FindControl("txtFugTemperature");
                    arraydata[2] = txtFugTemperature.Text;

                    TextBox txtFugQuantity = (TextBox)gvr.FindControl("txtFugQuantity");
                    arraydata[3] = txtFugQuantity.Text;

                    TextBox txtFugControlSystem = (TextBox)gvr.FindControl("txtFugControlSystem");
                    arraydata[4] = txtFugControlSystem.Text;

                    TextBox txtFugDiameter = (TextBox)gvr.FindControl("txtFugDiameter");
                    arraydata[5] = txtFugDiameter.Text;

                    TextBox txtFugFlow = (TextBox)gvr.FindControl("txtFugFlow");
                    arraydata[6] = txtFugFlow.Text;

                    TextBox txtFugHeightGround = (TextBox)gvr.FindControl("txtFugHeightGround");
                    arraydata[7] = txtFugHeightGround.Text;

                    DropDownList ddlFugStackTop = (DropDownList)gvr.FindControl("ddlFugStackTop");
                    arraydata[8] = ddlFugStackTop.SelectedValue;

                    DropDownList ddlFugEmission = (DropDownList)gvr.FindControl("ddlFugEmission");
                    arraydata[9] = ddlFugEmission.SelectedValue;

                    TextBox txtFugNumber = (TextBox)gvr.FindControl("txtFugNumber");
                    arraydata[10] = txtFugNumber.Text;

                    if (txtFugStackAttached.Text == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Stack Attached Details";
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
                    ViewState["dtFugitiveStackDetails"] = dt;
                    gvFugitive.DataSource = dt;
                    gvFugitive.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvFugitive.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindStackDetailsGrid();
                    String[] arraydata = new String[11];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvFugitive.Rows[i];

                            TextBox txtFugStackAttached = (TextBox)gvr.FindControl("txtFugStackAttached");
                            arraydata[0] = txtFugStackAttached.Text;

                            TextBox txtFugStackHeight = (TextBox)gvr.FindControl("txtFugStackHeight");
                            arraydata[1] = txtFugStackHeight.Text;

                            TextBox txtFugTemperature = (TextBox)gvr.FindControl("txtFugTemperature");
                            arraydata[2] = txtFugTemperature.Text;

                            TextBox txtFugQuantity = (TextBox)gvr.FindControl("txtFugQuantity");
                            arraydata[3] = txtFugQuantity.Text;

                            TextBox txtFugControlSystem = (TextBox)gvr.FindControl("txtFugControlSystem");
                            arraydata[4] = txtFugControlSystem.Text;

                            TextBox txtFugDiameter = (TextBox)gvr.FindControl("txtFugDiameter");
                            arraydata[5] = txtFugDiameter.Text;

                            TextBox txtFugFlow = (TextBox)gvr.FindControl("txtFugFlow");
                            arraydata[6] = txtFugFlow.Text;

                            TextBox txtFugHeightGround = (TextBox)gvr.FindControl("txtFugHeightGround");
                            arraydata[7] = txtFugHeightGround.Text;

                            DropDownList ddlFugStackTop = (DropDownList)gvr.FindControl("ddlFugStackTop");
                            arraydata[8] = ddlFugStackTop.SelectedValue;

                            DropDownList ddlFugEmission = (DropDownList)gvr.FindControl("ddlFugEmission");
                            arraydata[9] = ddlFugEmission.SelectedValue;

                            TextBox txtFugNumber = (TextBox)gvr.FindControl("txtFugNumber");
                            arraydata[10] = txtFugNumber.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtFugitiveStackDetails"] = dt;
                    gvFugitive.DataSource = dt;
                    gvFugitive.DataBind();
                }
                else
                {
                    dt = BindStackDetailsGrid();
                    ViewState["dtFugitiveStackDetails"] = dt;
                    gvFugitive.DataSource = dt;
                    gvFugitive.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvFuel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtStackfuel"];
                DropDownList ddlFuelPurpose = (DropDownList)gvr.FindControl("ddlFuelPurpose");
                DropDownList ddlFuelCharUnits = (DropDownList)gvr.FindControl("ddlFuelCharUnits");
                BindUnits(ddlFuelCharUnits);
                BindFuelPurpose(ddlFuelPurpose);
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtFuelName = (TextBox)gvr.FindControl("txtFuelName");
                        txtFuelName.Text = dt.Rows[e.Row.RowIndex]["NameFuel"].ToString();

                        TextBox txtFuelConsump = (TextBox)gvr.FindControl("txtFuelConsump");
                        txtFuelConsump.Text = dt.Rows[e.Row.RowIndex]["DailyConsumption"].ToString();
                        ddlFuelPurpose.SelectedValue = dt.Rows[e.Row.RowIndex]["Purpose"].ToString();
                        ddlFuelCharUnits.SelectedValue = dt.Rows[e.Row.RowIndex]["Unit"].ToString();
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
    private void BindUnits(DropDownList ddlUnits)
    {
        DataSet dsUnits = new DataSet();
        dsUnits = objPCB.GETUnitsPCB();
        ddlUnits.Items.Clear();
        if (dsUnits != null && dsUnits.Tables.Count > 0 && dsUnits.Tables[0].Rows.Count > 0)
        {
            ddlUnits.DataSource = dsUnits.Tables[0];
            ddlUnits.DataTextField = "Unit_Desc";
            ddlUnits.DataValueField = "UnitID";
            ddlUnits.DataBind();
        }
        ddlUnits.Items.Insert(0, "--Select--");
    }
    private void BindFuelPurpose(DropDownList ddlFuelPurpose)
    {
        DataSet dsUnits = new DataSet();
        dsUnits = objPCB.GETFuelPurposePCB();
        ddlFuelPurpose.Items.Clear();
        if (dsUnits != null && dsUnits.Tables.Count > 0 && dsUnits.Tables[0].Rows.Count > 0)
        {
            ddlFuelPurpose.DataSource = dsUnits.Tables[0];
            ddlFuelPurpose.DataTextField = "FuelPurpose_Desc";
            ddlFuelPurpose.DataValueField = "FuelPurposeId";
            ddlFuelPurpose.DataBind();
        }
        ddlFuelPurpose.Items.Insert(0, "--Select--");
    }
    protected void gvFuel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindFuelGrid();
                String[] arraydata = new String[4];

                int gvrcnt = gvFuel.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvFuel.Rows[i];

                    TextBox txtFuelName = (TextBox)gvr.FindControl("txtFuelName");
                    arraydata[0] = txtFuelName.Text;

                    TextBox txtFuelConsump = (TextBox)gvr.FindControl("txtFuelConsump");
                    arraydata[1] = txtFuelConsump.Text;

                    DropDownList ddlFuelPurpose = (DropDownList)gvr.FindControl("ddlFuelPurpose");
                    arraydata[2] = ddlFuelPurpose.SelectedValue;

                    DropDownList ddlFuelCharUnits = (DropDownList)gvr.FindControl("ddlFuelCharUnits");
                    arraydata[3] = ddlFuelCharUnits.SelectedValue;

                    if (txtFuelName.Text == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please select Fuel Name";
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
                    ViewState["dtStackfuel"] = dt;
                    gvFuel.DataSource = dt;
                    gvFuel.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvFuel.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindFuelGrid();
                    String[] arraydata = new String[4];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvFuel.Rows[i];

                            TextBox txtFuelName = (TextBox)gvr.FindControl("txtFuelName");
                            arraydata[0] = txtFuelName.Text;

                            TextBox txtFuelConsump = (TextBox)gvr.FindControl("txtFuelConsump");
                            arraydata[1] = txtFuelConsump.Text;

                            DropDownList ddlFuelPurpose = (DropDownList)gvr.FindControl("ddlFuelPurpose");
                            arraydata[2] = ddlFuelPurpose.SelectedValue;

                            DropDownList ddlFuelCharUnits = (DropDownList)gvr.FindControl("ddlFuelCharUnits");
                            arraydata[3] = ddlFuelCharUnits.SelectedValue;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtStackfuel"] = dt;
                    gvFuel.DataSource = dt;
                    gvFuel.DataBind();
                }
                else
                {
                    dt = BindFuelGrid();
                    ViewState["dtStackfuel"] = dt;
                    gvFuel.DataSource = dt;
                    gvFuel.DataBind();
                    //Failure.Visible = true;
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvFGases_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtFugitiveStackGases"];
                DropDownList ddlFCompGases = (DropDownList)gvr.FindControl("ddlFCompGases");
                DropDownList ddlFStackNameGases = (DropDownList)gvr.FindControl("ddlFStackNameGases");

                BindGases(ddlFCompGases);
                BindFugitiveStackNames(ddlFStackNameGases);
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        ddlFStackNameGases.SelectedValue = dt.Rows[e.Row.RowIndex]["StackName"].ToString();


                        ddlFCompGases.Text = dt.Rows[e.Row.RowIndex]["Gases"].ToString();

                        TextBox txtFQuantity = (TextBox)gvr.FindControl("txtFQuantity");
                        txtFQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();
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
    protected void gvFGases_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindFugitiveStackGasesGrid();
                String[] arraydata = new String[3];

                int gvrcnt = gvFGases.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvFGases.Rows[i];

                    DropDownList ddlStackNameGases = (DropDownList)gvr.FindControl("ddlFStackNameGases");
                    arraydata[0] = ddlStackNameGases.SelectedValue;

                    DropDownList ddlCompGases = (DropDownList)gvr.FindControl("ddlFCompGases");
                    arraydata[1] = ddlCompGases.SelectedValue;

                    TextBox txtQuantity = (TextBox)gvr.FindControl("txtFQuantity");
                    arraydata[2] = txtQuantity.Text;


                    if (ddlStackNameGases.SelectedValue == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please select Stack Details";
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
                    ViewState["dtFugitiveStackGases"] = dt;
                    gvFGases.DataSource = dt;
                    gvFGases.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvFGases.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindFugitiveStackGasesGrid();
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvFGases.Rows[i];

                            DropDownList ddlStackNameGases = (DropDownList)gvr.FindControl("ddlStackNameGases");
                            arraydata[0] = ddlStackNameGases.SelectedValue;

                            DropDownList ddlCompGases = (DropDownList)gvr.FindControl("ddlCompGases");
                            arraydata[1] = ddlCompGases.SelectedValue;

                            TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                            arraydata[2] = txtQuantity.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtFugitiveStackGases"] = dt;
                    gvFGases.DataSource = dt;
                    gvFGases.DataBind();
                }
                else
                {
                    dt = BindFugitiveStackGasesGrid();
                    ViewState["dtFugitiveStackGases"] = dt;
                    gvFGases.DataSource = dt;
                    gvFGases.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvFDust_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtFugStackDust"];
                DropDownList ddlFStackNameDust = (DropDownList)gvr.FindControl("ddlFStackNameDust");
                BindFugitiveStackNames(ddlFStackNameDust);
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        ddlFStackNameDust.SelectedValue = dt.Rows[e.Row.RowIndex]["StackName"].ToString();

                        TextBox txtFNature = (TextBox)gvr.FindControl("txtFNature");
                        txtFNature.Text = dt.Rows[e.Row.RowIndex]["NatureofDust"].ToString();

                        TextBox txtFQuantity = (TextBox)gvr.FindControl("txtFQuantity");
                        txtFQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();
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
    protected void gvFDust_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindFugitiveStackDustGrid();
                String[] arraydata = new String[3];

                int gvrcnt = gvFDust.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvFDust.Rows[i];

                    DropDownList ddlFStackNameDust = (DropDownList)gvr.FindControl("ddlFStackNameDust");
                    arraydata[0] = ddlFStackNameDust.SelectedValue;

                    TextBox txtFNature = (TextBox)gvr.FindControl("txtFNature");
                    arraydata[1] = txtFNature.Text;

                    TextBox txtFQuantity = (TextBox)gvr.FindControl("txtFQuantity");
                    arraydata[2] = txtFQuantity.Text;


                    if (ddlFStackNameDust.SelectedValue == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please select Stack Details";
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
                    ViewState["dtFugStackDust"] = dt;
                    gvFDust.DataSource = dt;
                    gvFDust.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvFDust.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindFugitiveStackDustGrid();
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvFDust.Rows[i];

                            DropDownList ddlFStackNameDust = (DropDownList)gvr.FindControl("ddlFStackNameDust");
                            arraydata[0] = ddlFStackNameDust.SelectedValue;

                            TextBox txtFNature = (TextBox)gvr.FindControl("txtFNature");
                            arraydata[1] = txtFNature.Text;

                            TextBox txtFQuantity = (TextBox)gvr.FindControl("txtFQuantity");
                            arraydata[2] = txtFQuantity.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtFugStackDust"] = dt;
                    gvFDust.DataSource = dt;
                    gvFDust.DataBind();
                }
                else
                {
                    dt = BindFugitiveStackDustGrid();
                    ViewState["dtFugStackDust"] = dt;
                    gvFDust.DataSource = dt;
                    gvFDust.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    private DataTable BindStackDetailsGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("StackAttached");
        dt.Columns.Add("StackHeight");
        dt.Columns.Add("Temprature");
        dt.Columns.Add("ExpectedQuantity");
        dt.Columns.Add("AirPollution");
        dt.Columns.Add("Diameter");
        dt.Columns.Add("FlowRate");
        dt.Columns.Add("StackHeightGround");
        dt.Columns.Add("StackTop");
        dt.Columns.Add("EmissionStandards");
        dt.Columns.Add("StackCount");

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

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindStackDustGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("StackName");
        dt.Columns.Add("NatureofDust");
        dt.Columns.Add("Quantity");

        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindStackGasesGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("StackName");
        dt.Columns.Add("Gases");
        dt.Columns.Add("Quantity");

        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindFugitiveStackDetailsGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("StackAttached");
        dt.Columns.Add("StackHeight");
        dt.Columns.Add("Temprature");
        dt.Columns.Add("ExpectedQuantity");
        dt.Columns.Add("AirPollution");
        dt.Columns.Add("Diameter");
        dt.Columns.Add("FlowRate");
        dt.Columns.Add("StackHeightGround");
        dt.Columns.Add("StackTop");
        dt.Columns.Add("EmissionStandards");
        dt.Columns.Add("StackCount");

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

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindFugitiveStackDustGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("StackName");
        dt.Columns.Add("NatureofDust");
        dt.Columns.Add("Quantity");

        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindFugitiveStackGasesGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("StackName");
        dt.Columns.Add("Gases");
        dt.Columns.Add("Quantity");

        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindFuelGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("NameFuel");
        dt.Columns.Add("DailyConsumption");
        dt.Columns.Add("Purpose");
        dt.Columns.Add("Unit");

        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private void BindGases(DropDownList ddlGases)
    {
        DataSet dsGases = new DataSet();
        dsGases = objPCB.GetGasesPCB();
        if (dsGases != null && dsGases.Tables.Count > 0 && dsGases.Tables[0].Rows.Count > 0)
        {
            ddlGases.DataSource = dsGases.Tables[0];
            ddlGases.DataTextField = "EmissionGases_Desc";
            ddlGases.DataValueField = "EmissionGasesId";
            ddlGases.DataBind();
        }
    }
    protected void btnSaveStackDetails_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<StackDetailsPCB> lstStackDetailsPCB = new List<StackDetailsPCB>();
            foreach (GridViewRow gvr in gvStackDetails.Rows)
            {
                StackDetailsPCB stackPcb = new StackDetailsPCB();
                TextBox txtStackAttached = (TextBox)gvr.FindControl("txtStackAttached");
                stackPcb.StackAttached = txtStackAttached.Text;

                TextBox txtStackHeight = (TextBox)gvr.FindControl("txtStackHeight");
                stackPcb.StackHeight = txtStackHeight.Text;

                TextBox txtTemperature = (TextBox)gvr.FindControl("txtTemperature");
                stackPcb.Temprature = txtTemperature.Text;

                TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                stackPcb.ExpectedQuantity = txtQuantity.Text;

                TextBox txtControlSystem = (TextBox)gvr.FindControl("txtControlSystem");
                stackPcb.AirPollution = txtControlSystem.Text;

                TextBox txtDiameter = (TextBox)gvr.FindControl("txtDiameter");
                stackPcb.Diameter = txtDiameter.Text;

                TextBox txtFlow = (TextBox)gvr.FindControl("txtFlow");
                stackPcb.FlowRate = txtFlow.Text;

                TextBox txtHeightGround = (TextBox)gvr.FindControl("txtHeightGround");
                stackPcb.StackHeightGround = txtHeightGround.Text;

                DropDownList ddlStackTop = (DropDownList)gvr.FindControl("ddlStackTop");
                stackPcb.StackTop = ddlStackTop.SelectedValue;

                DropDownList ddlEmission = (DropDownList)gvr.FindControl("ddlEmission");
                stackPcb.EmissionStandards = ddlEmission.SelectedValue;

                TextBox txtNumber = (TextBox)gvr.FindControl("txtNumber");
                stackPcb.StackCount = txtNumber.Text;
                lstStackDetailsPCB.Add(stackPcb);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertStackDetailsPCB(Created_By, QuestionnaireId, lstStackDetailsPCB);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblStackDetails.Text = "Stack Details Saved Successfully";
                btnSaveStackDetails.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }

    protected void btnSaveStackDust_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<StackDustPCB> lstStackDustPCB = new List<StackDustPCB>();
            foreach (GridViewRow gvr in gvCompDust.Rows)
            {
                StackDustPCB dustvo = new StackDustPCB();
                DropDownList ddlStackNameDust = (DropDownList)gvr.FindControl("ddlStackNameDust");
                dustvo.StackName = ddlStackNameDust.SelectedValue;

                TextBox txtNature = (TextBox)gvr.FindControl("txtNature");
                dustvo.NatureofDust = txtNature.Text;

                TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                dustvo.Quantity = txtQuantity.Text;
                lstStackDustPCB.Add(dustvo);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertStackDustPCB(Created_By, QuestionnaireId, lstStackDustPCB);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblDust.Text = "Nature of Dust Details Saved Successfully";
                btnSaveStackDust.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
    protected void btnSaveNatureofGases_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<StackGasesPCB> lstStackGasesPCB = new List<StackGasesPCB>();
            foreach (GridViewRow gvr in gvCompGases.Rows)
            {
                StackGasesPCB stackGasvo = new StackGasesPCB();
                DropDownList ddlStackNameGases = (DropDownList)gvr.FindControl("ddlStackNameGases");
                stackGasvo.StackName = ddlStackNameGases.SelectedValue;
                DropDownList ddlCompGases = (DropDownList)gvr.FindControl("ddlCompGases");
                stackGasvo.Gases = ddlCompGases.SelectedValue;

                TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                stackGasvo.Quantity = txtQuantity.Text;

                lstStackGasesPCB.Add(stackGasvo);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertStackGasesPCB(Created_By, QuestionnaireId, lstStackGasesPCB);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblGases.Text = "Stack Gases Details Saved Successfully";
                btnSaveNatureofGases.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
    protected void btnSaveFugitive_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<StackDetailsFugitivePCB> lstStackDetailsFugitivePCB = new List<StackDetailsFugitivePCB>();
            foreach (GridViewRow gvr in gvFugitive.Rows)
            {
                StackDetailsFugitivePCB stackFugitiveVo = new StackDetailsFugitivePCB();
                TextBox txtFugStackAttached = (TextBox)gvr.FindControl("txtFugStackAttached");
                stackFugitiveVo.StackAttached = txtFugStackAttached.Text;

                TextBox txtFugStackHeight = (TextBox)gvr.FindControl("txtFugStackHeight");
                stackFugitiveVo.StackHeight = txtFugStackHeight.Text;

                TextBox txtFugTemperature = (TextBox)gvr.FindControl("txtFugTemperature");
                stackFugitiveVo.Temprature = txtFugTemperature.Text;

                TextBox txtFugQuantity = (TextBox)gvr.FindControl("txtFugQuantity");
                stackFugitiveVo.ExpectedQuantity = txtFugQuantity.Text;

                TextBox txtFugControlSystem = (TextBox)gvr.FindControl("txtFugControlSystem");
                stackFugitiveVo.AirPollution = txtFugControlSystem.Text;

                TextBox txtFugDiameter = (TextBox)gvr.FindControl("txtFugDiameter");
                stackFugitiveVo.Diameter = txtFugDiameter.Text;

                TextBox txtFugFlow = (TextBox)gvr.FindControl("txtFugFlow");
                stackFugitiveVo.FlowRate = txtFugFlow.Text;

                TextBox txtFugHeightGround = (TextBox)gvr.FindControl("txtFugHeightGround");
                stackFugitiveVo.StackHeightGround = txtFugHeightGround.Text;

                DropDownList ddlFugStackTop = (DropDownList)gvr.FindControl("ddlFugStackTop");
                stackFugitiveVo.StackTop = ddlFugStackTop.SelectedValue;

                DropDownList ddlFugEmission = (DropDownList)gvr.FindControl("ddlFugEmission");
                stackFugitiveVo.EmissionStandards = ddlFugEmission.SelectedValue;

                TextBox txtFugNumber = (TextBox)gvr.FindControl("txtFugNumber");
                stackFugitiveVo.StackCount = txtFugNumber.Text;

                lstStackDetailsFugitivePCB.Add(stackFugitiveVo);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertStackDetailsFugitivePCB(Created_By, QuestionnaireId, lstStackDetailsFugitivePCB);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblFug.Text = "Fugitive Sources Saved Successfully";
                btnSaveFugitive.Enabled = false;
                gvFDust.DataSource = BindFugitiveStackDustGrid();
                gvFDust.DataBind();

                gvFGases.DataSource = BindFugitiveStackGasesGrid();
                gvFGases.DataBind();
            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
    protected void btnSaveFuelBurning_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<StackDustFugitivePCB> lstStackDustFugitivePCB = new List<StackDustFugitivePCB>();
            foreach (GridViewRow gvr in gvFDust.Rows)
            {
                StackDustFugitivePCB stackdustfug = new StackDustFugitivePCB();
                DropDownList ddlFStackNameDust = (DropDownList)gvr.FindControl("ddlFStackNameDust");
                stackdustfug.StackName = ddlFStackNameDust.SelectedValue;

                TextBox txtFNature = (TextBox)gvr.FindControl("txtFNature");
                stackdustfug.NatureofDust = txtFNature.Text;

                TextBox txtFQuantity = (TextBox)gvr.FindControl("txtFQuantity");
                stackdustfug.Quantity = txtFQuantity.Text;
                if (txtFQuantity.Text.Trim() != "")
                    lstStackDustFugitivePCB.Add(stackdustfug);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertStackDustFugitivePCB(Created_By, QuestionnaireId, lstStackDustFugitivePCB);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblFuelBurning.Text = "Fuel Burning Details Saved Successfully";
                btnSaveFuelBurning.Enabled = false;
            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
    protected void btnSaveFuelBurnGas_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<StackGasesFugitivePCB> lstStackGasesFugitivePCB = new List<StackGasesFugitivePCB>();
            foreach (GridViewRow gvr in gvFGases.Rows)
            {
                StackGasesFugitivePCB stackGasFug = new StackGasesFugitivePCB();
                DropDownList ddlStackNameGases = (DropDownList)gvr.FindControl("ddlFStackNameGases");
                stackGasFug.StackName = ddlStackNameGases.SelectedValue;

                DropDownList ddlCompGases = (DropDownList)gvr.FindControl("ddlFCompGases");
                stackGasFug.Gases = ddlCompGases.SelectedValue;

                TextBox txtFQuantity = (TextBox)gvr.FindControl("txtFQuantity");
                stackGasFug.Quantity = txtFQuantity.Text;
                lstStackGasesFugitivePCB.Add(stackGasFug);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertStackGasesFugitivePCB(Created_By, QuestionnaireId, lstStackGasesFugitivePCB);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblFuelBurnGas.Text = "Fuel Burning(Gases) Details Saved Successfully";
                btnSaveFuelBurnGas.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }//StackAttached,SLNO
    }
    protected void btnSaveFuelUsed_Click(object sender, EventArgs e)
    {
        if (Session["Applid"] != null)
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            List<FuelPCB> lstFuelPCB = new List<FuelPCB>();
            foreach (GridViewRow gvr in gvFuel.Rows)
            {
                FuelPCB fuelvo = new FuelPCB();
                TextBox txtFuelName = (TextBox)gvr.FindControl("txtFuelName");
                fuelvo.NameFuel = txtFuelName.Text;

                TextBox txtFuelConsump = (TextBox)gvr.FindControl("txtFuelConsump");
                fuelvo.DailyConsumption = txtFuelConsump.Text;

                DropDownList ddlFuelPurpose = (DropDownList)gvr.FindControl("ddlFuelPurpose");
                fuelvo.Purpose = ddlFuelPurpose.SelectedValue;

                DropDownList ddlFuelCharUnits = (DropDownList)gvr.FindControl("ddlFuelCharUnits");
                fuelvo.Unit = ddlFuelCharUnits.SelectedValue;
                if (txtFuelConsump.Text.Trim() != "")
                    lstFuelPCB.Add(fuelvo);
            }
            string Created_By = Session["uid"].ToString();
            int valid = 1;
            valid = objPCB.InsertFuelPCB(Created_By, QuestionnaireId, lstFuelPCB);
            if (valid == 0)
            {
                //btnSaveWaterSourceDtls.Attributes.Add("onclick", "javascript:return SavedWaterSourceDtls()");
                lblFuel.Text = "Fuel used Details Saved Successfully";
                btnSaveFuelUsed.Enabled = false;

            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }
    private void BindStackNames(DropDownList ddlStack)
    {
        DataSet dsGases = new DataSet();
        dsGases = objPCB.GetSTACKNAMES(Session["Applid"].ToString());
        if (dsGases != null && dsGases.Tables.Count > 0 && dsGases.Tables[0].Rows.Count > 0)
        {
            ddlStack.DataSource = dsGases.Tables[0];
            ddlStack.DataTextField = "StackAttached";
            ddlStack.DataValueField = "StackAttached";
            ddlStack.DataBind();
        }
    }
    private void BindFugitiveStackNames(DropDownList ddlFugitiveStack)
    {
        DataSet dsGases = new DataSet();
        dsGases = objPCB.GetFugitiveSTACKNAMES(Session["Applid"].ToString());
        if (dsGases != null && dsGases.Tables.Count > 0 && dsGases.Tables[0].Rows.Count > 0)
        {
            ddlFugitiveStack.DataSource = dsGases.Tables[0];
            ddlFugitiveStack.DataTextField = "StackAttached";
            ddlFugitiveStack.DataValueField = "StackAttached";
            ddlFugitiveStack.DataBind();
        }
    }
}