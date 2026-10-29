using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using KotakSplitPayment;
using System.Globalization;

public partial class UI_TSiPASS_frmCFEpaymentDetailsKotakSplitDTCP : System.Web.UI.Page
{
    //[WebService(Namespace = "http://tempuri.org/")]

    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal NumberofApprovalsappliedfor1;
    DB.DB con = new DB.DB();
    string sonlinetrnsNo;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["user"] != null && Session["user"] != "")
        //{ }
        //else
        //{
        //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //}

        lblHeading.Text = "Payment Details";

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "1213" || Session["uid"].ToString() == "34668")
        {

        }
        else
        {
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {

            getdistricts();
            GetDepartment();
            // string status = Request.QueryString[0].ToString().Trim();

            //DataSet ds = new DataSet();
            ////ds = Gen.RetriveStatusForViewApplication(Request.QueryString[0].ToString().Trim(), ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue);
            //ds = Gen.Getpaymentdetailslats(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), txtfromDate.Text, txttoDate.Text);
            //Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            //if (ds != null && ds.Tables[0].Rows.Count > 0)
            //{
            //    grdDetails.DataSource = ds.Tables[0];
            //    grdDetails.DataBind();
            //    grdDetails.Columns[2].Visible = false;
            //   // grdDetails.Columns[3].Visible = false;
            //}
            //else
            //{

            //}
            ddlpaymentType_SelectedIndexChanged(sender, e);
        }


    }

    private void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");
    }


    protected void GetDepartment()
    {
        DataSet dsd = new DataSet();

        dsd = Gen.GetDepartmentFullName();
        ddlDepartment.DataSource = dsd.Tables[0];
        ddlDepartment.DataValueField = "Dept_Id";
        ddlDepartment.DataTextField = "Dept_Full_name";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, "--Select--");
    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {



    }
    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {


    }
    void FillDetails()
    {


    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCFEpaymentDetailsKotakSplitDTCP.aspx");
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getcounties()
    {

    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getPayams()
    {

    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {

        try
        {



        }
        catch (Exception ex)
        {
            // lblmsg.Text = ex.ToString();
        }
        finally
        {

        }

    }



    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        AssignGridRowStyle(e.Row, "GridviewScrollC1Item");


        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.Cells[5].Text, "Total Investment (in Crores)"));
            //decimal NumberofApprovalsappliedfor = Convert.ToDecimal((e.Row.Cells[11].Text.Trim() == "" ? "0" : e.Row.Cells[11].Text));
            // NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            //decimal NumberofApprovalsappliedfor = Convert.ToDecimal((e.Row.Cells[6].Text.Trim() == "" ? "0" : e.Row.Cells[6].Text));
            //NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            btn.Text = "View";


            btn.OnClientClick = "javascript:return Popup1('" + intUid + "')";


            //string intUid1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CFEID")).Trim();
            //LinkButton btn1 = (LinkButton)e.Row.FindControl("LinkButton2");

            //btn1.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CFEID")).Trim();

            //btn1.Text = "DD Download";
            //btn1.OnClientClick = "javascript:return Popup('" + intUid1 + "')";

            HiddenField hdfuidno = (HiddenField)e.Row.FindControl("hdfuidno");
            HiddenField HdfAmount = (HiddenField)e.Row.FindControl("HdfAmount");
            HiddenField HdfDeptid = (HiddenField)e.Row.FindControl("HdfDeptid");
            HiddenField HdfQueid = (HiddenField)e.Row.FindControl("HdfQueid");
            HiddenField HdfApprovalid = (HiddenField)e.Row.FindControl("HdfApprovalid");
            HiddenField intCFEEnterpid = (HiddenField)e.Row.FindControl("intCFEEnterpid");
            HiddenField OnlineOrdernumber = (HiddenField)e.Row.FindControl("OnlineOrdernumber");
            HiddenField ACCOUNTNO = (HiddenField)e.Row.FindControl("ACCOUNTNO");
            HiddenField IFSCCODE = (HiddenField)e.Row.FindControl("IFSCCODE");
            CheckBox ChkApproval = (CheckBox)e.Row.FindControl("ChkApproval");

            OnlineOrdernumber.Value = DataBinder.Eval(e.Row.DataItem, "OnlineOrdernumber").ToString().Trim();
            intCFEEnterpid.Value = DataBinder.Eval(e.Row.DataItem, "CFEID").ToString().Trim();
            hdfuidno.Value = DataBinder.Eval(e.Row.DataItem, "UID").ToString().Trim();
            HdfAmount.Value = DataBinder.Eval(e.Row.DataItem, "Approval_Fee").ToString().Trim();
            HdfApprovalid.Value = DataBinder.Eval(e.Row.DataItem, "intApprovalid").ToString().Trim();
            HdfDeptid.Value = DataBinder.Eval(e.Row.DataItem, "INTDEPTID").ToString().Trim();
            ACCOUNTNO.Value = DataBinder.Eval(e.Row.DataItem, "ACCOUNTNO").ToString().Trim();
            IFSCCODE.Value = DataBinder.Eval(e.Row.DataItem, "IFSCCODE").ToString().Trim();
            //HdfQueid.Value = DataBinder.Eval(e.Row.DataItem, "intQuessionaireid").ToString().Trim();



        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            //e.Row.Cells[10].Text = "Total";
            //e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
            //e.Row.Cells[11].Text = NumberofApprovalsappliedfor1.ToString();
            //e.Row.Cells[11].ForeColor = System.Drawing.Color.White;

        }
    }


    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++) gr.Cells[cellIndex].CssClass = "GridviewScrollC1Header";
            }
            else if (gr.RowType == DataControlRowType.Footer)
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnRight";
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnRight";
                    }
                    catch (Exception) { }
                }
            }
        }
        catch (Exception) { }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        //string status = Request.QueryString[0].ToString().Trim();
        filldetails();
    }
    public void filldetails()
    {
        grdDetails.DataSource = null;
        grdDetails.DataBind();
        string FromdateforDB = "", TodateforDB = "";
        if (txtfromDate.Text != "")
        {
            string[] fmdate = txtfromDate.Text.Split('-');
            string[] todate = txttoDate.Text.Split('-');

            FromdateforDB = fmdate[2].ToString() + "/" + fmdate[1].ToString() + "/" + fmdate[0].ToString();
            TodateforDB = todate[2].ToString() + "/" + todate[1].ToString() + "/" + todate[0].ToString();

            // FromdateforDB = Convert.ToString(DateTime.ParseExact(txtfromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            // TodateforDB = Convert.ToString(DateTime.ParseExact(txttoDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        if (ddlDepartment.SelectedValue == "0")
        {
            lblmsg0.Text = "<font color='red'>Please Select Department Name ..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (ddlDepartment.SelectedValue == "1" || ddlDepartment.SelectedValue == "4")
        {
            if (ddldistrict.SelectedValue == "--Select--")
            {
                lblmsg0.Text = "<font color='red'>Please Select District Name ..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }
        DataSet ds = new DataSet();
        //ds = Gen.RetriveStatusForViewApplication(Request.QueryString[0].ToString().Trim(), ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue);
        if (ddlpaymentType.SelectedValue.ToString() == "O")
        {

            // ds =GetpaymentdetailslatsBankType(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), txtfromDate.Text, txttoDate.Text, ddlBank.SelectedValue);
            //ds = Gen.Getcfepaydetails(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), txtfromDate.Text, txttoDate.Text, ddlBank.SelectedValue);
            ds = GetcfepaydetailsNewKotakSplit(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), FromdateforDB, TodateforDB, ddlBank.SelectedValue, ddlmodule.SelectedValue);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                //grdDetails.Columns[2].Visible = false;
                //grdDetails.Columns[3].Visible = false;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();

            }
        }
        else if (ddlpaymentType.SelectedValue.ToString() == "S")
        {
            ds = Gen.GetpaymentdetailslatsSBHChallan(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), txtfromDate.Text, txttoDate.Text);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                grdDetails.Columns[2].Visible = false;
                //grdDetails.Columns[3].Visible = false;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        else if (ddlpaymentType.SelectedValue.ToString() == "R")
        {
            ds = GetcfepaydetailsNewKotakSplit(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), FromdateforDB, TodateforDB, ddlBank.SelectedValue, ddlmodule.SelectedValue);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                //grdDetails.Columns[2].Visible = false;
                //grdDetails.Columns[3].Visible = false;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();

            }


        }

        else
        {
            // ds = Gen.Getpaymentdetailslats(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), txtfromDate.Text, txttoDate.Text);
            ds = GetcfepaydetailsNewKotakSplit(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), txtfromDate.Text, txttoDate.Text, "", ddlmodule.SelectedValue);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                // grdDetails.Columns[2].Visible = false;
                // grdDetails.Columns[2].Visible = true;
                // grdDetails.Columns[3].Visible = false;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();

            }
        }
    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {

    }
    protected void grdDetails_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {


    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;
        filldetails();
    }

    protected void ExportToExcel()
    {
        try
        {

            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=Total Applications Received" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    grdDetails.RenderControl(hw);
            //    Response.Output.Write(sw.ToString());
            //    HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            //    HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            //    HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
            //    HttpContext.Current.Response.End();
            //}


            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment;filename=TotalApplicationsReceived" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    grdDetails.Columns[1].Visible = false;
            //    grdDetails.AllowPaging = false;
            //    filldetails();
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    grdDetails.RenderControl(hw);
            //    //grdDetails.Columns.RemoveAt("View");
            //    Response.Output.Write(sw.ToString());
            //    //HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            //    //HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            //    //HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
            //    //HttpContext.Current.Response.End();
            //    Response.Flush();
            //    Response.SuppressContent = true;
            //    //Response.Close();
            //    //Response.End();
            //}
        }
        catch (Exception e)
        {
            //Response.Write(e.ToString());
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void BtnExel_Click(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void ddlpaymentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpaymentType.SelectedValue == "O")
        {
            trBank.Visible = true;
        }
        else
        {
            trBank.Visible = false;
        }
    }

    public DataSet GetpaymentdetailslatsBankType(string intDeptid, string UID_No, string nameofunit, string District, string paymentmode, string fromdate, string todate, string BankName)
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetPaymentdtailsCFEBANKTYPE", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;




            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();


            if (fromdate.Trim() == "" || fromdate.Trim() == null || fromdate.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = cmf.convertDateIndia(fromdate);

            if (todate.Trim() == "" || todate.Trim() == null || todate.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = cmf.convertDateIndia(todate);

            if (paymentmode.Trim() == "" || paymentmode.Trim() == null || paymentmode.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@paymentmode", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@paymentmode", SqlDbType.VarChar).Value = paymentmode.ToString();

            if (District.Trim() == "" || District.Trim() == null || District.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = District.ToString();
            if (UID_No.Trim() == "" || UID_No.Trim() == null)
                da.SelectCommand.Parameters.Add("@UID_No", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@UID_No", SqlDbType.VarChar).Value = UID_No.ToString();

            if (nameofunit.Trim() == "" || nameofunit.Trim() == null)
                da.SelectCommand.Parameters.Add("@nameofunit", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@nameofunit", SqlDbType.VarChar).Value = nameofunit.ToString();

            if (BankName.Trim() == "" || BankName.Trim() == null)
                da.SelectCommand.Parameters.Add("@BankName", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName.ToString();


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

    public DataSet GetcfepaydetailsNewKotakSplit(string intDeptid, string UID_No, string nameofunit, string District, string paymentmode, string fromdate, string todate, string BankName, string ApplicationType)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_PAYMENT_ABSTRACT_DTLS_ONLINE_DTCP", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();


            if (fromdate.Trim() == "" || fromdate.Trim() == null || fromdate.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                //  da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = cmf.convertDateIndia(fromdate);
                da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = (fromdate);

            if (todate.Trim() == "" || todate.Trim() == null || todate.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@todate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@todate", SqlDbType.VarChar).Value = (todate);

            if (paymentmode.Trim() == "" || paymentmode.Trim() == null || paymentmode.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@paymentmode", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@paymentmode", SqlDbType.VarChar).Value = paymentmode.ToString();

            if (District.Trim() == "" || District.Trim() == null || District.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = District.ToString();
            if (UID_No.Trim() == "" || UID_No.Trim() == null)
                da.SelectCommand.Parameters.Add("@UID_No", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@UID_No", SqlDbType.VarChar).Value = UID_No.ToString();

            if (nameofunit.Trim() == "" || nameofunit.Trim() == null)
                da.SelectCommand.Parameters.Add("@nameofunit", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@nameofunit", SqlDbType.VarChar).Value = nameofunit.ToString();

            if (BankName.Trim() == "" || BankName.Trim() == null || BankName.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@BankName", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName.ToString();

            da.SelectCommand.Parameters.Add("@ApplicationType", SqlDbType.VarChar).Value = ApplicationType.ToString();

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

    protected void HdfAmount_ValueChanged(object sender, EventArgs e)
    {

    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkAll = (CheckBox)grdDetails.HeaderRow.FindControl("chkAll");

        if (checkAll.Checked)
        {
            foreach (GridViewRow row in grdDetails.Rows)
            {
                CheckBox checkone = (CheckBox)row.FindControl("ChkApproval");
                checkone.Checked = true;
                ChkApproval_CheckedChanged(sender, e);
            }

        }
        else
        {
            foreach (GridViewRow row in grdDetails.Rows)
            {
                CheckBox checkone = (CheckBox)row.FindControl("ChkApproval");
                checkone.Checked = false;
            }
        }
    }

    protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkApproval = (CheckBox)sender;
        GridViewRow row = (GridViewRow)ChkApproval.NamingContainer;
        HiddenField HdfAmount = (HiddenField)row.FindControl("Approval_Fee");
        if (ChkApproval.Checked == true)
        {
            row.Cells[5].Text = row.Cells[11].Text;

        }
        else
        {
            row.Cells[5].Text = "0";


        }
        decimal sum = Convert.ToDecimal("0");
        foreach (GridViewRow row1 in grdDetails.Rows)
        {
            if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
            {
                if (ChkApproval.Checked == true)
                {
                    row1.Cells[5].Text = row1.Cells[11].Text;

                }

                if (row1.Cells[5].Text != "" && row1.Cells[5].Text != "0")
                {

                    sum = sum + Convert.ToDecimal(row1.Cells[5].Text);
                }


                //  int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);  
            }
        }

        lbltotal.Text = sum.ToString();
        //txtAmount.Text = HdfA.Value;
        //TxtAmountOnline.Text = HdfA.Value;
        //if (TxtAmountOnline.Text == "0")
        //{
        //    BtnDelete.Text = "Submit Applications";
        //}
        //else
        //{
        //    BtnDelete.Text = "Pay";
        //}
    }
    protected void btntransfer_Click(object sender, EventArgs e)
    {
        try
        {
            int selectioncount = 0;
            foreach (GridViewRow row in grdDetails.Rows)
            {
                if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                {
                    string HdfApprovalidnew = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                    // if (HdfApprovalidnew.Trim() != "33" && HdfApprovalidnew.Trim() != "36" && HdfApprovalidnew.Trim() != "57")
                    if (HdfApprovalidnew.Trim() != "31")//TSIIC BP PAYMENT OTHER PAGE
                    {
                        selectioncount = selectioncount + 1;
                    }
                }
            }

            if (selectioncount == 0)
            {
                lblmsg0.Text = "<font color='red'>Please Select Atleaset one Department for Approval ..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            btntransfer.Enabled = false;
            sonlinetrnsNo = "Split" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
            Session["onlinetransId"] = sonlinetrnsNo;
            //inset into SBI payment disbursement table
            foreach (GridViewRow row in grdDetails.Rows)
            {
                if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                {
                    string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                    string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                    string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                    string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                    string onlineorderno = ((HiddenField)row.FindControl("OnlineOrdernumber")).Value.ToString();
                    string intCFEEnterpid = ((HiddenField)row.FindControl("intCFEEnterpid")).Value.ToString();
                    string uidno = ((HiddenField)row.FindControl("hdfuidno")).Value.ToString();
                    string additionalflag = ((HiddenField)row.FindControl("AdditionalFlag")).Value.ToString();
                    string ACCOUNTNO = ((HiddenField)row.FindControl("ACCOUNTNO")).Value.ToString();
                    string IFSCCODE = ((HiddenField)row.FindControl("IFSCCODE")).Value.ToString();
                    // int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(),HdfApprovalid);
                    int s =  InsertKotakSplitPayment(uidno, intCFEEnterpid, onlineorderno, HdfDeptid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, ddlmodule.SelectedValue, additionalflag, sonlinetrnsNo, ACCOUNTNO, IFSCCODE);
                }
            }
            DataSet ds = new DataSet();
            string responce = "";
            string Outresponse = "";
            string XmlData = "";
            ds = GetKotakSplitpaymentdata(sonlinetrnsNo, ddlDepartment.SelectedValue, "", ddldistrict.SelectedValue);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string ArgMessageId = ds.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                string ArgClientCode = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                string ArgMyProdCode = ds.Tables[0].Rows[0]["ProdCode"].ToString();// "CMSPAY"; //"NETPAY";// 
                string ArgTxnAmnt = ds.Tables[0].Rows[0]["AMOUNT"].ToString();
                string ArgAccountNo = ds.Tables[0].Rows[0]["CLIENTACCOUNTNO"].ToString();
                string ArgPaymentDt = ds.Tables[0].Rows[0]["PAYMENTDATE"].ToString();
                string ArgRecBrCd = ds.Tables[0].Rows[0]["IFSC"].ToString();
                string ArgBeneAcctNo = ds.Tables[0].Rows[0]["ACCOUNTNO"].ToString();
                string ArgBeneName = ds.Tables[0].Rows[0]["DEPARTMENTNAME"].ToString();
                string ArgEnrichment = "";// ds.Tables[0].Rows[0]["OnlineOrderNo"].ToString();

                try
                {
                    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://apigwuat.kotak.com:8443/cms_generic_service");
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://apigw.kotak.com:8443/cms_generic_service?apikey=l7xx48840f4c6a6c4ce88824a4fdbda07fa9");
                    request.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
                    request.Method = "POST";
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    string RequestString = Payment(ArgMessageId, ArgClientCode, ArgMyProdCode, ArgTxnAmnt, ArgAccountNo, ArgPaymentDt, ArgRecBrCd,
                        ArgBeneAcctNo, ArgBeneName, ArgEnrichment);
                    //Logfile(ConfigPath, "CallPayment Request : " + RequestString);
                    try
                    {
                        GetPaymentRequest(RequestString);
                    }
                    catch (Exception ex)
                    {

                    }
                    byte[] byteArray = Encoding.UTF8.GetBytes(RequestString);
                    request.ContentType = "application/soap+xml;charset=UTF-8;action=\"/BusinessServices/StarterProcesses/CMS_Generic_Service.serviceagent/Payment\"";
                    request.ContentLength = byteArray.Length;
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                    using (WebResponse Serviceres = request.GetResponse())
                    {
                        using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                        {
                            var ServiceResult = rd.ReadToEnd();
                            try
                            {
                                GetPaymentResponse(ServiceResult);
                            }
                            catch (Exception ex)
                            {

                            }
                            string PaymentResponse = ""; string PaymentOutputCode = "";
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.LoadXml(ServiceResult.ToString());
                            var items = xmlDoc.GetElementsByTagName("ns0:StatusRem");
                            foreach (var item in items)
                            {
                                PaymentResponse = ((System.Xml.XmlElement)(item)).InnerText.ToString();
                                //Console.WriteLine(((System.Xml.XmlElement)(item)).InnerText.ToString());
                            }
                            var items1 = xmlDoc.GetElementsByTagName("ns0:StatusCd");
                            foreach (var item in items1)
                            {
                                PaymentOutputCode = ((System.Xml.XmlElement)(item)).InnerText.ToString();
                                //Console.WriteLine(((System.Xml.XmlElement)(item)).InnerText.ToString());
                            }

                            int outputpcb = UpdateKotakSplitPayment(ArgMessageId, Convert.ToString(ArgTxnAmnt), ddlDepartment.SelectedValue, Session["uid"].ToString(), PaymentResponse,
         PaymentOutputCode, "", "", "", "", "");
                            int outputaccount = UpdateKotakSplitPaymentAccountDtls(ArgMessageId, Convert.ToString(ArgTxnAmnt), ddlDepartment.SelectedValue, Session["uid"].ToString(),
                  ArgBeneAcctNo, ArgRecBrCd, "");
                            success.Visible = true;
                            lblmsg.Text = ServiceResult;
                            lblmsg.Visible = true;
                            //ReturnResult = ServiceResult.ToString();
                            //Logfile(ConfigPath, "CallPayment Response : " + ReturnResult);
                        }
                    }
                }
                catch (Exception ex)
                {
                    success.Visible = true;
                    lblmsg.Text = ex.Message;
                    lblmsg.Visible = true;
                    GetPaymentResponse(ex.ToString());
                    //Logfile(ConfigPath, "Error In CallPayment : " + ex.ToString());
                    //RemitError = true;
                }

                try
                {

                    //HttpWebRequest requestreversal = (HttpWebRequest)WebRequest.Create("https://apigwuat.kotak.com:8443/cms_generic_service");
                    HttpWebRequest requestreversal = (HttpWebRequest)WebRequest.Create("https://apigw.kotak.com:8443/cms_generic_service?apikey=l7xx48840f4c6a6c4ce88824a4fdbda07fa9");
                    requestreversal.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
                    requestreversal.Method = "POST";
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    string RequestStringReversal = Reversal(ArgMessageId, ArgClientCode, ArgPaymentDt);
                    //Logfile(ConfigPath, "CallPayment Request : " + RequestString);
                    try
                    {
                        GetReversalRequest(RequestStringReversal);
                    }
                    catch (Exception ex)
                    {

                    }
                    byte[] byteArrayReversal = Encoding.UTF8.GetBytes(RequestStringReversal);
                    requestreversal.ContentType = "application/soap+xml;charset=UTF-8;action=\"/BusinessServices/StarterProcesses/CMS_Generic_Service.serviceagent/Reversal\"";
                    requestreversal.ContentLength = byteArrayReversal.Length;
                    Stream dataStreamReversal = requestreversal.GetRequestStream();
                    dataStreamReversal.Write(byteArrayReversal, 0, byteArrayReversal.Length);
                    dataStreamReversal.Close();
                    using (WebResponse Serviceres = requestreversal.GetResponse())
                    {
                        using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                        {
                            var ServiceResult = rd.ReadToEnd();
                            try
                            {
                                GetReversalResponse(ServiceResult);
                            }
                            catch (Exception ex)
                            {

                            }
                            //                   int outputpcb = UpdateKotakSplitPayment(ArgMessageId, "", ddlDepartment.SelectedValue, Session["uid"].ToString(), "",
                            //"", "", ServiceResult, "CMS", "");
                            success.Visible = true;
                            lblmsg.Text += ServiceResult;
                            lblmsg.Visible = true;
                            //ReturnResult = ServiceResult.ToString();
                            //Logfile(ConfigPath, "CallPayment Response : " + ReturnResult);
                        }
                    }
                }

                catch (Exception ex)
                {
                    success.Visible = true;
                    lblmsg.Text += ex.Message;
                    lblmsg.Visible = true;
                    GetReversalResponse(ex.ToString());
                    //Logfile(ConfigPath, "Error In CallPayment : " + ex.ToString());
                    //RemitError = true;
                }
            }

        }
        catch (Exception ex)
        {
            success.Visible = true;
            lblmsg.Text = ex.Message;
            lblmsg.Visible = true;
            //throw ex;
        }
    }

    public string postXMLData(string destinationUrl, string requestXml)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
        byte[] bytes;
        bytes = System.Text.Encoding.ASCII.GetBytes(requestXml);
        request.ContentType = "text/xml; encoding='utf-8'";
        request.ContentLength = bytes.Length;
        request.Method = "POST";
        Stream requestStream = request.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        HttpWebResponse response;
        response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            Stream responseStream = response.GetResponseStream();
            string responseStr = new StreamReader(responseStream).ReadToEnd();
            return responseStr;
        }
        return null;
    }

    public DataSet GetKotakSplitpaymentdata(string TSipassOrderNumber, string deptid, string approvalid, string districtid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@OnlineOrderNo",SqlDbType.VarChar),
               new SqlParameter("@INTDEPTID",SqlDbType.VarChar),
               new SqlParameter("@INTAPPROVALID",SqlDbType.VarChar),
               new SqlParameter("@DISTRICTID",SqlDbType.VarChar),
           };

        pp[0].Value = TSipassOrderNumber;
        pp[1].Value = deptid;
        pp[2].Value = approvalid;
        pp[3].Value = districtid;

        Dsnew = Gen.GenericFillDs("USP_GET_SPLIT_PaymentDtls_KOTAK_DTCP", pp);

        return Dsnew;
    }

    public static string Payment(string ArgMessageId, string ArgClientCode, string ArgMyProdCode, string ArgTxnAmnt, string ArgAccountNo, string ArgPaymentDt, string ArgRecBrCd, string ArgBeneAcctNo, string ArgBeneName, string ArgEnrichment)
    {
        string RequestMsg = "";

        RequestMsg = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
        RequestMsg += "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:pay=\"http://www.kotak.com/schemas/CMS_Generic/Payment_Request.xsd\">";
        RequestMsg += " <soap:Header/>";
        RequestMsg += " <soap:Body>";
        RequestMsg += "     <pay:Payment>";
        RequestMsg += "         <pay:RequestHeader>";
        RequestMsg += "             <pay:MessageId>" + ArgMessageId + "</pay:MessageId>";
        RequestMsg += "             <pay:MsgSource>" + ArgClientCode + "</pay:MsgSource>";
        RequestMsg += "             <pay:ClientCode>" + ArgClientCode + "</pay:ClientCode>";
        RequestMsg += "             <pay:BatchRefNmbr></pay:BatchRefNmbr>";
        RequestMsg += "             <pay:HeaderChecksum></pay:HeaderChecksum>";
        RequestMsg += "             <pay:ReqRF1></pay:ReqRF1>";
        RequestMsg += "             <pay:ReqRF2></pay:ReqRF2>";
        RequestMsg += "             <pay:ReqRF3></pay:ReqRF3>";
        RequestMsg += "             <pay:ReqRF4></pay:ReqRF4>";
        RequestMsg += "             <pay:ReqRF5></pay:ReqRF5>";
        RequestMsg += "         </pay:RequestHeader>";
        RequestMsg += "         <pay:InstrumentList>";
        RequestMsg += "             <pay:instrument>";
        RequestMsg += "                 <pay:InstRefNo>" + ArgMessageId + "</pay:InstRefNo>";
        RequestMsg += "                 <pay:CompanyId></pay:CompanyId>";
        RequestMsg += "                 <pay:CompBatchId></pay:CompBatchId>";
        RequestMsg += "                 <pay:ConfidentialInd></pay:ConfidentialInd>";
        RequestMsg += "                 <pay:MyProdCode>" + ArgMyProdCode + "</pay:MyProdCode>";
        RequestMsg += "                 <pay:CompTransNo></pay:CompTransNo>";
        RequestMsg += "                 <pay:PayMode></pay:PayMode>";
        RequestMsg += "                 <pay:TxnAmnt>" + ArgTxnAmnt + "</pay:TxnAmnt>";
        RequestMsg += "                 <pay:AccountNo>" + ArgAccountNo + "</pay:AccountNo>";
        RequestMsg += "                 <pay:DrRefNmbr></pay:DrRefNmbr>";
        RequestMsg += "                 <pay:DrDesc></pay:DrDesc>";
        RequestMsg += "                 <pay:PaymentDt>" + ArgPaymentDt + "</pay:PaymentDt>";
        RequestMsg += "                 <pay:BankCdInd></pay:BankCdInd>";
        RequestMsg += "                 <pay:BeneBnkCd></pay:BeneBnkCd>";
        RequestMsg += "                 <pay:RecBrCd>" + ArgRecBrCd + "</pay:RecBrCd>";
        RequestMsg += "                 <pay:BeneAcctNo>" + ArgBeneAcctNo + "</pay:BeneAcctNo>";
        RequestMsg += "                 <pay:BeneName>" + ArgBeneName + "</pay:BeneName>";// Regex.Replace(ArgBeneName.Trim(), @"[^0-9a-zA-Z]+", " ") + "</pay:BeneName>";
        RequestMsg += "                 <pay:BeneCode></pay:BeneCode>";
        RequestMsg += "                 <pay:BeneEmail></pay:BeneEmail>";
        RequestMsg += "                 <pay:BeneFax></pay:BeneFax>";
        RequestMsg += "                 <pay:BeneMb></pay:BeneMb>";
        RequestMsg += "                 <pay:BeneAddr1>IND</pay:BeneAddr1>";
        RequestMsg += "                 <pay:BeneAddr2></pay:BeneAddr2>";
        RequestMsg += "                 <pay:BeneAddr3></pay:BeneAddr3>";
        RequestMsg += "                 <pay:BeneAddr4></pay:BeneAddr4>";
        RequestMsg += "                 <pay:BeneAddr5></pay:BeneAddr5>";
        RequestMsg += "                 <pay:city></pay:city>";
        RequestMsg += "                 <pay:zip>0</pay:zip>";
        RequestMsg += "                 <pay:Country>INDIA</pay:Country>";
        RequestMsg += "                 <pay:State></pay:State>";
        RequestMsg += "                 <pay:TelephoneNo></pay:TelephoneNo>";
        RequestMsg += "                 <pay:BeneId></pay:BeneId>";
        RequestMsg += "                 <pay:BeneTaxId></pay:BeneTaxId>";
        RequestMsg += "                 <pay:AuthPerson></pay:AuthPerson>";
        RequestMsg += "                 <pay:AuthPersonId></pay:AuthPersonId>";
        RequestMsg += "                 <pay:DeliveryMode></pay:DeliveryMode>";
        RequestMsg += "                 <pay:PayoutLoc></pay:PayoutLoc>";
        RequestMsg += "                 <pay:PickupBr></pay:PickupBr>";
        RequestMsg += "                 <pay:PaymentRef></pay:PaymentRef>";
        RequestMsg += "                 <pay:ChgBorneBy></pay:ChgBorneBy>";
        RequestMsg += "                 <pay:InstDt>" + ArgPaymentDt + "</pay:InstDt>";
        RequestMsg += "                 <pay:MICRNo></pay:MICRNo>";
        RequestMsg += "                 <pay:CreditRefNo></pay:CreditRefNo>";
        RequestMsg += "                 <pay:PaymentDtl></pay:PaymentDtl>";
        RequestMsg += "                 <pay:PaymentDtl1></pay:PaymentDtl1>";
        RequestMsg += "                 <pay:PaymentDtl2></pay:PaymentDtl2>";
        RequestMsg += "                 <pay:PaymentDtl3></pay:PaymentDtl3>";
        RequestMsg += "                 <pay:MailToAddr1></pay:MailToAddr1>";
        RequestMsg += "                 <pay:MailToAddr2></pay:MailToAddr2>";
        RequestMsg += "                 <pay:MailToAddr3></pay:MailToAddr3>";
        RequestMsg += "                 <pay:MailToAddr4></pay:MailToAddr4>";
        RequestMsg += "                 <pay:MailTo></pay:MailTo>";
        RequestMsg += "                 <pay:ExchDoc></pay:ExchDoc>";
        RequestMsg += "                 <pay:InstChecksum></pay:InstChecksum>";
        RequestMsg += "                 <pay:InstRF1></pay:InstRF1>";
        RequestMsg += "                 <pay:InstRF2></pay:InstRF2>";
        RequestMsg += "                 <pay:InstRF3></pay:InstRF3>";
        RequestMsg += "                 <pay:InstRF4></pay:InstRF4>";
        RequestMsg += "                 <pay:InstRF5></pay:InstRF5>";
        RequestMsg += "                 <pay:InstRF6></pay:InstRF6>";
        RequestMsg += "                 <pay:InstRF7></pay:InstRF7>";
        RequestMsg += "                 <pay:InstRF8></pay:InstRF8>";
        RequestMsg += "                 <pay:InstRF9></pay:InstRF9>";
        RequestMsg += "                 <pay:InstRF10></pay:InstRF10>";
        RequestMsg += "                 <pay:InstRF11></pay:InstRF11>";
        RequestMsg += "                 <pay:InstRF12></pay:InstRF12>";
        RequestMsg += "                 <pay:InstRF13></pay:InstRF13>";
        RequestMsg += "                 <pay:InstRF14></pay:InstRF14>";
        RequestMsg += "                 <pay:InstRF15></pay:InstRF15>";
        RequestMsg += "                 <pay:EnrichmentSet>";
        RequestMsg += "                     <pay:Enrichment>" + ArgEnrichment + "</pay:Enrichment>";// Regex.Replace(ArgEnrichment.Trim(), @"[^0-9a-zA-Z]+", " ") + "</pay:Enrichment>";
        RequestMsg += "                 </pay:EnrichmentSet>";
        RequestMsg += "             </pay:instrument>";
        RequestMsg += "         </pay:InstrumentList>";
        RequestMsg += "     </pay:Payment>";
        RequestMsg += " </soap:Body>";
        RequestMsg += "</soap:Envelope>";

        return RequestMsg;
    }

    public static string Reversal(string ArgregId, string ArgClientCode, string ArgPaymentDt)
    {
        string RequestReversal = "";
        RequestReversal = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
        //RequestReversal += "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:pay=\"http://www.kotak.com/schemas/CMS_Generic/Payment_Request.xsd\">";
        RequestReversal += "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:rev=\"http://www.kotak.com/schemas/CMS_Generic/Reversal_Request.xsd\">";
        RequestReversal += " <soap:Header/>";
        RequestReversal += " <soap:Body>";
        RequestReversal += "      <rev:Reversal>";
        RequestReversal += "  <rev:Header>";
        RequestReversal += "    <rev:Req_Id>" + ArgregId + "</rev:Req_Id>";
        RequestReversal += "    <rev:Msg_Src>" + ArgregId + "</rev:Msg_Src>";
        RequestReversal += "    <rev:Client_Code>" + ArgClientCode + "</rev:Client_Code>";
        RequestReversal += "    <rev:Date_Post>" + ArgPaymentDt + "</rev:Date_Post>";
        RequestReversal += "  </rev:Header>";
        RequestReversal += "  <rev:Details>";
        //RequestReversal += "     <!--Zero or more repetitions:-->";
        RequestReversal += "     <rev:Msg_Id>" + ArgregId + "</rev:Msg_Id>";
        RequestReversal += "   </rev:Details>";
        RequestReversal += "  </rev:Reversal>";
        RequestReversal += "  </soap:Body>";
        RequestReversal += " </soap:Envelope>";
        return RequestReversal;
    }

    public void GetPaymentRequest(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_SPLITREQUEST", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@Online", SqlDbType.VarChar).Value = "Online";

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

    public void GetPaymentResponse(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_SPLITRESPONSE", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@Online", SqlDbType.VarChar).Value = "Online";

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

    public void GetReversalRequest(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_SPLITREVERSALREQUEST", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@Online", SqlDbType.VarChar).Value = "Online";

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

    public void GetReversalResponse(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_SPLITREVERSALSPONSE", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@Online", SqlDbType.VarChar).Value = "Online";

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

    public int UpdateKotakSplitPayment(string SplitOnlineOrderNo, string Total_Amount, string deptid, string Created_by, string PaymentResponse,
        string PaymentOutputCode, string ReversalRequestFlag, string ReversalRepose, string ReversaTransactionno, string Reversalupdatedate,
         string output)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPDATE_KotakSplit_PaymentDtls_DTCP";

        if (SplitOnlineOrderNo == "" || SplitOnlineOrderNo == null)
            com.Parameters.Add("@SplitOnlineOrderNo ", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@SplitOnlineOrderNo", SqlDbType.VarChar).Value = SplitOnlineOrderNo.Trim();

        if (Total_Amount == null)
            com.Parameters.Add("@Total_Amount ", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Total_Amount", SqlDbType.VarChar).Value = Total_Amount;

        if (deptid == "" || deptid == null)
            com.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DEPTID", SqlDbType.VarChar).Value = deptid.Trim();

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (PaymentResponse == "" || PaymentResponse == null)
            com.Parameters.Add("@PaymentResponse", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentResponse", SqlDbType.VarChar).Value = PaymentResponse.Trim();

        if (PaymentOutputCode == "" || PaymentOutputCode == null)
            com.Parameters.Add("@PaymentOutputCode", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentOutputCode", SqlDbType.VarChar).Value = PaymentOutputCode.Trim();

        if (ReversalRequestFlag == "" || ReversalRequestFlag == null)
            com.Parameters.Add("@ReversalRequestFlag", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ReversalRequestFlag", SqlDbType.VarChar).Value = ReversalRequestFlag.Trim();

        if (ReversalRepose == "" || ReversalRepose == null)
            com.Parameters.Add("@ReversalRepose", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ReversalRepose", SqlDbType.VarChar).Value = ReversalRepose.Trim();

        if (ReversaTransactionno == "" || ReversaTransactionno == null)
            com.Parameters.Add("@ReversaTransactionno", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ReversaTransactionno", SqlDbType.VarChar).Value = ReversaTransactionno.Trim();

        if (Reversalupdatedate == "" || Reversalupdatedate == null)
            com.Parameters.Add("@Reversalupdatedate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Reversalupdatedate", SqlDbType.VarChar).Value = Reversalupdatedate.Trim();

        if (output == "" || output == null)
            com.Parameters.Add("@VALID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@VALID", SqlDbType.VarChar).Value = output.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    private void getPCBdistrictsnew()
    {
        DataSet dsnew = new DataSet();

        dsnew = GetPCBDistricts();
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "Pcb_Map_Dist";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");
    }

    public DataSet GetPCBDistricts()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetPCBDistricts", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;




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
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDepartment.SelectedValue == "1")
            {
                getPCBdistrictsnew();
            }
            else
            {
                getdistricts();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int UpdateKotakSplitPaymentAccountDtls(string SplitOnlineOrderNo, string Total_Amount, string deptid, string Created_by, string Accountno,
       string IFSCCode, string output)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPDATE_ACCOUNTDTSL_KotakSplit_PaymentDtls_DTCP";

        if (SplitOnlineOrderNo == "" || SplitOnlineOrderNo == null)
            com.Parameters.Add("@SplitOnlineOrderNo ", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@SplitOnlineOrderNo", SqlDbType.VarChar).Value = SplitOnlineOrderNo.Trim();

        if (Total_Amount == null)
            com.Parameters.Add("@Total_Amount ", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Total_Amount", SqlDbType.VarChar).Value = Total_Amount;

        if (deptid == "" || deptid == null)
            com.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DEPTID", SqlDbType.VarChar).Value = deptid.Trim();

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (Accountno == "" || Accountno == null)
            com.Parameters.Add("@Accountno", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Accountno", SqlDbType.VarChar).Value = Accountno.Trim();

        if (IFSCCode == "" || IFSCCode == null)
            com.Parameters.Add("@IFSCCode", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IFSCCode", SqlDbType.VarChar).Value = IFSCCode.Trim();

        if (output == "" || output == null)
            com.Parameters.Add("@VALID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@VALID", SqlDbType.VarChar).Value = output.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public int InsertKotakSplitPayment(string UidNo, string intCFEEnterpid, string OnlineOrderNo, string intDeptid, string Online_Amount, string Created_by, string intApprovalid, string ApplType, string AdditionalPayment, string SplitOnlineOrderNo, string Accountnumber, string IFSCCODE)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_INSERT_KotakSplit_PaymentDtls_DTCP]";

        if (UidNo.Trim() == "" || UidNo.Trim() == null)
        {
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = UidNo.Trim();
        }
        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());

        if (OnlineOrderNo == "" || OnlineOrderNo == null)
            com.Parameters.Add("@OnlineOrderNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@OnlineOrderNo", SqlDbType.VarChar).Value = OnlineOrderNo.Trim();


        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());


        if (Online_Amount == "" || Online_Amount == null)
            com.Parameters.Add("@Online_Amount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Online_Amount", SqlDbType.VarChar).Value = Online_Amount.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
        {
            com.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
        }
        if (AdditionalPayment == "" || AdditionalPayment == null)
            com.Parameters.Add("@AdditionalPayment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdditionalPayment", SqlDbType.VarChar).Value = AdditionalPayment.Trim();

        if (SplitOnlineOrderNo == "" || SplitOnlineOrderNo == null)
            com.Parameters.Add("@SplitOnlineOrderNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@SplitOnlineOrderNo", SqlDbType.VarChar).Value = SplitOnlineOrderNo.Trim();

        com.Parameters.Add("@ApplType", SqlDbType.VarChar).Value = ApplType.Trim();

        if (Accountnumber == "" || Accountnumber == null)
            com.Parameters.Add("@Accountnumber", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Accountnumber", SqlDbType.VarChar).Value = Accountnumber.Trim();

        if (IFSCCODE == "" || IFSCCODE == null)
            com.Parameters.Add("@IFSCCODE", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IFSCCODE", SqlDbType.VarChar).Value = IFSCCODE.Trim();
        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }
}