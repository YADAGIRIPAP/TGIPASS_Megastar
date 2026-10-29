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
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Numberofpaymentreceivedfor24,Numberofpaymentreceivedfor12, Numberofpaymentreceivedfor22, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1;
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
            //Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            //getdistricts();
            fillgrid();
        }
    }
    #endregion


    void fillgrid()
    {
        DataSet ds = new DataSet();
        ds = Gen.GetRawMaterialsDetails1(Session["DistrictID"].ToString(), txtUdyogNo.Text, ddlStatus.SelectedValue);
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


    
    
 
  
    protected void BtnSave1_Click(object sender, EventArgs e)
    {

        fillgrid();
        //ds = Gen.sp_YearWiseProgress(ddldistrict.SelectedValue, ddlCategory.SelectedValue);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}
        //else
        //{
        //    grdDetails.DataSource = null;
        //    grdDetails.DataBind();
        //}
    }
   
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[11].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            h1.Target = "_blank";
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h1.NavigateUrl = "frmViewAttachmentDetailsRawmaterial.aspx?id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Createdby")).Trim();


        }
        //    decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));
        //    NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

        //    decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending"));
        //    Completed1 = Completed + Completed1;


        //    decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Approved"));
        //    QueryRaised1 = QueryRaised + QueryRaised1;


        //    decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Completed"));
        //    Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

        //    decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Rejected"));
        //    Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


        //    //decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Rejected"));
        //    //Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;

        //    //decimal Numberofpaymentreceivedfor11 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals Pending"));
        //    //Numberofpaymentreceivedfor12 = Numberofpaymentreceivedfor11 + Numberofpaymentreceivedfor12;

        //    //decimal Numberofpaymentreceivedfor21 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals Issued"));
        //    //Numberofpaymentreceivedfor22 = Numberofpaymentreceivedfor21 + Numberofpaymentreceivedfor22;

        //    //decimal Numberofpaymentreceivedfor23 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS-iPASS Approvals"));
        //    //Numberofpaymentreceivedfor24 = Numberofpaymentreceivedfor23 + Numberofpaymentreceivedfor24;



           

        //    //    HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
        //    //    //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
        //    //    //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
        //    //    h1.Target = "_blank";
        //    //    //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
        //    //    h1.NavigateUrl = "frmstatus.aspx?status=A";// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

        //    //    HyperLink h2 = (HyperLink)e.Row.Cells[4].Controls[0];
        //    //    //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
        //    //    //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
        //    //    h2.Target = "_blank";
        //    //    //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
        //    //    h2.NavigateUrl = "frmstatus.aspx?status=B";// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

        //    //    HyperLink h3 = (HyperLink)e.Row.Cells[5].Controls[0];
        //    //    //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
        //    //    //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
        //    //    h3.Target = "_blank";
        //    //    //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
        //    //    h3.NavigateUrl = "frmstatus.aspx?status=C";// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

        //    //    HyperLink h4 = (HyperLink)e.Row.Cells[7].Controls[0];
        //    //    //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
        //    //    //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
        //    //    h4.Target = "_blank";
        //    //    //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
        //    //    h4.NavigateUrl = "frmstatus.aspx?status=D";// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

        //    //    HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
        //    //    //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
        //    //    //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
        //    //    h5.Target = "_blank";
        //    //    //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
        //    //    h5.NavigateUrl = "frmstatus.aspx?status=E";// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

           

            
        //}

        //if (e.Row.RowType == DataControlRowType.Footer)
        //{

        //    e.Row.Cells[1].Text = "Total";
        //    e.Row.Cells[2].Text = NumberofApprovalsappliedfor1.ToString();
        //    e.Row.Cells[3].Text = Completed1.ToString();
        //    e.Row.Cells[4].Text = QueryRaised1.ToString();
        //    e.Row.Cells[5].Text = Pendinglessthan3days1.ToString();
        //    e.Row.Cells[6].Text = Pendingmorthan3days1.ToString();
        //    //e.Row.Cells[7].Text = Numberofpaymentreceivedfor1.ToString();
        //    //e.Row.Cells[8].Text = Numberofpaymentreceivedfor12.ToString();
        //    //e.Row.Cells[9].Text = Numberofpaymentreceivedfor22.ToString();
        //    //e.Row.Cells[10].Text = Numberofpaymentreceivedfor24.ToString();
        //}



        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[11].FindControl("HdfintApplicationid");
            HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID")).Trim();
            DropDownList ddlStatus = (DropDownList)e.Row.Cells[11].FindControl("ddlStatus");
        }

    }



    protected void BtnSaveg_Click(object sender, EventArgs e)
    {
        Button BtnSaveg = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

        HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");

        if (ddlStatus.SelectedIndex == 0)
        {
            lblMsg.Text = "Please Select Status";
        }
        else
        {
           


            int returnValue = Gen.ChangeRawmaterialWiseStatus(HdfintApplicationid.Value, ddlStatus.SelectedValue.ToString().Trim(), Session["uid"].ToString());
            fillgrid();
            lblMsg.Text = "Status Updated";
        }
        //  int returnValue = cnn.ChangestatusAppl(HdfintApplicationid.Value, ddlStatusg.SelectedValue.ToString().Trim(), Session["uid"].ToString());

    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridView HeaderGrid = (GridView)sender;
        //    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //    TableCell HeaderCell = new TableCell();
        //    HeaderCell.ColumnSpan = 1;
        //    HeaderCell.RowSpan = 1;
        //    HeaderCell.Text = "";
        //    HeaderCell.Font.Bold = true;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    HeaderCell = new TableCell();




        //    HeaderCell = new TableCell();
        //    //HeaderCell.Text = "Additions";
        //    HeaderCell.ColumnSpan = 1;
        //    HeaderCell.RowSpan = 1;
        //    HeaderCell.Font.Bold = true;
        //    HeaderCell.Text = "";
        //    HeaderGridRow.Cells.Add(HeaderCell);


        //    HeaderCell = new TableCell();
        //    //HeaderCell.Text = "Additions";
        //    HeaderCell.ColumnSpan = 4;
        //    HeaderCell.RowSpan = 1;
        //    HeaderCell.Font.Bold = true;
        //    HeaderCell.Text = "Consent for Establishment";
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
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
}
