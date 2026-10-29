using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_frmMSMEReportDRILLDOWN : System.Web.UI.Page
{
    Cls_MSME obj_msme = new Cls_MSME();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal NumberofApprovalsappliedfor1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                //Label1.Text = "Report from " + Request.QueryString["fromdate"].ToString().Trim() + " To " + Request.QueryString["todate"].ToString().Trim();
                Label1.Text = "Report from " + Request.QueryString["fromdate"].ToString().Trim() + " To " + DateTime.Now;

                txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todate"].ToString().Trim();
                if (Session["user_id"].ToString() == "JDMSME" || Session["user_id"].ToString() == "Commissioner" || Session["Role_Code"].ToString() == "GM" || Session["Role_Code"].ToString() == "IPO" || Session["Role_Code"].ToString() == "DD" || Session["Role_Code"].ToString() == "AD")
                {
                    if (Request.QueryString["type"] != "" && Request.QueryString["type"] != null)
                    {
                        ViewState["drillDowntype"] = Request.QueryString["type"].ToString().Trim();
                    }
                }

            }
            else
            {
                Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            }
            FillDetails();
            if (Session["Role_Code"].ToString() == "GM")
            {
                gmpen.Visible = true;
            }
            else
            {
                gmpen.Visible = false;
            }
        }
    }
    private void ClearFields()
    {
        Label1.Text = "";
        txtFromDate.Text = "";
        txtTodate.Text = "";
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        if (valid == 0)
        {
            FillDetails();
        }
        else
        {
            Failure.Visible = true;
        }
    }
    void FillDetails()
    {
        try
        {
            string status = Request.QueryString[1].ToString().Trim();
            string type = Request.QueryString[0].ToString().Trim();
            string drillDowntype = "";
            if (Session["user_id"].ToString() == "JDMSME" || Session["user_id"].ToString() == "Commissioner" || Session["Role_Code"].ToString() == "GM" || Session["Role_Code"].ToString() == "IPO" || Session["Role_Code"].ToString() == "DD" || Session["Role_Code"].ToString() == "AD")
            {
                if (ViewState["drillDowntype"] != "" && ViewState["drillDowntype"] != null)
                {
                    drillDowntype = ViewState["drillDowntype"].ToString();
                }
            }


            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }

            string rolecode = Request.QueryString["ROLE"].ToString().Trim();
            string district = Request.QueryString["district"].ToString().Trim();
            DataSet ds = GetMSMEApplicationsDrill(FromdateforDB, TodateforDB, district, rolecode, drillDowntype);
            if (drillDowntype != "TSIPASSUNITS" && drillDowntype != "TSIPASSNOTMAPPEDWITHMSME")
            {
                divPrint_new.Visible = false;
                divPrint.Visible = true;

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
                    Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + DateTime.Now;
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                }
                else
                {
                    Label1.Text = "No Records Found ";
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                }
            }
            if (drillDowntype == "TSIPASSUNITS" || drillDowntype == "TSIPASSNOTMAPPEDWITHMSME" || drillDowntype == "TSIPASSUNABLETOMAP")
            {
                Label1.Text = "No check Found ";
                divPrint_new.Visible = true;
                divPrint.Visible = false;

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
                    Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + DateTime.Now;
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    if (drillDowntype == "TSIPASSUNABLETOMAP")
                    {
                        GridView1.Columns[9].Visible = false;
                    }
                }
                else
                {
                    Label1.Text = "No Records Found ";

                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                GridView2.DataSource = ds.Tables[1];
                GridView2.DataBind();
            }

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].CssClass = "text-center";
            HyperLink LinkEDIT = (HyperLink)e.Row.FindControl("LinkEDIT");
            LinkButton linkdelete = (LinkButton)e.Row.FindControl("linkdelete");
            TextBox TXTREMARKS = (TextBox)e.Row.FindControl("TXTREMARKS");
            Label lbl_deletestatus = (Label)e.Row.FindControl("lbl_deletestatus");
            DropDownList ddl_griddeletedstatus = (DropDownList)e.Row.FindControl("ddl_griddeletedstatus");

            string DeleteFlag = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DeleteFlag")).Trim();
            string DeletedID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DeletedID")).Trim();
            string DeletedReason = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DeletedReason")).Trim();

            //if ((Session["userlevel"].ToString() == "10" && Session["DistrictID"].ToString().Trim() != "") && (Session["DistrictID"].ToString().Trim() == "6" 
            //    || Session["DistrictID"].ToString().Trim() == "10"
            //    || Session["DistrictID"].ToString().Trim() == "16" || Session["DistrictID"].ToString().Trim() == "18" || Session["DistrictID"].ToString().Trim() == "20"
            //    || Session["DistrictID"].ToString().Trim() == "23" || Session["DistrictID"].ToString().Trim() == "24" || Session["DistrictID"].ToString().Trim() == "28"
            //    || Session["DistrictID"].ToString().Trim() == "32"))
            //{
            //if ((Session["Role_Code"] != null && Session["Role_Code"].ToString() == "GM")) //provision given to all logins to update msme report details on 20.07.2021
            if ((Session["Role_Code"] != null))
            {
                if (Session["uid"].ToString() != "3377")
                {

                    LinkEDIT.Visible = true;
                    linkdelete.Visible = false;
                    TXTREMARKS.Visible = false;
                    lbl_deletestatus.Visible = true;
                    ddl_griddeletedstatus.Visible = true;

                    grdDetails.Columns[2].Visible = true;
                    string editstatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "editstatus")).Trim();
                    string totalemployee = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "totalEmployement")).Trim();
                    string category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnterpriseName")).Trim();
                    if (!string.IsNullOrEmpty(editstatus) && editstatus != "N")
                    {
                        LinkEDIT.Visible = false;
                        linkdelete.Visible = false;
                        TXTREMARKS.Visible = false;
                        ddl_griddeletedstatus.Visible = false;
                        e.Row.BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(DeleteFlag) && (DeleteFlag == "Y" || DeleteFlag == "1" || DeleteFlag.ToLower() == "true"))
                        {
                            LinkEDIT.Visible = false;
                            linkdelete.Visible = false;
                            TXTREMARKS.Visible = false;
                            lbl_deletestatus.Visible = true;
                            ddl_griddeletedstatus.Visible = false;
                        }
                    }

                    String intedit = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "msmeNo")).Trim();
                    LinkEDIT.Text = "MAP TO TSIPASS UNIT";
                    //LinkEDIT.OnClientClick = "javascript:return PopupONE('" + intedit + "')";
                    LinkEDIT.NavigateUrl = "frmMSME_edit.aspx?UID=" + intedit;
                    if (category == "MEGA" || category == "LARGE" || category == "MEDIUM")
                    {
                        if (totalemployee == "" || totalemployee == null)
                        {
                            LinkEDIT.Visible = true;
                            LinkEDIT.Text = "MSME Employment Edit";
                            LinkEDIT.NavigateUrl = "frmMSME_edit.aspx?UID=" + intedit;
                        }
                    }
                    if (Request.QueryString["type"] != null && Convert.ToString(Request.QueryString["type"]) == "MSMECLOSEDUNITS")
                    {
                        grdDetails.Columns[1].Visible = false;
                        grdDetails.Columns[2].Visible = false;
                    }
                }
                else
                {
                    LinkEDIT.Visible = false;
                    linkdelete.Visible = false;
                    TXTREMARKS.Visible = false;
                }



                string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "msmeNo")).Trim();
                LinkButton lnk_grdview = (LinkButton)e.Row.FindControl("lnk_grdview");
                lnk_grdview.Text = "View";
                lnk_grdview.OnClientClick = "javascript:return Popup('" + intUid + "')";
            }


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
        }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;

        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        if (valid == 0)
        {
            FillDetails();
        }
        else
        {
            Failure.Visible = true;
        }
    }

    #region print
    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            string drillDowntype = "";
            Response.Buffer = true;
            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                string status = Request.QueryString[0].ToString().Trim();
                string type = Request.QueryString[1].ToString().Trim();
                if (Session["user_id"].ToString() == "JDMSME" || Session["user_id"].ToString() == "Commissioner")
                {
                    drillDowntype = ViewState["drillDowntype"].ToString();
                }

                string FromdateforDB = "", TodateforDB = "";
                if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
                {
                    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                }
                string rolecode = Request.QueryString["ROLE"].ToString().Trim();
                string district = Request.QueryString["district"].ToString().Trim();
                DataSet ds = GetMSMEApplicationsDrill(FromdateforDB, TodateforDB, district, rolecode, drillDowntype);
                grdExport.DataSource = ds.Tables[0];
                grdExport.DataBind();
                grdExport.RenderControl(hw);
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception e)
        {

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
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";
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
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";
                    }
                    catch (Exception) { }
                }
            }
        }
        catch (Exception) { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    grdDetails.AllowPaging = false;

                    // this.FillDetails();
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.Visible = false;
                    grdDetails.Columns[1].Visible = false;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= MSMEreport" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception e)
        {

        }
    }
    #endregion

    public DataSet GetMSMEApplicationsDrill(string fromdate, string todate, string district, string rolecode, string drillDowntype)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FromDate",SqlDbType.VarChar),
                new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@DISTRICTID",SqlDbType.VarChar),
                new SqlParameter("@ROLECODE",SqlDbType.VarChar),
                new SqlParameter("@type",SqlDbType.VarChar)


           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        pp[2].Value = district;
        pp[3].Value = rolecode;
        pp[4].Value = drillDowntype;


        Dsnew = Gen.GenericFillDs("USP_GET_MSME_REPORT_DRILLDOWN_NEW", pp);
        return Dsnew;
    }




    protected void linkdelete_Click(object sender, EventArgs e)
    {
        LinkButton BtnReject = (LinkButton)sender;
        GridViewRow row = (GridViewRow)BtnReject.NamingContainer;
        TextBox TxtRemarks = (TextBox)row.FindControl("TXTREMARKS");
        HiddenField hf_msmeid = (HiddenField)row.FindControl("hf_msmeid");
        DropDownList ddl_griddeletedstatus = (DropDownList)row.FindControl("ddl_griddeletedstatus");
        LinkButton linkdelete = (LinkButton)row.FindControl("linkdelete");
        string DeletedReason = "";
        string DeletedID = "";
        if (ddl_griddeletedstatus.SelectedIndex <= 0)
        {
            ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", "select the Reason for Delete", true);
            return;
        }
        else
        {
            bool checkstatus = false;

            DeletedID = Convert.ToString(ddl_griddeletedstatus.SelectedValue);
            if (ddl_griddeletedstatus.SelectedValue == "1" || ddl_griddeletedstatus.SelectedValue == "2" || ddl_griddeletedstatus.SelectedValue == "3")
            {
                checkstatus = true;
                DeletedReason = ddl_griddeletedstatus.SelectedItem.Text;
            }
            else
            {
                if (ddl_griddeletedstatus.SelectedValue == "4" && ddl_griddeletedstatus.SelectedItem.Text.ToLower().Contains("others"))
                {
                    if (string.IsNullOrEmpty(Convert.ToString(TxtRemarks.Text)))
                    {
                        ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", "select the Reason for Delete", true);
                        return;
                    }
                    else
                    {
                        DeletedReason = Convert.ToString(TxtRemarks.Text);
                        checkstatus = true;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", "select the Reason for Delete", true);
                    return;
                }
            }


            if (checkstatus == true)
            {
                //if (!string.IsNullOrWhiteSpace(TxtRemarks.Text))
                //{
                string msmeno = hf_msmeid.Value;
                string deleteflag = "Y";
                string remarks = Convert.ToString(DeletedReason);
                string createdby = Session["uid"].ToString();
                // string DeletedID = Convert.ToString(ddl_griddeletedstatus.SelectedValue);

                string DeletedIP = Convert.ToString(Request.ServerVariables["Remote_Addr"]);
                int i = obj_msme.DeleteMsmeDetailsbyIDandDIC(msmeno, deleteflag, remarks, createdby, DeletedID, DeletedReason, DeletedIP);
                if (i > 0)
                {
                    string message = "alert('" + "Record Deleted Successfully" + "')";
                    ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", message, true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", "Please select  remarks", true);

                    return;

                }
                //}
                //else
                //{
                //    //Response.Write("<script>alert('Please enter remarks');</script>");
                //    ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", "Please enter remarks", true);
                //    TxtRemarks.Focus();
                //    return;
                //}
            }



        }

        FillDetails();
    }
    protected void ddl_griddeletedstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList BtnDropDownListReject = (DropDownList)sender;
        GridViewRow row = (GridViewRow)BtnDropDownListReject.NamingContainer;
        HiddenField hf_msmeid = (HiddenField)row.FindControl("hf_msmeid");
        DropDownList ddl_griddeletedstatus = (DropDownList)row.FindControl("ddl_griddeletedstatus");
        TextBox TxtRemarks = (TextBox)row.FindControl("TXTREMARKS");
        LinkButton linkdelete = (LinkButton)row.FindControl("linkdelete");
        TxtRemarks.Visible = false;
        linkdelete.Visible = false;
        if (ddl_griddeletedstatus.SelectedIndex <= 0)
        {
            ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", "select the Reason for Delete", true);
            return;
        }
        else
        {
            if (ddl_griddeletedstatus.SelectedValue == "1" || ddl_griddeletedstatus.SelectedValue == "2" || ddl_griddeletedstatus.SelectedValue == "3")
            {

                TxtRemarks.Visible = false;
                linkdelete.Visible = true;

                //    string msmeno = hf_msmeid.Value;
                //    string deleteflag = "Y";
                //    string remarks = Convert.ToString(TxtRemarks.Text);
                //    string createdby = Session["uid"].ToString();
                //    string DeletedID = Convert.ToString(ddl_griddeletedstatus.SelectedValue);
                //    string DeletedReason = Convert.ToString(ddl_griddeletedstatus.SelectedItem.Text);
                //    string DeletedIP = Convert.ToString(Request.ServerVariables["Remote_Addr"]);
                //    int i = obj_msme.DeleteMsmeDetailsbyIDandDIC(msmeno, deleteflag, remarks, createdby, DeletedID, DeletedReason, DeletedIP);
                //    if (i > 0)
                //    {
                //        string message = "alert('" + "Record Deleted Successfully" + "')";
                //        ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", message, true);
                //    }
            }
            else
            {
                if (ddl_griddeletedstatus.SelectedValue == "4" && ddl_griddeletedstatus.SelectedItem.Text.ToLower().Contains("others"))
                {
                    TxtRemarks.Visible = true;
                    linkdelete.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", "select the Reason for Delete", true);
                    return;
                }
            }
        }
    }


    protected void BtnReject_Click(object sender, EventArgs e)
    {
        Button BtnReject = (Button)sender;
        GridViewRow row = (GridViewRow)BtnReject.NamingContainer;
        TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject");
        string unitname = row.Cells[1].Text.ToString();
        RadioButtonList rdbUnabletoMap = (RadioButtonList)row.FindControl("rdbUnabletoMap");
        LinkButton lnk_grdview = (LinkButton)row.FindControl("lnk_grdview");
        Label lblUIDNo = (Label)row.FindControl("lblUIDNo");



        if ((TxtRemarks.Visible) && (TxtRemarks.Text != ""))
        {
            osqlConnection.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[USP_UnabletoMapMSME]";
            com.Connection = osqlConnection;

            com.Parameters.Add("@TxtRemarks", SqlDbType.VarChar).Value = TxtRemarks.Text.ToString();
            com.Parameters.Add("@unabletoMap", SqlDbType.VarChar).Value = rdbUnabletoMap.SelectedValue.ToString();
            com.Parameters.Add("@updatedBy", SqlDbType.VarChar).Value = Session["uid"].ToString();
            com.Parameters.Add("@uidNo", SqlDbType.VarChar).Value = lblUIDNo.Text.ToString();
            com.Parameters.Add("@nameUnit", SqlDbType.VarChar).Value = unitname.ToString();



            com.ExecuteNonQuery();
            osqlConnection.Close();
            BtnReject.Visible = false;
        }
        else
        {
            //Response.Write("<script>alert('Please enter remarks');</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate1", "RejectValidate1();", true);
            TxtRemarks.Focus();
            return;
        }






    }









    //protected void linkdelete_Click(object sender, EventArgs e)
    //{
    //    LinkButton BtnReject = (LinkButton)sender;
    //    GridViewRow row = (GridViewRow)BtnReject.NamingContainer;
    //    TextBox TxtRemarks = (TextBox)row.FindControl("TXTREMARKS");
    //    HiddenField hf_msmeid = (HiddenField)row.FindControl("hf_msmeid");

    //    if (!string.IsNullOrWhiteSpace(TxtRemarks.Text))
    //    {
    //        string msmeNo = hf_msmeid.Value;
    //        DataSet dsna = new DataSet();
    //        int i = Gen.DeleteMsmeDetailsByGM(msmeNo, "Y", TxtRemarks.Text, Session["uid"].ToString());
    //        if (i > 0)
    //        {
    //            string message = "alert('" + "Record Deleted Successfully" + "')";
    //            ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", message, true);
    //        }
    //    }
    //    else
    //    {
    //        //Response.Write("<script>alert('Please enter remarks');</script>");
    //        ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", "Please enter remarks", true);
    //        TxtRemarks.Focus();
    //        return;
    //    }

    //}



    protected void rdbUnabletoMap_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList rdbUnabletoMap = (RadioButtonList)sender;
        GridViewRow row = (GridViewRow)rdbUnabletoMap.NamingContainer;
        TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject");
        Button BtnReject = (Button)row.FindControl("BtnReject");
        Button btnInsertCatalogue = (Button)row.FindControl("btnInsertCatalogue");

        if (rdbUnabletoMap.SelectedIndex == 0)
        {
            BtnReject.Visible = true;
            TxtRemarks.Visible = true;
            btnInsertCatalogue.Visible = false;
        }
        else if (rdbUnabletoMap.SelectedIndex == 1)
        {
            BtnReject.Visible = false;
            TxtRemarks.Visible = false;
            btnInsertCatalogue.Visible = true;

        }
        //else TxtRemarks.Visible = true;
    }

    protected void btnInsertCatalogue_Click(object sender, EventArgs e)
    {
        Button btnInsertCatalogue = (Button)sender;
        GridViewRow row = (GridViewRow)btnInsertCatalogue.NamingContainer;
        //lblUIDNo
        Label lblUIDNo = (Label)row.FindControl("lblUIDNo");
        Response.Redirect("frmcapturemsmenewcommon.aspx?UID=" + lblUIDNo.Text);



    }
}