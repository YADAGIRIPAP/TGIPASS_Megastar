using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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

    static DataTable dtMyTable;

    DataRow dtr;
    static DataTable dtMyTablepr;
    static DataTable dtMyTableCertificate;

    DataRow dtrdr1;
    DataTable myDtNewRecdr1 = new DataTable();

    static DataTable dtMyTable1;

    DataRow dtr1;
    static DataTable dtMyTablepr1;
    static DataTable dtMyTableCertificate1;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
           // Response.Redirect("~/Index.aspx");
        }
        if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "0")
        {

            //FillDetails();
            //Failure.Visible = false;
            //success.Visible = false;
            //BtnSave1.Text = "Update";
            ////lblresult.Text = "";
            ////Btnsave.Enabled = true;
            //hdfFlagID.Value = "";
        }

        if (!IsPostBack)
        {


            fillgrid();
            success.Visible = false;
            Failure.Visible = false;
            //    ddlMonth.SelectedIndex = System.DateTime.Now.Month;
            //    ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
            //    ddlMonth.Enabled = false;
            //    ddlYear.Enabled = false;

            //    DataSet dsc = new DataSet();
            //    dsc = Gen.GetCategoryDet();
            //    ddlintLineofActivity.DataSource = dsc.Tables[0];
            //    ddlintLineofActivity.DataValueField = "intLineofActivityid";
            //    ddlintLineofActivity.DataTextField = "LineofActivity_Name";
            //    ddlintLineofActivity.DataBind();
            //    ddlintLineofActivity.Items.Insert(0, "--Select--");
            //    DataSet dsm = new DataSet();
            //    dsm = Gen.GetMandalsForClosedUnits();
            //    if (dsm.Tables[0].Rows.Count > 0)
            //    {
            //        ddlMandal.DataSource = dsm.Tables[0];
            //        ddlMandal.DataValueField = "Mandal_Id";
            //        ddlMandal.DataTextField = "Manda_lName";
            //        ddlMandal.DataBind();
            //        ddlMandal.Items.Insert(0, "--Mandal--");
            //    }
            //    else
            //    {
            //        ddlMandal.Items.Clear();
            //        ddlMandal.Items.Insert(0, "--Mandal--");
            //    }


            //}

            //if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            //{

            //}
        }
    }

    
  


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        
        //if (BtnSave1.Text == "Save")
        //{

        //    int i = 0;

        //    i= Gen.InsertClosedUnits("1",ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlMandal.SelectedValue, TxtNameofUnit.Text, TxtAddressofUnit.Text, TxtDateofCloser.Text, ddlLTHT.SelectedValue, TxtBriefReason.Text, txtRemarks.Text, ddlintLineofActivity.SelectedValue, Session["uid"].ToString());

        //    if (i > 0)
        //    {

        //        lblmsg.Text = "Added Successfully..!";
        //        success.Visible = true;
        //        Failure.Visible = false;
        //        clear();
        //    }

        //}
        //if (BtnSave1.Text == "Update")
        //{

        //    int i = 0;

        //    i = Gen.InsertClosedUnits(hdfID.Value,ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlMandal.SelectedValue, TxtNameofUnit.Text, TxtAddressofUnit.Text, TxtDateofCloser.Text, ddlLTHT.SelectedValue, TxtBriefReason.Text, txtRemarks.Text, ddlintLineofActivity.SelectedValue, Session["uid"].ToString());

        //    if (i > 0)
        //    {

        //        lblmsg.Text = "Updated Successfully..!";
        //        success.Visible = true;
        //        Failure.Visible = false;
        //        clear();
        //    }
        //}


        //}
    }
    //void clear()
    //{
    //    ddlMonth.SelectedIndex = 0; ddlYear.SelectedIndex = 0; ddlMandal.SelectedIndex = 0; TxtNameofUnit.Text = ""; TxtAddressofUnit.Text = ""; TxtDateofCloser.Text = ""; ddlLTHT.SelectedIndex = 0; TxtBriefReason.Text = ""; txtRemarks.Text = ""; ddlintLineofActivity.SelectedIndex = 0;
    //    BtnSave1.Text = "Save";
    //}


   
   // void FillDetails()
    //{

    //    DataSet ds = new DataSet();
    //    try
    //    {

    //        DataSet dsemp = new DataSet();

    //        dsemp = Gen.getUnitClosedDet(hdfID.Value);

    //        if (dsemp.Tables[0].Rows.Count > 0)
    //        {
    //            ddlMonth.SelectedValue = dsemp.Tables[0].Rows[0]["VI_Month"].ToString();
    //            ddlYear.SelectedValue = dsemp.Tables[0].Rows[0]["VI_Year"].ToString();
    //            TxtNameofUnit.Text = dsemp.Tables[0].Rows[0]["NameofUnit"].ToString();
    //            ddlMandal.SelectedValue = dsemp.Tables[0].Rows[0]["Location"].ToString();
    //            TxtAddressofUnit.Text = dsemp.Tables[0].Rows[0]["AddressofUnit"].ToString();
    //            ddlLTHT.SelectedValue = dsemp.Tables[0].Rows[0]["HTLT"].ToString();
    //            TxtDateofCloser.Text = Convert.ToDateTime(dsemp.Tables[0].Rows[0]["DateofCloser"].ToString()).ToString("dd-MM-yyyy");
    //            TxtBriefReason.Text = dsemp.Tables[0].Rows[0]["BriefReason"].ToString();
    //            txtRemarks.Text = dsemp.Tables[0].Rows[0]["OtherRemarks"].ToString();
    //            ddlintLineofActivity.SelectedValue = dsemp.Tables[0].Rows[0]["Line_of_Activity"].ToString();
    //            hdfID.Value = dsemp.Tables[0].Rows[0]["intClosedUnitid"].ToString();
    //            BtnSave1.Text = "Update";
    //        }

           

    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.ToString();
    //    }
    //    finally
    //    {

    //    }
          
    //} 
    
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //clear();

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
    


    //protected void GetNewRectoInsertdr()
    //{
    //    myDtNewRecdr = (DataTable)Session["CertificateTb2"];
    //    DataView dvdr = new DataView(myDtNewRecdr);
    //    //dvdr.RowFilter = "new = 0";
    //    myDtNewRecdr = dvdr.ToTable();
    //}

    protected void GetNewRectoInsertdr1()
    {
        //myDtNewRecdr1 = (DataTable)Session["CertificateTb1"];
        //DataView dvdr1 = new DataView(myDtNewRecdr1);
        ////dvdr1.RowFilter = "new = 0";
        //myDtNewRecdr1 = dvdr1.ToTable();

    }

    protected void gvCertificate0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        //    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        //    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        //}
    }

    
    protected void BtnClear1_Click(object sender, EventArgs e)
    {
        //txtRawItem.Text = "";
        //txtRawQuantity.Text = "";
        //ddlRawQuantityIn.SelectedIndex = 0;
        //ddlRawQuantityPer.SelectedIndex = 0;
        ddlmonth0.SelectedIndex = 0;
        ddlyear0.SelectedIndex = 0;
    }

    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void BtnClear0_Click2(object sender, EventArgs e)
    //{
    //    clear();
    //}
    protected void TxtNameofUnit_TextChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave4_Click(object sender, EventArgs e)
    {
        
        fillgrid();
        // txtUidno0.Text = "";
     //   ddlmonth0.SelectedIndex = 0;
      //  ddlyear0.SelectedIndex = 0;
    }
    void fillgrid()
    {


        DataSet ds = new DataSet();

        //ds = Gen.Searchclosedunitdetails1(Session["uid"].ToString(), ddlmonth0.SelectedValue.ToString(), ddlyear0.SelectedValue.ToString());

        ds = Gen.Searchclosedunitdetails1(Request.QueryString[0].ToString(), Request.QueryString[1].ToString(), Request.QueryString[2].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

            gvCertificate0.DataSource = ds.Tables[0];
            gvCertificate0.DataBind();
            lblmsg.Text = "";
            success.Visible = true;
            Failure.Visible = false;


        }
        else
        {
            success.Visible = false;
            Failure.Visible = true;
            lblmsg0.Text = "No Records found.";
            gvCertificate0.DataSource = null;
            gvCertificate0.DataBind();
        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

