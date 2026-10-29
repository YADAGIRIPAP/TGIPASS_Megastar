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
                dsn = Gen.GetShowDepartmentFilesIndus(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());
                
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
            dsn = Gen.GetShowDepartmentFilesIndusSearchNew(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim(), TxtnameofUnit.Text, TxtnameofUnit0.Text, ddldistrict.SelectedValue.ToString(), FromdateforDB, TodateforDB);

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
            


            h1.Target = "_blank";
            h1.NavigateUrl = "CFEPrint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            h2.Target = "_blank";
            h2.NavigateUrl = "frmViewAttachmentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            h3.Target = "_blank";
            h3.NavigateUrl = "frmQurieResponseStatus.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            h4.Target = "_blank";
            h4.NavigateUrl = "RptPaymentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            DropDownList ddlStatus = (DropDownList)e.Row.Cells[11].FindControl("ddlStatus");

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

        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtPromotor=(TextBox)row.FindControl("txtPromotor");

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
        else if(ddlStatus.SelectedValue.ToString()=="10")
        {
            int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, txtAmount.Text, "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());

        }
        else if (ddlStatus.SelectedValue.ToString() == "12")
        {
            int j = Gen.UpdateAdditionalpayments(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
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
}
