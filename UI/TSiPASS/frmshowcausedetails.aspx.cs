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


public partial class UI_TSiPASS_frmshowcausedetails : System.Web.UI.Page
{
    String uid;  //this.Page_Load(null, null);
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    List<officerRemarks> lstremarks = new List<officerRemarks>();
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

        ds = fetchIncentivedetnewSearchNewIncType(ddlDistrict.SelectedValue, Session["User_Code"].ToString(), Request.QueryString[0].ToString().Trim(), uid);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvdetailsnew.DataSource = ds.Tables[0];
            gvdetailsnew.DataBind();

            lblMsg.Text = "Total Records : " + ds.Tables[0].Rows.Count.ToString();
            // grdDetails.DataSource = ds.Tables[0];


            Session["DS4Grid"] = ds;
            if (Request.QueryString[0].ToString() == "SC2")
            {
                gvdetailsnew.Columns[12].Visible = true;
            }
            else
            {
                gvdetailsnew.Columns[12].Visible = false;
            }
            if (Request.QueryString[0].ToString() != "SC2")
            {
                gvdetailsnew.Columns[13].Visible = true;
                gvdetailsnew.Columns[14].Visible = true;
            }
            else
            {
                gvdetailsnew.Columns[13].Visible = false;
                gvdetailsnew.Columns[14].Visible = false;
            }
            // grdDetails.DataBind();
            //if (Request.QueryString.Count > 0)
            //{
            //    if (Request.QueryString[0].ToString().Trim() == "3" || Request.QueryString[0].ToString().Trim() == "5" || Request.QueryString[0].ToString().Trim() == "10" || Request.QueryString[0].ToString().Trim() == "11")
            //    {
            //        if (Session["uid"].ToString() == "1213" || (Convert.ToInt32(Session["User_Code"].ToString()) >= 46 && Convert.ToInt32(Session["User_Code"].ToString()) <= 55))
            //        {
            //            grdDetails.Columns[14].Visible = false;
            //        }
            //        else
            //        {
            //            grdDetails.Columns[14].Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        grdDetails.Columns[14].Visible = false;
            //    }
            //}
        }
        else
        {
            lblMsg.Text = "";
            //grdDetails.DataSource = null;
            //grdDetails.DataBind();
        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ddlstatus.SelectedIndex = 0;
        ddlDistrict.SelectedIndex = 0;
        TxtIndname.Text = "";
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
        //GridViewExportUtil.Export("Incentive.xls", this.grdDetails);
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
        string status = Request.QueryString[0].ToString().Trim();
        Button Button1 = (Button)row.FindControl("anchortaglink");

        string newurl = "frmShowcauseReply.aspx?EntrpId=" + enterid.Text.Trim();// +"&Sts=" + status;
        Response.Redirect(newurl);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open(" + newurl + ",'_newtab');", true);
    }

    public DataSet fetchIncentivedetnewSearchNewIncType(string intDistrictid, string intDeptid, string intstageid, string uid)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_DETAILS_SHOWCAUSE", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDistrictid.Trim() == "--Select--")
                intDistrictid = "0";

            if (intstageid.Trim() == "" || intstageid.Trim() == null || intstageid.Trim() == "All" || intstageid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intStageId", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intStageId", SqlDbType.VarChar).Value = intstageid.ToString();


            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();

            da.SelectCommand.Parameters.Add("@uid", SqlDbType.VarChar).Value = uid.ToString();

            // da.SelectCommand.Parameters.Add("@INTDISTID", SqlDbType.VarChar).Value = intDistrictid.ToString();

            if (intDistrictid.Trim() == "" || intDistrictid.Trim() == null)
                da.SelectCommand.Parameters.Add("@INTDISTID", SqlDbType.VarChar).Value = null;
            else
                da.SelectCommand.Parameters.Add("@INTDISTID", SqlDbType.VarChar).Value = intDistrictid.ToString();

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

    //protected void btnnotaccept_Click(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow gvrow in gvdetailsnew.Rows)
    //    {
    //        officerRemarks fromvo = new officerRemarks();
    //        int rowIndex = gvrow.RowIndex;
    //        fromvo.EnterperIncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();

    //        fromvo.MstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text.ToString();
    //        fromvo.id = "";// ((Label)gvrow.FindControl("lblid")).Text.ToString();
    //        fromvo.status = "GMDELAYREASON";
    //        fromvo.Remarks = "N";
    //        fromvo.CreatedByid = Session["uid"].ToString(); //((Label)gvrow.FindControl("lblCreatedByid")).Text.ToString();
    //        fromvo.Designation = "GM";
    //        //fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();


    //        lstremarks.Add(fromvo);
    //        int valid = InsertincentiveOfficerCommentsGMDelayreason(lstremarks, getclientIP());
    //        string message = "alert('Reason Not Accepted Successfully')";
    //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
    //        gvdetailsnew.Columns[12].Visible = false;
    //    }
    //}

    public int InsertincentiveOfficerCommentsGMDelayreason(List<officerRemarks> Ramarks, string IPAddress)
    {
        int valid = 0;
        DB.DB con = new DB.DB();

        foreach (officerRemarks Ramarksvo in Ramarks)
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("USP_UPD_GMDELAYUPDATIONADDL", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@EnterperIncentiveID", Convert.ToString(Ramarksvo.EnterperIncentiveID));
                cmd.Parameters.AddWithValue("@MstIncentiveId", Convert.ToString(Ramarksvo.MstIncentiveId));
                cmd.Parameters.AddWithValue("@ADDLFLAG", Convert.ToString(Ramarksvo.Remarks));
                cmd.Parameters.AddWithValue("@CreatedByid", Convert.ToString(Ramarksvo.CreatedByid));
                cmd.Parameters.AddWithValue("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();
                cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                valid = (Int32)cmd.Parameters["@Valid"].Value;
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.CloseConnection();
            }
        }

        return valid;
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
}