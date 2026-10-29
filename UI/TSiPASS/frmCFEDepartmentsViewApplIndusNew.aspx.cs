using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
//using TSIPassBE;
//using TSIPassBL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Xml;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public partial class UI_TSiPASS_frmCFEDepartmentsViewApplIndusNew : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    string rstages = "0";

    #region "Global Variables"
    HttpWebRequest request;
    static Stream dataStream;
    string responseFromServer = "";

    WebserviceVO webvo = new WebserviceVO();
    comFunctions obcmf = new comFunctions();
    General gen = new General();
    WebClient wc = new WebClient();
    TSNPDCLService.TsipassWsService tsnpdcl = new TSNPDCLService.TsipassWsService();
    TSSPDCLService.TSSPDCLIPassService tsspdcl = new TSSPDCLService.TSSPDCLIPassService();
    FactoryService.TSFactoryServiceImplService factory = new FactoryService.TSFactoryServiceImplService();
    FireService.Service1 fire = new FireService.Service1();
    //BoilerService.TSBoilerServiceImplService boiler = new BoilerService.TSBoilerServiceImplService();
    LabourService.TSLabourServiceImplService labourservice = new LabourService.TSLabourServiceImplService();
    NALAService.MeeSevaWebService nalaservice = new NALAService.MeeSevaWebService();
    HMWSSBService.TSiPASSNewConnectionUC hmwssb = new HMWSSBService.TSiPASSNewConnectionUC();
    HMDAService.tsipass hmdaservice = new HMDAService.tsipass();
    HMDAService.ApplicationFormResponse hmdapplication = new HMDAService.ApplicationFormResponse();
    TSIICService.tsipass tsiicservice = new TSIICService.tsipass();
    TSIICService.ApplicationFormResponse tsiicapplication = new TSIICService.ApplicationFormResponse();
    CEIGCFEService.ApplicationServiceImplService ceigcfe = new CEIGCFEService.ApplicationServiceImplService();
    CEIGCFEService.queryReply ceigqueryvo = new CEIGCFEService.queryReply();

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }


        if (!IsPostBack)
        {
            txtFromDate.Text = "01-04-2016";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");



            DataSet dsd = new DataSet();
            dsd = Gen.GetDistrictsWithoutHYD();
            ddldistrict.DataSource = dsd.Tables[0];
            ddldistrict.DataValueField = "District_Id";
            ddldistrict.DataTextField = "District_Name";
            ddldistrict.DataBind();
            ddldistrict.Items.Insert(0, "--Select--");
            GetDetails();


        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
        if ((Request.QueryString[0].ToString().Trim() == "6") || (Request.QueryString[0].ToString().Trim() == "5"))
        {
            tdfrom.Visible = true;
            tdto.Visible = true;
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
            dsn = GetShowDepartmentFilesIndus(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());

            if (dsn.Tables[0].Rows.Count > 0)
            {

                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
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
            if (Request.QueryString[0].ToString().Trim() == "17")
            {
                grdDetails.Columns[18].Visible = true;
            }
            else
            {
                grdDetails.Columns[18].Visible = false;
            }
            //if (Request.QueryString[0].ToString().Trim() == "18")
            //{
            //    grdDetails.Columns[19].Visible = true;
            //    grdDetails.Columns[20].Visible = true;
            //}
            //else
            //{
            //    grdDetails.Columns[19].Visible = false;
            //    grdDetails.Columns[20].Visible = false;
            //}
        }
        else
        {
            //grdDetails.Columns[10].Visible = false;
            //grdDetails.Columns[11].Visible = false;

            grdDetails.Columns[11].Visible = false;
            grdDetails.Columns[12].Visible = false;
        }


    }

    //public void GetDetailsSearch()
    //{

    //    if (Request.QueryString.Count > 0)
    //    {
    //        rstages = Request.QueryString[0].ToString().Trim();

    //        DataSet dsn = new DataSet();
    //        //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
    //        //return;
    //        dsn = Gen.GetShowDepartmentFilesIndusSearch(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim(),TxtnameofUnit.Text,TxtnameofUnit0.Text,ddldistrict.SelectedValue.ToString());

    //        if (dsn.Tables[0].Rows.Count > 0)
    //        {

    //            grdDetails.DataSource = dsn.Tables[0];
    //            grdDetails.DataBind();
    //        }
    //        else
    //        {
    //            grdDetails.DataSource = null;
    //            grdDetails.DataBind();
    //        }
    //    }


    //    if (Request.QueryString.Count > 0)
    //    {
    //        if (Request.QueryString[0].ToString().Trim() == "5" || Request.QueryString[0].ToString().Trim() == "6")
    //        {
    //        }
    //        else
    //        {
    //            // grdDetails.Columns[10].Visible = false;
    //            //grdDetails.Columns[11].Visible = false;
    //            grdDetails.Columns[11].Visible = false;
    //            grdDetails.Columns[12].Visible = false;
    //        }
    //    }
    //    else
    //    {
    //        //grdDetails.Columns[10].Visible = false;
    //        //grdDetails.Columns[11].Visible = false;

    //        grdDetails.Columns[11].Visible = false;
    //        grdDetails.Columns[12].Visible = false;
    //    }


    //}

    public void GetDetailsSearch()
    {

        if (Request.QueryString.Count > 0)
        {
            DataSet dsn = new DataSet();
            //if (Request.QueryString[0].ToString().Trim() == "6")
            //{
            int valid = 0;
            string FromdateforDB = "", TodateforDB = "";

            //if (rbtnlstInputType.SelectedValue == "N")
            //{
            if (txtFromDate.Text == "" || txtFromDate.Text == null)
            {
                lblmsg0.Text = "Please Enter From Date <br/>";
                valid = 1;
            }
            if (txtTodate.Text == "" || txtTodate.Text == null)
            {
                lblmsg0.Text += "Please Enter To Date <br/>";
                valid = 1;
            }
            if (valid == 0)
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            rstages = Request.QueryString[0].ToString().Trim();


            //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
            //return;
            dsn = GetShowDepartmentFilesIndusSearchNew(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim(), TxtnameofUnit.Text, TxtnameofUnit0.Text, ddldistrict.SelectedValue.ToString(), FromdateforDB, TodateforDB);

            if (dsn.Tables[0].Rows.Count > 0)
            {

                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
            //}
            //else
            //{


            //    rstages = Request.QueryString[0].ToString().Trim();

            //    //DataSet dsn = new DataSet();
            //    //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
            //    //return;
            //    dsn = Gen.GetShowDepartmentFilesIndusSearch(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim(), TxtnameofUnit.Text, TxtnameofUnit0.Text, ddldistrict.SelectedValue.ToString());

            //    if (dsn.Tables[0].Rows.Count > 0)
            //    {

            //        grdDetails.DataSource = dsn.Tables[0];
            //        grdDetails.DataBind();
            //    }
            //    else
            //    {
            //        grdDetails.DataSource = null;
            //        grdDetails.DataBind();
            //    }
            //}
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


    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        GetDetailsSearch();


    }
    void clear()
    {




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

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[8].Controls[0];

            HyperLink h2 = (HyperLink)e.Row.Cells[9].Controls[0];
            HyperLink h3 = (HyperLink)e.Row.Cells[10].Controls[0];
            HyperLink h4 = (HyperLink)e.Row.Cells[17].Controls[0];
            HyperLink h5 = (HyperLink)e.Row.Cells[18].Controls[0];


            h1.Target = "_blank";
            h1.NavigateUrl = "CFEPrint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            h2.Target = "_blank";
            h2.NavigateUrl = "frmViewAttachmentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            h3.Target = "_blank";
            h3.NavigateUrl = "frmQurieResponseStatus.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            h4.Target = "_blank";
            h4.NavigateUrl = "RptPaymentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();

            h5.Target = "_blank";
            h5.NavigateUrl = "frmCFEAppealedListIndus.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();


            DropDownList ddlStatus = (DropDownList)e.Row.Cells[11].FindControl("ddlStatus");

            TextBox txtPromotor = (TextBox)e.Row.Cells[11].FindControl("txtPromotor");

            Label Label378 = (Label)e.Row.Cells[11].FindControl("Label378");

            Label Label379 = (Label)e.Row.Cells[11].FindControl("Label379");

            TextBox txtAmount = (TextBox)e.Row.Cells[11].FindControl("txtAmount");

            HiddenField hdfApplID = (HiddenField)e.Row.Cells[12].FindControl("hdfApplID");
            hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();

            HiddenField hdfGroundedNo = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo");

            hdfGroundedNo.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();


            HiddenField hduidno = (HiddenField)e.Row.Cells[12].FindControl("hduidno");
            hduidno.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim(); 

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

                //ddlStatus.Items.RemoveAt(3);
                ddlStatus.Items.RemoveAt(2);
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




            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();

            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";




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

        }
        else if (ddlStatus.SelectedValue.ToString() == "16")
        {

            txtPromotor.Visible = true;
            Label378.Visible = true;
            LabelDiscription.Visible = true;

            LabelDiscription.Text = "Rejection in pre-scrutiny stage is allowed only if the application is not in accordance with any act / rules. Pl. indicate the provision of act /rules that necessitate rejection of this application.Please mention on which act or rule,you are Rejecting?";
            string CloseWindow; CloseWindow = "alert('Rejection in pre-scrutiny stage is allowed only if the application is not in accordance with any act / rules. Pl. indicate the provision of act /rules that necessitate rejection of this application.Please mention on which act or rule,you are Rejecting?')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseWindow", CloseWindow, true);
            // success.Visible = true;
            // Failure.Visible = false;
            //  lblmsg.Text = "Please Mention on which act or rule,you are Rejecting?";
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblmsg.Text + "');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "Rejection in pre-scrutiny stage is allowed only if the application is not in accordance with any act / rules. Pl. indicate the provision of act /rules that necessitate rejection of this application.Please Mention on which act or rule,you are Rejecting?", true);

            string message = "Please mention on which act or rule,you are Rejecting?";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            // string message = "Your request is being processed.";

            sb.Append("alert('");
            sb.Append(message);
            sb.Append("');");
            ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());

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
    protected void BtnSave_Click1(object sender, EventArgs e)
    {

        Button BtnSave = (Button)sender;

        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");
        HiddenField hduidno= (HiddenField)row.FindControl("hduidno");
        

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
        result = Gen.insertDepartmentProcess(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value, ddlStatus.SelectedValue.ToString(), hdfGroundedNo2.Value, Session["uid"].ToString().Trim());


        if (ddlStatus.SelectedValue.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
        {
            //HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
            //hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();


            //HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");

            //hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();


            //HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");

            //hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();

            if (txtPromotor.Text == "")  //changed , added code for mail - 06.12.2017 - nk.
            {
                lblmsg.Text = "Please Enter Query Description";
            }

            else
            {
                int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());

                int i = Gen.insertQueryResponsedata(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text, "Y", Session["uid"].ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, hdfApplID.Value);

                DataSet dsMail = new DataSet();
                dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);

                if (dsMail.Tables[0].Rows.Count > 0)
                {
                    cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + "  :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                }
                if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thank You.");
                    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
                }
            }

            GetDetails();

        }
        else if (ddlStatus.SelectedValue.ToString() == "11")
        {
            if (txtAmount.Text.Trim() == "")
            {
                Failure.Visible = true;
                success.Visible = false;
                lblmsg.Text = "Please Enter Additional Payment Amount";
                return;
            }
            int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, txtAmount.Text, "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
            DataSet dsMail = new DataSet();
            try
            {
                int k = Gen.InsertDeptDateTracing(hdfGroundedNo0.Value, hdfApplID.Value, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", hdfGroundedNo1.Value);
            }
            catch (Exception ex)
            {

            }
            dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);

            if (dsMail.Tables[0].Rows.Count > 0)
            {
                cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised additional payment for your application. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has raised additional payment for your application. Thank You.");
                //cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "7")
        {

            int i = Gen.insertQueryResponsedata(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, hdfApplID.Value);

            int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, txtAmount.Text, "Y", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
            DataSet dsMail = new DataSet();
            dsMail = Gen.GetShowEmailidandMobileNumber(hdfApplID.Value);
            if (dsMail.Tables[0].Rows.Count > 0)
            {
                cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query and requested additional payment on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
            }
            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            {
                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + ": " + Session["user_id"].ToString() + "  has raised a query  and requested additional payment on your application. Please respond to the query  in your login in TS-iPASS. Thank You.");
                //cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "16")
        {

            //if (txtPromotor.Text == "" || txtPromotor.Text == null)
            //{
            //    Failure.Visible = true;
            //    success.Visible = false;

            //    lblmsg0.Text = " Rejection in pre-scrutiny stage is allowed only if the application is not in accordance with any act / rules. Pl. indicate the provision of act /rules that necessitate rejection of this application.";

            //   // lblmsg0.Text = " File size should be less than 300KB";
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblmsg0.Text + "');", true);
            //    return;


            //   // return;
            //}
            if (txtPromotor.Text.Trim() != "")
            {

                int j = Gen.UpdateAdditionalpaymentsBeforePre(hdfGroundedNo.Value, "", "Rejected", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, txtPromotor.Text, getclientIP());
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
                lblmsg0.Text = "Please Enter Reason For Rejection";
            }
        }
        else if (ddlStatus.SelectedValue.ToString() == "10")
        {
            int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, txtAmount.Text, "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());

        }
        else if (ddlStatus.SelectedValue.ToString() == "12")
        {
            int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
            try
            {
                int valid = updatetodepartments(hdfApplID.Value, Session["uid"].ToString(), getclientIP(), hduidno.Value);
                if (valid == 1)
                {
                }
            }
            catch (Exception ex)
            {

            }
            try
            {
                webservice(hduidno.Value);
            }
            catch (Exception ex)
            {

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

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;
        GetDetails();
    }

    public DataSet GetShowDepartmentFilesIndus(string Deptid, string intStageid, string intDistrictid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowDepartmentFilesIndusNewProcessFlag", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = Deptid.ToString();
            if (intStageid.Trim() == "" || intStageid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();

            if (intDistrictid.Trim() == "" || intDistrictid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = intDistrictid.ToString();


            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    public DataSet GetShowDepartmentFilesIndusSearchNew(string Deptid, string intStageid, string intDistrictid, string NameofUnit, string UIDNUmber, string District_Id, string fromdate, string todate)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowDepartmentFilesIndusSearchNew", con.GetConnection);
            //da = new SqlDataAdapter("GetShowDepartmentFilesIndusSearch", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = Deptid.ToString();

            if (intStageid.Trim() == "" || intStageid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();

            if (intDistrictid.Trim() == "" || intDistrictid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = intDistrictid.ToString();

            if (District_Id.Trim() == "" || District_Id.Trim() == null || District_Id.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@District_Id", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@District_Id", SqlDbType.VarChar).Value = District_Id.ToString();

            if (NameofUnit.Trim() == "" || NameofUnit.Trim() == null)
                da.SelectCommand.Parameters.Add("@NameofUnit", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@NameofUnit", SqlDbType.VarChar).Value = "%" + NameofUnit.ToString() + "%";


            if (UIDNUmber.Trim() == "" || UIDNUmber.Trim() == null)
                da.SelectCommand.Parameters.Add("@UIDNUmber", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@UIDNUmber", SqlDbType.VarChar).Value = "%" + UIDNUmber.ToString() + "%";

            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate.ToString();
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate.ToString();

            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    public void webservice(string UIDNO)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        try
        {
            //if (Session["objUsrDtl"] != null)
            //{
            //if (!IsPostBack)
            //{
                // string UIDNO = Request.QueryString["UIDNO"].ToString();
                // UIDNO = "MEG01000354445";//"MEG02000064425";//"SML00500064419";//"SML00500064419";
                ds = Gen.GetDepartmentonuid(UIDNO);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string deptid = dt.Rows[i]["intApprovalid"].ToString();

                        if (deptid == "65")
                        {
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                            SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                            CEIGCFEService.designApplication ceifvo = new CEIGCFEService.designApplication();
                            DataSet dsdept = new DataSet();
                            string valueshmwssb = "";
                            string outputhmwssb = "";
                            string outpayhmwssb = "";
                            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            valueshmwssb = dsdept.GetXml();
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {

                                ceifvo.aadhar_number = dsdept.Tables[0].Rows[0]["AadharNo"].ToString();
                                //ceifvo.applicationID = dsdept.Tables[0].Rows[0]["intCFOPowerid"].ToString();
                                ceifvo.UID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                                ceifvo.atc = dsdept.Tables[0].Rows[0]["ATC"].ToString();
                                //ceifvo.checkListUploads = "";
                                ceifvo.cli_already_installed = dsdept.Tables[0].Rows[0]["Cont_Demand_Max_Already"].ToString();
                                ceifvo.cli_proposed = dsdept.Tables[0].Rows[0]["Cont_Demand_Max_Proposed"].ToString();
                                ceifvo.cmd_already_installed = dsdept.Tables[0].Rows[0]["Connect_Load_A"].ToString();
                                ceifvo.cmd_proposed = dsdept.Tables[0].Rows[0]["Connect_Load_B"].ToString();
                                ceifvo.customer_remarks = "";//dsdept.Tables[0].Rows[0][""].ToString();
                                ceifvo.district_id = dsdept.Tables[0].Rows[0]["intDistrictid"].ToString();
                                ceifvo.email_id = dsdept.Tables[0].Rows[0]["Email"].ToString();
                                ceifvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                ceifvo.file_number = "";// dsdept.Tables[0].Rows[0][""].ToString();
                                ceifvo.first_name = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                ceifvo.hno = dsdept.Tables[0].Rows[0]["Survey_No"].ToString();
                                ceifvo.industry_district_id = dsdept.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                                ceifvo.industry_hno = dsdept.Tables[0].Rows[0]["Door_No"].ToString();
                                ceifvo.industry_mandal_id = dsdept.Tables[0].Rows[0]["Prop_intMandalid"].ToString();
                                ceifvo.industry_pincode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                                ceifvo.industry_plot_no = dsdept.Tables[0].Rows[0]["PLOTNO"].ToString();
                                ceifvo.industry_street_name = dsdept.Tables[0].Rows[0]["StreetName"].ToString();
                                ceifvo.industry_sy_no = dsdept.Tables[0].Rows[0]["inds_Survey_No"].ToString();
                                ceifvo.industry_village_id = dsdept.Tables[0].Rows[0]["Prop_intVillageid"].ToString();
                                ceifvo.last_name = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                ceifvo.loction_district_id = dsdept.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                                ceifvo.mandal_id = dsdept.Tables[0].Rows[0]["intMandalid"].ToString();
                                ceifvo.mobile_no = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                                ceifvo.name_of_industry = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                                ceifvo.name_of_promoter = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                ceifvo.pan_number = dsdept.Tables[0].Rows[0]["PANcardno"].ToString();
                                ceifvo.pincode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                                ceifvo.plant_slno = dsdept.Tables[0].Rows[0]["Plant_slno"].ToString();
                                ceifvo.plot_no = dsdept.Tables[0].Rows[0]["DOOR_nO"].ToString();
                                ceifvo.proposal_for = dsdept.Tables[0].Rows[0]["ProposalForQue"].ToString();
                                ceifvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                ceifvo.regulation_slno = dsdept.Tables[0].Rows[0]["Regulation_type"].ToString();
                                ceifvo.so_do_wo = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                ceifvo.street_name = dsdept.Tables[0].Rows[0]["Street_Name"].ToString();
                                ceifvo.sy_no = dsdept.Tables[0].Rows[0]["Survey_No"].ToString();// dsdept.Tables[0].Rows[0][""].ToString();
                                //ceifvo.system_ip = "1.1.1.1"; ;// dsdept.Tables[0].Rows[0][""].ToString();                                
                                ceifvo.type_of_industry = "35";//dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                                ceifvo.type_of_industry_others = "";// dsdept.Tables[0].Rows[0][""].ToString();                              
                                ceifvo.user_name = dsdept.Tables[0].Rows[0]["User_name"].ToString();
                                ceifvo.password = dsdept.Tables[0].Rows[0]["password"].ToString();
                                ceifvo.village_id = dsdept.Tables[0].Rows[0]["intVillageid"].ToString();
                                ceifvo.voltage_slno = dsdept.Tables[0].Rows[0]["Voltage_Slno"].ToString();
                                ceifvo.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                ceifvo.transaction_ref = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                ceifvo.payment_date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                ceifvo.bank = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                ceifvo.amount = Convert.ToDouble(dsdept.Tables[0].Rows[0]["Online_Amount"].ToString());
                                DataSet dsBoiler = new DataSet();
                                CEIGCFEService.checkListUploads[] Uploaddocuments = null;
                                dsBoiler = Gen.getattachmentdetailsonuid(UIDNO, "65", "");
                                string attcvalueshmwssb = dsBoiler.GetXml();
                                if (dsBoiler != null && dsBoiler.Tables.Count > 0)
                                {

                                    ///Registration Deed////

                                    //if (dsBoiler.Tables[0].Rows.Count > 0)
                                    //{
                                    DataTable dtceigdocuments = new DataTable();
                                    dtceigdocuments = dsBoiler.Tables[0];
                                    Uploaddocuments = new CEIGCFEService.checkListUploads[dtceigdocuments.Rows.Count];

                                    for (int n = 0; n < dtceigdocuments.Rows.Count; n++)
                                    {
                                        CEIGCFEService.checkListUploads uploadvo = new CEIGCFEService.checkListUploads();
                                        uploadvo.documentName = dtceigdocuments.Rows[n]["FileName"].ToString();
                                        uploadvo.documentPath = dtceigdocuments.Rows[n]["Filepath"].ToString();
                                        uploadvo.documentId = Convert.ToInt32(dtceigdocuments.Rows[n]["Documentid"].ToString());
                                        Uploaddocuments[n] = uploadvo;
                                    }
                                    ceifvo.checkListUploads = Uploaddocuments;
                                    //}
                                }
                                string ceigout = ceigcfe.insertIntoDesignApplication(ceifvo); //ceig.in(ceifvo);
                                if (ceigout == "SUCCESS")
                                {
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", ceigout, "Y");
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "A", ceigout, "Y");
                                    int k = Gen.InsertDeptDateTracing("65", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", "65");
                                    //int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                }
                                else
                                {
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", ceigout, "N");
                                }
                            }
                        }
                        if (deptid == "71")
                        {
                            //http://125.18.179.58:8080/WaterFeasibility/IALAsavewaterdetails.do?aadhaarnumber=222222222207&ulb_code=1116&dist_id=1&fathername=ser&fathersurname=fds&mobilenumber=9999999999&name=Test&surname=Test&industryname=IALATest&quantityofwater=10&quessionaireid=12345&entrepreneurid=2131&uid=test123;

                            DataSet dsdept = new DataSet();

                            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                string token = "bd16b347e586f05339f830b3a85d8aefa8da92c1";
                                int districtId = Convert.ToInt16(dsdept.Tables[0].Rows[0]["districtId"].ToString());
                                string districtName = dsdept.Tables[0].Rows[0]["districtName"].ToString();
                                int constituencyId = Convert.ToInt16(dsdept.Tables[0].Rows[0]["constituencyId"].ToString());
                                string constituencyName = dsdept.Tables[0].Rows[0]["constituencyName"].ToString();
                                int mandalId = Convert.ToInt16(dsdept.Tables[0].Rows[0]["mandalId"].ToString());
                                string mandalName = dsdept.Tables[0].Rows[0]["mandalName"].ToString();
                                string panchayatId = dsdept.Tables[0].Rows[0]["panchayatId"].ToString();
                                int segmentId = Convert.ToInt16(dsdept.Tables[0].Rows[0]["segmentId"].ToString());
                                string Landmark = dsdept.Tables[0].Rows[0]["Landmark"].ToString();
                                string institutionName = dsdept.Tables[0].Rows[0]["institutionName"].ToString();
                                string institutionPrimaryType = dsdept.Tables[0].Rows[0]["institutionPrimaryType"].ToString();
                                string institutionSecondaryType = dsdept.Tables[0].Rows[0]["institutionPrimaryType"].ToString();
                                int requiredQty = Convert.ToInt16(dsdept.Tables[0].Rows[0]["requiredQty"].ToString());
                                string purpose = dsdept.Tables[0].Rows[0]["purpose"].ToString();
                                string contactName = dsdept.Tables[0].Rows[0]["contactName"].ToString();
                                string contactPhone = dsdept.Tables[0].Rows[0]["contactPhone"].ToString();
                                string contactEmail = dsdept.Tables[0].Rows[0]["contactEmail"].ToString();
                                string document = dsdept.Tables[0].Rows[0]["document"].ToString();
                                string quessionaireid = dsdept.Tables[0].Rows[0]["quessionaireid"].ToString();
                                string entrepreneurid = dsdept.Tables[0].Rows[0]["entrepreneurid"].ToString();
                                string uid = dsdept.Tables[0].Rows[0]["uid"].ToString();

                                //string WEBSERVICE_URL = "http://125.18.179.58:8080/WaterFeasibility/IALAsavewaterdetails.do?aadhaarnumber=" + aadhaarnumber + "&ulb_code=" + ulb_code + "&dist_id=" + dist_id + "&fathername=" + fathername + "&fathersurname=" + fathersurname + "&mobilenumber=" + mobilenumber + "&name=" + name + "&surname=" + surname + "&industryname=" + industryname + "&quantityofwater=" + quantityofwater + " &quessionaireid=" + quessionaireid + "&entrepreneurid=" + entrepreneurid + "&uid=" + uid + ""; Test url
                                //string WEBSERVICE_URL = "http://mb.adeptogeoit.com/api/v1/connection-request?districtId=" + districtId + "&districtName=" + districtName +
                                //    "&constituencyId=" + constituencyId + "&constituencyName=" + constituencyName + "&mandalId=" + mandalId + "&mandalName=" + mandalName +
                                //    "&panchayatId=" + panchayatId + "&segmentId=" + segmentId + "&landmark=" + Landmark +
                                //   "&institutionName=" + institutionName + "&institutionPrimaryType=" + institutionPrimaryType + "&institutionSecondaryType=" + institutionSecondaryType +
                                //   "&requiredQty=" + requiredQty + "&purpose=" + purpose + "&contactName=" + contactName + "&contactPhone=" + contactPhone + "&contactEmail=" + contactEmail + "&documentFilePath=" + document +
                                //   " &quessionaireid=" + quessionaireid + "&entrepreneurid=" + entrepreneurid + "&integratedRecordId=" + uid + ""; //test url


                                string WEBSERVICE_URL = "http://missionbhagiratha.telangana.gov.in/mb-online/api/v1/connection-request?districtId=" + districtId + "&districtName=" + districtName +
                                    "&constituencyId=" + constituencyId + "&constituencyName=" + constituencyName + "&mandalId=" + mandalId + "&mandalName=" + mandalName +
                                    "&panchayatId=" + panchayatId + "&segmentId=" + segmentId + "&landmark=" + Landmark +
                                   "&institutionName=" + institutionName + "&institutionPrimaryType=" + institutionPrimaryType + "&institutionSecondaryType=" + institutionSecondaryType +
                                   "&requiredQty=" + requiredQty + "&purpose=" + purpose + "&contactName=" + contactName + "&contactPhone=" + contactPhone + "&contactEmail=" + contactEmail + "&documentFilePath=" + document +
                                   " &quessionaireid=" + quessionaireid + "&entrepreneurid=" + entrepreneurid + "&integratedRecordId=" + uid + "";

                                //http://missionbhagiratha.telangana.gov.in/mb-online/

                                //string jsonData = "{\"cafUniqueNo\" : \""+cafUniqueNo+"\", \"transactionId\":\""+transactionId+"\" , \"amount\":\""+amount+"\" , \"bankName\":\""+bankName+"\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                //string jsonData = "cafUniqueNo" : \"" + cafUniqueNo + "\", \"transactionId\":\"" + transactionId + "\" , \"amount\":\"" + amount + "\" , \"bankName\":\"" + bankName + "\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                try
                                {
                                    var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                                    if (webRequest != null)
                                    {
                                        webRequest.Headers.Add("token", "bd16b347e586f05339f830b3a85d8aefa8da92c1");
                                        //webRequest.Headers =  "bd16b347e586f05339f830b3a85d8aefa8da92c1";
                                        webRequest.Method = "POST";
                                        webRequest.Timeout = 20000;
                                        webRequest.ContentType = "application/x-www-form-urlencoded";

                                        //using (System.IO.Stream s = webRequest.GetRequestStream())
                                        //{
                                        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                                        //        sw.Write(jsonData);
                                        //}

                                        using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                                        {
                                            using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                                            {
                                                var jsonResponse = sr.ReadToEnd();
                                                System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
                                                if (jsonResponse.Contains("Operation executed successfully"))
                                                {
                                                    //{"result":"201903180002","response":"SUCCESS","responseMessage":"Operation executed successfully","status":200}
                                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", jsonResponse, "Y");
                                                    int k = Gen.InsertDeptDateTracing("71", quessionaireid, UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", "71");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", jsonResponse, "N");
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                                }

                            }
                        }
                        if (deptid == "20")//PCB
                        {
                            DataSet dsdept = new DataSet();

                            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                string cafUniqueNo = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                string transactionId = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                string amount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                                string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                string transactionStatus = "S";
                                string paymentType = "NB";
                                string indApplication = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
                                string additionalPayment = "F";
                                string QUESTIONNAIREID = dsdept.Tables[0].Rows[0]["QUESTIONNAIREID"].ToString();
                                //string WEBSERVICE_URL1 = "http://tsocmms.nic.in/TLWS/updateCl?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&remark=" + "AdditionalAmountSubmitted" + "&urlSingle=" + "";

                                //try
                                //{
                                //    var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL1);
                                //    if (webRequest != null)
                                //    {
                                //        webRequest.Method = "GET";
                                //        webRequest.Timeout = 20000;
                                //        webRequest.ContentType = "application/x-www-form-urlencoded";

                                //        //using (System.IO.Stream s = webRequest.GetRequestStream())
                                //        //{
                                //        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                                //        //        sw.Write(jsonData);
                                //        //}

                                //        using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                                //        {
                                //            using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                                //            {
                                //                var jsonResponse = sr.ReadToEnd();
                                //                System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
                                //                if (jsonResponse.Contains("submitted successfully"))
                                //                {
                                //                    //Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", jsonResponse, "Y");
                                //                }
                                //                else
                                //                {
                                //                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                //                    //Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", jsonResponse, "N");
                                //                }
                                //            }
                                //        }
                                //    }
                                //}
                                //catch (Exception ex)
                                //{
                                //    System.Diagnostics.Debug.WriteLine(ex.ToString());
                                //}

                                string WEBSERVICE_URL = "http://tsocmms.nic.in/TLWS/updateFee?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";


                                //string jsonData = "{\"cafUniqueNo\" : \""+cafUniqueNo+"\", \"transactionId\":\""+transactionId+"\" , \"amount\":\""+amount+"\" , \"bankName\":\""+bankName+"\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                //string jsonData = "cafUniqueNo" : \"" + cafUniqueNo + "\", \"transactionId\":\"" + transactionId + "\" , \"amount\":\"" + amount + "\" , \"bankName\":\"" + bankName + "\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                try
                                {
                                    var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                                    if (webRequest != null)
                                    {
                                        webRequest.Method = "GET";
                                        webRequest.Timeout = 20000;
                                        webRequest.ContentType = "application/x-www-form-urlencoded";

                                        //using (System.IO.Stream s = webRequest.GetRequestStream())
                                        //{
                                        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                                        //        sw.Write(jsonData);
                                        //}

                                        using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                                        {
                                            using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                                            {
                                                var jsonResponse = sr.ReadToEnd();
                                                System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
                                                if (jsonResponse.Contains("Fee submitted successfully"))
                                                {
                                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", jsonResponse, "Y");
                                                    int k = Gen.InsertDeptDateTracing("1", QUESTIONNAIREID, UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", "20");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", jsonResponse, "N");
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                                }

                            }

                        }
                        if (deptid == "31")//TSIIC
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

                                tsiicapplication = tsiicservice.create(valueshmda, "$$08@213");//000844/I1/U6/HMDA/25072017

                                DataSet dsdeptattachmentsTSIIC = new DataSet();
                                dsdeptattachmentsTSIIC = Gen.getattachmentdetailsonuid(UIDNO, deptid, tsiicapplication.FileNo);
                                //Kindly contact to administrator regarding add work flow.
                                string tsiicattachments = dsdeptattachmentsTSIIC.GetXml();
                                tsiicapplication = tsiicservice.SaveDocumentDataUsingXML(tsiicattachments, "$$08@213");//000838/I1/U6/HMDA/20072017//
                                if (tsiicapplication.FileNo != "" && tsiicapplication.FileNo != null)
                                {
                                    //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", tsiicapplication.FileNo, "Y");
                                    int k = Gen.InsertDeptDateTracing("3", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                }
                                else
                                {
                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", tsiicapplication.ErrorMessage, "N");
                                }
                            }
                        }
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
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", hmdapplication.FileNo, "Y");
                                    int k = Gen.InsertDeptDateTracing("11", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                }
                                else
                                {
                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", hmdapplication.ErrorMessage, "N");
                                }
                            }
                        }
                        if (deptid == "10") //HMWSSB
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                string valueshmwssb = "";
                                string outputhmwssb = "";
                                string outpayhmwssb = "";
                                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                valueshmwssb = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    webvo.UID_No = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                    webvo.intQuessionaireid = Convert.ToInt16(dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString());
                                    webvo.intEnterpreneurid = Convert.ToInt16(dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString());
                                    webvo.NameofthePromoter = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                    webvo.Door_No = dsdept.Tables[0].Rows[0]["DOOR_NO"].ToString();
                                    webvo.STREET = dsdept.Tables[0].Rows[0]["StreetName"].ToString();
                                    webvo.AreaName = dsdept.Tables[0].Rows[0]["AREANAME"].ToString();
                                    webvo.Pincode = dsdept.Tables[0].Rows[0]["PINCODE"].ToString();
                                    webvo.TelephoneNumber = dsdept.Tables[0].Rows[0]["TELEPHONENUMBER"].ToString();
                                    webvo.MobileNumber = dsdept.Tables[0].Rows[0]["MOBILENUMBER"].ToString();
                                    webvo.Email = dsdept.Tables[0].Rows[0]["EMAIL"].ToString();
                                    webvo.saleDeedPlotAreaInSqMts = Convert.ToDecimal(dsdept.Tables[0].Rows[0]["Built_up_Area"].ToString());
                                    webvo.saleDeedPlotAreaInSqYards = Convert.ToDecimal(dsdept.Tables[0].Rows[0]["SQUAREYARD"].ToString());
                                    webvo.totalPlinthArea = Convert.ToDecimal(dsdept.Tables[0].Rows[0]["Tot_Extent"].ToString());
                                    webvo.Amount = Convert.ToDecimal(dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString());
                                    webvo.Paymentflag = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    webvo.Bankname = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    webvo.Transactionno = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    webvo.TransactionDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    int receiptno = 0;
                                    bool recepit;

                                    outputhmwssb = hmwssb.SubmitApplication(webvo.UID_No, webvo.intQuessionaireid, true, webvo.intEnterpreneurid, true, webvo.NameofthePromoter, webvo.Door_No, webvo.STREET,
                                        webvo.AreaName, webvo.Pincode, webvo.TelephoneNumber, webvo.MobileNumber, webvo.Email, webvo.saleDeedPlotAreaInSqMts, true,
                                      webvo.saleDeedPlotAreaInSqYards, true, webvo.totalPlinthArea, true);
                                    hmwssb.PostCollectionChargesReceipt(webvo.intQuessionaireid, true, webvo.UID_No, webvo.intEnterpreneurid, true, webvo.Amount, true, webvo.Paymentflag, webvo.Bankname,
                                        webvo.Transactionno, webvo.TransactionDate, out receiptno, out recepit);
                                    if (receiptno != 0 && recepit == true)
                                    {
                                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", Convert.ToString(receiptno), "Y");
                                        int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), webvo.intQuessionaireid.ToString(), webvo.UID_No, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                    }
                                    else
                                    {
                                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", Convert.ToString(receiptno), "N");
                                    }
                                    //hmwssb.PostCollectionChargesReceipt()
                                    //hmwssb.SubmitApplication("uidno", "Fnam", "Houseno", "Street", "Area", "Mobile", "saleDeedPlotAreaInSqMts", "saleDeedPlotAreaInSqMtsSpecified",
                                    //   "saleDeedPlotAreaInSqYards", "saleDeedPlotAreaInSqYardsSpecified", "totalPlinthArea", "totalPlinthAreaSpecified");
                                    //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('HSRPService.aspx?Office=" + ((UserDetail)Session["objUsrDtl"]).OfficeCode + "&Date=" + DateTime.Today.ToString("dd/MM/yyyy") + "','null','height=350,width=500,status=no,toolbar=no,menubar=no,location=no');</Script>", false);
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                        if (deptid == "34")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                string valuenala = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    webvo.UserId = dsdept.Tables[0].Rows[0]["UserId"].ToString();
                                    webvo.Password = dsdept.Tables[0].Rows[0]["Password"].ToString();
                                    webvo.LogindID = dsdept.Tables[0].Rows[0]["LogindID"].ToString();
                                    webvo.ServiceID = dsdept.Tables[0].Rows[0]["ServiceID"].ToString();
                                    webvo.AddressFlag = dsdept.Tables[0].Rows[0]["AddressFlag"].ToString();
                                    webvo.UIDNumber = dsdept.Tables[0].Rows[0]["UIDNumber"].ToString();
                                    webvo.ApplicantName = dsdept.Tables[0].Rows[0]["ApplicantName"].ToString();
                                    webvo.Relation = dsdept.Tables[0].Rows[0]["Relation"].ToString();
                                    webvo.FatherName = dsdept.Tables[0].Rows[0]["FatherName"].ToString();
                                    webvo.Gender = dsdept.Tables[0].Rows[0]["Gender"].ToString();
                                    webvo.DateOfBirth = dsdept.Tables[0].Rows[0]["DateOfBirth"].ToString();
                                    webvo.PermanentDoorNo = dsdept.Tables[0].Rows[0]["PermanentDoorNo"].ToString();
                                    webvo.PermanentLocality = dsdept.Tables[0].Rows[0]["PermanentLocality"].ToString();
                                    webvo.PermanentDistrict = dsdept.Tables[0].Rows[0]["PermanentDistrict"].ToString();
                                    webvo.PermanentMandal = dsdept.Tables[0].Rows[0]["PermanentMandal"].ToString();
                                    webvo.PermanentVillage = dsdept.Tables[0].Rows[0]["PermanentVillage"].ToString();
                                    webvo.PermanentPincode = dsdept.Tables[0].Rows[0]["PermanentPincode"].ToString();
                                    webvo.PostalDoorNo = dsdept.Tables[0].Rows[0]["PostalDoorNo"].ToString();
                                    webvo.PostalLocality = dsdept.Tables[0].Rows[0]["PostalLocality"].ToString();
                                    webvo.StateId = dsdept.Tables[0].Rows[0]["StateId"].ToString();
                                    webvo.PostalDistrict = dsdept.Tables[0].Rows[0]["PostalDistrict"].ToString();
                                    webvo.PostalMandal = dsdept.Tables[0].Rows[0]["PostalMandal"].ToString();
                                    webvo.PostalVillage = dsdept.Tables[0].Rows[0]["PostalVillage"].ToString();
                                    webvo.PostalPincode = dsdept.Tables[0].Rows[0]["PostalPincode"].ToString();
                                    webvo.MobileNo = dsdept.Tables[0].Rows[0]["MobileNo"].ToString();
                                    webvo.PhoneNo = dsdept.Tables[0].Rows[0]["PhoneNo"].ToString();
                                    webvo.EmailID = dsdept.Tables[0].Rows[0]["EmailID"].ToString();
                                    webvo.Remarks = dsdept.Tables[0].Rows[0]["Remarks"].ToString();
                                    webvo.RationCardNo = dsdept.Tables[0].Rows[0]["RationCardNo"].ToString();
                                    webvo.AadhaarNo = dsdept.Tables[0].Rows[0]["AadhaarNo"].ToString();
                                    webvo.DeliveryType = dsdept.Tables[0].Rows[0]["DeliveryType"].ToString();
                                    webvo.Doc_District = dsdept.Tables[0].Rows[0]["Doc_District"].ToString();
                                    webvo.Doc_Mandal = dsdept.Tables[0].Rows[0]["Doc_Mandal"].ToString();
                                    webvo.Doc_Village = dsdept.Tables[0].Rows[0]["Doc_Village"].ToString();
                                    webvo.Purpose = dsdept.Tables[0].Rows[0]["Purpose"].ToString();
                                    webvo.ServiceCharge = dsdept.Tables[0].Rows[0]["ServiceCharge"].ToString();
                                    webvo.UserCharge = dsdept.Tables[0].Rows[0]["UserCharge"].ToString();
                                    webvo.PostalCharge = dsdept.Tables[0].Rows[0]["PostalCharge"].ToString();
                                    webvo.TotalAmount = dsdept.Tables[0].Rows[0]["TotalAmount"].ToString();
                                    webvo.GridDetails = dsdept.Tables[0].Rows[0]["GridDetails"].ToString();
                                    webvo.QuestionaireId = dsdept.Tables[0].Rows[0]["QuestionaireId"].ToString();
                                    webvo.EntrepreneurId = dsdept.Tables[0].Rows[0]["EntrepreneurId"].ToString();
                                    DataSet dsdeptattachmentsfire = new DataSet();
                                    dsdeptattachmentsfire = Gen.getattachmentdetailsonuid(UIDNO, deptid, "");
                                    if (dsdeptattachmentsfire != null && dsdeptattachmentsfire.Tables.Count > 0 && dsdeptattachmentsfire.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsdeptattachmentsfire.Tables[0].Rows[0]["Description"] == "Self Certification Form")
                                        {
                                            webvo.certificateform = dsdeptattachmentsfire.Tables[0].Rows[0]["Filepath"].ToString();
                                        }
                                        if (dsdeptattachmentsfire.Tables[1].Rows.Count > 0)
                                        {
                                            if (dsdeptattachmentsfire.Tables[1].Rows[0]["Description"] == "Registration Deed")
                                            {
                                                webvo.landrelated = dsdeptattachmentsfire.Tables[1].Rows[0]["Filepath"].ToString();
                                            }
                                        }
                                        if (dsdeptattachmentsfire.Tables[2].Rows.Count > 0)
                                        {
                                            if (dsdeptattachmentsfire.Tables[2].Rows[0]["Description"] == "PAN / AADHAAR")
                                            {
                                                webvo.idproof = dsdeptattachmentsfire.Tables[2].Rows[0]["Filepath"].ToString();
                                            }
                                        }
                                        if (dsdeptattachmentsfire.Tables[3].Rows.Count > 0)
                                        {
                                            if (dsdeptattachmentsfire.Tables[3].Rows[0]["Description"] == "Combined site plan")
                                            {
                                                webvo.docapplicationform = dsdeptattachmentsfire.Tables[3].Rows[0]["Filepath"].ToString();
                                            }
                                        }

                                    }
                                    string outputnala = nalaservice.GetLandConversionTransactionNo(webvo.UserId, webvo.Password, webvo.LogindID, webvo.ServiceID, webvo.AddressFlag, webvo.UIDNumber, webvo.ApplicantName,
          webvo.Relation, webvo.FatherName, webvo.Gender, webvo.DateOfBirth, webvo.PermanentDoorNo, webvo.PermanentLocality, webvo.PermanentDistrict, webvo.PermanentMandal, webvo.PermanentVillage,
          webvo.PermanentPincode, webvo.PostalDoorNo, webvo.PostalLocality, webvo.StateId, webvo.PostalDistrict, webvo.PostalMandal, webvo.PostalVillage, webvo.PostalPincode, webvo.MobileNo,
          webvo.PhoneNo, webvo.EmailID, webvo.Remarks, webvo.RationCardNo, webvo.AadhaarNo, webvo.DeliveryType, webvo.Doc_District, webvo.Doc_Mandal, webvo.Doc_Village, webvo.Purpose,
          webvo.ServiceCharge, webvo.UserCharge, webvo.PostalCharge, webvo.TotalAmount, webvo.GridDetails, webvo.QuestionaireId, webvo.EntrepreneurId, webvo.docapplicationform, webvo.landrelated, webvo.certificateform, webvo.idproof);
                                    StringReader str = new StringReader(outputnala);
                                    DataSet dsout = new DataSet();
                                    dsout.ReadXml(str);
                                    if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsout.Tables[0].Columns.Contains("ResponseCode"))
                                        {
                                            if (dsout.Tables[0].Rows[0]["ResponseCode"].ToString() == "100")
                                            {
                                                string cclaout = dsout.Tables[0].Rows[0]["ResponseCode"].ToString() + ',' + dsout.Tables[0].Rows[0]["ResponseDesc"].ToString();
                                                Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", cclaout, "Y");
                                                int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), webvo.QuestionaireId.ToString(), webvo.UIDNumber, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                            }
                                            else
                                            {
                                                string cclaouterror = dsout.Tables[0].Rows[0]["ResponseCode"].ToString() + ',' + dsout.Tables[0].Rows[0]["ResponseDesc"].ToString();
                                                Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", cclaouterror, "N");
                                            }
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "47")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                LabourService.act labouract = new LabourService.act();
                                LabourService.actsResponse labourout = new LabourService.actsResponse();
                                LabourService.contractLabourPrincipalEmployer contractvo = new LabourService.contractLabourPrincipalEmployer();
                                LabourService.buildingotherconstructions labour = new LabourService.buildingotherconstructions();
                                LabourService.ismwPrincipalEmployer migrateemployer = new LabourService.ismwPrincipalEmployer();

                                string actids = "";
                                string actid = "";
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();

                                    string[] split = actids.Split(',');
                                    if (actids.Contains("2"))//The Buildings & Other Construction Workers Act
                                    {
                                        labouract.buildingRegistrationActSelected = true;
                                        labour.actID = dsdept.Tables[0].Rows[0]["actID"].ToString();
                                        labour.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                        labour.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        labour.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                        labour.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                        labour.compound_fee = 0;// dsdept.Tables[0].Columns[""].ToString();
                                        labour.date_commencement = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        labour.date_completion = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                        labour.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                        labour.establishment_full_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                        labour.establishment_name = dsdept.Tables[0].Rows[0]["NAME"].ToString();
                                        labour.establishment_permanent_district = dsdept.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                                        labour.establishment_permanent_door = dsdept.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();
                                        labour.establishment_permanent_mandal = dsdept.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                                        labour.establishment_permanent_pincode = dsdept.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();
                                        labour.establishment_permanent_village = dsdept.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();
                                        labour.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                        labour.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                        labour.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                        labour.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                        labour.establishment_postal_pincode = dsdept.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                                        labour.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                        labour.manager_agent_designation = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
                                        labour.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                        labour.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                        labour.manager_agent_email = dsdept.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
                                        labour.manager_agent_fathername = dsdept.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                                        labour.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                        labour.manager_agent_mobile = dsdept.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
                                        labour.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                        labour.manager_agent_street = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                                        labour.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                        labour.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                        labour.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                        labour.other_attachments_1 = "";//dsdept.Tables[0].Columns["other_attachments_1"].ToString();
                                        labour.other_attachments_2 = "";// dsdept.Tables[0].Columns["other_attachments_2"].ToString();
                                        labour.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                        labour.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                        labour.penality_percentage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                                        labour.penality_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                                        labour.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                        labour.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                        labour.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        labour.registration_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_years"].ToString());
                                        labour.stageID = dsdept.Tables[0].Rows[0]["stageID"].ToString();
                                        labour.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                        labour.total_penality_amount = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_penality_amount"].ToString());
                                        labour.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_registration_fee"].ToString());
                                        labour.totalAmount = dsdept.Tables[0].Rows[0]["totalAmount"].ToString();
                                        labour.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                        labour.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        labour.transaction_status = "Y";
                                        labour.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                        //labour.tsipassApplicationID = dsdept.Tables[0].Rows[0]["tsipassApplicationID"].ToString();
                                        labour.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                        labour.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                        labour.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                        labour.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        labour.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                        labouract.buildingRegistrationActData = labour;

                                        labourout = labourservice.actSelected(labouract);
                                        if (labourout.status == "SUCCESS")
                                        {
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), labour.uID, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labourouterrormsg, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "48")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                LabourService.act labouract = new LabourService.act();
                                LabourService.actsResponse labourout = new LabourService.actsResponse();
                                LabourService.contractLabourPrincipalEmployer contractvo = new LabourService.contractLabourPrincipalEmployer();
                                LabourService.buildingotherconstructions labour = new LabourService.buildingotherconstructions();
                                LabourService.ismwPrincipalEmployer migrateemployer = new LabourService.ismwPrincipalEmployer();



                                string actids = "";
                                string actid = "";
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                                    string[] split = actids.Split(',');
                                    if (actids.Contains("3"))//The Contract Labour Act (Principal Employer)
                                    {

                                        labouract.contractLabourPrincipalEmplyerActSelected = true;
                                        contractvo.actID = "CPF";
                                        contractvo.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                        contractvo.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        contractvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                        contractvo.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                        contractvo.compound_fee = 0;
                                        contractvo.employees_attachement = "";//dsdept.Tables[0].Rows[0][""].ToString();
                                        contractvo.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                        contractvo.establishment_category = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                                        contractvo.establishment_category_others = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                                        contractvo.establishment_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                        contractvo.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                        contractvo.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                        contractvo.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                        contractvo.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                        contractvo.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                        contractvo.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                        contractvo.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                        contractvo.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                        contractvo.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                        contractvo.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                        contractvo.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                        contractvo.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                        contractvo.other_attachments_1 = "";
                                        contractvo.other_attachments_2 = "";
                                        contractvo.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                        contractvo.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                        contractvo.penality_percentage = 0;//Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                                        contractvo.penality_years = 0;//Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                                        //contractvo.previous_registered_act = dsdept.Tables[0].Rows[0][""].ToString();
                                        //contractvo.previous_registration_certificate = dsdept.Tables[0].Rows[0][""].ToString();
                                        //contractvo.previous_registration_no = dsdept.Tables[0].Rows[0][""].ToString();
                                        contractvo.principal_employer_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                                        contractvo.principal_employer_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                                        contractvo.principal_employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                                        contractvo.principal_employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                                        contractvo.principal_employer_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                                        contractvo.principal_employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                                        contractvo.principal_employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                                        contractvo.principal_employer_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                                        contractvo.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                        contractvo.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                        contractvo.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        contractvo.registration_years = 0;
                                        contractvo.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                        contractvo.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                        contractvo.total_penality_amount = 0;
                                        contractvo.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        contractvo.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                                        contractvo.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                        contractvo.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        contractvo.transaction_status = "Y";//dsdept.Tables[0].Rows[0][""].ToString();
                                        contractvo.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                        contractvo.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        //contractvo.tsipassApplicationID = dsdept.Tables[0].Rows[0][""].ToString();
                                        contractvo.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                        contractvo.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                        contractvo.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                        contractvo.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        contractvo.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();

                                        LabourService.contractLabourPrincipalEmployerMultiData[] contractmulti = null;

                                        //contractvo.contractorParticulars[] lstitem = null;
                                        ContractorDetails co = new ContractorDetails();
                                        //FactoryService.rawMaterial[] lst = null;
                                        if (dsdept.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtraw = new DataTable();
                                            dtraw = dsdept.Tables[1];
                                            contractmulti = new LabourService.contractLabourPrincipalEmployerMultiData[dtraw.Rows.Count];

                                            for (int k = 0; k < dtraw.Rows.Count; k++)
                                            {
                                                //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                                LabourService.contractLabourPrincipalEmployerMultiData coc = new LabourService.contractLabourPrincipalEmployerMultiData();
                                                coc.contractorAddress = dtraw.Rows[k]["Contractor_Address"].ToString();
                                                coc.commencementDate = dtraw.Rows[k]["Contractor_Est_Commence_Dt"].ToString();
                                                coc.terminationDate = dtraw.Rows[k]["Contractor_Est_Compltd_Dt"].ToString();
                                                //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                                coc.contractorName = dtraw.Rows[k]["Contractor_Name"].ToString();
                                                coc.maxcontractLabour = dtraw.Rows[k]["Contractor_MaxWorkers"].ToString();
                                                coc.natureOfWork = dtraw.Rows[k]["Contractor_Work_Nature"].ToString();
                                                coc.manufacturingDeptDetails = dtraw.Rows[k]["Contractor_ManufacturingDepts"].ToString();
                                                contractmulti[k] = coc;
                                                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                            }
                                            contractvo.contractorParticulars = contractmulti;
                                            //rawvo.materialDescr
                                        }

                                        labouract.contractLabourPrincipalEmplyerActData = contractvo;
                                        labourout = labourservice.actSelected(labouract);
                                        if (labourout.status == "SUCCESS")
                                        {
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), contractvo.uID, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labourouterrormsg, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "49")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                LabourService.act labouract = new LabourService.act();
                                LabourService.actsResponse labourout = new LabourService.actsResponse();
                                LabourService.contractLabourPrincipalEmployer contractvo = new LabourService.contractLabourPrincipalEmployer();
                                LabourService.buildingotherconstructions labour = new LabourService.buildingotherconstructions();
                                LabourService.ismwPrincipalEmployer migrateemployer = new LabourService.ismwPrincipalEmployer();

                                string actids = "";
                                string actid = "";
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                                    string[] split = actids.Split(',');

                                    if (actids.Contains("4"))//Principal Employer Registration Under InterState Migrant Workman Act
                                    {
                                        labouract.interstateMigrantPrincipalEmplyerActSelected = true;
                                        migrateemployer.actID = "ISMWPEF";
                                        migrateemployer.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                        migrateemployer.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        migrateemployer.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                        migrateemployer.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                        migrateemployer.compound_fee = 0;
                                        migrateemployer.director_district = dsdept.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString();
                                        migrateemployer.director_door = dsdept.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString();
                                        migrateemployer.director_mandal = dsdept.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                                        migrateemployer.director_name = dsdept.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString();
                                        migrateemployer.director_village = dsdept.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString();
                                        migrateemployer.employees_attachement = "";
                                        migrateemployer.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                        migrateemployer.establishment_category = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                                        migrateemployer.establishment_category_others = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                                        migrateemployer.establishment_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                        migrateemployer.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                        migrateemployer.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                        migrateemployer.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                        migrateemployer.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                        migrateemployer.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                        migrateemployer.ipass_status_id = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                        migrateemployer.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                        migrateemployer.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                        migrateemployer.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                        migrateemployer.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                        migrateemployer.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                        migrateemployer.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                        migrateemployer.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                        migrateemployer.other_attachments_1 = "";
                                        migrateemployer.other_attachments_2 = "";
                                        migrateemployer.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                        migrateemployer.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                        migrateemployer.penality_percentage = 0;
                                        migrateemployer.penality_years = 0;
                                        migrateemployer.previous_registered_act = "";
                                        migrateemployer.previous_registration_certificate = "";
                                        migrateemployer.previous_registration_no = "";
                                        migrateemployer.principal_employer_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                                        migrateemployer.principal_employer_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                                        migrateemployer.principal_employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                                        migrateemployer.principal_employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                                        migrateemployer.principal_employer_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                                        migrateemployer.principal_employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                                        migrateemployer.principal_employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                                        migrateemployer.principal_employer_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                                        migrateemployer.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                        migrateemployer.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                        migrateemployer.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        migrateemployer.registration_years = 0;
                                        migrateemployer.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                        migrateemployer.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                        migrateemployer.total_penality_amount = 0;
                                        migrateemployer.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        migrateemployer.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                                        migrateemployer.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                        migrateemployer.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        migrateemployer.transaction_status = "Y";
                                        migrateemployer.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                        migrateemployer.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        migrateemployer.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                        migrateemployer.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                        migrateemployer.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                        migrateemployer.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        migrateemployer.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();

                                        LabourService.ismwPrincipalEmployerMultiData[] migrantvo = null;
                                        ContractorDetails co = new ContractorDetails();
                                        //FactoryService.rawMaterial[] lst = null;
                                        if (dsdept.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtraw = new DataTable();
                                            dtraw = dsdept.Tables[1];
                                            migrantvo = new LabourService.ismwPrincipalEmployerMultiData[dtraw.Rows.Count];

                                            for (int k = 0; k < dtraw.Rows.Count; k++)
                                            {
                                                //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                                LabourService.ismwPrincipalEmployerMultiData coc = new LabourService.ismwPrincipalEmployerMultiData();
                                                coc.contractorAddress = dtraw.Rows[k]["Contractor_Address"].ToString();
                                                coc.commencementDate = dtraw.Rows[k]["Contractor_Est_Commence_Dt"].ToString();
                                                coc.terminationDate = dtraw.Rows[k]["Contractor_Est_Compltd_Dt"].ToString();
                                                //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                                coc.contractorName = dtraw.Rows[k]["Contractor_Name"].ToString();
                                                coc.maxcontractLabour = dtraw.Rows[k]["Contractor_MaxWorkers"].ToString();
                                                coc.natureOfWork = dtraw.Rows[k]["Contractor_Work_Nature"].ToString();
                                                coc.manufacturingDeptDetails = dtraw.Rows[k]["Contractor_ManufacturingDepts"].ToString();
                                                coc.mobileNo = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                                migrantvo[k] = coc;
                                                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                            }
                                            migrateemployer.contractorParticulars = migrantvo;
                                            //rawvo.materialDescr
                                        }

                                        labouract.interstateMigrantPrincipalEmplyerActData = migrateemployer;
                                        labourout = labourservice.actSelected(labouract);
                                        if (labourout.status == "SUCCESS")
                                        {
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), migrateemployer.uID, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labourouterrormsg, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "58")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                //LabourServicetest.act labouract = new LabourServicetest.act();
                                //LabourServicetest.actsResponse labourout = new LabourServicetest.actsResponse();                                
                                //LabourServicetest.ismwContractor ismwContractorvo = new LabourServicetest.ismwContractor();

                                LabourService.act labouract = new LabourService.act();
                                LabourService.actsResponse labourout = new LabourService.actsResponse();
                                LabourService.ismwContractor ismwContractorvo = new LabourService.ismwContractor();

                                string actids = "";
                                string actid = "";
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                                    string[] split = actids.Split(',');

                                    if (actids.Contains("4"))//Principal Employer Registration Under InterState Migrant Workman Act
                                    {
                                        labouract.interstateMigrantContractorActSelected = true;
                                        ismwContractorvo.actID = "ISMWCOF";
                                        ismwContractorvo.age = dsdept.Tables[0].Rows[0]["Form_1_5_Age"].ToString();
                                        ismwContractorvo.agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                        ismwContractorvo.agent_door_no = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                        ismwContractorvo.agent_locality = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                                        ismwContractorvo.agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                        ismwContractorvo.agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                        ismwContractorvo.agent_pin_no = "";// dsdept.Tables[0].Rows[0][""].ToString();
                                        ismwContractorvo.agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                        ismwContractorvo.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                        ismwContractorvo.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        ismwContractorvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                        ismwContractorvo.certificate = dsdept.Tables[0].Rows[0]["Form_1_5_Establishment_Number"].ToString();
                                        ismwContractorvo.certificate_date = dsdept.Tables[0].Rows[0]["Form_1_5_Establishment_Date"].ToString();
                                        ismwContractorvo.certificate_number = dsdept.Tables[0].Rows[0]["Form_1_5_Establishment_Number"].ToString();
                                        ismwContractorvo.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                        ismwContractorvo.compound_fee = 0;
                                        ismwContractorvo.contractor_convicted = dsdept.Tables[0].Rows[0]["Form_1_5_Contractor_convicted_flag"].ToString();
                                        ismwContractorvo.contractor_convicted_details = dsdept.Tables[0].Rows[0]["Form_1_5_Contractor_convicted"].ToString();
                                        ismwContractorvo.contractor_district = dsdept.Tables[0].Rows[0]["Form_1_5_contr_District"].ToString();
                                        ismwContractorvo.contractor_door_no = dsdept.Tables[0].Rows[0]["Form_1_5_contr_Doorno"].ToString();
                                        ismwContractorvo.contractor_email = dsdept.Tables[0].Rows[0]["Form_1_5_contr_Email"].ToString();
                                        ismwContractorvo.contractor_father_name = dsdept.Tables[0].Rows[0]["Form_1_5_contr_Fname"].ToString();
                                        ismwContractorvo.contractor_has_worked = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                        ismwContractorvo.contractor_locality = dsdept.Tables[0].Rows[0]["Form_1_5_contr_Locality"].ToString();

                                        ismwContractorvo.contractor_mandal = dsdept.Tables[0].Rows[0]["Form_1_5_contr_Mandal"].ToString();
                                        ismwContractorvo.contractor_mobile = dsdept.Tables[0].Rows[0]["Form_1_5_contr_Mobile"].ToString();
                                        ismwContractorvo.contractor_name = dsdept.Tables[0].Rows[0]["Form1_5_contr_Firm"].ToString();
                                        ismwContractorvo.contractor_otherstate_address = dsdept.Tables[0].Rows[0]["Form_1_5_contr_Othr_St_Address"].ToString();
                                        ismwContractorvo.contractor_pin_no = dsdept.Tables[0].Rows[0]["Form_1_5_contr_Pincode"].ToString();
                                        ismwContractorvo.contractor_revoked_suspended = dsdept.Tables[0].Rows[0]["Form_1_5_Contractor_anyorder_flag"].ToString();
                                        ismwContractorvo.contractor_revoked_suspended_date = dsdept.Tables[0].Rows[0]["Form_1_5_Contractor_anyorder"].ToString();
                                        ismwContractorvo.contractor_village = dsdept.Tables[0].Rows[0]["Form_1_5_contr_Village"].ToString();
                                        ismwContractorvo.contractor_worked_details = "";// dsdept.Tables[0].Rows[0][""].ToString();
                                        ismwContractorvo.commencement_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        ismwContractorvo.end_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                        ismwContractorvo.date_of_birth = dsdept.Tables[0].Rows[0]["Form_1_5_Dob"].ToString();
                                        ismwContractorvo.employees_attachement = dsdept.Tables[0].Rows[0]["Form_1_5_Contractor_PERCFileName"].ToString();
                                        ismwContractorvo.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                        ismwContractorvo.establishment_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                        ismwContractorvo.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                        ismwContractorvo.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                        ismwContractorvo.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                        ismwContractorvo.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                        ismwContractorvo.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                        ismwContractorvo.ipass_status_id = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                        ismwContractorvo.form_V = dsdept.Tables[0].Rows[0]["Form_1_5_Contractor_PEFVFileName"].ToString();
                                        ismwContractorvo.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                        ismwContractorvo.nature_work = dsdept.Tables[0].Rows[0]["Form_1_5_Contractor_anyestablish_flag"].ToString();
                                        ismwContractorvo.number_migrantworkers = dsdept.Tables[0].Rows[0]["InterStateContractWorker"].ToString();
                                        ismwContractorvo.other_attachments_1 = "";
                                        ismwContractorvo.other_attachments_2 = "";
                                        ismwContractorvo.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                        ismwContractorvo.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                        ismwContractorvo.penality_percentage = 0;
                                        ismwContractorvo.penality_years = 0;
                                        ismwContractorvo.principal_employer_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                                        ismwContractorvo.principal_employer_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                                        ismwContractorvo.principal_employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                                        ismwContractorvo.principal_employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                                        ismwContractorvo.principal_employer_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                                        ismwContractorvo.principal_emp_otherstate_address = "";// dsdept.Tables[0].Rows[0][""].ToString();
                                        ismwContractorvo.principal_employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                                        ismwContractorvo.principal_employer_pincode = "";// dsdept.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                                        ismwContractorvo.principal_employer_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                                        ismwContractorvo.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                        ismwContractorvo.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                        ismwContractorvo.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        ismwContractorvo.registration_years = 0;
                                        ismwContractorvo.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                        ismwContractorvo.security_amount = dsdept.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_Amountpaid"].ToString();
                                        ismwContractorvo.security_challan = dsdept.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_ChallanFileName"].ToString();
                                        ismwContractorvo.security_challan_no = dsdept.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_ChallanNo"].ToString();
                                        //ismwContractorvo.
                                        ismwContractorvo.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                        ismwContractorvo.total_penality_amount = 0;
                                        ismwContractorvo.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        ismwContractorvo.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                                        ismwContractorvo.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                        ismwContractorvo.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        ismwContractorvo.transaction_status = "Y";
                                        ismwContractorvo.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                        ismwContractorvo.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        ismwContractorvo.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                        ismwContractorvo.type_of_business = dsdept.Tables[0].Rows[0]["Form_1_5_Type_of_Bussiness"].ToString();
                                        ismwContractorvo.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                        ismwContractorvo.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                        ismwContractorvo.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        ismwContractorvo.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();


                                        labouract.interstateMigrantContractorActData = ismwContractorvo;
                                        //labourout = LabourServicetest.actSelected(labouract);
                                        labourout = labourservice.actSelected(labouract);

                                        if (labourout.status == "SUCCESS")
                                        {
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), ismwContractorvo.uID, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labourouterrormsg, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "8")// FIRE
                        {
                            try
                            {
                                ServicePointManager.Expect100Continue = true;
                                ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                                SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                                string valuefire = "";
                                string outputfire = "";
                                string fireattachments = "";
                                string outapplicant = "";
                                string outapplicant1 = "";
                                string outescapre = "";
                                DataSet dsdept = new DataSet();
                                DataSet dsfire = new DataSet();
                                DataSet dsfireescape = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                valuefire = dsdept.GetXml();
                                string output = fire.InsertApplicantFireDetails(valuefire);
                                string[] split = output.Split('-');
                                string applid = split[1];
                                dsfire = Gen.getfiremeanofescapedetailsonuid(UIDNO, applid);
                                if (dsfire != null && dsfire.Tables.Count > 0 && dsfire.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtfire = new DataTable();
                                    DataTable dtfirenew = new DataTable();
                                    dtfire = dsfire.Tables[1];
                                    dtfirenew = dsfire.Tables[2];
                                    dsfire.Tables.Remove(dtfire);
                                    dsfire.Tables.Remove(dtfirenew);
                                    string fireescape = "";
                                    fireescape = dsfire.GetXml();
                                    outescapre = fire.StoreMeansOfEscape(fireescape);
                                }
                                DataSet dsfire1 = new DataSet();
                                dsfire1 = Gen.getfiremeanofescapedetailsonuid(UIDNO, applid);
                                if (dsfire1 != null && dsfire1.Tables.Count > 0 && dsfire1.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtfire1 = new DataTable();
                                    DataTable dtfire1new = new DataTable();
                                    dtfire1 = dsfire1.Tables[0];
                                    dtfire1new = dsfire1.Tables[2];
                                    dsfire1.Tables.Remove(dtfire1);
                                    dsfire1.Tables.Remove(dtfire1new);

                                    string fireapplicant = "";
                                    fireapplicant = dsfire1.GetXml();
                                    outapplicant = fire.StoreFloorwiseApplicantDtls(fireapplicant);
                                }
                                DataSet dsfire2 = new DataSet();
                                dsfire2 = Gen.getfiremeanofescapedetailsonuid(UIDNO, applid);
                                if (dsfire2 != null && dsfire2.Tables.Count > 0 && dsfire2.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtfire2 = new DataTable();
                                    DataTable dtfire2new = new DataTable();
                                    dtfire2 = dsfire2.Tables[1];
                                    dtfire2new = dsfire2.Tables[0];
                                    dsfire2.Tables.Remove(dtfire2);
                                    dsfire2.Tables.Remove(dtfire2new);

                                    string firefight = "";
                                    firefight = dsfire2.GetXml();
                                    outapplicant1 = fire.StoreFireFightingInstallations(firefight);
                                }

                                DataSet dsdeptattachmentsfire = new DataSet();
                                dsdeptattachmentsfire = Gen.getattachmentdetailsonuid(UIDNO, deptid, applid);
                                fireattachments = dsdeptattachmentsfire.GetXml();
                                outputfire = fire.StoreUploadDocuments(fireattachments);
                                //StringReader str1 = new StringReader(outputfire);
                                //DataSet dsout1 = new DataSet();
                                //dsout1.ReadXml(str1);
                                if (split[0] == "Success" && outescapre == "Success" && outapplicant == "Success" && outapplicant1 == "Success" && outputfire == "Success")
                                {
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "A", outapplicant, "Y");
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", outapplicant, "Y");
                                    int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["QuestionnaireId"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                }
                                else
                                {
                                    string outputerror = split[0].ToString() + ',' + outescapre + ',' + outapplicant + ',' + outapplicant1 + ',' + outputfire;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", outputerror, "N");
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "4" || deptid == "41")//NPDCL
                        {
                            try
                            {
                                string valueNPDCL = "";
                                string outputnpdcl = "";
                                string npdclattachments = "";
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                valueNPDCL = dsdept.GetXml();
                                outputnpdcl = tsnpdcl.insertTsipassUidDetaisls(valueNPDCL);
                                StringReader str = new StringReader(outputnpdcl);
                                DataSet dsout = new DataSet();
                                dsout.ReadXml(str);
                                if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
                                {
                                    if (dsout.Tables[0].Columns.Contains("status"))
                                    {
                                        if (dsout.Tables[0].Rows[0]["status"].ToString() == "S")
                                        {
                                            string npdclout = dsout.Tables[0].Rows[0]["status"].ToString();
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", npdclout, "Y");
                                        }
                                        else
                                        {
                                            string npdclouterror = dsout.Tables[0].Rows[0]["status"].ToString();
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", npdclouterror, "N");
                                        }
                                    }
                                }
                                dsdeptattachments = Gen.getattachmentdetailsonuid(UIDNO, deptid, "");
                                npdclattachments = dsdeptattachments.GetXml();
                                outputnpdcl = tsnpdcl.insertAllAttachments(npdclattachments);
                                StringReader str1 = new StringReader(outputnpdcl);
                                DataSet dsout1 = new DataSet();
                                dsout1.ReadXml(str1);
                                if (dsout1 != null && dsout1.Tables.Count > 0 && dsout1.Tables[0].Rows.Count > 0)
                                {
                                    if (dsout1.Tables[0].Columns.Contains("status"))
                                    {
                                        if (dsout1.Tables[0].Rows[0]["status"].ToString() == "S")
                                        {
                                            string npdclsattachment = dsout1.Tables[0].Rows[0]["status"].ToString();
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "A", npdclsattachment, "Y");
                                            int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["deptId"].ToString(), dsdept.Tables[0].Rows[0]["questionniareId"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                        }
                                        else
                                        {
                                            string npdclsattachmenterror = dsout1.Tables[0].Rows[0]["status"].ToString();
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "A", npdclsattachmenterror, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "25") // SPDCL
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                string valuesPDCL = "";
                                string outputspdcl = "";
                                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                valuesPDCL = dsdept.GetXml();
                                outputspdcl = tsspdcl.setPowerRegistration(valuesPDCL);
                                StringReader str = new StringReader(outputspdcl);
                                DataSet dsout = new DataSet();
                                dsout.ReadXml(str);
                                if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
                                {
                                    if (dsout.Tables[0].Columns.Contains("RESULT"))
                                    {
                                        if (dsout.Tables[0].Rows[0]["RESULT"].ToString() == "Success")
                                        {
                                            string spdcloutmsg = dsout.Tables[0].Rows[0]["RESULT"].ToString();
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", spdcloutmsg, "Y");
                                            int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                        }
                                        else
                                        {
                                            string spdcloutmsgerror = dsout.Tables[0].Rows[0]["RESULT"].ToString();
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", spdcloutmsgerror, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }


                        if (deptid == "21" || deptid == "5" || deptid == "44")//FACTORIES
                        {
                            try
                            {
                                FactoryService.plan factoryvo = new FactoryService.plan();
                                FactoryService.rawMaterial rawvo = new FactoryService.rawMaterial();


                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    valuefactory = dsdept.GetXml();
                                    //outputfactory = factory.insertIntoPlanApproval(factoryvo);
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
                                    factoryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                    factoryvo.factoryDistrictID = dsdept.Tables[0].Rows[0]["Land_intDistrictid"].ToString();
                                    factoryvo.factoryLocality = dsdept.Tables[0].Rows[0]["Name_Gramapachayat"].ToString();
                                    factoryvo.factoryDoorNumber = dsdept.Tables[0].Rows[0]["SurveyNo"].ToString();
                                    factoryvo.factoryMandalID = dsdept.Tables[0].Rows[0]["Land_intMandalid"].ToString();
                                    factoryvo.factoryName = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                                    factoryvo.factoryPinCode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                                    factoryvo.factoryVillageID = dsdept.Tables[0].Rows[0]["Land_intVillageid"].ToString();
                                    factoryvo.hazardousNature = dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                                    factoryvo.installedHP = dsdept.Tables[0].Rows[0]["Connect_Load_B"].ToString();
                                    factoryvo.mailID = dsdept.Tables[0].Rows[0]["Land_Email"].ToString();
                                    factoryvo.mobileNumber = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                                    factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    factoryvo.planReferenceNumber = "NA";//dsdept.Tables[0].Columns[""].ToString();
                                    factoryvo.planType = dsdept.Tables[0].Rows[0]["ProposalFor"].ToString();
                                    factoryvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                    factoryvo.ssiType = "0";// dsdept.Tables[0].Columns[""].ToString();
                                    factoryvo.systemIP = "0.0.0.0";// dsdept.Tables[0].Columns[""].ToString();
                                    factoryvo.userID = dsdept.Tables[0].Rows[0]["CREATEDBY"].ToString();
                                    factoryvo.workersToBeEmployedMen = dsdept.Tables[0].Rows[0]["DirectMale"].ToString();
                                    factoryvo.workersToBeEmployedWomen = dsdept.Tables[0].Rows[0]["DirectFemale"].ToString();

                                    FactoryService.rawMaterial[] lst = null;
                                    if (dsdept.Tables[1].Rows.Count > 0)
                                    {
                                        DataTable dtraw = new DataTable();
                                        dtraw = dsdept.Tables[1];
                                        lst = new FactoryService.rawMaterial[dtraw.Rows.Count];

                                        for (int k = 0; k < dtraw.Rows.Count; k++)
                                        {
                                            FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                            BBB.materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                            lst[k] = BBB;
                                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                        }
                                        //rawvo.materialDescr
                                    }

                                    factoryvo.rawMaterials = lst;

                                    FactoryService.productsOutput[] product = null;
                                    if (dsdept.Tables[1].Rows.Count > 0)
                                    {
                                        DataTable dtproduct = new DataTable();
                                        dtproduct = dsdept.Tables[2];
                                        product = new FactoryService.productsOutput[dtproduct.Rows.Count];

                                        for (int m = 0; m < dtproduct.Rows.Count; m++)
                                        {
                                            FactoryService.productsOutput productvo = new FactoryService.productsOutput();
                                            productvo.product = dtproduct.Rows[m]["Manf_ItemName"].ToString();
                                            productvo.output = dtproduct.Rows[m]["OUTPUT"].ToString();
                                            product[m] = productvo;
                                        }
                                    }

                                    factoryvo.productsOutputs = product;

                                    FactoryService.saleLeaseDeed[] registrationdeed = null;
                                    FactoryService.sitePlan[] siteplan = null;
                                    FactoryService.buildingPlan[] buildingplan = null;
                                    FactoryService.partnershipDeed[] partnershipdeed = null;
                                    FactoryService.processFlowChart[] flowchat = null;
                                    FactoryService.panAadharCard[] panaadhar = null;
                                    FactoryService.additionalAttachment[] AdditionalAttachment = null;
                                    //factory.insertIntoPlanApprovalCompleted factoryoutput = new FactoryService.insertIntoPlanApprovalCompletedEventHandler();


                                    DataSet dsfactroy = new DataSet();
                                    dsfactroy = Gen.getattachmentdetailsonuid(UIDNO, deptid, "");

                                    if (dsfactroy != null && dsfactroy.Tables.Count > 0 && dsfactroy.Tables[0].Rows.Count > 0)
                                    {
                                        ///Registration Deed////

                                        if (dsfactroy.Tables[0].Rows.Count > 0)
                                        {
                                            DataTable dtregistrationdeed = new DataTable();
                                            dtregistrationdeed = dsfactroy.Tables[0];
                                            registrationdeed = new FactoryService.saleLeaseDeed[dtregistrationdeed.Rows.Count];

                                            for (int n = 0; n < dtregistrationdeed.Rows.Count; n++)
                                            {
                                                FactoryService.saleLeaseDeed registrationdeedvo = new FactoryService.saleLeaseDeed();
                                                registrationdeedvo.documentName = dtregistrationdeed.Rows[n]["FileName"].ToString();
                                                registrationdeedvo.documentPath = dtregistrationdeed.Rows[n]["Filepath"].ToString();
                                                registrationdeed[n] = registrationdeedvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtsiteplan = new DataTable();
                                            dtsiteplan = dsfactroy.Tables[1];
                                            siteplan = new FactoryService.sitePlan[dtsiteplan.Rows.Count];

                                            for (int o = 0; o < dtsiteplan.Rows.Count; o++)
                                            {
                                                FactoryService.sitePlan siteplanvo = new FactoryService.sitePlan();
                                                siteplanvo.documentName = dtsiteplan.Rows[o]["FileName"].ToString();
                                                siteplanvo.documentPath = dtsiteplan.Rows[o]["Filepath"].ToString();
                                                siteplan[o] = siteplanvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[2].Rows.Count > 0)
                                        {
                                            DataTable dtbuildingplan = new DataTable();
                                            dtbuildingplan = dsfactroy.Tables[2];
                                            buildingplan = new FactoryService.buildingPlan[dtbuildingplan.Rows.Count];

                                            for (int p = 0; p < dtbuildingplan.Rows.Count; p++)
                                            {
                                                FactoryService.buildingPlan buildingplanvo = new FactoryService.buildingPlan();
                                                buildingplanvo.documentName = dtbuildingplan.Rows[p]["FileName"].ToString();
                                                buildingplanvo.documentPath = dtbuildingplan.Rows[p]["Filepath"].ToString();
                                                buildingplan[p] = buildingplanvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[3].Rows.Count > 0)
                                        {
                                            DataTable dtpartnershipdeed = new DataTable();
                                            dtpartnershipdeed = dsfactroy.Tables[3];
                                            partnershipdeed = new FactoryService.partnershipDeed[dtpartnershipdeed.Rows.Count];

                                            for (int n = 0; n < dtpartnershipdeed.Rows.Count; n++)
                                            {
                                                FactoryService.partnershipDeed partnershipdeedvo = new FactoryService.partnershipDeed();
                                                partnershipdeedvo.documentName = dtpartnershipdeed.Rows[n]["FileName"].ToString();
                                                partnershipdeedvo.documentPath = dtpartnershipdeed.Rows[n]["Filepath"].ToString();
                                                partnershipdeed[n] = partnershipdeedvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[4].Rows.Count > 0)
                                        {
                                            DataTable dtflowchat = new DataTable();
                                            dtflowchat = dsfactroy.Tables[4];
                                            flowchat = new FactoryService.processFlowChart[dtflowchat.Rows.Count];

                                            for (int n = 0; n < dtflowchat.Rows.Count; n++)
                                            {
                                                FactoryService.processFlowChart flowchatvo = new FactoryService.processFlowChart();
                                                flowchatvo.documentName = dtflowchat.Rows[n]["FileName"].ToString();
                                                flowchatvo.documentPath = dtflowchat.Rows[n]["Filepath"].ToString();
                                                flowchat[n] = flowchatvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[5].Rows.Count > 0)
                                        {
                                            DataTable dtpanaadhar = new DataTable();
                                            dtpanaadhar = dsfactroy.Tables[5];
                                            panaadhar = new FactoryService.panAadharCard[dtpanaadhar.Rows.Count];

                                            for (int n = 0; n < dtpanaadhar.Rows.Count; n++)
                                            {
                                                FactoryService.panAadharCard panaadharvo = new FactoryService.panAadharCard();
                                                panaadharvo.documentName = dtpanaadhar.Rows[n]["FileName"].ToString();
                                                panaadharvo.documentPath = dtpanaadhar.Rows[n]["Filepath"].ToString();
                                                panaadhar[n] = panaadharvo;
                                            }
                                        }
                                        if (dsfactroy.Tables[6].Rows.Count > 0)
                                        {
                                            DataTable dtAdditionalAttachment = new DataTable();
                                            dtAdditionalAttachment = dsfactroy.Tables[6];
                                            AdditionalAttachment = new FactoryService.additionalAttachment[dtAdditionalAttachment.Rows.Count];

                                            for (int n = 0; n < dtAdditionalAttachment.Rows.Count; n++)
                                            {
                                                FactoryService.additionalAttachment AdditionalAttachmentvo = new FactoryService.additionalAttachment();
                                                AdditionalAttachmentvo.documentName = dtAdditionalAttachment.Rows[n]["FileName"].ToString();
                                                AdditionalAttachmentvo.documentPath = dtAdditionalAttachment.Rows[n]["Filepath"].ToString();
                                                AdditionalAttachment[n] = AdditionalAttachmentvo;
                                            }
                                        }
                                    }
                                    factoryvo.saleLeaseDeeds = registrationdeed;
                                    factoryvo.sitePlans = siteplan;
                                    factoryvo.buildingPlans = buildingplan;
                                    factoryvo.partnershipDeeds = partnershipdeed;
                                    factoryvo.processFlowCharts = flowchat;
                                    factoryvo.panAadharCards = panaadhar;
                                    factoryvo.additionalAttachments = AdditionalAttachment;

                                    string OUTPUT = factory.insertIntoPlanApproval(factoryvo);
                                    // factory.insertIntoPlanApprovalCompleted 
                                    //factory.insertIntoPlanApproval(factoryvo);
                                    // factory.insertIntoPlanApprovalCompleted = factory.insertIntoPlanApproval(factoryvo);
                                    //factory.insertIntoPlanApprovalCompleted = factory.insertIntoPlanApproval(factoryvo);
                                    if (OUTPUT == "SUCCESS")
                                    {

                                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", OUTPUT, "Y");
                                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "A", OUTPUT, "Y");
                                        int k = Gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", deptid);
                                    }
                                    else
                                    {
                                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", OUTPUT, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                    }


                }
                // additional Payment Dtls
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dtadd = new DataTable();
                    dtadd = ds.Tables[1];
                    for (int i = 0; i < dtadd.Rows.Count; i++)
                    {
                        string deptid = dtadd.Rows[i]["intApprovalid"].ToString();
                        if (deptid == "20")//PCB Additional Amount
                        {
                            DataSet dsdept = new DataSet();

                            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                string cafUniqueNo = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                string transactionId = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                string amount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                                string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                string transactionStatus = "S";
                                string paymentType = "NB";
                                string indApplication = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
                                string additionalPayment = "T";


                                string WEBSERVICE_URL1 = "http://tsocmms.nic.in/TLWS/updateCl?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&remark=" + "AdditionalAmountSubmitted" + "&urlSingle=" + "";

                                try
                                {
                                    var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL1);
                                    if (webRequest != null)
                                    {
                                        webRequest.Method = "GET";
                                        webRequest.Timeout = 20000;
                                        webRequest.ContentType = "application/x-www-form-urlencoded";

                                        //using (System.IO.Stream s = webRequest.GetRequestStream())
                                        //{
                                        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                                        //        sw.Write(jsonData);
                                        //}

                                        using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                                        {
                                            using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                                            {
                                                var jsonResponse = sr.ReadToEnd();
                                                System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
                                                if (jsonResponse.Contains("submitted successfully"))
                                                {
                                                    //Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", jsonResponse, "Y");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    //Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", jsonResponse, "N");
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                                }


                                string WEBSERVICE_URL = "http://tsocmms.nic.in/TLWS/updateFee?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";


                                //string jsonData = "{\"cafUniqueNo\" : \""+cafUniqueNo+"\", \"transactionId\":\""+transactionId+"\" , \"amount\":\""+amount+"\" , \"bankName\":\""+bankName+"\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                //string jsonData = "cafUniqueNo" : \"" + cafUniqueNo + "\", \"transactionId\":\"" + transactionId + "\" , \"amount\":\"" + amount + "\" , \"bankName\":\"" + bankName + "\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                try
                                {
                                    var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                                    if (webRequest != null)
                                    {
                                        webRequest.Method = "GET";
                                        webRequest.Timeout = 20000;
                                        webRequest.ContentType = "application/x-www-form-urlencoded";

                                        //using (System.IO.Stream s = webRequest.GetRequestStream())
                                        //{
                                        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                                        //        sw.Write(jsonData);
                                        //}

                                        using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                                        {
                                            using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                                            {
                                                var jsonResponse = sr.ReadToEnd();
                                                System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
                                                if (jsonResponse.Contains("Fee submitted successfully"))
                                                {
                                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", jsonResponse, "Y");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    //Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", jsonResponse, "N");
                                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", jsonResponse, "N");
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                                }

                            }

                        }
                        if (deptid == "21" || deptid == "5") //FACTORY
                        {
                            try
                            {
                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = Gen.getAdditionalPaymentDetails(UIDNO, deptid);
                                valuefactory = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    FactoryService.planAdditionalPayment factoryvo = new FactoryService.planAdditionalPayment();
                                    factoryvo.applicationID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    factoryvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                    factoryvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    factoryvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    factoryvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    factoryvo.systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    factoryvo.userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
                                    string outfactory = factory.insertIntoPlanApprovalAdditionalPayment(factoryvo);

                                    if (outfactory == "SUCCESS")
                                    {

                                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", outfactory, "Y");

                                    }
                                    else
                                    {
                                        Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", outfactory, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "8")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                dsdept = Gen.getAdditionalPaymentDetails(UIDNO, deptid);
                                string UIDNo = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                string amount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                string date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                string challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                string paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                string systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                //string userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                                string outputfire = fire.PaymentDetails(UIDNo, challanNumber, date, bankName, amount);

                                if (outputfire == "Success")
                                {
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", outputfire, "Y");
                                }
                                else
                                {
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", outputfire, "N");
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "4")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                dsdept = Gen.getAdditionalPaymentDetails(UIDNO, deptid);
                                string npdcl = dsdept.GetXml();

                                string npdclout = tsnpdcl.insertTsipassOnlinePayments(npdcl);
                                StringReader str = new StringReader(npdclout);
                                DataSet dsout = new DataSet();
                                dsout.ReadXml(str);
                                if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
                                {
                                    if (dsout.Tables[0].Columns.Contains("status"))
                                    {
                                        if (dsout.Tables[0].Rows[0]["status"].ToString() == "S")
                                        {
                                            string npdcloutflag = dsout.Tables[0].Rows[0]["status"].ToString();
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", npdclout, "Y");
                                        }
                                        else
                                        {
                                            string npdclouterror = dsout.Tables[0].Rows[0]["status"].ToString();
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", npdclouterror, "Y");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "35")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                dsdept = Gen.getMortgagedetailsonuid(UIDNO, deptid);
                                string hmdapayment = dsdept.GetXml();

                                hmdapplication = hmdaservice.Mortgage(hmdapayment, "$$08@213");
                                if (hmdapplication.ResponseStatus != 0 && hmdapplication.ResponseStatus != 0)
                                {
                                    //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "M", hmdapplication.FileNo, "Y");
                                    //int k = Gen.InsertDeptDateTracing(deptid, dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE");
                                }
                                else
                                {
                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "M", hmdapplication.ErrorMessage, "N");
                                }

                            }
                            catch (Exception ex)
                            {

                            }

                            try
                            {
                                DataSet dsdept = new DataSet();
                                dsdept = Gen.getAdditionalPaymentDetails(UIDNO, deptid);
                                string hmdapayment = dsdept.GetXml();

                                hmdapplication = hmdaservice.DCPayment(hmdapayment, "$$08@213");
                                if (hmdapplication.ResponseStatus != 0 && hmdapplication.ResponseStatus != 0)
                                {
                                    //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", hmdapplication.FileNo, "Y");
                                    //int k = Gen.InsertDeptDateTracing(deptid, dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE");
                                }
                                else
                                {
                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", hmdapplication.ErrorMessage, "N");
                                }

                            }
                            catch (Exception ex)
                            {

                            }
                        }

                        if (deptid == "31")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                dsdept = Gen.getAdditionalPaymentDetails(UIDNO, deptid);
                                string dtcppayment = dsdept.GetXml();
                                tsiicapplication = tsiicservice.DCPayment(dtcppayment, "$$08@213");

                                if (tsiicapplication.ResponseStatus != 0 && tsiicapplication.ResponseStatus != 0)
                                {
                                    //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", tsiicapplication.FileNo, "Y");
                                    //int k = Gen.InsertDeptDateTracing(deptid, dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE");
                                }
                                else
                                {
                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", tsiicapplication.ErrorMessage, "N");
                                }

                            }
                            catch (Exception ex)
                            {

                            }
                            try
                            {
                                DataSet dsdept = new DataSet();
                                dsdept = Gen.getMortgagedetailsonuid(UIDNO, "31");
                                string tsiicdata = dsdept.GetXml();


                                tsiicapplication = tsiicservice.Mortgage(tsiicdata, "$$08@213");
                                if (tsiicapplication.ResponseStatus != 0 && tsiicapplication.ResponseStatus != 0)
                                {
                                    //string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, "31", "M", tsiicapplication.FileNo, "Y");
                                    //int k = Gen.InsertDeptDateTracing(deptid, dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE");
                                }
                                else
                                {
                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                    Gen.UpdateDepartwebserviceflag(UIDNO, "31", "M", tsiicapplication.ErrorMessage, "N");
                                }

                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "25") // SPDCL
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                string valuesPDCL = "";
                                string outputspdcl = "";
                                dsdept = Gen.getAdditionalPaymentDetails(UIDNO, deptid);
                                valuesPDCL = dsdept.GetXml();
                                string UIDNo = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                double amount = Convert.ToDouble(dsdept.Tables[0].Rows[0]["Online_Amount"].ToString());
                                string date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                string challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                string paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                string systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                outputspdcl = tsspdcl.setPayment(UIDNo, amount, true, bankName, challanNumber, date);
                                StringReader strSPDCL = new StringReader(outputspdcl);
                                DataSet dsoutSPDCL = new DataSet();
                                dsoutSPDCL.ReadXml(strSPDCL);
                                if (dsoutSPDCL != null && dsoutSPDCL.Tables.Count > 0 && dsoutSPDCL.Tables[0].Rows.Count > 0)
                                {
                                    if (dsoutSPDCL.Tables[0].Columns.Contains("RESULT"))
                                    {
                                        if (dsoutSPDCL.Tables[0].Rows[0]["RESULT"].ToString() == "Success")
                                        {
                                            string spdcloutmsg = dsoutSPDCL.Tables[0].Rows[0]["RESULT"].ToString();
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", spdcloutmsg, "Y");
                                        }
                                        else
                                        {
                                            string spdcloutmsgerror = dsoutSPDCL.Tables[0].Rows[0]["RESULT"].ToString();
                                            Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", spdcloutmsgerror, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
                //StringBuilder sbScript = new StringBuilder();
                //string sScript;
                //sbScript.Append("<script>");
                //sbScript.Append(" window.close();");
                //sbScript.Append("</script>");

                //sScript = sbScript.ToString();

                //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", sScript, false);
           // }
            // }
        }
        catch (Exception ex)
        {
            //  lblmsg.Text = ex.Message;
            //lblmsg.Visible = true;
        }
    }

    public int updatetodepartments(string intQuessionaireid, string Created_by, string ipaddress, string TSIPASSUID)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("USP_UPD_STAGEID_DEPARTMENTS", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            if (intQuessionaireid == "" || intQuessionaireid == null)
                command.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

            if (ipaddress == "" || ipaddress == null)
                command.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

            if (TSIPASSUID == "" || TSIPASSUID == null)
                command.Parameters.Add("@TSIPASSUID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@TSIPASSUID", SqlDbType.VarChar).Value = TSIPASSUID.Trim();

            if (Created_by == "" || Created_by == null)
                command.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();


            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;


            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }
}