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
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1, Pendinglessthan3daysbeyond1;
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
            Label1.Text = "Report from 01-Apr-2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            getDeptsbyinspetion();
            if (Request.QueryString.Count > 0)
            {
                ddlDept.SelectedValue = ddlDept.Items.FindByValue(Request.QueryString[0].ToString().Trim()).Value;
                ddlDept.Enabled = false;
            }
            if (ddlDept.SelectedValue == "INDUSTRIES")
            {
                lblHeading.Text = Request.QueryString[0].ToString().Trim() + " DEPARTMENT";
            }
            else if (ddlDept.SelectedValue == "PCB")
            {
                lblHeading.Text = Request.QueryString[0].ToString().Trim() + " DEPARTMENT";
            }
            else if (ddlDept.SelectedValue == "FIRE")
            {
                lblHeading.Text = Request.QueryString[0].ToString().Trim() + " AND SAFETY DEPARTMENT";
            }
            else
            {
                lblHeading.Text = Request.QueryString[0].ToString().Trim();
            }
            fillgrid();
        }
        //ds = Gen.FetchInspectionProgressRpt(txtFromDate.Text,txtToDate.Text);INSPECTION PROGRESS REPORT
        //grdDetails.DataSource = ds.Tables[0];
        //grdDetails.DataBind();
    }
    #endregion




    void getDeptsbyinspetion()
    {

        DataSet ds = new DataSet();
        ds = Gen.GetDeptbyinspection();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlDept.DataSource = ds.Tables[0];

            ddlDept.DataTextField = "Department";
            ddlDept.DataValueField = "Department";
            ddlDept.DataBind();
            ddlDept.Items.Insert(0, "--Select--");


        }



    }
    public void fillgrid()
    {

        string fromdate, todate;
        if (txtFromDate.Text.Trim() == "")
        {
            fromdate = "";

        }

        else
        {

            fromdate = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("yyyy-MM-dd");
        }

        if (txtToDate.Text.Trim() == "")
        {
            todate = "";

        }

        else
        {

            todate = Convert.ToDateTime(txtToDate.Text.Trim()).ToString("yyyy-MM-dd");
        }



        DataSet dsnew = new DataSet();

        dsnew = Gen.FetchInspectionProgressRpt(fromdate, todate, ddlDept.SelectedValue.ToString().Trim());

        if (dsnew.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();

        }

        else
        {

            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }


    }




    //protected void BtnSave1_Click(object sender, EventArgs e)
    //{
    //    ds = Gen.FetchInspectionProgressRpt();
    //    grdDetails.DataSource = ds.Tables[0];
    //    grdDetails.DataBind();
    //}

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Performance indicator"));
            NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of Inspections to be conducted"));
            Completed1 = Completed + Completed1;


            decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of Inspections completed"));
            QueryRaised1 = QueryRaised + QueryRaised1;


            decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of inspection reports uploaded within 48 hrs"));
            Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

            decimal Pendinglessthan3daysbeyond = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of inspection reports uploaded beyond 48 hrs"));
            Pendinglessthan3daysbeyond1 = Pendinglessthan3daysbeyond + Pendinglessthan3daysbeyond1;

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];

            string fromdate, Todate;
            if (txtFromDate.Text == "" || txtToDate.Text == "")
            {
                fromdate = "";
                Todate = "";



                //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
                //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
                h1.Target = "_blank";
                //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
                h1.NavigateUrl = "InspectionRptDrillDown.aspx?status=1&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department")).Trim();




                //HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
                ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
                //h2.Target = "_blank";
                ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
                //h2.NavigateUrl = "InspectionRptDrillDown.aspx?status=2&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department")).Trim();



                //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
                //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
                h3.Target = "_blank";
                //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
                h3.NavigateUrl = "InspectionRptDrillDown.aspx?status=2&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department")).Trim();



                //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
                //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
                h4.Target = "_blank";
                //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
                h4.NavigateUrl = "InspectionRptDrillDown.aspx?status=3&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department")).Trim();



                //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
                //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
                h5.Target = "_blank";
                //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
                h5.NavigateUrl = "InspectionRptDrillDown.aspx?status=4&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department")).Trim();

            }
            else
            {

                // fromdate = txtFromDate.Text;
                fromdate = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("yyyy-MM-dd");

                Todate = Convert.ToDateTime(txtToDate.Text.Trim()).ToString("yyyy-MM-dd");

                h1.NavigateUrl = "InspectionRptDrillDown.aspx?status=1&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department")).Trim() + "&FromDate=" + fromdate + "&ToDate=" + Todate;

                h3.NavigateUrl = "InspectionRptDrillDown.aspx?status=2&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department")).Trim() + "&FromDate=" + fromdate + "&ToDate=" + Todate;
                h4.NavigateUrl = "InspectionRptDrillDown.aspx?status=3&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department")).Trim() + "&FromDate=" + fromdate + "&ToDate=" + Todate;

                h5.NavigateUrl = "InspectionRptDrillDown.aspx?status=4&type=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Department")).Trim() + "&FromDate=" + fromdate + "&ToDate=" + Todate;
            }


            //decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendinglessthan3days"));
            //Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


            //decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Numberofpaymentreceivedfor"));
            //Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = NumberofApprovalsappliedfor1.ToString();
            e.Row.Cells[3].Text = Completed1.ToString();
            e.Row.Cells[4].Text = QueryRaised1.ToString();
            e.Row.Cells[5].Text = Pendinglessthan3days1.ToString();

            e.Row.Cells[6].Text = Pendinglessthan3daysbeyond1.ToString();
            //e.Row.Cells[7].Text = Pendingmorthan3days1.ToString();
            //e.Row.Cells[7].Text = Numberofpaymentreceivedfor1.ToString();
        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    { }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("InspectionProgressReport.aspx");
    }
    protected void btnExportToExcel(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename= " + lblHeading.Text + " " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
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
}
