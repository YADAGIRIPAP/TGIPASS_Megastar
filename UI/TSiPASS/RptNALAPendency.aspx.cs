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
    decimal totalapplied, approved, rejected, query, prewith, prebeyond, approvalwith, approvalBeyond;
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
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }
        if (!IsPostBack)
        {

            getdistricts();
            fillgrid();
        }
    }
    #endregion


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

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //fillgrid();

        fillgrid();

    }
    public void fillgrid()
    {

        ds = Gen.RptNALAAPPROVALSDISTRICTWISE(ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "Report as on date " + System.DateTime.Now.ToString("dd-MMM-yyyy");
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


            decimal totalapplied1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Approvals Applied"));
            totalapplied = totalapplied1 + totalapplied;

            decimal approved1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Approved"));
            approved = approved1 + approved;

            decimal rejected1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Rejected"));
            rejected = rejected1 + rejected;

            decimal query1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Query Raised"));
            query = query1 + query;

            decimal prewith1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PreWith"));
            prewith = prewith1 + prewith;

            decimal prebeyond1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PreBeyond"));
            prebeyond = prebeyond1 + prebeyond;


            decimal approvalwith1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ApprovalWith"));
            approvalwith = approvalwith1 + approvalwith;

            decimal approvalBeyond1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ApprovalBeyond"));
            approvalBeyond = approvalBeyond1 + approvalBeyond;



            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];

            h1.Target = "_blank";

            if (h1.Text != "0")
            {
                h1.NavigateUrl = "frmstatusNala.aspx?status=A&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&Category=" + ddlCategory.SelectedValue;
            }




            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];

            h2.Target = "_blank";

            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmstatusNala.aspx?status=B&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&Category=" + ddlCategory.SelectedValue;
            }




            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];

            h3.Target = "_blank";

            if (h3.Text != "0")
            {
                h3.NavigateUrl = "frmstatusNala.aspx?status=C&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&Category=" + ddlCategory.SelectedValue;
            }

            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];

            h4.Target = "_blank";

            if (h4.Text != "0")
            {
                h4.NavigateUrl = "frmstatusNala.aspx?status=D&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&Category=" + ddlCategory.SelectedValue;
            }


            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];

            h5.Target = "_blank";

            if (h5.Text != "0")
            {
                h5.NavigateUrl = "frmstatusNala.aspx?status=E&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&Category=" + ddlCategory.SelectedValue;
            }

            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];

            h6.Target = "_blank";

            if (h6.Text != "0")
            {
                h6.NavigateUrl = "frmstatusNala.aspx?status=F&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&Category=" + ddlCategory.SelectedValue;
            }

            HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];

            h7.Target = "_blank";

            if (h7.Text != "0")
            {
                h7.NavigateUrl = "frmstatusNala.aspx?status=G&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&Category=" + ddlCategory.SelectedValue;
            }

            HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];

            h8.Target = "_blank";

            if (h8.Text != "0")
            {
                h8.NavigateUrl = "frmstatusNala.aspx?status=H&dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim() + "&Category=" + ddlCategory.SelectedValue;
            }


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";

            HyperLink f1 = new HyperLink();

            f1.Target = "_blank";

            if (f1.Text != "0")
            {
                f1.NavigateUrl = "frmstatusNala.aspx?status=A&dist=%&Category=" + ddlCategory.SelectedValue;
            }




            HyperLink f2 = new HyperLink();

            f2.Target = "_blank";

            if (f2.Text != "0")
            {
                f2.NavigateUrl = "frmstatusNala.aspx?status=B&dist=%&Category=" + ddlCategory.SelectedValue;
            }




            HyperLink f3 = new HyperLink();

            f3.Target = "_blank";

            if (f3.Text != "0")
            {
                f3.NavigateUrl = "frmstatusNala.aspx?status=C&dist=%&Category=" + ddlCategory.SelectedValue;
            }

            HyperLink f4 = new HyperLink();

            f4.Target = "_blank";

            if (f4.Text != "0")
            {
                f4.NavigateUrl = "frmstatusNala.aspx?status=D&dist=%&Category=" + ddlCategory.SelectedValue;
            }



            HyperLink f5 = new HyperLink();

            f5.Target = "_blank";

            if (f5.Text != "0")
            {
                f5.NavigateUrl = "frmstatusNala.aspx?status=E&dist=%&Category=" + ddlCategory.SelectedValue;
            }

            HyperLink f6 = new HyperLink();

            f6.Target = "_blank";

            if (f6.Text != "0")
            {
                f6.NavigateUrl = "frmstatusNala.aspx?status=F&dist=%&Category=" + ddlCategory.SelectedValue;
            }

            HyperLink f7 = new HyperLink();

            f7.Target = "_blank";

            if (f7.Text != "0")
            {
                f7.NavigateUrl = "frmstatusNala.aspx?status=G&dist=%&Category=" + ddlCategory.SelectedValue;
            }

            HyperLink f8 = new HyperLink();

            f8.Target = "_blank";

            if (f8.Text != "0")
            {
                f8.NavigateUrl = "frmstatusNala.aspx?status=H&dist=%&Category=" + ddlCategory.SelectedValue;
            }



            f1.Text = totalapplied.ToString();
            f1.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[2].Controls.Add(f1);
            f2.Text = approved.ToString();
            f2.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[3].Controls.Add(f2);
            f3.Text = rejected.ToString();
            f3.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[4].Controls.Add(f3);
            f4.Text = query.ToString();
            f4.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[5].Controls.Add(f4);
            f5.Text = prewith.ToString();
            f5.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[6].Controls.Add(f5);
            f6.Text = prebeyond.ToString();
            f6.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[7].Controls.Add(f6);
            f7.Text = approvalwith.ToString();
            f7.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[8].Controls.Add(f7);
            f8.Text = approvalBeyond.ToString();
            f8.ForeColor = System.Drawing.Color.White;
            e.Row.Cells[9].Controls.Add(f8);
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
                if (i == 6 || i == 7 || i == 8 || i == 9)
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
            tcMergePackage.Text = "Pre-Scrutiny-Under Process";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Department Approval - Under Process";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage1);



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
