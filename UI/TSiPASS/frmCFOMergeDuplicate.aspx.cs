using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmCFOMergeDuplicate : System.Web.UI.Page
{
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1;
    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;


    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            Response.Redirect("../../IpassLogin.aspx");
        }
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        if (!IsPostBack)
        {
            //HyperLink1.NavigateUrl = "DistrictWiseUpdateabstarct.aspx?AppsType=" + Request.QueryString["TSiPASSType"].ToString();
            //HyperLink2.NavigateUrl = "DistrictWiseUpdateabstarct.aspx?AppsType=" + Request.QueryString["TSiPASSType"].ToString();
            getdistricts();
            if (Session["DistrictID"].ToString().Trim() != "")
            {
                ddlConnectLoad.SelectedValue = (Session["DistrictID"].ToString().Trim());
                ddlConnectLoad.Enabled = false;
            }
            else
                ddlConnectLoad.Enabled = true;
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todate"].ToString().Trim();

            }
            else
            {
                txtFromDate.Text = "01-01-2015";
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
                //fillgrid();
            }
            fillgrid();
        }
    }
    #endregion

    private void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddlConnectLoad.DataSource = dsnew.Tables[0];
        ddlConnectLoad.DataTextField = "District_Name";
        ddlConnectLoad.DataValueField = "District_Id";
        ddlConnectLoad.DataBind();
        ddlConnectLoad.Items.Insert(0, "--Select--");

    }
    public void fillgrid()
    {
        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }

        DataSet dsnew = new DataSet();
        if (FromdateforDB != "")
            dsnew = GetAppealApplications(ddlEnterPriseType.SelectedValue, ddlConnectLoad.SelectedValue, FromdateforDB, TodateforDB, "");
        else
        {
            dsnew = GetAppealApplications(ddlEnterPriseType.SelectedValue, ddlConnectLoad.SelectedValue, FromdateforDB, TodateforDB, "");
        }

        //dsnew = GetAppealApplications(status, District, unitname, TSiPASSType, progress);
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            lblMsg0.Text = "Total Records Found :" + dsnew.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            lblMsg0.Text = "Total Records Found : 0";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    public DataSet GetAppealApplications(string status, string District, string FromDate, string ToDate, string progress)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@status",SqlDbType.VarChar),
               new SqlParameter("@District",SqlDbType.VarChar),
               new SqlParameter("@FromDate",SqlDbType.VarChar),
               new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@EntType",SqlDbType.VarChar)
               
           };
        pp[0].Value = status;
        pp[1].Value = District;
        pp[2].Value = FromDate;
        pp[3].Value = ToDate;
        pp[4].Value = progress;
        //pp[5].Value = status;
        Dsnew = gen.GenericFillDs("FetchDistrictwiseDrildownNew_CFODUPLICATE", pp);
        return Dsnew;
    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + "District Level Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                //grdDetails.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                DataSet dsnew = new DataSet();

                dsnew = Gen.getdataofDistrictlevel1(ddlConnectLoad.SelectedItem.Text.ToString(), txtUnitname.Text);

                GridExport.DataSource = dsnew.Tables[0];
                GridExport.DataBind();

                GridExport.RenderControl(hw);
                //grdDetails.Columns.RemoveAt("View");
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportToExcel();
    }


    //protected void BtnSave1_Click(object sender, EventArgs e)
    //{
    //    ds = Gen.FetchInspectionProgressRpt();
    //    grdDetails.DataSource = ds.Tables[0];
    //    grdDetails.DataBind();
    //}

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Performance indicator"));
        //    NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

        //    decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of Inspections to be conducted"));
        //    Completed1 = Completed + Completed1;


        //    decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of Inspections completed"));
        //    QueryRaised1 = QueryRaised + QueryRaised1;


        //    decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of inspection reports uploaded within 48 hrs"));
        //    Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

        //    //decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendinglessthan3days"));
        //    //Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


        //    //decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Numberofpaymentreceivedfor"));
        //    //Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;


        //}

        //if (e.Row.RowType == DataControlRowType.Footer)
        //{

        //    e.Row.Cells[1].Text = "Total";
        //    e.Row.Cells[2].Text = NumberofApprovalsappliedfor1.ToString();
        //    e.Row.Cells[3].Text = Completed1.ToString();
        //    e.Row.Cells[4].Text = QueryRaised1.ToString();
        //    e.Row.Cells[5].Text = Pendinglessthan3days1.ToString();
        //    //e.Row.Cells[7].Text = Pendingmorthan3days1.ToString();
        //    //e.Row.Cells[7].Text = Numberofpaymentreceivedfor1.ToString();
        //}

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[11].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intSNo")).Trim();
            DropDownList ddlStatus = (DropDownList)e.Row.Cells[11].FindControl("ddlStatus");
            Button BtnSaveg = (Button)e.Row.FindControl("BtnSaveg");
            HiddenField hduidno = (HiddenField)e.Row.Cells[11].FindControl("HdfintApplicationid");
            string progress = e.Row.Cells[11].Text.ToString();
            //if (progress.ToUpper() == "COMMENCED OPERATIONS")
            //{
            //    ddlStatus.Items.Remove(new ListItem("ADVANCED STAGE"));
            //    ddlStatus.Items.Remove(new ListItem("INITIAL STAGE"));
            //    ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
            //    ddlStatus.Items.Remove(new ListItem("COMMENCED OPERATIONS"));
            //    // ddlStatus.SelectedIndex = 1;
            //    BtnSaveg.Enabled = false;
            //}
            //if (progress.ToUpper() == "ADVANCED STAGE")
            //{
            //    ddlStatus.Items.Remove(new ListItem("INITIAL STAGE"));
            //    ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
            //}
            //if (progress.ToUpper() == "INITIAL STAGE")
            //{
            //    ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
            //}
            ////if (progress.ToUpper() == "YET TO START CONSTRUCTION")
            ////{
            ////    ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
            ////}
            //if (progress.ToUpper() == "DROPPED")
            //{
            //    ddlStatus.Items.Remove(new ListItem("ADVANCED STAGE"));
            //    ddlStatus.Items.Remove(new ListItem("INITIAL STAGE"));
            //    ddlStatus.Items.Remove(new ListItem("YET TO START CONSTRUCTION"));
            //    ddlStatus.Items.Remove(new ListItem("COMMENCED OPERATIONS"));
            //    // ddlStatus.SelectedIndex = 1;
            //    BtnSaveg.Enabled = false;
            //}
        }
    }



    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdDetails.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    { }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCFOMergeDuplicate.aspx");

    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlStatus = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
        Button BtnSaveg = (Button)row.FindControl("BtnSaveg");
        ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnSaveg);
        HtmlTableRow trdupuidno = (HtmlTableRow)row.FindControl("trdupuidno");
        HtmlTableRow trremarks = (HtmlTableRow)row.FindControl("trremarks");
        //HtmlTableRow dropupload = (HtmlTableRow)row.FindControl("dropupload");

        if (ddlStatus.SelectedValue == "YES")
        {
            trdupuidno.Visible = true;
            trremarks.Visible = true;
        }
        else
        {
            trdupuidno.Visible = false;
            trremarks.Visible = false;
        }
    }
    protected void txtdupuidno_TextChanged(object sender, EventArgs e)
    {

        try
        {
            //Button BtnSaveg = (Button)sender;
            TextBox txtuidno = (TextBox)sender;
            GridViewRow row = (GridViewRow)txtuidno.NamingContainer;
            TextBox txtdupuidno = (TextBox)row.FindControl("txtdupuidno");
            HyperLink HyperLinknew = (HyperLink)row.FindControl("HyperLink1");
            DataSet ds = new DataSet();
            string errormsg = Gen.getCFOVaildate(txtdupuidno.Text, ddlConnectLoad.SelectedItem.Text, HyperLinknew.Text);
            if (errormsg != null && errormsg != "")
            {
                string message = "alert(" + errormsg + ")";
                //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);



                //ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + errormsg + "');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + errormsg + "');", true);
                txtuidno.Text = "";

            }

        }
        catch (Exception ex)
        {
            lblresult.Text = ex.Message;
            lblresult.Visible = true;
            string message = "alert(" + lblresult.Text + ")";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", lblresult.Text, true);
        }
    }

    protected void BtnSaveg_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileName = "";

        string newPathImage = "";
        string sFileNameImage = "";

        Button BtnSaveg = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

        HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtreasonschange = (TextBox)row.FindControl("txtreasonschange");
        TextBox txtdupuidno = (TextBox)row.FindControl("txtdupuidno");

        //Label Label6 = (Label)row.FindControl("Label6new");
        //FileUpload fupPERCert = (FileUpload)row.FindControl("fluPrincipalEmployersRegistrationCertificate");
        //FileUpload fupPERCertimage = (FileUpload)row.FindControl("FileUpload1");
        HyperLink HyperLinknew = (HyperLink)row.FindControl("HyperLink1");


        if (ddlStatus.SelectedIndex == 0)
        {
            lblresult.Text = "Please Select Status";
        }
        else
        {
            if (ddlStatus.SelectedIndex == 2)
            {
                if (txtdupuidno.Text.Trim().TrimStart() == "")
                {
                    lblresult.Text = "Please Enter UidNo";
                    lblresult.Focus();
                    return;
                }

                if (txtreasonschange.Text.Trim().TrimStart() == "")
                {
                    lblresult.Text = "Please Enter Reason For Status Change";
                    lblresult.Focus();
                    return;
                }
                //string errormsg = Gen.getCFEVaildate(txtdupuidno.Text, ddlConnectLoad.SelectedItem.Text, HyperLinknew.Text);
                string errormsg = Gen.getCFOVaildate(txtdupuidno.Text, ddlConnectLoad.SelectedItem.Text, HyperLinknew.Text);
                if (errormsg != null && errormsg != "")
                {
                    lblresult.Text = errormsg;
                    SetFocus(lblresult);
                    lblresult.Focus();
                    return;

                    //string message = "alert(" + errormsg + ")";
                    ////ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);



                    ////ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + errormsg + "');", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "alert('" + errormsg + "');", true);

                }
            }

            int returnValue = Gen.InsertDuplicateCFO(HyperLinknew.Text.Trim(), ddlStatus.SelectedValue.ToString().Trim(), txtdupuidno.Text.Trim(), Session["uid"].ToString(), txtreasonschange.Text.Trim().TrimStart(), ddlConnectLoad.SelectedValue);

            lblresult.Text = "Status Updated";
            //int returnValue = Gen.ChangeDistrictWiseStatus(HdfintApplicationid.Value,ddlStatus.SelectedValue.ToString(),Session["uid"].ToString());
            fillgrid();
            string message = "alert('Status of Unit has been Updated. Thank You')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
        //  int returnValue = cnn.ChangestatusAppl(HdfintApplicationid.Value, ddlStatusg.SelectedValue.ToString().Trim(), Session["uid"].ToString());

    }
}