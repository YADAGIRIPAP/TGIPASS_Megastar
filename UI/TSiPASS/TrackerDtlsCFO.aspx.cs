using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UI_TSiPASS_TrackerDtlsCFO : System.Web.UI.Page
{
    General Gen = new General();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string intQuessionaireid = "", intStageid = "", intApprovalid = "";

            intQuessionaireid = Request.QueryString["intQuessionaireid"].ToString().Trim();
            intStageid = Request.QueryString["intStageid"].ToString().Trim();
            intApprovalid = Request.QueryString["intApprovalid"].ToString().Trim();

            DataSet dscheck = new DataSet();
            dscheck = Gen.GetApplicationTrackerDetailedDetailsCFO(intQuessionaireid, intStageid, intApprovalid);
            if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
            {
                if (intStageid == "1")
                {
                    trquerydtls.Visible = true;
                    trPayment.Visible = false;
                    trrejcted.Visible = false;
                    Divappsinfo.Visible = false;
                    tddeptname.InnerText = dscheck.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                    tdqdate.InnerText = dscheck.Tables[0].Rows[0]["QRYRSDDATE"].ToString().Trim();
                    tdremarks.InnerText = dscheck.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                    tdResponseDate.InnerText = dscheck.Tables[0].Rows[0]["QRYRESPDATE"].ToString().Trim();
                    tdnotakes.InnerText = dscheck.Tables[0].Rows[0]["Nodaystakne"].ToString().Trim();
                    tdresonce.InnerText = dscheck.Tables[0].Rows[0]["QueryRespondRemarks"].ToString().Trim();
                    if (dscheck.Tables[0].Rows[0]["QueryRespondRemarks"].ToString().Trim() == "")
                    {
                        trresponce1.Visible = false;
                        trresponce2.Visible = false;
                    }
                    else
                    {
                        trresponce1.Visible = true;
                        trresponce2.Visible = true;
                    }
                }
                else if (intStageid == "2" || intStageid == "3")
                {
                    trquerydtls.Visible = false;
                    trPayment.Visible = true;
                    trrejcted.Visible = false;
                    Divappsinfo.Visible = false;
                    grdDetails.DataSource = dscheck.Tables[0];
                    grdDetails.DataBind();

                    foreach (GridViewRow row in grdDetails.Rows)
                    {
                        //foreach (TableCell cell in row.Cells)
                        //{
                        row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                        row.Cells[3].Attributes.CssStyle["Width"] = "100px";
                        //}
                    }
                }
                else if (intStageid == "4")
                {
                    trquerydtls.Visible = false;
                    trPayment.Visible = false;
                    trrejcted.Visible = true;
                    Divappsinfo.Visible = false;
                    tddeptnamenew.InnerText = dscheck.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                    tdrejcteddate.InnerText = dscheck.Tables[0].Rows[0]["Dept_Rejected_date"].ToString().Trim();
                    tdremarksrejected.InnerText = dscheck.Tables[0].Rows[0]["rejected_reason"].ToString().Trim();
                    if (dscheck != null && dscheck.Tables.Count > 1 && dscheck.Tables[1].Rows.Count > 0)
                    {
                        hmdaattachements.Visible = true;
                        gvlastattachments.DataSource = dscheck.Tables[1];
                        gvlastattachments.DataBind();
                    }
                }
                else if (intStageid == "5")
                {
                    trquerydtls.Visible = false;
                    trPayment.Visible = false;
                    trrejcted.Visible = false;
                    Divappsinfo.Visible = true;
                    if (intApprovalid == "6" || intApprovalid == "45")
                    {
                        tddeptnameapp.InnerText = dscheck.Tables[0].Rows[0]["Name of the approval"].ToString().Trim();
                        tdApprovalAppliedDate.InnerText = dscheck.Tables[0].Rows[0]["Approval Application Date"].ToString().Trim();
                        tdtpscdate.InnerText = dscheck.Tables[0].Rows[0]["Target Date of PSC"].ToString().Trim();
                        tdpscdate.InnerText = dscheck.Tables[0].Rows[0]["PSC Completion_Rejection Date"].ToString().Trim();

                        tddaystakenpsc.InnerText = dscheck.Tables[0].Rows[0]["No of days taken for PSC excluding holidays"].ToString().Trim();
                        tdReceivedApproval.InnerText = dscheck.Tables[0].Rows[0]["Date of Approval received to Approval Stage Max of payment or PSC date"].ToString().Trim();
                        tdSendMAUDTarget.InnerText = dscheck.Tables[0].Rows[0]["APPROVALDATEHMDANEW"].ToString().Trim();
                        tdDateofSenttoMAUD.InnerText = dscheck.Tables[0].Rows[0]["HMDASnetDate"].ToString().Trim();
                        tdDaysTaken.InnerText = dscheck.Tables[0].Rows[0]["Noofdaystakentosendmaud"].ToString().Trim();   // hmda days 
                        // tdpscdate.InnerText = dscheck.Tables[0].Rows[0][""].ToString().Trim();
                    }
                    if (intApprovalid == "45")
                    {
                        trmauddata1.Visible = true;
                        trmauddata.Visible = true;
                        trmauddata2.Visible = true;
                        tdTargetDateforApprovalmaud.InnerText = dscheck.Tables[0].Rows[0]["APPROVALDATEMAUDNEW"].ToString().Trim();
                        tdActualApprovaldate.InnerText = dscheck.Tables[0].Rows[0]["Actual Date of Approval Rejection"].ToString().Trim();
                        tdDaysTakenforApproval.InnerText = dscheck.Tables[0].Rows[0]["Noofdaystakentoapprovemaud"].ToString().Trim();
                    }
                }
            }
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            decimal TotalFee1 = Convert.ToDecimal(e.Row.Cells[3].Text);
            TotalFee = TotalFee + TotalFee1;
        }
        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            e.Row.Cells[2].Text = "Total Fee";
            e.Row.Cells[3].Text = Convert.ToDecimal(TotalFee.ToString()).ToString("#,##0");
            e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
        }
    }
}