using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Org.BouncyCastle.Asn1.Ocsp;
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
    CFOWebServices CFosenddata = new CFOWebServices();
    string rstages = "0";
    FactoryServiceCFO.TSFactoryServiceImplService factorycfo = new FactoryServiceCFO.TSFactoryServiceImplService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            GetDetails();
        }
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
        }
    }
    public void GetDetails()
    {
        if (Request.QueryString.Count > 0)
        {
            rstages = Request.QueryString[0].ToString().Trim();
            DataSet dsn = new DataSet();
            //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
            //return;
            dsn = Gen.GetShowDepartmentFilesCFO(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());
            if (dsn.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();

                if (Session["uid"].ToString().Trim() == "1021")
                {
                    grdDetails.Columns[20].Visible = true;
                    grdDetails.Columns[21].Visible = true;
                    grdDetails.Columns[22].Visible = true;
                }
                else
                {
                    grdDetails.Columns[20].Visible = false;
                    grdDetails.Columns[21].Visible = false;
                    grdDetails.Columns[22].Visible = false;
                }

            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }

        }
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString[0].ToString().Trim() == "5" || Request.QueryString[0].ToString().Trim() == "6")
            {
            }
            else
            {
                // grdDetails.Columns[10].Visible = false;
                //grdDetails.Columns[11].Visible = false;
                grdDetails.Columns[11].Visible = false;
                grdDetails.Columns[12].Visible = false;
            }
        }
        else
        {
            //grdDetails.Columns[10].Visible = false;
            //grdDetails.Columns[11].Visible = false;
            grdDetails.Columns[11].Visible = false;
            grdDetails.Columns[12].Visible = false;
        }
        if (Request.QueryString[0].ToString().Trim() == "17")
        {
            grdDetails.Columns[23].Visible = true;
            grdDetails.Columns[13].Visible = false;
        }
        if (Request.QueryString[0].ToString().Trim() == "5"|| Request.QueryString[0].ToString().Trim() == "6")
        {
            grdDetails.Columns[13].Visible = true;
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
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlStatus1 = (DropDownList)e.Row.Cells[12].FindControl("ddlStatus");
            if (e.Row.Cells[19].Text.Trim() == "Y")
            {
                if (Session["User_Code"].ToString().Trim() == "3")
                {
                    e.Row.Cells[19].Text = "Please process this application in TS-iPASS portal";
                    ddlStatus1.Enabled = true;
                }
                else
                {
                    e.Row.Cells[19].Text = "Please process this application in Concerned Department portal";
                    e.Row.Cells[19].Font.Bold = true;
                    ddlStatus1.Enabled = false;
                }
               
            }
            else
            {
                e.Row.Cells[19].Text = "Please process this application in TS-iPASS portal";
                ddlStatus1.Enabled = true;
            }

            HyperLink h1 = (HyperLink)e.Row.Cells[9].Controls[0];
            HyperLink h2 = (HyperLink)e.Row.Cells[10].Controls[0];
            HyperLink h3 = (HyperLink)e.Row.Cells[11].Controls[0];
            h1.Target = "_blank";
            h1.NavigateUrl = "ViewCFOPrint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
            h2.Target = "_blank";
            h2.NavigateUrl = "frmViewAttachmentDetailsCFO.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
            h3.Target = "_blank";
            h3.NavigateUrl = "frmQurieResponseStatusCFO.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
            DropDownList ddlStatus = (DropDownList)e.Row.Cells[12].FindControl("ddlStatus");
            TextBox txtPromotor = (TextBox)e.Row.Cells[12].FindControl("txtPromotor");
            Label Label378 = (Label)e.Row.Cells[12].FindControl("Label378");
            Label Label379 = (Label)e.Row.Cells[12].FindControl("Label379");
            Label LabelDiscription = (Label)e.Row.Cells[12].FindControl("LabelDiscription");
            TextBox txtAmount = (TextBox)e.Row.Cells[12].FindControl("txtAmount");
            HiddenField hdfApplID = (HiddenField)e.Row.Cells[13].FindControl("hdfApplID");
            hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireCFOid")).Trim();
            HiddenField hdfGroundedNo = (HiddenField)e.Row.Cells[13].FindControl("hdfGroundedNo");
            hdfGroundedNo.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
            HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[13].FindControl("hdfGroundedNo0");
            hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
            HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[13].FindControl("hdfGroundedNo1");
            hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
            HiddenField hdfGroundedNo2 = (HiddenField)e.Row.Cells[13].FindControl("hdfGroundedNo2");
            hdfGroundedNo2.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LastDateofPreScrutiy")).Trim();
            HiddenField hdfGroundedNo3 = (HiddenField)e.Row.Cells[13].FindControl("hdfGroundedNo3");
            DataSet dsquery = new DataSet();
            dsquery = Gen.GetQueryRaisedCFOOneTime(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value);
            if (dsquery.Tables[0].Rows.Count > 0)
            {
                ddlStatus.Items.RemoveAt(2);
            }
            //DataSet dsverify = new DataSet();
            //dsverify = Gen.GetdeptbyCFOstageID(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value);
            //if (dsverify.Tables[0].Rows.Count > 0)
            //{
            //    ddlStatus.Items.RemoveAt(3);
            //}
            //hdfGroundedNo3.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStatusid")).Trim();
            //if (ddlStatus.SelectedValue.ToString() == "8")
            //{
            //    txtPromotor.Visible = true;
            //    Label378.Visible = true;
            //}
            //else
            //{
            //    txtPromotor.Visible = false;
            //    Label378.Visible = false;
            //}
            HyperLink h4 = (HyperLink)e.Row.Cells[18].Controls[0];
            h4.Target = "_blank";
            h4.NavigateUrl = "RptPaymentDetailsCFO.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
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
        Label LabelDiscription = (Label)row.FindControl("LabelDiscription");
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
            LabelDiscription.Visible = false;
        }
        else if (ddlStatus.SelectedValue.ToString() == "16")
        {
            txtPromotor.Visible = true;
            Label378.Visible = true;

            LabelDiscription.Visible = true;

            LabelDiscription.Text = "Please Mention on which act or rule,you are Rejecting?";

            Label378.Text = "Reason For Rejection";

            Label379.Visible = false;
            txtAmount.Visible = false;
        }
        else if (ddlStatus.SelectedValue.ToString() == "7")
        {
            txtPromotor.Visible = true;
            Label378.Visible = true;
            Label379.Visible = true;
            txtAmount.Visible = true;
            LabelDiscription.Visible = false;
        }
        else if (ddlStatus.SelectedValue.ToString() == "11")
        {
            txtPromotor.Visible = false;
            Label378.Visible = false;
            Label379.Visible = true;
            txtAmount.Visible = true;
            LabelDiscription.Visible = false;
        }
        else
        {
            txtPromotor.Visible = false;
            Label378.Visible = false;
            Label379.Visible = false;
            txtAmount.Visible = false;
            LabelDiscription.Visible = false;
        }
        // if(ddlStatus.)
        //if()
    }
    protected void BtnSave_Click1(object sender, EventArgs e)
    {
        Button BtnSave = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");
        TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
        HyperLink h1 = (HyperLink)row.FindControl("h1");
        HyperLink h2 = (HyperLink)row.FindControl("h2");
        HyperLink h3 = (HyperLink)row.FindControl("h3");
        HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
        HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
        HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");
        HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");
        HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");
        if (ddlStatus.SelectedValue.ToString() == "--Select--")
        {
            Failure.Visible = true;
            success.Visible = false;
            lblmsg.Text = "Please Select Status";
        }
        int result = 0;
        result = Gen.insertDepartmentProcessCFO(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value, ddlStatus.SelectedValue.ToString(), hdfGroundedNo2.Value, Session["uid"].ToString().Trim());
        if (ddlStatus.SelectedValue.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
        {
            //HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
            //hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
            ////HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");
            ////hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
            ////HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");
            ////hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
            if (txtPromotor.Text == "")
            {
                lblmsg.Text = "Please Enter Query Description";
            }
            else
            {
                int j = Gen.UpdateAdditionalpaymentsCFO(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
                int i = Gen.insertQueryResponsedataCFO(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text, "Y", Session["uid"].ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, hdfApplID.Value);
                try
                {
                    int k = Gen.InsertDeptDateTracingCFO(hdfGroundedNo0.Value, hdfApplID.Value, "", null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "CFO", hdfGroundedNo1.Value);
                }
                catch (Exception ex)
                {

                }
                DataSet dsMail = new DataSet();
                dsMail = Gen.GetShowEmailidandMobileNumberCFO(hdfApplID.Value);
                if (dsMail.Tables[0].Rows.Count > 0)
                {
                    cmf.SendMailTSiPASSCFO(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + ":<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                }
                if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + ": " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                    //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                }
                if (i > 0)
                {
                    GetDetails();
                }
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "7")
        {
            int i = Gen.insertQueryResponsedataCFO(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text, "Y", Session["uid"].ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, hdfApplID.Value);
            int j = Gen.UpdateAdditionalpaymentsCFO(hdfGroundedNo.Value, txtAmount.Text, "Y", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumberCFO(hdfApplID.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                cmf.SendMailTSiPASSCFO(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + ":<br/><br/> <b> " + Session["user_id"].ToString() + " has raised a query and requested additional payment on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + " has raised a query and requested additional payment on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "11")
        {
           // if (txtAmount.Text == "" || txtAmount.Text == null || txtAmount.Text == "0"|| txtAmount.Text == "0")
                if(string.IsNullOrWhiteSpace(txtAmount.Text) || txtAmount.Text == "" || txtAmount.Text == null || Convert.ToDecimal(txtAmount.Text) == 0)
            {
                success.Visible = false;
                Failure.Visible = true;
                lblmsg0.Text = "Please Enter Amount";
                return;
            }
                else
            {

            
            int j = Gen.UpdateAdditionalpaymentsCFO(hdfGroundedNo.Value, txtAmount.Text, "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
            try
            {
                int k = Gen.InsertDeptDateTracingCFO(hdfGroundedNo0.Value, hdfApplID.Value, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", hdfGroundedNo1.Value);
            }
            catch (Exception ex)
            {

            }
            }
            //DataSet dsMail = new DataSet();
            //dsMail = Gen.GetShowEmailidandMobileNumberCFO(hdfApplID.Value);
            //if (dsMail.Tables[0].Rows.Count > 0)
            //{
            //    cmf.SendMailTSiPASSCFO(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            //}
            //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            //{
            //    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() +" : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            //    //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            //}
        }
        else if (ddlStatus.SelectedValue.ToString() == "12")
        {
            int j = Gen.UpdateAdditionalpaymentsCFO(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
            try
            {
                int k = Gen.InsertDeptDateTracingCFO(hdfGroundedNo0.Value, hdfApplID.Value, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", hdfGroundedNo1.Value);
            }
            catch (Exception ex)
            {

            }
            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumberCFO(hdfApplID.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                cmf.SendMailTSiPASSCFO(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "16")
        {
            int j = Gen.UpdateAdditionalpaymentsBeforePreCFO(hdfGroundedNo.Value, "", "Rejected", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, txtPromotor.Text, getclientIP());
            try
            {
                int k = Gen.InsertDeptDateTracingCFO(hdfGroundedNo0.Value, hdfApplID.Value, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", hdfGroundedNo1.Value);
            }
            catch (Exception ex)
            {

            }
            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumberCFO(hdfApplID.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                cmf.SendMailTSiPASSCFO(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has Rejected your application. Please login to TS-iPASS Appeal for Rejection. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + ": " + Session["user_id"].ToString() + "  has Rejected your application. Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
        }
        if (result > 0)
        {
            ddlStatus.SelectedIndex = 0;
            txtAmount.Text = "";
            txtPromotor.Text = "";
            success.Visible = true;
            Failure.Visible = false;
            lblmsg.Text = "Successfully Registered";
        }
        else
        {
            success.Visible = false;
            Failure.Visible = true;
            lblmsg.Text = "Failed..";
        }
        GetDetails();
        //else if (ddlStatus.SelectedValue.ToString() == "--Select--")
        //{
        //    Failure.Visible = true;
        //    success.Visible = false;
        //    lblmsg.Text = "Please Select Status";
        //}
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }
    protected void BtnRevoke_Click(object sender, EventArgs e)
    {
        try
        {
            Button BtnSave = (Button)sender;
            GridViewRow row = (GridViewRow)BtnSave.NamingContainer;

            HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
            TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
            HyperLink h1 = (HyperLink)row.FindControl("h1");
            HyperLink h2 = (HyperLink)row.FindControl("h2");
            HyperLink h3 = (HyperLink)row.FindControl("h3");
            HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
            HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
            HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");
            HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");
            HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");

            LinkButton lnkuidno = (LinkButton)row.FindControl("LinkButton1");

            //HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
            //hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
            ////HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");
            ////hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
            ////HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");
            ////hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
            int j = Gen.UpdatetAppealApprovalnewCFO(hdfGroundedNo.Value, "Revoked", Session["uid"].ToString(), "16", hdfGroundedNo0.Value, hdfGroundedNo1.Value);

            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                //cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has Revoked your application. Thank You.");
                cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> Industries Department  has Revoked your application. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                //cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has Revoked your application. Thank You.");
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : Industries Department  has Revoked your application. Thank You.");
                //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                //}

                if (j > 0)
                {
                    success.Visible = true;
                    Failure.Visible = false;
                    lblmsg.Text = "Successfully Updated";
                }
                else
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg.Text = "Failed..";
                }
                GetDetails();
                //else if (ddlStatus.SelectedValue.ToString() == "--Select--")
                //{
                //    Failure.Visible = true;
                //    success.Visible = false;
                //    lblmsg.Text = "Please Select Status";

                //}

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                string UIDNO = lnkuidno.Text;// "MEG01500315533 ";//
                                             //  ds = Gen.GetDepartmentonuidCFO(UIDNO);
                CFosenddata.webservicecfo(UIDNO);

                /*  if (ds != null && ds.Tables.Count > 0)
                  {
                      if (ds.Tables[2].Rows.Count > 0)
                      {
                          dt = ds.Tables[2];
                      }
                      for (int i = 0; i < dt.Rows.Count; i++)
                      {
                          string deptid = dt.Rows[i]["intApprovalid"].ToString();

                          if (deptid == "15")//FACTORIES
                          {
                              try
                              {
                                  FactoryServiceCFO.grantLicense factoryvo = new FactoryServiceCFO.grantLicense();
                                  FactoryServiceCFO.rawMaterial rawvo = new FactoryService.rawMaterial();
                                  FactoryServiceCFO.UpdateAppealAgainstRejectionCFO factoryvo = new FactoryServiceCFO.UpdateAppealAgainstRejectionCFO();

                                  string outputfactory = "";
                                  string valuefactory = "";
                                  DataSet dsdept = new DataSet();
                                  dsdept = Gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                                  valuefactory = dsdept.GetXml();
                                  outputfactory = factory.insertIntoPlanApproval(factoryvo);


                                  factoryvo.amountToBePaid = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                                  factoryvo.applicationID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                                  factoryvo.applicationStageID = dsdept.Tables[0].Rows[0]["intstageid"].ToString();
                                  factoryvo.applicationStatus = "Pre-Scuitiny Pending"; //dsdept.Tables[0].Columns[""].ToString();
                                  factoryvo.applicationSubmittedDate = dsdept.Tables[0].Rows[0]["UID_NOGenerateDate"].ToString();

                                  factoryvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                  factoryvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                  factoryvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                  factoryvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                  factoryvo.communicationAddress = dsdept.Tables[0].Rows[0]["communicationAddress"].ToString();
                                  factoryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                  factoryvo.factoryDistrictID = dsdept.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                                  factoryvo.factoryDoorNumber = dsdept.Tables[0].Rows[0]["Door_No"].ToString();
                                  factoryvo.factoryLocality = dsdept.Tables[0].Rows[0]["StreetName"].ToString();
                                  factoryvo.factoryMandalID = dsdept.Tables[0].Rows[0]["Prop_intMandalid"].ToString();
                                  factoryvo.factoryName = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                                  factoryvo.factoryOccupationDateByOccupier = dsdept.Tables[0].Rows[0]["Date_Occupation"].ToString();// 
                                  factoryvo.factoryPinCode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                                  factoryvo.factoryType = dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                                  factoryvo.factoryVillageID = dsdept.Tables[0].Rows[0]["Prop_intVillageid"].ToString();
                                  factoryvo.horsePowerToBeInstalledRegular = dsdept.Tables[0].Rows[0]["RegularHp"].ToString(); //dsdept.Tables[0].Rows[0][""].ToString();
                                  factoryvo.horsePowerToBeInstalledRegularUnits = "HP";
                                  factoryvo.horsePowerToBeInstalledStandby = dsdept.Tables[0].Rows[0]["StandbyHp"].ToString(); //dsdept.Tables[0].Rows[0][""].ToString();
                                  factoryvo.horsePowerToBeInstalledStandbyUnits = "HP";
                                  factoryvo.managerDistrict = dsdept.Tables[0].Rows[0]["Mangr_District"].ToString();
                                  factoryvo.managerDoorNo = dsdept.Tables[0].Rows[0]["Mangr_DoorNo"].ToString();
                                  factoryvo.managerFullName = dsdept.Tables[0].Rows[0]["Mangr_Full_Name"].ToString();
                                  factoryvo.managerLocality = dsdept.Tables[0].Rows[0]["Mangr_Locality"].ToString();
                                  factoryvo.managerMailId = dsdept.Tables[0].Rows[0]["Mangr_EmailId"].ToString();
                                  factoryvo.managerMandal = dsdept.Tables[0].Rows[0]["Mangr_Mandal"].ToString();
                                  factoryvo.managerMobileNumber = dsdept.Tables[0].Rows[0]["Mangr_MobileNo"].ToString();
                                  factoryvo.managerPinCode = dsdept.Tables[0].Rows[0]["Mangr_PinCode"].ToString();
                                  factoryvo.managerVillage = dsdept.Tables[0].Rows[0]["Mangr_Village"].ToString();
                                  factoryvo.natureOfManufacturingProcessMain = dsdept.Tables[0].Rows[0]["MAIN"].ToString();// dsdept.Tables[0].Rows[0][""].ToString();
                                  factoryvo.natureOfManufacturingProcessSecondary = dsdept.Tables[0].Rows[0]["SECONDARYITEM"].ToString();// dsdept.Tables[0].Rows[0][""].ToString();
                                  factoryvo.noOfyearsSelectedToPayLicenceFee = dsdept.Tables[0].Rows[0]["LicenseYear"].ToString();
                                  factoryvo.occupierDistrict = dsdept.Tables[0].Rows[0]["Occupier_District"].ToString();
                                  factoryvo.occupierDoorNo = dsdept.Tables[0].Rows[0]["Occupier_DoorNo"].ToString();
                                  factoryvo.occupierFullName = dsdept.Tables[0].Rows[0]["Occupier_Full_Name"].ToString();
                                  factoryvo.occupierLocality = dsdept.Tables[0].Rows[0]["Occupier_Locality"].ToString();
                                  factoryvo.occupierMailId = dsdept.Tables[0].Rows[0]["Occupier_EmailId"].ToString();
                                  factoryvo.occupierMandal = dsdept.Tables[0].Rows[0]["Occupier_Mandal"].ToString();
                                  factoryvo.occupierMobileNumber = dsdept.Tables[0].Rows[0]["Occupier_MobileNo"].ToString();
                                  factoryvo.occupierOtherStatePostalAddress = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                                  factoryvo.occupierPinCode = dsdept.Tables[0].Rows[0]["Occupier_PinCode"].ToString();
                                  factoryvo.occupierPositionInFactory = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                                  factoryvo.occupierState = "36";//dsdept.Tables[0].Rows[0][""].ToString();
                                  factoryvo.occupierVillage = dsdept.Tables[0].Rows[0]["Occupier_Village"].ToString();
                                  factoryvo.ownerDistrict = dsdept.Tables[0].Rows[0]["Owner_District"].ToString();
                                  factoryvo.ownerDoorNo = dsdept.Tables[0].Rows[0]["Owner_DoorNo"].ToString();
                                  factoryvo.ownerFullName = dsdept.Tables[0].Rows[0]["Owner_Full_Name"].ToString();
                                  factoryvo.ownerLocality = dsdept.Tables[0].Rows[0]["Owner_Locality"].ToString();
                                  factoryvo.ownerMailId = dsdept.Tables[0].Rows[0]["Owner_EmailId"].ToString();
                                  factoryvo.ownerMandal = dsdept.Tables[0].Rows[0]["Owner_Mandal"].ToString();
                                  factoryvo.ownerMobileNumber = dsdept.Tables[0].Rows[0]["Owner_MobileNo"].ToString();
                                  factoryvo.ownerOtherStatePostalAddress = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                                  factoryvo.ownerPinCode = dsdept.Tables[0].Rows[0]["Owner_PinCode"].ToString();
                                  factoryvo.ownerState = "36";//dsdept.Tables[0].Rows[0][""].ToString();
                                  factoryvo.ownerVillage = dsdept.Tables[0].Rows[0]["Owner_Village"].ToString();
                                  factoryvo.paidAmount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                                  factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["IsPayment"].ToString();
                                  factoryvo.plansReferenceApprovedByChiefInspectorIfApplicable = dsdept.Tables[0].Rows[0]["Plans_Chief_Inspector_RefNo"].ToString();//Plans_Chief_Inspector_RefNo
                                  factoryvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                  factoryvo.systemIP = "0.0.0.0";// dsdept.Tables[0].Columns[""].ToString();
                                  factoryvo.userID = dsdept.Tables[0].Rows[0]["CREATEDBY"].ToString();
                                  factoryvo.userMailID = dsdept.Tables[0].Rows[0]["Email"].ToString();
                                  factoryvo.userMobileNumber = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                                  factoryvo.workersToBeEmployedAdolescentsFemale = dsdept.Tables[0].Rows[0]["Adolescents_Female"].ToString();
                                  factoryvo.workersToBeEmployedAdolescentsMale = dsdept.Tables[0].Rows[0]["Adolescents_Male"].ToString();
                                  factoryvo.workersToBeEmployedAdultsFemale = dsdept.Tables[0].Rows[0]["AdultFemale"].ToString();
                                  factoryvo.workersToBeEmployedAdultsMale = dsdept.Tables[0].Rows[0]["AdultMale"].ToString();
                                  factoryvo.workersToBeEmployedChildrenFemale = dsdept.Tables[0].Rows[0]["Children_Female"].ToString();
                                  factoryvo.workersToBeEmployedChildrenMale = dsdept.Tables[0].Rows[0]["Children_Male"].ToString();
                                  factoryvo.isOldApplication = "Yes";

                                  FactoryServiceCFO.aadharCardOrPanCard[] factoryaadhar = null;
                                  FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories[] factoryrefapproved = null;
                                  FactoryServiceCFO.latestListOfPartnersOrDirectors[] factorypartner = null;
                                  FactoryServiceCFO.partnershipDeed[] factorypartnershipdeed = null;
                                  FactoryServiceCFO.passPortSizePhotographWithSignature[] factoryphotosign = null;
                                  FactoryServiceCFO.registeredSaleDeedOrLeaseDeed[] factoryregisteredsaledeed = null;

                                  FactoryServiceCFO.factoryOccupierAndManagerPhotoIDProof[] factoryoccupierIdPrrof = null;
                                  FactoryServiceCFO.inCaseChangeOfDirectorsFormNo32[] factorydirector = null;
                                  FactoryServiceCFO.proposedInventoriesOfChemicalsUsed[] factoryinventories = null;


                                  DataSet dsfactroy = new DataSet();
                                  dsfactroy = Gen.getattachmentdetailsonuidCFO(UIDNO, deptid, "");

                                  if (dsfactroy != null && dsfactroy.Tables.Count > 0)
                                  {
                                      / Registration Deed////

                                      if (dsfactroy.Tables[0].Rows.Count > 0)
                                      {
                                          DataTable dtfactoryaadhar = new DataTable();
                                          dtfactoryaadhar = dsfactroy.Tables[0];
                                          factoryaadhar = new FactoryServiceCFO.aadharCardOrPanCard[dtfactoryaadhar.Rows.Count];

                                          for (int n = 0; n < dtfactoryaadhar.Rows.Count; n++)
                                          {
                                              FactoryServiceCFO.aadharCardOrPanCard factoryaadharvo = new FactoryServiceCFO.aadharCardOrPanCard();
                                              factoryaadharvo.documentName = dtfactoryaadhar.Rows[n]["FileName"].ToString();
                                              factoryaadharvo.documentPath = dtfactoryaadhar.Rows[n]["Filepath"].ToString();
                                              factoryaadhar[n] = factoryaadharvo;
                                          }
                                      }
                                      if (dsfactroy.Tables[1].Rows.Count > 0)
                                      {
                                          DataTable dtfactoryrefapproved = new DataTable();
                                          dtfactoryrefapproved = dsfactroy.Tables[1];
                                          factoryrefapproved = new FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories[dtfactoryrefapproved.Rows.Count];

                                          for (int o = 0; o < dtfactoryrefapproved.Rows.Count; o++)
                                          {
                                              FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories factoryrefapprovedvo = new FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories();
                                              factoryrefapprovedvo.documentName = dtfactoryrefapproved.Rows[o]["FileName"].ToString();
                                              factoryrefapprovedvo.documentPath = dtfactoryrefapproved.Rows[o]["Filepath"].ToString();
                                              factoryrefapproved[o] = factoryrefapprovedvo;
                                          }
                                      }
                                      if (dsfactroy.Tables[2].Rows.Count > 0)
                                      {
                                          DataTable dtfactorypartner = new DataTable();
                                          dtfactorypartner = dsfactroy.Tables[2];
                                          factorypartner = new FactoryServiceCFO.latestListOfPartnersOrDirectors[dtfactorypartner.Rows.Count];

                                          for (int p = 0; p < dtfactorypartner.Rows.Count; p++)
                                          {
                                              FactoryServiceCFO.latestListOfPartnersOrDirectors factorypartnervo = new FactoryServiceCFO.latestListOfPartnersOrDirectors();
                                              factorypartnervo.documentName = dtfactorypartner.Rows[p]["FileName"].ToString();
                                              factorypartnervo.documentPath = dtfactorypartner.Rows[p]["Filepath"].ToString();
                                              factorypartner[p] = factorypartnervo;
                                          }
                                      }
                                      if (dsfactroy.Tables[3].Rows.Count > 0)
                                      {
                                          DataTable dtfactorypartnershipdeed = new DataTable();
                                          dtfactorypartnershipdeed = dsfactroy.Tables[3];
                                          factorypartnershipdeed = new FactoryServiceCFO.partnershipDeed[dtfactorypartnershipdeed.Rows.Count];

                                          for (int n = 0; n < dtfactorypartnershipdeed.Rows.Count; n++)
                                          {
                                              FactoryServiceCFO.partnershipDeed factorypartnershipdeedvo = new FactoryServiceCFO.partnershipDeed();
                                              factorypartnershipdeedvo.documentName = dtfactorypartnershipdeed.Rows[n]["FileName"].ToString();
                                              factorypartnershipdeedvo.documentPath = dtfactorypartnershipdeed.Rows[n]["Filepath"].ToString();
                                              factorypartnershipdeed[n] = factorypartnershipdeedvo;
                                          }
                                      }
                                      if (dsfactroy.Tables[4].Rows.Count > 0)
                                      {
                                          DataTable dtfactoryphotosign = new DataTable();
                                          dtfactoryphotosign = dsfactroy.Tables[4];
                                          factoryphotosign = new FactoryServiceCFO.passPortSizePhotographWithSignature[dtfactoryphotosign.Rows.Count];

                                          for (int n = 0; n < dtfactoryphotosign.Rows.Count; n++)
                                          {
                                              FactoryServiceCFO.passPortSizePhotographWithSignature factoryphotosignvo = new FactoryServiceCFO.passPortSizePhotographWithSignature();
                                              factoryphotosignvo.documentName = dtfactoryphotosign.Rows[n]["FileName"].ToString();
                                              factoryphotosignvo.documentPath = dtfactoryphotosign.Rows[n]["Filepath"].ToString();
                                              factoryphotosign[n] = factoryphotosignvo;
                                          }
                                      }
                                      if (dsfactroy.Tables[5].Rows.Count > 0)
                                      {
                                          DataTable dtfactoryregisteredsaledeed = new DataTable();
                                          dtfactoryregisteredsaledeed = dsfactroy.Tables[5];
                                          factoryregisteredsaledeed = new FactoryServiceCFO.registeredSaleDeedOrLeaseDeed[dtfactoryregisteredsaledeed.Rows.Count];

                                          for (int n = 0; n < dtfactoryregisteredsaledeed.Rows.Count; n++)
                                          {
                                              FactoryServiceCFO.registeredSaleDeedOrLeaseDeed factoryregisteredsaledeedvo = new FactoryServiceCFO.registeredSaleDeedOrLeaseDeed();
                                              factoryregisteredsaledeedvo.documentName = dtfactoryregisteredsaledeed.Rows[n]["FileName"].ToString();
                                              factoryregisteredsaledeedvo.documentPath = dtfactoryregisteredsaledeed.Rows[n]["Filepath"].ToString();
                                              factoryregisteredsaledeed[n] = factoryregisteredsaledeedvo;
                                          }
                                      }
                                  }


                                  factoryvo.aadharCardOrPanCardAttachments = factoryaadhar;
                                  factoryvo.plansReferenceApprovedByDirectorOfFactoriesAttachments = factoryrefapproved;
                                  factoryvo.latestListOfPartnersOrDirectorsAttachments = factorypartner;
                                  factoryvo.partnershipDeedAttachments = factorypartnershipdeed;
                                  factoryvo.passPortSizePhotographWithSignatureAttachments = factoryphotosign;
                                  factoryvo.registeredSaleDeedOrLeaseDeedAttachments = factoryregisteredsaledeed;
                                  factoryvo.factoryOccupierAndManagerPhotoIDProofAttachments = factoryoccupierIdPrrof;
                                  factoryvo.inCaseChangeOfDirectorsFormNo32Attachments = factorydirector;
                                  factoryvo.proposedInventoriesOfChemicalsUsedAttachments = factoryinventories;

                                  string OUTPUT = factorycfo.updateAppealAgainstRejectionCFO(factoryvo);

                                  if (OUTPUT == "SUCCESS")
                                  {

                                      Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "R", OUTPUT, "Y");
                                      Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", OUTPUT, "Y");
                                      int k = Gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);

                                      try
                                      {
                                          string outputfactory1 = "";
                                          string valuefactory1 = "";
                                          DataSet dsdept1 = new DataSet();
                                          dsdept1 = Gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                          valuefactory = dsdept.GetXml();
                                          if (dsdept1 != null && dsdept1.Tables.Count > 0 && dsdept1.Tables[0].Rows.Count > 0)
                                          {
                                              FactoryServiceCFO.grantLicenseAdditionalPayment factorycfovo = new FactoryServiceCFO.grantLicenseAdditionalPayment();
                                              factorycfovo.applicationID = dsdept1.Tables[0].Rows[0]["UIDNO"].ToString();
                                              factorycfovo.bankAmount = dsdept1.Tables[0].Rows[0]["Online_Amount"].ToString();
                                              factorycfovo.bankDate = dsdept1.Tables[0].Rows[0]["TransactionDate"].ToString();
                                              factorycfovo.bankName = dsdept1.Tables[0].Rows[0]["BankName"].ToString();
                                              factorycfovo.challanNumber = dsdept1.Tables[0].Rows[0]["TransactionNO"].ToString();
                                              factorycfovo.paymentStatus = dsdept1.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                              factorycfovo.systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                              factorycfovo.userID = dsdept1.Tables[0].Rows[0]["Created_by"].ToString();
                                              string outfactory1 = factorycfo.insertIntoGrantLicenseAdditionalPayment(factorycfovo);

                                              if (outfactory1 == "SUCCESS")
                                              {

                                                  Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outfactory1, "Y");

                                              }
                                              else
                                              {
                                                  Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outfactory1, "N");
                                              }
                                          }
                                      }
                                      catch (Exception ex)
                                      {

                                      }
                                  }
                                  else
                                  {
                                      Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "R", OUTPUT, "N");
                                  }
                              }
                              catch (Exception ex)
                              {


                              }
                          }
                      }
                  }*/
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void BtnReject_Click(object sender, EventArgs e)
    {
        try
        {

            Button BtnReject = (Button)sender;
            GridViewRow row = (GridViewRow)BtnReject.NamingContainer;
            TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject");
            if (!TxtRemarks.Visible)
                TxtRemarks.Visible = true;

            if ((TxtRemarks.Visible) && (TxtRemarks.Text != ""))
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate", "RejectValidate();", true);
                //return;
            }
            else
            {
                //Response.Write("<script>alert('Please enter remarks');</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate1", "RejectValidate1();", true);
                TxtRemarks.Focus();
                return;
            }


            HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
            TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
            HyperLink h1 = (HyperLink)row.FindControl("h1");
            HyperLink h2 = (HyperLink)row.FindControl("h2");
            HyperLink h3 = (HyperLink)row.FindControl("h3");
            HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
            HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
            HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");
            HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");
            HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");

            LinkButton lnkuidno = (LinkButton)row.FindControl("LinkButton1");

            int j = Gen.UpdatetAppealApprovalnewCFOCOIReject(hdfGroundedNo.Value, "Rejected", Session["uid"].ToString(), "16", hdfGroundedNo0.Value, hdfGroundedNo1.Value, TxtRemarks.Text.Trim(), getclientIP());

            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "   </b> Industries Dept has Rejected your application with Remarks " + TxtRemarks.Text.Trim() + " . Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  : Industries Dept has Rejected your application with Remarks " + TxtRemarks.Text.Trim() + ". Thank You.");
                //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                //}

                if (j > 0)
                {
                    success.Visible = true;
                    Failure.Visible = false;
                    lblmsg.Text = "Successfully Updated";
                }
                else
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg.Text = "Failed..";
                }
                GetDetails();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}
