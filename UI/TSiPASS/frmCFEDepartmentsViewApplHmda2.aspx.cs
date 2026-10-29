using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using Org.BouncyCastle.Asn1.Ocsp;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General(); DB.DB con = new DB.DB();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    string rstages = "0";
    HMDAService.tsipass hmdaservice = new HMDAService.tsipass();
    HMDAService.ApplicationFormResponse hmdapplication = new HMDAService.ApplicationFormResponse();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
            Session.RemoveAll();

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
            dsn = Gen.GetShowDepartmentFilesHmda2(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());
            if (dsn.Tables[0].Rows.Count > 0)
            {

                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
                if (rstages == "13")
                {
                    grdDetails.Columns[17].Visible = true;
                    grdDetails.Columns[18].Visible = true;
                }
                else
                {
                    //grdDetails.Columns[17].Visible = false;
                    grdDetails.Columns[18].Visible = false;
                }
                if (Session["uid"].ToString().Trim() == "1027" || Session["uid"].ToString().Trim() == "1028")
                {
                    grdDetails.Columns[18].Visible = true;
                }
                else
                {
                    grdDetails.Columns[18].Visible = false;
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
                grdDetails.Columns[13].Visible = false;
            }
            if (Request.QueryString[0].ToString().Trim() == "17"|| Request.QueryString[0].ToString().Trim() == "18" || Request.QueryString[0].ToString().Trim() == "7" )
            {
                grdDetails.Columns[13].Visible = false;
               
            }
            if (Request.QueryString[0].ToString().Trim() == "17" )
            {
                grdDetails.Columns[13].Visible = false;
                grdDetails.Columns[22].Visible = true;
            }
        }
        else
        {
            //grdDetails.Columns[10].Visible = false;
            //grdDetails.Columns[11].Visible = false;

            grdDetails.Columns[11].Visible = false;
            grdDetails.Columns[12].Visible = false;
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


            DropDownList ddlStatus1 = (DropDownList)e.Row.Cells[11].FindControl("ddlStatus");
            e.Row.Cells[21].Text = "Please process this application in TS-iPASS portal";
            ddlStatus1.Enabled = true;
            //Commented on 14/05/2025 as integration stopped
            //if (e.Row.Cells[21].Text.Trim() == "Y" )
            //{
            //    e.Row.Cells[21].Text = "Please process this application in Concerned Department portal";
            //    e.Row.Cells[21].Font.Bold = true;
            //    ddlStatus1.Enabled = false;
            //}
            //else
            //{
            //    e.Row.Cells[21].Text = "Please process this application in TS-iPASS portal";
            //    ddlStatus1.Enabled = true;
            //}

            HyperLink h1 = (HyperLink)e.Row.Cells[8].Controls[0];

            HyperLink h2 = (HyperLink)e.Row.Cells[9].Controls[0];
            HyperLink h3 = (HyperLink)e.Row.Cells[10].Controls[0];
            HyperLink h4 = (HyperLink)e.Row.Cells[17].Controls[0];
            HyperLink h5 = (HyperLink)e.Row.Cells[19].Controls[0];

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");
            h4.Target = "_blank";
            h4.NavigateUrl = "RptPaymentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();



            btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();


            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";


            h1.Target = "_blank";

            h1.NavigateUrl = "CFEPrint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            h2.Target = "_blank";
            h2.NavigateUrl = "frmViewAttachmentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            h3.Target = "_blank";
            h3.NavigateUrl = "frmQurieResponseStatus.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            h4.Target = "_blank";
            h4.NavigateUrl = "RptPaymentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            h5.Target = "_blank";
            h5.NavigateUrl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FilePath"));
            
            DropDownList ddlStatus = (DropDownList)e.Row.Cells[11].FindControl("ddlStatus");
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "139723"|| Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "115861" ||
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "138952" || Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "139034" ||
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "139954" || Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "139659" ||
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "140248" || Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "139047"||
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "138747" || Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "139604"||
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "140398"|| Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "140697"||
                 Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "138919" || Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "138727"||
                 Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "138968"|| Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "138940"
                 || Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() == "140411")
            {
                ddlStatus.Enabled = true;
            }
            ddlStatus.Enabled = true;
            TextBox txtPromotor = (TextBox)e.Row.Cells[11].FindControl("txtPromotor");

            Label Label378 = (Label)e.Row.Cells[11].FindControl("Label378");

            Label Label379 = (Label)e.Row.Cells[11].FindControl("Label379");

            TextBox txtAmount = (TextBox)e.Row.Cells[11].FindControl("txtAmount");

            HiddenField hdfApplID = (HiddenField)e.Row.Cells[12].FindControl("hdfApplID");
            hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();

            HiddenField hdfGroundedNo = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo");

            hdfGroundedNo.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo0");

            hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();


            HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo1");

            hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();


            HiddenField hdfGroundedNo2 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo2");

            hdfGroundedNo2.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LastDateofPreScrutiy")).Trim();


            HiddenField hdfGroundedNo3 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo3");

            hdfGroundedNo3.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStatusid")).Trim();


            DataSet dsquery = new DataSet();

            dsquery = Gen.GetQueryRaised(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value);

            if (dsquery.Tables[0].Rows.Count > 0)
            {
                ddlStatus.Items.RemoveAt(3);
                //ddlStatus.Items.RemoveAt(2);
            }





            if (Session["uid"].ToString().Trim() == "1027" || Session["uid"].ToString().Trim() == "1028")
            {
                HyperLink h6 = (HyperLink)e.Row.Cells[19].Controls[0];
                h6.Target = "_blank";
                h6.NavigateUrl = "RPTTSSPDCL.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }

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


            //DataSet dsDCR = new DataSet();
            //dsDCR = checkDCRPortal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")));

            //if (Session["User_Code"].ToString().Trim() == "11" || Session["User_Code"].ToString().Trim() == "13")
            //{
            //    if (Convert.ToString(dsDCR.Tables[0].Rows[0]["DCRPORTAL"]) == "Y")
            //    {
            //        e.Row.Cells[20].Text = "Please process this application in Concerned Department portal";
            //        e.Row.Cells[20].Font.Bold = true;
            //        ddlStatus.Enabled = false;
            //    }
            //    else
            //    {
            //        e.Row.Cells[20].Text = "Please process this application in TS-iPASS portal";
            //        ddlStatus.Enabled = true;
            //    }
            //}




        }




    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList ddlStatus = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");
        FileUpload fuDCLUpload = (FileUpload)row.FindControl("fuDCLUpload");
        Button btnFupUpload = (Button)row.FindControl("btnUploadDC");
        CheckBoxList chkQueryRej = (CheckBoxList)row.FindControl("chkQueryRej");
        //
        CheckBoxList CheckBoxList1 = (CheckBoxList)row.FindControl("CheckBoxList1");
        Label lbluploadDCLetter = (Label)row.FindControl("lbluploadDCLetter");
        //lblQueryRej
        Label lblQueryRej = (Label)row.FindControl("lblQueryRej");
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
            fuDCLUpload.Visible = false;
            btnFupUpload.Visible = false;
            Label379.Visible = false;
            txtAmount.Visible = false;
            lbluploadDCLetter.Visible = false;
            chkQueryRej.Visible = true;
            lblQueryRej.Visible = true;
        }

        else if (ddlStatus.SelectedValue.ToString() == "16")
        {
            txtPromotor.Visible = true;
            Label378.Visible = true;
            Label378.Text = "Reason For Rejection";
            fuDCLUpload.Visible = false;
            btnFupUpload.Visible = false;
            Label379.Visible = false;
            txtAmount.Visible = false;
            lbluploadDCLetter.Visible = false;
            chkQueryRej.Visible = true;
            lblQueryRej.Visible = true;

        }
        else if (ddlStatus.SelectedValue.ToString() == "7")
        {

            txtPromotor.Visible = true;
            Label378.Visible = true;
            Label379.Visible = true;
            txtAmount.Visible = true;
            fuDCLUpload.Visible = false;
            btnFupUpload.Visible = false;
            lbluploadDCLetter.Visible = false;
            chkQueryRej.Visible = false;
            lblQueryRej.Visible = false;
        }

        else if (ddlStatus.SelectedValue.ToString() == "11")
        {
            txtPromotor.Visible = false;
            Label378.Visible = false;
            Label379.Visible = true;
            txtAmount.Visible = true;
            grdDetails.Columns[12].Visible = true;
            lbluploadDCLetter.Visible = true;
            fuDCLUpload.Visible = true;
            btnFupUpload.Visible = true;
            CheckBoxList1.Visible = true;
            chkQueryRej.Visible = false;
            lblQueryRej.Visible = false;
        }
        else
        {
            txtPromotor.Visible = false;
            Label378.Visible = false;
            Label379.Visible = false;
            txtAmount.Visible = false;
            fuDCLUpload.Visible = false;
            btnFupUpload.Visible = false;
            lbluploadDCLetter.Visible = false;
            chkQueryRej.Visible = false;
            lblQueryRej.Visible = false;

        }

        // if(ddlStatus.)

        //if()


    }
    protected void BtnSave_Click1(object sender, EventArgs e)
    {

        Button BtnSave = (Button)sender;

        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");

        Label lblAttachedFileName1 = (Label)row.FindControl("lblAttachedFileName1");

        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");

        TextBox txtAmount = (TextBox)row.FindControl("txtAmount");

        HyperLink h1 = (HyperLink)row.FindControl("h1");

        HyperLink h2 = (HyperLink)row.FindControl("h2");

        HyperLink h3 = (HyperLink)row.FindControl("h3");

        HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
        HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
        HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");
        CheckBoxList chkQueryRej1 = (CheckBoxList)row.FindControl("chkQueryRej");

        HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");

        HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");


        if (ddlStatus.SelectedValue.ToString() == "--Select--")
        {
            Failure.Visible = true;
            success.Visible = false;
            lblmsg.Text = "Please Select Status";
        }

        int result = 0;

        result = Gen.insertDepartmentProcess(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value, ddlStatus.SelectedValue.ToString(), hdfGroundedNo2.Value, Session["uid"].ToString().Trim());


        if (ddlStatus.SelectedValue.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
        {
            //HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
            //hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();


            ////HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");

            ////hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();


            ////HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");

            ////hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();

            int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
            string selectedDocuments = string.Empty;
     
 
            foreach(ListItem liDoc in chkQueryRej1.Items)
            {
           
                 if(liDoc.Selected)
                {
                    if(selectedDocuments!="")
                    {
                        selectedDocuments = selectedDocuments + ",";
                    }
                    selectedDocuments = selectedDocuments  + liDoc.Value ;
                }
              
            }
            if(selectedDocuments=="")
            {
                lblmsg.Text = "Please select Documents";
            }
            else
            {
                lblmsg.Text = "";
                int i = Gen.insertQueryResponsedata_BP(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text, "Y", Session["uid"].ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, hdfApplID.Value, selectedDocuments);
                try
                {
                    int k = Gen.InsertDeptDateTracing(hdfGroundedNo0.Value, hdfApplID.Value, "", null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "CFE", hdfGroundedNo1.Value);
                }
                catch (Exception ex)
                {

                }
                DataSet dsMail = new DataSet();
                dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);

                if (dsMail.Tables[0].Rows.Count > 0)
                {

                    cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                }
                if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thank You.");
                    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
                }
                GetDetails();

            }




        }
        else if (ddlStatus.SelectedValue.ToString() == "7")
        {

            int i = Gen.insertQueryResponsedata_BP(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, hdfApplID.Value, "");

            int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, txtAmount.Text, "Y", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());


            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);

            if (dsMail.Tables[0].Rows.Count > 0)
            {

                cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query and requested additional payment on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has raised a query  and requested additional payment on your application. Please respond to the query  in your login in TS-iPASS. Thank You.");
                //cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "11")
        {
            if (txtAmount.Text.Trim() == "")
            {
                Failure.Visible = true;
                success.Visible = false;
                lblmsg.Text = "Please Enter Amount";
                return;
            }
            if(lblAttachedFileName1.Text!="" && txtAmount.Text.Trim() != "")

            {

                int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, txtAmount.Text, "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());

                try
                {
                    //int k = Gen.InsertDeptDateTracing(hdfGroundedNo0.Value, hdfApplID.Value, "", null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "CFE", hdfGroundedNo1.Value);
                    int k = Gen.InsertDeptDateTracing(hdfGroundedNo0.Value, hdfApplID.Value, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", hdfGroundedNo1.Value);
                }
                catch (Exception ex)
                {

                }
                DataSet dsMail = new DataSet();
                dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);

                if (dsMail.Tables[0].Rows.Count > 0)
                {

                    cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                }
                if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                    //cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                }

            }

            if(lblAttachedFileName1.Text=="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please upload DC Letter and select list of documents!');", true);
            }
       
        }
        else if (ddlStatus.SelectedValue.ToString() == "12")
        {
            int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
            try
            {
                int k = Gen.InsertDeptDateTracing(hdfGroundedNo0.Value, hdfApplID.Value, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", hdfGroundedNo1.Value);
            }
            catch (Exception ex)
            {

            }
            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);

            if (dsMail.Tables[0].Rows.Count > 0)
            {

                cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "16")
        {
            string selectedDocuments_Rej = string.Empty;


            foreach (ListItem liDoc in chkQueryRej1.Items)
            {

                if (liDoc.Selected)
                {
                    if (selectedDocuments_Rej != "")
                    {
                        selectedDocuments_Rej = selectedDocuments_Rej + ",";
                    }
                    selectedDocuments_Rej = selectedDocuments_Rej + liDoc.Value;
                }

            }

            if (selectedDocuments_Rej=="")
            {
                lblmsg.Text = "Please select Documents";
            }

            else
            {
                lblmsg.Text = "";
                if (txtPromotor.Text.Trim() != "")
                {
                    int j = Gen.UpdateAdditionalpaymentsBeforePre_BP(hdfGroundedNo.Value, "", "Rejected", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, txtPromotor.Text, getclientIP(), selectedDocuments_Rej);
                    int k = Gen.InsertDeptDateTracing(hdfGroundedNo0.Value, hdfApplID.Value, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", hdfGroundedNo1.Value);
                    DataSet dsMail = new DataSet();
                    dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
                    if (dsMail.Tables[0].Rows.Count > 0)
                    {
                        cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has Rejected your application. Please login to TS-iPASS Appeal for Rejection. Thank You.");
                    }
                    if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    {
                        cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has Rejected your application. Please login to TS-iPASS Appeal for Rejection. Thank You.");
                        //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                    }

                }
                else
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg.Text = "Please Enter Reason For Rejection";
                }
            }

         
        }



        if (result > 0)
        {
            success.Visible = true;
            Failure.Visible = false;
            lblmsg.Text = "Successfully Updated";
            if (ddlStatus.SelectedValue.ToString() == "16")
            {
                if (txtPromotor.Text.Trim() == "")
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg.Text = "Please Enter Reason For Rejection";
                }
            }
            ddlStatus.SelectedIndex = 0;
            txtAmount.Text = "";
            txtPromotor.Text = "";
        }
        else
        {

            success.Visible = false;
            Failure.Visible = true;
            lblmsg.Text = "Failed..";


        }

        GetDetails();

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


    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }

    protected void btnUploadDC_Click(object sender, EventArgs e)
    {

    }


    protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Click")
        {
            string newPath = "";
            Button btnFupUpload = e.CommandSource as Button;
            Response.Write(btnFupUpload.Parent.Parent.GetType().ToString());
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            //Button btnUploadDC = (Button)sender;
            //GridViewRow row = (GridViewRow)btnUploadDC.NamingContainer;

            //Button btnFupUpload = (Button)row.FindControl("btnUploadDC");
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
            if (ddlStatus.SelectedIndex == 2)
            {
                foreach (GridViewRow gvRow in grdDetails.Rows)
                {
                    FileUpload fuDCLUpload = (FileUpload)btnFupUpload.FindControl("fuDCLUpload");
                    Label lblAttachedFileName1 = (Label)btnFupUpload.FindControl("lblAttachedFileName1");
                    Label lblIntcfeenterpid = (Label)btnFupUpload.FindControl("lblIntcfeenterpid");
                    CheckBoxList CheckBoxList1 = (CheckBoxList)btnFupUpload.FindControl("CheckBoxList1");
                    TextBox txtOthersDocument = (TextBox)btnFupUpload.FindControl("txtOthersDocument");


                    if (fuDCLUpload.HasFile)
                    {
                        if ((fuDCLUpload.PostedFile != null) && (fuDCLUpload.PostedFile.ContentLength > 0))
                        {
                            //determine file name
                            string sFileName = System.IO.Path.GetFileName(fuDCLUpload.PostedFile.FileName);
                            try
                            {
                                btnUploadDC.Enabled = false;
                                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                                //{
                                //    //Save File on disk


                                //if (FileUpload1.FileContent.Length > 102400 * 18)
                                //{
                                //     lblmsg0.Text = "size should be less than 600KB";
                                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                                //    return;
                                //}

                                string[] fileType = fuDCLUpload.PostedFile.FileName.Split('.');
                                int i = fileType.Length;
                                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                                {
                                    //Create a new subfolder under the current active folder
                                    newPath = System.IO.Path.Combine(sFileDir, lblIntcfeenterpid.Text + "\\DCLetterUploads");

                                    // Create the subfolder
                                    if (!Directory.Exists(newPath))

                                        System.IO.Directory.CreateDirectory(newPath);
                                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                    int count = dir.GetFiles().Length;
                                    if (count == 0)
                                        fuDCLUpload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                    else
                                    {
                                        if (count == 1)
                                        {
                                            string[] Files = Directory.GetFiles(newPath);

                                            foreach (string file in Files)
                                            {
                                                File.Delete(file);
                                            }
                                            fuDCLUpload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                        }
                                    }

                                    int result = 0;




                                    //ResetFormControl(this);



                                    using (SqlConnection conn = new SqlConnection())
                                    {

                                        conn.ConnectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
                                        using (SqlCommand cmd = new SqlCommand())
                                        {
                                            int counts = 0;
                                            string comma = "";
                                            string commaitem = "";
                                            string otherName = "";
                                            foreach (ListItem item in CheckBoxList1.Items)
                                            {
                                                if (item.Selected == true)
                                                {
                                                    counts = counts + 1;
                                                    if (counts > 1)
                                                    {
                                                        comma = ",";
                                                    }

                                                    if(item.Value.ToString()=="18")
                                                    {
                                                        if(txtOthersDocument.Text!="")
                                                        otherName = txtOthersDocument.Text.ToString();
                                                        else
                                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please provide the name of other attachment!');", true);
                                                    }
                                                    commaitem = commaitem + comma + item.Value.ToString();
                                                    cmd.CommandText = "update td_DepartmentApprovals set DCLetterConditionsdocid=@DCLetterConditionsdocid where intApprovalid='35' and intCFEEnterpid=@intcfeenterpid";
                                                    cmd.Connection = conn;
                                                    conn.Open();
                                          
                                                    cmd.Parameters.AddWithValue("@DCLetterConditionsdocid", commaitem);
                                                    cmd.Parameters.AddWithValue("@intcfeenterpid", lblIntcfeenterpid.Text.ToString());
                                                    cmd.Parameters.AddWithValue("@FileName_dcletter", otherName);
                                                    cmd.ExecuteNonQuery();
                                                    cmd.Parameters.Clear();
                                                    conn.Close();
                                                    result = t1.InsertImagedata("", lblIntcfeenterpid.Text, fileType[i - 1].ToUpper(), newPath, sFileName, "DCLetterUploads", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                                                    if (result > 0)
                                                    {
                                                        lblAttachedFileName1.Visible = true;
                                                        lblAttachedFileName1.Text = sFileName.ToString();
                                                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                                        btnFupUpload.Enabled = false;
                                                        CheckBoxList1.Enabled = false;
                                                        break;
                                                        success.Visible = true;
                                                        Failure.Visible = false;
                                                    }
                                                }
                                                if (counts == 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select atleast one attachment!');", true);
                                                }

                                            }
                                        }

                                       


                                    }


                                    //
                                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                    //fillNews(userid);
                                }



                                else
                                {
                                    lblmsg0.Text = "<font color='red'>Upload PDF files only..!</font>";
                                    success.Visible = false;
                                    Failure.Visible = true;
                                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                                }

                            }
                            catch (Exception ex)//in case of an error
                            {
                                throw ex;
                                //lblError.Visible = true;
                                //lblError.Text = "An Error Occured. Please Try Again!";
                                DeleteFile(newPath + "\\" + sFileName);
                                // DeleteFile(sFileDir + sFileName);
                            }
                        }
                        break;


                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select a file To Upload..!');", true);
                        success.Visible = false;
                        Failure.Visible = true;
                        //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
                    }
                 
                }
            }

        }
    }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Value == "18")
            {
                GridViewRow row = (GridViewRow)CheckBoxList1.NamingContainer;
                TextBox txtPromotor = (TextBox)row.FindControl("txtOthersDocument");
                txtOthersDocument.Visible = true;
            }
        }
    }

    public DataSet checkDCRPortal(string intcfeid)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_CHECK_DCRPORTAL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intcfeid.Trim() == "" || intcfeid.Trim() == null)
                da.SelectCommand.Parameters.Add("@INTCFEID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@INTCFEID", SqlDbType.VarChar).Value = intcfeid.ToString();


            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {

        }

    }

    protected void BtnRevoke_Click(object sender, EventArgs e)
    {
        Button BtnSave = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        Button BtnReject = (Button)row.FindControl("BtnReject");
        BtnReject.Visible = false;
        TextBox TxtRemarks = (TextBox)row.FindControl("TxtReject");
        if (!TxtRemarks.Visible)
            TxtRemarks.Visible = true;

        if ((TxtRemarks.Visible) && (TxtRemarks.Text.Trim() != ""))
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

        //HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
        //hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
        ////HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");
        ////hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
        ////HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");
        ////hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
        //  int j = Gen.UpdatetAppealApprovalnew(hdfGroundedNo.Value, "Revoked", Session["uid"].ToString(), "16", hdfGroundedNo0.Value, hdfGroundedNo1.Value);
        int j = UpdatetAppealApprovalnew(hdfGroundedNo.Value, "Revoked", Session["uid"].ToString(), "16", hdfGroundedNo0.Value, hdfGroundedNo1.Value, TxtRemarks.Text);

        DataSet dsMail = new DataSet();
        dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
        if (dsMail.Tables[0].Rows.Count > 0)
        {
            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> Industries Dept has Revoked your application. Thank You."); //+ Session["user_id"].ToString() +
        }
        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
        {
            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : Industries Dept has Revoked your application. Thank You.");
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
            //string UIDNO = Request.QueryString["UIDNO"].ToString();
            //string UIDNO = "LRG00600335772";//"MEG02000064425";//"SML00500064419";//"SML00500064419";
            string UIDNO = lnkuidno.Text;// "MEG01500315533 ";//
            ds = Gen.GetDepartmentonuid(UIDNO);

            if (ds != null)
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    dt = ds.Tables[2];
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string deptid = dt.Rows[i]["intApprovalid"].ToString();
                    if (deptid == "35")//HMDA
                    {
                        DataSet dsdept = new DataSet();
                        string valueshmda = "";
                        string outputhmda = "";
                        string outpayhmda = "";
                        dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                        valueshmda = dsdept.GetXml();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(valueshmda);
                        //string jsonText = JsonConvert.SerializeXmlNode(doc); // To convert JSON text contained in string json into an XML node XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {
                            //hmdapplication.
                            //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                            hmdapplication = hmdaservice.create(valueshmda, "$$08@213");//000844/I1/U6/HMDA/25072017
                            //Kindly contact to Administrator regarding post mapping configuration for revenue department.
                            DataSet dsdeptattachmentsHMDA = new DataSet();
                            dsdeptattachmentsHMDA = Gen.getattachmentdetailsonuid(UIDNO, deptid, hmdapplication.FileNo);// "000825 /I1/U6/HMDA/10072017");//000841/I1/U6/HMDA/23072017//000842/I1/U6/HMDA/23072017

                            //Kindly contact to administrator regarding add work flow.
                            string hmdaattachments = dsdeptattachmentsHMDA.GetXml();
                            hmdapplication = hmdaservice.SaveDocumentDataUsingXML(hmdaattachments, "$$08@213");//000838/I1/U6/HMDA/20072017


                            if (hmdapplication.FileNo != "" && hmdapplication.FileNo != null)
                            {
                                //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", hmdapplication.FileNo, "Y");
                                int k = Gen.InsertDeptDateTracing("11", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                            }
                            else
                            {
                                //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "R", hmdapplication.ErrorMessage, "N");
                            }
                        }
                    }

                }
            }

        }
    }
    public int UpdatetAppealApprovalnew(string intCFEEnterpid, string Status, string Created_by, string stageid, string dept, string Approval, string Remarks)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetAppealApprovalnew";


        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();



        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();

        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@RevokeRemarks", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RevokeRemarks", SqlDbType.VarChar).Value = Remarks.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }

    }

    protected void BtnReject_Click(object sender, EventArgs e)
    {
        try
        {
            Button BtnReject = (Button)sender;
            GridViewRow row = (GridViewRow)BtnReject.NamingContainer;
            Button BtnRevoke = (Button)row.FindControl("BtnRevoke");
            BtnRevoke.Visible = false;
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
            int j = Gen.UpdatetAppealApprovalnewCOIReject(hdfGroundedNo.Value, "Rejected", Session["uid"].ToString(), "16", hdfGroundedNo0.Value, hdfGroundedNo1.Value, TxtRemarks.Text.Trim(), getclientIP());

            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                try
                {
                    //cmf.SendMailTSiPASS("anandsharmavaranasi@gmail.com", "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> Industries Dept has Rejected your application with Remarks:- " + TxtRemarks.Text.Trim() + " . Thank You.");
                    cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> Industries Dept has Rejected your application with Remarks " + TxtRemarks.Text.Trim() + " . Thank You."); //+ Session["user_id"].ToString() +
                }
                catch (Exception ee)
                {
                    throw;
                }
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                try
                {
                    //cmf.SendSingleSMS("8500602468", "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : Industries Dept has Rejected your application with Remarks:- " + TxtRemarks.Text.Trim() + ". Thank You.");
                    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : Industries Dept has Rejected your application with Remarks " + TxtRemarks.Text.Trim() + ". Thank You.");
                }
                catch (Exception ee)
                {
                    throw;
                }
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
                //GetDetails();

            }

            ScriptManager.RegisterStartupScript(this, GetType(), "RejectValidate2", "RejectValidate2();", true);
            TxtRemarks.Text = "";
            TxtRemarks.Visible = false;
            GetDetails();
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

        }

    }

}