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

public partial class UI_TSiPASS_frmCFESplitPaymentReportGWD : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal NumberofApprovalsappliedfor1;
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["user"] != null && Session["user"] != "")
        //{ }
        //else
        //{
        //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //}

        lblHeading.Text = "Payment Details";
        Label1.Text = "Report as on date " + DateTime.Now;

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
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
            ddlDepartment.SelectedValue = "15";
            ddlDepartment.Enabled = false;
            ddlmodule.Enabled = false;
            ddlmodule.SelectedValue = "CFE";
            ddlBank.SelectedValue = "Kotak";
            ddlBank.Enabled = false;
            ddlpaymentType.SelectedValue = "O";
            ddlpaymentType.Enabled = false;

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
        Response.Redirect("frmCFEpaymentDetails.aspx");
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
        excel_button.Visible = true;
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
        DataSet ds = new DataSet();
        //ds = Gen.RetriveStatusForViewApplication(Request.QueryString[0].ToString().Trim(), ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue);
        if (ddlpaymentType.SelectedValue.ToString() == "O")
        {

            // ds =GetpaymentdetailslatsBankType(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), txtfromDate.Text, txttoDate.Text, ddlBank.SelectedValue);
            //ds = Gen.Getcfepaydetails(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), txtfromDate.Text, txttoDate.Text, ddlBank.SelectedValue);
            ds = GetcfepaydetailsNew(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), FromdateforDB, TodateforDB, ddlBank.SelectedValue, ddlmodule.SelectedValue);

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
            ds = GetcfepaydetailsNew(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), FromdateforDB, TodateforDB, ddlBank.SelectedValue, ddlmodule.SelectedValue);

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
            ds = GetcfepaydetailsNew(ddlDepartment.SelectedValue.ToString(), txtUidno.Text, txtNameOfUnit.Text, ddldistrict.SelectedValue.ToString(), ddlpaymentType.SelectedValue.ToString(), txtfromDate.Text, txttoDate.Text, "", ddlmodule.SelectedValue);
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
        ExportToExcel();
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
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=TotalApplicationsReceived" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.Columns[1].Visible = false;
                grdDetails.AllowPaging = false;
                filldetails();

                grdDetails.RenderControl(hw);
                //grdDetails.Columns.RemoveAt("View");
                Response.Output.Write(sw.ToString());
                //HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                //HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                //HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
                //HttpContext.Current.Response.End();
                Response.Flush();
                //Response.SuppressContent = true;
                //Response.Close();
                Response.End();
            }
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

    public DataSet GetcfepaydetailsNew(string intDeptid, string UID_No, string nameofunit, string District, string paymentmode, string fromdate, string todate, string BankName, string ApplicationType)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_PAYMENT_ABSTRACT_DTLS_ONLINE_DEPARTMENTTRANSFERED", con.GetConnection);
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
}