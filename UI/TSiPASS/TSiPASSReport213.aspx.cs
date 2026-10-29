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
        if (!IsPostBack)
        {
           // getIPOS();

            fillgrid();
            success.Visible = false;
            Failure.Visible = false;
        }
        
        if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "0")
        {

           // FillDetails();
           // Failure.Visible = false;
            //success.Visible = false;
           // BtnSave1.Text = "Update";
            //lblresult.Text = "";
            //Btnsave.Enabled = true;
            hdfFlagID.Value = "";
        }
    }

    public void FillDetails()
    {
        //DataSet dsemp = new DataSet();

        //dsemp = Gen.getTsipassreport4(hdfID.Value);

        //if (dsemp.Tables[0].Rows.Count > 0)
        //{
        //    txtUidno.Text = dsemp.Tables[0].Rows[0]["UID_No"].ToString();
        //    txtUnitName.Text = dsemp.Tables[0].Rows[0]["NameofUnit"].ToString();
        //    txtaddressunit.Text = dsemp.Tables[0].Rows[0]["AddressofUnit"].ToString();
        //    txtDDDate.Text =Convert.ToDateTime(dsemp.Tables[0].Rows[0]["DateofApproval"].ToString()).ToString("dd-MM-yyyy");
        //    ddlcstatus.SelectedValue = dsemp.Tables[0].Rows[0]["CurrentStatus"].ToString();
        //    txtremark.Text = dsemp.Tables[0].Rows[0]["Remarks"].ToString();
        //    hdfID.Value = dsemp.Tables[0].Rows[0]["intTSiPASSid"].ToString();
        //    BtnSave1.Text = "Update";
        //}



    }
    protected void getIPOS()
    {
        //DataSet dsnew = new DataSet();
        //dsnew = Gen.GetIPOS(Session["uid"].ToString());

        //ddlIPOname.DataSource = dsnew.Tables[0];
        //ddlIPOname.DataTextField = "Dept_Name";
        //ddlIPOname.DataValueField = "intUserid";
        //ddlIPOname.DataBind();
        //ddlIPOname.Items.Insert(0, "--Select--");
    }


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        fillgrid();
       // txtUidno0.Text = "";
     //   ddlmonth.SelectedIndex = 0;
       // ddlyear.SelectedIndex = 0;
       
    }
    void fillgrid()
    {


        DataSet ds = new DataSet();

        //ds = Gen.Searchdetails1(Session["uid"].ToString(), ddlmonth.SelectedValue.ToString(), ddlyear.SelectedValue.ToString());

        ds = Gen.Searchdetails1(Request.QueryString[0].ToString(),Request.QueryString[1].ToString(),Request.QueryString[2].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            
            gvCertificate0.DataSource = ds.Tables[0];
            gvCertificate0.DataBind();
            lblmsg.Text = "";
//            success.Visible = true;
  //          Failure.Visible = false;


        }
        else
        {
    //        success.Visible = false;
      //      Failure.Visible = true;
            lblmsg0.Text = "No Records found.";
            gvCertificate0.DataSource = null;
            gvCertificate0.DataBind();
        }
    }
          

    void clear()
    {
        
        //txtUnitName.Text="";
        //txtaddressunit.Text="";
        //txtDDDate.Text="";
        //ddlcstatus.SelectedIndex=0;
        //txtremark.Text="";
        

       


    }    
    
    protected void txtRawItem_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

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
    
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //txtUidno0.Text = "";
       // ddlmonth.SelectedIndex = 0;
       // ddlyear.SelectedIndex = 0;
    }



    protected void txtUnitName_TextChanged(object sender, EventArgs e)
    {

    }


    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtUidno_TextChanged(object sender, EventArgs e)
    {
        //DataSet dsemp = new DataSet();

        //dsemp = Gen.getTsipassreportDet(txtUidno.Text);
        //if (dsemp.Tables[0].Rows.Count > 0)
        //{
        //    //txtUidno.Text = dsemp.Tables[0].Rows[0]["UID_No"].ToString();
        //    txtUnitName.Text = dsemp.Tables[0].Rows[0]["nameofunit"].ToString();
        //    txtaddressunit.Text = dsemp.Tables[0].Rows[0]["Address"].ToString();
        //    if (dsemp.Tables[0].Rows[0]["Approval_Date"].ToString() == "" || dsemp.Tables[0].Rows[0]["Approval_Date"].ToString() == "NULL")
        //    {
        //        txtDDDate.Text = "";
        //    }
        //    else
        //    {
        //        txtDDDate.Text = Convert.ToDateTime(dsemp.Tables[0].Rows[0]["Approval_Date"].ToString()).ToString("dd-MM-yyyy");
        //    }
            //ddlcstatus.SelectedValue = dsemp.Tables[0].Rows[0]["CurrentStatus"].ToString();
           // txtremark.Text = dsemp.Tables[0].Rows[0]["Remarks"].ToString();
            //hdfID.Value = dsemp.Tables[0].Rows[0]["intTSiPASSid"].ToString();
            //BtnSave1.Text = "Update";
       // }
    }
}
