using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Web.Services;
using System.IO;

using System.Web.Security;

using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;



public partial class UI_TSIPASS_ApplicationSolution : System.Web.UI.Page
{
    General Gen = new General();
    public DataTable DtTable = new DataTable();
    ArrayList ParameterArray = new ArrayList();
    DataSet ds = new DataSet();
    string ins = string.Empty;
    int input = 0;
    string insert = string.Empty;
    string user;
    HdGeneral g = new HdGeneral();
    private static HdGeneral gen = null;
    DeptSendFailedApps objwebservice = new DeptSendFailedApps();
    paymentresponseVOs paymentresponseVOsobj = new paymentresponseVOs();
    CFEWebServices CFesenddata = new CFEWebServices();
    CFOWebServices CFosenddata = new CFOWebServices();
    RenWebservice Rensenddata = new RenWebservice();
    BMWWebservice BMWsenddata = new BMWWebservice();
    Departtsiicservice tsiicdata = new Departtsiicservice();

    public UI_TSIPASS_ApplicationSolution()
    {
        gen = new HdGeneral();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        if (Session["uid"] == null)
        {
            Response.Redirect("~/IpassLogin.aspx");
        }
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
        if (!IsPostBack)
        {
            if (Session["uid"].ToString() == "1238" ||Session["uid"].ToString() == "3377"|| Session["userlevel"].ToString().Trim() == "2" || Session["uid"].ToString() == "359104")
            {

            }
            else
            {
                Response.Redirect("~/Index.aspx");
            }
            getdistricts();
            if (Session["uid"].ToString() == "3377")
            {
                ddlModule.SelectedValue = "1";
                ddlModule.Enabled = false;
                ddlModule_SelectedIndexChanged(sender, e);

            }
        }


        #region old

        //try
        //{
        //    if (!IsPostBack)
        //    {
        //        if (Session["UserLogin"] != null)
        //        {
        //            user = Session["User_Code"].ToString();
        //            PopulateTables();
        //            DataSet dshelps = new DataSet();
        //            if (Request.QueryString["Newid"] != null && Request.QueryString["Newid"] != "")
        //            {
        //                string Newid = Request.QueryString["Newid"].ToString();
        //                if (Newid != "")
        //                {
        //                    dshelps = cmn.GethelpdeskbackupNew(Newid);
        //                    gvComplaintsList.DataSource = dshelps.Tables[0];
        //                    gvComplaintsList.DataBind();
        //                    btnback.Visible = true;
        //                }
        //                else
        //                    btnback.Visible = false;
        //            }
        //            else
        //                btnback.Visible = false;
        //        }
        //        else

        //            Response.Redirect("Login.aspx");

        //    }
        //    else
        //    {
        //        if (ViewState["DataTable"] != null)
        //        {
        //            CreateTemplatedGridView();

        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblMsg.Text = ex.Message;
        //    lblMsg.CssClass = "errormsg";
        //    lblMsg.Visible = true;
        //}


        #endregion
    }

    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();
        dsnew = gen.GetDistrictsbystate("%");
        selDist.Items.Clear();
        selDist.DataSource = dsnew.Tables[0];
        selDist.DataTextField = "District_Name";
        selDist.DataValueField = "District_Id";
        selDist.DataBind();
        selDist.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void anchortaglink_Click(object sender, EventArgs e)
    {
        ViewState["Id"] = "";
        ViewState["mstid"] = "";
        ViewState["SLCorDLC"] = "";
        viewData.Visible = false;
        divProcess.Visible = false;

        txthdid.Text = "";
        txtremarks.Text = "";

        Button ddlDeptnameFnl2 = (Button)sender;
        GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;

        string enterid = ((Label)row.FindControl("lblEnterperIncentiveID")).Text;
        string Incids = ((Label)row.FindControl("lblMstIncentiveId")).Text;
        IncentiveStatus(enterid, Incids);
        tblinclist.Visible = false;
        divcommoninpts.Visible = false;
        btncfeactionclick.Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["Id"] = "";
        ViewState["mstid"] = "";
        ViewState["SLCorDLC"] = "";
        viewData.Visible = false;
        divProcess.Visible = false;
        divselrollbacklevel.Visible = false;
        divselroleamt.Visible = false;
        divselcaste.Visible = false;
        divtxtAmt.Visible = false;
        btnchange.Visible = false;
        divcommoninpts.Visible = false;
        txthdid.Text = "";
        txtremarks.Text = "";
        btnAction.Enabled = true;
        IncentivesList(inputIncId.Text.Trim(), inputUnit.Text.Trim(), selDist.SelectedValue);
    }

