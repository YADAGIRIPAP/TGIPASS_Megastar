using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
public partial class UI_TSiPASS_RPT_GroundwaterDistrictMandalwise : System.Web.UI.Page
{
    int totrw_TotalApplications, totrw_TotalPrescrunitypendinginMROappl, totrw_TotalQueryraisedbyMROappl,
        totrw_TotalQueryrespondedtoMROappl, totrw_TotalPrescrunityrejectedMROappl, totrw_TotalapplforwardtoDGWOappl,
        totrw_TotalQueryraisedbyDGWOappl, totrw_TotalQueryrespondedDGwoappl, totrw_TotalApprovedbyDGWOappl,
        totrw_TotalRejectedbyDGWOappl, totrw_TotalApprovedbyMROappl, totrw_TotalApprovalRejectedbyMROappl,
        totrw_totalPrescrunitypendingMRObeyond14days, totrw_TotalMROQueryraisedNoresponsebyapplbeyond7days,
        totrw_TotalQueryrespondedapplnoactionbeyond7daysMRO, totrw_totalapplpendinginDGWObeyond7days,
        totrw_TotalDGWOQueryraisedNoresponsebyapplbeyond7days, totrw_TotalQueryrespondedapplnoactionbeyond7daysDGWO,
        totrw_DGWOApprovedwithintimelimit, totrw_DGWOapprovedbeyondtimelimit, totrw_MROApprovedwithintimelimit,
        totrw_MROapprovedbeyondtimelimit, totrw_DWGOrejecteddocuploadedbyMRO, totrw_DWGOrejecteddocuploadpendingbyMRO,
        totrw_TotCurr_PrescrunitypendinginMROappl, totrw_TotCurr_QueryraisedbyMROappl, totrw_TotCurr_QueryrespondedtoMROappl,
        totrw_TotCurr_applforwardtoDGWOappl, totrw_TotCurr_QueryraisedbyDGWOappl, totrw_TotCurr_QueryrespondedDGwoappl,
       
        totrw_TotalapplforwardtoTRANSCOappl,totrw_TotCurr_applforwardtoTRANSCOappl,totrw_totalapplpendinginTRANSCObeyond7days,
        totrw_TotalQueryraisedbyTRANSCOappl,totrw_TotCurr_QueryraisedbyTRANSCOappl,totrw_TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days,
        totrw_TotalQueryrespondedTRANSCOappl,totrw_TotCurr_QueryrespondedTRANSCOappl,totrw_TotalQueryrespondedapplnoactionbeyond7daysTRANSCO,
        totrw_TotalApprovedbyTRANSCOappl,totrw_TRANSCOApprovedwithintimelimit,totrw_TRANSCOapprovedbeyondtimelimit,totrw_TotalRejectedbyTRANSCOappl;

