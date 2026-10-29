using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_OldSanctionedIncentives : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }
        if (!IsPostBack)
        {
            Session["UIDNO"] = null;
            BindDistricts(ddlDist);

            BindIncentives();

           
        }
    }

    private void BindDistricts(DropDownList ddlDistrict)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            dsd = Gen.GetDistrictsForOldSanctionedIncentives();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dsd.Tables[0];
                ddlDistrict.DataValueField = "DistrictName";
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    private void BindIncentives()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlIncentive.Items.Clear();
            dsd = Gen.GetIncentivesForOldSanctionedIncentives();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlIncentive.DataSource = dsd.Tables[0];
                ddlIncentive.DataValueField = "IncentiveId";
                ddlIncentive.DataTextField = "IncentiveName";
                ddlIncentive.DataBind();
                ddlIncentive.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlIncentive.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        ViewState["UIDNO"] = null;
        Session["UIDNO"] = null;
        Failure.Visible = false;

        if (txtUnitName.Text.Trim() == "")
        {
            lblmsg0.Text += "Please enter Unit Name" + "<br/>";
            valid = 1;
        }
        if (ddlDist.SelectedItem.Text == "--Select--")
        {
            lblmsg0.Text += "Please Select District" + "<br/>";
            valid = 1;
        }
        if (ddlIncentive.SelectedItem.Text == "--Select--")
        {
            lblmsg0.Text += "Please Select Incentive" + "<br/>";
            valid = 1;
        }
        if (valid == 0)
        {
            DataSet dsd = new DataSet();
            dsd = Gen.GetIncentivesDataofOldSanctionedIncentives(ddlIncentive.SelectedValue, ddlDist.SelectedValue, txtUnitName.Text.Trim());
            if (dsd != null && dsd.Tables.Count > 0)
            {
                if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = dsd.Tables[0];
                    grdDetails.DataBind();
                }
                if (dsd != null && dsd.Tables.Count > 1 && dsd.Tables[1].Rows.Count > 0)
                {
                    gvData2.DataSource = dsd.Tables[1];
                    gvData2.DataBind();
                }
                if (dsd.Tables[0].Rows.Count == 0 && dsd.Tables[1].Rows.Count == 0)
                {
                    gvData2.DataSource = null;
                    gvData2.DataBind();
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                    Failure.Visible = true;
                    lblmsg0.Text = "No Details Found ";
                }
            }
            else
            {
                gvData2.DataSource = null;
                gvData2.DataBind();
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                Failure.Visible = true;
                lblmsg0.Text = "No Details Found ";
            }
            // Failure.Visible = false;
        }
        else
        {
            Failure.Visible = true;
            gvData2.DataSource = null;
            gvData2.DataBind();
            grdDetails.DataSource = null;
            grdDetails.DataBind();
            Failure.Visible = true;
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                HiddenField hdsSanctionSLNOOld = (HiddenField)e.Row.Cells[0].FindControl("hdfSanctionSlNo");
                hdsSanctionSLNOOld.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionSlNo")).Trim();

                HiddenField hdfUIDOld = (HiddenField)e.Row.Cells[0].FindControl("hdfUID");
                hdfUIDOld.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UIDNo")).Trim();

                HiddenField hdfincentiveId = (HiddenField)e.Row.Cells[0].FindControl("hdfIncentiveID");
                hdfincentiveId.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId")).Trim();

                string UnitName = "", District = "", Scheme = "", SanctionedAmount = "", SanctionedDate = "", FinYear = "", SLCNumber = "", IncentiveId = "";

                UnitName = e.Row.Cells[1].Text;
                District = e.Row.Cells[2].Text;
                Scheme = e.Row.Cells[3].Text;
                SanctionedAmount = e.Row.Cells[4].Text;
                SanctionedDate = e.Row.Cells[5].Text;
                FinYear = e.Row.Cells[6].Text;
                SLCNumber = e.Row.Cells[7].Text;
                IncentiveId = hdfincentiveId.Value;
                string UIDNo = "";
                if (ViewState["UIDNO"] != null && ViewState["UIDNO"].ToString() != "")
                {
                    UIDNo = ViewState["UIDNO"].ToString();
                }
                (e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = true;
                (e.Row.FindControl("anchortaglinkView") as HyperLink).NavigateUrl = "DIPCSanctionedDtlsEntryScreenNew.aspx?SanctionSLNo=" + hdsSanctionSLNOOld.Value + "&UnitName=" + UnitName + "&District=" + District + "&Scheme=" + Scheme + "&SanctionedAmount=" + SanctionedAmount + "&SanctionedDate=" + SanctionedDate + "&FinYear=" + FinYear + "&SLCNumber=" + SLCNumber + "&IncentiveId=" + IncentiveId + "&UIDNo=" + UIDNo;
                //DIPCSanctionedDtlsEntryScreenNew


            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    protected void ChckedChanged(object sender, EventArgs e)
    {
        GetSelectedRows();
        //BindSecondGrid();
    }

    private void GetSelectedRows()
    {
        int selected = 0;
        for (int i = 0; i < gvData2.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvData2.Rows[i].Cells[0].FindControl("chkSameUnit");
            if (chk.Checked)
            {
                HiddenField hdfUIDOld = (HiddenField)gvData2.Rows[i].Cells[0].FindControl("hdfUID");
                string UID = hdfUIDOld.Value;
                ViewState["UIDNO"] = UID;
                Session["UIDNO"] = UID;
                //string UID=gvData2.Rows[i][].tos
                selected = 1;
            }
            else
            {
                if (selected == 0)
                {
                    ViewState["UIDNO"] = null;
                    Session["UIDNO"] = null;
                }
                // dt = RemoveRow(gvEmpInfo.Rows[i], dt);
            }
        }
    }
    protected void gvData2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                HiddenField hdsSanctionSLNOOld = (HiddenField)e.Row.Cells[0].FindControl("hdfSanctionSlNo");
                hdsSanctionSLNOOld.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionSlNo")).Trim();

                HiddenField hdfUIDOld = (HiddenField)e.Row.Cells[0].FindControl("hdfUID");
                hdfUIDOld.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UIDNo")).Trim();

                HiddenField hdfincentiveId = (HiddenField)e.Row.Cells[0].FindControl("hdfIncentiveID");
                hdfincentiveId.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId")).Trim();

                string UnitName = "", District = "", Scheme = "", SanctionedAmount = "", SanctionedDate = "", FinYear = "", SLCNumber = "", IncentiveId = "";

                UnitName = e.Row.Cells[1].Text;
                District = e.Row.Cells[2].Text;
                Scheme = e.Row.Cells[3].Text;
                SanctionedAmount = e.Row.Cells[4].Text;
                SanctionedDate = e.Row.Cells[5].Text;
                FinYear = e.Row.Cells[6].Text;
                SLCNumber = e.Row.Cells[7].Text;
                IncentiveId = hdfincentiveId.Value;
                //(e.Row.FindControl("anchortaglinkView") as HyperLink).Visible = true;
                //(e.Row.FindControl("anchortaglinkView") as HyperLink).NavigateUrl = "DIPCSanctionedDtlsEntryScreenNew.aspx?SanctionSLNo=" + hdsSanctionSLNOOld.Value + "&UnitName=" + UnitName + "&District=" + District + "&Scheme=" + Scheme + "&SanctionedAmount=" + SanctionedAmount + "&SanctionedDate=" + SanctionedDate + "&FinYear=" + FinYear + "&SLCNumber=" + SLCNumber + "&IncentiveId=" + IncentiveId + "&UIDNo=" + hdfUIDOld.Value;
                //DIPCSanctionedDtlsEntryScreenNew


            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    //protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    string UIDNo = "";
    //    if (ViewState["UIDNO"] != null && ViewState["UIDNO"].ToString() != "")
    //    {
    //        UIDNo = ViewState["UIDNO"].ToString();
    //    }
    //    int index = Convert.ToInt32(e.CommandArgument.ToString());
    //    //Literal ltrlslno = (Literal)grdDetails.Rows[index].FindControl("ltrlSlno");
    //    //Literal ltrlName = (Literal)grdDetails.Rows[index].FindControl("ltrlName");

    //    HiddenField hdsSanctionSLNOOld = (HiddenField)grdDetails.Rows[index].FindControl("hdfSanctionSlNo");
    //    // hdsSanctionSLNOOld.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SanctionSlNo")).Trim();

    //    HiddenField hdfUIDOld = (HiddenField)grdDetails.Rows[index].FindControl("hdfUID");
    //    //hdfUIDOld.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UIDNo")).Trim();

    //    HiddenField hdfincentiveId = (HiddenField)grdDetails.Rows[index].FindControl("hdfIncentiveID");
    //    //hdfincentiveId.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId")).Trim();

    //    string UnitName = "", District = "", Scheme = "", SanctionedAmount = "", SanctionedDate = "", FinYear = "", SLCNumber = "", IncentiveId = "";

    //    UnitName = grdDetails.Rows[index].Cells[1].ToString();
    //    District = grdDetails.Rows[index].Cells[2].ToString();
    //    Scheme = grdDetails.Rows[index].Cells[3].ToString();
    //    SanctionedAmount = grdDetails.Rows[index].Cells[4].ToString();
    //    SanctionedDate = grdDetails.Rows[index].Cells[5].ToString();
    //    FinYear = grdDetails.Rows[index].Cells[6].ToString();
    //    SLCNumber = grdDetails.Rows[index].Cells[7].ToString();
    //    IncentiveId = hdfincentiveId.Value;

    //    (grdDetails.Rows[index].FindControl("anchortaglinkView") as HyperLink).Visible = true;
    //    (grdDetails.Rows[index].FindControl("anchortaglinkView") as HyperLink).NavigateUrl = "DIPCSanctionedDtlsEntryScreenNew.aspx?SanctionSLNo=" + hdsSanctionSLNOOld.Value + "&UnitName=" + UnitName + "&District=" + District + "&Scheme=" + Scheme + "&SanctionedAmount=" + SanctionedAmount + "&SanctionedDate=" + SanctionedDate + "&FinYear=" + FinYear + "&SLCNumber=" + SLCNumber + "&IncentiveId=" + IncentiveId + "&UIDNo=" + UIDNo;


    //}
}