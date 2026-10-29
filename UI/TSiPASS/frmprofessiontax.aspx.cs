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

public partial class UI_TSiPASS_frmprofessiontax : System.Web.UI.Page
{
    General Gen = new General();
    DropDownList ddlcountry;
    DropDownList ddlpartnertype;
    DropDownList ddlstate;
    DropDownList ddldistrict;
    DataTable dt = new DataTable();
    List<Professiontaxaddressdetails> listproftaxAdressDetails = new List<Professiontaxaddressdetails>();
    List<Professiontaxpromoterdetails> listProftaxpromotional = new List<Professiontaxpromoterdetails>();

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

                dsver = Gen.GetverifyofqueProfessionTax(Session["Applid"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatus(Session["Applid"].ToString());
                    ////string res = Gen.RetriveStatus("1002");


                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);
                    }

                }
                // ddlcountry.SelectedValue = "1"; ddlcountry.Enabled = false; Gen.getStates(); ddlstate.SelectedValue = "31"; ddlstate.Enabled = false;
            }
            if (!IsPostBack)
            {
                DataSet dsnew = new DataSet();

                dsnew = Gen.getdataofidentity(Session["Applid"].ToString(), "2");

                if (dsnew.Tables[0].Rows.Count > 0 && dsnew.Tables[0].Rows[0]["IsOffline"].ToString() != "Y")
                {

                }
                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {

                        Response.Redirect("frmAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    }
                    else
                    {
                        Response.Redirect("frmPowerCeig.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                    }
                }
            }

            if (!IsPostBack)
            {

                gvdirectordetails.DataSource = BindgvdirectordetailsGrid();
                gvdirectordetails.DataBind();

                gvbusinessplaces.DataSource = BindgvbusinessplacesGrid();
                gvbusinessplaces.DataBind();

                DataSet dsbank = new DataSet();
                dsbank = Gen.GetProfessionTaxBankMaster();
                if (dsbank != null && dsbank.Tables.Count > 0 && dsbank.Tables[0].Rows.Count > 0)
                {
                    ddlBank.DataSource = dsbank.Tables[0];
                    //ddlBank.DataTextField = "Bankid";
                    //ddlBank.DataValueField = "BankName";

                    ddlBank.DataTextField = "BankName";
                    ddlBank.DataValueField = "Bankid";

                    ddlBank.DataBind();
                    AddSelect(ddlBank);
                }

                if (Request.QueryString["intApplicationId"] != null)
                {

                    DataSet ds = new DataSet();
                    ds = Gen.getdataofProfessionTax(Request.QueryString["intApplicationId"].ToString());

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        FillDetails();
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
    void FillDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Gen.getdataofProfessionTax(Request.QueryString["intApplicationId"].ToString());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtpanindustrl.Text = ds.Tables[0].Rows[0]["panofindustrialundertaking"].ToString();
                txtBranchName.Text = ds.Tables[0].Rows[0]["Branch"].ToString();
                txtIfscCode.Text = ds.Tables[0].Rows[0]["IFSCcode"].ToString();
                txtAccNumber.Text = ds.Tables[0].Rows[0]["Accountno"].ToString();

                ddlanualtrnovr.SelectedValue = ds.Tables[0].Rows[0]["estimatedannualturnover"].ToString();

                ddlBank.SelectedValue = ds.Tables[0].Rows[0]["Bankname"].ToString();


                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["dtDirectorDetails"] = null;
                    ViewState["dtDirectorDetails"] = ds.Tables[1];

                    gvdirectordetails.DataSource = ds.Tables[1];
                    gvdirectordetails.DataBind();
                }

                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    ViewState["dtBussinessPlaces"] = null;
                    ViewState["dtBussinessPlaces"] = ds.Tables[2];

                    gvbusinessplaces.DataSource = ds.Tables[2];
                    gvbusinessplaces.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvdirectordetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvdirectordetailsGridAdd();
                String[] arraydata = new String[15];

                int gvrcnt = gvdirectordetails.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {
                    DropDownList ddlpatnertype = (DropDownList)gvdirectordetails.Rows[i].Cells[3].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
                    DropDownList ddlGender = (DropDownList)gvdirectordetails.Rows[i].Cells[4].Controls[1];
                    DropDownList ddlcountry = (DropDownList)gvdirectordetails.Rows[i].Cells[8].Controls[1];
                    DropDownList ddlstate = (DropDownList)gvdirectordetails.Rows[i].Cells[9].Controls[1];
                    DropDownList ddldistrict = (DropDownList)gvdirectordetails.Rows[i].Cells[10].Controls[1];

                    GridViewRow gvr = gvdirectordetails.Rows[i];
                    TextBox txtName = (TextBox)gvr.FindControl("txtName");

                    TextBox txtdob = (TextBox)gvr.FindControl("txtdob");
                    TextBox txtdoor_no = (TextBox)gvr.FindControl("txtdoor_no");
                    TextBox txtpan = (TextBox)gvr.FindControl("txtpan");
                    TextBox txtroad = (TextBox)gvr.FindControl("txtroad");
                    TextBox txtcity = (TextBox)gvr.FindControl("txtcity");
                    TextBox txtpin = (TextBox)gvr.FindControl("txtpin");
                    TextBox txtaadharno = (TextBox)gvr.FindControl("txtaadhar");
                    TextBox txtemail = (TextBox)gvr.FindControl("txtemail");
                    TextBox txtmobileno = (TextBox)gvr.FindControl("txtmobileno");
                    TextBox txtstate = (TextBox)gvr.FindControl("txtstate");
                    TextBox txtdistrict = (TextBox)gvr.FindControl("txtdistrict");
                    //TextBox txtstate = (TextBox)gvr.FindControl("txtstate");

                    //  DropDownList ddlcountry = (DropDownList)gvr.FindControl("ddlcountry");
                    //  DropDownList ddlstate = (DropDownList)gvr.FindControl("ddlstate");
                    //  DropDownList ddldistrict = (DropDownList)gvr.FindControl("ddldistrict");

                    arraydata[0] = txtName.Text;
                    arraydata[1] = txtdob.Text;
                    arraydata[2] = ddlpatnertype.SelectedValue;
                    arraydata[3] = ddlGender.SelectedValue;
                    arraydata[4] = txtdoor_no.Text;
                    arraydata[5] = txtpan.Text;
                    arraydata[6] = txtroad.Text;
                    arraydata[7] = ddlcountry.SelectedValue;
                    if (ddlstate.SelectedValue != "31")
                    {
                        arraydata[8] = txtstate.Text;
                        arraydata[9] = txtdistrict.Text;
                    }
                    else
                    {
                        arraydata[8] = ddlstate.SelectedValue;
                        arraydata[9] = ddldistrict.SelectedValue;
                    }
                    //arraydata[8] = ddlstate.SelectedValue;

                    arraydata[10] = txtcity.Text;
                    arraydata[11] = txtpin.Text;
                    arraydata[12] = txtaadharno.Text;
                    arraydata[13] = txtemail.Text;
                    arraydata[14] = txtmobileno.Text;

                    //  arraydata[5] = txtdob.Text;


                    //if (txtName.Text == "" || ddlpatnertype.SelectedValue == "0")// || txtEnjExtent.Value == "")
                    //{
                    //    valid = 1;
                    //    lblmsg.Text = "Please enter Family Member details";
                    //    lblmsg.CssClass = "errormsg";
                    //}
                    if (txtdoor_no.Text == "" || txtdob.Text == "" || ddlpatnertype.SelectedValue == "0" || ddlGender.SelectedValue == "0" || txtdoor_no.Text == "" || txtpan.Text == "" || txtroad.Text == "" || ddlcountry.SelectedValue == "0" || ddlstate.SelectedValue == "0" || ddldistrict.SelectedValue == "0" || txtcity.Text == "" || txtpin.Text == "" || txtaadharno.Text == "" || txtemail.Text == "" || txtmobileno.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        Failure.Visible = true;
                        lblmsg0.Visible = true;
                        lblmsg0.Text = "<font color=red> Please Enter Details of all promoters/partners/Directors/others as applicable...!</font>";
                        return;
                    }
                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtDirectorDetails"] = dt;
                    gvdirectordetails.DataSource = dt;
                    gvdirectordetails.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvdirectordetails.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvdirectordetailsGridAdd();
                    String[] arraydata = new String[15];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            DropDownList ddlRelationship = (DropDownList)gvdirectordetails.Rows[i].Cells[3].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
                            DropDownList ddlGender = (DropDownList)gvdirectordetails.Rows[i].Cells[4].Controls[1];
                            DropDownList ddlcountry = (DropDownList)gvdirectordetails.Rows[i].Cells[8].Controls[1];
                            DropDownList ddlstate = (DropDownList)gvdirectordetails.Rows[i].Cells[9].Controls[1];
                            DropDownList ddldistrict = (DropDownList)gvdirectordetails.Rows[i].Cells[10].Controls[1];

                            GridViewRow gvr = gvdirectordetails.Rows[i];
                            TextBox txtName = (TextBox)gvr.FindControl("txtName");
                            TextBox txtdob = (TextBox)gvr.FindControl("txtdob");
                            TextBox txtdoor_no = (TextBox)gvr.FindControl("txtdoor_no");
                            TextBox txtpan = (TextBox)gvr.FindControl("txtpan");
                            TextBox txtroad = (TextBox)gvr.FindControl("txtroad");
                            TextBox txtcity = (TextBox)gvr.FindControl("txtcity");
                            TextBox txtpin = (TextBox)gvr.FindControl("txtpin");
                            TextBox txtaadharno = (TextBox)gvr.FindControl("txtaadhar");
                            TextBox txtemail = (TextBox)gvr.FindControl("txtemail");
                            TextBox txtmobileno = (TextBox)gvr.FindControl("txtmobileno");
                            TextBox txtstate = (TextBox)gvr.FindControl("txtstate");
                            TextBox txtdistrict = (TextBox)gvr.FindControl("txtdistrict");

                            arraydata[0] = txtName.Text;
                            arraydata[1] = txtdob.Text;
                            arraydata[2] = ddlRelationship.SelectedValue;
                            arraydata[3] = ddlGender.SelectedValue;
                            arraydata[4] = txtdoor_no.Text;
                            arraydata[5] = txtpan.Text;
                            arraydata[6] = txtroad.Text;
                            arraydata[7] = ddlcountry.SelectedValue;
                            if (ddlstate.SelectedValue != "31")
                            {
                                arraydata[8] = txtstate.Text;
                                arraydata[9] = txtdistrict.Text;
                            }
                            else
                            {
                                arraydata[8] = ddlstate.SelectedValue;
                                arraydata[9] = ddldistrict.SelectedValue;
                            }
                            arraydata[10] = txtcity.Text;
                            arraydata[11] = txtpin.Text;
                            arraydata[12] = txtaadharno.Text;
                            arraydata[13] = txtemail.Text;
                            arraydata[14] = txtmobileno.Text;

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
                    ViewState["dtDirectorDetails"] = dt;
                    gvdirectordetails.DataSource = dt;
                    gvdirectordetails.DataBind();
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
    protected void gvdirectordetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataSet dscountry = new DataSet();
            DataSet dspartner = new DataSet();
            DataSet dsstate = new DataSet();
            DataSet dsdistrict = new DataSet();
            DataSet dsGenders = new DataSet();


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                dsGenders = Gen.GetGender();
                dscountry = Gen.GetProfessionTaxCountries();//9
                dspartner = Gen.GetProfessionTaxpartnertype();//3
                //dsstate = Gen.GetProfessionTaxStates();//10
                dsstate = Gen.getStates();
               // dsdistrict = Gen.GetDistricts(); //GetProfessionTaxDistricts();//11
                Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
                dsdistrict = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFE");

                ddlpartnertype = (DropDownList)e.Row.Cells[3].Controls[1];
                ddldistrict = (DropDownList)e.Row.Cells[10].Controls[1];
                ddlcountry = (DropDownList)e.Row.Cells[8].Controls[1];
                ddlstate = (DropDownList)e.Row.Cells[9].Controls[1];
                DropDownList ddlGender = (DropDownList)e.Row.Cells[4].Controls[1];

                if (dspartner != null && dspartner.Tables.Count > 0 && dspartner.Tables[0].Rows.Count > 0)
                {
                    ddlpartnertype.DataSource = dspartner.Tables[0];
                    ddlpartnertype.DataValueField = "intStageid";
                    ddlpartnertype.DataTextField = "StageName";
                    ddlpartnertype.DataBind();
                }
                if (dscountry != null && dscountry.Tables.Count > 0 && dscountry.Tables[0].Rows.Count > 0)
                {
                    ddlcountry.DataSource = dscountry.Tables[0];
                    ddlcountry.DataValueField = "Countryid";
                    ddlcountry.DataTextField = "CountryName";
                    ddlcountry.DataBind();
                    ddlcountry.SelectedItem.Text = "India";
                    ddlcountry.SelectedValue = "1";
                    ddlcountry.Enabled = false;
                }

                if (dsstate != null && dsstate.Tables.Count > 0 && dsstate.Tables[0].Rows.Count > 0)
                {
                    ddlstate.DataSource = dsstate.Tables[0];
                    ddlstate.DataTextField = "State_Name";
                    ddlstate.DataValueField = "State_id";
                    ddlstate.DataBind();
                    ddlstate.SelectedValue = "31";
                    ddlstate.Enabled = false;
                }
                if (dsdistrict != null && dsdistrict.Tables.Count > 0 && dsdistrict.Tables[0].Rows.Count > 0)
                {
                    ddldistrict.DataSource = dsdistrict.Tables[0];
                    ddldistrict.DataValueField = "District_Id";
                    ddldistrict.DataTextField = "District_Name";
                    ddldistrict.DataBind();

                }
                if (dsGenders != null && dsGenders.Tables.Count > 0 && dsGenders.Tables[0].Rows.Count > 0)
                {
                    ddlGender.DataSource = dsGenders.Tables[0];
                    ddlGender.DataTextField = "Gender_Type";
                    ddlGender.DataValueField = "Gender_Id";
                    ddlGender.DataBind();
                }

                AddSelect(ddlpartnertype);
                AddSelect(ddlcountry);
                AddSelect(ddlstate);
                AddSelect(ddldistrict);
                AddSelect(ddlGender);

                DataTable dt = (DataTable)ViewState["dtDirectorDetails"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        GridViewRow gvr = e.Row;
                        TextBox txtName = (TextBox)gvr.FindControl("txtName");
                        TextBox txtdob = (TextBox)gvr.FindControl("txtdob");
                        TextBox txtdoor_no = (TextBox)gvr.FindControl("txtdoor_no");
                        TextBox txtpan = (TextBox)gvr.FindControl("txtpan");
                        TextBox txtroad = (TextBox)gvr.FindControl("txtroad");
                        TextBox txtcity = (TextBox)gvr.FindControl("txtcity");
                        TextBox txtpin = (TextBox)gvr.FindControl("txtpin");
                        TextBox txtaadharno = (TextBox)gvr.FindControl("txtaadhar");
                        TextBox txtemail = (TextBox)gvr.FindControl("txtemail");
                        TextBox txtmobileno = (TextBox)gvr.FindControl("txtmobileno");
                        TextBox txtstate = (TextBox)gvr.FindControl("txtstate");
                        TextBox txtdistrict = (TextBox)gvr.FindControl("txtdistrict");

                        // DropDownList ddlcountry = (DropDownList)gvr.FindControl("ddlcountry");
                        //binding through database
                        //  DropDownList ddlstate = (DropDownList)gvr.FindControl("ddlstate");
                        //end
                        //   DropDownList ddldistrict = (DropDownList)gvr.FindControl("ddldistrict");
                        txtName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        txtdob.Text = dt.Rows[e.Row.RowIndex]["dob"].ToString();
                        txtdoor_no.Text = dt.Rows[e.Row.RowIndex]["Doorno"].ToString();
                        txtpan.Text = dt.Rows[e.Row.RowIndex]["pan"].ToString();
                        txtroad.Text = dt.Rows[e.Row.RowIndex]["road"].ToString();
                        txtcity.Text = dt.Rows[e.Row.RowIndex]["city"].ToString();
                        txtpin.Text = dt.Rows[e.Row.RowIndex]["pin"].ToString();
                        ddlpartnertype.SelectedValue = dt.Rows[e.Row.RowIndex]["partnertype"].ToString();
                        ddlGender.SelectedValue = dt.Rows[e.Row.RowIndex]["Gender"].ToString();
                        ddlcountry.SelectedValue = dt.Rows[e.Row.RowIndex]["country"].ToString();
                        ddlstate.SelectedValue = dt.Rows[e.Row.RowIndex]["state"].ToString();
                        ddldistrict.SelectedValue = dt.Rows[e.Row.RowIndex]["district"].ToString();

                        txtaadharno.Text = dt.Rows[e.Row.RowIndex]["Aadhar"].ToString();
                        txtemail.Text = dt.Rows[e.Row.RowIndex]["Email"].ToString();
                        txtmobileno.Text = dt.Rows[e.Row.RowIndex]["Mobileno"].ToString();

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
    protected void gvbusinessplaces_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {

                DropDownList ddlstate = (DropDownList)e.Row.Cells[5].Controls[1];
                DropDownList ddldistrict = (DropDownList)e.Row.Cells[6].Controls[1];

                DataSet dsStates = new DataSet();
                DataSet dsDistricts = new DataSet();
                dsStates = Gen.getStates();
               // dsDistricts = Gen.GetDistricts();
                Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
                dsDistricts = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFE");

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (dsDistricts != null && dsDistricts.Tables.Count > 0 && dsDistricts.Tables[0].Rows.Count > 0)
                    {
                        ddldistrict.DataSource = dsDistricts.Tables[0];
                        ddldistrict.DataTextField = "District_Name";
                        ddldistrict.DataValueField = "District_Id";
                        ddldistrict.DataBind();
                    }

                    if (dsStates != null && dsStates.Tables.Count > 0 && dsStates.Tables[0].Rows.Count > 0)
                    {
                        ddlstate.DataSource = dsStates.Tables[0];
                        ddlstate.DataTextField = "State_Name";
                        ddlstate.DataValueField = "State_id";
                        ddlstate.DataBind();
                        ddlstate.SelectedValue = "31";
                        ddlstate.Enabled = false;
                    }




                    AddSelect(ddlstate);
                    AddSelect(ddldistrict);

                    // AddSelect(ddlOccupationAct1);
                    //  AddSelect(ddlGender);
                    DataTable dt = (DataTable)ViewState["dtBussinessPlaces"];

                    if (dt != null)
                    {
                        if (e.Row.RowIndex < dt.Rows.Count)
                        {
                            GridViewRow gvr = e.Row;
                            TextBox txtdoor_no = (TextBox)gvr.FindControl("txtdoor_no");
                            TextBox txtroad = (TextBox)gvr.FindControl("txtroad");
                            TextBox txtlocality = (TextBox)gvr.FindControl("txtlocality");
                            TextBox txtmandal = (TextBox)gvr.FindControl("txtmandal");
                            TextBox txtcity = (TextBox)gvr.FindControl("txtcity");
                            TextBox txtpin = (TextBox)gvr.FindControl("txtpin");

                            txtdoor_no.Text = dt.Rows[e.Row.RowIndex]["Doorno"].ToString();
                            txtroad.Text = dt.Rows[e.Row.RowIndex]["road"].ToString();
                            txtlocality.Text = dt.Rows[e.Row.RowIndex]["locality"].ToString();
                            txtmandal.Text = dt.Rows[e.Row.RowIndex]["mandal"].ToString();
                            txtcity.Text = dt.Rows[e.Row.RowIndex]["city"].ToString();
                            txtpin.Text = dt.Rows[e.Row.RowIndex]["pin"].ToString();

                            ddlstate.SelectedValue = dt.Rows[e.Row.RowIndex]["state"].ToString();
                            ddldistrict.SelectedValue = dt.Rows[e.Row.RowIndex]["district"].ToString();

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
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvbusinessplaces_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvbussinessplacesAdd();
                String[] arraydata = new String[8];

                int gvrcnt = gvbusinessplaces.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {
                    DropDownList ddlstate = (DropDownList)gvbusinessplaces.Rows[i].Cells[5].Controls[1];
                    DropDownList ddldistrict = (DropDownList)gvbusinessplaces.Rows[i].Cells[6].Controls[1];

                    GridViewRow gvr = gvbusinessplaces.Rows[i];

                    TextBox txtdoor_no = (TextBox)gvr.FindControl("txtdoor_no");

                    TextBox txtroad = (TextBox)gvr.FindControl("txtroad");
                    TextBox txtlocality = (TextBox)gvr.FindControl("txtlocality");
                    TextBox txtmandal = (TextBox)gvr.FindControl("txtmandal");
                    TextBox txtcity = (TextBox)gvr.FindControl("txtcity");
                    TextBox txtpin = (TextBox)gvr.FindControl("txtpin");
                    arraydata[0] = txtdoor_no.Text;
                    arraydata[1] = txtroad.Text;
                    arraydata[2] = txtlocality.Text;
                    arraydata[3] = txtmandal.Text;
                    arraydata[4] = ddlstate.SelectedValue;
                    arraydata[5] = ddldistrict.SelectedValue;
                    arraydata[6] = txtcity.Text;
                    arraydata[7] = txtpin.Text;


                    if (txtdoor_no.Text == "" || ddlstate.SelectedValue == "0" || ddldistrict.SelectedValue == "0" || txtroad.Text == "" || txtlocality.Text == "" || txtmandal.Text == "" || txtcity.Text == "" || txtpin.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        Failure.Visible = true;
                        lblmsg0.Visible = true;
                        lblmsg0.Text = "<font color=red> Please Enter Name & Address of other places of work Business...!</font>";
                        return;
                    }

                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtBussinessPlaces"] = dt;
                    gvbusinessplaces.DataSource = dt;
                    gvbusinessplaces.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvbusinessplaces.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvbussinessplacesAdd();
                    String[] arraydata = new String[8];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            DropDownList ddlstate = (DropDownList)gvbusinessplaces.Rows[i].Cells[5].Controls[1];
                            DropDownList ddldistrict = (DropDownList)gvbusinessplaces.Rows[i].Cells[6].Controls[1];

                            GridViewRow gvr = gvbusinessplaces.Rows[i];
                            TextBox txtdoor_no = (TextBox)gvr.FindControl("txtdoor_no");

                            TextBox txtroad = (TextBox)gvr.FindControl("txtroad");
                            TextBox txtlocality = (TextBox)gvr.FindControl("txtlocality");
                            TextBox txtmandal = (TextBox)gvr.FindControl("txtmandal");
                            TextBox txtcity = (TextBox)gvr.FindControl("txtcity");
                            TextBox txtpin = (TextBox)gvr.FindControl("txtpin");
                            arraydata[0] = txtdoor_no.Text;
                            arraydata[1] = txtroad.Text;
                            arraydata[2] = txtlocality.Text;
                            arraydata[3] = txtmandal.Text;
                            arraydata[4] = ddlstate.SelectedValue;
                            arraydata[5] = ddldistrict.SelectedValue;
                            arraydata[6] = txtcity.Text;
                            arraydata[7] = txtpin.Text;

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
                    ViewState["dtBussinessPlaces"] = dt;
                    gvbusinessplaces.DataSource = dt;
                    gvbusinessplaces.DataBind();
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

    protected DataTable BindgvbussinessplacesAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Doorno");
        dt.Columns.Add("road");
        dt.Columns.Add("locality");
        dt.Columns.Add("Mandal");
        dt.Columns.Add("state");
        dt.Columns.Add("district");
        dt.Columns.Add("city");
        dt.Columns.Add("pin");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
        dr[6] = "";
        dr[7] = "";

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

    protected DataTable BindgvdirectordetailsGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Directors");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }

    protected DataTable BindgvdirectordetailsGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Name");
        dt.Columns.Add("dob");
        dt.Columns.Add("partnertype");
        dt.Columns.Add("Gender");
        // dt.Columns.Add("HouseWife");
        dt.Columns.Add("Doorno");
        dt.Columns.Add("pan");
        dt.Columns.Add("road");
        dt.Columns.Add("country");
        dt.Columns.Add("state");
        dt.Columns.Add("district");
        dt.Columns.Add("city");
        dt.Columns.Add("pin");
        dt.Columns.Add("Aadhar");
        dt.Columns.Add("Email");
        dt.Columns.Add("MobileNo");

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
        dt.Rows.Add(dr);
        return dt;
    }

    protected DataTable BindgvbusinessplacesGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("BusinessPlaces");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        int valid = 0;
        if (txtpanindustrl.Text.Trim() == "")
        {
            lblmsg0.Visible = true;
            lblmsg0.Text += "<font color='red'>Please enter PAN of Industrial Undertaking...!</font>";
            valid = 1;
            SetFocus(txtpanindustrl);
            txtpanindustrl.Enabled = true;
        }
        if (ddlanualtrnovr.SelectedValue == "0")
        {
            lblmsg0.Visible = true;
            lblmsg0.Text += "<font color='red'>Please select ESTIMATED ANNUAL TURNOVER(Rupees)...!</font>";
            valid = 1;
            SetFocus(ddlanualtrnovr);
            ddlanualtrnovr.Enabled = true;
        }
        if (ddlBank.SelectedValue == "0")
        {
            lblmsg0.Visible = true;
            lblmsg0.Text += "<font color='red'>Please select Bank Name...!</font>";
            valid = 1;
            SetFocus(ddlBank);
            ddlanualtrnovr.Enabled = true;
        }
        if (txtAccNumber.Text.Trim() == "")
        {
            lblmsg0.Visible = true;
            lblmsg0.Text += "<font color='red'>Please enter Account Number...!</font>";
            valid = 1;
            SetFocus(txtAccNumber);
            txtAccNumber.Enabled = true;
        }
        if (txtIfscCode.Text.Trim() == "")
        {
            lblmsg0.Visible = true;
            lblmsg0.Text += "<font color='red'>Please enter IFSC Code...!</font>";
            valid = 1;
            SetFocus(txtIfscCode);
            txtIfscCode.Enabled = true;
        }
        if (txtBranchName.Text.Trim() == "")
        {
            lblmsg0.Visible = true;
            lblmsg0.Text += "<font color='red'>Please enter Branch...!</font>";
            valid = 1;
            SetFocus(txtBranchName);
            txtBranchName.Enabled = true;
        }
        if (gvdirectordetails.Rows.Count <= 1) // added = on 22.01.2021 not allow without entering details
        {
            lblmsg0.Visible = true;
            lblmsg0.Text += "<font color=red> Please Enter atleast one Details of all promoters/partners/Directors/others as applicable...!</font>";
            valid = 1;

        }
        if (gvbusinessplaces.Rows.Count <= 1) // added = on 22.01.2021 not allow without entering details
        {
            lblmsg0.Visible = true;
            lblmsg0.Text += "<font color=red> Please Enter atleast one Name & Address of other places of work Business...!</font>";
            valid = 1;
        }
        if (valid == 1)
        {
            Failure.Visible = true;
            lblmsg0.Visible = true;
            //lblmsg0.Text = lblmsg0.Text;
            return;
        }
        valid = SaveData();
        lblmsg.Text = "<font color='green'>Details Added Successfully..!</font>";
        lblmsg.Visible = true;
        Failure.Visible = false;

        Response.Redirect("frmAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPowerCeig.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int valid = 0;
            if (txtpanindustrl.Text.Trim() == "")
            {
                lblmsg0.Visible = true;
                lblmsg0.Text += "<font color='red'>Please enter PAN of Industrial Undertaking...!</font>";
                valid = 1;
                SetFocus(txtpanindustrl);
                txtpanindustrl.Enabled = true;
            }
            if (ddlanualtrnovr.SelectedValue == "0")
            {
                lblmsg0.Visible = true;
                lblmsg0.Text += "<font color='red'>Please select ESTIMATED ANNUAL TURNOVER(Rupees)...!</font>";
                valid = 1;
                SetFocus(ddlanualtrnovr);
                ddlanualtrnovr.Enabled = true;
            }
            if (ddlBank.SelectedValue == "0")
            {
                lblmsg0.Visible = true;
                lblmsg0.Text += "<font color='red'>Please select Bank Name...!</font>";
                valid = 1;
                SetFocus(ddlBank);
                ddlanualtrnovr.Enabled = true;
            }
            if (txtAccNumber.Text.Trim() == "")
            {
                lblmsg0.Visible = true;
                lblmsg0.Text += "<font color='red'>Please enter Account Number...!</font>";
                valid = 1;
                SetFocus(txtAccNumber);
                txtAccNumber.Enabled = true;
            }
            if (txtIfscCode.Text.Trim() == "")
            {
                lblmsg0.Visible = true;
                lblmsg0.Text += "<font color='red'>Please enter IFSC Code...!</font>";
                valid = 1;
                SetFocus(txtIfscCode);
                txtIfscCode.Enabled = true;
            }
            if (txtBranchName.Text.Trim() == "")
            {
                lblmsg0.Visible = true;
                lblmsg0.Text += "<font color='red'>Please enter Branch...!</font>";
                valid = 1;
                SetFocus(txtBranchName);
                txtBranchName.Enabled = true;
            }
            if (gvdirectordetails.Rows.Count < 1) 
            {
                lblmsg0.Visible = true;
                lblmsg0.Text += "<font color=red> Please Enter atleast one Details of all promoters/partners/Directors/others as applicable...!</font>";
                valid = 1;

            }
            if (gvbusinessplaces.Rows.Count < 1) 
            {
                lblmsg0.Visible = true;
                lblmsg0.Text += "<font color=red> Please Enter atleast one Name & Address of other places of work Business...!</font>";
                valid = 1;
            }
            if (gvdirectordetails.Rows.Count >= 1)
            {
                string errormsg = "";
                int slno = 0;
                foreach (GridViewRow row in gvdirectordetails.Rows)
                {
                    slno = slno + 1;
                    TextBox txtName = (TextBox)row.FindControl("txtName");

                    TextBox txtdob = (TextBox)row.FindControl("txtdob");
                    TextBox txtdoor_no = (TextBox)row.FindControl("txtdoor_no");
                    TextBox txtpan = (TextBox)row.FindControl("txtpan");
                    TextBox txtroad = (TextBox)row.FindControl("txtroad");
                    TextBox txtcity = (TextBox)row.FindControl("txtcity");
                    TextBox txtpin = (TextBox)row.FindControl("txtpin");
                    TextBox txtaadharno = (TextBox)row.FindControl("txtaadhar");
                    TextBox txtemail = (TextBox)row.FindControl("txtemail");
                    TextBox txtmobileno = (TextBox)row.FindControl("txtmobileno");
                    TextBox txtstate = (TextBox)row.FindControl("txtstate");
                    TextBox txtdistrict = (TextBox)row.FindControl("txtdistrict");

                    DropDownList ddlpatnertype = (DropDownList)row.FindControl("ddlpartnertype");// gvdirectordetails.Rows[i].Cells[3].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
                    DropDownList ddlGender = (DropDownList)row.FindControl("ddlGender");//gvdirectordetails.Rows[i].Cells[4].Controls[1];
                    DropDownList ddlcountry = (DropDownList)row.FindControl("ddlcountry");//gvdirectordetails.Rows[i].Cells[8].Controls[1];
                    DropDownList ddlstate = (DropDownList)row.FindControl("ddlstate");//gvdirectordetails.Rows[i].Cells[9].Controls[1];
                    DropDownList ddldistrict = (DropDownList)row.FindControl("ddldistrict");//gvdirectordetails.Rows[i].Cells[10].Controls[1];


                    if (txtdoor_no.Text == "" || txtdob.Text == "" || ddlpatnertype.SelectedValue == "0" || ddlGender.SelectedValue == "0" || txtdoor_no.Text == "" || txtpan.Text == "" || txtroad.Text == "" || ddlcountry.SelectedValue == "0" || ddlstate.SelectedValue == "0" || ddldistrict.SelectedValue == "0" || txtcity.Text == "" || txtpin.Text == "" || txtaadharno.Text == "" || txtemail.Text == "" || txtmobileno.Text == "")// || txtEnjExtent.Value == "")
                    {
                        errormsg = errormsg + "Rows" + slno + ") Please Enter Name & Address of other places of work Business...!";
                    }
                }
                lblmsg0.Visible = true;
                lblmsg0.Text += "<font color=red>" + errormsg + "</font>";
                valid = 1;
            }
            if (gvbusinessplaces.Rows.Count >= 1)
            {
                string errormsg = "";
                int slno = 0;

                foreach (GridViewRow row in gvbusinessplaces.Rows)
                {
                    slno = slno + 1;
                    //TextBox txtdoor_no = (TextBox)row.FindControl("txtdoor_no");
                    TextBox txtdoor_no = (TextBox)row.FindControl("txtdoor_no");

                    TextBox txtroad = (TextBox)row.FindControl("txtroad");
                    TextBox txtlocality = (TextBox)row.FindControl("txtlocality");
                    TextBox txtmandal = (TextBox)row.FindControl("txtmandal");
                    TextBox txtcity = (TextBox)row.FindControl("txtcity");
                    TextBox txtpin = (TextBox)row.FindControl("txtpin");

                    if (txtdoor_no.Text == "" || ddlstate.SelectedValue == "0" || ddldistrict.SelectedValue == "0" || txtroad.Text == "" || txtlocality.Text == "" || txtmandal.Text == "" || txtcity.Text == "" || txtpin.Text == "")// || txtEnjExtent.Value == "")
                    {

                        errormsg = errormsg + "Rows" + slno + ") Please Enter Name & Address of other places of work Business...!";
                    }

                }
                lblmsg0.Visible = true;
                lblmsg0.Text += "<font color=red>" + errormsg + "</font>";
                valid = 1;

            }
            if (valid == 1)
            {
                Failure.Visible = true;

                //lblmsg0.Visible = true;
                //lblmsg0.Text = lblmsg0.Text;
                return;
            }
            valid = SaveData();
            success.Visible = true;
            Failure.Visible = false;
            lblmsg.Text = "<font color='green'>Details Added Successfully..!</font>";
            lblmsg.Visible = true;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected int SaveData()
    {
        General objGen = new General();
        proffecionaltaxBankDetails objvo = new proffecionaltaxBankDetails();
        objvo.BankName = ddlBank.SelectedValue;
        objvo.BranchName = txtBranchName.Text.ToUpper();
        objvo.AccNo = txtAccNumber.Text.ToUpper();
        objvo.IFSCCode = txtIfscCode.Text.ToUpper();
        objvo.ESTimatedannualturnover = ddlanualtrnovr.SelectedValue;
        objvo.panofindustrial = txtpanindustrl.Text;
        objvo.QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
        objvo.CreatedBy = Convert.ToInt32(Session["uid"].ToString().Trim());
        objvo.modified = Convert.ToInt32(Session["uid"].ToString().Trim());
        objvo.Intenterprenuerid = Convert.ToInt32(Request.QueryString[0].ToString());

        //objGen.insertProfesstaxbankdetails(objvo);
        //16 parameters
        foreach (GridViewRow gvrow in gvdirectordetails.Rows)
        {
            Professiontaxpromoterdetails objProftaxpromoterdetails = new Professiontaxpromoterdetails();
            TextBox txtName = (TextBox)gvrow.FindControl("txtName");
            TextBox txtdob = (TextBox)gvrow.FindControl("txtdob");
            TextBox txtdoor_no = (TextBox)gvrow.FindControl("txtdoor_no");
            TextBox txtpan = (TextBox)gvrow.FindControl("txtpan");
            TextBox txtroad = (TextBox)gvrow.FindControl("txtroad");
            TextBox txtcity = (TextBox)gvrow.FindControl("txtcity");
            TextBox txtpin = (TextBox)gvrow.FindControl("txtpin");
            DropDownList ddlcountry = (DropDownList)gvrow.FindControl("ddlcountry");
            DropDownList ddlstate = (DropDownList)gvrow.FindControl("ddlstate");
            DropDownList ddldistrict = (DropDownList)gvrow.FindControl("ddldistrict");
            DropDownList ddlpartnertype = (DropDownList)gvrow.FindControl("ddlpartnertype");
            DropDownList ddlGender = (DropDownList)gvrow.FindControl("ddlGender");
            TextBox txtaadharno = (TextBox)gvrow.FindControl("txtaadhar");
            TextBox txtemail = (TextBox)gvrow.FindControl("txtemail");
            TextBox txtmobileno = (TextBox)gvrow.FindControl("txtmobileno");

            //if (txtdoor_no.Text == "" || txtdob.Text == "" || ddlpartnertype.SelectedValue == "0" || ddlGender.SelectedValue == "0" || txtdoor_no.Text == "" || txtpan.Text == "" || txtroad.Text == "" || ddlcountry.SelectedValue == "0" || ddlstate.SelectedValue == "0" || ddldistrict.SelectedValue == "0" || txtcity.Text == "" || txtpin.Text == "" || txtaadharno.Text == "" || txtemail.Text == "" || txtmobileno.Text == "")// || txtEnjExtent.Value == "")
            //{
            //    //valid = 1;
            //    Failure.Visible = true;
            //    lblmsg0.Visible = true;
            //    lblmsg0.Text = "<font color=red> Please Enter Details of all promoters/partners/Directors/others as applicable...!</font>";
            //    return;
            //}

            if (txtName.Text.Trim() != "")
            {

                objProftaxpromoterdetails.Name = txtName.Text;
                string dob = "";
                if (txtdob.Text != "")
                {
                    string[] newdate = txtdob.Text.Trim().Split('-');
                    dob = newdate[1].ToString() + "/" + newdate[0].ToString() + "/" + newdate[2].ToString();// +" " + date[1].ToString();
                }

                objProftaxpromoterdetails.dob = dob;
                objProftaxpromoterdetails.Doorno = txtdoor_no.Text;
                objProftaxpromoterdetails.pan = txtpan.Text;
                objProftaxpromoterdetails.road = txtroad.Text;
                objProftaxpromoterdetails.city = txtcity.Text;
                objProftaxpromoterdetails.pin = txtpin.Text;
                objProftaxpromoterdetails.country = ddlcountry.SelectedValue;
                objProftaxpromoterdetails.state = ddlstate.SelectedValue;
                objProftaxpromoterdetails.district = ddldistrict.SelectedValue;
                objProftaxpromoterdetails.patnertype = ddlpartnertype.SelectedValue;
                objProftaxpromoterdetails.gender = ddlGender.SelectedValue;
                objProftaxpromoterdetails.CreatedBy = Convert.ToInt32(Session["uid"].ToString().Trim());
                objProftaxpromoterdetails.modified = Convert.ToInt32(Session["uid"].ToString().Trim());
                objProftaxpromoterdetails.Intenterprenuerid = Convert.ToInt32(Request.QueryString[0].ToString());
                objProftaxpromoterdetails.QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
                objProftaxpromoterdetails.Email = txtemail.Text.Trim();
                objProftaxpromoterdetails.AadharNo = txtaadharno.Text.Trim();
                objProftaxpromoterdetails.MobileNo = txtmobileno.Text.Trim();

                listProftaxpromotional.Add(objProftaxpromoterdetails);
            }
        }
        //12 parameters
        foreach (GridViewRow gvrow in gvbusinessplaces.Rows)
        {
            Professiontaxaddressdetails objProftaxAdress = new Professiontaxaddressdetails();
            TextBox txtdoor_no = (TextBox)gvrow.FindControl("txtdoor_no");
            TextBox txtroad = (TextBox)gvrow.FindControl("txtroad");
            TextBox txtlocality = (TextBox)gvrow.FindControl("txtlocality");
            TextBox txtmandal = (TextBox)gvrow.FindControl("txtmandal");
            TextBox txtcity = (TextBox)gvrow.FindControl("txtcity");
            TextBox txtpin = (TextBox)gvrow.FindControl("txtpin");
            DropDownList ddlstate = (DropDownList)gvrow.FindControl("ddlstate");
            DropDownList ddldistrict = (DropDownList)gvrow.FindControl("ddldistrict");
            if (txtdoor_no.Text.Trim() != "")
            {
                objProftaxAdress.Doorno = txtdoor_no.Text.Trim();
                objProftaxAdress.road = txtroad.Text.Trim();
                objProftaxAdress.locality = txtlocality.Text.Trim();
                objProftaxAdress.mandal = txtmandal.Text.Trim();
                objProftaxAdress.city = txtcity.Text.Trim();
                objProftaxAdress.pin = txtpin.Text.Trim();
                objProftaxAdress.state = ddlstate.SelectedValue;
                objProftaxAdress.district = ddldistrict.SelectedValue;
                objProftaxAdress.QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
                objProftaxAdress.Intenterprenuerid = Convert.ToInt32(Request.QueryString[0].ToString());
                objProftaxAdress.CreatedBy = Convert.ToInt32(Session["uid"].ToString().Trim());
                objProftaxAdress.modified = Convert.ToInt32(Session["uid"].ToString().Trim());
                listproftaxAdressDetails.Add(objProftaxAdress);
            }
        }

        int valid = 0;
        int i = objGen.InsertProfessionalTaxDetails(objvo, listproftaxAdressDetails, listProftaxpromotional);
        return valid;


    }
}