     Cls_OSGroundWater obj_insert = new Cls_OSGroundWater();
    string DistrictID = "", MandalID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDistricts();
            BindMandal();
            ddlDIst.Enabled = true;
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                DistrictID = Convert.ToString(Session["DistrictID"]);
                ddlDIst.SelectedValue = DistrictID;
                ddlDIst.Enabled = false;
            }
            fillgrid(DistrictID, MandalID);
        }
    }

    public void AddSelect(DropDownList ddl)
    {
        try
        {
            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
        }
    }
    public void BindDistricts()
    {
        try
        {
            ddlDIst.Items.Clear();
            DataTable dsd = obj_insert.DB_GWgetdistricts();
            if (dsd != null && dsd.Rows.Count > 0)
            {
                ddlDIst.DataSource = dsd;
                ddlDIst.DataValueField = "District_Id";
                ddlDIst.DataTextField = "District_Name";
                ddlDIst.DataBind();
                AddSelect(ddlDIst);
            }
            else
            {

                AddSelect(ddlDIst);
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void ddlDIst_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlDIst.SelectedIndex == 0)
        {
            AddSelect(ddlMandal);
        }
        else
        {
            BindMandal();
        }
        string DistrictID = ""; string MandalID = "";
        if (ddlDIst.SelectedIndex > 0)
        {
            DistrictID = Convert.ToString(ddlDIst.SelectedValue);
        }

        if (ddlMandal.SelectedIndex > 0)
        {
            MandalID = Convert.ToString(ddlMandal.SelectedValue);
        }
        fillgrid(DistrictID, MandalID);
    }
    public void BindMandal()
    {
        ddlMandal.Items.Clear();
        DataTable dsm = obj_insert.DB_GWgetmadals(ddlDIst.SelectedValue);
        if (dsm.Rows.Count > 0)
        {
            ddlMandal.DataSource = dsm;
            ddlMandal.DataValueField = "Mandal_Id";
            ddlMandal.DataTextField = "Manda_lName";
            ddlMandal.DataBind();
            AddSelect(ddlMandal);
        }
        else
        {
            ddlMandal.Items.Clear();
            AddSelect(ddlMandal);
        }
        
    }
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        string DistrictID = ""; string MandalID = "";
        if (ddlDIst.SelectedIndex > 0)
        {
            DistrictID = Convert.ToString(ddlDIst.SelectedValue);
        }

        if (ddlMandal.SelectedIndex > 0)
        {
            MandalID = Convert.ToString(ddlMandal.SelectedValue);
            if (ddlDIst.SelectedIndex <=0)
            {
                string message = "alert('Select District')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }
            fillgrid(DistrictID, MandalID);
    }
   
    public void fillgrid(string DistrictID, string MandalID)
    {
        
        
        DataSet vehicleDS = new DataSet();
        vehicleDS = obj_insert.DB_getgroundwaterrpdistrictmandalwise(DistrictID,MandalID);
        grdDetails.DataSource = vehicleDS;
        grdDetails.DataBind();
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string DistrictID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID"));
            string DistrictName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District"));

            string MandalID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MandalID"));
            string Mandal = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Mandal"));


            HyperLink hyp_TotalApplications = (HyperLink)e.Row.FindControl("hyp_TotalApplications");
            hyp_TotalApplications.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalApplications&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Applications"+ "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalPrescrunitypendinginMROappl = (HyperLink)e.Row.FindControl("hyp_TotalPrescrunitypendinginMROappl");
            hyp_TotalPrescrunitypendinginMROappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalPrescrunitypendinginMROappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Presrunity Pending" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalQueryraisedbyMROappl = (HyperLink)e.Row.FindControl("hyp_TotalQueryraisedbyMROappl");
            hyp_TotalQueryraisedbyMROappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryraisedbyMROappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Pre-Scrunity Pending after 14 Days" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalQueryrespondedtoMROappl = (HyperLink)e.Row.FindControl("hyp_TotalQueryrespondedtoMROappl");
            hyp_TotalQueryrespondedtoMROappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryrespondedtoMROappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Query Raised  For Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalPrescrunityrejectedMROappl = (HyperLink)e.Row.FindControl("hyp_TotalPrescrunityrejectedMROappl");
            hyp_TotalPrescrunityrejectedMROappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalPrescrunityrejectedMROappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Current Query Raised Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalapplforwardtoDGWOappl = (HyperLink)e.Row.FindControl("hyp_TotalapplforwardtoDGWOappl");
            hyp_TotalapplforwardtoDGWOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalapplforwardtoDGWOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Query raised, no response within 7 days From Applicants" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalQueryraisedbyDGWOappl = (HyperLink)e.Row.FindControl("hyp_TotalQueryraisedbyDGWOappl");
            hyp_TotalQueryraisedbyDGWOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryraisedbyDGWOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Query Responded Application" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalQueryrespondedDGwoappl = (HyperLink)e.Row.FindControl("hyp_TotalQueryrespondedDGwoappl");
            hyp_TotalQueryrespondedDGwoappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryrespondedDGwoappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Current Query Responded Application" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalApprovedbyDGWOappl = (HyperLink)e.Row.FindControl("hyp_TotalApprovedbyDGWOappl");
            hyp_TotalApprovedbyDGWOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalApprovedbyDGWOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Query Responded,No action Taken within 7 days" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalRejectedbyDGWOappl = (HyperLink)e.Row.FindControl("hyp_TotalRejectedbyDGWOappl");
            hyp_TotalRejectedbyDGWOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalRejectedbyDGWOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Approved Application" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;


            HyperLink hyp_TotalApprovedbyMROappl = (HyperLink)e.Row.FindControl("hyp_TotalApprovedbyMROappl");
            hyp_TotalApprovedbyMROappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalApprovedbyMROappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalApprovalRejectedbyMROappl = (HyperLink)e.Row.FindControl("hyp_TotalApprovalRejectedbyMROappl");
            hyp_TotalApprovalRejectedbyMROappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalApprovalRejectedbyMROappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_totalPrescrunitypendingMRObeyond14days = (HyperLink)e.Row.FindControl("hyp_totalPrescrunitypendingMRObeyond14days");
            hyp_totalPrescrunitypendingMRObeyond14days.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=totalPrescrunitypendingMRObeyond14days&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Presrunity Pending" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalMROQueryraisedNoresponsebyapplbeyond7days = (HyperLink)e.Row.FindControl("hyp_TotalMROQueryraisedNoresponsebyapplbeyond7days");
            hyp_TotalMROQueryraisedNoresponsebyapplbeyond7days.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalMROQueryraisedNoresponsebyapplbeyond7days&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Pre-Scrunity Pending after 14 Days" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;


            HyperLink hyp_TotalQueryrespondedapplnoactionbeyond7daysMRO = (HyperLink)e.Row.FindControl("hyp_TotalQueryrespondedapplnoactionbeyond7daysMRO");
            hyp_TotalQueryrespondedapplnoactionbeyond7daysMRO.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryrespondedapplnoactionbeyond7daysMRO&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Query Raised  For Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_totalapplpendinginDGWObeyond7days = (HyperLink)e.Row.FindControl("hyp_totalapplpendinginDGWObeyond7days");
            hyp_totalapplpendinginDGWObeyond7days.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=totalapplpendinginDGWObeyond7days&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Current Query Raised Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalDGWOQueryraisedNoresponsebyapplbeyond7days = (HyperLink)e.Row.FindControl("hyp_TotalDGWOQueryraisedNoresponsebyapplbeyond7days");
            hyp_TotalDGWOQueryraisedNoresponsebyapplbeyond7days.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalDGWOQueryraisedNoresponsebyapplbeyond7days&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Query raised, no response within 7 days From Applicants" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalQueryrespondedapplnoactionbeyond7daysDGWO = (HyperLink)e.Row.FindControl("hyp_TotalQueryrespondedapplnoactionbeyond7daysDGWO");
            hyp_TotalQueryrespondedapplnoactionbeyond7daysDGWO.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryrespondedapplnoactionbeyond7daysDGWO&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Query Responded Application" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_DGWOApprovedwithintimelimit = (HyperLink)e.Row.FindControl("hyp_DGWOApprovedwithintimelimit");
            hyp_DGWOApprovedwithintimelimit.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=DGWOApprovedwithintimelimit&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Current Query Responded Application" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_DGWOapprovedbeyondtimelimit = (HyperLink)e.Row.FindControl("hyp_DGWOapprovedbeyondtimelimit");
            hyp_DGWOapprovedbeyondtimelimit.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=DGWOapprovedbeyondtimelimit&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Query Responded,No action Taken within 7 days" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_MROApprovedwithintimelimit = (HyperLink)e.Row.FindControl("hyp_MROApprovedwithintimelimit");
            hyp_MROApprovedwithintimelimit.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=MROApprovedwithintimelimit&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Approved Application" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_MROapprovedbeyondtimelimit = (HyperLink)e.Row.FindControl("hyp_MROapprovedbeyondtimelimit");
            hyp_MROapprovedbeyondtimelimit.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=MROapprovedbeyondtimelimit&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_DWGOrejecteddocuploadedbyMRO = (HyperLink)e.Row.FindControl("hyp_DWGOrejecteddocuploadedbyMRO");
            hyp_DWGOrejecteddocuploadedbyMRO.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=DWGOrejecteddocuploadedbyMRO&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Approved Application" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_DWGOrejecteddocuploadpendingbyMRO = (HyperLink)e.Row.FindControl("hyp_DWGOrejecteddocuploadpendingbyMRO");
            hyp_DWGOrejecteddocuploadpendingbyMRO.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=DWGOrejecteddocuploadpendingbyMRO&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotCurr_PrescrunitypendinginMROappl = (HyperLink)e.Row.FindControl("hyp_TotCurr_PrescrunitypendinginMROappl");
            hyp_TotCurr_PrescrunitypendinginMROappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_PrescrunitypendinginMROappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotCurr_QueryraisedbyMROappl = (HyperLink)e.Row.FindControl("hyp_TotCurr_QueryraisedbyMROappl");
            hyp_TotCurr_QueryraisedbyMROappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_QueryraisedbyMROappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotCurr_QueryrespondedtoMROappl = (HyperLink)e.Row.FindControl("hyp_TotCurr_QueryrespondedtoMROappl");
            hyp_TotCurr_QueryrespondedtoMROappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_QueryrespondedtoMROappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotCurr_applforwardtoDGWOappl = (HyperLink)e.Row.FindControl("hyp_TotCurr_applforwardtoDGWOappl");
            hyp_TotCurr_applforwardtoDGWOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_applforwardtoDGWOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotCurr_QueryraisedbyDGWOappl = (HyperLink)e.Row.FindControl("hyp_TotCurr_QueryraisedbyDGWOappl");
            hyp_TotCurr_QueryraisedbyDGWOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_QueryraisedbyDGWOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;


            HyperLink hyp_TotCurr_QueryrespondedDGwoappl = (HyperLink)e.Row.FindControl("hyp_TotCurr_QueryrespondedDGwoappl");
            hyp_TotCurr_QueryrespondedDGwoappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_QueryrespondedDGwoappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;






            HyperLink hyp_TotalapplforwardtoTRANSCOappl = (HyperLink)e.Row.FindControl("hyp_TotalapplforwardtoTRANSCOappl");
            hyp_TotalapplforwardtoTRANSCOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalapplforwardtoTRANSCOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Query raised, no response within 7 days From Applicants" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            
            HyperLink hyp_TotalQueryraisedbyTRANSCOappl = (HyperLink)e.Row.FindControl("hyp_TotalQueryraisedbyTRANSCOappl");
            hyp_TotalQueryraisedbyTRANSCOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryraisedbyTRANSCOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Query Responded Application" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalQueryrespondedTRANSCOappl = (HyperLink)e.Row.FindControl("hyp_TotalQueryrespondedTRANSCOappl");
            hyp_TotalQueryrespondedTRANSCOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryrespondedTRANSCOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Current Query Responded Application" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalApprovedbyTRANSCOappl = (HyperLink)e.Row.FindControl("hyp_TotalApprovedbyTRANSCOappl");
            hyp_TotalApprovedbyTRANSCOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalApprovedbyTRANSCOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Query Responded,No action Taken within 7 days" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalRejectedbyTRANSCOappl = (HyperLink)e.Row.FindControl("hyp_TotalRejectedbyTRANSCOappl");
            hyp_TotalRejectedbyTRANSCOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalRejectedbyTRANSCOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Approved Application" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;


            HyperLink hyp_totalapplpendinginTRANSCObeyond7days = (HyperLink)e.Row.FindControl("hyp_totalapplpendinginTRANSCObeyond7days");
            hyp_totalapplpendinginTRANSCObeyond7days.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=totalapplpendinginTRANSCObeyond7days&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Current Query Raised Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days = (HyperLink)e.Row.FindControl("hyp_TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days");
            hyp_TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Query raised, no response within 7 days From Applicants" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotalQueryrespondedapplnoactionbeyond7daysTRANSCO = (HyperLink)e.Row.FindControl("hyp_TotalQueryrespondedapplnoactionbeyond7daysTRANSCO");
            hyp_TotalQueryrespondedapplnoactionbeyond7daysTRANSCO.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryrespondedapplnoactionbeyond7daysTRANSCO&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Query Responded Application" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TRANSCOApprovedwithintimelimit = (HyperLink)e.Row.FindControl("hyp_TRANSCOApprovedwithintimelimit");
            hyp_TRANSCOApprovedwithintimelimit.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TRANSCOApprovedwithintimelimit&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Current Query Responded Application" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TRANSCOapprovedbeyondtimelimit = (HyperLink)e.Row.FindControl("hyp_TRANSCOapprovedbeyondtimelimit");
            hyp_TRANSCOapprovedbeyondtimelimit.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TRANSCOapprovedbeyondtimelimit&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Query Responded,No action Taken within 7 days" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;


            HyperLink hyp_TotCurr_applforwardtoTRANSCOappl = (HyperLink)e.Row.FindControl("hyp_TotCurr_applforwardtoTRANSCOappl");
            hyp_TotCurr_applforwardtoTRANSCOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_applforwardtoTRANSCOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;

            HyperLink hyp_TotCurr_QueryraisedbyTRANSCOappl = (HyperLink)e.Row.FindControl("hyp_TotCurr_QueryraisedbyTRANSCOappl");
            hyp_TotCurr_QueryraisedbyTRANSCOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_QueryraisedbyTRANSCOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;


            HyperLink hyp_TotCurr_QueryrespondedTRANSCOappl = (HyperLink)e.Row.FindControl("hyp_TotCurr_QueryrespondedTRANSCOappl");
            hyp_TotCurr_QueryrespondedTRANSCOappl.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_QueryrespondedTRANSCOappl&DistrictID=" + DistrictID + "&DistrictName=" + DistrictName + "&Category=Total Rejected Applications" + "&MandalID=" + MandalID + "&MandalName=" + Mandal;



            
            
                
                
                
                
                
                
                






            int TotalApplications = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalApplications"));
            totrw_TotalApplications = TotalApplications + totrw_TotalApplications;

            int TotalPrescrunitypendinginMROappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalPrescrunitypendinginMROappl"));
            totrw_TotalPrescrunitypendinginMROappl = TotalPrescrunitypendinginMROappl + totrw_TotalPrescrunitypendinginMROappl;

            int TotalQueryraisedbyMROappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalQueryraisedbyMROappl"));
            totrw_TotalQueryraisedbyMROappl = TotalQueryraisedbyMROappl + totrw_TotalQueryraisedbyMROappl;

            int TotalQueryrespondedtoMROappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalQueryrespondedtoMROappl"));
            totrw_TotalQueryrespondedtoMROappl = TotalQueryrespondedtoMROappl + totrw_TotalQueryrespondedtoMROappl;

            int TotalPrescrunityrejectedMROappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalPrescrunityrejectedMROappl"));
            totrw_TotalPrescrunityrejectedMROappl = TotalPrescrunityrejectedMROappl + totrw_TotalPrescrunityrejectedMROappl;

            int TotalapplforwardtoDGWOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalapplforwardtoDGWOappl"));
            totrw_TotalapplforwardtoDGWOappl = TotalapplforwardtoDGWOappl + totrw_TotalapplforwardtoDGWOappl;

            int TotalQueryraisedbyDGWOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalQueryraisedbyDGWOappl"));
            totrw_TotalQueryraisedbyDGWOappl = TotalQueryraisedbyDGWOappl + totrw_TotalQueryraisedbyDGWOappl;

            int TotalQueryrespondedDGwoappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalQueryrespondedDGwoappl"));
            totrw_TotalQueryrespondedDGwoappl = TotalQueryrespondedDGwoappl + totrw_TotalQueryrespondedDGwoappl;

            int TotalApprovedbyDGWOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalApprovedbyDGWOappl"));
            totrw_TotalApprovedbyDGWOappl = TotalApprovedbyDGWOappl + totrw_TotalApprovedbyDGWOappl;

            int TotalRejectedbyDGWOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalRejectedbyDGWOappl"));
            totrw_TotalRejectedbyDGWOappl = TotalRejectedbyDGWOappl + totrw_TotalRejectedbyDGWOappl;

            int TotalApprovedbyMROappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalApprovedbyMROappl"));
            totrw_TotalApprovedbyMROappl = TotalApprovedbyMROappl + totrw_TotalApprovedbyMROappl;

            int TotalApprovalRejectedbyMROappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalApprovalRejectedbyMROappl"));
            totrw_TotalApprovalRejectedbyMROappl = TotalApprovalRejectedbyMROappl + totrw_TotalApprovalRejectedbyMROappl;

            int totalPrescrunitypendingMRObeyond14days = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "totalPrescrunitypendingMRObeyond14days"));
            totrw_totalPrescrunitypendingMRObeyond14days = totalPrescrunitypendingMRObeyond14days + totrw_totalPrescrunitypendingMRObeyond14days;

            int TotalMROQueryraisedNoresponsebyapplbeyond7days = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalMROQueryraisedNoresponsebyapplbeyond7days"));
            totrw_TotalMROQueryraisedNoresponsebyapplbeyond7days = TotalMROQueryraisedNoresponsebyapplbeyond7days + totrw_TotalMROQueryraisedNoresponsebyapplbeyond7days;

            int TotalQueryrespondedapplnoactionbeyond7daysMRO = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalQueryrespondedapplnoactionbeyond7daysMRO"));
            totrw_TotalQueryrespondedapplnoactionbeyond7daysMRO = TotalQueryrespondedapplnoactionbeyond7daysMRO + totrw_TotalQueryrespondedapplnoactionbeyond7daysMRO;

            int totalapplpendinginDGWObeyond7days = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "totalapplpendinginDGWObeyond7days"));
            totrw_totalapplpendinginDGWObeyond7days = totalapplpendinginDGWObeyond7days + totrw_totalapplpendinginDGWObeyond7days;

            int TotalDGWOQueryraisedNoresponsebyapplbeyond7days = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalDGWOQueryraisedNoresponsebyapplbeyond7days"));
            totrw_TotalDGWOQueryraisedNoresponsebyapplbeyond7days = TotalDGWOQueryraisedNoresponsebyapplbeyond7days + totrw_TotalDGWOQueryraisedNoresponsebyapplbeyond7days;

            int TotalQueryrespondedapplnoactionbeyond7daysDGWO = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalQueryrespondedapplnoactionbeyond7daysDGWO"));
            totrw_TotalQueryrespondedapplnoactionbeyond7daysDGWO = TotalQueryrespondedapplnoactionbeyond7daysDGWO + totrw_TotalQueryrespondedapplnoactionbeyond7daysDGWO;

            int DGWOApprovedwithintimelimit = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DGWOApprovedwithintimelimit"));
            totrw_DGWOApprovedwithintimelimit = DGWOApprovedwithintimelimit + totrw_DGWOApprovedwithintimelimit;

            int DGWOapprovedbeyondtimelimit = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DGWOapprovedbeyondtimelimit"));
            totrw_DGWOapprovedbeyondtimelimit = DGWOapprovedbeyondtimelimit + totrw_DGWOapprovedbeyondtimelimit;

            int MROApprovedwithintimelimit = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "MROApprovedwithintimelimit"));
            totrw_MROApprovedwithintimelimit = MROApprovedwithintimelimit + totrw_MROApprovedwithintimelimit;

            int MROapprovedbeyondtimelimit = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "MROapprovedbeyondtimelimit"));
            totrw_MROapprovedbeyondtimelimit = MROapprovedbeyondtimelimit + totrw_MROapprovedbeyondtimelimit;

            int DWGOrejecteddocuploadedbyMRO = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DWGOrejecteddocuploadedbyMRO"));
            totrw_DWGOrejecteddocuploadedbyMRO = DWGOrejecteddocuploadedbyMRO + totrw_DWGOrejecteddocuploadedbyMRO;

            int DWGOrejecteddocuploadpendingbyMRO = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DWGOrejecteddocuploadpendingbyMRO"));
            totrw_DWGOrejecteddocuploadpendingbyMRO = DWGOrejecteddocuploadpendingbyMRO + totrw_DWGOrejecteddocuploadpendingbyMRO;


            int TotCurr_PrescrunitypendinginMROappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DWGOrejecteddocuploadpendingbyMRO"));
            totrw_TotCurr_PrescrunitypendinginMROappl = TotCurr_PrescrunitypendinginMROappl + totrw_TotCurr_PrescrunitypendinginMROappl;

            int TotCurr_QueryraisedbyMROappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DWGOrejecteddocuploadpendingbyMRO"));
            totrw_TotCurr_QueryraisedbyMROappl = TotCurr_QueryraisedbyMROappl + totrw_TotCurr_QueryraisedbyMROappl;

            int TotCurr_QueryrespondedtoMROappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DWGOrejecteddocuploadpendingbyMRO"));
            totrw_TotCurr_QueryrespondedtoMROappl = TotCurr_QueryrespondedtoMROappl + totrw_TotCurr_QueryrespondedtoMROappl;

            int TotCurr_applforwardtoDGWOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotCurr_applforwardtoDGWOappl"));
            totrw_TotCurr_applforwardtoDGWOappl = TotCurr_applforwardtoDGWOappl + totrw_TotCurr_applforwardtoDGWOappl;

            int TotCurr_QueryraisedbyDGWOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotCurr_QueryraisedbyDGWOappl"));
            totrw_TotCurr_QueryraisedbyDGWOappl = TotCurr_QueryraisedbyDGWOappl + totrw_TotCurr_QueryraisedbyDGWOappl;

            int TotCurr_QueryrespondedDGwoappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotCurr_QueryrespondedDGwoappl"));
            totrw_TotCurr_QueryrespondedDGwoappl = TotCurr_QueryrespondedDGwoappl + totrw_TotCurr_QueryrespondedDGwoappl;
            
            int TotalapplforwardtoTRANSCOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotCurr_applforwardtoTRANSCOappl"));
            totrw_TotalapplforwardtoTRANSCOappl = TotalapplforwardtoTRANSCOappl + totrw_TotalapplforwardtoTRANSCOappl;

            int TotCurr_applforwardtoTRANSCOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotCurr_applforwardtoTRANSCOappl"));
            totrw_TotCurr_applforwardtoTRANSCOappl = TotCurr_applforwardtoTRANSCOappl + totrw_TotCurr_applforwardtoTRANSCOappl;

            int totalapplpendinginTRANSCObeyond7days = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "totalapplpendinginTRANSCObeyond7days"));
            totrw_totalapplpendinginTRANSCObeyond7days = totalapplpendinginTRANSCObeyond7days + totrw_totalapplpendinginTRANSCObeyond7days;

            int TotalQueryraisedbyTRANSCOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalQueryraisedbyTRANSCOappl"));
            totrw_TotalQueryraisedbyTRANSCOappl = TotalQueryraisedbyTRANSCOappl + totrw_TotalQueryraisedbyTRANSCOappl;

            int TotCurr_QueryraisedbyTRANSCOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotCurr_QueryraisedbyTRANSCOappl"));
            totrw_TotCurr_QueryraisedbyTRANSCOappl = TotCurr_QueryraisedbyTRANSCOappl + totrw_TotCurr_QueryraisedbyTRANSCOappl;

            int TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days"));
            totrw_TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days = TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days + totrw_TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days;
            
            int TotalQueryrespondedTRANSCOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalQueryrespondedTRANSCOappl"));
            totrw_TotalQueryrespondedTRANSCOappl = TotalQueryrespondedTRANSCOappl + totrw_TotalQueryrespondedTRANSCOappl;
 
            int TotCurr_QueryrespondedTRANSCOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotCurr_QueryrespondedTRANSCOappl"));
            totrw_TotCurr_QueryrespondedTRANSCOappl = TotCurr_QueryrespondedTRANSCOappl + totrw_TotCurr_QueryrespondedTRANSCOappl;

            int TotalQueryrespondedapplnoactionbeyond7daysTRANSCO = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalQueryrespondedapplnoactionbeyond7daysTRANSCO"));
            totrw_TotalQueryrespondedapplnoactionbeyond7daysTRANSCO = TotalQueryrespondedapplnoactionbeyond7daysTRANSCO + totrw_TotalQueryrespondedapplnoactionbeyond7daysTRANSCO;

            int TotalApprovedbyTRANSCOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalApprovedbyTRANSCOappl"));
            totrw_TotalApprovedbyTRANSCOappl = TotalApprovedbyTRANSCOappl + totrw_TotalApprovedbyTRANSCOappl;

            int TRANSCOApprovedwithintimelimit = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TRANSCOApprovedwithintimelimit"));
            totrw_TRANSCOApprovedwithintimelimit = TRANSCOApprovedwithintimelimit + totrw_TRANSCOApprovedwithintimelimit;

            int TRANSCOapprovedbeyondtimelimit = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TRANSCOapprovedbeyondtimelimit"));
            totrw_TRANSCOapprovedbeyondtimelimit = TRANSCOapprovedbeyondtimelimit + totrw_TRANSCOapprovedbeyondtimelimit;

            int TotalRejectedbyTRANSCOappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalRejectedbyTRANSCOappl"));
            totrw_TotalRejectedbyTRANSCOappl = TotalRejectedbyTRANSCOappl + totrw_TotalRejectedbyTRANSCOappl;
    

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[2].Text = "Grand Total";
            e.Row.Cells[3].Text = totrw_TotalApplications.ToString();
            e.Row.Cells[4].Text = totrw_TotalPrescrunitypendinginMROappl.ToString();
            e.Row.Cells[5].Text = totrw_TotCurr_PrescrunitypendinginMROappl.ToString();
            e.Row.Cells[6].Text = totrw_totalPrescrunitypendingMRObeyond14days.ToString();
            e.Row.Cells[7].Text = totrw_TotalQueryraisedbyMROappl.ToString();
            e.Row.Cells[8].Text = totrw_TotCurr_QueryraisedbyMROappl.ToString();
            e.Row.Cells[9].Text = totrw_TotalMROQueryraisedNoresponsebyapplbeyond7days.ToString();
            e.Row.Cells[10].Text = totrw_TotalQueryrespondedtoMROappl.ToString();
            e.Row.Cells[11].Text = totrw_TotCurr_QueryrespondedtoMROappl.ToString();
            e.Row.Cells[12].Text = totrw_TotalQueryrespondedapplnoactionbeyond7daysMRO.ToString();

            e.Row.Cells[13].Text = totrw_TotalPrescrunityrejectedMROappl.ToString();

            e.Row.Cells[14].Text = totrw_TotalapplforwardtoDGWOappl.ToString();
            e.Row.Cells[15].Text = totrw_TotCurr_applforwardtoDGWOappl.ToString();
            e.Row.Cells[16].Text = totrw_totalapplpendinginDGWObeyond7days.ToString();
            e.Row.Cells[17].Text = totrw_TotalQueryraisedbyDGWOappl.ToString();
            e.Row.Cells[18].Text = totrw_TotCurr_QueryraisedbyDGWOappl.ToString();
            e.Row.Cells[19].Text = totrw_TotalDGWOQueryraisedNoresponsebyapplbeyond7days.ToString();
            e.Row.Cells[20].Text = totrw_TotalQueryrespondedDGwoappl.ToString();
            e.Row.Cells[21].Text = totrw_TotCurr_QueryrespondedDGwoappl.ToString();
            e.Row.Cells[22].Text = totrw_TotalQueryrespondedapplnoactionbeyond7daysDGWO.ToString();
            e.Row.Cells[23].Text = totrw_TotalApprovedbyDGWOappl.ToString();
            e.Row.Cells[24].Text = totrw_DGWOApprovedwithintimelimit.ToString();
            e.Row.Cells[25].Text = totrw_DGWOapprovedbeyondtimelimit.ToString();
            e.Row.Cells[26].Text = totrw_TotalRejectedbyDGWOappl.ToString();


            e.Row.Cells[27].Text = totrw_TotalApprovedbyMROappl.ToString();
            e.Row.Cells[28].Text = totrw_MROApprovedwithintimelimit.ToString();
            e.Row.Cells[29].Text = totrw_MROapprovedbeyondtimelimit.ToString();
            e.Row.Cells[30].Text = totrw_TotalApprovalRejectedbyMROappl.ToString();
            e.Row.Cells[31].Text = totrw_DWGOrejecteddocuploadedbyMRO.ToString();
            e.Row.Cells[32].Text = totrw_DWGOrejecteddocuploadpendingbyMRO.ToString();

            e.Row.Cells[33].Text = totrw_TotalapplforwardtoTRANSCOappl.ToString();
            e.Row.Cells[34].Text = totrw_TotCurr_applforwardtoTRANSCOappl.ToString();
            e.Row.Cells[35].Text = totrw_totalapplpendinginTRANSCObeyond7days.ToString();
            e.Row.Cells[36].Text = totrw_TotalQueryraisedbyTRANSCOappl.ToString();
            e.Row.Cells[37].Text = totrw_TotCurr_QueryraisedbyTRANSCOappl.ToString();
            e.Row.Cells[38].Text = totrw_TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days.ToString();
            e.Row.Cells[39].Text = totrw_TotalQueryrespondedTRANSCOappl.ToString();
            e.Row.Cells[40].Text = totrw_TotCurr_QueryrespondedTRANSCOappl.ToString();
            e.Row.Cells[41].Text = totrw_TotalQueryrespondedapplnoactionbeyond7daysTRANSCO.ToString();
            e.Row.Cells[42].Text = totrw_TotalApprovedbyTRANSCOappl.ToString();
            e.Row.Cells[43].Text = totrw_TRANSCOApprovedwithintimelimit.ToString();
            e.Row.Cells[44].Text = totrw_TRANSCOapprovedbeyondtimelimit.ToString();
            e.Row.Cells[45].Text = totrw_TotalRejectedbyTRANSCOappl.ToString();





            HyperLink h1 = new HyperLink();
            h1.Text = totrw_TotalApplications.ToString();
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalApplications&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Applications"+"&MandalID=ALL"+ "&MandalName=ALL MANDALS";
                e.Row.Cells[3].Controls.Add(h1);
            }

            HyperLink h2 = new HyperLink();
            h2.Text = totrw_TotalPrescrunitypendinginMROappl.ToString();
            if (h2.Text != "0")
            {
               h2.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalPrescrunitypendinginMROappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Presrunity Pending" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[4].Controls.Add(h2);
            }

            HyperLink h3 = new HyperLink();
            h3.Text = totrw_TotCurr_PrescrunitypendinginMROappl.ToString();
            if (h3.Text != "0")
            {
               h3.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_PrescrunitypendinginMROappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[5].Controls.Add(h3);
            }

            HyperLink h4 = new HyperLink();
            h4.Text = totrw_totalPrescrunitypendingMRObeyond14days.ToString();
            if (h4.Text != "0")
            {
               h4.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=totalPrescrunitypendingMRObeyond14days&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Current Query Responded Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[6].Controls.Add(h4);
            }

            HyperLink h5 = new HyperLink();
            h5.Text = totrw_TotalQueryraisedbyMROappl.ToString();
            if (h5.Text != "0")
            {
               h5.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryraisedbyMROappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Pre-Scrunity Pending after 14 Days" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[7].Controls.Add(h5);
            }

            HyperLink h6 = new HyperLink();
            h6.Text = totrw_TotCurr_QueryraisedbyMROappl.ToString();
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_QueryraisedbyMROappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[8].Controls.Add(h6);
            }
       
            HyperLink h7 = new HyperLink();
            h7.Text = totrw_TotalMROQueryraisedNoresponsebyapplbeyond7days.ToString();
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalMROQueryraisedNoresponsebyapplbeyond7days&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Query Responded,No action Taken within 7 days" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[9].Controls.Add(h7);
            }

            HyperLink h8 = new HyperLink();
            h8.Text = totrw_TotalQueryrespondedtoMROappl.ToString();
            if (h8.Text != "0")
            {
               h8.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryrespondedtoMROappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Query Raised  For Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[10].Controls.Add(h8);
            }

            HyperLink h9 = new HyperLink();
            h9.Text = totrw_TotCurr_QueryrespondedtoMROappl.ToString();
            if (h9.Text != "0")
            {
               h9.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_QueryrespondedtoMROappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[11].Controls.Add(h9);
            }

            HyperLink h10 = new HyperLink();
            h10.Text = totrw_TotalQueryrespondedapplnoactionbeyond7daysMRO.ToString();
            if (h10.Text != "0")
            {
                h10.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryrespondedapplnoactionbeyond7daysMRO&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Approved Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[12].Controls.Add(h10);
            }

            HyperLink h11 = new HyperLink();
            h11.Text = totrw_TotalPrescrunityrejectedMROappl.ToString();
            if (h11.Text != "0")
            {
                h11.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalPrescrunityrejectedMROappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Current Query Raised Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[13].Controls.Add(h11);
            }

            HyperLink h12 = new HyperLink();
            h12.Text = totrw_TotalapplforwardtoDGWOappl.ToString();
            if (h12.Text != "0")
            {
                h12.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalapplforwardtoDGWOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Query raised, no response within 7 days From Applicants" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[14].Controls.Add(h12);
            }

            HyperLink h13 = new HyperLink();
            h13.Text = totrw_TotCurr_applforwardtoDGWOappl.ToString();
            if (h13.Text != "0")
            {
                h13.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_applforwardtoDGWOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[15].Controls.Add(h13);
            }
         
            HyperLink h14 = new HyperLink();
            h14.Text = totrw_totalapplpendinginDGWObeyond7days.ToString();
            if (h14.Text != "0")
            {
                h14.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=totalapplpendinginDGWObeyond7days&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[16].Controls.Add(h14);
            }

            HyperLink h15 = new HyperLink();
            h15.Text = totrw_TotalQueryraisedbyDGWOappl.ToString();
            if (h15.Text != "0")
            {
                h15.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryraisedbyDGWOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Query Responded Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[17].Controls.Add(h15);
            }

            HyperLink h16 = new HyperLink();
            h16.Text = totrw_TotCurr_QueryraisedbyDGWOappl.ToString();
            if (h16.Text != "0")
            {
                h16.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_QueryraisedbyDGWOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[18].Controls.Add(h16);
            }

            HyperLink h17 = new HyperLink();
            h17.Text = totrw_TotalDGWOQueryraisedNoresponsebyapplbeyond7days.ToString();
            if (h17.Text != "0")
            {
                h17.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalDGWOQueryraisedNoresponsebyapplbeyond7days&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Query Responded,No action Taken within 7 days" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[19].Controls.Add(h17);
            }
          
            HyperLink h18 = new HyperLink();
            h18.Text = totrw_TotalQueryrespondedDGwoappl.ToString();
            if (h18.Text != "0")
            {
                h18.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryrespondedDGwoappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Current Query Responded Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[20].Controls.Add(h18);
            }

            HyperLink h19 = new HyperLink();
            h19.Text = totrw_TotCurr_QueryrespondedDGwoappl.ToString();
            if (h19.Text != "0")
            {
                h19.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_QueryrespondedDGwoappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[21].Controls.Add(h19);
            }

            HyperLink h20 = new HyperLink();
            h20.Text = totrw_TotalQueryrespondedapplnoactionbeyond7daysDGWO.ToString();
            if (h20.Text != "0")
            {
                h20.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryrespondedapplnoactionbeyond7daysDGWO&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Approved Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[22].Controls.Add(h20);
            }

            HyperLink h21= new HyperLink();
            h21.Text = totrw_TotalApprovedbyDGWOappl.ToString();
            if (h21.Text != "0")
            {
                h21.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalApprovedbyDGWOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Query Responded,No action Taken within 7 days" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[23].Controls.Add(h21);
            }

            HyperLink h22 = new HyperLink();
            h22.Text = totrw_DGWOApprovedwithintimelimit.ToString();
            if (h22.Text != "0")
            {
                h22.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=DGWOApprovedwithintimelimit&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[24].Controls.Add(h22);
            }

            HyperLink h23 = new HyperLink();
            h23.Text = totrw_DGWOapprovedbeyondtimelimit.ToString();
            if (h23.Text != "0")
            {
               h23.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=DGWOapprovedbeyondtimelimit&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Query Responded,No action Taken within 7 days" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[25].Controls.Add(h23);
            }

            HyperLink h24 = new HyperLink();
            h24.Text = totrw_TotalRejectedbyDGWOappl.ToString();
            if (h24.Text != "0")
            {
               h24.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalRejectedbyDGWOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Approved Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[26].Controls.Add(h24);
            }

            HyperLink h25 = new HyperLink();
            h25.Text = totrw_TotalApprovedbyMROappl.ToString();
            if (h25.Text != "0")
            {
                h25.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalApprovedbyMROappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[27].Controls.Add(h25);
            }

            HyperLink h26 = new HyperLink();
            h26.Text = totrw_MROApprovedwithintimelimit.ToString();
            if (h26.Text != "0")
            {
                h26.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=MROApprovedwithintimelimit&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Approved Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[28].Controls.Add(h26);
            }

            HyperLink h27 = new HyperLink();
            h27.Text = totrw_MROapprovedbeyondtimelimit.ToString();
            if (h27.Text != "0")
            {
                h27.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=MROapprovedbeyondtimelimit&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[29].Controls.Add(h27);
            }

            HyperLink h28 = new HyperLink();
            h28.Text = totrw_TotalApprovalRejectedbyMROappl.ToString();
            if (h28.Text != "0")
            {
                h28.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalApprovalRejectedbyMROappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Query Responded Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[30].Controls.Add(h28);
            }

            HyperLink h29 = new HyperLink();
            h29.Text = totrw_DWGOrejecteddocuploadedbyMRO.ToString();
            if (h29.Text != "0")
            {
                h29.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=DWGOrejecteddocuploadedbyMRO&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Approved Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[31].Controls.Add(h29);
            }

            HyperLink h30 = new HyperLink();
            h30.Text = totrw_DWGOrejecteddocuploadpendingbyMRO.ToString();
            if (h30.Text != "0")
            {
                h30.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=DWGOrejecteddocuploadpendingbyMRO&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[32].Controls.Add(h30);
            }

            //TRANSCO
            HyperLink h31 = new HyperLink();
            h31.Text = totrw_TotalapplforwardtoTRANSCOappl.ToString();
            if (h31.Text != "0")
            {
                h31.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalapplforwardtoTRANSCOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Query raised, no response within 7 days From Applicants" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[33].Controls.Add(h31);
            }

            HyperLink h32 = new HyperLink();
            h32.Text = totrw_TotCurr_applforwardtoTRANSCOappl.ToString();
            if (h32.Text != "0")
            {
                h32.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_applforwardtoTRANSCOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[34].Controls.Add(h32);
            }

            HyperLink h33 = new HyperLink();
            h33.Text = totrw_totalapplpendinginTRANSCObeyond7days.ToString();
            if (h33.Text != "0")
            {
                h33.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=totalapplpendinginTRANSCObeyond7days&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[35].Controls.Add(h33);
            }

            HyperLink h34 = new HyperLink();
            h34.Text = totrw_TotalQueryraisedbyTRANSCOappl.ToString();
            if (h34.Text != "0")
            {
                h34.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryraisedbyTRANSCOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Query Responded Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[36].Controls.Add(h34);
            }

            HyperLink h35 = new HyperLink();
            h35.Text = totrw_TotCurr_QueryraisedbyTRANSCOappl.ToString();
            if (h35.Text != "0")
            {
                h35.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_QueryraisedbyTRANSCOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[37].Controls.Add(h35);
            }

            HyperLink h36 = new HyperLink();
            h36.Text = totrw_TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days.ToString();
            if (h36.Text != "0")
            {
                h36.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalTRANSCOQueryraisedNoresponsebyapplbeyond7days&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Query Responded,No action Taken within 7 days" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[38].Controls.Add(h36);
            }

            HyperLink h37 = new HyperLink();
            h37.Text = totrw_TotalQueryrespondedTRANSCOappl.ToString();
            if (h37.Text != "0")
            {
                h37.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryrespondedTRANSCOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Current Query Responded Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[39].Controls.Add(h37);
            }

            HyperLink h38 = new HyperLink();
            h38.Text = totrw_TotCurr_QueryrespondedTRANSCOappl.ToString();
            if (h38.Text != "0")
            {
                h38.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotCurr_QueryrespondedTRANSCOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[40].Controls.Add(h38);
            }

            HyperLink h39 = new HyperLink();
            h39.Text = totrw_TotalQueryrespondedapplnoactionbeyond7daysTRANSCO.ToString();
            if (h39.Text != "0")
            {
                h39.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalQueryrespondedapplnoactionbeyond7daysTRANSCO&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Approved Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[41].Controls.Add(h39);
            }

            HyperLink h40 = new HyperLink();
            h40.Text = totrw_TotalApprovedbyTRANSCOappl.ToString();
            if (h40.Text != "0")
            {
                h40.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalApprovedbyTRANSCOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Query Responded,No action Taken within 7 days" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[42].Controls.Add(h40);
            }

            HyperLink h41 = new HyperLink();
            h41.Text = totrw_TRANSCOApprovedwithintimelimit.ToString();
            if (h41.Text != "0")
            {
                h41.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TRANSCOApprovedwithintimelimit&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Rejected Applications" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[43].Controls.Add(h41);
            }

            HyperLink h42 = new HyperLink();
            h42.Text = totrw_TRANSCOapprovedbeyondtimelimit.ToString();
            if (h42.Text != "0")
            {
                h42.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TRANSCOapprovedbeyondtimelimit&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Query Responded,No action Taken within 7 days" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[44].Controls.Add(h42);
            }

            HyperLink h43 = new HyperLink();
            h43.Text = totrw_TotalRejectedbyTRANSCOappl.ToString();
            if (h43.Text != "0")
            {
                h43.NavigateUrl = "RptWellApplicationlistmandalwiseReport.aspx?Typedataofappl=TotalRejectedbyTRANSCOappl&DistrictID=ALL" + "&DistrictName=ALL" + "&Category=Total Approved Application" + "&MandalID=ALL" + "&MandalName=ALL MANDALS";
                e.Row.Cells[45].Controls.Add(h43);
            }





            h1.ForeColor = System.Drawing.Color.White;
            h2.ForeColor = System.Drawing.Color.White;
            h3.ForeColor = System.Drawing.Color.White;
            h4.ForeColor = System.Drawing.Color.White;
            h5.ForeColor = System.Drawing.Color.White;
            h6.ForeColor = System.Drawing.Color.White;
            h7.ForeColor = System.Drawing.Color.White;
            h8.ForeColor = System.Drawing.Color.White;
            h9.ForeColor = System.Drawing.Color.White;
            h10.ForeColor = System.Drawing.Color.White;

            h11.ForeColor = System.Drawing.Color.White;
            h12.ForeColor = System.Drawing.Color.White;
            h13.ForeColor = System.Drawing.Color.White;
            h14.ForeColor = System.Drawing.Color.White;
            h15.ForeColor = System.Drawing.Color.White;
            h16.ForeColor = System.Drawing.Color.White;
            h17.ForeColor = System.Drawing.Color.White;
            h18.ForeColor = System.Drawing.Color.White;
            h19.ForeColor = System.Drawing.Color.White;
            h20.ForeColor = System.Drawing.Color.White;

            h21.ForeColor = System.Drawing.Color.White;
            h22.ForeColor = System.Drawing.Color.White;
            h23.ForeColor = System.Drawing.Color.White;
            h24.ForeColor = System.Drawing.Color.White;

            h25.ForeColor = System.Drawing.Color.White;
            h26.ForeColor = System.Drawing.Color.White;
            h27.ForeColor = System.Drawing.Color.White;
            h28.ForeColor = System.Drawing.Color.White;
            h29.ForeColor = System.Drawing.Color.White;
            h30.ForeColor = System.Drawing.Color.White;

            h31.ForeColor = System.Drawing.Color.White;
            h32.ForeColor = System.Drawing.Color.White;
            h33.ForeColor = System.Drawing.Color.White;
            h34.ForeColor = System.Drawing.Color.White;
            h35.ForeColor = System.Drawing.Color.White;
            h36.ForeColor = System.Drawing.Color.White;
            h37.ForeColor = System.Drawing.Color.White;
            h38.ForeColor = System.Drawing.Color.White;
            h39.ForeColor = System.Drawing.Color.White;
            h40.ForeColor = System.Drawing.Color.White;
            h41.ForeColor = System.Drawing.Color.White;
            h42.ForeColor = System.Drawing.Color.White;
            h43.ForeColor = System.Drawing.Color.White;
        }

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {

            //cast the sender back to a gridview
            GridView gv = sender as GridView;

            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //create the first row
                GridViewRow extraHeader1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                extraHeader1.BackColor = System.Drawing.Color.LightSalmon;

                TableCell cell0 = new TableCell();
                cell0.ColumnSpan = 4;
                cell0.Text = "";
                extraHeader1.Cells.Add(cell0);

                TableCell cell1 = new TableCell();
                cell1.ColumnSpan = 10;
                cell1.Text = "MRO Applications";
                extraHeader1.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.ColumnSpan = 13;
                cell2.Text = "District Ground Water Officer Applications";
                extraHeader1.Cells.Add(cell2);

                TableCell cell20 = new TableCell();
                cell20.ColumnSpan = 6;
                cell20.Text = "MRO Approval/Rejected Applications";
                extraHeader1.Cells.Add(cell20);

                TableCell cell21 = new TableCell();
                cell21.ColumnSpan = 13;
                cell21.Text = "District TRANSCO Officer Applications";
                extraHeader1.Cells.Add(cell21);

                //create the second row
                GridViewRow extraHeader2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                extraHeader2.BackColor = System.Drawing.Color.LightGreen;

                TableCell cell3 = new TableCell();
                cell3.ColumnSpan = 4;
                extraHeader2.Cells.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.ColumnSpan = 3;
                cell4.Text = "Pre-Scruinty Pending";
                extraHeader2.Cells.Add(cell4);

                TableCell cell5 = new TableCell();
                cell5.ColumnSpan = 3;
                cell5.Text = "Query Raised";
                extraHeader2.Cells.Add(cell5);

                TableCell cell6 = new TableCell();
                cell6.ColumnSpan = 3;
                cell6.Text = "Query Response";
                extraHeader2.Cells.Add(cell6);

                TableCell cell7 = new TableCell();
                cell7.ColumnSpan = 1;
                cell7.Text = "MRO Pre-scrunity Rejected";
                extraHeader2.Cells.Add(cell7);

                TableCell cell8 = new TableCell();
                cell8.ColumnSpan = 3;
                cell8.Text = "Forward by MRO";
                extraHeader2.Cells.Add(cell8);

                TableCell cell9 = new TableCell();
                cell9.ColumnSpan = 3;
                cell9.Text = "Query Raised";
                extraHeader2.Cells.Add(cell9);

                TableCell cell10 = new TableCell();
                cell10.ColumnSpan = 3;
                cell10.Text = "Query Response";
                extraHeader2.Cells.Add(cell10);


                TableCell cell11 = new TableCell();
                cell11.ColumnSpan = 3;
                cell11.Text = "DGWO Approved & Forward to MRO";
                extraHeader2.Cells.Add(cell11);

                TableCell cell12 = new TableCell();
                cell12.ColumnSpan = 1;
                cell12.Text = "DGWO Rejected";
                extraHeader2.Cells.Add(cell12);

                TableCell cell13 = new TableCell();
                cell13.ColumnSpan = 3;
                cell13.Text = "MRO Approved";
                extraHeader2.Cells.Add(cell13);

                TableCell cell14 = new TableCell();
                cell14.ColumnSpan = 3;
                cell14.Text = "MRO Rejected";
                extraHeader2.Cells.Add(cell14);



                TableCell cell81 = new TableCell();
                cell81.ColumnSpan = 3;
                cell81.Text = "Forward by MRO";
                extraHeader2.Cells.Add(cell81);

                TableCell cell91 = new TableCell();
                cell91.ColumnSpan = 3;
                cell91.Text = "Query Raised";
                extraHeader2.Cells.Add(cell91);

                TableCell cell101 = new TableCell();
                cell101.ColumnSpan = 3;
                cell101.Text = "Query Response";
                extraHeader2.Cells.Add(cell101);


                TableCell cell111 = new TableCell();
                cell111.ColumnSpan = 3;
                cell111.Text = "TRANSCO Approved & Forward to MRO";
                extraHeader2.Cells.Add(cell111);

                TableCell cell121 = new TableCell();
                cell121.ColumnSpan = 1;
                cell121.Text = "TRANSCO Rejected";
                extraHeader2.Cells.Add(cell121);



                ////create the third row
                //GridViewRow extraHeader3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                //extraHeader3.BackColor = System.Drawing.Color.LightBlue;

                ////loop all the columns and create a new cell for each
                //for (int i = 0; i < gv.Columns.Count; i++)
                //{
                //    TableCell cell = new TableCell();
                //    if (i == 0)
                //        cell.Text = "Foo";
                //    else if (i == 1)
                //        cell.Text = "Bar";
                //    else
                //        cell.Text = (i - 1).ToString();

                //    extraHeader3.Cells.Add(cell);
                //}

                //add the new rows to the gridview
                // gv.Controls[0].Controls.AddAt(0, extraHeader3);
                gv.Controls[0].Controls.AddAt(0, extraHeader2);
                gv.Controls[0].Controls.AddAt(0, extraHeader1);
            }

            #region
            //GridViewRow gvHeaderRow = e.Row;
            //GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            //this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            //int headerCellCount = gvHeaderRow.Cells.Count;
            //int cellIndex = 0;

            //for (int i = 0; i < headerCellCount; i++)
            //{
            //    if (i > 2 && i < 11)
            //    {
            //        cellIndex++;
            //    }
            //    else
            //    {
            //        TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
            //        //if (i == 0 || i == 1 || i == 2)
            //        //{
            //        tcHeader.RowSpan = 2;
            //        gvHeaderRowCopy.Cells.Add(tcHeader);


            //    }
            //}

            //TableCell tcMergePackage = new TableCell();
            //tcMergePackage.Text = "Presrunity Pending Applications";
            //tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage.ColumnSpan = 2;
            //gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage);

            //TableCell tcMergePackage1 = new TableCell();
            //tcMergePackage1.Text = "Query Raised Applications";
            //tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage1.ColumnSpan = 3;
            //gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage1);

            //TableCell tcMergePackage2 = new TableCell();
            //tcMergePackage2.Text = "Query Responded Applications";
            //tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage2.ColumnSpan = 3;
            //gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage2);
            #endregion
        }
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();
        // fillgrid();

    }
    protected void ExportToExcel()
    {
        string DistrictID = ""; string MandalID = "";
        if (ddlDIst.SelectedIndex > 0)
        {
            DistrictID = Convert.ToString(ddlDIst.SelectedValue);
        }

        if (ddlMandal.SelectedIndex > 0)
        {
            MandalID = Convert.ToString(ddlMandal.SelectedValue);
        }
        ////fillgrid(DistrictID, MandalID);
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=R6.3: TSiPASS - Progress Of Implementation Report.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            //  Government.Visible = true;
            tr1.Style["width"] = "680px";
            // Button1.Visible = false;
            Button2.Visible = false;
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                //To Export all pages
                grdDetails.AllowPaging = false;
                this.fillgrid(DistrictID, MandalID);

                grdDetails.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in grdDetails.HeaderRow.Cells)
                {
                    //cell.BackColor = grdDetails.HeaderStyle.BackColor;
                    cell.ForeColor = System.Drawing.Color.Black;
                }
                foreach (TableCell cell in grdDetails.FooterRow.Cells)
                {
                    cell.BackColor = System.Drawing.Color.White;
                    cell.ForeColor = System.Drawing.Color.Black;
                    // cell.
                }


                foreach (TableCell cell in grdDetails.FooterRow.Cells)
                {

                    cell.CssClass = "textmode";
                    List<Control> controls = new List<Control>();
                    foreach (Control control in cell.Controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "HyperLink":
                                controls.Add(control);
                                break;
                            case "TextBox":
                                controls.Add(control);
                                break;
                            case "LinkButton":
                                controls.Add(control);
                                break;
                            case "CheckBox":
                                controls.Add(control);
                                break;
                            case "RadioButton":
                                controls.Add(control);
                                break;
                        }
                    }
                    foreach (Control control in controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "HyperLink":
                                cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                break;
                            case "TextBox":
                                cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                break;
                            case "LinkButton":
                                cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                break;
                            case "CheckBox":
                                cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                break;
                            case "RadioButton":
                                cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                break;
                        }
                        cell.Controls.Remove(control);
                    }
                }
                foreach (GridViewRow row in grdDetails.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdDetails.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdDetails.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                        List<Control> controls = new List<Control>();
                        foreach (Control control in cell.Controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    controls.Add(control);
                                    break;
                                case "TextBox":
                                    controls.Add(control);
                                    break;
                                case "LinkButton":
                                    controls.Add(control);
                                    break;
                                case "CheckBox":
                                    controls.Add(control);
                                    break;
                                case "RadioButton":
                                    controls.Add(control);
                                    break;
                            }
                        }
                        foreach (Control control in controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                    break;
                                case "TextBox":
                                    cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                    break;
                                case "LinkButton":
                                    cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                    break;
                                case "CheckBox":
                                    cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                    break;
                                case "RadioButton":
                                    cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                    break;
                            }
                            cell.Controls.Remove(control);
                        }
                    }
                }

                divPrint.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=Report " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    Button2.Visible = false;
            //    Button1.Visible = false;
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    divPrint.RenderControl(hw);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}
        }
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    //trLogo.Visible = true;
                    grdDetails.AllowPaging = false;
                    //this.FillGridDetails(rbtnlstInputType.SelectedValue.ToString().Trim(), ddlFinancialYear.SelectedValue.ToString().Trim(), FromdateforDB, TodateforDB);
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.Visible = true;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= R1.5_Month_wise_Applications_Received" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception e)
        {

        }
    }
}