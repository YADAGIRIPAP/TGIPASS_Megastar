using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;


public partial class UI_TSiPASS_lthtnpdclgstdata : System.Web.UI.Page
{
    DB.DB con = new DB.DB();

    Cls_MSME obj_msme = new Cls_MSME();
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
            BindDistricts(); 
            //BindDistricts_grid();

            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddlDistrict.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddlDistrict.Enabled = false;
            }
            else
            {
                ddlDistrict.SelectedIndex = 0;
            }

            FillDetails();
        }
    }


    protected void BindDistricts()
    {
        ddlDistrict.Items.Clear();
        string strConnectionString = ConfigurationManager.ConnectionStrings["tsipassskils"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnectionString);

        SqlDataAdapter da = new SqlDataAdapter("Select * from tm_Districts", con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlDistrict.DataSource = ds.Tables[0];
            ddlDistrict.DataValueField = "District_Id";
            ddlDistrict.DataTextField = "District_Name"; 
            ddlDistrict.DataBind();
            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("ALL", "%");
            ddlDistrict.Items.Insert(0, li);
            //ddlDistrict.Items.Insert(0, "ALL");
        }
        else
        {
            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("ALL", "%");
            ddlDistrict.Items.Insert(0, li);
        }
    }
    public void BindDistricts_grid()
    {
      
    }



    private void ClearFields()
    {
        ddlDistrict.SelectedIndex =0;
        
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        
        //if (ddlDistrict.SelectedIndex ==0)
        //{
        //    lblmsg0.Text += "Please Select District <br/>";
        //    valid = 1;
        //}
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
                     
            string district = ddlDistrict.SelectedItem.Text.Trim();
            DataSet ds = GetMSMENPDCLorGSTdata(district);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
              
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                }
                else
                {
                    lblmsg0.Text = "No Records Found ";
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }

    }
    public DataSet GetMSMENPDCLorGSTdata(string district)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] 
        {
            new SqlParameter("@DISTRICT",SqlDbType.VarChar)
           };
            pp[0].Value = district;

        Dsnew = Gen.GenericFillDs("usp_msme_npdcl_gst", pp);
        return Dsnew;
    }

    protected void ddl_status_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList enterprisetype = (DropDownList)sender;
        GridViewRow row = (GridViewRow)enterprisetype.NamingContainer;
        //HiddenField hf_msmeid = (HiddenField)row.FindControl("hf_msmeid");
        DropDownList ddl_status = (DropDownList)row.FindControl("ddl_status");
        RadioButtonList msmeornot = (RadioButtonList)row.FindControl("rblmsme");
        Label lblmsme = (Label)row.FindControl("lblmsme");
        //TextBox TxtRemarks = (TextBox)row.FindControl("TXTREMARKS");
        Label LBLID = (Label)row.FindControl("LBLID");

        //TxtRemarks.Visible = false;
        msmeornot.Visible = false;
        lblmsme.Visible = false;

        if (ddl_status.SelectedIndex <= 0)
        {
            ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", "select the Enterprise type", true);
            return;
        }
        else if (ddl_status.SelectedValue == "1")
        {

            msmeornot.Visible = true;
            lblmsme.Visible = true;

        }
        
        if (ddl_status.SelectedValue == "2")
         {
                msmeornot.Visible = false;
                lblmsme.Visible = false;
            try
            {
                int i = 0;

                i = UPDATE_SERVICEORMANF(LBLID.Text);

                if (i > 0)
                {
                    //Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

                    FillDetails();

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }
       
        //if (msmeornot.SelectedValue == "N")
        //{
        //    Response.Redirect("frmmsme_LTHTGST.aspx");
        //}
    }

    protected void rblmsme_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        RadioButtonList rbtyesrorno = (RadioButtonList)sender;
        GridViewRow row = (GridViewRow)rbtyesrorno.NamingContainer;
        RadioButtonList msmeornot = (RadioButtonList)row.FindControl("rblmsme");
        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

        string LBLDISTRICTID = ((Label)grdDetails.Rows[indexing].FindControl("LBLDISTRICTID")).Text;
        string LBLUNITNAME = ((Label)grdDetails.Rows[indexing].FindControl("LBLUNITNAME")).Text;
        string LBLID = ((Label)grdDetails.Rows[indexing].FindControl("LBLID")).Text;

        if (msmeornot.SelectedValue=="Y")
        {
            Response.Redirect("LTHTGSTDATAPROCESSING.aspx?DISTRICTID=" + LBLDISTRICTID +  "&UNITNAME="+LBLUNITNAME+ "&LBLID=" + LBLID);

        }
        else
        {
            Response.Redirect("frmmsme_LTHTGST.aspx");

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
            DropDownList ddl_status = (DropDownList)e.Row.FindControl("ddl_status");
            RadioButtonList msmeornot = (RadioButtonList)e.Row.FindControl("rblmsme");
            DropDownList ddldistrict_GRID = (DropDownList)e.Row.FindControl("ddldistrict_GRID");
            RadioButtonList rbldistrict = (RadioButtonList)e.Row.FindControl("rbldistrict");
            RadioButtonList rblunitname = (RadioButtonList)e.Row.FindControl("rblunitname");

            Label LBLDISTYESORNO =(Label)e.Row.FindControl("LBLSAMEDISTRICTORNOT");
            Label LBLINDUSORSERVICE= (Label)e.Row.FindControl("LBLINDUSORSERVICE");
            Label LBLUNITNAMESAMEORNIT = (Label)e.Row.FindControl("LBLUNITNAMESAMEORNIT");
            Label LBLCONNECTIONSTATUS = (Label)e.Row.FindControl("LBLCONNECTIONSTATUS");
            RadioButtonList rbltemporperm= (RadioButtonList)e.Row.FindControl("rbltemporperm");

            Label LBLDISCONNECTION = (Label)e.Row.FindControl("LBLDISCONNECTION");
            Label LBLREASONS = (Label)e.Row.FindControl("LBLREASONS");



            if (LBLDISTYESORNO.Text=="Y")
            {
                rbldistrict.SelectedValue = "Y";
                rbldistrict.Enabled = false;

            }
            if(LBLINDUSORSERVICE.Text=="1")
            {
                ddl_status.SelectedValue = "1";
                ddl_status.Enabled = false;
            }
            if (LBLINDUSORSERVICE.Text == "2")
            {
                ddl_status.SelectedValue = "2";
                ddl_status.Enabled = false;
            }
            if (LBLUNITNAMESAMEORNIT.Text == "Y")
            {
                rblunitname.SelectedValue = "Y";
                rblunitname.Enabled = false;
            }
            if (LBLUNITNAMESAMEORNIT.Text == "N")
            {
                rblunitname.SelectedValue = "N";
                rblunitname.Enabled = false;
            }
            if (LBLCONNECTIONSTATUS.Text == "UDC"|| LBLCONNECTIONSTATUS.Text == "BS")
            {
                rbltemporperm.Visible = true;
                rbltemporperm.Enabled = true;
            }
            if(LBLCONNECTIONSTATUS.Text == "LIVE")
            {
                rbltemporperm.Visible = false;

                rbltemporperm.Enabled = false;
            }
            if(LBLDISCONNECTION.Text=="T")
            {
                rbltemporperm.SelectedValue = "T";
                rbltemporperm.Enabled = false;
                LBLREASONS.Visible = true;
            }
            if (LBLDISCONNECTION.Text == "P")
            {
                rbltemporperm.SelectedValue = "P";
                rbltemporperm.Enabled = false;

                LBLREASONS.Visible = true;

            }


            if (msmeornot.SelectedValue == "Y")
            {
                Response.Redirect("frmmsme_LTHTGST.aspx?DISTRICTID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")) + "&MANDALID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MANDALID")));

            }
            else
            {
                
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
        }
    }
   
    #region print
    
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
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //}
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void ExportToExcel()
    {
        //try
        //{
        //    Response.Clear();
        //    string drillDowntype = "";
        //    Response.Buffer = true;
        //    string FileName = lblHeading.Text;
        //    FileName = FileName.Replace(" ", "");
        //    Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        HtmlTextWriter hw = new HtmlTextWriter(sw);

        //        string status = Request.QueryString[0].ToString().Trim();
        //        string type = Request.QueryString[1].ToString().Trim();
        //        if (Session["user_id"].ToString() == "JDMSME" || Session["user_id"].ToString() == "Commissioner")
        //        {
        //            drillDowntype = ViewState["drillDowntype"].ToString();
        //        }

        //        string FromdateforDB = "", TodateforDB = "";
        //        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        //        {
        //            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        //            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        //        }
        //        string rolecode = Request.QueryString["ROLE"].ToString().Trim();
        //        string district = Request.QueryString["district"].ToString().Trim();
        //        DataSet ds = GetMSMEApplicationsDrill(FromdateforDB, TodateforDB, district, rolecode, drillDowntype);
        //        grdExport.DataSource = ds.Tables[0];
        //        grdExport.DataBind();
        //        grdExport.RenderControl(hw);
        //        string label1text = Label1.Text;
        //        string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
        //        HttpContext.Current.Response.Write(headerTable);

        //        Response.Output.Write(sw.ToString());
        //        Response.Flush();
        //        Response.End();
        //    }
        //}
        //catch (Exception e)
        //{

        //}
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
    


    protected void rbldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList rbtyesrorno = (RadioButtonList)sender;
        GridViewRow row = (GridViewRow)rbtyesrorno.NamingContainer;
        RadioButtonList districtornot = (RadioButtonList)row.FindControl("rbldistrict");
        DropDownList ddl_status = (DropDownList)row.FindControl("ddl_status");
        DropDownList ddldistrict_GRID = (DropDownList)row.FindControl("ddldistrict_GRID");

        Label LBLDISTRICTORNOT = (Label)row.FindControl("LBLDISTRICTORNOT");
        Label LBLID = (Label)row.FindControl("LBLID");

        if (districtornot.SelectedValue=="N")
        {
            ddl_status.Enabled = false;
            ddl_status.Visible = false;
            ddldistrict_GRID.Visible = true;
            LBLDISTRICTORNOT.Visible = true;

            try
            {

                DataSet dsd = new DataSet();
                ddldistrict_GRID.Items.Clear();
                dsd = Gen.GetDistrictsWithoutHYD();
                if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                {
                    ddldistrict_GRID.DataSource = dsd.Tables[0];
                    ddldistrict_GRID.DataValueField = "District_Id";
                    ddldistrict_GRID.DataTextField = "District_Name";
                    ddldistrict_GRID.DataBind();
                    ddldistrict_GRID.Items.Insert(0, "--Select--");
                    //AddSelect(ddlDistrict);
                }
                else
                {
                    ddldistrict_GRID.Items.Insert(0, "--Select--");
                    // AddSelect(ddlDistrict);
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
        else
        {
            ddl_status.Enabled = true;
            ddl_status.Visible = true;
            ddldistrict_GRID.Visible = false;
            LBLDISTRICTORNOT.Visible = false;
            try
            {
                int i = 0;

                i = UPDATEDISTRICTCOLUMN_YESORNO(LBLID.Text);

                if (i > 0)
                {
                    //Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

                    FillDetails();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }
    }

    protected void ddldistrict_GRID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddldistrict = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddldistrict.NamingContainer;
        //HiddenField hf_msmeid = (HiddenField)row.FindControl("hf_msmeid");
        DropDownList ddldistrict_GRID = (DropDownList)row.FindControl("ddldistrict_GRID");
        Label lblid= (Label)row.FindControl("LBLID");

        try
        {
            int i = 0;
            
            i = UPDATEDISTRICTID(ddldistrict_GRID.SelectedValue, lblid.Text);

            if (i>0)
            {
                //Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

                FillDetails();

            }
            else
            {
                
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    public int UPDATEDISTRICTID(string ddldistrict_GRID,string  lblid )
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UPDATEDISTRICTID";
        {
            if (ddldistrict_GRID == "" || ddldistrict_GRID == null || ddldistrict_GRID == "--Select--")
                com.Parameters.Add("@ddldistrict_GRID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ddldistrict_GRID", SqlDbType.VarChar).Value = ddldistrict_GRID.Trim();

            if (lblid == "" || lblid == null || lblid == "--Select--")
                com.Parameters.Add("@lblid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@lblid", SqlDbType.VarChar).Value = lblid.Trim();
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
    public int UPDATEDISTRICTCOLUMN_YESORNO( string lblid)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UPDATEDISTRICTCOLUMN_YESORNO";
        {
            

            if (lblid == "" || lblid == null || lblid == "--Select--")
                com.Parameters.Add("@lblid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@lblid", SqlDbType.VarChar).Value = lblid.Trim();
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
    public int UPDATE_SERVICEORMANF(string lblid)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UPDATE_SERVICEORMANF";
        {


            if (lblid == "" || lblid == null || lblid == "--Select--")
                com.Parameters.Add("@lblid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@lblid", SqlDbType.VarChar).Value = lblid.Trim();
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



    protected void rblunitname_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList rbtyesrorno = (RadioButtonList)sender;
        GridViewRow row = (GridViewRow)rbtyesrorno.NamingContainer;
        RadioButtonList unitornot = (RadioButtonList)row.FindControl("rblunitname");
        DropDownList ddl_status = (DropDownList)row.FindControl("ddl_status");
        TextBox txtunitname = (TextBox)row.FindControl("txtunitname");
        Button btnsubmitunitname = (Button)row.FindControl("btnsubmitunitname");
        Label LBLUNITNAME = (Label)row.FindControl("LBLUNITNAMENEW");
        Label LBLID = (Label)row.FindControl("LBLID");

        if (unitornot.SelectedValue == "N")
        {
            ddl_status.Enabled = false;
            ddl_status.Visible = false;
            txtunitname.Visible = true;
            LBLUNITNAME.Visible = true;
            btnsubmitunitname.Visible = true;

        }
        else
        {
            ddl_status.Enabled = true;
            ddl_status.Visible = true;
            txtunitname.Visible = false;
            LBLUNITNAME.Visible = false;
            btnsubmitunitname.Visible = false;

            try
            {
                int i = 0;

                i = UPDATEUNITNAME_YESORNO(LBLID.Text);

                if (i > 0)
                {
                    //Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

                    FillDetails();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }
    }
    public int UPDATEUNITNAME_YESORNO(string lblid)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UPDATEUNITNAME_YESORNO";
        {


            if (lblid == "" || lblid == null || lblid == "--Select--")
                com.Parameters.Add("@lblid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@lblid", SqlDbType.VarChar).Value = lblid.Trim();
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


    protected void btnsubmitunitname_Click(object sender, EventArgs e)
    {

        Button rbtyesrorno = (Button)sender;
        GridViewRow row = (GridViewRow)rbtyesrorno.NamingContainer;
        RadioButtonList unitornot = (RadioButtonList)row.FindControl("rblunitname");
        DropDownList ddl_status = (DropDownList)row.FindControl("ddl_status");
        TextBox txtunitname = (TextBox)row.FindControl("txtunitname");
        Label LBLID = (Label)row.FindControl("LBLID");

        if (txtunitname.Text==""|| txtunitname.Text==null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Please enter unit name as per MSME data');", true);
        }
        else
        {
            try
            {
                int i = 0;

                i = UPDATEUNITNAME(txtunitname.Text, LBLID.Text);

                if (i > 0)
                {
                    //Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

                    FillDetails();

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }

        }
    }
    public int UPDATEUNITNAME(string UNITNAME, string lblid)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UPDATEUNITNAME";
        {
            if (UNITNAME == "" || UNITNAME == null || UNITNAME == "--Select--")
                com.Parameters.Add("@UNITNAME", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@UNITNAME", SqlDbType.VarChar).Value = UNITNAME.Trim();

            if (lblid == "" || lblid == null || lblid == "--Select--")
                com.Parameters.Add("@lblid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@lblid", SqlDbType.VarChar).Value = lblid.Trim();
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


    protected void rbltemporperm_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList rbtyesrorno = (RadioButtonList)sender;
        GridViewRow row = (GridViewRow)rbtyesrorno.NamingContainer;
        RadioButtonList rbltemporperm = (RadioButtonList)row.FindControl("rbltemporperm");
        DropDownList ddl_status = (DropDownList)row.FindControl("ddl_status");
        TextBox txtreason = (TextBox)row.FindControl("txtreason");
        Button btnsubmitreason = (Button)row.FindControl("btnsubmitreason");
        Label LBLREASON = (Label)row.FindControl("LBLREASON");
        Label LBLID = (Label)row.FindControl("LBLID");
        txtreason.Visible = true;
        LBLREASON.Visible = true;
        btnsubmitreason.Visible = true;

    }

    protected void btnsubmitreason_Click(object sender, EventArgs e)
    {
        Button rbtyesrorno = (Button)sender;
        GridViewRow row = (GridViewRow)rbtyesrorno.NamingContainer;
        RadioButtonList rbltemporperm = (RadioButtonList)row.FindControl("rbltemporperm");
        DropDownList ddl_status = (DropDownList)row.FindControl("ddl_status");
        TextBox txtreason = (TextBox)row.FindControl("txtreason");
        Label LBLID = (Label)row.FindControl("LBLID");
        if (txtreason.Text == "" || txtreason.Text == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Please enter Reasons for Disconnection(UDC/BS)');", true);
        }
        else
        {
            try
            {
                int i = 0;

                i = UPDATEREASONS(LBLID.Text, rbltemporperm.SelectedValue, txtreason.Text);

                if (i > 0)
                {
                    //Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

                    FillDetails();

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }

        }
    }
    public int UPDATEREASONS(string lblid,string Temporpermnt,string reasons)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UPDATEREASONS";
        {


            if (lblid == "" || lblid == null || lblid == "--Select--")
                com.Parameters.Add("@lblid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@lblid", SqlDbType.VarChar).Value = lblid.Trim();
            if (Temporpermnt == "" || Temporpermnt == null || Temporpermnt == "--Select--")
                com.Parameters.Add("@Temporpermnt", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Temporpermnt", SqlDbType.VarChar).Value = Temporpermnt.Trim();
            if (reasons == "" || reasons == null || reasons == "--Select--")
                com.Parameters.Add("@reasons", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@reasons", SqlDbType.VarChar).Value = reasons.Trim();
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

}


