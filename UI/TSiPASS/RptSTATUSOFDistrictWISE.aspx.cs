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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

//created by suresh as on 1-17-2016 for county adm lookup 
//tables td_CountyAdmDet,getCASearch


public partial class LookupCA : System.Web.UI.Page
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
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("../../frmUserLogin.aspx");
        //}
        if (!IsPostBack)
        {

            getdistricts();
            FillGridDetails();
            ///  fillgrid();
        }
    }
    #endregion


    //protected void BtnSave_Click(object sender, EventArgs e)
    //{
    //    fillgrid();
    //}
    //void fillgrid()
    //{

    //    string User = "";
    //    if (Session["user_type"].ToString() == "TST")
    //    {
    //        User = Session["uid"].ToString();
    //    }
    //    else
    //    {
    //        User = "%";
    //    }

    //    DataSet ds = Gen.getCASearch(ddlState.SelectedValue, ddlCounties.SelectedValue,txtca.Text,User);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        lblMsg.Text = ds.Tables[0].Rows.Count.ToString() + " Records found.";
    //        grdDetails.DataSource = ds.Tables[0];
    //        grdDetails.DataBind();
    //    }
    //    else
    //    {
    //        lblMsg.Text = "No Records found.";
    //        grdDetails.DataSource = ds.Tables[0];
    //        grdDetails.DataBind();
    //    }
    //}



    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");
        if (Session["DistrictID"].ToString().Trim() != "")
        {
            ddldistrict.SelectedValue = Session["DistrictID"].ToString().Trim();
            ddldistrict.Enabled = false;
        }
        else
        {
            ddldistrict.Enabled = true;
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ddldistrict.SelectedIndex = 0;
        //  txtRegDate.Text = "";
        ddlCategory.SelectedIndex = 0;

    }

    public void FillGridDetails()
    {
        ds = Gen.sp_DepartmentWiseReport(ddlCategory.SelectedItem.ToString().Trim(), ddldistrict.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
        }
        else
        {
            Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        FillGridDetails();
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NoofapplicationsApplied"));
            NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Completed"));
            Completed1 = Completed + Completed1;


            decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QueryRaised"));
            QueryRaised1 = QueryRaised + QueryRaised1;


            decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending Less than 3 Days"));
            Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

            decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days"));
            Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


            decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of payment received for"));
            Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;
            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h1.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h1.NavigateUrl = "frmstatusDepartmentNext.aspx?status=A&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue;

            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h2.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h2.NavigateUrl = "frmstatusDepartmentNext.aspx?status=B&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue;


            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h3.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3.NavigateUrl = "frmstatusDepartmentNext.aspx?status=C&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue;

            HyperLink h3a = (HyperLink)e.Row.Cells[5].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h3a.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3a.NavigateUrl = "frmstatusDepartmentNext.aspx?status=D&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue;


            HyperLink h3b = (HyperLink)e.Row.Cells[6].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h3b.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3b.NavigateUrl = "frmstatusDepartmentNext.aspx?status=E&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue;

            HyperLink h3bc = (HyperLink)e.Row.Cells[7].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h3bc.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3bc.NavigateUrl = "frmstatusDepartmentNext.aspx?status=F&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue;


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";

            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
            Total.Target = "_blank";
            Total.NavigateUrl = "frmstatusDepartmentNext.aspx?status=A&intDeptid=%"  + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue;
            Total.Text = NumberofApprovalsappliedfor1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[2].Controls.Add(Total);

            HyperLink TotalComp = new HyperLink();
            TotalComp.ForeColor = System.Drawing.Color.White;
            TotalComp.Target = "_blank";
            TotalComp.NavigateUrl = "frmstatusDepartmentNext.aspx?status=B&intDeptid=%" + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue;
            TotalComp.Text = Completed1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[3].Controls.Add(TotalComp);

            HyperLink TotalQuery = new HyperLink();
            TotalQuery.ForeColor = System.Drawing.Color.White;
            TotalQuery.Target = "_blank";
            TotalQuery.NavigateUrl = "frmstatusDepartmentNext.aspx?status=C&intDeptid=%" + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue;
            TotalQuery.Text = QueryRaised1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[4].Controls.Add(TotalQuery);

            HyperLink Totalless3days = new HyperLink();
            Totalless3days.ForeColor = System.Drawing.Color.White;
            Totalless3days.Target = "_blank";
            Totalless3days.NavigateUrl = "frmstatusDepartmentNext.aspx?status=D&intDeptid=%" + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue;
            Totalless3days.Text = Pendinglessthan3days1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[5].Controls.Add(Totalless3days);

            HyperLink TotalMore3days = new HyperLink();
            TotalMore3days.ForeColor = System.Drawing.Color.White;
            TotalMore3days.Target = "_blank";
            TotalMore3days.NavigateUrl = "frmstatusDepartmentNext.aspx?status=E&intDeptid=%" + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue;
            TotalMore3days.Text = Pendingmorthan3days1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[6].Controls.Add(TotalMore3days);

            HyperLink TotalPayment = new HyperLink();
            TotalPayment.ForeColor = System.Drawing.Color.White;
            TotalPayment.Target = "_blank";
            TotalPayment.NavigateUrl = "frmstatusDepartmentNext.aspx?status=F&intDeptid=%" + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue;
            TotalPayment.Text = Numberofpaymentreceivedfor1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[7].Controls.Add(TotalPayment);
            
            //e.Row.Cells[2].Text = NumberofApprovalsappliedfor1.ToString();
           // e.Row.Cells[3].Text = Completed1.ToString();
           // e.Row.Cells[4].Text = QueryRaised1.ToString();
           // e.Row.Cells[5].Text = Pendinglessthan3days1.ToString();
            //e.Row.Cells[6].Text = Pendingmorthan3days1.ToString();
            //e.Row.Cells[7].Text = Numberofpaymentreceivedfor1.ToString();
        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 3 || i == 4 || i == 5 || i == 6)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }

            
            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Prescrutiny Status (Approvals)";
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 4;
            gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage);
        } 
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridView HeaderGrid = (GridView)sender;
        //    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //    TableCell HeaderCell = new TableCell();
        //    HeaderCell.ColumnSpan = 3;
        //    HeaderCell.RowSpan = 1;
        //    HeaderCell.Text = "";
        //    HeaderCell.Font.Bold = true;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    HeaderCell = new TableCell();

        //    HeaderCell = new TableCell();
        //    //HeaderCell.Text = "Additions";
        //    HeaderCell.ColumnSpan = 4;
        //    HeaderCell.RowSpan = 1;
        //    HeaderCell.Font.Bold = true;
        //    HeaderCell.Text = "Prescrutiny Status (Approvals)";
        //    HeaderCell.CssClass = "GRDHEADER";
        //    HeaderCell.ForeColor = System.Drawing.Color.White;
        //    HeaderGridRow.Cells.Add(HeaderCell);


        //    HeaderCell = new TableCell();
        //    //HeaderCell.Text = "Additions";
        //    HeaderCell.ColumnSpan = 1;
        //    HeaderCell.RowSpan = 1;
        //    HeaderCell.Font.Bold = true;
        //    HeaderCell.Text = "";
        //    HeaderGridRow.Cells.Add(HeaderCell);


        //    grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

        //}

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();

    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=R2.1 STATUS OF PRESCRUTINY - DEPARTMENT WISE " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.RenderControl(hw);
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
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    //trLogo.Visible = true;
                    
                    this.FillGridDetails();
                    
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= R2.1 STATUS OF PRESCRUTINY - DEPARTMENT WISE " + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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
    
    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
}
