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
            fillgrid();
        }
    }
    #endregion


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //fillgrid();

        fillgrid();

    }
    void fillgrid()
    {

        ds = Gen.sp_TSIPASSApprovals(ddlCategory.SelectedItem.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
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
            decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NumberOfApplicationsFullyPaid"));
            NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Approved"));
            Completed1 = Completed + Completed1;


            decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "UnderProcess"));
            QueryRaised1 = QueryRaised + QueryRaised1;


            decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Rejected"));
            Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

            decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AverageNumberOfDaysTakenForProcessing"));
            Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h1.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h1.NavigateUrl = "frmstatusDistrictDril.aspx?status=A&districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim() +"&Category="+ddlCategory.SelectedValue;

            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h2.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h2.NavigateUrl = "frmstatusDistrictDril.aspx?status=B&districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim() + "&Category=" + ddlCategory.SelectedValue;


            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h3.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3.NavigateUrl = "frmstatusDistrictDril.aspx?status=C&districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim() + "&Category=" + ddlCategory.SelectedValue;

            HyperLink h3a = (HyperLink)e.Row.Cells[5].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h3a.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h3a.NavigateUrl = "frmstatusDistrictDril.aspx?status=D&districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim() + "&Category=" + ddlCategory.SelectedValue;



            
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = NumberofApprovalsappliedfor1.ToString();
            e.Row.Cells[3].Text = Completed1.ToString();
            e.Row.Cells[4].Text = QueryRaised1.ToString();
            e.Row.Cells[5].Text = Pendinglessthan3days1.ToString();
           // e.Row.Cells[6].Text = Pendingmorthan3days1.ToString();
           // e.Row.Cells[7].Text = Numberofpaymentreceivedfor1.ToString();
        }


       
    }
  

   
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
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
            HeaderCell.Text = "TS-iPASS Approvals";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "";
            HeaderGridRow.Cells.Add(HeaderCell);





            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);




        }
    }
}
