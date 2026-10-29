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
//Created by Srikanht on 14-08-2013
//Stored Procedure:sp_getFreezependingBatch,
// Tables Used: tblBatch_details,tblPIA,tblProjectDet,tblTrngCentre,tblTrade,tblSector
//Created by Srikanht on 14-08-2013
//Modified  by Srikanht on 14-08-2013
//Modifeid Stored Procedure:sp_getFreezependingBatch,
// Tables Used: tblBatch_details,tblPIA,tblProjectDet,tblTrngCentre,tblTrade,tblSector
// For: Include Status also
//MOdified by Srikanht on 14-08-2013
public partial class DepartmentAndCategoryWiseReport : System.Web.UI.Page
{
   // common cmn = new common();
    General gen = new General();
    General Gen = new General();
    int Sno = 0;
    
    DataSet ds;
    DataTable dt;

    decimal NumberofApplicationsReceived1, Completed1, QueryRaised1, Pendinglessthan3days1, Pendingmorethan3days1;
    DataSet dslist;
    
    public string DisableTheButton(Control pge, Control btn, string vldGroup)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("if (typeof(Page_ClientValidate) == 'function') {");
        if (vldGroup.Trim() == "")
        {
            sb.Append("if (Page_ClientValidate() == false) { return false; }} ");
        }
        else
        {
            sb.Append("if (Page_ClientValidate('" + vldGroup + "') == false) { return false; }} ");

        }
        sb.Append("this.value = 'Please wait...';");
        sb.Append("this.disabled = true;");
        sb.Append(pge.Page.GetPostBackEventReference(btn));
        //sb.Append(pge.Page.GetPostBackEventReference(btn));
        sb.Append(";");
        return sb.ToString();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("frmUserLogin.aspx");
        //}

        if (!IsPostBack)
        {
          //  fillgrid();
            
            this.BtnBatchsave0.Attributes.Add("onclick", DisableTheButton(this.Page, this.BtnBatchsave0, "group"));
            DataSet dsd = new DataSet();
            dsd = Gen.GetDepartment();
            ddlDepartment.DataSource = dsd.Tables[0];
            ddlDepartment.DataValueField = "Dept_Id";
            ddlDepartment.DataTextField = "Dept_Name";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, "ALL");

            fillgrid();



        }
    }
    public void fillgrid()
    {

        string fromdate, todate;
        if (txtFromDate.Text.Trim() == "")
        {
            fromdate = Convert.ToDateTime("01/03/2016").ToString("yyyy-MM-dd"); 

        }

        else
        {

            fromdate = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("yyyy-MM-dd");
        }

        if (txtToDate.Text.Trim() == "")
        {
            todate = Convert.ToDateTime(System.DateTime.Now).ToString("yyyy-MM-dd"); 

        }

        else
        {

            todate = Convert.ToDateTime(txtToDate.Text.Trim()).ToString("yyyy-MM-dd");
        }




        ds = Gen.sp_GetReport(ddlDepartment.SelectedValue, ddlCategory.SelectedValue, fromdate, todate);
        if (ds.Tables[0].Rows.Count > 0)
        {
           
            grdtraineedetails.DataSource = ds.Tables[0];
            grdtraineedetails.DataBind();

        }

        else
        {

            grdtraineedetails.DataSource = null;
            grdtraineedetails.DataBind();
        }


    }
    
    protected void BtnBatchsave0_Click(object sender, EventArgs e)
    {

        fillgrid();
        
        
    }

    public void Clear()
    {
        ddlDepartment.SelectedIndex = 0;
       // txtRegDate.Text = "";
        ddlCategory.SelectedIndex = 0;
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Clear();
    }
  
    protected void grdtraineedetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal ApplicationsReceived = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NumberofApplicationsReceived"));
            NumberofApplicationsReceived1 = ApplicationsReceived + NumberofApplicationsReceived1;
            
            decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Completed"));
            Completed1 = Completed + Completed1;

            decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QueryRaised"));
            QueryRaised1 = QueryRaised + QueryRaised1;

            decimal lessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendinglessthan3days"));
            Pendinglessthan3days1 = lessthan3days + Pendinglessthan3days1;

            decimal morethan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendingmorethan3days"));
            Pendingmorethan3days1 = morethan3days + Pendingmorethan3days1;

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h1.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h1.NavigateUrl = "frmstatusDistrict.aspx?status=A&districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h2.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h2.NavigateUrl = "frmstatusDistrict.aspx?status=B&districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();


            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h3.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3.NavigateUrl = "frmstatusDistrict.aspx?status=C&districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

            HyperLink h3a = (HyperLink)e.Row.Cells[5].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h3a.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3a.NavigateUrl = "frmstatusDistrict.aspx?status=D&districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();


            HyperLink h3b = (HyperLink)e.Row.Cells[6].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h3b.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3b.NavigateUrl = "frmstatusDistrict.aspx?status=E&districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();
            
            
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = NumberofApplicationsReceived1.ToString();
            e.Row.Cells[3].Text = Completed1.ToString();
            e.Row.Cells[4].Text = QueryRaised1.ToString();
            e.Row.Cells[5].Text = Pendinglessthan3days1.ToString();
            e.Row.Cells[6].Text = Pendingmorethan3days1.ToString();
        }
    }
    protected void grdtraineedetails_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void grdtraineedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdtraineedetails.DataSource = null;
        grdtraineedetails.DataBind();
        lblmsg.Text = "";
    }
    protected void grdtraineedetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 1;
            HeaderCell.Text = "";
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();


             HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 1;
            HeaderCell.Text = "";
          
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();



            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "";
            HeaderGridRow.Cells.Add(HeaderCell);


            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 4;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "Prescrutiny Status Of CAF";
            HeaderGridRow.Cells.Add(HeaderCell);
            grdtraineedetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }



    }
    protected void grdtraineedetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  
}