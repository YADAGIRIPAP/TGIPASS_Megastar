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
    string DistrictID = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    public void GetDetails()
    {
        try
        {
            if (Request.QueryString.Count > 0)
            {
                rstages = Request.QueryString[0].ToString().Trim();
                DistrictID = Request.QueryString["District"];
                DataSet dsn = new DataSet();
                //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
                //return;
                dsn = Gen.DistrictWiseCerGenDrildownReport(rstages.ToString().Trim(), DistrictID.ToString().Trim());
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
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }

        //if (Request.QueryString.Count > 0)
        //{
        //    if (Request.QueryString[0].ToString().Trim() == "5" || Request.QueryString[0].ToString().Trim() == "6")
        //    {
        //    }
        //    else
        //    {
        //        grdDetails.Columns[10].Visible = false;
        //        grdDetails.Columns[11].Visible = false;
        //        grdDetails.Columns[11].Visible = false;
        //        grdDetails.Columns[12].Visible = false;
        //    }
        //}
        //else
        //{
        //    grdDetails.Columns[10].Visible = false;
        //    grdDetails.Columns[11].Visible = false;

        //    grdDetails.Columns[11].Visible = false;
        //    grdDetails.Columns[12].Visible = false;
        //}


    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            GetDetails();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }

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
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink h1 = (HyperLink)e.Row.Cells[8].Controls[0];

                HyperLink h2 = (HyperLink)e.Row.Cells[9].Controls[0];
                HyperLink h3 = (HyperLink)e.Row.Cells[10].Controls[0];

                HyperLink HyperLink1 = (HyperLink)e.Row.Cells[11].FindControl("HyperLink1");
                HyperLink1.Target = "_blank";
                HyperLink1.NavigateUrl = "CFECertificate.aspx?intCFEEnterpid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() + "&Stage=" + Request.QueryString["Stage"].ToString();

                h1.Target = "_blank";
                h1.NavigateUrl = "ViewCFEPrint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                h2.Target = "_blank";
                h2.NavigateUrl = "frmViewAttachmentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

                h3.Target = "_blank";
                h3.NavigateUrl = "frmQurieResponseStatus.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                DropDownList ddlStatus = (DropDownList)e.Row.Cells[11].FindControl("ddlStatus");

                TextBox txtPromotor = (TextBox)e.Row.Cells[11].FindControl("txtPromotor");

                Label Label378 = (Label)e.Row.Cells[11].FindControl("Label378");

                Label Label379 = (Label)e.Row.Cells[11].FindControl("Label379");
                Label Label377 = (Label)e.Row.Cells[11].FindControl("Label377");

                TextBox txtAmount = (TextBox)e.Row.Cells[11].FindControl("txtAmount");

                Button BtnSave = (Button)e.Row.Cells[12].FindControl("BtnSave");

                HiddenField hdfApplID = (HiddenField)e.Row.Cells[12].FindControl("hdfApplID");
                hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();

                HiddenField hdfGroundedNo = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo");

                hdfGroundedNo.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

                HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo0");

                //   hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();


                HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo1");

                //hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();


                HiddenField hdfGroundedNo2 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo2");

                hdfGroundedNo2.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LastDateofPreScrutiy")).Trim();


                HiddenField hdfGroundedNo3 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo3");

                hdfGroundedNo3.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStatusid")).Trim();


                string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
                LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

                btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();

                btn.OnClientClick = "javascript:return Popup('" + intUid + "')";

                LinkButton btn1 = (LinkButton)e.Row.FindControl("LinkButton2");

                btn1.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Pre-Scrutiny Status")).Trim();

                btn1.OnClientClick = "javascript:return PopupN('" + intUid + "')";





            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }


    }

}
