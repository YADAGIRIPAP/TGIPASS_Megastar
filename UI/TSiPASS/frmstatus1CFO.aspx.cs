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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["user"] != null && Session["user"] != "")
        //{ }
        //else
        //{
        //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //}
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
            FillGrid();
        }


    }

    //private void getdistricts()
    //{
    //    DataSet dsnew = new DataSet();

    //    dsnew = Gen.GetDistricts();
    //    ddldistrict.DataSource = dsnew.Tables[0];
    //    ddldistrict.DataTextField = "District_Name";
    //    ddldistrict.DataValueField = "District_Id";
    //    ddldistrict.DataBind();
    //    ddldistrict.Items.Insert(0, "--Select--");
    //}


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
    public void FillGrid()
    {
        DataSet ds = new DataSet();
        if (Session["DistrictID"].ToString().Trim() != "")
        {
            ds = Gen.getR1DrildownbyCostCFO(Session["DistrictID"].ToString().Trim());
        }
        else
        {
            ds = Gen.getR1DrildownbyCostCFO("%");
        }
        Label1.Text = "Report as on " + System.DateTime.Now.ToString("dd-MMM-yyyy");
        grdDetails.DataSource = ds.Tables[0];
        grdDetails.DataBind();

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

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

            decimal a1a = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MNo of Units")).Trim());
            a1 = a1a + a1;
            decimal a2a = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MTotal Investment")).Trim());
            a2 = a2a + a2;
            decimal a3a = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LNo of Units")).Trim());
            a3 = a3a + a3;
            decimal a4a = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LTotal Investment")).Trim());
            a4 = a4a + a4;
            decimal a5a = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MeNo of Units")).Trim());
            a5 = a5a + a5;
            decimal a6a = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MeTotal Investment")).Trim());
            a6 = a6a + a6;
            decimal a7a = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SNo of Units")).Trim());
            a7 = a7a + a7;
            decimal a8a = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "STotal Investment")).Trim());
            a8 = a8a + a8;
            decimal a9a = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MiNo of Units")).Trim());
            a9 = a9a + a9;
            decimal a10a = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MiTotal Investment")).Trim());
            a10 = a10a + a10;
            decimal a11a = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TNo of Units")).Trim());
            a11 = a11a + a11;
            decimal a12a = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TTotal Investment")).Trim());
            a12 = a12a + a12;


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[2].Text = a1.ToString();
            e.Row.Cells[3].Text = a2.ToString();
            e.Row.Cells[4].Text = a3.ToString();
            e.Row.Cells[5].Text = a4.ToString();
            e.Row.Cells[6].Text = a5.ToString();
            e.Row.Cells[7].Text = a6.ToString();
            e.Row.Cells[8].Text = a7.ToString();
            e.Row.Cells[9].Text = a8.ToString();
            e.Row.Cells[10].Text = a9.ToString();
            e.Row.Cells[11].Text = a10.ToString();
            e.Row.Cells[12].Text = a11.ToString();
            e.Row.Cells[13].Text = a12.ToString();

        }
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
                if (i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13)
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


            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Mega Units";
            tcMergePackage1.CssClass = "GridviewScrollC1Header";
            tcMergePackage1.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Large Units";
            tcMergePackage2.CssClass = "GridviewScrollC1Header";
            tcMergePackage2.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage2);

            TableCell tcMergePackage3 = new TableCell();
            tcMergePackage3.Text = "Medium Units";
            tcMergePackage3.CssClass = "GridviewScrollC1Header";
            tcMergePackage3.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage3);

            TableCell tcMergePackage4 = new TableCell();
            tcMergePackage4.Text = "Small Units";
            tcMergePackage4.CssClass = "GridviewScrollC1Header";
            tcMergePackage4.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage4);

            TableCell tcMergePackage5 = new TableCell();
            tcMergePackage5.Text = "Micro Units";
            tcMergePackage5.CssClass = "GridviewScrollC1Header";
            tcMergePackage5.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage5);

            TableCell tcMergePackage6 = new TableCell();
            tcMergePackage6.Text = "Total Units";
            tcMergePackage6.CssClass = "GridviewScrollC1Header";
            tcMergePackage6.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage6);


        }
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridView HeaderGrid = (GridView)sender;
        //    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //    TableCell HeaderCell = new TableCell();
        //    HeaderCell = new TableCell();
        //    HeaderCell.ColumnSpan = 2;
        //    HeaderCell.RowSpan = 0;
        //    HeaderCell.Font.Bold = true;
        //    HeaderCell.Text = "";
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.ColumnSpan = 2;
        //    HeaderCell.RowSpan = 0;
        //    HeaderCell.Font.Bold = true;
        //    HeaderCell.Text = "Mega";
        //    HeaderCell.Attributes.Add("class", "GridviewScrollC1Header");
        //    //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

        //    HeaderCell = new TableCell();
        //    HeaderCell.ColumnSpan = 2;
        //    HeaderCell.RowSpan = 0;
        //    HeaderCell.Font.Bold = true;
        //    HeaderCell.Text = "Large";
        //    HeaderCell.Attributes.Add("class", "GridviewScrollC1Header");
        //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

        //    HeaderCell = new TableCell();
        //    HeaderCell.ColumnSpan = 2;
        //    HeaderCell.RowSpan = 0;
        //    HeaderCell.Font.Bold = true;
        //    HeaderCell.Text = "Medium";
        //    HeaderCell.Attributes.Add("class", "GridviewScrollC1Header");
        //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

        //    HeaderCell = new TableCell();
        //    HeaderCell.ColumnSpan = 2;
        //    HeaderCell.RowSpan = 0;
        //    HeaderCell.Font.Bold = true;
        //    HeaderCell.Text = "Small";
        //    HeaderCell.Attributes.Add("class", "GridviewScrollC1Header");
        //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

        //    HeaderCell = new TableCell();
        //    HeaderCell.ColumnSpan = 2;
        //    HeaderCell.RowSpan = 0;
        //    HeaderCell.Font.Bold = true;
        //    HeaderCell.Text = "Micro";
        //    HeaderCell.Attributes.Add("class", "GridviewScrollC1Header");
        //    //HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

        //    HeaderCell = new TableCell();
        //    HeaderCell.ColumnSpan = 2;
        //    HeaderCell.RowSpan = 0;
        //    HeaderCell.Font.Bold = true;
        //    HeaderCell.Text = "Total";
        //    HeaderCell.Attributes.Add("class", "GridviewScrollC1Header");
        //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
        //}
    }

    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++) gr.Cells[cellIndex].CssClass = "GridviewScrollC1HeaderWrap";
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
    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Investment by District wise " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                //grdDetails.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint.RenderControl(hw);
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


}
