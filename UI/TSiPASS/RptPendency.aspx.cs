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

//created by suresh as on 1-17-2016 for county adm lookup 
//tables td_CountyAdmDet,getCASearch

public partial class LookupCA : System.Web.UI.Page
{
    decimal CFEQuery, CFOQuery, CFEPreBeyond, CFOPreBeyond, CFEApprovalBeyond, CFOApprovalBeyond;
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


            fillgrid();
        }
    }
    #endregion


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //fillgrid();

        fillgrid();

    }
    public void fillgrid()
    {

        ds = Gen.GetDeptPendency("%");
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal CFEQuery1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFEQuery"));
            CFEQuery = CFEQuery1 + CFEQuery;

            decimal CFOQuery1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFOQuery"));
            CFOQuery = CFOQuery1 + CFOQuery;

            decimal CFEPreBeyond1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFEPreBeyond"));
            CFEPreBeyond = CFEPreBeyond1 + CFEPreBeyond;

            decimal CFOPreBeyond1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFOPreBeyond"));
            CFOPreBeyond = CFOPreBeyond + CFOPreBeyond1;

            decimal CFEApprovalBeyond1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFEApprovalBeyond"));
            CFEApprovalBeyond = CFEApprovalBeyond + CFEApprovalBeyond1;


            decimal CFOApprovalBeyond1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CFOApprovalBeyond"));
            CFOApprovalBeyond = CFOApprovalBeyond + CFOApprovalBeyond1;





            HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];

           

            if (h1.Text != "0")
            {
                h1.NavigateUrl = "RptPendencyDetailed.aspx?intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
            }




        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = CFEQuery.ToString();
            e.Row.Cells[3].Text = CFOQuery.ToString();

            e.Row.Cells[4].Text = CFEPreBeyond.ToString();
            e.Row.Cells[5].Text = CFOPreBeyond.ToString();
            e.Row.Cells[6].Text = CFEApprovalBeyond.ToString();
            e.Row.Cells[7].Text = CFOApprovalBeyond.ToString();
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
                if (i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7)
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
            tcMergePackage.Text = "Query Raised";
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Pre-Scrutiny (beyond three days)";
            tcMergePackage1.CssClass = "GridviewScrollC1Header";
            tcMergePackage1.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Approvals (beyond Time limits)";
            tcMergePackage2.CssClass = "GridviewScrollC1Header";
            tcMergePackage2.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage2);



           
        }
        
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
            Response.AddHeader("content-disposition", "attachment;filename=Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                div_Print.RenderControl(hw);
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
}
