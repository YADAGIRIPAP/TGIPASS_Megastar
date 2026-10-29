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
            fillgrid();
        }
        
    }
    #endregion

    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddlConnectLoad.DataSource = dsnew.Tables[0];
        ddlConnectLoad.DataTextField = "District_Name";
        ddlConnectLoad.DataValueField = "District_Name";
        ddlConnectLoad.DataBind();
        ddlConnectLoad.Items.Insert(0, "--Select--");
    }
    public void fillgrid()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.getdataofStatelevel(ddlConnectLoad.SelectedItem.Text.ToString(), ddlYear.SelectedValue);
        lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();

            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();


        }
        else
        {
            lblMsg.Text = "";

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
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Performance indicator"));
        //    NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

        //    decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of Inspections to be conducted"));
        //    Completed1 = Completed + Completed1;


        //    decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of Inspections completed"));
        //    QueryRaised1 = QueryRaised + QueryRaised1;


        //    decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of inspection reports uploaded within 48 hrs"));
        //    Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

        //    //decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendinglessthan3days"));
        //    //Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


        //    //decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Numberofpaymentreceivedfor"));
        //    //Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;

            
        //}

        //if (e.Row.RowType == DataControlRowType.Footer)
        //{

        //    e.Row.Cells[1].Text = "Total";
        //    e.Row.Cells[2].Text = NumberofApprovalsappliedfor1.ToString();
        //    e.Row.Cells[3].Text = Completed1.ToString();
        //    e.Row.Cells[4].Text = QueryRaised1.ToString();
        //    e.Row.Cells[5].Text = Pendinglessthan3days1.ToString();
        //    //e.Row.Cells[7].Text = Pendingmorthan3days1.ToString();
        //    //e.Row.Cells[7].Text = Numberofpaymentreceivedfor1.ToString();
        //}
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
        grdDetails.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    { }
    
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("StateLevelwiseReport.aspx");

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
                divPrint.RenderControl(hw);
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
