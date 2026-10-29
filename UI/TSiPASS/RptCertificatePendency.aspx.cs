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
    decimal approveddist, approvedstate, tsipassdist, tsipasstate, tsipasspendingdist, tsipasspendingstate;
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

        ds = Gen.GetDistrictWiseCertificate("%");
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


            decimal approveddist1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dept Approved dist"));
            approveddist = approveddist1 + approveddist;

            decimal approvedstate1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Dept Approved state"));
            approvedstate = approvedstate1 + approvedstate;

            decimal tsipassdist1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "tsipass Approved dist"));
            tsipassdist = tsipassdist1 + tsipassdist;

            decimal tsipasstate1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "tsipass Approved State"));
            tsipasstate = tsipasstate1 + tsipasstate;

            decimal tsipasspendingdist1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending Approved dist"));
            tsipasspendingdist = tsipasspendingdist1 + tsipasspendingdist;


            decimal tsipasspendingstate1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending Approved state"));
            tsipasspendingstate = tsipasspendingstate1 + tsipasspendingstate;




            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];


            if (h1.Text != "0")
            {
                h1.NavigateUrl = "Rptcertstatus.aspx?status=A&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();
            }




            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];


            if (h2.Text != "0")
            {
                h2.NavigateUrl = "Rptcertstatus.aspx?status=B&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();
            }




            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];


            if (h3.Text != "0")
            {
                h3.NavigateUrl = "Rptcertstatus.aspx?status=C&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();
            }

            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];


            if (h4.Text != "0")
            {
                h4.NavigateUrl = "Rptcertstatus.aspx?status=D&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();
            }


            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];


            if (h5.Text != "0")
            {
                h5.NavigateUrl = "Rptcertstatus.aspx?status=E&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();
            }

            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];


            if (h6.Text != "0")
            {
                h6.NavigateUrl = "Rptcertstatus.aspx?status=F&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();
            }


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";

            HyperLink f1 = new HyperLink();


            if (f1.Text != "0")
            {
                f1.NavigateUrl = "Rptcertstatus.aspx?status=A&dist=%";
            }




            HyperLink f2 = new HyperLink();


            if (f2.Text != "0")
            {
                f2.NavigateUrl = "Rptcertstatus.aspx?status=B&dist=%";
            }




            HyperLink f3 = new HyperLink();


            if (f3.Text != "0")
            {
                f3.NavigateUrl = "Rptcertstatus.aspx?status=C&dist=%";
            }

            HyperLink f4 = new HyperLink();


            if (f4.Text != "0")
            {
                f4.NavigateUrl = "Rptcertstatus.aspx?status=D&dist=%";
            }



            HyperLink f5 = new HyperLink();


            if (f5.Text != "0")
            {
                f5.NavigateUrl = "Rptcertstatus.aspx?status=E&dist=%";
            }

            HyperLink f6 = new HyperLink();


            if (f6.Text != "0")
            {
                f6.NavigateUrl = "Rptcertstatus.aspx?status=F&dist=%" ;
            }



            f1.Text = approveddist.ToString();
            f1.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[2].Controls.Add(f1);
            f2.Text = approvedstate.ToString();
            f2.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[3].Controls.Add(f2);
            f3.Text = tsipassdist.ToString();
            f3.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[4].Controls.Add(f3);
            f4.Text = tsipasstate.ToString();
            f4.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[5].Controls.Add(f4);
            f5.Text = tsipasspendingdist.ToString();
            f5.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[6].Controls.Add(f5);
            f6.Text = tsipasspendingstate.ToString();
            f6.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[7].Controls.Add(f6);
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
            tcMergePackage.Text = "Numberof application where all approvals are given";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Number of applications where TSiPASS approval is generated";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Number of Applications where TSiPASS approvals is yet to be generated";
            tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
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
