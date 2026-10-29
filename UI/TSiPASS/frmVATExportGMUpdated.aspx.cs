using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
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
    string rstages = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session.Count <= 0)
        {
           // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
       

        if (!IsPostBack)
        {
           
            //GetDetails();
            GetDetailsSearch();
            
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            
        }
    }
    public void GetDetails()
    {

           
               
                DataSet dsn = new DataSet();
                //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
                //return;
                dsn = Gen.GetShowVATExporters(TxtnameofUnit.Text, TxtIECNumber.Text, TxtCommodity.Text, ddlStatus.SelectedValue);
                if (dsn.Tables[0].Rows.Count > 0)
                {
                    
                    grdDetails.DataSource = dsn.Tables[0];
                    grdDetails.DataBind();
                    if (ddlStatus.SelectedIndex == 0)
                    {
                        grdDetails.Columns[11].Visible = false;
                    }
                    else
                    {
                        grdDetails.Columns[11].Visible = true;
                    }

                }
                else
                {
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                }
           

     
    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        GetDetails();

       
    }
    void clear()
    {

        
       
       
    }

    public void GetDetailsSearch()
    {

       

            DataSet dsn = new DataSet();
            //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
            //return;



            dsn = Gen.GetGMExportDetUpdated(TxtnameofUnit.Text, TxtIECNumber.Text, TxtCommodity.Text, ddlStatus.SelectedValue);

            if (dsn.Tables[0].Rows.Count > 0)
            {

                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
                //if (ddlStatus.SelectedIndex == 0)
                //{
                //    grdDetails.Columns[11].Visible = false;
                //}
                //else
                //{
                //    grdDetails.Columns[11].Visible = true;
                //}
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
       



    }

    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        GetDetailsSearch();
      

    }
    void FillDetails()
    {
        
          
    }    
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        
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
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
            
        try
        {

           

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {

        }
    
    }

    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {

      


    }
  
    protected void BtnClear0_Click1(object sender, EventArgs e)
    {
      
    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }



    protected void GetNewRectoInsertdr()
    {
        
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
           
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //HyperLink h1 = (HyperLink)e.Row.Cells[11].Controls[0];

           
           


           
            //h1.NavigateUrl = "ViewCFEPrint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            HyperLink hypFMB = (HyperLink)e.Row.Cells[14].Controls[0];

            if (!Directory.Exists(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Upload_Product_FilePath")).Trim()))
            {
                hypFMB.Text = "No Attachment";
            }
            else
            {
                string sen, sen1, sen2;
                sen2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Upload_Product_FilePath")).Trim();
                sen1 = sen2.Replace(@"\", @"/");
                sen1 = sen1 + "/" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Upload_Product_FileName")).Trim();
                sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");//FMB///VizagFMB/oldsite/
                hypFMB.NavigateUrl = sen;
                hypFMB.Target = "_blank";
                hypFMB.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Upload_Product_FileName")).Trim();
            }







        }




    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList ddlStatus = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");

        Label Label378 = (Label)row.FindControl("Label378");

        TextBox txtAmount = (TextBox)row.FindControl("txtAmount");

        Label Label379 = (Label)row.FindControl("Label379");

        //DropDownList ddlCorporation1 = (DropDownList)row.FindControl("ddlCorporation");
        //DropDownList ddlWard = (DropDownList)row.FindControl("ddlWard");
        //GetWards(ddlWard, ddlCorporation1.SelectedValue);

        ////DropDownList ddlStatus = (DropDownList).FindControl("ddlStatus");
        //Button BtnSave = (Button)sender;
        //GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        //DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
      

        if (ddlStatus.SelectedValue.ToString() == "5")
        {
            txtPromotor.Visible = true;
            Label378.Visible = true;

            Label379.Visible = false;
            txtAmount.Visible = false;
    
        }
        else if (ddlStatus.SelectedValue.ToString() == "7")
        {

            txtPromotor.Visible = true;
            Label378.Visible = true;
            Label379.Visible = true;
            txtAmount.Visible = true;
        }

        else if (ddlStatus.SelectedValue.ToString() == "10")
        {
            txtPromotor.Visible = false;
            Label378.Visible = false;
            Label379.Visible = true;
            txtAmount.Visible = true;
        }
        else
        {
            txtPromotor.Visible = false;
            Label378.Visible = false;
            Label379.Visible = false;
            txtAmount.Visible = false;

        }
       
        // if(ddlStatus.)

        //if()


    }
    //protected void BtnSave_Click1(object sender, EventArgs e)
    //{

    //    Button BtnSave = (Button)sender;

    //    GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
    //    HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");

    //    DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
    //    TextBox txtPromotor=(TextBox)row.FindControl("txtPromotor");

    //    TextBox txtAmount = (TextBox)row.FindControl("txtAmount");

    //    HyperLink h1 = (HyperLink)row.FindControl("h1");

    //    HyperLink h2 = (HyperLink)row.FindControl("h2");

    //    HyperLink h3 = (HyperLink)row.FindControl("h3");

    //    HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
    //    HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
    //    HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");

    //    HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");

    //    HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");


    //    if (ddlStatus.SelectedValue.ToString() == "--Select--")
    //    {
    //        Failure.Visible = true;

    //        success.Visible = false;

    //        lblmsg.Text = "Please Select Status";


    //    }

    //    int result = 0;
    //    result = Gen.insertDepartmentProcess(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value, ddlStatus.SelectedValue.ToString(), hdfGroundedNo2.Value, Session["uid"].ToString().Trim());


    //    if (ddlStatus.SelectedValue.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
    //    {
    //        //HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
    //        //hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();


    //        ////HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");

    //        ////hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();


    //        ////HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");

    //        ////hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();

    //        int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value);

    //        int i = Gen.insertQueryResponsedata(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text, "Y", Session["uid"].ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, hdfApplID.Value);

    //        DataSet dsMail = new DataSet();
    //        dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);

    //        if (dsMail.Tables[0].Rows.Count > 0)
    //        {


    //            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + "  :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
    //        }
    //        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
    //        {
    //            //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thank You.");
    //            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " +  dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() +" : " + Session["user_id"].ToString() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
    //        }
    //        GetDetails();


    //    }
    //    else if (ddlStatus.SelectedValue.ToString() == "7")
    //    {

    //        int i = Gen.insertQueryResponsedata(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text, "Y", Session["uid"].ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, hdfApplID.Value);

    //        int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, txtAmount.Text, "Y", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value);


    //        DataSet dsMail = new DataSet();
    //        dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);

    //        if (dsMail.Tables[0].Rows.Count > 0)
    //        {

    //            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query and requested additional payment on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
    //        }
    //        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
    //        {
    //            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + ": " + Session["user_id"].ToString() + "  has raised a query  and requested additional payment on your application. Please respond to the query  in your login in TS-iPASS. Thank You.");
    //            //cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
    //        }
    //    }
    //    else if(ddlStatus.SelectedValue.ToString()=="10")
    //    {
    //        int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, txtAmount.Text, "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value);


    //        DataSet dsMail = new DataSet();
    //        dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);

    //        if (dsMail.Tables[0].Rows.Count > 0)
    //        {

    //            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
    //        }
    //        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
    //        {
    //            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
    //            //cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
    //        }


    //    }
    //    else if (ddlStatus.SelectedValue.ToString() == "12")
    //    {
    //        int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value);

    //        DataSet dsMail = new DataSet();
    //        dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);

    //        if (dsMail.Tables[0].Rows.Count > 0)
    //        {

    //            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
    //        }
    //        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
    //        {
    //            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
    //          //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
    //        }
    //    }



    //    else if (ddlStatus.SelectedValue.ToString() == "16")
    //    {
    //        int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, "", "Rejected", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value);


    //        DataSet dsMail = new DataSet();
    //        dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);

    //        if (dsMail.Tables[0].Rows.Count > 0)
    //        {

    //            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
    //        }
    //        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
    //        {
    //            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
    //            //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
    //        }

    //    }



    //    if (result > 0)
    //    {

           

           

    //        ddlStatus.SelectedIndex = 0;
    //        txtAmount.Text = "";
    //        txtPromotor.Text = "";


    //        success.Visible = true;
    //        Failure.Visible = false;
    //        lblmsg.Text = "Successfully Registered";


    //    }
    //    else
    //    {

    //        success.Visible = false;
    //        Failure.Visible = true;
    //        lblmsg.Text = "Failed..";


    //    }

    //    GetDetails();

    //    //else if (ddlStatus.SelectedValue.ToString() == "--Select--")
    //    //{
    //    //    Failure.Visible = true;

    //    //    success.Visible = false;

    //    //    lblmsg.Text = "Please Select Status";

            
    //    //}








    //}
}
