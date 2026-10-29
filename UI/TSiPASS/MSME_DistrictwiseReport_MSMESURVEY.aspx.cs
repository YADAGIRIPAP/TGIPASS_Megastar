using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;

public partial class UI_TSiPASS_MSME_DistrictwiseReport_MSMESURVEY : System.Web.UI.Page
{
    string District = null;
    string FromdateforDB = null;
    string TodateforDB = null;
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbl_datesdisplay.Text = "Report as on date " + DateTime.Now;
            txtFromDate.Text = "01-01-2020";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                District = Convert.ToString(Session["DistrictID"]);

            }
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

            FillGrid(District, FromdateforDB, TodateforDB);

        }
    }


    protected void btnGet_Click(object sender, EventArgs e)
    {
        Failure.Visible = false;
        lblmsg0.Text = "";
        try
        {
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                District = Convert.ToString(Session["DistrictID"]);

            }
            if (txtFromDate.Text == "" && txtFromDate.Text == null && txtTodate.Text == "" && txtTodate.Text == null)
            {
                FillGrid(District, FromdateforDB, TodateforDB);
            }
            else
            {
                if (txtFromDate.Text == "" || txtFromDate.Text == null)
                {
                    if (txtTodate.Text != "" || txtTodate.Text != null)
                    {
                        Failure.Visible = true;
                        lblmsg0.Text = "Please Enter From Date ";
                    }
                    else
                    {
                        FillGrid(District, FromdateforDB, TodateforDB);
                    }
                }
                else
                {
                    if (txtTodate.Text == "" || txtTodate.Text == null)
                    {
                        Failure.Visible = true;
                        lblmsg0.Text += "Please Enter To Date";
                    }
                    else
                    {
                        FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                        TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                        lbl_datesdisplay.Text = "Report from " + txtFromDate.Text.Trim() + " to " + txtTodate.Text.Trim();
                        FillGrid(District, FromdateforDB, TodateforDB);
                    }
                }

            }

        }
        catch (Exception ex)
        {
            Failure.Visible = true;
            lblmsg0.Text += ex;

        }
    }
    private void FillGrid(string District, string fromdate, string todate)
    {
        DataSet ds = new DataSet();
        grdDetails.DataSource = null;
        grdDetails.DataBind();
        ds = MSMEDistrictwiseReport(District, fromdate, todate);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
    }
    public DataSet MSMEDistrictwiseReport(string District, string FromDate, string ToDate)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETEMSMEDATA_MSMESURVEY", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (District == "" || District == null)
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = District.Trim();
            if (FromDate == "" || FromDate == null)
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromDate.Trim();
            if (ToDate == "" || ToDate == null)
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = ToDate.Trim();

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

    int totalNoofunits;
    int TotalUnitsupdated, TotalUnitstobeupdated;
    int TotalUnitsedited;
    int Totalproductsupdated;
    int Totalrawmaterialupdated;
    int TotalDeletedunits;
    int TotalIEunitsEdited;
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int Noofunits = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Noofunits"));
            int Unitsupdated = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "updated"));
            int UnitsTobeupdated = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "tobeupdated"));

            //int productsupdated = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "productsupdated"));
            //int rawmaterialupdated = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "rawmaterialupdated"));
            //int Deletedunits = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Deletedunits"));
            //int IEunitsEdited = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IEunitsEdited"));

            string DistrictID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "district_id"));
            string District = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Name"));
            string Status = "";
            string sendingparmeter = "";

            HyperLink hyp_noofunits = (HyperLink)e.Row.FindControl("hyp_noofunits");
            if (!string.IsNullOrEmpty(hyp_noofunits.Text))
            {
                if (hyp_noofunits.Text != "0")
                {
                    Status = "Noofunits";
                    sendingparmeter = DistrictID + "&Status=" + Status;
                    //hyp_noofunits.NavigateUrl = "javascript:return Popup('" + sendingparmeter+"')";
                    //hyp_noofunits.NavigateUrl = "frmMSMEReportSurvey.aspx?DistrictID=" + DistrictID + "&Status=" + Status + "&District=" + District+"&fromdate="+FromdateforDB+"&todate="+TodateforDB;
                }
            }

            HyperLink hupdated = (HyperLink)e.Row.FindControl("hplUpdated");
            if (hupdated.Text != "0" || !string.IsNullOrEmpty(hupdated.Text))
            {
                //Status = "Updated";
                // sendingparmeter = DistrictID + "&Status=" + Status;
                //hyp_noofunits.NavigateUrl = "javascript:return Popup('" + sendingparmeter+"')";
                hupdated.NavigateUrl = "frmMSMEReportSurvey.aspx?DistrictID=" + DistrictID + "&Status=Updated" + "&District=" + District + "&fromdate=" + FromdateforDB + "&todate=" + TodateforDB;
            }
            HyperLink htobeupdated = (HyperLink)e.Row.FindControl("hplTobeUpdated");
            if (htobeupdated.Text != "0" || !string.IsNullOrEmpty(htobeupdated.Text))
            {
                //Status = "Updated";
                // sendingparmeter = DistrictID + "&Status=" + Status;
                //hyp_noofunits.NavigateUrl = "javascript:return Popup('" + sendingparmeter+"')";
                htobeupdated.NavigateUrl = "frmMSMEReportSurvey.aspx?DistrictID=" + DistrictID + "&Status=TobeUpdated" + "&District=" + District + "&fromdate=" + FromdateforDB + "&todate=" + TodateforDB;
            }

            totalNoofunits += Noofunits;
            TotalUnitsupdated += Unitsupdated;
            TotalUnitstobeupdated = +UnitsTobeupdated;

            //TotalUnitsedited += Unitsedited;
            //Totalproductsupdated += productsupdated;
            //Totalrawmaterialupdated += rawmaterialupdated;
            //TotalDeletedunits += Deletedunits;
            //TotalIEunitsEdited += IEunitsEdited;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl_foot_noofunits = (Label)e.Row.FindControl("lbl_foot_noofunits");
            Label lblUpdatedUnits = (Label)e.Row.FindControl("lbl_Updated");
            Label lblTobeUpdatedUnits = (Label)e.Row.FindControl("lbl_tobeUpdated");

            //Label lbl_footNoofunitsUpdated = (Label)e.Row.FindControl("lbl_footNoofunitsUpdated");
            //Label lbl_footNoofunitsedit = (Label)e.Row.FindControl("lbl_footNoofunitsedit");
            //Label lbl_footNoofProductsUpdated = (Label)e.Row.FindControl("lbl_footNoofProductsUpdated");
            //Label lbl_footNoofRawMaterials = (Label)e.Row.FindControl("lbl_footNoofRawMaterials");
            //Label lbl_footInActiveUnits = (Label)e.Row.FindControl("lbl_footInActiveUnits");
            //Label lbl_footIEUnitsEdit = (Label)e.Row.FindControl("lbl_footIEUnitsEdit");

            lbl_foot_noofunits.Text = Convert.ToString(totalNoofunits);
            lblUpdatedUnits.Text = Convert.ToString(TotalUnitsupdated);
            lblTobeUpdatedUnits.Text = Convert.ToString(TotalUnitstobeupdated);

            //lbl_footNoofunitsUpdated.Text = Convert.ToString(TotalUnitsupdated);
            //lbl_footNoofunitsedit.Text = Convert.ToString(TotalUnitsedited);
            //lbl_footNoofProductsUpdated.Text = Convert.ToString(Totalproductsupdated);
            //lbl_footNoofRawMaterials.Text = Convert.ToString(Totalrawmaterialupdated);
            //lbl_footInActiveUnits.Text = Convert.ToString(TotalDeletedunits);
            //lbl_footIEUnitsEdit.Text = Convert.ToString(TotalIEunitsEdited);
        }
    }

    protected void lnk_pdf_Click(object sender, EventArgs e)
    {
        ExportToPDF();
    }
    protected void ExportToPDF()
    {
        this.FillGrid(FromdateforDB, TodateforDB, District);

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=MSMEDistrictWiseReport_MSMESURVEY.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        grdDetails.AllowPaging = false;
        grdDetails.HeaderRow.Visible = true;
        grdDetails.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
    private void Excel_Export()
    {
        string fn = "MSMEDistrictWiseReport_MSMESURVEY";
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fn + ".xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        grdDetails.AllowPaging = false;
        this.FillGrid(FromdateforDB, TodateforDB, District);
        //Change the Header Row back to white color
        grdDetails.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Applying stlye to gridview header cells
        for (int i = 0; i < grdDetails.HeaderRow.Cells.Count; i++)
        {
            grdDetails.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
        }
        grdDetails.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void lnk_excel_Click(object sender, EventArgs e)
    {
        Excel_Export();
    }
}