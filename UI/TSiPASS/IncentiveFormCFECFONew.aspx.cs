using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class UI_TSiPASS_IncentiveFormCFECFONew : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    CommonBL objcommon = new CommonBL();
    string Applicanttype;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                BindDistricts();
                BindLineofActivityName();
                rblSector.SelectedValue = "2";
                rblSector_SelectedIndexChanged(this, EventArgs.Empty);
                trdistrict.Visible = true;
                ddlProp_intDistrictid.SelectedValue = Request.QueryString["district"].ToString();
                ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                ddlProp_intMandalid.SelectedValue = Request.QueryString["Mandal"].ToString();
                ddlintLineofActivity.SelectedValue = Request.QueryString["LOA"].ToString();
                txtnameofunit.Text = Request.QueryString["unitname"].ToString();
                BtnSave1_Click(this, EventArgs.Empty);
                RBTISMSMEUNIT.SelectedValue = "1";
                RBTISMSMEUNIT.Enabled = false;
                RBTISMSMEUNIT_SelectedIndexChanged(this, EventArgs.Empty);
            }

            else
            {
                BindDistricts();
                BindLineofActivityName();
            }
        }
    }

    public void BindDistricts()
    {
        try
        {
            //DataSet dsd = new DataSet();
            //ddlProp_intDistrictid.Items.Clear();
            //dsd = Gen.GetDistrictsWithoutHYD();
            Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "INC");
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                ddlProp_intDistrictid.Items.Insert(0, "--District--");
            }
            else
            {
                ddlProp_intDistrictid.Items.Insert(0, "--District--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void rblSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblSector.SelectedValue == "3")
            {
                tdTrans1.Visible = false;
                tdTrans2.Visible = false;
                trTrans.Visible = false;
                trvehicleno.Visible = false;
                trlineofactivity.Visible = false;
                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    //Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                    string uidno = dscheck.Tables[2].Rows[0]["UID_No"].ToString().Trim();
                    //Session["intCFEEnterpid"] = dscheck.Tables[3].Rows[0]["intCFEEnterpid"].ToString().Trim();
                    if (uidno != "")
                    {
                        checkUID.Visible = false;
                        if (Session["userlevel"].ToString() == "13")
                        {
                            string UserId = Session["user_id"].ToString();
                            string Password = Session["password"].ToString();
                            string Flag = Session["PwdEncryflag"].ToString();
                            string CreateBy = Session["uid"].ToString();
                            string Role = Session["Role_Code"].ToString();
                            string User_level = Session["userlevel"].ToString();
                            string Fromname = Session["Type"].ToString();
                            string DistrictID = Session["DistrictID"].ToString();
                            string User_type = Session["user_type"].ToString();
                        // HyperLink h1 = (HyperLink)e.Row.FindControl("hypLetter");
                        //string NavigateUrl = "http://120.138.9.236/TTAP/loginReg.aspx?UserId=" + UserID + "&UserCode=" + Password + "&Flg=" + Flag;//"IncetivesNewForm2.aspx?ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID"));
                        //Response.Redirect("http://120.138.9.236/TTAP/loginReg.aspx?UserId=" + UserID + "&UserCode=" + Password + "&Flg=" + Flag);
                      
                            //http://www.ttap.telangana.gov.in/TTAPTEST/loginReg.aspx
                            Response.Redirect("https://ttap.telangana.gov.in/TTAP/loginReg.aspx?UserId=" + UserId + "&UserCode=" + Password + "&Flg=Y&CreateBy=" +
                                CreateBy + "&Role=" + Role + "&User_level=" + User_level + "&Fromname=" + Fromname + "&DistrictID=" + DistrictID + "&User_type=" + User_type);
                        }
                    }

                }
                else
                {
                    checkUID.Visible = true;
                    BtnSave1.Enabled = false;


                }

            }

            else if (rblSector.SelectedValue == "1")  // Not manufacture
            {
                //trvehicleno.Visible = true;
                //btnnext.Visible = true;
                //btnnext.Text = "Next";
                btnnext.Enabled = true;
                trdistrict.Visible = false;
                ddlProp_intDistrictid.ClearSelection();
                ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                trlineofactivity.Visible = false;
                ddlintLineofActivity.ClearSelection();
                txtnameofunit.Text = "";
                checkUID.Visible = false;
                tdTrans1.Visible = false;
                tdTrans2.Visible = false;
                trTrans.Visible = false;
                BtnSave1.Text = "Search";
                BtnSave1.Enabled = false;
                BtnSave1.Visible = false;
                btnnext.Visible = true;
                TRISMSMEUNIT.Visible = false;
                RBTISMSMEUNIT.ClearSelection();
                TRMSMEUNITNAME.Visible = false;
                DDLMSMEUNITNAME.ClearSelection();
                //trvehicleno.Visible = true;
            }
            else
            {
                tdTrans1.Visible = false;
                tdTrans2.Visible = false;
                trTrans.Visible = false;
                trvehicleno.Visible = false;
                trdistrict.Visible = true;
                trlineofactivity.Visible = true;
                trvehicleno.Visible = false;
                BtnSave1.Text = "Search";
                tdLineofActivity.Visible = true;
                tdLineofActivity1.Visible = true;

                BtnSave1.Enabled = true;
                btnnext.Visible = false;
                BtnSave1.Visible = true;
                checkUID.Visible = false;
                //Getchildandparentdata_Auto(Session["uid"].ToString());
                BINDUSERDATA();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
            //Response.Write(ex);
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public void BINDUSERDATA()
    {
        DataSet USERDATA = new DataSet();
        USERDATA = GETUSERDATABYID(Session["uid"].ToString());

        if (USERDATA.Tables.Count > 0)
        {
            if (USERDATA.Tables.Count == 2)
            {
                Applicanttype = Convert.ToString(USERDATA.Tables[1].Rows[0]["ApplicationTypeDB"]).Trim();
                HDNAPPLICATIONTYPE.Value = Applicanttype;
                if (Applicanttype == "UserNotexist")
                {
                    //ddlProp_intDistrictid.ClearSelection();
                    //ddlProp_intMandalid.ClearSelection();
                    //ddlintLineofActivity.ClearSelection();
                    //txtnameofunit.Text = "";
                    if (Session["uid"].ToString() == "122996")
                    {
                        ddlProp_intDistrictid.Enabled = false;
                        ddlProp_intMandalid.Enabled = false;
                        ddlintLineofActivity.Enabled = false;
                        txtnameofunit.Enabled = false;
                        ddlProp_intDistrictid.SelectedValue = USERDATA.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim();
                        ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlProp_intMandalid.SelectedValue = USERDATA.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim();
                        ddlintLineofActivity.SelectedValue = USERDATA.Tables[0].Rows[0]["LOAID"].ToString().Trim();
                        txtnameofunit.Text = USERDATA.Tables[0].Rows[0]["nameofunit"].ToString().Trim();
                        BtnSave1_Click(this, EventArgs.Empty);
                        RBTISMSMEUNIT.SelectedValue = "1";
                        RBTISMSMEUNIT.Enabled = false;
                        RBTISMSMEUNIT_SelectedIndexChanged(this, EventArgs.Empty);
                        string MSMENO_CFE = Convert.ToString(USERDATA.Tables[0].Rows[0]["MSMENO"]);
                        System.Web.UI.WebControls.ListItem selectedCentreactivestatus = DDLMSMEUNITNAME.Items.FindByValue(MSMENO_CFE);
                        if (selectedCentreactivestatus != null)
                        {
                            DDLMSMEUNITNAME.SelectedValue = MSMENO_CFE;
                        }
                        DDLMSMEUNITNAME_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    else
                    {
                        ddlProp_intDistrictid.ClearSelection();
                        ddlProp_intMandalid.ClearSelection();
                        ddlintLineofActivity.ClearSelection();
                        txtnameofunit.Text = "";
                    }
                }
                else if (Applicanttype == "CFE")
                {

                    //ddlProp_intDistrictid.Enabled = false;
                    //ddlProp_intMandalid.Enabled = false;
                    //ddlintLineofActivity.Enabled = false;
                    //txtnameofunit.Enabled = false;
                    ddlProp_intDistrictid.SelectedValue = USERDATA.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim();
                    ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlProp_intMandalid.SelectedValue = USERDATA.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim();
                    ddlintLineofActivity.SelectedValue = USERDATA.Tables[0].Rows[0]["LOAID"].ToString().Trim();
                    txtnameofunit.Text = USERDATA.Tables[0].Rows[0]["nameofunit"].ToString().Trim();
                    BtnSave1_Click(this, EventArgs.Empty);
                    RBTISMSMEUNIT.SelectedValue = "1";
                    RBTISMSMEUNIT.Enabled = false;
                    RBTISMSMEUNIT_SelectedIndexChanged(this, EventArgs.Empty);


                }
                else if (Applicanttype == "CFO")
                {

                    //ddlProp_intDistrictid.Enabled = false;
                    //ddlProp_intMandalid.Enabled = false;
                    //ddlintLineofActivity.Enabled = false;
                    //txtnameofunit.Enabled = false;
                    ddlProp_intDistrictid.SelectedValue = USERDATA.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim();
                    ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlProp_intMandalid.SelectedValue = USERDATA.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim();
                    ddlintLineofActivity.SelectedValue = USERDATA.Tables[0].Rows[0]["LOAID"].ToString().Trim();
                    txtnameofunit.Text = USERDATA.Tables[0].Rows[0]["nameofunit"].ToString().Trim();
                    BtnSave1_Click(this, EventArgs.Empty);
                    RBTISMSMEUNIT.SelectedValue = "1";
                    RBTISMSMEUNIT.Enabled = false;
                    RBTISMSMEUNIT_SelectedIndexChanged(this, EventArgs.Empty);

                }
                else if (Applicanttype == "UserExist")
                {

                    ddlProp_intDistrictid.ClearSelection();
                    ddlProp_intMandalid.ClearSelection();
                    ddlintLineofActivity.ClearSelection();
                    txtnameofunit.Text = "";
                }
                else if (Applicanttype == "MSMECFOExist")
                {
                    if (USERDATA.Tables[0].Rows[0]["OFFLINE"].ToString().Trim() == "Y")
                    {

                        ddlProp_intDistrictid.Enabled = false;
                        ddlProp_intMandalid.Enabled = false;
                        ddlintLineofActivity.Enabled = false;
                        txtnameofunit.Enabled = false;
                        ddlProp_intDistrictid.SelectedValue = USERDATA.Tables[0].Rows[0]["UnitDIst"].ToString().Trim();
                        ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlProp_intMandalid.SelectedValue = USERDATA.Tables[0].Rows[0]["UnitMandal"].ToString().Trim();
                        txtnameofunit.Text = USERDATA.Tables[0].Rows[0]["UnitName"].ToString().Trim();
                        ddlintLineofActivity.SelectedValue = USERDATA.Tables[0].Rows[0]["LOAID"].ToString().Trim();
                        BtnSave1_Click(this, EventArgs.Empty);
                        RBTISMSMEUNIT.SelectedValue = "1";
                        RBTISMSMEUNIT.Enabled = false;
                        RBTISMSMEUNIT_SelectedIndexChanged(this, EventArgs.Empty);
                        ///DDLMSMEUNITNAME.SelectedValue = USERDATA.Tables[0].Rows[0]["MSMENO"].ToString().Trim();
                        string MSMENO_CFO = Convert.ToString(USERDATA.Tables[0].Rows[0]["MSMENO"]);
                        System.Web.UI.WebControls.ListItem selectedCentreactivestatus = DDLMSMEUNITNAME.Items.FindByValue(MSMENO_CFO);
                        if (selectedCentreactivestatus != null)
                        {
                            DDLMSMEUNITNAME.SelectedValue = MSMENO_CFO;
                        }
                        DDLMSMEUNITNAME_SelectedIndexChanged(this, EventArgs.Empty);

                    }
                    else
                    {

                        ddlProp_intDistrictid.Enabled = false;
                        ddlProp_intMandalid.Enabled = false;
                        ddlintLineofActivity.Enabled = false;
                        txtnameofunit.Enabled = false;
                        ddlProp_intDistrictid.SelectedValue = USERDATA.Tables[0].Rows[0]["UnitDIst"].ToString().Trim();
                        ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlProp_intMandalid.SelectedValue = USERDATA.Tables[0].Rows[0]["UnitMandal"].ToString().Trim();
                        ddlintLineofActivity.SelectedValue = USERDATA.Tables[0].Rows[0]["LOAID"].ToString().Trim();
                        txtnameofunit.Text = USERDATA.Tables[0].Rows[0]["UnitName"].ToString().Trim();
                        BtnSave1_Click(this, EventArgs.Empty);
                        RBTISMSMEUNIT.SelectedValue = "1";
                        RBTISMSMEUNIT.Enabled = false;
                        RBTISMSMEUNIT_SelectedIndexChanged(this, EventArgs.Empty);
                        ///DDLMSMEUNITNAME.SelectedValue = USERDATA.Tables[0].Rows[0]["MSMENO"].ToString().Trim();
                        string MSMENO_CFO = Convert.ToString(USERDATA.Tables[0].Rows[0]["MSMENO"]);
                        System.Web.UI.WebControls.ListItem selectedCentreactivestatus = DDLMSMEUNITNAME.Items.FindByValue(MSMENO_CFO);
                        if (selectedCentreactivestatus != null)
                        {
                            DDLMSMEUNITNAME.SelectedValue = MSMENO_CFO;
                        }
                        DDLMSMEUNITNAME_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    //ddlProp_intDistrictid.SelectedValue = USERDATA.Tables[0].Rows[0]["UnitDIst"].ToString().Trim();
                    //ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                    //ddlProp_intMandalid.SelectedValue = USERDATA.Tables[0].Rows[0]["UnitMandal"].ToString().Trim();
                    //ddlintLineofActivity.SelectedValue = USERDATA.Tables[0].Rows[0]["LOAID"].ToString().Trim();
                    //txtnameofunit.Text = USERDATA.Tables[0].Rows[0]["UnitName"].ToString().Trim();
                    //BtnSave1_Click(this, EventArgs.Empty);
                    //RBTISMSMEUNIT.SelectedValue = "1";
                    //RBTISMSMEUNIT.Enabled = false;
                    //RBTISMSMEUNIT_SelectedIndexChanged(this, EventArgs.Empty);
                    /////DDLMSMEUNITNAME.SelectedValue = USERDATA.Tables[0].Rows[0]["MSMENO"].ToString().Trim();
                    //string MSMENO_CFO = Convert.ToString(USERDATA.Tables[0].Rows[0]["MSMENO"]);
                    //System.Web.UI.WebControls.ListItem selectedCentreactivestatus = DDLMSMEUNITNAME.Items.FindByValue(MSMENO_CFO);
                    //if (selectedCentreactivestatus != null)
                    //{
                    //    DDLMSMEUNITNAME.SelectedValue = MSMENO_CFO;
                    //}
                    //DDLMSMEUNITNAME_SelectedIndexChanged(this, EventArgs.Empty);
                }
                else
                {
                    if (USERDATA.Tables[0].Rows[0]["OFFLINE"].ToString().Trim() == "Y")
                    {

                        ddlProp_intDistrictid.Enabled = false;
                        ddlProp_intMandalid.Enabled = false;
                        ddlintLineofActivity.Enabled = false;
                        txtnameofunit.Enabled = false;
                        ddlProp_intDistrictid.SelectedValue = USERDATA.Tables[0].Rows[0]["UnitDIst"].ToString().Trim();
                        ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlProp_intMandalid.SelectedValue = USERDATA.Tables[0].Rows[0]["UnitMandal"].ToString().Trim();
                        txtnameofunit.Text = USERDATA.Tables[0].Rows[0]["UnitName"].ToString().Trim();
                        ddlintLineofActivity.SelectedValue = USERDATA.Tables[0].Rows[0]["LOAID"].ToString().Trim();
                        DDLMSMEUNITNAME_SelectedIndexChanged(this, EventArgs.Empty);

                    }
                    else
                    {

                        ddlProp_intDistrictid.Enabled = false;
                        ddlProp_intMandalid.Enabled = false;
                        ddlintLineofActivity.Enabled = false;
                        txtnameofunit.Enabled = false;
                        ddlProp_intDistrictid.SelectedValue = USERDATA.Tables[0].Rows[0]["UnitDIst"].ToString().Trim();
                        ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlProp_intMandalid.SelectedValue = USERDATA.Tables[0].Rows[0]["UnitMandal"].ToString().Trim();
                        ddlintLineofActivity.SelectedValue = USERDATA.Tables[0].Rows[0]["LOAID"].ToString().Trim();
                        txtnameofunit.Text = USERDATA.Tables[0].Rows[0]["UnitName"].ToString().Trim();
                        BtnSave1_Click(this, EventArgs.Empty);
                        RBTISMSMEUNIT.SelectedValue = "1";
                        RBTISMSMEUNIT.Enabled = false;
                        RBTISMSMEUNIT_SelectedIndexChanged(this, EventArgs.Empty);
                        // DDLMSMEUNITNAME.SelectedValue = USERDATA.Tables[0].Rows[0]["MSMENO"].ToString().Trim();
                        string MSMENO_CFE = Convert.ToString(USERDATA.Tables[0].Rows[0]["MSMENO"]);
                        System.Web.UI.WebControls.ListItem selectedCentreactivestatus = DDLMSMEUNITNAME.Items.FindByValue(MSMENO_CFE);
                        if (selectedCentreactivestatus != null)
                        {
                            DDLMSMEUNITNAME.SelectedValue = MSMENO_CFE;
                        }
                        DDLMSMEUNITNAME_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                }
            }
            else
            {
                //user not exist
                ddlProp_intDistrictid.ClearSelection();
                ddlProp_intMandalid.ClearSelection();
                ddlintLineofActivity.ClearSelection();
                txtnameofunit.Text = "";
            }
        }
        else
        {
            //user not exist
            ddlProp_intDistrictid.ClearSelection();
            ddlProp_intMandalid.ClearSelection();
            ddlintLineofActivity.ClearSelection();
            txtnameofunit.Text = "";
        }


    }
    public DataSet GETUSERDATABYID(string createdby)
    {

        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[]
       {
             new SqlParameter("@createdby",SqlDbType.VarChar)
       };
        pp[0].Value = createdby;

        Dsnew = Gen.GenericFillDs("SP_GETUSERDETAILS", pp);
        return Dsnew;
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //if (rblSector.SelectedValue == "3")
                    //{
                    //    if (Session["user_id"].ToString() == "30978" || Session["user_id"].ToString() == "43266" || Session["user_id"].ToString() == "47115" || Session["user_id"].ToString() == "48329" || Session["user_id"].ToString() == "48519")
                    //    {
                    //        string UserID = Session["user_id"].ToString();
                    //        string Password = Session["password"].ToString();
                    //        string Flag = Session["PwdEncryflag"].ToString();

                    //        HyperLink h1 = (HyperLink)e.Row.FindControl("hypLetter");
                    //        h1.NavigateUrl = "http://120.138.9.236/TTAP/loginReg.aspx?UserId=" + UserID + "&UserCode=" + Password + "&Flg=" + Flag;//"IncetivesNewForm2.aspx?ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID"));
                    //        h1.Text = "Apply Incentives";
                    //        //Response.Redirect("http://120.138.9.236/TTAP/loginReg.aspx?UserId=" + UserID + "&UserCode=" + Password + "&Flg=" + Flag);
                    //    }
                    //    //break;
                    //}
                    //else
                    //{
                    HyperLink h1 = (HyperLink)e.Row.FindControl("hypLetter");
                    if (rblSector.SelectedValue == "2" || rblSector.SelectedValue == "1")
                    {
                        if (rblSector.SelectedValue == "2")
                        {

                            //h1.NavigateUrl = "IncetivesNewForm2.aspx?ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID")) + "&unitName=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Name of the Industry")) + "&createdBy=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "createdBy") + "&vehicleNo");
                            h1.NavigateUrl = "IncetivesNewForm2.aspx?ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID")) + "&unitName=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Name of the Industry") + "&MSMENO=" + DDLMSMEUNITNAME.SelectedValue.ToString());
                            h1.Text = "Apply Incentives";
                        }
                        else if (rblSector.SelectedValue == "1")
                        {

                            //h1.NavigateUrl = ("IncetivesNewForm2.aspx?district=" + ddlProp_intDistrictid.SelectedValue.ToString() + "&Mandal=" + ddlProp_intMandalid.SelectedValue.ToString() + "&village=" + ddlVillage.SelectedValue.ToString() + "&vehicle=" + txtregistrationno.Text.ToString() + "&rblSector=" + rblSector.SelectedValue.ToString() + "&isVehicle=" + rblVeh.SelectedIndex.ToString() + "&createdBy=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "createdBy")));
                            //h1.Text = "Apply Incentives";
                        }

                    }
                    //else
                    //{
                    //    //if (Session["user_id"].ToString() == "30978" || Session["user_id"].ToString() == "43266" || Session["user_id"].ToString() == "47115" || Session["user_id"].ToString() == "48329" || Session["user_id"].ToString() == "48519")
                    //    //{
                    //    if(Session["userlevel"]=="13")
                    //    {
                    //        string UserID = Session["user_id"].ToString();
                    //        string Password = Session["password"].ToString();
                    //        string Flag = Session["PwdEncryflag"].ToString();

                    //       // HyperLink h1 = (HyperLink)e.Row.FindControl("hypLetter");
                    //        h1.NavigateUrl = "http://120.138.9.236/TTAP/loginReg.aspx?UserId=" + UserID + "&UserCode=" + Password + "&Flg=" + Flag;//"IncetivesNewForm2.aspx?ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID"));
                    //        h1.Text = "Apply Incentives";
                    //        //Response.Redirect("http://120.138.9.236/TTAP/loginReg.aspx?UserId=" + UserID + "&UserCode=" + Password + "&Flg=" + Flag);
                    //    }
                    //}
                    if (grdDetails.Rows.Count == 0)
                    {
                        string error = IncentiveCFECFO(rblSector.SelectedValue, ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue, ddlintLineofActivity.SelectedValue,
                              Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Name of the Industry")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Activity Proposed")),
                              Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Line of Activity")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Total Investment")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Date of application")),
                              Session["uid"].ToString());

                    }

                    // }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet dsn = new DataSet();
            if (rblSector.SelectedIndex.ToString() == "2" && HDNAPPLICATIONTYPE.Value != "UserExist")
            {
                //TRISMSMEUNIT.Visible = true;
                //RBTISMSMEUNIT.ClearSelection();

                if (Session["uid"].ToString() == "122996")
                {
                    dsn = Getchildandparentdata(rblSector.SelectedIndex.ToString(), ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue, "", ddlintLineofActivity.SelectedValue, txtnameofunit.Text.Trim(), rblVeh.SelectedIndex.ToString());
                    if (dsn != null && dsn.Tables.Count > 0 && dsn.Tables[0].Rows.Count > 0)
                    {
                        grdDetails.DataSource = dsn.Tables[0];
                        grdDetails.DataBind();
                        grdDetails.Visible = true;
                    }
                    else
                    {
                        grdDetails.DataSource = null;
                        grdDetails.DataBind();
                        grdDetails.Visible = false;
                        BtnSave1.Visible = false;
                        trFirstTrans.Visible = true;
                        BtnSave1.Text = "Next";
                    }
                }
                else
                {
                    TRISMSMEUNIT.Visible = true;
                    RBTISMSMEUNIT.ClearSelection();
                }
                //dsn = Getchildandparentdata(rblSector.SelectedIndex.ToString(), ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue, "", ddlintLineofActivity.SelectedValue, txtnameofunit.Text.Trim(), rblVeh.SelectedIndex.ToString());
                //if (dsn != null && dsn.Tables.Count > 0 && dsn.Tables[0].Rows.Count > 0)
                //{
                //    TRISMSMEUNIT.Visible = true;
                //    if(RBTISMSMEUNIT.SelectedValue=="1")
                //    {
                //        grdDetails.DataSource = dsn.Tables[0];
                //        grdDetails.DataBind();
                //        grdDetails.Visible = true;
                //    }
                //    else
                //    {
                //        grdDetails.DataSource = null;
                //        grdDetails.DataBind();
                //        grdDetails.Visible = false;
                //    }

                //}
                //else
                //{
                //    TRISMSMEUNIT.Visible = true;
                //    grdDetails.DataSource = null;
                //    grdDetails.DataBind();
                //    grdDetails.Visible = false;
                //}
            }
            else if (HDNAPPLICATIONTYPE.Value == "UserExist")
            {
                dsn = Getchildandparentdata(rblSector.SelectedIndex.ToString(), ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue, "", ddlintLineofActivity.SelectedValue, txtnameofunit.Text.Trim(), rblVeh.SelectedIndex.ToString());
                if (dsn != null && dsn.Tables.Count > 0 && dsn.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = dsn.Tables[0];
                    grdDetails.DataBind();
                    grdDetails.Visible = true;
                }
                else
                {
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                    grdDetails.Visible = false;
                    BtnSave1.Visible = false;
                    trFirstTrans.Visible = true;
                    BtnSave1.Text = "Next";
                }
            }
            else if (rblSector.SelectedIndex.ToString() == "1" && rblVeh.SelectedIndex.ToString() == "0" && txtregistrationno.Text != "" && trFirstTrans.Visible == false && chkTransportDeclare.Checked == false)
            {
                dsn = Getchildandparentdata(rblSector.SelectedIndex.ToString(), ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue, ddlVillage.SelectedValue.ToString(), ddlintLineofActivity.SelectedValue, txtregistrationno.Text.Trim(), rblVeh.SelectedIndex.ToString());
                if (dsn != null && dsn.Tables.Count > 0 && dsn.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = dsn.Tables[0];
                    grdDetails.DataBind();
                    grdDetails.Visible = true;
                }
                else
                {
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                    grdDetails.Visible = false;
                    BtnSave1.Visible = false;
                    trFirstTrans.Visible = true;
                    BtnSave1.Text = "Next";

                }
            }
            else if (rblSector.SelectedIndex.ToString() == "1" && rblVeh.SelectedIndex.ToString() == "1" && txtregistrationno.Text != "" && trFirstTrans.Visible == false && chkTransportDeclare.Checked == false)
            {
                dsn = Getchildandparentdata(rblSector.SelectedIndex.ToString(), ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue, ddlVillage.SelectedValue.ToString(), ddlintLineofActivity.SelectedValue, txtregistrationno.Text.Trim(), rblVeh.SelectedIndex.ToString());
                if (dsn != null && dsn.Tables.Count > 0 && dsn.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = dsn.Tables[0];
                    grdDetails.DataBind();
                    grdDetails.Visible = true;
                }
                else
                {
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                    grdDetails.Visible = false;
                    BtnSave1.Visible = false;
                    trFirstTrans.Visible = true;
                    BtnSave1.Text = "Next";

                }
            }
            else if (rblSector.SelectedIndex.ToString() == "1" && trFirstTrans.Visible == true && chkTransportDeclare.Checked == true && BtnSave1.Text == "Next")
            {
                //Response.Redirect("IncetivesNewForm2.aspx?rblSector=" + rblSector.SelectedValue);
                Response.Redirect("IncetivesNewForm2.aspx?district=" + ddlProp_intDistrictid.SelectedValue.ToString() + "&Mandal=" + ddlProp_intMandalid.SelectedValue.ToString() + "&village=" + ddlVillage.SelectedValue.ToString() + "&vehicle=" + txtregistrationno.Text.ToString() + "&rblSector=" + rblSector.SelectedValue.ToString() + "&isVehicle=" + rblVeh.SelectedIndex.ToString());

            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("IncentiveFormCFECFO.aspx");
    }

    public DataSet Getchildandparentdata(string sector, string District, string Mandal, string village, string LineofActivity, string Unitname, string TransportService)
    {

        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@SECTOR",SqlDbType.VarChar),
                new SqlParameter("@DISTRICT",SqlDbType.VarChar),
               new SqlParameter("@MANDAL",SqlDbType.VarChar),
               new SqlParameter("@VILLAGE",SqlDbType.VarChar),
               new SqlParameter("@LINEOFACITIVTY",SqlDbType.VarChar),
               new SqlParameter("@transportService",SqlDbType.VarChar),
               new SqlParameter("@UNITNAME",SqlDbType.VarChar),
           };

            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = sector;
            pp[1].Value = District;
            pp[2].Value = Mandal;
            pp[3].Value = village;
            pp[4].Value = LineofActivity;
            pp[5].Value = TransportService;
            pp[6].Value = (Unitname == "") ? "%" : "%" + Unitname.ToString() + "%";

            Dsnew = Gen.GenericFillDs("[USP_GET_UNITLIST_CFECFO]", pp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        return Dsnew;
    }
    public void Getchildandparentdata_Auto(string createdBy)
    {

        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@createdBy",SqlDbType.VarChar),

           };

        //pp[0].Value = (Unitname == "") ? "%" : Unitname;
        pp[0].Value = createdBy;


        Dsnew = Gen.GenericFillDs("[USP_GET_UNITLIST_CFECFO_Auto]", pp);
        if (Dsnew.Tables.Count >= 1)
        {
            if (Dsnew.Tables[0].Rows.Count >= 1)
            {
                grdDetails.DataSource = Dsnew.Tables[0];
                grdDetails.DataBind();
                BtnSave1.Enabled = false;
            }
        }






    }
    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            TRISMSMEUNIT.Visible = false;
            //RBTISMSMEUNIT.Items.Clear();
            TRMSMEUNITNAME.Visible = false;
            // DDLMSMEUNITNAME.SelectedValue = "0";
            grdDetails.Visible = false;
            if (ddlProp_intDistrictid.SelectedIndex == 0)
            {
                ddlProp_intMandalid.Items.Clear();
                ddlProp_intMandalid.Items.Insert(0, "--Mandal--");

            }
            else
            {

                ddlProp_intMandalid.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddlProp_intDistrictid.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlProp_intMandalid.DataSource = dsm.Tables[0];
                    ddlProp_intMandalid.DataValueField = "Mandal_Id";
                    ddlProp_intMandalid.DataTextField = "Manda_lName";
                    ddlProp_intMandalid.DataBind();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlProp_intMandalid.Items.Clear();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                }
            }

            //   ddlProp_intDistrictid.Focus();
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void BindLineofActivityName()
    {
        try
        {
            ddlintLineofActivity.Items.Clear();
            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDetNew(Session["uid"].ToString());
            if (dsc != null && dsc.Tables.Count > 0 && dsc.Tables[0].Rows.Count > 0)
            {
                ddlintLineofActivity.DataSource = dsc.Tables[0];
                ddlintLineofActivity.DataValueField = "intLineofActivityid";
                ddlintLineofActivity.DataTextField = "LineofActivity_Name";
                ddlintLineofActivity.DataBind();
                ddlintLineofActivity.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlintLineofActivity.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        Response.Redirect("IncetivesNewForm2.aspx?rblSector=" + rblSector.SelectedValue);
    }

    public string IncentiveCFECFO(string sector, string District, string Mandal, string LineofActivityid, string NameofIndustry, string Uidno, string ActivityProposed, string LineofActivity, string TotalInvst, string DateofApplication, string Createdby)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        string valid = "";
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "USP_INS_INCENTIVECFECFO";

            com.Transaction = transaction;
            com.Connection = connection;

            if (District != "" && District != null)
                com.Parameters.AddWithValue("@District", District);
            else
                com.Parameters.AddWithValue("@District", null);
            if (Mandal != "" && Mandal != null)
                com.Parameters.AddWithValue("@Mandal", Mandal);
            else
                com.Parameters.AddWithValue("@Mandal", null);
            if (LineofActivityid != "" && LineofActivityid != null)
                com.Parameters.AddWithValue("@LineofActivityid", LineofActivityid);
            else
                com.Parameters.AddWithValue("@LineofActivityid", null);

            if (NameofIndustry != "" && NameofIndustry != null)
                com.Parameters.AddWithValue("@NameofIndustry", NameofIndustry);
            else
                com.Parameters.AddWithValue("@NameofIndustry", null);

            if (Uidno != "" && Uidno != null)
                com.Parameters.AddWithValue("@Uidno", Uidno);
            else
                com.Parameters.AddWithValue("@Uidno", null);

            if (ActivityProposed != "" && ActivityProposed != null)
                com.Parameters.AddWithValue("@ActivityProposed", ActivityProposed);
            else
                com.Parameters.AddWithValue("@ActivityProposed", null);
            if (LineofActivity != "" && LineofActivity != null)
                com.Parameters.AddWithValue("@LineofActivity", LineofActivity.ToString().Trim());
            else
                com.Parameters.AddWithValue("@LineofActivity", null);

            if (TotalInvst != "" && TotalInvst != null)
                com.Parameters.AddWithValue("@TotalInvst", TotalInvst);
            else
                com.Parameters.AddWithValue("@TotalInvst", null);
            if (DateofApplication != "" && DateofApplication != null)
                com.Parameters.AddWithValue("@DateofApplication", Convert.ToDateTime(DateofApplication));
            else
                com.Parameters.AddWithValue("@DateofApplication", null);
            if (Createdby != "" && Createdby != null)
                com.Parameters.AddWithValue("@Createdby", Createdby);
            else
                com.Parameters.AddWithValue("@Createdby", null);


            com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();

            valid = com.Parameters["@Valid"].Value.ToString();

            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
        return valid;
    }

    protected void rblVeh_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if(rblVeh.selec)
        if (rblVeh.SelectedIndex.ToString() == "0" && rblSector.SelectedItem.Text.ToString() == "Service")
        {
            tdLineofActivity.Visible = false;
            trvillage.Visible = true;
            tdLineofActivity1.Visible = false;
            trvehicleno.Visible = true;
            trdistrict.Visible = true;
            lblVehicle.Text = "Vehicle Number";
        }
        else if (rblVeh.SelectedIndex.ToString() == "1" && rblSector.SelectedItem.Text.ToString() == "Service")
        {
            tdLineofActivity.Visible = false;
            trvillage.Visible = true;
            tdLineofActivity1.Visible = false;
            trvehicleno.Visible = true;
            trdistrict.Visible = true;
            lblVehicle.Text = "Unit Name";
        }


    }

    protected void ddlProp_intMandalid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlProp_intMandalid.SelectedIndex == 0)
            {
                ddlVillage.Items.Clear();
                ddlVillage.Items.Insert(0, "--Mandal--");

            }
            else
            {

                ddlVillage.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetVillages(ddlProp_intMandalid.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlVillage.DataSource = dsm.Tables[0];
                    ddlVillage.DataValueField = "Village_Id";
                    ddlVillage.DataTextField = "Village_Name";
                    ddlVillage.DataBind();
                    ddlVillage.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlVillage.Items.Clear();
                    ddlVillage.Items.Insert(0, "--Village--");
                }
            }

            //   ddlProp_intDistrictid.Focus();
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void chkTransportDeclare_CheckedChanged(object sender, EventArgs e)
    {
        if (chkTransportDeclare.Visible == true)
            BtnSave1.Visible = true;
        else if (chkTransportDeclare.Visible == false)
            BtnSave1.Visible = false;
    }



    protected void RBTISMSMEUNIT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBTISMSMEUNIT.SelectedValue == "1")
        {
            TRMSMEUNITNAME.Visible = true;
            BINDMSMEUNITNAMES();
        }
        else
        {
            // Response.Redirect("frmmsme_INCENTIVES.aspx?district=" + ddlProp_intDistrictid.SelectedValue.ToString() + "&Mandal=" + ddlProp_intMandalid.SelectedValue.ToString() + "&LOA=" + ddlintLineofActivity.SelectedValue.ToString());
            Response.Redirect("frmmsme_INCENTIVES.aspx?district=" + ddlProp_intDistrictid.SelectedValue.ToString() + "&Mandal=" + ddlProp_intMandalid.SelectedValue.ToString() + "&LOA=" + ddlintLineofActivity.SelectedValue.ToString() + "&UNITNAME=" + txtnameofunit.Text.Trim().ToString());
        }
    }
    public void BINDMSMEUNITNAMES()
    {
        DataSet UNITNAME = new DataSet();
        UNITNAME = GETMSMEUNITNAMES(ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue, ddlintLineofActivity.SelectedValue, txtnameofunit.Text);
        if (UNITNAME.Tables[0].Rows.Count > 0)
        {
            DDLMSMEUNITNAME.DataSource = UNITNAME.Tables[0];
            DDLMSMEUNITNAME.DataTextField = "UNIT_NAME";
            DDLMSMEUNITNAME.DataValueField = "MSME_NO";
            DDLMSMEUNITNAME.DataBind();
            AddSelect(DDLMSMEUNITNAME);
        }
        else
        {
            DDLMSMEUNITNAME.Items.Clear();
            AddSelect(DDLMSMEUNITNAME);
            RBTISMSMEUNIT.SelectedValue = "0";
            RBTISMSMEUNIT_SelectedIndexChanged(this, EventArgs.Empty);

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
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public DataSet GETMSMEUNITNAMES(string DISTRICTID, string MANDALID, string LOCID, string MSMEUNITNAME)
    {

        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[]
       {
             new SqlParameter("@DISTRICTID",SqlDbType.VarChar),
              new SqlParameter("@MANDALID",SqlDbType.VarChar),
               new SqlParameter("@LOCID",SqlDbType.VarChar),
                new SqlParameter("@MSMEUNITNAME",SqlDbType.VarChar)
       };
        pp[0].Value = DISTRICTID;
        pp[1].Value = MANDALID;
        pp[2].Value = LOCID;
        pp[3].Value = MSMEUNITNAME;
        Dsnew = Gen.GenericFillDs("SP_GETMSMEUNITNAMES", pp);
        return Dsnew;
    }
    protected void DDLMSMEUNITNAME_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsmmsme = new DataSet();
        dsmmsme = Getchildandparentdata(rblSector.SelectedIndex.ToString(), ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue, "", ddlintLineofActivity.SelectedValue, txtnameofunit.Text.Trim(), rblVeh.SelectedIndex.ToString());
        if (dsmmsme != null && dsmmsme.Tables.Count > 0 && dsmmsme.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = dsmmsme.Tables[0];
            grdDetails.DataBind();
            grdDetails.Visible = true;
        }
        else
        {

            grdDetails.DataSource = null;
            grdDetails.DataBind();
            grdDetails.Visible = false;
        }
    }
}