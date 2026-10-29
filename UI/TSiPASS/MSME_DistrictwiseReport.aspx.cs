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
public partial class UI_TSiPASS_MSME_DistrictwiseReport : System.Web.UI.Page
{
    Cls_MSME Gen = new Cls_MSME();
    string District = null;
    string FromdateforDB = null;
    string TodateforDB = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = "Report as on date " + DateTime.Now;

            if(Request.QueryString.Count>0)
            {
                if (Request.QueryString["DistrictID"] != null && Request.QueryString["DistrictID"] != "")
                {
                    District = Convert.ToString(Request.QueryString["DistrictID"]);
                }
            }
             FillGrid(FromdateforDB,TodateforDB,District);
                      
        }
    }

    
    protected void btnGet_Click(object sender, EventArgs e)
    {
        Failure.Visible = false;
        lblmsg0.Text = "";
        try
        {
            if(txtFromDate.Text == "" && txtFromDate.Text == null && txtTodate.Text == "" && txtTodate.Text == null)
            {
                FillGrid(FromdateforDB, TodateforDB, District);
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
                        FillGrid(FromdateforDB, TodateforDB, District);
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
                        FillGrid(FromdateforDB, TodateforDB, District);
                    }
                }
                 
            }
           
        }
        catch(Exception ex)
        {
            Failure.Visible = true;
            lblmsg0.Text += ex;
           
        }
    }
    private void FillGrid(string FromdateforDB,string TodateforDB, string District)
    {
        DataSet ds = new DataSet();
        grdDetails.DataSource = null;
        grdDetails.DataBind();    
        ds = Gen.MSMEDistrictwiseReport(FromdateforDB, TodateforDB, District);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {        
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
    }

    int totalNoofunits;
    int TotalUnitsupdated;
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
            int Unitsupdated = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Unitsupdated"));
            int Unitsedited = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Unitsedited"));
           
            int productsupdated = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "productsupdated"));
            int rawmaterialupdated = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "rawmaterialupdated"));
            int Deletedunits = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Deletedunits"));
            int IEunitsEdited = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IEunitsEdited"));

            string DistrictID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_id"));
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
                    hyp_noofunits.NavigateUrl = "listofMSMEDistrictwisedetails.aspx?DistrictID=" + DistrictID + "&Status=" + Status + "&District=" + District;
                }
            }

            HyperLink hyp_noofunitsupdated = (HyperLink)e.Row.FindControl("hyp_noofunitsupdated");
            if (!string.IsNullOrEmpty(hyp_noofunitsupdated.Text))
            {
                if (hyp_noofunitsupdated.Text != "0")
                {
                    Status = "Noofunitsupdated";
                    sendingparmeter = DistrictID + "&Status=" + Status;
                   // hyp_noofunitsupdated.NavigateUrl = "javascript:return Popup('" + sendingparmeter + "')";
                    hyp_noofunitsupdated.NavigateUrl = "listofMSMEDistrictwisedetails.aspx?DistrictID=" + DistrictID + "&Status=" + Status + "&District=" + District;
                }
            }
            HyperLink hyp_noofunitsedited = (HyperLink)e.Row.FindControl("hyp_noofunitsedited");
            if (!string.IsNullOrEmpty(hyp_noofunitsedited.Text))
            {
                if (hyp_noofunitsedited.Text != "0")
                {
                    Status = "Noofunitsedited";
                    sendingparmeter = DistrictID + "&Status=" + Status;
                    //hyp_noofunitsedited.NavigateUrl = "javascript:return Popup('" + sendingparmeter + "')";
                    hyp_noofunitsedited.NavigateUrl = "listofMSMEDistrictwisedetails.aspx?DistrictID=" + DistrictID + "&Status=" + Status + "&District=" + District;
                }
            }
            HyperLink hyp_noofunitsproductsupdated = (HyperLink)e.Row.FindControl("hyp_noofunitsproductsupdated");
            if (!string.IsNullOrEmpty(hyp_noofunitsproductsupdated.Text))
            {
                if (hyp_noofunitsproductsupdated.Text != "0")
                {
                    Status = "Noofunitsproductsupdated";
                    sendingparmeter = DistrictID + "&Status=" + Status;
                    //hyp_noofunitsproductsupdated.NavigateUrl = "javascript:return Popup('" + sendingparmeter + "')";
                    hyp_noofunitsproductsupdated.NavigateUrl = "listofMSMEDistrictwisedetails.aspx?DistrictID=" + DistrictID + "&Status=" + Status + "&District=" + District;
                }
            }

            HyperLink hyp_noofunitsrawmaterialupdated = (HyperLink)e.Row.FindControl("hyp_noofunitsrawmaterialupdated");
            if (!string.IsNullOrEmpty(hyp_noofunitsrawmaterialupdated.Text))
            {
                if (hyp_noofunitsrawmaterialupdated.Text != "0")
                {
                    Status = "Noofunitsrawmaterialupdated";
                    sendingparmeter = DistrictID + "&Status=" + Status;
                   // hyp_noofunitsrawmaterialupdated.NavigateUrl = "javascript:return Popup('" + sendingparmeter + "')";
                    hyp_noofunitsrawmaterialupdated.NavigateUrl = "listofMSMEDistrictwisedetails.aspx?DistrictID=" + DistrictID + "&Status=" + Status + "&District=" + District;
                }
            }

            HyperLink hyp_noofDeletedunits = (HyperLink)e.Row.FindControl("hyp_noofDeletedunits");
            if (!string.IsNullOrEmpty(hyp_noofDeletedunits.Text))
            {
                if (hyp_noofDeletedunits.Text != "0")
                {
                    Status = "NoofunitsDeleted";
                    sendingparmeter = DistrictID + "&Status=" + Status;
                    //hyp_noofDeletedunits.NavigateUrl = "javascript:return Popup('" + sendingparmeter + "')";
                    hyp_noofDeletedunits.NavigateUrl = "listofMSMEDistrictwisedetails.aspx?DistrictID=" + DistrictID + "&Status=" + Status + "&District=" + District;
                }
            }

            HyperLink hyp_noofIEunitsEdited = (HyperLink)e.Row.FindControl("hyp_noofIEunitsEdited");
            if (!string.IsNullOrEmpty(hyp_noofIEunitsEdited.Text))
            {
                if (hyp_noofIEunitsEdited.Text != "0")
                {
                    Status = "NoofIEunitsEdited";
                    sendingparmeter = DistrictID + "&Status=" + Status;
                    //hyp_noofDeletedunits.NavigateUrl = "javascript:return Popup('" + sendingparmeter + "')";
                    hyp_noofIEunitsEdited.NavigateUrl = "listofMSMEDistrictwisedetails.aspx?DistrictID=" + DistrictID + "&Status=" + Status + "&District=" + District;
                }
            }

            


            totalNoofunits += Noofunits;
            TotalUnitsupdated += Unitsupdated;
            TotalUnitsedited += Unitsedited;
            Totalproductsupdated += productsupdated;
            Totalrawmaterialupdated += rawmaterialupdated;
            TotalDeletedunits += Deletedunits;
            TotalIEunitsEdited += IEunitsEdited;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {    
            Label lbl_foot_noofunits = (Label)e.Row.FindControl("lbl_foot_noofunits");
            Label lbl_footNoofunitsUpdated = (Label)e.Row.FindControl("lbl_footNoofunitsUpdated");
            Label lbl_footNoofunitsedit = (Label)e.Row.FindControl("lbl_footNoofunitsedit");
            Label lbl_footNoofProductsUpdated = (Label)e.Row.FindControl("lbl_footNoofProductsUpdated");
            Label lbl_footNoofRawMaterials = (Label)e.Row.FindControl("lbl_footNoofRawMaterials");
            Label lbl_footInActiveUnits = (Label)e.Row.FindControl("lbl_footInActiveUnits");
            Label lbl_footIEUnitsEdit = (Label)e.Row.FindControl("lbl_footIEUnitsEdit");
            
            lbl_foot_noofunits.Text = Convert.ToString(totalNoofunits);
            lbl_footNoofunitsUpdated.Text = Convert.ToString(TotalUnitsupdated);
            lbl_footNoofunitsedit.Text = Convert.ToString(TotalUnitsedited);
            lbl_footNoofProductsUpdated.Text = Convert.ToString(Totalproductsupdated);
            lbl_footNoofRawMaterials.Text = Convert.ToString(Totalrawmaterialupdated);
            lbl_footInActiveUnits.Text = Convert.ToString(TotalDeletedunits);
            lbl_footIEUnitsEdit.Text = Convert.ToString(TotalIEunitsEdited);
        }
    }

    protected void lnk_pdf_Click(object sender, EventArgs e)
    {
        ExportToPDF();
    }
    protected void ExportToPDF()
    {
        this.FillGrid(FromdateforDB,TodateforDB,District);

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=MSMEDistrictWiseReport.pdf");
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
        string fn = "MSMEDistrictWiseReport";
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