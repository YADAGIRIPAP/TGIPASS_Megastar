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
    string intCFEEntrid = ""; //for MA&UD..
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblHeading.Text = Request.QueryString[1].ToString().Trim();
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {

            fillGrid();
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
        lblHeading.Text = Request.QueryString[1].ToString().Trim();
        lblHeaderlink.Text = Request.QueryString[1].ToString().Trim();
    }

    void fillGrid()   //nikhil --
    {

        DataSet dsn = new DataSet();
        // dsn = Gen.GetShowDepartmentFiles("%");
        // Session["User_Code"] = "1";
        // dsn = Gen.GetShowDepartmentFiles(Session["User_Code"].ToString().Trim());
        //dsn = Gen.GetShowDepartmentFiles("15", "3", "5");

        //dsn = Gen.GetCompletedbyApproval("12", txtFromDate.Text, txtToDate.Text);
        dsn = Gen.GetCompletedbyApproval1HMDA("12", txtFromDate.Text, txtToDate.Text, Session["User_Code"].ToString().Trim(), Request.QueryString[0].ToString().Trim());

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

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        fillGrid();
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

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)   //nikhil--
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Session["Reject"] = "";
            HiddenField oHDFMAUD = new HiddenField();
            oHDFMAUD.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "maudflag")).Trim();
            Button oButton = (Button)e.Row.FindControl("Button1");
            Label oLabel = (Label)e.Row.FindControl("lblMAUDSts");
            if (oHDFMAUD.Value == "Y")
            {
                oButton.Visible = false;
                oLabel.Visible = true;
            }
            else
            {
                oButton.Visible = true;
                oLabel.Visible = false;
            }

            intCFEEntrid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();

            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";

            //intCFEEntrid = e.Row.Cells[1].Text;

            HyperLink h1 = (HyperLink)e.Row.Cells[5].Controls[0];
            Button btnMA = (Button)e.Row.FindControl("btnMAUD");
            //BtnSave.Attributes.Add("onclick", DisableTheButton(this.Page, BtnSave, "group"));

            string fromdate, Todate;
            if (txtFromDate.Text == "" || txtToDate.Text == "")
            {

                fromdate = "%";
                Todate = "%";


                if (Request.QueryString.Count >= 3)
                {
                    //btnMA
                    h1.NavigateUrl = "frmApproveDetailsbyquery.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() + "&apid=" + Request.QueryString[2].ToString().Trim();
                    Session["Reject"] = "Y";
                }
                else
                {
                    h1.NavigateUrl = "frmApproveDetailsbyquery.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                    Session["Reject"] = "Y";
                }
            }
            else
            {
                //  h1.Text = "Send to MA & UD";
                fromdate = txtFromDate.Text;
                Todate = txtToDate.Text;
                if (Request.QueryString.Count >= 3)
                {
                    Session["Reject"] = "Y";
                    h1.NavigateUrl = "frmApproveDetailsbyquery.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() + "&apid=" + Request.QueryString[2].ToString().Trim();
                }
                else
                {
                    h1.NavigateUrl = "frmApproveDetailsbyquery.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                    Session["Reject"] = "Y";
                }

            }

            //    HyperLink h1 = (HyperLink)e.Row.Cells[7].Controls[0];

            //    HyperLink h2 = (HyperLink)e.Row.Cells[8].Controls[0];
            //    HyperLink h3 = (HyperLink)e.Row.Cells[9].Controls[0];
            //    DropDownList ddlStatus = (DropDownList)e.Row.Cells[10].FindControl("ddlStatus");

            //    TextBox txtPromotor = (TextBox)e.Row.Cells[10].FindControl("txtPromotor");

            //    Label Label378 = (Label)e.Row.Cells[10].FindControl("Label378");

            //    HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
            //    hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();

            // HiddenField hdfGroundedNo = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo");

            //hdfGroundedNo.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();



            //    HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");

            //    hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();


            //    HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");

            //    hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();


            //    HiddenField hdfGroundedNo2 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo2");

            //    hdfGroundedNo2.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LastDateofPreScrutiy")).Trim();


            //    HiddenField hdfGroundedNo3 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo3");

            //    hdfGroundedNo3.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStatusid")).Trim();


            //    if (ddlStatus.SelectedValue.ToString() == "8")
            //    {
            //        txtPromotor.Visible = true;
            //        Label378.Visible = true;

            //    }
            //    else
            //    {
            //        txtPromotor.Visible = false;
            //        Label378.Visible = false;


            //    }







            //}


        }

    }
    //protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    DropDownList ddlStatus = (DropDownList)sender;
    //    GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
    //    TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");

    //    Label Label378 = (Label)row.FindControl("Label378");

    //    //DropDownList ddlCorporation1 = (DropDownList)row.FindControl("ddlCorporation");
    //    //DropDownList ddlWard = (DropDownList)row.FindControl("ddlWard");
    //    //GetWards(ddlWard, ddlCorporation1.SelectedValue);

    //    ////DropDownList ddlStatus = (DropDownList).FindControl("ddlStatus");
    //    //Button BtnSave = (Button)sender;
    //    //GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
    //    //DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");


    //    if (ddlStatus.SelectedValue.ToString() == "8")
    //    {
    //        txtPromotor.Visible = true;
    //        Label378.Visible = true;

    //    }

    //    else
    //    {
    //        txtPromotor.Visible = false;
    //        Label378.Visible = false;


    //    }

    //    // if(ddlStatus.)

    //    //if()


    //}
    protected void BtnSave_Click1(object sender, EventArgs e)
    {

        Button BtnSave = (Button)sender;

        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");

        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");

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
            //fai

        }

        int result = 0;
        result = Gen.insertDepartmentProcess(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value, ddlStatus.SelectedValue.ToString(), hdfGroundedNo2.Value, Session["uid"].ToString().Trim());


        if (ddlStatus.SelectedValue.ToString() == "8")
        {

            //  int i= Gen.insertQueryResponsedata(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text,ddlStatus.SelectedValue.ToString(), Session["uid"].ToString());
            int i = 1;

            if (i > 0)
            {

                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Successfully Registered";
                return;

            }


        }

        if (result > 0)
        {


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



        //else if (ddlStatus.SelectedValue.ToString() == "--Select--")
        //{
        //    Failure.Visible = true;

        //    success.Visible = false;

        //    lblmsg.Text = "Please Select Status";


        //}








    }

    // protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    //   {
    //  Button BtnSave = (Button)e.Row.FindControl("Button1");
    // if (e.CommandName== "Send to MA & UD")
    // {

    // Button1.OnClientClick = "javascript:return Popup('hello')";
    // }
    //  btnMAUD.OnClientClick = "javascript:return Popup('hello')";

    // }

    //protected void btnMAUD_click(object sender, EventArgs e)
    // {
    //  Button btn1 = (Button)sender;
    //  GridViewRow row = (GridViewRow)btn1.NamingContainer;


    // }

    protected void Button1_Click(object sender, EventArgs e)   //nikhil --
    {

        //int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

        //LinkButton myTextBox = grdDetails.Rows[indexing].FindControl("LinkButton1") as LinkButton;
        //Button Button1new = grdDetails.Rows[indexing].FindControl("Button1") as Button;

        //string result = Gen.sendMAUD_HMDACLU(myTextBox.Text);
        //Button1new.Enabled = false;

        //int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

        //LinkButton myTextBox = grdDetails.Rows[indexing].FindControl("LinkButton1") as LinkButton;

        //string result = Gen.sendMAUD_HMDACLU(myTextBox.Text);
        //if (result == "success")
        //    fillGrid();

        //int RowId = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
        //string cfeid = grdDetails.Rows[RowId].Cells[8].Text.ToString();

        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
        string cfeid = ((Label)grdDetails.Rows[indexing].FindControl("lblcreatedby")).Text;
        string uidno = ((LinkButton)grdDetails.Rows[indexing].FindControl("LinkButton1")).Text;
        Response.Redirect("HMDAAttachmentsToMAUD.aspx?cfeid=" + cfeid + "&uidno=" + uidno);
       
    }

    protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {


    }
}
