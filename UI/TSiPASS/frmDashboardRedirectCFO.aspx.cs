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
    string approvalllid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["user"] != null && Session["user"] != "")
        //{ }
        //else
        //{
        //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //}
        if (Session.Count <= 0)
        {

            Response.Redirect("~/Index.aspx");
        }
        DataSet ds = new DataSet();
        string status = Request.QueryString[1].ToString().Trim();
        string id = Request.QueryString[0].ToString().Trim();
        if (!IsPostBack)
        {
            ds = Gen.getEnterprenuerdashboarddrilldownCFO(id, status);
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }

        if (status == "Approval - Issued")
        {

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TourismFlag"].ToString() != null && ds.Tables[0].Rows[0]["TourismFlag"].ToString() == "Y")
                {
                    trcoicertificate.Visible = true;
                    HyperLinkcoi.Target = "_blank";
                    //HyperLinkcoi.NavigateUrl = "CFECertificate.aspx?intCFEEnterpid=" + Convert.ToString(id).Trim();
                    HyperLinkcoi.NavigateUrl = "CFOHotelCertificate.aspx?intCFEEnterpid=" + Convert.ToString(ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString()).Trim();
                }
            }
        }
        if (status == "Approval - Rejected")
        {
            grdDetails.Columns[16].Visible = true;
            grdDetails.Columns[17].Visible = false;

        }


        else if (status == "Pre-Scrutiny - Rejected")
        {
            grdDetails.Columns[16].Visible = false;
            grdDetails.Columns[17].Visible = true;
        }
        else if (approvalllid == "14" && status == "Approval - Pending")
        {
            grdDetails.Columns[17].Visible = true;
        }
        //else
        else
        {
            grdDetails.Columns[16].Visible = false;
            grdDetails.Columns[17].Visible = false;
        }

        if (status == "Approval - Pending")
        {

            int c = ds.Tables[0].Rows.Count;
            int i = 0;
            while (i < c)
            {
                if (ds.Tables[0].Rows[i]["intapprovalid"].ToString() == "16" && ds.Tables[0].Rows[i]["ErectionReportUploadedFlag"].ToString().TrimEnd().TrimStart() != "Y")
                {
                    grdDetails.Columns[19].Visible = true;
                }
                else
                {
                    if (grdDetails.Columns[19].Visible != true)
                    grdDetails.Columns[17].Visible = false;

                       // grdDetails.Columns[19].Visible = false;
                }
                i++;
            }
        }
        else
        {
            grdDetails.Columns[19].Visible = false;
        }
    }


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {



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
            // lblmsg.Text = ex.ToString();
        }
        finally
        {

        }

    }



    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string approvalid = ""; string Commondetatilsupdated = "", HdfQueid = "", Letter = "", createdby = "";
            approvalid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid"));
            Commondetatilsupdated = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CommonDetailsUpdatedFlag"));
            HdfQueid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireCFOid"));
            Letter = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RejectedLetter"));
            createdby = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Created_by"));
            approvalllid = approvalid;
            HyperLink h4 = (HyperLink)e.Row.Cells[19].Controls[0];
            if (approvalid == "16")
            {
                grdDetails.Columns[19].Visible = true;
                h4.Visible = true;
                h4.Target = "_blank";
                h4.NavigateUrl = "frmCEIGComplainceReport.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
            }
            if (approvalid == "14")
            {
                h4.Visible = false;
                //grdDetails.Columns[19].Visible = false;
            }

            HyperLink h1 = (HyperLink)e.Row.Cells[15].Controls[0];

            h1.Target = "_blank";
            h1.NavigateUrl = "frmViewAttachmentDetailsCFO.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
            HyperLink h2 = (HyperLink)e.Row.Cells[17].Controls[0];

            if (approvalid == "14" && (Commondetatilsupdated != "" && Commondetatilsupdated == "Y"))
            {
                h2.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHome?swiftApplicationNo=" + createdby;
                h2.Text = "Click here to Appeal";
                if (Letter != null && Letter != "")
                {
                    grdDetails.Columns[20].Visible = true;
                }
                else
                {
                    grdDetails.Columns[20].Visible = false;
                }
            }
            else
            {
                h2.Target = "_blank";
                h2.NavigateUrl = "frmAppealtoprerejectionCFO.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim() + "&apid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
                h2.Text = "Click here to Appeal";
            }
            if (approvalid == "14" && (Commondetatilsupdated != "" && Commondetatilsupdated == "Y"))
            {
                HyperLink h3 = (HyperLink)e.Row.Cells[16].Controls[0];
                if (Request.QueryString[1].ToString().Trim() == "Approval - Rejected")
                {

                    h3.NavigateUrl = "https://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHome?swiftApplicationNo=" + createdby;
                    h3.Text = "Click here to Appeal";
                }
                else
                {
                    h3.Text = "Under process";
                    h3.NavigateUrl = "";
                }
                //HyperLink h4 = (HyperLink)e.Row.Cells[19].Controls[0];
                h4.Visible = false;
                //grdDetails.Columns[19].Visible = false;
            }
            else
            {
                if (Request.QueryString[1].ToString().Trim() == "Approval - Rejected")
                {
                    HyperLink h3 = (HyperLink)e.Row.Cells[16].Controls[0];

                    if (Request.QueryString[1].ToString().Trim() == "Approval - Rejected")
                    {
                        h3.Target = "_blank";
                        h3.NavigateUrl = "frmAppealtoapprovalrejectionCFO.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim() + "&apid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
                        h3.Text = "Click here to Appeal";
                    }
                    else
                    {
                        grdDetails.Columns[16].Visible = false;
                    }
                }
            }

            //HyperLink h4 = (HyperLink)e.Row.Cells[19].Controls[0];
            //h4.Target = "_blank";
            //h4.NavigateUrl = "frmBoilerInspectUpload.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();

        }

    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/AcknowledgmentEntrPrintCFO.aspx?id=" + Request.QueryString[0].ToString().Trim());

        //string pageurl = "~/UI/TSIPASS/AcknowledgmentEntrPrint.aspx?id=" + Request.QueryString[0].ToString().Trim();

        //Response.Write("<script> window.open( '" + pageurl + "','_blank' ); </script>");

        //Response.End();

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/UI/TSIPASS/AcknowledgmentEntrPrint.aspx?id=" + Request.QueryString[0].ToString().Trim() + "','_newtab');");
    }
}
