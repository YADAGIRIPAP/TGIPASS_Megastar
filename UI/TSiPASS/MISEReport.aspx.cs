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
    int cnt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            //  Response.Redirect("~/Index.aspx");
        }


        if (!IsPostBack)
        {
            GetDetails();


        }


    }
    public void GetDetails()
    {





        DataSet dsn = new DataSet();
        //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
        //return;
        //dsn = Gen.GetShowSactionedIncentives(ddlCategory.SelectedValue,txtindustrialName.Text,ddltypeofncentive.SelectedItem.Text.ToString(),txtEMpartnumber.Text);

        // dsn = Gen.GetShowSactionedIncentivesDCIP(ddlCategory.SelectedValue, txtindustrialName.Text, ddltypeofncentive.SelectedItem.Text.ToString(), txtEMpartnumber.Text,ddldistrict.SelectedItem.Text.ToString());
        if (Session["DistrictID"] != null && Session["uid"] != null)
        {
            dsn = Gen.GetMICSDetails(txtNameofUnit.Text, txtEMpartnumber.Text, ddlCategory.SelectedValue.ToString(), ddlCategory0.SelectedValue.ToString(), ddltypeofncentive.SelectedValue.ToString(), ddlCategory1.SelectedValue.ToString(), Session["DistrictID"].ToString(), Session["uid"].ToString());
            if (dsn.Tables[0].Rows.Count > 0)
            {

                lblstate11.Text = "Total Records Found : " + dsn.Tables[0].Rows.Count.ToString();
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                lblstate11.Text = "No records Found";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }

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
        Response.Redirect("MISEReport.aspx");
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
            //lblmsg.Text = ex.ToString();
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

            HyperLink h1 = (HyperLink)e.Row.Cells[17].Controls[0];
            h1.Target = "_blank";
            h1.NavigateUrl = "frmViewMSMEAttachmentDetails.aspx?intMSMEid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intMSMEid")).Trim();

            //cnt = cnt + 1;
            //e.Row.Cells[0].Text = cnt.ToString();




        }




    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        GetDetails();
    }
}
