using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmLabourDetails : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DropDownList ddlWorkPlace;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    List<LabourWorkPlace> lstworkplaceVo = new List<LabourWorkPlace>();
    List<FamilyMembersAct1> lstfamilyMembersActVo = new List<FamilyMembersAct1>();
    List<EmployeesDetails> lstemployeeDetailsVo = new List<EmployeesDetails>();

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

                dsver = Gen.GetverifyofqueLabour(Session["Applid"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatus(Session["Applid"].ToString());
                    ////string res = Gen.RetriveStatus("1002");


                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);
                    }

                }


            }

            if (!IsPostBack)
            {
                gvWorkerDtls.DataSource = BindWorkerPlaceGrid();
                gvWorkerDtls.DataBind();

                gvFamilyMembersAct1.DataSource = BindgvFamilyMembersAct1Grid();
                gvFamilyMembersAct1.DataBind();

                gvEmployeeNames.DataSource = BindgvEmployeeNamesGrid();
                gvEmployeeNames.DataBind();

                //gvNoofEmployeesAct1.DataSource = BindgvNoofEmployeesAct1Grid();
                //gvNoofEmployeesAct1.DataBind();

                DataSet dsClassification = new DataSet();
                DataSet dsCategory = new DataSet();

                DataSet dsOccupation = new DataSet();
                DataSet dsPersonType = new DataSet();

                dsClassification = Gen.GetLabourActClassification();
                if (dsClassification != null && dsClassification.Tables.Count > 0 && dsClassification.Tables[0].Rows.Count > 0)
                {
                    ddlEstClassification.DataSource = dsClassification.Tables[0];
                    ddlEstClassification.DataTextField = "Classification_Desc";
                    ddlEstClassification.DataValueField = "Classification_Id";
                    ddlEstClassification.DataBind();
                }
                AddSelect(ddlEstClassification);

                dsCategory = Gen.GetLabourActCategoryMaster();
                if (dsCategory != null && dsCategory.Tables.Count > 0 && dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlCategoryofEstablishment.DataSource = dsCategory.Tables[0];
                    ddlCategoryofEstablishment.DataTextField = "Category_Desc";
                    ddlCategoryofEstablishment.DataValueField = "Category_Id";
                    ddlCategoryofEstablishment.DataBind();
                }
                AddSelect(ddlCategoryofEstablishment);

                dsOccupation = Gen.GetLabourActOccupationMaster();
                BindDistricts(ddlShopDistrict);
                BindDistricts(ddlDistrictResidentialAct1);
                BindDistricts(ddlManagerDistrictAct1);
            }
            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];

                if (!IsPostBack)
                {
                    FillDetails();

                }

            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvWorkerDtls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindWorkerPlaceGridAdd();

                DropDownList ddlWorkPlace;
                TextBox txtDoorNo;
                TextBox txtLocality;

                String[] arraydata = new String[3];

                int gvrcnt = gvWorkerDtls.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {
                    ddlWorkPlace = (DropDownList)gvWorkerDtls.Rows[i].Cells[1].Controls[1];
                    arraydata[0] = ddlWorkPlace.SelectedValue;
                    GridViewRow gvr = gvWorkerDtls.Rows[i];
                    txtDoorNo = (TextBox)gvr.FindControl("txtDoorNo");
                    arraydata[1] = txtDoorNo.Text;
                    txtLocality = (TextBox)gvr.FindControl("txtLocality");
                    arraydata[2] = txtLocality.Text;

                    if (txtDoorNo.Text == "" || txtLocality.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Work Place details";
                        lblmsg.CssClass = "errormsg";
                    }

                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtWorkerDtls"] = dt;
                    gvWorkerDtls.DataSource = dt;
                    gvWorkerDtls.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvWorkerDtls.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindWorkerPlaceGridAdd();
                    DropDownList ddlWorkPlace;
                    TextBox txtDoorNo;
                    TextBox txtLocality;
                    String[] arraydata = new String[3];
                    
                    int j = Convert.ToInt32(e.CommandArgument);
                    decimal extent = 0;
                    int i;
                    for ( i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            ddlWorkPlace = (DropDownList)gvWorkerDtls.Rows[i].Cells[1].Controls[1];
                            arraydata[0] = ddlWorkPlace.SelectedValue;
                            GridViewRow gvr = gvWorkerDtls.Rows[i];
                            txtDoorNo = (TextBox)gvr.FindControl("txtDoorNo");
                            arraydata[1] = txtDoorNo.Text;
                            txtLocality = (TextBox)gvr.FindControl("txtLocality");
                            arraydata[2] = txtLocality.Text;
                            
                            if (j == 0)
                                dt.Rows[i - 1].ItemArray = arraydata;
                            else
                                dt.Rows[i].ItemArray = arraydata;


                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);
                        }
                    }
                    dt.Rows.RemoveAt(i - 1);
                    ViewState["dtWorkerDtls"] = dt;
                    gvWorkerDtls.DataSource = dt;
                    gvWorkerDtls.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg";
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvWorkerDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataSet dsWorkPlace = new DataSet();
            dsWorkPlace = Gen.GetWorkPlaceMaster();
            if (dsWorkPlace != null && dsWorkPlace.Tables.Count > 0 && dsWorkPlace.Tables[0].Rows.Count > 0)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddlWorkPlace = (DropDownList)e.Row.Cells[1].Controls[1];

                    ddlWorkPlace.DataSource = dsWorkPlace.Tables[0];
                    ddlWorkPlace.DataTextField = "Work_Place";
                    ddlWorkPlace.DataValueField = "WorkPlace_Id";
                    ddlWorkPlace.DataBind();

                    AddSelect(ddlWorkPlace);

                    DataTable dt = (DataTable)ViewState["dtWorkerDtls"];

                    if (dt != null)
                    {
                        if (e.Row.RowIndex < dt.Rows.Count)
                        {
                            GridViewRow gvr = e.Row;
                            TextBox txtDoorNo = (TextBox)gvr.FindControl("txtDoorNo");
                            TextBox txtLocality = (TextBox)gvr.FindControl("txtLocality");

                            txtDoorNo.Text = dt.Rows[e.Row.RowIndex]["Door_No"].ToString();
                            txtLocality.Text = dt.Rows[e.Row.RowIndex]["Locality"].ToString();
                            ddlWorkPlace.SelectedValue = dt.Rows[e.Row.RowIndex]["Work_Place"].ToString();

                        }
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
    protected DataTable BindWorkerPlaceGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Work_Place");
        dt.Columns.Add("Door_No");
        dt.Columns.Add("Locality");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

        dt.Rows.Add(dr);
        return dt;
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
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected DataTable BindWorkerPlaceGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Work_Place");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected void gvFamilyMembersAct1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvFamilyMembersAct1GridAdd();
                String[] arraydata = new String[4];

                int gvrcnt = gvFamilyMembersAct1.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {
                    DropDownList ddlRelationship = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[2].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
                    DropDownList ddlGender = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[3].Controls[1];
                    DropDownList ddlPersonType = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[4].Controls[1];

                    GridViewRow gvr = gvFamilyMembersAct1.Rows[i];
                    TextBox txtFamilyMemeberName = (TextBox)gvr.FindControl("txtFamilyNameAct1");
                    arraydata[0] = txtFamilyMemeberName.Text;
                    arraydata[1] = ddlRelationship.SelectedValue;
                    arraydata[2] = ddlGender.SelectedValue;
                    arraydata[3] = ddlPersonType.SelectedValue;


                    if (txtFamilyMemeberName.Text == "" || ddlRelationship.SelectedValue == "0")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Family Member details";
                        lblmsg.CssClass = "errormsg";
                    }

                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtFamilyMembers"] = dt;
                    gvFamilyMembersAct1.DataSource = dt;
                    gvFamilyMembersAct1.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvFamilyMembersAct1.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvFamilyMembersAct1GridAdd();
                    String[] arraydata = new String[4];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            DropDownList ddlRelationship = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[2].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
                            DropDownList ddlGender = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[3].Controls[1];
                            DropDownList ddlPersonType = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[4].Controls[1];

                            GridViewRow gvr = gvFamilyMembersAct1.Rows[i];
                            TextBox txtFamilyMemeberName = (TextBox)gvr.FindControl("txtFamilyNameAct1");
                            arraydata[0] = txtFamilyMemeberName.Text;
                            arraydata[1] = ddlRelationship.SelectedValue;
                            arraydata[2] = ddlGender.SelectedValue;
                            arraydata[3] = ddlPersonType.SelectedValue;

                            if (j == 0)
                                dt.Rows[i - 1].ItemArray = arraydata;
                            else
                                dt.Rows[i].ItemArray = arraydata;


                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);
                        }
                    }
                    dt.Rows.RemoveAt(i - 1);
                    ViewState["dtFamilyMembers"] = dt;
                    gvFamilyMembersAct1.DataSource = dt;
                    gvFamilyMembersAct1.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg";
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvFamilyMembersAct1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataSet dsRelations = new DataSet();
            DataSet dsGenders = new DataSet();
            DataSet dsPersonTypes = new DataSet();
            dsRelations = Gen.GetLabourActRelationshipMaster();

            dsGenders = Gen.GetGender();
            dsPersonTypes = Gen.GetLabourActPersonMaster();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlRelationship = (DropDownList)e.Row.Cells[2].Controls[1];
                DropDownList ddlGender = (DropDownList)e.Row.Cells[3].Controls[1];
                DropDownList ddlPersonType = (DropDownList)e.Row.Cells[4].Controls[1];

                if (dsRelations != null && dsRelations.Tables.Count > 0 && dsRelations.Tables[0].Rows.Count > 0)
                {
                    ddlRelationship.DataSource = dsRelations.Tables[0];
                    ddlRelationship.DataTextField = "Relationship_Type";
                    ddlRelationship.DataValueField = "Relationship_Id";
                    ddlRelationship.DataBind();
                }
                if (dsGenders != null && dsGenders.Tables.Count > 0 && dsGenders.Tables[0].Rows.Count > 0)
                {
                    ddlGender.DataSource = dsGenders.Tables[0];
                    ddlGender.DataTextField = "Gender_Type";
                    ddlGender.DataValueField = "Gender_Id";
                    ddlGender.DataBind();
                }
                if (dsPersonTypes != null && dsPersonTypes.Tables.Count > 0 && dsPersonTypes.Tables[0].Rows.Count > 0)
                {
                    ddlPersonType.DataSource = dsPersonTypes.Tables[0];
                    ddlPersonType.DataTextField = "PersonType_Type";
                    ddlPersonType.DataValueField = "PersonType_Id";
                    ddlPersonType.DataBind();
                }

                AddSelect(ddlRelationship);
                AddSelect(ddlGender);
                AddSelect(ddlPersonType);

                DataTable dt = (DataTable)ViewState["dtFamilyMembers"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        GridViewRow gvr = e.Row;
                        TextBox txtFamilyMemberName = (TextBox)gvr.FindControl("txtFamilyNameAct1");

                        txtFamilyMemberName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        ddlRelationship.SelectedValue = dt.Rows[e.Row.RowIndex]["RelationShip"].ToString();
                        ddlGender.SelectedValue = dt.Rows[e.Row.RowIndex]["Gender"].ToString();
                        ddlPersonType.SelectedValue = dt.Rows[e.Row.RowIndex]["Adult_Flag"].ToString();
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
    protected DataTable BindgvFamilyMembersAct1GridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Name");
        dt.Columns.Add("RelationShip");
        dt.Columns.Add("Gender");
        dt.Columns.Add("Adult_Flag");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dt.Rows.Add(dr);
        return dt;
    }

    protected DataTable BindgvFamilyMembersAct1Grid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Name");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected DataTable BindgvEmployeeNamesGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Occupation");
        dt.Columns.Add("Name");
        dt.Columns.Add("Gender");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

        dt.Rows.Add(dr);
        return dt;
    }

    protected DataTable BindgvEmployeeNamesGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Occupation");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected void gvEmployeeNames_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataSet dsOccupations = new DataSet();
            DataSet dsGenders = new DataSet();
            dsOccupations = Gen.GetLabourActOccupationMaster();

            dsGenders = Gen.GetGender();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlOccupationAct1 = (DropDownList)e.Row.Cells[1].Controls[1];

                DropDownList ddlGender = (DropDownList)e.Row.Cells[3].Controls[1];


                if (dsOccupations != null && dsOccupations.Tables.Count > 0 && dsOccupations.Tables[0].Rows.Count > 0)
                {
                    ddlOccupationAct1.DataSource = dsOccupations.Tables[0];
                    ddlOccupationAct1.DataTextField = "Occupation_Type";
                    ddlOccupationAct1.DataValueField = "Occupation_Id";
                    ddlOccupationAct1.DataBind();
                }
                if (dsGenders != null && dsGenders.Tables.Count > 0 && dsGenders.Tables[0].Rows.Count > 0)
                {
                    ddlGender.DataSource = dsGenders.Tables[0];
                    ddlGender.DataTextField = "Gender_Type";
                    ddlGender.DataValueField = "Gender_Id";
                    ddlGender.DataBind();
                }


                AddSelect(ddlOccupationAct1);
                AddSelect(ddlGender);
                DataTable dt = (DataTable)ViewState["dtEmplyoees"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        GridViewRow gvr = e.Row;
                        TextBox txtEmployeeName = (TextBox)gvr.FindControl("txtEmployeeNameAct1");

                        txtEmployeeName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        ddlOccupationAct1.SelectedValue = dt.Rows[e.Row.RowIndex]["Occupation"].ToString();
                        ddlGender.SelectedValue = dt.Rows[e.Row.RowIndex]["Gender"].ToString();

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
    protected void gvEmployeeNames_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvEmployeeNamesGridAdd();
                String[] arraydata = new String[3];

                int gvrcnt = gvEmployeeNames.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {
                    DropDownList ddlOccupation = (DropDownList)gvEmployeeNames.Rows[i].Cells[1].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
                    DropDownList ddlGender = (DropDownList)gvEmployeeNames.Rows[i].Cells[3].Controls[1];

                    GridViewRow gvr = gvEmployeeNames.Rows[i];
                    TextBox txtEmployeeName = (TextBox)gvr.FindControl("txtEmployeeNameAct1");
                    arraydata[0] = ddlOccupation.SelectedValue;
                    arraydata[1] = txtEmployeeName.Text;
                    arraydata[2] = ddlGender.SelectedValue;


                    if (txtEmployeeName.Text == "" || ddlOccupation.SelectedValue == "0" || ddlGender.SelectedValue == "0")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Employee details";
                        lblmsg.CssClass = "errormsg";
                    }

                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtEmplyoees"] = dt;
                    gvEmployeeNames.DataSource = dt;
                    gvEmployeeNames.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvEmployeeNames.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvEmployeeNamesGridAdd();
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            DropDownList ddlOccupation = (DropDownList)gvEmployeeNames.Rows[i].Cells[1].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
                            DropDownList ddlGender = (DropDownList)gvEmployeeNames.Rows[i].Cells[3].Controls[1];

                            GridViewRow gvr = gvEmployeeNames.Rows[i];
                            TextBox txtEmployeeName = (TextBox)gvr.FindControl("txtEmployeeNameAct1");
                            arraydata[0] = ddlOccupation.SelectedValue;
                            arraydata[1] = txtEmployeeName.Text;
                            arraydata[2] = ddlGender.SelectedValue;

                            if (j == 0)
                                dt.Rows[i - 1].ItemArray = arraydata;
                            else
                                dt.Rows[i].ItemArray = arraydata;


                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);
                        }
                    }
                    dt.Rows.RemoveAt(i - 1);
                    ViewState["dtEmplyoees"] = dt;
                    gvEmployeeNames.DataSource = dt;
                    gvEmployeeNames.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg";
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void Rd_ManagerResidenceAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rd_ManagerResidenceAct1.SelectedValue.ToString().Trim() == "Y")
        {
            trManagerResidenceAct1.Visible = true;
        }
        else
        {
            trManagerResidenceAct1.Visible = false;
        }
    }
    protected DataTable BindgvNoofEmployeesAct1Grid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("");
        dt.Columns.Add("");
        dt.Columns.Add("");

        DataRow dr = dt.NewRow();
        dr[0] = "MALE";
        dr[1] = "FEMALE";
        dr[2] = "TOTAL";
        dt.Rows.Add(dr);

        return dt;
    }
    public void BindDistricts(DropDownList ddlDistrict)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dsd.Tables[0];
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "--District--");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--District--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    protected void ddlShopDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlShopDistrict, ddlShopMandal);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    public void BindMandals(DropDownList ddlDistrict, DropDownList ddlMandal)
    {

        ddlMandal.Items.Clear();
        DataSet dsm = new DataSet();
        dsm = Gen.GetMandals(ddlDistrict.SelectedValue);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddlMandal.DataSource = dsm.Tables[0];
            ddlMandal.DataValueField = "Mandal_Id";
            ddlMandal.DataTextField = "Manda_lName";
            ddlMandal.DataBind();
            ddlMandal.Items.Insert(0, "--Mandal--");
        }
        else
        {
            ddlMandal.Items.Clear();
            ddlMandal.Items.Insert(0, "--Mandal--");
        }

    }
    protected void ddlShopMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlShopMandal, ddlShopVillage);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlDistrictResidentialAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDistrictResidentialAct1, ddlMandalResidentialAct1);
            //ddlMandal.Items.Clear();
            //DataSet dsm = new DataSet();
            //dsm = Gen.GetMandals(ddlDistrict.SelectedValue);
            //if (dsm.Tables[0].Rows.Count > 0)
            //{
            //    ddlMandal.DataSource = dsm.Tables[0];
            //    ddlMandal.DataValueField = "Mandal_Id";
            //    ddlMandal.DataTextField = "Manda_lName";
            //    ddlMandal.DataBind();
            //    ddlMandal.Items.Insert(0, "--Mandal--");
            //}
            //else
            //{
            //    ddlMandal.Items.Clear();
            //    ddlMandal.Items.Insert(0, "--Mandal--");
            //}
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlMandalResidentialAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMandalResidentialAct1, ddlVillageResidentialAct1);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    public void BindVillages(DropDownList ddlMandal, DropDownList ddlVillages)
    {
        if (ddlMandal.SelectedIndex == 0)
        {
            ddlVillages.Items.Clear();
            ddlVillages.Items.Insert(0, "--Village--");
        }
        else
        {
            ddlVillages.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlMandal.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlVillages.DataSource = dsv.Tables[0];
                ddlVillages.DataValueField = "Village_Id";
                ddlVillages.DataTextField = "Village_Name";
                ddlVillages.DataBind();
                ddlVillages.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlVillages.Items.Clear();
                ddlVillages.Items.Insert(0, "--Village--");
            }
        }

    }

    protected void ddlManagerMandalAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlManagerMandalAct1, ddlManagerVillageAct1);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlManagerDistrictAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlManagerDistrictAct1, ddlManagerMandalAct1);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
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
    void FillDetails()
    {

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();

        try
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            ds = Gen.getLabourDetails(hdfFlagID0.Value.ToString(), QuestionnaireId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                ddlEstClassification.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                ddlCategoryofEstablishment.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                txtNameofShopAct1.Text = ds.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                txtShopDoorNo.Text = ds.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                txtShopLocality.Text = ds.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                ddlShopDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                ddlShopMandal.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                ddlShopVillage.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();

                txtShopPincode.Text = ds.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                TxtnameofUnitAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                txtPGNameAct1.Text = ds.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                txtDesigAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Designation"].ToString();
                txtAgeAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Age"].ToString();
                txtMobileAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                txtEmailAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                txtDoorNoResidentialAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                txtLocalResidentialAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Locality"].ToString();
                ddlDistrictResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                ddlDistrictResidentialAct1_SelectedIndexChanged(this, EventArgs.Empty);
                ddlMandalResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                ddlMandalResidentialAct1_SelectedIndexChanged(this, EventArgs.Empty);
                ddlVillageResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();

                Rd_ManagerResidenceAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Agent_Flag"].ToString();
                Rd_ManagerResidenceAct1_SelectedIndexChanged(this, EventArgs.Empty);
                txtManagerNameAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                txtManagerPGNameAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                txtManagerDesignationAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
                txtManagerDoorNoAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                txtManagerLocalityAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                ddlManagerDistrictAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                ddlManagerDistrictAct1_SelectedIndexChanged(this, EventArgs.Empty);
                ddlManagerMandalAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                ddlManagerMandalAct1_SelectedIndexChanged(this, EventArgs.Empty);
                ddlManagerVillageAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();

                txtNatureofBusinessAct1.Text = ds.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                txtDateofCommenceAct1.Text = ds.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                //  txtTotalEmployees.Text = ds.Tables[0].Rows[0][""].ToString();
                txtAbove18Male.Text = ds.Tables[0].Rows[0]["Form1_1_Employees_Above18_Male"].ToString();
                txtBelow18Male.Text = ds.Tables[0].Rows[0]["Form1_1_Employees_14_18_Male"].ToString();
                txtAbove18Female.Text = ds.Tables[0].Rows[0]["Form1_1_Employees_Above18_Female"].ToString();
                txtBelow18FeMale.Text = ds.Tables[0].Rows[0]["Form1_1_Employees_14_18_Female"].ToString();
                //txtTotalAbove18.Text = ds.Tables[0].Rows[0][""].ToString();
                //txtTotalBelow18.Text = ds.Tables[0].Rows[0][""].ToString();
                txtBelow18FeMale_TextChanged(this, EventArgs.Empty);

            }
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                ViewState["dtWorkerDtls"] = ds.Tables[1];

                gvWorkerDtls.DataSource = ds.Tables[1];
                gvWorkerDtls.DataBind();
            }
            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                ViewState["dtFamilyMembers"] = ds.Tables[2];

                gvFamilyMembersAct1.DataSource = ds.Tables[2];
                gvFamilyMembersAct1.DataBind();
            }
            if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                ViewState["dtEmplyoees"] = ds.Tables[3];

                gvEmployeeNames.DataSource = ds.Tables[3];
                gvEmployeeNames.DataBind();
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
    protected void txtAbove18Male_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            txtTotalEmployees.Text = totalEmp.ToString();
            txtTotalAbove18.Text = totalAbove18Emp.ToString();
            txtTotalBelow18.Text = totalBelow18Emp.ToString();
            txtBelow18Male.Focus();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void txtAbove18Female_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            txtTotalEmployees.Text = totalEmp.ToString();
            txtTotalAbove18.Text = totalAbove18Emp.ToString();
            txtTotalBelow18.Text = totalBelow18Emp.ToString();
            txtBelow18FeMale.Focus();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void txtBelow18FeMale_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            txtTotalEmployees.Text = totalEmp.ToString();
            txtTotalAbove18.Text = totalAbove18Emp.ToString();
            txtTotalBelow18.Text = totalBelow18Emp.ToString();
            txtBelow18FeMale.Focus();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void txtBelow18Male_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            txtTotalEmployees.Text = totalEmp.ToString();
            txtTotalAbove18.Text = totalAbove18Emp.ToString();
            txtTotalBelow18.Text = totalBelow18Emp.ToString();
            txtAbove18Female.Focus();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {

            //labouractvo.
            int valid = 0;
            valid = SaveLabourDetails();
            lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    private int SaveLabourDetails()
    {
        LabourActVO labouractvo = new LabourActVO();
        labouractvo.QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
        labouractvo.intCFEEnterpid = Convert.ToInt32(Request.QueryString[0].ToString());
        labouractvo.EstClassification = ddlEstClassification.SelectedValue;
        labouractvo.CategoryofEstablishment = ddlCategoryofEstablishment.SelectedValue;
        labouractvo.NameofShopAct1 = txtNameofShopAct1.Text;
        labouractvo.CreatedBy = Convert.ToInt32(Session["uid"].ToString().Trim());
        labouractvo.ShopDoorNo = txtShopDoorNo.Text;
        labouractvo.ShopLocality = txtShopLocality.Text;
        labouractvo.ShopDistrict = ddlShopDistrict.SelectedValue;
        labouractvo.ShopMandal = ddlShopMandal.SelectedValue;
        labouractvo.ShopVillage = ddlShopVillage.SelectedValue;
        labouractvo.ShopPincode = txtShopPincode.Text;

        labouractvo.NameofUnitAct1 = TxtnameofUnitAct1.Text;
        labouractvo.PGNameAct1 = txtPGNameAct1.Text;
        labouractvo.EmpDesignation = txtDesigAct1.Text;
        labouractvo.AgeAct1 = txtAgeAct1.Text;
        labouractvo.MobileAct1 = txtMobileAct1.Text;
        labouractvo.EmailAct1 = txtEmailAct1.Text;

        labouractvo.DoorNoResidentialAct1 = txtDoorNoResidentialAct1.Text;
        labouractvo.LocalResidentialAct1 = txtLocalResidentialAct1.Text;
        labouractvo.DistrictResidentialAct1 = ddlDistrictResidentialAct1.SelectedValue;
        labouractvo.MandalResidentialAct1 = ddlMandalResidentialAct1.SelectedValue;
        labouractvo.VillageResidentialAct1 = ddlVillageResidentialAct1.SelectedValue;

        labouractvo.ManagerResidenceAct1 = Rd_ManagerResidenceAct1.SelectedValue;
        labouractvo.ManagerNameAct1 = txtManagerNameAct1.Text;
        labouractvo.ManagerPGNameAct1 = txtManagerPGNameAct1.Text;
        labouractvo.ManagerDesignationAct1 = txtManagerDesignationAct1.Text;
        labouractvo.ManagerDoorNo = txtManagerDoorNoAct1.Text;
        labouractvo.ManagerLocalityAct1 = txtManagerLocalityAct1.Text;
        labouractvo.ManagerDistrictAct1 = ddlManagerDistrictAct1.SelectedValue;
        labouractvo.ManagerMandalAct1 = ddlManagerMandalAct1.SelectedValue;
        labouractvo.ManagerVillageAct1 = ddlManagerVillageAct1.SelectedValue;

        labouractvo.NatureofBusinessAct1 = txtNatureofBusinessAct1.Text;
        labouractvo.DateofCommenceAct1 = txtDateofCommenceAct1.Text;
        if (txtTotalEmployees.Text.Trim() != "")
            labouractvo.TotalEmployees = Convert.ToInt32(txtTotalEmployees.Text);
        if (txtAbove18Male.Text.Trim() != "")
            labouractvo.Above18Male = Convert.ToInt32(txtAbove18Male.Text);
        if (txtBelow18Male.Text.Trim() != "")
            labouractvo.Below18Male = Convert.ToInt32(txtBelow18Male.Text);
        if (txtAbove18Female.Text.Trim() != "")
            labouractvo.Above18FeMale = Convert.ToInt32(txtAbove18Female.Text);
        if (txtBelow18FeMale.Text.Trim() != "")
            labouractvo.Below18FeMale = Convert.ToInt32(txtBelow18FeMale.Text);
        if (txtTotalAbove18.Text.Trim() != "")
            labouractvo.TotalAbove18 = Convert.ToInt32(txtTotalAbove18.Text);
        if (txtTotalBelow18.Text.Trim() != "")
            labouractvo.TotalBelow18 = Convert.ToInt32(txtTotalBelow18.Text);


        foreach (GridViewRow gvrow in gvWorkerDtls.Rows)
        {
            LabourWorkPlace workplaceVo = new LabourWorkPlace();
            DropDownList ddlWorkPlace = (DropDownList)gvrow.FindControl("ddlWorkPlace");
            TextBox txtDoorNo = (TextBox)gvrow.FindControl("txtDoorNo");
            TextBox txtLocality = (TextBox)gvrow.FindControl("txtLocality");
            workplaceVo.WorkPlace = ddlWorkPlace.SelectedValue;
            workplaceVo.DoorNo = txtDoorNo.Text.Trim();
            workplaceVo.Locality = txtLocality.Text.Trim();

            lstworkplaceVo.Add(workplaceVo);
        }
        foreach (GridViewRow gvrow in gvFamilyMembersAct1.Rows)
        {
            FamilyMembersAct1 familyMembersActVo = new FamilyMembersAct1();

            DropDownList ddlRelationshipAct1 = (DropDownList)gvrow.FindControl("ddlRelationshipAct1");
            DropDownList ddlFamilyGenderAct1 = (DropDownList)gvrow.FindControl("ddlFamilyGenderAct1");
            DropDownList ddlFamilyAdultAct1 = (DropDownList)gvrow.FindControl("ddlFamilyAdultAct1");
            TextBox txtFamilyNameAct1 = (TextBox)gvrow.FindControl("txtFamilyNameAct1");
            familyMembersActVo.RelationshipAct1 = ddlRelationshipAct1.SelectedValue;
            familyMembersActVo.FamilyNameAct1 = txtFamilyNameAct1.Text;
            familyMembersActVo.GenderAct1 = ddlFamilyGenderAct1.SelectedValue;

            familyMembersActVo.AdultAct1 = ddlFamilyAdultAct1.SelectedValue;

            lstfamilyMembersActVo.Add(familyMembersActVo);
        }
        foreach (GridViewRow gvrow in gvEmployeeNames.Rows)
        {
            EmployeesDetails employeeDetailsVo = new EmployeesDetails();

            DropDownList ddlOccupationAct1 = (DropDownList)gvrow.FindControl("ddlOccupationAct1");
            DropDownList ddlEmployeeGenderAct1 = (DropDownList)gvrow.FindControl("ddlEmployeeGenderAct1");

            TextBox txtEmployeeNameAct1 = (TextBox)gvrow.FindControl("txtEmployeeNameAct1");
            employeeDetailsVo.Occupation = ddlOccupationAct1.SelectedValue;
            employeeDetailsVo.EmployeeNameAct1 = txtEmployeeNameAct1.Text.Trim();
            employeeDetailsVo.EmployeeGenderAct1 = ddlEmployeeGenderAct1.SelectedValue;

            lstemployeeDetailsVo.Add(employeeDetailsVo);
        }
        int valid = 0;
        //  int valid = Gen.InsertLabourDetails(labouractvo, lstworkplaceVo, lstemployeeDetailsVo, lstfamilyMembersActVo);
        return valid;
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
            //Response.Write(hdfFlagID0.Value.ToString());
            //return;
            //ds = Gen.GetdataofPowerenterprenuer(hdfFlagID0.Value.ToString());

            int valid = 0;
            valid = SaveLabourDetails();

            Response.Redirect("frmAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
            //ResetFormControl(this);
            lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
            //this.Clear();
            success.Visible = true;
            Failure.Visible = false;
            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
            //fillNews(userid);

        }

    }
    protected void btnNext0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmLabourDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
    }
}