    public void IncentivesList(string Id, string Unitname, string Dist)
    {
        DataSet ds = g.FillIncList(Id, Unitname, Dist);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            tblinclist.Visible = true;
            // data = g.DataTableToJSONWithJSONNet(ds.Tables[0]);
        }
        else
        {
            tblinclist.Visible = true;
        }
    }

    public void IncentiveStatus(string Id, string mstid)
    {
        ViewState["Id"] = Id;
        ViewState["mstid"] = mstid;
        ViewState["SLCorDLC"] = "";

        HdGeneral g = new HdGeneral();
        DataSet ds = g.GetIncentivesDetails(Id, mstid);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            tdApplicationDate.InnerHtml = ds.Tables[0].Rows[0]["ApplliedDate"].ToString();
            tdApplicationNo.InnerHtml = ds.Tables[0].Rows[0]["applicationno"].ToString();
            tdUnitName.InnerHtml = ds.Tables[0].Rows[0]["UnitName"].ToString();
            tdApplicantName.InnerHtml = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
            tdSocialStatus.InnerHtml = ds.Tables[0].Rows[0]["SocialStatus"].ToString();
            tdSector.InnerHtml = ds.Tables[0].Rows[0]["SectorNew"].ToString();
            tdCategory.InnerHtml = ds.Tables[0].Rows[0]["Category"].ToString();
            tdDCP.InnerHtml = ds.Tables[0].Rows[0]["DCP"].ToString();
            tdUnitDistName.InnerHtml = ds.Tables[0].Rows[0]["UnitDistName"].ToString();
            tdMandal.InnerHtml = ds.Tables[0].Rows[0]["UNITMANDAL"].ToString();
            tdVillage.InnerHtml = ds.Tables[0].Rows[0]["UNITVILLAGE"].ToString();
            tdMobile.InnerHtml = ds.Tables[0].Rows[0]["UnitMObileNo"].ToString();
            tdEmail.InnerHtml = ds.Tables[0].Rows[0]["UnitEmail"].ToString();
            viewData.Visible = true;
            divProcess.Visible = true;
            divselrollbacklevel.Visible = false;
            divselroleamt.Visible = false;
            divselcaste.Visible = false;
            divtxtAmt.Visible = false;
            btnchange.Visible = false;
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                gvdeatilsincentives.DataSource = ds.Tables[1];
                gvdeatilsincentives.DataBind();
                btnAction.Enabled = true;
            }

            if (gvdeatilsincentives.Rows.Count == 1)
            {
                ViewState["SLCorDLC"] = ds.Tables[1].Rows[0]["SLCorDLC"].ToString();
            }
        }
        else
        {
            viewData.Visible = false;
            divProcess.Visible = false;
        }
    }


    [WebMethod]
    public static string GetIncentivesList(string Id)
    {
        string data = "";
        HdGeneral g = new HdGeneral();
        DataSet ds = g.GetIncentives(Id);
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                data = g.DataSetToJsonWithJSONNet(ds);
            }
        }
        return data;
    }


    [WebMethod]
    public static int UpdateCaste(int EnrpId, int Caste)
    {
        return gen.ApplicantCasteChange(EnrpId, Caste);
    }


    [WebMethod]
    public static int UpdateIncentiveAmount(int EnrpId, int MstincId, int Role, string Amount)
    {
        return gen.IncentiveAmountChange(EnrpId, MstincId, Role, Amount);
    }


    //[WebMethod]
    //public static int ApplicationRollback(int EntrpId, int MstIncid, int Rblevel, int Type)
    //{
    //    int transType = 0;
    //    if ((Rblevel == 8 || Rblevel == 3) && Type == 1)
    //    {
    //        transType = 1;
    //    }
    //    else if (Rblevel == 9 && Type == 1)
    //    { transType = 2; }
    //    else if (Rblevel == 4 && Type == 2)
    //    { transType = 3; }
    //    else if (Rblevel == 4 && Type == 4)
    //    { transType = 4; }
    //    else if (Rblevel == 1 && Type == 2)
    //    {
    //        transType = 5;
    //    }
    //    else if (Rblevel == 6 && Type == 2)
    //    {
    //        transType = 6;
    //    }
    //    else if (Rblevel == 1 && Type == 1)
    //    {
    //        transType = 7;
    //    }
    //    else if (Rblevel == 7 && Type == 2)
    //    {
    //        transType = 10;
    //    }
    //    return gen.ApplicationRollback("INCENTIVE", EntrpId, MstIncid, transType, 1000, "Test remarks");
    //}
    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        //divselIncTypes.Visible = false;
        //    divselrollbacklevel.Visible = false;
        //    divselrbtype.Visible = false;
        //    divselroleamt.Visible = false;
        //    divselcaste.Visible = false;
        //    divtxtAmt.Visible = false;

        viewData.Visible = false;
        divProcess.Visible = false;
        divcfeviewdata.Visible = false;
        divcfefailedwebservices.Visible = false;
        DivInc.Visible = false;
        DivCfe.Visible = false;
        divbtnupdatecfe.Visible = false;
        if (ddlModule.SelectedValue == "1")
        {
            DivInc.Visible = true;
            DivCfe.Visible = false;
            DivCfo.Visible = false;
            inputIncId.Text = "";
            inputUnit.Text = "";
        }
        else if (ddlModule.SelectedValue == "2" || ddlModule.SelectedValue == "3")
        {
            DivInc.Visible = false;
            DivCfe.Visible = true;
        }
        else if (ddlModule.SelectedValue == "4")
        {
            objwebservice.CallWebserviceFromRTA();
        }
        else if (ddlModule.SelectedValue == "5")
        {
            DataSet ds = new DataSet();
            ds = GetCFEFailedUpdateDtls("2017/06/06", System.DateTime.Today.ToString("yyyy/MM/dd"), "ALL", "N");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvcfefaileddata.DataSource = ds.Tables[0];
                gvcfefaileddata.DataBind();
                divcfefailedwebservices.Visible = true;
                divbtnupdatecfe.Visible = true;
                divRenfailedwebservices.Visible = false;
                divbtnupdateren.Visible = false;
            }
            else
            {
                divcfefailedwebservices.Visible = false;
                divbtnupdatecfe.Visible = false;
            }
        }
        else if (ddlModule.SelectedValue == "6")
        {
            DataSet ds = new DataSet();
            ds = GetCFOFailedUpdateDtls("2017/06/06", System.DateTime.Today.ToString("yyyy/MM/dd"), "ALL", "N");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvcfofaileddata.DataSource = ds.Tables[0];
                gvcfofaileddata.DataBind();
                divcfofailedwebservices.Visible = true;
                divbtnupdatecfo.Visible = true;
                divRenfailedwebservices.Visible = false;
                divbtnupdateren.Visible = false;
            }
            else
            {
                divcfofailedwebservices.Visible = false;
                divbtnupdatecfo.Visible = false;

            }
        }
        else if (ddlModule.SelectedValue == "7")
        {
            DataSet ds = new DataSet();
            ds = GetRENFailedUpdateDtls("2017/08/06", System.DateTime.Today.ToString("yyyy/MM/dd"), "ALL", "N");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvrenfaileddata.DataSource = ds.Tables[0];
                gvrenfaileddata.DataBind();
                divRenfailedwebservices.Visible = true;
                divbtnupdateren.Visible = true;
                divcfofailedwebservices.Visible = false;
                divbtnupdatecfo.Visible = false;
            }
            else
            {
                divRenfailedwebservices.Visible = false;
                divbtnupdateren.Visible = false;
                divcfofailedwebservices.Visible = false;
                divbtnupdatecfo.Visible = false;
            }
        }
        else if (ddlModule.SelectedValue == "10")
        {
            try
            {
                DataSet ds = new DataSet();
                ds = GetBMWFailedUpdateDtls("2017/08/06", System.DateTime.Today.ToString("yyyy/MM/dd"), "ALL", "N");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvBMWfaileddata.DataSource = ds.Tables[0];
                    gvBMWfaileddata.DataBind();
                    divbtnupdateBMW.Visible = true;
                    divBMWfailedwebservices.Visible = true;
                    divcfofailedwebservices.Visible = false;
                    divbtnupdatecfo.Visible = false;
                    divRenfailedwebservices.Visible = false;
                    divbtnupdateren.Visible = false;
                }
                else
                {
                    divBMWfailedwebservices.Visible = false;
                    divbtnupdateBMW.Visible = false;
                    divcfofailedwebservices.Visible = false;
                    divbtnupdatecfo.Visible = false;
                    divRenfailedwebservices.Visible = false;
                    divbtnupdateren.Visible = false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        else if (ddlModule.SelectedValue == "8")
        {
            try
            {
                DataSet ds = new DataSet();
                ds = GettsiicplotFailedUpdateDtls("2017/08/06", System.DateTime.Today.ToString("yyyy/MM/dd"), "ALL", "N");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdtsiic.DataSource = ds.Tables[0];
                    grdtsiic.DataBind();
                    divtsiicupdate.Visible = true;
                    divplottsiicfailedservice.Visible = true;
                    divcfofailedwebservices.Visible = false;
                    divbtnupdatecfo.Visible = false;
                    divRenfailedwebservices.Visible = false;
                    divbtnupdateren.Visible = false;
                }
                else
                {
                    divplottsiicfailedservice.Visible = false;
                    divtsiicupdate.Visible = false;
                    divcfofailedwebservices.Visible = false;
                    divbtnupdatecfo.Visible = false;
                    divRenfailedwebservices.Visible = false;
                    divbtnupdateren.Visible = false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        else if (ddlModule.SelectedValue == "9")
        {
            Response.Redirect("frmfailedpayments.aspx");
        }
        else if (ddlModule.SelectedValue == "11")
        {
            Response.Redirect("frmfailedpaymentsbydate.aspx");
        }
        else if (ddlModule.SelectedValue == "12")
        {
            Response.Redirect("Departmentserviceattachment.aspx");
        }
    }

    protected void btnRollback_Click(object sender, EventArgs e)
    {
        divselrollbacklevel.Visible = true;
        divselroleamt.Visible = false;
        divselcaste.Visible = false;
        divtxtAmt.Visible = false;
        btnchange.Visible = true;
        divcommoninpts.Visible = true;

        DataSet ds = new DataSet();



        string EnprIncentiveId = ViewState["Id"].ToString();
        string MstIncentiveId = ViewState["mstid"].ToString();
        string SLCorDLC = ViewState["SLCorDLC"].ToString();

        ds = g.GetIncentivesDetailsRollback(EnprIncentiveId, MstIncentiveId, SLCorDLC);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            selrollbacklevel.DataSource = ds.Tables[0];
            selrollbacklevel.DataTextField = "RolebackLevel";
            selrollbacklevel.DataValueField = "Id";
            selrollbacklevel.DataBind();
            selrollbacklevel_SelectedIndexChanged(sender, e);
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
    protected void btnAmount_Click(object sender, EventArgs e)
    {
        divselrollbacklevel.Visible = false;
        divselroleamt.Visible = true;
        divselcaste.Visible = false;
        divtxtAmt.Visible = true;
        btnchange.Visible = true;
        divcommoninpts.Visible = true;
    }
    protected void btnCaste_Click(object sender, EventArgs e)
    {
        divselrollbacklevel.Visible = false;
        divselroleamt.Visible = false;
        divselcaste.Visible = true;
        divtxtAmt.Visible = false;
        btnchange.Visible = true;
        divcommoninpts.Visible = true;
    }
    protected void btnAction_Click(object sender, EventArgs e)
    {
        string errormsgval = ValidationInputs();
        if (errormsgval.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsgval + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        string EnprIncentiveId = ViewState["Id"].ToString();
        string MstIncentiveId = ViewState["mstid"].ToString();
        string SLCorDLC = ViewState["SLCorDLC"].ToString();
        string Ipaddress = getclientIP();
        string result = ApplicationRollback("INCENTIVE", EnprIncentiveId, MstIncentiveId, selrollbacklevel.SelectedValue.ToString(), Session["uid"].ToString(), txtremarks.Text.Trim(), txthdid.Text.Trim(), Ipaddress, txtAmt.Text.Trim(), SLCorDLC);

        if (result == "1")
        {
            txthdid.Text = "";
            txtremarks.Text = "";

            btnAction.Enabled = false;
            string errormsg = "Updated Successfully";
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
    }

    protected void selrollbacklevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (selrollbacklevel.SelectedValue == "12" || selrollbacklevel.SelectedValue == "13")
        {
            divtxtAmt.Visible = true;
        }
        else
        {
            divtxtAmt.Visible = false;
        }
    }

    public string ApplicationRollback(string module, string EnprIncId, string MstincId, string Trasntype, string ModifiedBy, string Remarks, string HdId, string Ipaddress, string Amountchange, string SLCorDLC)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;


        string Result = "";
        SqlConnection con = new SqlConnection(ConnectionString);
        SqlCommand Com = new SqlCommand("USP_SOLUTIONUPDTAES_NEW", con);

        Com.CommandType = CommandType.StoredProcedure;
        Com.Parameters.Add("@MODULE", SqlDbType.VarChar).Value = module;
        Com.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = EnprIncId;
        Com.Parameters.Add("@MSTINCENTIVEID", SqlDbType.VarChar).Value = MstincId;
        Com.Parameters.Add("@TRANSACTIONTYPE", SqlDbType.VarChar).Value = Trasntype;
        Com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = ModifiedBy;
        Com.Parameters.Add("@HDREMARKS", SqlDbType.VarChar).Value = Remarks;
        Com.Parameters.Add("@HdId", SqlDbType.VarChar).Value = HdId;
        Com.Parameters.Add("@Ipaddress", SqlDbType.VarChar).Value = Ipaddress;
        Com.Parameters.Add("@Amountchange", SqlDbType.VarChar).Value = Amountchange;
        Com.Parameters.Add("@SLCorDLC", SqlDbType.VarChar).Value = SLCorDLC;
        Com.Parameters.Add("@Result", SqlDbType.VarChar).Value = "0";
        Com.Parameters["@Result"].Direction = ParameterDirection.Output;

        con.Open();
        try
        {
            Com.ExecuteNonQuery();
            Result = Com.Parameters["@Result"].Value.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Com.Dispose();
            con.Close();
        }

        return Result;
    }


    public string ValidationInputs()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (selrollbacklevel.SelectedValue == "12" && txtAmt.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter the Amount\\n";
            slno = slno + 1;
        }
        if (txthdid.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter HD ID \\n";
            slno = slno + 1;
        }
        if (txtremarks.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Remarks\\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }
    public void Resetvalues()
    {
        ddlcfeactions.SelectedIndex = 0;
        divinitiatrdpaymentdetails.Visible = false;
        gvInitiated.DataSource = null;
        gvInitiated.DataBind();
        txtcfeamount.Text = "";
        txttransnor.Text = "";
        txtbankid.Text = "";
        lblFileName.Text = "";
        txtcfehdid.Text = "";
        txthdRemarks.Text = "";
        divinitiatrdpaymentdetails.Visible = false;
        divcfertgshdremarks.Visible = false;
        divcfertgsUpload.Visible = false;
        divcfertgs.Visible = false;
        btncfeactionclick.Visible = false;
        divpaymentsuccess.Visible = false;
        gvdpaymentsuccess.DataSource = null;
        gvdpaymentsuccess.DataBind();
    }
    protected void btncfesearch_Click(object sender, EventArgs e)
    {
        Resetvalues();
        Divserchcfedata.Visible = false;

        tblcfe.Visible = false;
        try
        {
            if (txtunitname.Text.TrimStart().TrimEnd() != "" || txtUidNo.Text.TrimStart().TrimEnd() != "" || txtcfeid.Text.TrimStart().TrimEnd() != "")
            {
                fillGrid();
            }
            else
            {

            }
        }
        catch (Exception ex)
        {

        }
    }
    private void fillGrid()
    {
        try
        {
            DataSet dsn = new DataSet();
            divcfeviewdata.Visible = false;
            Divserchcfedata.Visible = false;
            tblcfe.Visible = false;
            // dsn = Gen.GetApplicationTracker(txtnameofUnit.Text, txtUID.Text,ddlquantityper.SelectedValue.ToString());
            dsn = Getchildandparentdata(txtunitname.Text.TrimStart().TrimEnd(), txtUidNo.Text.TrimStart().TrimEnd(), ddlModule.SelectedValue.ToString(), txtcfeid.Text.TrimStart().TrimEnd());
            if (ddlModule.SelectedValue.ToString() == "2")
            {
                if (dsn.Tables[0].Rows.Count > 0)
                {
                    grdDetailsMain.DataSource = dsn.Tables[0];
                    grdDetailsMain.DataBind();
                    Divserchcfedata.Visible = true;
                }
                else
                {
                    grdDetailsMain.DataSource = null;
                    grdDetailsMain.DataBind();
                }
            }
            else if (ddlModule.SelectedValue.ToString() == "3")
            {
                if (dsn.Tables[0].Rows.Count > 0)
                {
                    grdDetailsMain.DataSource = dsn.Tables[0];
                    grdDetailsMain.DataBind();
                    Divserchcfedata.Visible = true;
                }
                else
                {
                    grdDetailsMain.DataSource = null;
                    grdDetailsMain.DataBind();
                }
            }
            //else if (ddlquantityper.SelectedValue.ToString() == "CFO")
            //{


            //    if (dsn.Tables[0].Rows.Count > 0)
            //    {

            //        grdDetails0.DataSource = dsn.Tables[0];
            //        grdDetails0.DataBind();
            //        grdDetails.Visible = false;
            //        grdDetails.DataSource = null;
            //        grdDetails.DataBind();
            //    }
            //    else
            //    {
            //        lblrecords.Text = "NO RECORD TO DISPLAY";
            //        grdDetails0.DataSource = null;
            //        grdDetails0.DataBind();
            //    }


            //}
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }

    }

    public DataSet Getchildandparentdata(string Unitname, string Uid, string Appstype, string CFEID)
    {

        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UnitName",SqlDbType.VarChar),
               new SqlParameter("@UID",SqlDbType.VarChar),
               new SqlParameter("@ApplType",SqlDbType.VarChar),
               new SqlParameter("@CFEID",SqlDbType.VarChar)
           };

            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = (Unitname == "") ? "%" : "%" + Unitname.ToString() + "%";
            pp[1].Value = (Uid == "") ? "%" : Uid;
            pp[2].Value = (Appstype == "") ? "%" : Appstype;
            pp[3].Value = (CFEID == "") ? "%" : CFEID;

            Dsnew = Gen.GenericFillDs("[USP_GET_GetApplicationTracker_Solution]", pp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }
        return Dsnew;
    }



    public DataSet GetCFEFailedUpdateDtls(string FROMDATE, string TODATE, string DEPARTMENTID, string STATUS)
    {

        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@FROMDATE",SqlDbType.VarChar),
               new SqlParameter("@TODATE",SqlDbType.VarChar),
               new SqlParameter("@DEPARTMENTID",SqlDbType.VarChar),
               new SqlParameter("@STATUS",SqlDbType.VarChar)
           };

            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = FROMDATE;
            pp[1].Value = TODATE;
            pp[2].Value = DEPARTMENTID;
            pp[3].Value = STATUS;

            Dsnew = Gen.GenericFillDs("[USP_GET_WEBSERVICE_REPORT]", pp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }
        return Dsnew;
    }
    protected void btncfeprocess_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlModule.SelectedValue == "2")
            {
                divcfeviewdata.Visible = false;
                Button ddlDeptnameFnl2 = (Button)sender;
                GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;

                string enterid = ((Label)row.FindControl("lblintQuessionaireid")).Text;
                string createdby = ((Label)row.FindControl("lblCREATEDBY")).Text;
                ViewState["lblCREATEDBY"] = createdby;
                DataSet ds = new DataSet();
                ds = GetApplicationTrackerDetailed2(enterid);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    tdapplicationstatus.InnerHtml = "Application Status : " + ds.Tables[0].Rows[0]["ApplStatusNew"].ToString();
                    tdapplicationstatus.InnerHtml = "Application Status : " + ds.Tables[0].Rows[0]["ApplStatusNew"].ToString();

                    lblUID.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
                    labUidNumber.Attributes["href"] = "CFEPrint.aspx?intApplid=" + ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                    HyperLinkSubsidy.NavigateUrl = "frmViewAttachmentDetails.aspx?intApplicationId=" + ds.Tables[0].Rows[0]["INTCFEENTERPID"].ToString();
                    //labNameandAddress.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    labNameandAddress.Text = ds.Tables[0].Rows[0]["Name of the Industry"].ToString();
                    labLineofActivity.Text = ds.Tables[0].Rows[0]["Line of Activity"].ToString();
                    lblSector.Text = ds.Tables[0].Rows[0]["Sector"].ToString();
                    lblDistrict.Text = ds.Tables[0].Rows[0]["District_Name"].ToString();

                    labDOA.Text = ds.Tables[0].Rows[0]["Date of Application of  industry"].ToString();
                    labCategoryofIndustry.Text = ds.Tables[0].Rows[0]["CategoryOfIndustry"].ToString();
                    labTotalInvestment.Text = ds.Tables[0].Rows[0]["Investment"].ToString() + " Crore "; //+ ds.Tables[0].Rows[0]["CurrencyType"].ToString();
                    labNameandAddress0.Text = ds.Tables[0].Rows[0]["PropAddress"].ToString();
                    lblpolution.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    lblEmploymenttot.Text = ds.Tables[0].Rows[0]["Employment"].ToString();


                    //if (Session["username"].ToString() == "KCSBabu" || Session["username"].ToString() == "cmsnikhil")  //new nikhil
                    //{
                    hprcoipaynetdtls.NavigateUrl = "RptPaymentDetails.aspx?intApplicationId=" + lblUID.Text.ToString() + "";
                    //}
                    //else
                    //{
                    //    hprcoipaynetdtls.NavigateUrl = "TrackerDtls.aspx?intQuessionaireid=" + ds.Tables[0].Rows[0]["intQuessionaireid"].ToString() + "&intStageid=2&intApprovalid=33";
                    //}


                    if (ds.Tables[0].Rows[0]["Consolidatecert"].ToString() != "")
                    {
                        trcoicertificate.Visible = true;
                        HyperLinkcoi.Target = "_blank";

                        HyperLinkcoi.NavigateUrl = ds.Tables[0].Rows[0]["Consolidatecert"].ToString();
                    }
                    divcfeviewdata.Visible = true;
                    Divserchcfedata.Visible = false;
                    tblcfe.Visible = true;
                }
                grdDetailsApprovaldtls.DataSource = ds.Tables[0];
                grdDetailsApprovaldtls.DataBind();
            }
            if (ddlModule.SelectedValue == "3")
            {
                divcfeviewdata.Visible = false;
                Button ddlDeptnameFnl2 = (Button)sender;
                GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;

                string enterid = ((Label)row.FindControl("lblintQuessionaireid")).Text;

                DataSet ds = new DataSet();
                ds = GetApplicationTrackerDetailed2CFO(enterid);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    tdapplicationstatus.InnerHtml = "Application Status : " + ds.Tables[0].Rows[0]["ApplStatusNew"].ToString();
                    tdapplicationstatus.InnerHtml = "Application Status : " + ds.Tables[0].Rows[0]["ApplStatusNew"].ToString();

                    lblUID.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
                    labUidNumber.Attributes["href"] = "CFOPrint.aspx?intApplid=" + ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                    HyperLinkSubsidy.NavigateUrl = "frmViewAttachmentDetailsCFO.aspx?intApplicationId=" + ds.Tables[0].Rows[0]["INTCFEENTERPID"].ToString();
                    //labNameandAddress.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    labNameandAddress.Text = ds.Tables[0].Rows[0]["Name of the Industry"].ToString();
                    labLineofActivity.Text = ds.Tables[0].Rows[0]["Line of Activity"].ToString();
                    lblSector.Text = ds.Tables[0].Rows[0]["Sector"].ToString();
                    lblDistrict.Text = ds.Tables[0].Rows[0]["District_Name"].ToString();

                    labDOA.Text = ds.Tables[0].Rows[0]["Date of Application of  industry"].ToString();
                    labCategoryofIndustry.Text = ds.Tables[0].Rows[0]["CategoryOfIndustry"].ToString();
                    labTotalInvestment.Text = ds.Tables[0].Rows[0]["Investment"].ToString() + " Crore "; //+ ds.Tables[0].Rows[0]["CurrencyType"].ToString();
                    labNameandAddress0.Text = ds.Tables[0].Rows[0]["PropAddress"].ToString();
                    lblpolution.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    lblEmploymenttot.Text = ds.Tables[0].Rows[0]["Employment"].ToString();


                    //if (Session["username"].ToString() == "KCSBabu" || Session["username"].ToString() == "cmsnikhil")  //new nikhil
                    //{
                    hprcoipaynetdtls.NavigateUrl = "RptPaymentDetailsCFO.aspx?intApplicationId=" + lblUID.Text.ToString() + "";
                    //}
                    //else
                    //{
                    //    hprcoipaynetdtls.NavigateUrl = "TrackerDtls.aspx?intQuessionaireid=" + ds.Tables[0].Rows[0]["intQuessionaireid"].ToString() + "&intStageid=2&intApprovalid=33";
                    //}


                    if (ds.Tables[0].Rows[0]["Consolidatecert"].ToString() != "")
                    {
                        trcoicertificate.Visible = true;
                        HyperLinkcoi.Target = "_blank";

                        HyperLinkcoi.NavigateUrl = ds.Tables[0].Rows[0]["Consolidatecert"].ToString();
                    }
                    divcfeviewdata.Visible = true;
                    Divserchcfedata.Visible = false;
                    tblcfe.Visible = true;
                }
                grdDetailsApprovaldtls.DataSource = ds.Tables[0];
                grdDetailsApprovaldtls.DataBind();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblm.Text = ex.Message;
            throw ex;
        }
    }

    protected void grdDetailsApprovaldtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Statusid = DataBinder.Eval(e.Row.DataItem, "intStageid").ToString();
                if (Statusid != "")
                {
                    int Statusidnew = Convert.ToInt32(Statusid);
                    if (Statusidnew == 13 || Statusidnew == 14 || Statusidnew == 15 || Statusidnew == 16 || Statusidnew == 22)
                    {
                        e.Row.FindControl("lblverified").Visible = false;
                        e.Row.FindControl("HyperLinkSubsidy").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lblverified").Visible = true;
                        e.Row.FindControl("HyperLinkSubsidy").Visible = false;
                    }
                    if (((HyperLink)e.Row.FindControl("HyperLinkSubsidy")).NavigateUrl == "")
                    {
                        e.Row.FindControl("lblverified").Visible = true;
                        e.Row.FindControl("HyperLinkSubsidy").Visible = false;
                    }
                    if (((HyperLink)e.Row.FindControl("hplpscstataus")).NavigateUrl == "")
                    {
                        e.Row.FindControl("lblpscstataus").Visible = true;
                        e.Row.FindControl("hplpscstataus").Visible = false;
                    }
                }
                if ((Session["uid"].ToString() == "1222" || Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "3377"))
                {
                    string intApprovalid = DataBinder.Eval(e.Row.DataItem, "intApprovalid").ToString();
                    if ((intApprovalid == "6" || intApprovalid == "45") && Statusid != "22" && Statusid != "2" && Statusid != "1")
                    {
                        e.Row.FindControl("lblapprovalname").Visible = false;
                        e.Row.FindControl("hplkapprovalsname").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lblapprovalname").Visible = true;
                        e.Row.FindControl("hplkapprovalsname").Visible = false;
                    }
                }
                else
                {
                    e.Row.FindControl("lblapprovalname").Visible = true;
                    e.Row.FindControl("hplkapprovalsname").Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg.Text = ex.Message;

        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NumberofApprovalsappliedfor"));
        //    NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

        //    decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Completed"));
        //    Completed1 = Completed + Completed1;


        //    decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QueryRaised"));
        //    QueryRaised1 = QueryRaised + QueryRaised1;


        //    decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendinglessthan3days"));
        //    Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

        //    decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendinglessthan3days"));
        //    Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


        //    decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Numberofpaymentreceivedfor"));
        //    Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;


        //}


    }
    protected void grdDetailsApprovaldtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetailsApprovaldtls_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


                TableCell HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "";
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "";
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);
                HeaderCell = new TableCell();



                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "";
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "";
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 4;
                HeaderCell.RowSpan = 1;
                HeaderCell.Font.Bold = true;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "Prescrutiny Status";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                //HeaderCell.Text = "Additions";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                //HeaderCell.Text = "Additions";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.RowSpan = 1;
                HeaderCell.Font.Bold = true;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "Approval Stage";
                HeaderCell.Visible = true;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);

                grdDetailsApprovaldtls.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg.Text = ex.Message;

        }
    }


    public DataSet GetApplicationTrackerDetailed2(string Quesionary_id)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("GetApplicationTrackerDetailed2", con.GetConnection);
            da = new SqlDataAdapter("[GetApplicationTrackerDetailed_CFE_Solution]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            if (Quesionary_id.Trim() == "" || Quesionary_id.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = Quesionary_id.ToString();

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

    public DataSet GetApplicationTrackerDetailed2CFO(string Quesionary_id)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("GetApplicationTrackerDetailed2", con.GetConnection);
            da = new SqlDataAdapter("[GetApplicationTrackerDetailed_CFO_Solution]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            if (Quesionary_id.Trim() == "" || Quesionary_id.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = Quesionary_id.ToString();

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

    protected void ddlcfeactions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlModule.SelectedValue == "2")
            {
                if (ddlcfeactions.SelectedValue == "7")
                {
                    if (ViewState["lblCREATEDBY"] != null && ViewState["lblCREATEDBY"] != "")
                    {
                        Response.Redirect("frmQuesstionniareRegEdit.aspx?intApplicationId=" + ViewState["lblCREATEDBY"].ToString());
                    }
                }
            }
            if (ddlModule.SelectedValue == "2")
            {
                divinitiatrdpaymentdetails.Visible = false;
                divcfertgshdremarks.Visible = false;
                divcfertgsUpload.Visible = false;
                divcfertgs.Visible = false;
                btncfeactionclick.Visible = false;
                txtcfeamount.Text = "";
                txttransnor.Text = "";
                txtbankid.Text = "";
                lblFileName.Text = "";
                txtcfehdid.Text = "";
                txthdRemarks.Text = "";
                divpaymentsuccess.Visible = false;
                gvdpaymentsuccess.DataSource = null;
                gvdpaymentsuccess.DataBind();

                DataSet ds = new DataSet();
                if (ddlcfeactions.SelectedValue == "1" || ddlcfeactions.SelectedValue == "2" || ddlcfeactions.SelectedValue == "3" || ddlcfeactions.SelectedValue == "4" || ddlcfeactions.SelectedValue == "5")
                {
                    DataSet dspay = GetPaymentdtlsinitiated(lblUID.Text.Trim().TrimStart(), ddlcfeactions.SelectedValue);
                    if (dspay != null && dspay.Tables.Count > 0 && dspay.Tables[0].Rows.Count > 0)
                    {
                        gvInitiated.DataSource = dspay.Tables[0];
                        gvInitiated.DataBind();
                        divinitiatrdpaymentdetails.Visible = true;

                        if (ddlcfeactions.SelectedValue == "1" || ddlcfeactions.SelectedValue == "2" || ddlcfeactions.SelectedValue == "5")
                        {
                            divcfertgshdremarks.Visible = true;
                            divcfertgsUpload.Visible = true;
                            divcfertgs.Visible = true;
                        }
                        btncfeactionclick.Visible = true;
                    }
                    else
                    {
                        string errormsgval = "Please Intiate the Transaction and Update the Payment Details";
                        string message = "alert('" + errormsgval + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }
            }
            if (ddlModule.SelectedValue == "3")
            {
                divinitiatrdpaymentdetails.Visible = false;
                divcfertgshdremarks.Visible = false;
                divcfertgsUpload.Visible = false;
                divcfertgs.Visible = false;
                btncfeactionclick.Visible = false;
                txtcfeamount.Text = "";
                txttransnor.Text = "";
                txtbankid.Text = "";
                lblFileName.Text = "";
                txtcfehdid.Text = "";
                txthdRemarks.Text = "";
                divpaymentsuccess.Visible = false;
                gvdpaymentsuccess.DataSource = null;
                gvdpaymentsuccess.DataBind();

                DataSet ds = new DataSet();
                if (ddlcfeactions.SelectedValue == "1" || ddlcfeactions.SelectedValue == "2" || ddlcfeactions.SelectedValue == "3" || ddlcfeactions.SelectedValue == "4" || ddlcfeactions.SelectedValue == "5")
                {
                    DataSet dspay = GetPaymentdtlsinitiatedCFO(lblUID.Text.Trim().TrimStart(), ddlcfeactions.SelectedValue);
                    if (dspay != null && dspay.Tables.Count > 0 && dspay.Tables[0].Rows.Count > 0)
                    {
                        gvInitiated.DataSource = dspay.Tables[0];
                        gvInitiated.DataBind();
                        divinitiatrdpaymentdetails.Visible = true;

                        if (ddlcfeactions.SelectedValue == "1" || ddlcfeactions.SelectedValue == "2" || ddlcfeactions.SelectedValue == "5")
                        {
                            divcfertgshdremarks.Visible = true;
                            divcfertgsUpload.Visible = true;
                            divcfertgs.Visible = true;
                        }
                        btncfeactionclick.Visible = true;
                    }
                    else
                    {
                        string errormsgval = "Please Intiate the Transaction and Update the Payment Details";
                        string message = "alert('" + errormsgval + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetPaymentdtlsinitiated(string Uid, string Paymentgatway)
    {
        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UIDNO",SqlDbType.VarChar),
                new SqlParameter("@Paymentgatway",SqlDbType.VarChar),
           };
            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = Uid;
            pp[1].Value = Paymentgatway;
            Dsnew = Gen.GenericFillDs("[USP_GET_Builldesc_PaymentDtls_DESE_Solution]", pp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }
        return Dsnew;
    }

    public DataSet GetPaymentdtlsinitiatedCFO(string Uid, string Paymentgatway)
    {
        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UIDNO",SqlDbType.VarChar),
                new SqlParameter("@Paymentgatway",SqlDbType.VarChar),
           };
            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = Uid;
            pp[1].Value = Paymentgatway;
            Dsnew = Gen.GenericFillDs("[USP_GET_Builldesc_PaymentDtls_DESE_Solution_CFO]", pp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }
        return Dsnew;
    }

    public DataSet GetPaymentdtlsinitiatedstatus(string Uid)
    {
        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UIDNO",SqlDbType.VarChar),
           };
            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = Uid;
            Dsnew = Gen.GenericFillDs("[USP_PAYMENT_STATUS_SOLUTION]", pp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }
        return Dsnew;
    }
    decimal TotalFee = Convert.ToDecimal("0");
    protected void gvInitiated_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                decimal TotalFee1 = Convert.ToDecimal(e.Row.Cells[2].Text);
                TotalFee = TotalFee + TotalFee1;
            }
            if ((e.Row.RowType == DataControlRowType.Footer))
            {
                e.Row.Cells[1].Text = "Total Fee";
                e.Row.Cells[2].Text = Convert.ToDecimal(TotalFee.ToString()).ToString("#,##0");
                e.Row.Cells[2].Attributes.CssStyle["text-align"] = "Right";
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }
    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        if (ddlModule.SelectedValue == "2")
        {
            try
            {

                string newPath = "";
                //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
                //string sFileDir = "~\\TenderNotice";
                string sFileDir = Server.MapPath("~\\Attachments");


                General t1 = new General();
                if (FileUpload1.HasFile)
                {

                    //Response.Write(FileUpload1.HasFile.ToString());
                    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                    {
                        DataSet dspay = new DataSet();
                        string Questionerid = "", CFeid = "";
                        dspay = GetPaymentdtlsinitiated(lblUID.Text.Trim().TrimStart(), ddlcfeactions.SelectedValue);
                        if (dspay != null && dspay.Tables.Count > 0 && dspay.Tables[0].Rows.Count > 0)
                        {
                            Questionerid = dspay.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                            CFeid = dspay.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                        }
                        //determine file name
                        string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                        //Response.Write(sFileName);
                        try
                        {
                            string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "JPEG")
                            {
                                //Create a new subfolder under the current active folder

                                newPath = System.IO.Path.Combine(sFileDir, CFeid + "\\RTGS Uploads");
                                ViewState["pathDDUpload"] = newPath;
                                ViewState["DDUploadName"] = sFileName;
                                // Create the subfolder
                                if (!Directory.Exists(newPath))
                                    System.IO.Directory.CreateDirectory(newPath);


                                FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                int result = 0;
                                result = t1.InsertImagedata(Questionerid, CFeid, fileType[i - 1].ToUpper(), newPath, sFileName, "RTGS Uploads", "", Session["uid"].ToString(), DateTime.Now.ToString(), Session["uid"].ToString(), DateTime.Now.ToString());

                                if (result > 0)
                                {
                                    //ResetFormControl(this);
                                    //lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                    lblFileName.Text = sFileName;
                                    lblFileName.NavigateUrl = newPath + "\\" + sFileName;
                                    Label434.Text = sFileName;
                                    // success.Visible = true;
                                    // Failure.Visible = false;
                                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                    //fillNews(userid);
                                }
                                else
                                {
                                    // lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                    // success.Visible = false;
                                    // Failure.Visible = true;
                                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                                }
                            }
                            else
                            {
                                // lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                                // success.Visible = false;
                                // Failure.Visible = true;
                                //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                            }

                        }
                        catch (Exception ex)//in case of an error
                        {
                            //lblError.Visible = true;
                            //lblError.Text = "An Error Occured. Please Try Again!";
                            DeleteFile(newPath + "\\" + sFileName);
                            // DeleteFile(sFileDir + sFileName);
                        }
                    }
                }
                else
                {
                    //lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                    //success.Visible = false;
                    //Failure.Visible = true;
                    //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception ex)
            {
                // Response.Write(ex.ToString());
            }
            finally
            {
            }
        }
        if (ddlModule.SelectedValue == "3")
        {
            try
            {

                string newPath = "";
                //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
                //string sFileDir = "~\\TenderNotice";
                string sFileDir = Server.MapPath("~\\CFOAttachments");


                General t1 = new General();
                if (FileUpload1.HasFile)
                {

                    //Response.Write(FileUpload1.HasFile.ToString());
                    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                    {
                        DataSet dspay = new DataSet();
                        string Questionerid = "", CFeid = "";
                        dspay = GetPaymentdtlsinitiatedCFO(lblUID.Text.Trim().TrimStart(), ddlcfeactions.SelectedValue);
                        if (dspay != null && dspay.Tables.Count > 0 && dspay.Tables[0].Rows.Count > 0)
                        {
                            Questionerid = dspay.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                            CFeid = dspay.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                        }
                        //determine file name
                        string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                        //Response.Write(sFileName);
                        try
                        {
                            string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "JPEG")
                            {
                                //Create a new subfolder under the current active folder

                                newPath = System.IO.Path.Combine(sFileDir, CFeid + "\\RTGS Uploads");
                                ViewState["pathDDUpload"] = newPath;
                                ViewState["DDUploadName"] = sFileName;
                                // Create the subfolder
                                if (!Directory.Exists(newPath))
                                    System.IO.Directory.CreateDirectory(newPath);


                                FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                int result = 0;
                                result = t1.InsertImagedataCFO(Questionerid, CFeid, fileType[i - 1].ToUpper(), newPath, sFileName, "RTGS Uploads", "", Session["uid"].ToString(), DateTime.Now.ToString(), Session["uid"].ToString(), DateTime.Now.ToString());

                                if (result > 0)
                                {
                                    //ResetFormControl(this);
                                    //lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                    lblFileName.Text = sFileName;
                                    lblFileName.NavigateUrl = newPath + "\\" + sFileName;
                                    Label434.Text = sFileName;
                                    // success.Visible = true;
                                    // Failure.Visible = false;
                                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                    //fillNews(userid);
                                }
                                else
                                {
                                    // lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                    // success.Visible = false;
                                    // Failure.Visible = true;
                                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                                }
                            }
                            else
                            {
                                // lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                                // success.Visible = false;
                                // Failure.Visible = true;
                                //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                            }

                        }
                        catch (Exception ex)//in case of an error
                        {
                            //lblError.Visible = true;
                            //lblError.Text = "An Error Occured. Please Try Again!";
                            DeleteFile(newPath + "\\" + sFileName);
                            // DeleteFile(sFileDir + sFileName);
                        }
                    }
                }
                else
                {
                    //lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                    //success.Visible = false;
                    //Failure.Visible = true;
                    //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception ex)
            {
                // Response.Write(ex.ToString());
            }
            finally
            {
            }
        }
    }

    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }
    protected void btncfeactionclick_Click(object sender, EventArgs e)
    {
        divpaymentsuccess.Visible = false;
        gvdpaymentsuccess.DataSource = null;
        gvdpaymentsuccess.DataBind();

        string errormsgval = "";
        var footerRow = gvInitiated.FooterRow;
        if (footerRow != null)
        {
            if ((ddlcfeactions.SelectedValue == "1" || ddlcfeactions.SelectedValue == "2"))
            {
                errormsgval = ValidationInputscfeRtgs();
                if (errormsgval.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsgval + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            if (ddlcfeactions.SelectedValue == "7")
            {
                if (ddlModule.SelectedValue == "2")
                {
                    Button ddlDeptnameFnl2 = (Button)sender;
                    GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
                    string enterid = ((Label)row.FindControl("lblintQuessionaireid")).Text;
                    Response.Redirect("");
                }
            }
            DataSet dspay = new DataSet();
            string OnlineTransactionNo = "", Paymentmode = "", Transdate = "", QuestionerID = "";
            if (ddlModule.SelectedValue == "2")
            {
                dspay = GetPaymentdtlsinitiated(lblUID.Text.Trim().TrimStart(), ddlcfeactions.SelectedValue);
                if (dspay != null && dspay.Tables.Count > 0 && dspay.Tables[0].Rows.Count > 0)
                {
                    OnlineTransactionNo = dspay.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                    Paymentmode = dspay.Tables[0].Rows[0]["AddtionalPaymentflg"].ToString();
                    Transdate = dspay.Tables[0].Rows[0]["Transdate"].ToString();
                    QuestionerID = dspay.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                }
                else
                {
                    return;
                }

                if (errormsgval.Trim().TrimStart() == "" && (ddlcfeactions.SelectedValue == "1" || ddlcfeactions.SelectedValue == "2" || ddlcfeactions.SelectedValue == "5"))
                {
                    try
                    {
                        string amt = "";
                        if (ddlcfeactions.SelectedValue == "5")
                        {
                            amt = "0.00";
                        }
                        else
                        {
                            amt = txtcfeamount.Text.Trim();
                        }
                        string msg = "COITS|" + OnlineTransactionNo + "|" + txttransnor.Text.Trim().TrimStart() + "-RTGS" + "|" + txtbankid.Text.Trim().TrimStart() + "|" + amt + "|" + txtbankid.Text.Trim() + "|NA|01|INR|DIRECT|NA|NA|9.44|" + Transdate + "|0300|NA|" + QuestionerID + "|" + lblUID.Text.Trim().TrimStart() + "|CFE|NODEPT|" + Paymentmode + "|0000|0000@rediffmail.com|NA|Completed successfully|F907CB5AC58BC60F1CDFBCAE242F4BF9CCC86D1FDAD908CA1A4970ADFA5C9DA4";

                        if (msg != null)
                        {
                            //MerchantID|CustomerID|TxnReferenceNo|BankReferenceNo|TxnAmount|BankID|BIN|TxnTy
                            //pe|CurrencyName|ItemCode|SecurityType|SecurityID|SecurityPassword|TxnDate|AuthStatu
                            //s|SettlementType|AdditionalInfo1|AdditionalInfo2|AdditionalInfo3|AdditionalInfo4|Additional
                            //Info5|AdditionalInfo6|AdditionalInfo7|ErrorStatus|ErrorDescription|CheckSum

                            string BilldeskResponse = msg;

                            try
                            {
                                GetTESTVALUES(BilldeskResponse);
                            }
                            catch (Exception ex)
                            {

                            }
                            // string BilldeskResponse = msg;
                            string[] values = BilldeskResponse.Split('|');

                            paymentresponseVOsobj.MerchantID_0 = values[0];
                            paymentresponseVOsobj.CustomerID_1 = values[17];   // UID Number
                            paymentresponseVOsobj.TxnReferenceNo_2 = values[2];
                            paymentresponseVOsobj.BankReferenceNo_3 = values[3];
                            paymentresponseVOsobj.TxnAmount_4 = values[4];
                            paymentresponseVOsobj.BankID_5 = values[5];
                            paymentresponseVOsobj.BIN_6 = values[6];
                            paymentresponseVOsobj.TxnType_7 = values[7];
                            paymentresponseVOsobj.CurrencyName_8 = values[8];
                            paymentresponseVOsobj.ItemCode_9 = values[9];
                            paymentresponseVOsobj.SecurityType_10 = values[10];
                            paymentresponseVOsobj.SecurityID_11 = values[11];
                            paymentresponseVOsobj.SecurityPassword_12 = values[12];
                            string[] date = values[13].Split(' ');
                            string[] newdate = date[0].ToString().Split('-');
                            paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();
                            paymentresponseVOsobj.AuthStatus_14 = values[14];
                            paymentresponseVOsobj.SettlementType_15 = values[15];
                            paymentresponseVOsobj.AdditionalInfo1_16 = values[16];   // Questionaireid
                            paymentresponseVOsobj.AdditionalInfo2_17 = values[1];    // TSipassOrderNumber
                            paymentresponseVOsobj.AdditionalInfo3_18 = values[18];   // ApplicationType
                            paymentresponseVOsobj.AdditionalInfo4_19 = values[19];   // Departmentdetails
                            paymentresponseVOsobj.AdditionalInfo5_20 = values[20];   //  AddtionalPayment flag
                            paymentresponseVOsobj.AdditionalInfo6_21 = values[21];
                            paymentresponseVOsobj.AdditionalInfo7_22 = values[22];
                            paymentresponseVOsobj.ErrorStatus_23 = values[23];
                            paymentresponseVOsobj.ErrorDescription_24 = values[24];
                            paymentresponseVOsobj.CheckSum_25 = values[25];
                            paymentresponseVOsobj.Createdby = Session["uid"].ToString();   //"17311";//


                            //“0300”   Success                                           Successful Transaction
                            //“0399”   Invalid Authentication at Bank                    Cancel Transaction
                            //“NA”     Invalid Input in the Request Message              Cancel Transaction
                            //“0002”   BillDesk is waiting for Response from Bank        Cancel Transaction
                            //“0001”   Error at BillDesk                                 Cancel Transaction

                            if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                            {
                                DataSet dspaydtls = new DataSet();
                                if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                                {
                                    dspaydtls = Gen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                    //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                    if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                    {
                                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                    }
                                }
                                else
                                {
                                    dspaydtls = Gen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                    //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                    if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                    {
                                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                    }
                                }
                            }
                            if (paymentresponseVOsobj.AdditionalInfo5_20 == "NA")
                            {
                                paymentresponseVOsobj.AdditionalInfo5_20 = "";
                            }
                            List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj = new List<paymendepartwisetresponseVOs>();
                            string[] deptvalues = paymentresponseVOsobj.AdditionalInfo4_19.Split('&');
                            for (int i = 0; i < deptvalues.Length; i++)
                            {
                                string[] deptwisevalues = deptvalues[i].Split('#');
                                paymendepartwisetresponseVOs payment = new paymendepartwisetresponseVOs();
                                payment.Questionnaireid = deptwisevalues[0].ToString();
                                payment.intEnterprenerid = deptwisevalues[1].ToString();
                                payment.Departmentid = deptwisevalues[2].ToString();
                                payment.CustomerID_1 = deptwisevalues[3].ToString();
                                payment.DeptAmount = deptwisevalues[4].ToString();
                                payment.intApprovalid = deptwisevalues[5].ToString();
                                payment.TxnDate_13 = paymentresponseVOsobj.TxnDate_13;
                                payment.TxnReferenceNo_2 = paymentresponseVOsobj.TxnReferenceNo_2;
                                payment.BankReferenceNo_3 = paymentresponseVOsobj.BankReferenceNo_3;
                                payment.TxnAmount_4 = paymentresponseVOsobj.TxnAmount_4;
                                payment.BankID_5 = paymentresponseVOsobj.BankID_5;
                                payment.Createdby = paymentresponseVOsobj.Createdby;
                                payment.AdditionalPaymentFlag = paymentresponseVOsobj.AdditionalInfo5_20;
                                payment.Ipaddress = getclientIP();
                                payment.HDid = txtcfehdid.Text.Trim().TrimStart();
                                payment.HDRemarks = txthdRemarks.Text.Trim().TrimStart();
                                payment.TransactionType = ddlcfeactions.SelectedItem.Text;
                                payment.DocPath = lblFileName.Text.Trim().TrimStart();
                                payment.TypeofOfflineUpdate = ddlcfeactions.SelectedValue;
                                paymendepartwisetresponseVOsobj.Add(payment);
                            }

                            if (paymentresponseVOsobj.AuthStatus_14 == "0300")
                            {
                                int valid = InsertUpdatepaymentdtls(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                if (valid == 1)
                                {
                                    //  LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                    Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                    Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                    Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                    Response.Redirect("IpassPrintReceipt.aspx");
                                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceipt.aspx';", true);
                                }
                            }
                            else
                            {
                                errormsgval = "Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24;
                                if (errormsgval.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsgval + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                    return;
                                }

                                // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                                // Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='HomeDashboard.aspx';", true);
                                // Response.Redirect("HomeDashboard.aspx");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                        // LogErrorToText(ex);
                    }
                }
                else if (errormsgval.Trim().TrimStart() == "" && ddlcfeactions.SelectedValue == "4")
                {

                    objwebservice.callbilldeskpage(OnlineTransactionNo);
                    DataSet ds = new DataSet();
                    ds = GetPaymentdtlsinitiatedstatus(lblUID.Text.Trim().TrimStart());
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        divpaymentsuccess.Visible = true;
                        gvdpaymentsuccess.DataSource = ds.Tables[0];
                        gvdpaymentsuccess.DataBind();
                    }
                    else
                    {
                        divpaymentsuccess.Visible = false;
                        gvdpaymentsuccess.DataSource = null;
                        gvdpaymentsuccess.DataBind();
                    }
                    errormsgval = "Payment Gateway Called Successfully. kindly Check Status in Below Grid";
                    if (errormsgval.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgval + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }



                }
            }
            if (ddlModule.SelectedValue == "3")
            {
                dspay = GetPaymentdtlsinitiatedCFO(lblUID.Text.Trim().TrimStart(), ddlcfeactions.SelectedValue);
                if (dspay != null && dspay.Tables.Count > 0 && dspay.Tables[0].Rows.Count > 0)
                {
                    OnlineTransactionNo = dspay.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                    Paymentmode = dspay.Tables[0].Rows[0]["AddtionalPaymentflg"].ToString();
                    Transdate = dspay.Tables[0].Rows[0]["Transdate"].ToString();
                    QuestionerID = dspay.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                }
                else
                {
                    return;
                }

                if (errormsgval.Trim().TrimStart() == "" && (ddlcfeactions.SelectedValue == "1" || ddlcfeactions.SelectedValue == "2" || ddlcfeactions.SelectedValue == "5"))
                {
                    try
                    {
                        string amt = "";
                        if (ddlcfeactions.SelectedValue == "5")
                        {
                            amt = "0.00";
                        }
                        else
                        {
                            amt = txtcfeamount.Text.Trim();
                        }
                        string msg = "COITS|" + OnlineTransactionNo + "|" + txttransnor.Text.Trim().TrimStart() + "-RTGS" + "|" + txtbankid.Text.Trim().TrimStart() + "|" + amt + "|" + txtbankid.Text.Trim() + "|NA|01|INR|DIRECT|NA|NA|9.44|" + Transdate + "|0300|NA|" + QuestionerID + "|" + lblUID.Text.Trim().TrimStart() + "|CFO|NODEPT|" + Paymentmode + "|0000|0000@rediffmail.com|NA|Completed successfully|F907CB5AC58BC60F1CDFBCAE242F4BF9CCC86D1FDAD908CA1A4970ADFA5C9DA4";

                        if (msg != null)
                        {
                            //MerchantID|CustomerID|TxnReferenceNo|BankReferenceNo|TxnAmount|BankID|BIN|TxnTy
                            //pe|CurrencyName|ItemCode|SecurityType|SecurityID|SecurityPassword|TxnDate|AuthStatu
                            //s|SettlementType|AdditionalInfo1|AdditionalInfo2|AdditionalInfo3|AdditionalInfo4|Additional
                            //Info5|AdditionalInfo6|AdditionalInfo7|ErrorStatus|ErrorDescription|CheckSum

                            string BilldeskResponse = msg;

                            try
                            {
                                GetTESTVALUES(BilldeskResponse);
                            }
                            catch (Exception ex)
                            {

                            }
                            // string BilldeskResponse = msg;
                            string[] values = BilldeskResponse.Split('|');

                            paymentresponseVOsobj.MerchantID_0 = values[0];
                            paymentresponseVOsobj.CustomerID_1 = values[17];   // UID Number
                            paymentresponseVOsobj.TxnReferenceNo_2 = values[2];
                            paymentresponseVOsobj.BankReferenceNo_3 = values[3];
                            paymentresponseVOsobj.TxnAmount_4 = values[4];
                            paymentresponseVOsobj.BankID_5 = values[5];
                            paymentresponseVOsobj.BIN_6 = values[6];
                            paymentresponseVOsobj.TxnType_7 = values[7];
                            paymentresponseVOsobj.CurrencyName_8 = values[8];
                            paymentresponseVOsobj.ItemCode_9 = values[9];
                            paymentresponseVOsobj.SecurityType_10 = values[10];
                            paymentresponseVOsobj.SecurityID_11 = values[11];
                            paymentresponseVOsobj.SecurityPassword_12 = values[12];
                            string[] date = values[13].Split(' ');
                            string[] newdate = date[0].ToString().Split('-');
                            paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();
                            paymentresponseVOsobj.AuthStatus_14 = values[14];
                            paymentresponseVOsobj.SettlementType_15 = values[15];
                            paymentresponseVOsobj.AdditionalInfo1_16 = values[16];   // Questionaireid
                            paymentresponseVOsobj.AdditionalInfo2_17 = values[1];    // TSipassOrderNumber
                            paymentresponseVOsobj.AdditionalInfo3_18 = values[18];   // ApplicationType
                            paymentresponseVOsobj.AdditionalInfo4_19 = values[19];   // Departmentdetails
                            paymentresponseVOsobj.AdditionalInfo5_20 = values[20];   //  AddtionalPayment flag
                            paymentresponseVOsobj.AdditionalInfo6_21 = values[21];
                            paymentresponseVOsobj.AdditionalInfo7_22 = values[22];
                            paymentresponseVOsobj.ErrorStatus_23 = values[23];
                            paymentresponseVOsobj.ErrorDescription_24 = values[24];
                            paymentresponseVOsobj.CheckSum_25 = values[25];
                            paymentresponseVOsobj.Createdby = Session["uid"].ToString();   //"17311";//


                            //“0300”   Success                                           Successful Transaction
                            //“0399”   Invalid Authentication at Bank                    Cancel Transaction
                            //“NA”     Invalid Input in the Request Message              Cancel Transaction
                            //“0002”   BillDesk is waiting for Response from Bank        Cancel Transaction
                            //“0001”   Error at BillDesk                                 Cancel Transaction

                            if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                            {
                                DataSet dspaydtls = new DataSet();
                                if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                                {
                                    dspaydtls = Gen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                    //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                    if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                    {
                                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                    }
                                }
                                else
                                {
                                    dspaydtls = Gen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                    //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                    if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                    {
                                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                    }
                                }
                            }
                            if (paymentresponseVOsobj.AdditionalInfo5_20 == "NA")
                            {
                                paymentresponseVOsobj.AdditionalInfo5_20 = "";
                            }
                            List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj = new List<paymendepartwisetresponseVOs>();
                            string[] deptvalues = paymentresponseVOsobj.AdditionalInfo4_19.Split('&');
                            for (int i = 0; i < deptvalues.Length; i++)
                            {
                                string[] deptwisevalues = deptvalues[i].Split('#');
                                paymendepartwisetresponseVOs payment = new paymendepartwisetresponseVOs();
                                payment.Questionnaireid = deptwisevalues[0].ToString();
                                payment.intEnterprenerid = deptwisevalues[1].ToString();
                                payment.Departmentid = deptwisevalues[2].ToString();
                                payment.CustomerID_1 = deptwisevalues[3].ToString();
                                payment.DeptAmount = deptwisevalues[4].ToString();
                                payment.intApprovalid = deptwisevalues[5].ToString();
                                payment.TxnDate_13 = paymentresponseVOsobj.TxnDate_13;
                                payment.TxnReferenceNo_2 = paymentresponseVOsobj.TxnReferenceNo_2;
                                payment.BankReferenceNo_3 = paymentresponseVOsobj.BankReferenceNo_3;
                                payment.TxnAmount_4 = paymentresponseVOsobj.TxnAmount_4;
                                payment.BankID_5 = paymentresponseVOsobj.BankID_5;
                                payment.Createdby = paymentresponseVOsobj.Createdby;
                                payment.AdditionalPaymentFlag = paymentresponseVOsobj.AdditionalInfo5_20;
                                payment.Ipaddress = getclientIP();
                                payment.HDid = txtcfehdid.Text.Trim().TrimStart();
                                payment.HDRemarks = txthdRemarks.Text.Trim().TrimStart();
                                payment.TransactionType = ddlcfeactions.SelectedItem.Text;
                                payment.DocPath = lblFileName.Text.Trim().TrimStart();
                                payment.TypeofOfflineUpdate = ddlcfeactions.SelectedValue;
                                paymendepartwisetresponseVOsobj.Add(payment);
                            }

                            if (paymentresponseVOsobj.AuthStatus_14 == "0300")
                            {
                                int valid = InsertUpdatepaymentdtlscfo(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                if (valid == 1)
                                {
                                    //  LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                    Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                    Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                    Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                    Response.Redirect("IpassPrintReceiptCFO.aspx");
                                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceipt.aspx';", true);
                                }
                            }
                            else
                            {
                                errormsgval = "Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24;
                                if (errormsgval.Trim().TrimStart() != "")
                                {
                                    string message = "alert('" + errormsgval + "')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                    return;
                                }

                                // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                                // Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='HomeDashboard.aspx';", true);
                                // Response.Redirect("HomeDashboard.aspx");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                        // LogErrorToText(ex);
                    }
                }
                else if (errormsgval.Trim().TrimStart() == "" && ddlcfeactions.SelectedValue == "4")
                {

                    objwebservice.callbilldeskpage(OnlineTransactionNo);
                    DataSet ds = new DataSet();
                    ds = GetPaymentdtlsinitiatedstatus(lblUID.Text.Trim().TrimStart());
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        divpaymentsuccess.Visible = true;
                        gvdpaymentsuccess.DataSource = ds.Tables[0];
                        gvdpaymentsuccess.DataBind();
                    }
                    else
                    {
                        divpaymentsuccess.Visible = false;
                        gvdpaymentsuccess.DataSource = null;
                        gvdpaymentsuccess.DataBind();
                    }
                    errormsgval = "Payment Gateway Called Successfully. kindly Check Status in Below Grid";
                    if (errormsgval.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgval + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }



                }
            }
        }
    }

    public string ValidationInputscfeRtgs()
    {

        Decimal Emount = Convert.ToDecimal(gvInitiated.FooterRow.Cells[2].Text.ToString().Replace(",", ""));

        int slno = 1;
        string ErrorMsg = "";

        if (txtcfeamount.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter the Amount\\n";
            slno = slno + 1;
        }
        if (txtcfeamount.Text.Trim() != "")
        {
            if (Emount <= Convert.ToDecimal(txtcfeamount.Text))
            {

            }
            else
            {
                ErrorMsg = ErrorMsg + slno + ". The Paid amount should not be less than to actual paid amount \\n";
                slno = slno + 1;
            }
        }
        if (txttransnor.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter The Transation/UTI Number\\n";
            slno = slno + 1;
        }
        if (txtbankid.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Bank Code\\n";
            slno = slno + 1;
        }
        if (txtcfehdid.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter HD ID \\n";
            slno = slno + 1;
        }
        if (txthdRemarks.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Remarks\\n";
            slno = slno + 1;
        }

        if (ddlcfeactions.SelectedValue == "1" || ddlcfeactions.SelectedValue == "2" || ddlcfeactions.SelectedValue == "5")
        {
            if (lblFileName.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Upload Payment Proof Certificate\\n";
                slno = slno + 1;
            }
        }

        return ErrorMsg;
    }

    public void GetTESTVALUES(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_TEST_WEBSERVISE", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@Online", SqlDbType.VarChar).Value = "HDSOLUTION";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
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

    public int InsertUpdatepaymentdtls(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int valid1 = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_Builldesc_PaymentDtls]", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;
        SqlCommand command2 = null;

        try
        {
            command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
            command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
            command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
            command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
            command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
            command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
            command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
            command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
            command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
            command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
            command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
            command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
            command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
            command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
            command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
            command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
            command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
            command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
            command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
            command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
            command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
            command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
            command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
            command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
            command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            if (valid == 1)
            {
                foreach (paymendepartwisetresponseVOs ffvo in paymendepartwisetresponseVOsobj)
                {
                    command1 = new SqlCommand("[USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls]", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
                    command1.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
                    command1.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
                    command1.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
                    command1.Parameters.AddWithValue("@TxnDate_13", ffvo.TxnDate_13);
                    command1.Parameters.AddWithValue("@TxnReferenceNo_2", ffvo.TxnReferenceNo_2);
                    command1.Parameters.AddWithValue("@BankReferenceNo_3", ffvo.BankReferenceNo_3);
                    command1.Parameters.AddWithValue("@Deptamont", ffvo.DeptAmount);
                    command1.Parameters.AddWithValue("@TxnAmount_4", ffvo.TxnAmount_4);
                    command1.Parameters.AddWithValue("@BankID_5", ffvo.BankID_5);
                    command1.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
                    command1.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
                    command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command1.Transaction = trans;
                    command1.ExecuteNonQuery();
                    valid = (Int32)command1.Parameters["@VALID"].Value;
                    if (valid == 1)
                    {
                        command2 = new SqlCommand("USP_UPD_HELPDESKCFEPAYMENT_DETAILS", connection);
                        command2.CommandType = CommandType.StoredProcedure;
                        command2.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
                        command2.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
                        command2.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
                        command2.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
                        command2.Parameters.AddWithValue("@HDREMARKS", SqlDbType.VarChar).Value = ffvo.HDRemarks;
                        command2.Parameters.AddWithValue("@HdId", SqlDbType.VarChar).Value = ffvo.HDid;
                        command2.Parameters.AddWithValue("@Ipaddress", SqlDbType.VarChar).Value = ffvo.Ipaddress;
                        command2.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
                        command2.Parameters.AddWithValue("@TransactionType", ffvo.TransactionType);
                        command2.Parameters.AddWithValue("@DocPath", ffvo.DocPath);
                        command2.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
                        command2.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
                        command2.Parameters.AddWithValue("@TypeofOfflineUpdate", ffvo.TypeofOfflineUpdate);

                        command2.Parameters.Add("@VALID", SqlDbType.Int, 500);
                        command2.Parameters["@VALID"].Direction = ParameterDirection.Output;
                        command2.Transaction = trans;
                        command2.ExecuteNonQuery();
                        valid1 = (Int32)command1.Parameters["@VALID"].Value;
                    }
                }
            }
            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in gvcfefaileddata.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkcheckapps");
                if (chk.Checked)
                {
                    string UIDNO = ((Label)row.FindControl("lblUIDNO")).Text;
                    string INTQUESTIONNAIREID = ((Label)row.FindControl("lblINTQUESTIONNAIREID")).Text;
                    string INTAPPROVALID = ((Label)row.FindControl("lbINTAPPROVALID")).Text;
                    try
                    {
                        CFesenddata.webservicecfe(UIDNO);
                    }
                    catch (Exception ex)
                    {
                        LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

                    }
                }
            }
        }
        catch (Exception ex2)
        {

        }
        DataSet ds = new DataSet();
        ds = GetCFEFailedUpdateDtls("2017/06/06", System.DateTime.Today.ToString("yyyy/MM/dd"), "ALL", "N");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvcfefaileddata.DataSource = ds.Tables[0];
            gvcfefaileddata.DataBind();
            divcfefailedwebservices.Visible = true;
        }
        else
        {
            divcfefailedwebservices.Visible = false;
        }

        string errormsgval = "Updated Successfully";
        if (errormsgval.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsgval + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    public DataSet GetCFOFailedUpdateDtls(string FROMDATE, string TODATE, string DEPARTMENTID, string STATUS)
    {

        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@FROMDATE",SqlDbType.VarChar),
               new SqlParameter("@TODATE",SqlDbType.VarChar),
               new SqlParameter("@DEPARTMENTID",SqlDbType.VarChar),
               new SqlParameter("@STATUS",SqlDbType.VarChar)
           };

            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = FROMDATE;
            pp[1].Value = TODATE;
            pp[2].Value = DEPARTMENTID;
            pp[3].Value = STATUS;

            Dsnew = Gen.GenericFillDs("[USP_GET_WEBSERVICE_REPORT_CFO]", pp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }
        return Dsnew;
    }

    protected void btnupdatecfo_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in gvcfofaileddata.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkcheckapps");
                if (chk.Checked)
                {
                    string UIDNO = ((Label)row.FindControl("lblUIDNO")).Text;
                    string INTQUESTIONNAIREID = ((Label)row.FindControl("lblINTQUESTIONNAIREID")).Text;
                    string INTAPPROVALID = ((Label)row.FindControl("lbINTAPPROVALID")).Text;
                    try
                    {
                        CFosenddata.webservicecfo(UIDNO);
                    }
                    catch (Exception ex)
                    {
                        LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                    }
                }
            }
        }
        catch (Exception ex2)
        {

        }
        DataSet ds = new DataSet();
        ds = GetCFOFailedUpdateDtls("2017/06/06", System.DateTime.Today.ToString("yyyy/MM/dd"), "ALL", "N");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvcfofaileddata.DataSource = ds.Tables[0];
            gvcfofaileddata.DataBind();
            divcfofailedwebservices.Visible = true;
        }
        else
        {
            divcfofailedwebservices.Visible = false;
        }

        string errormsgval = "Updated Successfully";
        if (errormsgval.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsgval + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    public int InsertUpdatepaymentdtlscfo(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_Builldesc_PaymentDtls_CFO]", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
            command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
            command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
            command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
            command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
            command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
            command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
            command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
            command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
            command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
            command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
            command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
            command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
            command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
            command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
            command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
            command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
            command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
            command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
            command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
            command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
            command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
            command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
            command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
            command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            if (valid == 1)
            {
                foreach (paymendepartwisetresponseVOs ffvo in paymendepartwisetresponseVOsobj)
                {
                    command1 = new SqlCommand("[USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls_CFO]", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
                    command1.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
                    command1.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
                    command1.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
                    command1.Parameters.AddWithValue("@TxnDate_13", ffvo.TxnDate_13);
                    command1.Parameters.AddWithValue("@TxnReferenceNo_2", ffvo.TxnReferenceNo_2);
                    command1.Parameters.AddWithValue("@BankReferenceNo_3", ffvo.BankReferenceNo_3);
                    command1.Parameters.AddWithValue("@Deptamont", ffvo.DeptAmount);
                    command1.Parameters.AddWithValue("@TxnAmount_4", ffvo.TxnAmount_4);
                    command1.Parameters.AddWithValue("@BankID_5", ffvo.BankID_5);
                    command1.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
                    command1.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
                    command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command1.Transaction = trans;
                    command1.ExecuteNonQuery();
                    valid = (Int32)command1.Parameters["@VALID"].Value;
                }
            }
            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }

    public DataSet GetRENFailedUpdateDtls(string FROMDATE, string TODATE, string DEPARTMENTID, string STATUS)
    {

        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@FROMDATE",SqlDbType.VarChar),
               new SqlParameter("@TODATE",SqlDbType.VarChar),
               new SqlParameter("@DEPARTMENTID",SqlDbType.VarChar),
               new SqlParameter("@STATUS",SqlDbType.VarChar)
           };

            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = FROMDATE;
            pp[1].Value = TODATE;
            pp[2].Value = DEPARTMENTID;
            pp[3].Value = STATUS;

            Dsnew = Gen.GenericFillDs("[USP_GET_WEBSERVICE_REPORT_REN]", pp);
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }
        return Dsnew;
    }

    protected void btnupdateRen_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in gvrenfaileddata.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkcheckapps");
                if (chk.Checked)
                {
                    string UIDNO = ((Label)row.FindControl("lblUIDNO")).Text;
                    string INTQUESTIONNAIREID = ((Label)row.FindControl("lblINTQUESTIONNAIREID")).Text;
                    string INTAPPROVALID = ((Label)row.FindControl("lbINTAPPROVALID")).Text;
                    try
                    {
                        Rensenddata.webserviceren(UIDNO);
                    }
                    catch (Exception ex)
                    {
                        LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                    }
                }
            }
        }
        catch (Exception ex2)
        {

        }
        DataSet ds = new DataSet();
        ds = GetRENFailedUpdateDtls("2017/08/06", System.DateTime.Today.ToString("yyyy/MM/dd"), "ALL", "N");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvrenfaileddata.DataSource = ds.Tables[0];
            gvrenfaileddata.DataBind();
            divRenfailedwebservices.Visible = true;
        }
        else
        {
            divRenfailedwebservices.Visible = false;
        }

        string errormsgval = "Updated Successfully";
        if (errormsgval.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsgval + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    public DataSet GettsiicplotFailedUpdateDtls(string FROMDATE, string TODATE, string DEPARTMENTID, string STATUS)
    {

        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@FROMDATE",SqlDbType.VarChar),
               new SqlParameter("@TODATE",SqlDbType.VarChar),
               new SqlParameter("@DEPARTMENTID",SqlDbType.VarChar),
               new SqlParameter("@STATUS",SqlDbType.VarChar)
           };

            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = FROMDATE;
            pp[1].Value = TODATE;
            pp[2].Value = DEPARTMENTID;
            pp[3].Value = STATUS;

            Dsnew = Gen.GenericFillDs("[USP_GET_WEBSERVICE_REPORT_tsiicplotallotment]", pp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }
        return Dsnew;
    }

    protected void btnupdatetsiic_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in grdtsiic.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkcheckapps");
                if (chk.Checked)
                {
                    string UIDNO = ((Label)row.FindControl("lblUIDNO")).Text;
                    string INTQUESTIONNAIREID = ((Label)row.FindControl("lblINTQUESTIONNAIREID")).Text;
                    string INTAPPROVALID = ((Label)row.FindControl("lbINTAPPROVALID")).Text;
                    try
                    {

                        tsiicdata.TSiicdetailsdata(Convert.ToInt32(INTAPPROVALID), Convert.ToInt32(INTQUESTIONNAIREID));

                    }
                    catch (Exception ex)
                    {
                        LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

                    }


                }
            }
        }
        catch (Exception ex2)
        {

        }



        DataSet ds = new DataSet();
        ds = GettsiicplotFailedUpdateDtls("2017/08/06", System.DateTime.Today.ToString("yyyy/MM/dd"), "ALL", "N");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdtsiic.DataSource = ds.Tables[0];
            grdtsiic.DataBind();
            divplottsiicfailedservice.Visible = true;
            divplottsiicfailedservice.Visible = true;
        }
        else
        {
            divplottsiicfailedservice.Visible = false;
            divtsiicupdate.Visible = false;
        }

        string errormsgval = "Updated Successfully";
        if (errormsgval.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsgval + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

    }
    protected void btnupdateBMW_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in gvBMWfaileddata.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkcheckapps");
                if (chk.Checked)
                {
                    string UIDNO = ((Label)row.FindControl("lblUIDNO")).Text;
                    string INTQUESTIONNAIREID = ((Label)row.FindControl("lblINTQUESTIONNAIREID")).Text;
                    string INTAPPROVALID = ((Label)row.FindControl("lbINTAPPROVALID")).Text;
                    try
                    {
                        BMWsenddata.webserviceBMW(UIDNO);
                    }
                    catch (Exception ex)
                    {
                        LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

                    }
                }
            }
        }
        catch (Exception ex2)
        {

        }
        DataSet ds = new DataSet();
        ds = GetBMWFailedUpdateDtls("2017/08/06", System.DateTime.Today.ToString("yyyy/MM/dd"), "ALL", "N");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvBMWfaileddata.DataSource = ds.Tables[0];
            gvBMWfaileddata.DataBind();
            divBMWfailedwebservices.Visible = true;
        }
        else
        {
            divBMWfailedwebservices.Visible = false;
        }

        string errormsgval = "Updated Successfully";
        if (errormsgval.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsgval + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }
    public DataSet GetBMWFailedUpdateDtls(string FROMDATE, string TODATE, string DEPARTMENTID, string STATUS)
    {

        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@FROMDATE",SqlDbType.VarChar),
               new SqlParameter("@TODATE",SqlDbType.VarChar),
               new SqlParameter("@DEPARTMENTID",SqlDbType.VarChar),
               new SqlParameter("@STATUS",SqlDbType.VarChar)
           };

            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = FROMDATE;
            pp[1].Value = TODATE;
            pp[2].Value = DEPARTMENTID;
            pp[3].Value = STATUS;

            Dsnew = Gen.GenericFillDs("[USP_GET_WEBSERVICE_REPORT_BMW]", pp);
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }
        return Dsnew;
    }
}