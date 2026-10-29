using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

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
        //if (Session["user"] != null && Session["user"] != "")
        //{ }
        //else
        //{
        //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //}
        DataSet ds = new DataSet();
        string status = Request.QueryString[1].ToString().Trim();
        string id = Request.QueryString[0].ToString().Trim();
        if (!IsPostBack)
        {
            ds = Gen.getEnterprenuerdashboarddrilldown(id, status);


            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            if (status == "Approval - Issued")
            {

                grdDetails.Columns[15].Visible = true;
                grdDetails.Columns[16].Visible = false;
                grdDetails.Columns[17].Visible = false;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["TourismFlag"].ToString() != null && ds.Tables[0].Rows[0]["TourismFlag"].ToString() == "Y")
                    {
                        trcoicertificate.Visible = true;
                        HyperLinkcoi.Target = "_blank";
                        //HyperLinkcoi.NavigateUrl = "CFECertificate.aspx?intCFEEnterpid=" + Convert.ToString(id).Trim();
                        HyperLinkcoi.NavigateUrl = "CFEHotelCertificate.aspx?intCFEEnterpid=" + Convert.ToString(ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString()).Trim();
                    }
                }
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    trcoicertificate.Visible = true;
                    HyperLinkcoi.Target = "_blank";
                    HyperLinkcoi.Text = "Tourism consolidated certificate";
                    //HyperLinkcoi.NavigateUrl = "CFECertificate.aspx?intCFEEnterpid=" + Convert.ToString(id).Trim();
                    HyperLinkcoi.NavigateUrl = "CFECertificate.aspx?intCFEEnterpid=" + Convert.ToString(ds.Tables[1].Rows[0]["intCFEEnterpidnew"].ToString()).Trim();
                }
            }


            else if (status == "Approval - Rejected")
            {
                grdDetails.Columns[15].Visible = false;
                grdDetails.Columns[16].Visible = false;
                grdDetails.Columns[17].Visible = true;
                //grdDetails.Columns[19].Visible = true;
            }


            else if (status == "Pre-Scrutiny - Rejected")
            {
                grdDetails.Columns[15].Visible = false;
                grdDetails.Columns[16].Visible = true;
                grdDetails.Columns[17].Visible = false;
                //grdDetails.Columns[19].Visible = true;
            }
            else if (status == "Queries -Yet to Respond")
            {
                grdDetails.Columns[15].Visible = false;
                grdDetails.Columns[16].Visible = true;
                grdDetails.Columns[17].Visible = false;
            }
            else if (status == "Queries Raised")
            {
                grdDetails.Columns[15].Visible = false;
                grdDetails.Columns[16].Visible = true;
                grdDetails.Columns[17].Visible = false;
                grdDetails.Columns[19].Visible = false;
            }
            else if (status == "Queries Responded")
            {
                grdDetails.Columns[15].Visible = false;
                grdDetails.Columns[16].Visible = true;
                grdDetails.Columns[17].Visible = false;
                grdDetails.Columns[19].Visible = false;
            }
            else
            {

                grdDetails.Columns[15].Visible = false;
                grdDetails.Columns[16].Visible = false;
                grdDetails.Columns[17].Visible = false;
                grdDetails.Columns[19].Visible = false;
            }

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
            HdfQueid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid"));
            Letter = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RejectedLetter"));
            HtmlAnchor QueryLetter = (HtmlAnchor)e.Row.FindControl("Letter");
            createdby = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Created_by"));
            string NICApplicationno = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NICApplicationno"));
            HyperLink h1 = (HyperLink)e.Row.Cells[15].Controls[0];

            h1.Target = "_blank";
            h1.NavigateUrl = "frmViewAttachmentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            HyperLink h2 = (HyperLink)e.Row.Cells[16].Controls[0];

            h2.Target = "_blank";

            if (Request.QueryString[1].ToString().Trim() == "Queries -Yet to Respond")
            {
                if (Letter != null && Letter != "" && Letter.Contains("http") && approvalid!="20")
                {
                    QueryLetter.Visible = true;
                }
                else
                {
                    QueryLetter.Visible = false;
                }
                if (approvalid == "20" && (Commondetatilsupdated != "" && Commondetatilsupdated == "Y"))
                {
                    h2.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHomeNew?swiftApplicationNo=" + createdby + "&applicationNo=" + NICApplicationno;
                    h2.Text = "Respond";
                }
                else
                {
                    h2.NavigateUrl = "frmResponceQueries.aspx?intApplicationid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQueryTrnsid")).Trim();
                    h2.Text = "Respond";
                }
            }
            else if (Request.QueryString[1].ToString().Trim() == "Queries Raised")
            {
                h2.NavigateUrl = "TrackerDtls.aspx?intQuessionaireid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim() + "&intStageid=1&intApprovalid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
                h2.Text = "View";
            }
            else if (Request.QueryString[1].ToString().Trim() == "Queries Responded")
            {
                h2.NavigateUrl = "TrackerDtls.aspx?intQuessionaireid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim() + "&intStageid=1&intApprovalid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
                h2.Text = "View";
            }
            else
            {
                if (approvalid == "20" && (Commondetatilsupdated != "" && Commondetatilsupdated == "Y"))
                {
                    //h2.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHome?swiftApplicationNo=" + createdby + "&applicationNo=" + NICApplicationno; 
                    h2.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHomeNew?swiftApplicationNo=" + createdby + "&applicationNo=" + NICApplicationno;
                    h2.Text = "Click here to Appeal";
                    if (Letter != null && Letter !="")
                    {
                         grdDetails.Columns[19].Visible = true;
                    }
                    else
                    {
                         grdDetails.Columns[19].Visible = false;
                    }
                }
                else
                {
                    h2.NavigateUrl = "frmAppealtoprerejection.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() + "&apid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();
                    h2.Text = "Click here to Appeal";

                    if (approvalid == "35" || approvalid == "31")
                    {
                        grdDetails.Columns[19].Visible = true;
                    }
                    else
                    {
                        grdDetails.Columns[19].Visible = false;
                    }
                }
            }



            if (approvalid == "20" && (Commondetatilsupdated != "" && Commondetatilsupdated == "Y"))
            {
                HyperLink h3 = (HyperLink)e.Row.Cells[17].Controls[0];
                h3.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHomeNew?swiftApplicationNo=" + createdby + "&applicationNo=" + NICApplicationno;
                h3.Text = "Click here to Appeal";
            }
            else
            {
                HyperLink h3 = (HyperLink)e.Row.Cells[17].Controls[0];

                h3.Target = "_blank";
                h3.NavigateUrl = "frmAppealtoapprovalrejection.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() + "&apid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();

                h3.Text = "Click here to Appeal";
            }



        }
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/AcknowledgmentEntrPrint.aspx?id=" + Request.QueryString[0].ToString().Trim());

        //string pageurl = "~/UI/TSIPASS/AcknowledgmentEntrPrint.aspx?id=" + Request.QueryString[0].ToString().Trim();

        //Response.Write("<script> window.open( '" + pageurl + "','_blank' ); </script>");

        //Response.End();

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/UI/TSIPASS/AcknowledgmentEntrPrint.aspx?id=" + Request.QueryString[0].ToString().Trim() + "','_newtab');");
    }
}
