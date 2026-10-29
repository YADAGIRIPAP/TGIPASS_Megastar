using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Org.BouncyCastle.Asn1.Ocsp;
//using System.Reflection.Emit;

public partial class UI_TSiPASS_IncentiveStatusDetailsNew : System.Web.UI.Page
{
    String uid;  //this.Page_Load(null, null);
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    public static DataSet dsOfficers { get; set; }
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        string status = Request.QueryString[0].ToString().Trim();
        string distid = Session["DistrictID"].ToString().Trim();



        //if (!IsPostBack)
        //{
        //    getdistricts();
        //    fetchIncentivedet();

        //}
        if (!IsPostBack)
        {
            getdistricts();
            getincentives();
            Officers(distid);
        }
        if (Request.QueryString.Count > 0)
        {


            if (!IsPostBack)
            {
                ddlDistrict.SelectedValue = distid;
                ddlDistrict.Enabled = false;
                if (Session["DistrictID"].ToString().Trim() == null || Session["DistrictID"].ToString().Trim() == "")
                {
                    ddlDistrict.Enabled = true;
                }
                //grdDetails.Columns[7].Visible = false;
                //grdDetails.Columns[8].Visible = false;
            }
        }
        else
        {

            ddlDistrict.SelectedValue = distid;
            ddlDistrict.Enabled = false;
        }

