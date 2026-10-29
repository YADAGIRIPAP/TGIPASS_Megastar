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
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }
        if (Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "1213")
        {

        }
        else
        {
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {


            getdistricts();
            //fillGrid();
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }


    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddlLand_intDistrictid.DataSource = dsnew.Tables[0];
        ddlLand_intDistrictid.DataTextField = "District_Name";
        ddlLand_intDistrictid.DataValueField = "District_Id";
        ddlLand_intDistrictid.DataBind();
        ddlLand_intDistrictid.Items.Insert(0, "--Select--");

    }
    void fillGrid()
    {

        DataSet dsn = new DataSet();
        // dsn = Gen.GetShowDepartmentFiles("%");
        // Session["User_Code"] = "1";
        // dsn = Gen.GetShowDepartmentFiles(Session["User_Code"].ToString().Trim());
        //dsn = Gen.GetShowDepartmentFiles("15", "3", "5");

        //dsn = Gen.GetCompletedbyApproval("12", txtFromDate.Text, txtToDate.Text);

        dsn = Gen.getApplicationforpayment(txtnameofUnit.Text, txtUID.Text, ddlLand_intDistrictid.SelectedValue.ToString(), ddlProp_intMandalid.SelectedValue.ToString());

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
        Response.Redirect("frmCFENEFTPayment.aspx");
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
            HyperLink btn = (HyperLink)e.Row.FindControl("hypLetter");

            btn.Text = "Pay";
            btn.NavigateUrl = "frmNEFTlPaymentDetails.aspx?Applid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() + "&crid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Created_by")).Trim();
        }
    }

    protected void ddlLand_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlProp_intMandalid.Items.Clear();
        DataSet dsm = new DataSet();
        dsm = Gen.GetMandals(ddlLand_intDistrictid.SelectedValue);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddlProp_intMandalid.DataSource = dsm.Tables[0];
            ddlProp_intMandalid.DataValueField = "Mandal_Id";
            ddlProp_intMandalid.DataTextField = "Manda_lName";
            ddlProp_intMandalid.DataBind();
            ddlProp_intMandalid.Items.Insert(0, "--Select--");
        }
        else
        {
            ddlProp_intMandalid.Items.Clear();
            ddlProp_intMandalid.Items.Insert(0, "--Select--");
        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdDetails.PageIndex = e.NewPageIndex;
        fillGrid();
    }
}
