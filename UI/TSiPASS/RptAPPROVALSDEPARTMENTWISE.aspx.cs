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
    decimal NumberofApprovalsappliedfor1,payment1, Completed1, Pendinglessthan3days1, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1, BeyondTimelimits1;
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
            Response.Redirect("~/Index.aspx");
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

        ds = Gen.RptAPPROVALSBYDEPARTMENTWISE(ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue);
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
    protected void BtnClear_Click(object sender, EventArgs e)
    {
         ddlCategory.SelectedIndex = 0;
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
         if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NumberofApprovalsappliedfor"));
            NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            decimal payment = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Prescrutiny Completed Payment Made"));
            payment1 = payment + payment1;

            decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Completed"));
            Completed1 = Completed + Completed1;


            decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "UnderProcess"));
            QueryRaised1 = QueryRaised + QueryRaised1;


            decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Rejected"));
            Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

            decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WithinTimelimits"));
            Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


            decimal BeyondTimelimits = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BeyondTimelimits"));
            BeyondTimelimits1 = BeyondTimelimits + BeyondTimelimits1;


            HyperLink h1 = (HyperLink)e.Row.Cells[3].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=A&intApprovalid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalId")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();
            }

            HyperLink h2 = (HyperLink)e.Row.Cells[5].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=B&intApprovalid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalId")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();
            }

            HyperLink h3 = (HyperLink)e.Row.Cells[6].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=C&intApprovalid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalId")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();
            }
            HyperLink h3a = (HyperLink)e.Row.Cells[7].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            if (h3a.Text != "0")
            {
                h3a.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=D&intApprovalid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalId")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();
            }
            HyperLink h3ab = (HyperLink)e.Row.Cells[8].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            if (h3ab.Text != "0")
            {
                h3ab.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=E&intApprovalid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalId")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();
            }

            HyperLink h3ac = (HyperLink)e.Row.Cells[9].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            if (h3ac.Text != "0")
            {
                h3ac.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=F&intApprovalid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalId")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();
            }

            HyperLink h4 = (HyperLink)e.Row.Cells[4].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=G&intApprovalid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalId")).Trim() + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();
            }
            
            
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";

            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
            
            Total.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=A&intApprovalid=%" + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=%" ;
            Total.Text = NumberofApprovalsappliedfor1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[3].Controls.Add(Total);

            HyperLink Totalpayment = new HyperLink();
            Totalpayment.ForeColor = System.Drawing.Color.White;
            
            Totalpayment.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=G&intApprovalid=%" + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=%";
            Totalpayment.Text = payment1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[4].Controls.Add(Totalpayment);

            HyperLink TotalComp = new HyperLink();
            TotalComp.ForeColor = System.Drawing.Color.White;
            
            TotalComp.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=B&intApprovalid=%" + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=%";
            TotalComp.Text = Completed1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[5].Controls.Add(TotalComp);

            HyperLink TotalQuery = new HyperLink();
            TotalQuery.ForeColor = System.Drawing.Color.White;
            
            TotalQuery.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=C&intApprovalid=%" + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=%";
            TotalQuery.Text = QueryRaised1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[6].Controls.Add(TotalQuery);

            HyperLink TotalReject = new HyperLink();
            TotalReject.ForeColor = System.Drawing.Color.White;
            
            TotalReject.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=D&intApprovalid=%" + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=%";
            TotalReject.Text = Pendinglessthan3days1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[7].Controls.Add(TotalReject);

            HyperLink Totalmorthan3days = new HyperLink();
            Totalmorthan3days.ForeColor = System.Drawing.Color.White;
            
            Totalmorthan3days.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=E&intApprovalid=%" + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=%";
            Totalmorthan3days.Text = Pendingmorthan3days1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[8].Controls.Add(Totalmorthan3days);

            HyperLink TotalBeyond3days = new HyperLink();
            TotalBeyond3days.ForeColor = System.Drawing.Color.White;
            
            TotalBeyond3days.NavigateUrl = "frmstatusDepartmentApprovalNext.aspx?status=F&intApprovalid=%" + "&Category=" + ddlCategory.SelectedValue + "&Districtid=" + ddldistrict.SelectedValue + "&intDeptid=%";
            TotalBeyond3days.Text = BeyondTimelimits1.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[9].Controls.Add(TotalBeyond3days);


            //e.Row.Cells[3].Text = NumberofApprovalsappliedfor1.ToString();
            //e.Row.Cells[4].Text = payment1.ToString();
            //e.Row.Cells[5].Text = Completed1.ToString();
            //e.Row.Cells[6].Text = QueryRaised1.ToString();
            //e.Row.Cells[7].Text = Pendinglessthan3days1.ToString();
            //e.Row.Cells[8].Text = Pendingmorthan3days1.ToString();
            //e.Row.Cells[9].Text = BeyondTimelimits1.ToString();
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
                if (i == 5 || i == 6 || i == 7 )
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
            tcMergePackage.Text = "Department Approvals";
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage);
        } 
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridView HeaderGrid = (GridView)sender;
        //    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //    TableCell HeaderCell = new TableCell();
        //    HeaderCell.ColumnSpan = 5;
        //    HeaderCell.RowSpan = 1;
        //    HeaderCell.Text = "";
        //    HeaderCell.Font.Bold = true;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    HeaderCell = new TableCell();


        //    HeaderCell = new TableCell();
        //    //HeaderCell.Text = "Additions";
        //    HeaderCell.ColumnSpan =3;
        //    HeaderCell.RowSpan = 1;
        //    HeaderCell.Font.Bold = true;
        //    HeaderCell.Text = "DEPARTMENT APPROVALS";
        //    HeaderCell.CssClass = "GRDHEADER";
        //    HeaderCell.ForeColor = System.Drawing.Color.White;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Additions";
        //    HeaderCell.ColumnSpan = 2;
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