        if (!IsPostBack)
        {
            //getdistricts();
            fetchIncentivedet();

        }
        


    }
    public void Officers(string DistID)
    {
        try
        {
            //DataSet dsnew = new DataSet();

            dsOfficers = Gen.GetDepartmentINcentiveNew(DistID);//distid    DistID

        }
        catch (Exception ex)
        {

            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void GetDepartment()
    {

    }
    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetDistrictsbystate("%");

        ddlDistrict.DataSource = dsnew.Tables[0];
        ddlDistrict.DataTextField = "District_Name";
        ddlDistrict.DataValueField = "District_Id";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, "--Select--");
    }
    protected void getincentives()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetIncentives();

        ddlIncentiveName.DataSource = dsnew.Tables[0];
        ddlIncentiveName.DataTextField = "IncentiveName";
        ddlIncentiveName.DataValueField = "IncentiveID";
        ddlIncentiveName.DataBind();
        ddlIncentiveName.Items.Insert(0, "--Select--");
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        fetchIncentivedet();
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        LinkButton lnkViewQuery = (LinkButton)sender;
        GridViewRow row = (GridViewRow)lnkViewQuery.NamingContainer;
        DataSet ds = (DataSet)Session["DS4Grid"];
        string INCId = ds.Tables[0].Rows[row.RowIndex]["IncentveID"].ToString();
        Response.Redirect("/UI/TSiPASS/frmResptoIncQry.aspx?EntrpId='" + INCId + "'");
    }
    protected void fetchIncentivedet()
    {
        DataSet ds = new DataSet();

        uid = Session["uid"].ToString();

        ds = Gen.fetchIncentivedetnewSearchNewIncType(ddlDistrict.SelectedValue, Session["User_Code"].ToString(), Request.QueryString[0].ToString().Trim(), uid);

        //  ds = Gen.fetchIncentivedetnewSearch(ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), Session["User_Code"].ToString(), Request.QueryString[0].ToString().Trim(),ddlIncentiveName.SelectedValue,txtFromDate.Text,txtToDate.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvdetailsnew.DataSource = ds.Tables[0];
            gvdetailsnew.DataBind();

            if (Request.QueryString[0].ToString() == "71" || Request.QueryString[0].ToString() == "1171" || Request.QueryString[0].ToString() == "72")
            {
                grdOfficer.DataSource = ds.Tables[0];
                grdOfficer.DataBind();
                if (Request.QueryString[0].ToString() == "71" || Request.QueryString[0].ToString() == "72")
                    grdOfficer.Columns[14].Visible = true;
                else if (Request.QueryString[0].ToString() == "1171")
                    grdOfficer.Columns[15].Visible = true;
                grdOfficer.Visible = true;
                gvdetailsnew.Visible = false;
            }
            else
            {
                grdOfficer.Visible = false;
                gvdetailsnew.Visible = true;
            }

            lblMsg.Text = "Total Records : " + ds.Tables[0].Rows.Count.ToString();
            // grdDetails.DataSource = ds.Tables[0];

            Session["DS4Grid"] = ds;
            // grdDetails.DataBind();
            if (Request.QueryString.Count > 0)
            {
                
                if (Request.QueryString[0].ToString().Trim() == "3" || Request.QueryString[0].ToString().Trim() == "5" || Request.QueryString[0].ToString().Trim() == "10" || Request.QueryString[0].ToString().Trim() == "11")
                {
                    if (Session["uid"].ToString() == "1213" || (Convert.ToInt32(Session["User_Code"].ToString()) >= 46 && Convert.ToInt32(Session["User_Code"].ToString()) <= 55))
                    {
                        grdDetails.Columns[14].Visible = false;
                    }
                    else
                    {
                        grdDetails.Columns[14].Visible = true;
                    }
                }
                else
                {
                    grdDetails.Columns[14].Visible = false;
                }
                //if (Request.QueryString[0].ToString().Trim() == "3T" || Request.QueryString[0].ToString().Trim() == "3IM" || Request.QueryString[0].ToString().Trim() == "3IT" || Request.QueryString[0].ToString().Trim() == "3IO")
                //{
                //    grdDetails.Columns[14].Visible = false;
                //}
                //else
                //{
                //    grdDetails.Columns[14].Visible = true;
                //}
                
            }
        }
        else
        {
            lblMsg.Text = "";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ddlstatus.SelectedIndex = 0;
        ddlDistrict.SelectedIndex = 0;
        TxtIndname.Text = "";
        fetchIncentivedet();
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;
        fetchIncentivedet();
    }


    protected void ddlDeptname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList ddlDeptname = (e.Row.FindControl("ddlDeptname") as DropDownList);
            LinkButton oLinkButton = (e.Row.FindControl("lbStockNumber") as LinkButton);
            GridView GrdInc = (e.Row.FindControl("GrdInc") as GridView);
            LinkButton olnkView = (e.Row.FindControl("lnkView") as LinkButton);


            DataSet dsnew = new DataSet();
            if (Request.QueryString[0].ToString().Trim() == "3" || Request.QueryString[0].ToString().Trim() == "5")
            {
                dsnew = Gen.GetDepartmentINcentive(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistID")).Trim());//distid    DistID
                ddlDeptname.DataSource = dsnew.Tables[0];
                ddlDeptname.DataTextField = "Dept_Name";
                ddlDeptname.DataValueField = "Dept_Id";
                ddlDeptname.DataBind();
                ddlDeptname.Items.Insert(0, "--Select--");
                ddlDeptname.Items.Insert(1, "--Raise Query--");
            }



            else if (Request.QueryString[0].ToString().Trim() == "10" || Request.QueryString[0].ToString().Trim() == "11")
            {
                ddlDeptname.Items.Insert(0, new ListItem("Commissioner of COI", "999"));
                ddlDeptname.Items.Insert(0, new ListItem(Session["user_id"].ToString().Trim(), Session["User_Code"].ToString().Trim()));

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                System.Data.DataRowView drQryDesc = (System.Data.DataRowView)e.Row.DataItem;
                if (drQryDesc["QueryDesc"].ToString() == "1")
                {
                    LinkButton btnQryDesc = (LinkButton)e.Row.FindControl("lnkView");

                    btnQryDesc.Visible = true;
                    ddlDeptname.Items.RemoveAt(1);
                }
            }



            HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[11].FindControl("HdfintApplicationid");
            HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnterperIncentiveID")).Trim();  //CHANGED

            DataSet dsnewinc = new DataSet();
            dsnewinc = Gen.GetIncentiveTypebyIncentive(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnterperIncentiveID")).Trim());  //CHANGED


            if (dsnewinc.Tables[0].Rows.Count > 0)
            {
                GrdInc.DataSource = dsnewinc.Tables[0];
                GrdInc.DataBind();
            }
            else
            {
                GrdInc.DataSource = null;
                GrdInc.DataBind();
            }




            //  DropDownList ddlStatus = (DropDownList)e.Row.Cells[12].FindControl("ddlDeptname");
        }
    }
    protected void BtnSaveg_Click(object sender, EventArgs e)
    {
        Button BtnSaveg = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

        TextBox txtIncQuery = (TextBox)row.FindControl("txtIncQueryFnl");

        //lblQueryDescErr
        Label lblQueryDescErr = (Label)row.FindControl("lblQueryDescErr");

        int incRtrVal = 0; //for query ret val

        HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
        DropDownList ddlDeptname = (DropDownList)row.FindControl("ddlDeptname");

        if (ddlDeptname.SelectedItem.Text != "--Raise Query--")
        {
            if (ddlDeptname.SelectedIndex == 0)
            {
                lblresult.Text = "Please Select Status";
            }
        }
        else
        {

            //lblresult.Text = "Status Updated";


            //int returnValue = Gen.UpdateInspectorName(HdfintApplicationid.Value, ddlDeptname.SelectedValue.ToString().Trim(), Session["uid"].ToString(), row.Cells[1].Text, Session["User_Code"].ToString(), "3");

            string HdfintApplicatiionid = HdfintApplicationid.Value.ToString();
            string DeptName = ddlDeptname.SelectedValue.ToString().Trim();
            string stringval = Session["uid"].ToString();
            string rowCells = row.Cells[1].Text.ToString();
            string usrCode = Session["User_Code"].ToString();



            if (txtIncQuery.Text != "")
            {
                incRtrVal = Gen.insertInctveQueryResponsedata(HdfintApplicationid.Value.ToString(), txtIncQuery.Text, Session["User_Code"].ToString());

                if (incRtrVal >= 1)
                {
                    lblresult.Text = "Status Updated";
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Query Raised Successfully');", true);

                    SndAlertIncentQry();

                    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "Rejection in pre-scrutiny stage is allowed only if the application is not in accordance with any act / rules. Pl. indicate the provision of act /rules that necessitate rejection of this application.Please Mention on which act or rule,you are Rejecting?", true);


                    Response.Redirect("/UI/TSiPASS/IncentiveStatusDetailsNew.aspx?Stg=3");
                }

                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);
                    lblresult.Text = "Status Not Updated";

                }
            }
            else if (txtIncQuery.Text == "" && ddlDeptname.SelectedItem.Text != "--Raise Query--")
            {
                int returnValue = Gen.UpdateInspectorNameNewIncType(HdfintApplicationid.Value, ddlDeptname.SelectedValue.ToString().Trim(), Session["uid"].ToString(), row.Cells[1].Text, Session["User_Code"].ToString(), "3");
                if (returnValue != 999)
                {
                    lblresult.Text = "Status Updated";
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);
                    Response.Redirect("/UI/TSiPASS/IncentiveStatusDetailsNew.aspx?Stg=3");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);
                    lblresult.Text = "Status Not Updated";
                }
                fetchIncentivedet();
            }

            else if (txtIncQuery.Text == "" && ddlDeptname.SelectedItem.Text == "--Raise Query--")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Please enter query description');", true);
                lblQueryDescErr.Visible = true;
                lblQueryDescErr.ForeColor = System.Drawing.Color.Red;

            }

        }
        // int returnValue = cnn.ChangestatusAppl(HdfintApplicationid.Value, ddlStatusg.SelectedValue.ToString().Trim(), Session["uid"].ToString());


        //fetchIncentivedet();

    }


    protected void SndAlertIncentQry()
    {
        DataSet dsMail = new DataSet();
        dsMail = Gen.GetShowEmailidandMobileNumberforIncentive(Session["uid"].ToString());
        if (dsMail.Tables[0].Rows.Count > 0)
        {
            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["applcntName"].ToString().Trim() + "  :<br/><br/> <b> " + Session["user_id"].ToString().Trim() + "  has raised a query for your incentives application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
        }
        if (dsMail.Tables[0].Rows[0]["mobileNo"].ToString().Trim() != "")
        {

            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["mobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["applcntName"].ToString().Trim() + " : " + Session["user_id"].ToString().Trim() + "  has raised a query for your incentives application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
        }
    }

    protected void BtnSearch0_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("Incentive.xls", this.grdDetails);
    }



    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void btnCancelIncQry_Click(object sender, EventArgs e)
    {
        //fetchIncentivedet();
        //Response.Redirect("~/Index.aspx");


        Response.Redirect("/UI/TSiPASS/IncentiveStatusDetailsNew.aspx?Stg=3");


    }



    protected void lnkView_Click1(object sender, EventArgs e)
    {

        LinkButton lnkViewQuery = (LinkButton)sender;
        GridViewRow row = (GridViewRow)lnkViewQuery.NamingContainer;
        DataSet ds = (DataSet)Session["DS4Grid"];
        string INCId = ds.Tables[0].Rows[row.RowIndex]["IncentveID"].ToString();
        Response.Redirect("/UI/TSiPASS/frmResptoIncQry.aspx?EntrpId=" + INCId + "");
    }

    protected void ddlDeptname_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList ddlDeptnameFnl = (DropDownList)sender;
        //Button BtnSaveInc = (Button)sender;

        GridViewRow row = (GridViewRow)ddlDeptnameFnl.NamingContainer;
        // DropDownList ddlDeptnameFnl = (DropDownList)row.FindControl("ddlDeptname");
        // GridViewRow row = (GridViewRow)ddlDeptnameFnnl.NamingContainer;
        TextBox txtIncQuery = (TextBox)row.FindControl("txtIncQueryFnl");
        Button BtnSaveIncQry = (Button)row.FindControl("BtnSaveg");
        Button btnCancelIncQry = (Button)row.FindControl("btnCancelIncQry");


        txtIncQuery.Visible = false;
        //lblQueryDescFnl.Visible = false;



        if (ddlDeptnameFnl.SelectedItem.Text == "--Raise Query--")
        {
            ddlDeptnameFnl.Items.Clear();
            ddlDeptnameFnl.Items.Insert(0, "--Raise Query--");
            txtIncQuery.Visible = true;


            BtnSaveIncQry.Text = "Submit Query";
            //BtnSaveIncQry.Width = "Auto";
            btnCancelIncQry.Visible = true;



        }
    }
    protected void gvdetailsnew_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
        //    string status = Request.QueryString[0].ToString().Trim();
        //    //Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);
        //    Button MstIncentiveId = (e.Row.FindControl("anchortaglink") as Button);
        //    string newurl = "ApplicantIncentiveDtls.aspx?EntrpId=" + enterid.Text.Trim() + "&Sts=" + status;
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open(" + newurl + ",'_newtab');", true);
        //    //(e.Row.FindControl("anchortaglink") as Button).NavigateUrl = "ApplicantIncentiveDtls.aspx?EntrpId=" + enterid.Text.Trim() + "&Sts=" + status;
        //}
    }
    protected void anchortaglink_Click(object sender, EventArgs e)
    {
        Button ddlDeptnameFnl2 = (Button)sender;

        GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;

        Label enterid = (Label)row.FindControl("lblIncentiveID");
        Label lblAppliedIncentives = (Label)row.FindControl("lblAppliedIncentives");

        string status = Request.QueryString[0].ToString().Trim();
        Button Button1 = (Button)row.FindControl("anchortaglink");

        string newurl = "ApplicantIncentiveDtls.aspx?EntrpId=" + enterid.Text.Trim() + "&Sts=" + status + "&IncIds=" + lblAppliedIncentives.Text;
        Response.Redirect(newurl);
       // Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open(" + newurl + ",'_newtab');", true);
    }


    protected void btnUpdateOfficer_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;
            DropDownList ddlOfficer = (DropDownList)row.FindControl("ddlOfficer");
            string intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom,
                Status, MstIncentiveIds, txtIncQuery, txtinspectiondate, Deptname1new;

            EMiUdyogAadhar = row.Cells[1].Text;
            if (ddlOfficer.SelectedItem.Value != "-Select-")
            {
                int returnValuenew = 0;

                intApplicationid = ((Label)row.FindControl("lblEnterperIncentiveID")).Text.ToString();
                MstIncentiveIds = ((Label)row.FindControl("lblAppliedIncentivess")).Text.ToString();
                string[] mstincids = MstIncentiveIds.Split(',');
                Deptname = ddlOfficer.SelectedValue.ToString();
                //EMiUdyogAadhar = grdDetails.Rows[row.RowIndex].Cells[1].Text;
                Modified_by = Session["uid"].ToString();
                SentFrom = Session["User_Code"].ToString();
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
                Status = "3";
                if (mstincids.Length != 0)
                {
                    foreach (string id in mstincids)
                    {
                        string msg = intApplicationid + Deptname + Modified_by + EMiUdyogAadhar + SentFrom + Status + id;
                        //int returnValue = Gen.UpdateInspectorNameNewIncTypeNew(intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, getclientIP());
                        //int returnValue = Gen.UpdateInspectorNameNewIncTypeNew(intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, getclientIP(), ViewState["checkVerifyinsp"].ToString());
                        //returnValuenew = returnValue;
                        //bindGMGrids(MstIncentiveId);
                        //GridView1.Visible = false;
                        //trddlDeptname.Visible = false;

                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SP_CHANGEOFFICERWITHANDWITHOUTROLLBACK", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@intApplicationid", intApplicationid);
                        cmd.Parameters.AddWithValue("@Deptname", ddlOfficer.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@EMiUdyogAadhar", EMiUdyogAadhar);
                        cmd.Parameters.AddWithValue("@SentFrom", Session["User_Code"].ToString());
                        cmd.Parameters.AddWithValue("@Status", Status);
                        cmd.Parameters.AddWithValue("@MstIncentiveId", id);
                        cmd.Parameters.AddWithValue("@IPAddress", getclientIP());
                        cmd.Parameters.AddWithValue("@checkVerifyInsp", "Verified");
                        cmd.Parameters.AddWithValue("@TYPEOFCORRECTION", "CHANGEOFFICERONLY");

                        cmd.Parameters.AddWithValue("@Modified_by", Convert.ToString(Session["uid"]));
                        //cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
                        //cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        //cmd.ExecuteNonQuery();

                        int Result = cmd.ExecuteNonQuery();
                        if (Result != 0)
                        {
                            string message = "alert('inspecting officer Changed Successfully')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                        connection.Close();
                    }
                }

                btnUpdate.Enabled = false;
            }
            else
            {
                string message = "alert('Please Select Assigned to inspecting officer')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }





        }
        catch (Exception ex)
        {

            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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

    protected void btnRollbakandUpdateOfficer_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;
            DropDownList ddlOfficer = (DropDownList)row.FindControl("RollbackddlOfficer");
            string intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom,
                Status, MstIncentiveIds, txtIncQuery, txtinspectiondate, Deptname1new;

            EMiUdyogAadhar = row.Cells[1].Text;
            if (ddlOfficer.SelectedItem.Value != "-Select-")
            {
                int returnValuenew = 0;

                intApplicationid = ((Label)row.FindControl("lblEnterperIncentiveID")).Text.ToString();
                MstIncentiveIds = ((Label)row.FindControl("lblAppliedIncentivess")).Text.ToString();
                string[] mstincids = MstIncentiveIds.Split(',');
                Deptname = ddlOfficer.SelectedValue.ToString();
                //EMiUdyogAadhar = grdDetails.Rows[row.RowIndex].Cells[1].Text;
                Modified_by = Session["uid"].ToString();
                SentFrom = Session["User_Code"].ToString();
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
                Status = "3";
                if (mstincids.Length != 0)
                {
                    foreach (string id in mstincids)
                    {
                        string msg = intApplicationid + Deptname + Modified_by + EMiUdyogAadhar + SentFrom + Status + id;
                        //int returnValue = Gen.UpdateInspectorNameNewIncTypeNew(intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, getclientIP());
                        //int returnValue = Gen.UpdateInspectorNameNewIncTypeNew(intApplicationid, Deptname, Modified_by, EMiUdyogAadhar, SentFrom, Status, MstIncentiveId, getclientIP(), ViewState["checkVerifyinsp"].ToString());
                        //returnValuenew = returnValue;
                        //bindGMGrids(MstIncentiveId);
                        //GridView1.Visible = false;
                        //trddlDeptname.Visible = false;

                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SP_CHANGEOFFICERWITHANDWITHOUTROLLBACK", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@intApplicationid", intApplicationid);
                        cmd.Parameters.AddWithValue("@Deptname", ddlOfficer.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@EMiUdyogAadhar", EMiUdyogAadhar);
                        cmd.Parameters.AddWithValue("@SentFrom", Session["User_Code"].ToString());
                        cmd.Parameters.AddWithValue("@Status", Status);
                        cmd.Parameters.AddWithValue("@MstIncentiveId", id);
                        cmd.Parameters.AddWithValue("@IPAddress", getclientIP());
                        cmd.Parameters.AddWithValue("@checkVerifyInsp", "Verified");
                        cmd.Parameters.AddWithValue("@TYPEOFCORRECTION", "ROLLBACKWITHOFFICERCHANGE");

                        cmd.Parameters.AddWithValue("@Modified_by", Convert.ToString(Session["uid"]));
                        //cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
                        //cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                        // cmd.ExecuteNonQuery();

                        int Result = cmd.ExecuteNonQuery();
                        if (Result != 0)
                        {
                            string message = "alert('inspecting officer Changed Successfully')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                        connection.Close();
                    }
                }

                btnUpdate.Enabled = false;

            }
            else
            {
                string message = "alert('Please Select Assigned to inspecting officer')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }





        }
        catch (Exception ex)
        {

            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }

    }

    protected void grdOfficerChange_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlOfficer = (e.Row.FindControl("ddlOfficer") as DropDownList);
            DropDownList RollbackddlOfficer = (e.Row.FindControl("RollbackddlOfficer") as DropDownList);


            ddlOfficer.DataSource = dsOfficers.Tables[0];
            ddlOfficer.DataTextField = "Dept_Name";
            ddlOfficer.DataValueField = "Dept_Id";
            ddlOfficer.DataBind();
            ddlOfficer.Items.Insert(0, "-Select-");

            RollbackddlOfficer.DataSource = dsOfficers.Tables[0];
            RollbackddlOfficer.DataTextField = "Dept_Name";
            RollbackddlOfficer.DataValueField = "Dept_Id";
            RollbackddlOfficer.DataBind();
            RollbackddlOfficer.Items.Insert(0, "-Select-");
            //Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
            //string status = Request.QueryString[0].ToString().Trim();
            ////Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);
            //Button MstIncentiveId = (e.Row.FindControl("anchortaglink") as Button);
            //string newurl = "ApplicantIncentiveDtls.aspx?EntrpId=" + enterid.Text.Trim() + "&Sts=" + status;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open(" + newurl + ",'_newtab');", true);
            ////(e.Row.FindControl("anchortaglink") as Button).NavigateUrl = "ApplicantIncentiveDtls.aspx?EntrpId=" + enterid.Text.Trim() + "&Sts=" + status;

            int incentiveCount = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IncentiveCount"));
            if (ViewState["TotalIncentives"] == null)
                ViewState["TotalIncentives"] = 0;

            ViewState["TotalIncentives"] = (int)ViewState["TotalIncentives"] + incentiveCount;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            // Display the total in the footer
            e.Row.Cells[0].Text = "Total:";
            e.Row.Cells[9].Text = ViewState["TotalIncentives"].ToString();
        }

    }
}