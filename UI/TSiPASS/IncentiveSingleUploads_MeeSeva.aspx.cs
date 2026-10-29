using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic;
//using MeeSeva;
using MeeSeva_Live;
using System.Xml;

public partial class TSTBDCReg1 : System.Web.UI.Page
{
    comFunctions objCmf = new comFunctions();
    BusinessLogic.DML objDml = new BusinessLogic.DML();
    BusinessLogic.Fetch objFetch = new BusinessLogic.Fetch();
    MeeSevaWebService objMeeSeva = new MeeSevaWebService();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0) { ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true); return; }

            if (!IsPostBack)
            {
                tblPayment.Visible = false;
                if (Session["dtIncentiveTypes"] != null)
                {
                    DataTable dtInctypes = new DataTable();
                    DataTable dt = new DataTable();
                    DataTable dtUploads = new DataTable();

                    btnNext.Visible = btnPrevious.Visible = false;

                    dtInctypes = objFetch.FetchIncentiveTypes();
                    dt = (Session["dtIncentiveTypes"] as DataTable);

                    if (Request.QueryString.Count > 0 && Request.QueryString["q"] != null)
                    {
                        dtUploads = objFetch.FetchIncentiveUploads(Convert.ToInt32(Session["EntprIncentive"].ToString()), Convert.ToInt32(Request.QueryString["q"]));
                        lblIncHeaderType.Text = lblIncentivetype.Text = dtInctypes.AsEnumerable()
                                                                                  .Where(r => r.Field<int>("ID") == Convert.ToInt32(Request.QueryString["q"].ToString()))
                                                                                  .CopyToDataTable().Rows[0][1].ToString();

                        objCmf.FillGrid(dtUploads, grdChecklistsDocument, true);
                        //lblIncentiveNameTitle.Text = dt.Rows[0][0].ToString();
                        if (dt.Rows[0][0].ToString().Trim() == Request.QueryString["q"].ToString().Trim())
                        {
                            btnPrevious.Visible = true;
                            btnPrevious.PostBackUrl = "~/UI/TSiPASS/TypeOfIncentives_MeeSeva.aspx";
                            if (dt.Rows.Count > 1)
                            {
                                btnNext.PostBackUrl = "~/UI/TSiPASS/IncentiveSingleUploads_MeeSeva.aspx?q=" + dt.Rows[1][0];
                                btnNext.Visible = true;
                            }
                        }
                        else
                        {
                            if (dt.Rows.Count > 1)
                            {
                                for (int i = 1; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i][0].ToString().Trim() == Request.QueryString["q"].ToString().Trim())
                                    {
                                        btnPrevious.Visible = true;
                                        btnPrevious.PostBackUrl = "~/UI/TSiPASS/IncentiveSingleUploads_MeeSeva.aspx?q=" + dt.Rows[i - 1][0].ToString();
                                        btnNext.Visible = false;
                                        if (dt.Rows.Count > i+1)
                                        {
                                            btnNext.PostBackUrl = "~/UI/TSiPASS/IncentiveSingleUploads_MeeSeva.aspx?q=" + dt.Rows[i + 1][0].ToString();
                                            btnNext.Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (!btnNext.Visible)
                { 
                    btnsave.Text = "Confirm Payment";
                    tblPayment.Visible = true;
                }
            }
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Failure.Visible= success.Visible = false;
            bool isValid = true;
            foreach (GridViewRow gr in grdChecklistsDocument.Rows)
            {
                if ((gr.FindControl("lhl") as HyperLink).Text.Trim() == ""
                        && (gr.FindControl("lblisMandatoryDoc") as Label).Text.Trim().ToLower() == "yes")
                {
                    isValid = false;
                    Failure.Visible = true;
                    lblmsg0.Text = "Please upload Mandatory Document(s).";
                    gr.BackColor = System.Drawing.Color.Pink;
                }
            }

            if (isValid)
            {
                if (btnsave.Text == "Confirm Payment")
                {   
                        if (Session["dtIncentiveTypes"] != null && (Session["dtIncentiveTypes"] as DataTable).Rows.Count > 0)
                        {
                            DataTable dt = (Session["dtIncentiveTypes"] as DataTable);
                            if (Request.QueryString["q"].ToString() == dt.Rows[dt.Rows.Count - 1][0].ToString())
                            {
                                btnNext.Visible = btnsave.Visible = grdChecklistsDocument.Enabled = false;                                
                                DataTable dtMeeSeva = objFetch.Fetch_MeeSevaBeforPayment(Convert.ToInt32(Session["EntprIncentive"].ToString()));
                                
                                string[] arrPaymentDetails = new string[9];

                                arrPaymentDetails[0] = Session["StrUniqueNo"].ToString();
                                arrPaymentDetails[1] = Session["StrSCAId"].ToString();
                                arrPaymentDetails[2] = "CA";
                                arrPaymentDetails[3] = Session["StrMeesevaUserId"].ToString();
                                arrPaymentDetails[4] = Session["StrChannelId"].ToString();
                                arrPaymentDetails[5] = Session["EntprIncentive"].ToString();
                                arrPaymentDetails[6] = Session["StrMeesevaRequestId"].ToString();
                                arrPaymentDetails[7] = Session["StrServiceid"].ToString();
                                arrPaymentDetails[8] = Session["StrScaPassword"].ToString();

                                string[] arrAmount = new string[5];
                                arrAmount[0] = txtUserCharges.Text;
                                arrAmount[1] = "0";
                                arrAmount[2] = "0";
                                arrAmount[3] = "0";
                                arrAmount[4] = "0";

                                string[] arrTransParams = new string[4];
                                arrTransParams[0] = "ApplciantName";
                                arrTransParams[1] = "MobileNo";
                                arrTransParams[2] = "DistrictID";
                                arrTransParams[3] = "Total Amount";

                                string[] arrTransDetails = new string[4];
                                arrTransDetails[0] = dtMeeSeva.Rows[0]["ApplciantName"].ToString();
                                arrTransDetails[1] = dtMeeSeva.Rows[0]["MobileNo"].ToString();
                                arrTransDetails[2] = dtMeeSeva.Rows[0]["MeeSevaDistrictCode"].ToString();
                                arrTransDetails[3] = txtTotalAmt.Text;

                                XmlNode xmlMeeSeva = objMeeSeva.GetPaymentGatewayResponse(arrPaymentDetails, arrAmount, arrTransParams, arrTransDetails, "MEESEVA", "MEESEVA", Session["StrChecksum"].ToString());
                                //Response.Write("b");
                                if (xmlMeeSeva.FirstChild.InnerText.Trim() == "0")
                                {
                                    //Response.Write("a");
                                    string[] arrPaymentDetailsDone = new string[12];
                                    arrPaymentDetailsDone[0] = Session["StrUniqueNo"].ToString();
                                    arrPaymentDetailsDone[1] = Session["StrSCAId"].ToString();
                                    arrPaymentDetailsDone[2] = "CA";
                                    arrPaymentDetailsDone[3] = Session["StrMeesevaUserId"].ToString();
                                    arrPaymentDetailsDone[4] = Session["StrChannelId"].ToString();
                                    arrPaymentDetailsDone[5] = Session["EntprIncentive"].ToString();
                                    arrPaymentDetailsDone[6] = Session["StrMeesevaRequestId"].ToString();
                                    arrPaymentDetailsDone[7] = Session["StrServiceid"].ToString();
                                    arrPaymentDetailsDone[8] = Session["EntprIncentive"].ToString();
                                    arrPaymentDetailsDone[9] = "00";
                                    arrPaymentDetailsDone[10] = Session["StrScaPassword"].ToString();
                                    arrPaymentDetailsDone[11] = Session["StrMeesevaFlag"].ToString();

                                    string[] arrTransParamsList = new string[9];
                                    arrTransParamsList[0] = "Applicant Name";
                                    arrTransParamsList[1] = "District";
                                    arrTransParamsList[2] = "Mandal";
                                    arrTransParamsList[3] = "Village";
                                    arrTransParamsList[4] = "SLA";
                                    arrTransParamsList[5] = "DeliveryType";
                                    arrTransParamsList[6] = "TotalAmount";
                                    arrTransParamsList[7] = "Status";
                                    arrTransParamsList[8] = "SLAEnddate";

                                    string[] arrTransParamsDone = new string[9];
                                    arrTransParamsDone[0] = dtMeeSeva.Rows[0]["ApplciantName"].ToString();
                                    arrTransParamsDone[1] = dtMeeSeva.Rows[0]["MeeSevaDistrictCode"].ToString();
                                    arrTransParamsDone[2] = "00";
                                    arrTransParamsDone[3] = "00";
                                    arrTransParamsDone[4] = "0";
                                    arrTransParamsDone[5] = "Manual";
                                    arrTransParamsDone[6] = txtTotalAmt.Text;
                                    arrTransParamsDone[7] = "02";
                                    arrTransParamsDone[8] = DateTime.Now.ToString("dd/MM/yyyy");

                                    XmlNode xt= objMeeSeva.GetPaymentTransId(arrPaymentDetailsDone, arrAmount, arrTransParamsDone, arrTransParamsDone, "MEESEVA", "MEESEVA", Session["StrChecksum"].ToString());
                                    try
                                    {
                                        if (xt["ERRORCODE"].InnerText.ToString() == "0")
                                        {
                                            objDml.updMeeSevatbl_Incentive(Convert.ToInt32(Session["EntprIncentive"].ToString()), xt["TRANSID"].InnerText.ToString());
                                        }
                                        else
                                        {
                                            Failure.Visible = true;
                                            lblmsg0.Text = " Transaction Failed .";
                                        }
                                        //objMeeSeva.UpdateApplicationDetails(
                                    }
                                    catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
                                    success.Visible = true;
                                    Session["EmUdyog"] = null;
                                    Response.Redirect("PrintReceipt_MeeSeva.aspx", false);
                                }

                                else
                                {
                                    Failure.Visible = true;
                                    lblmsg0.Text = "Transaction Failed.";
                                }
                            }
                            else
                            {
                                btnsave.Visible = grdChecklistsDocument.Enabled = false;
                                btnNext.Visible = true;
                                success.Visible = true;
                            }
                        }
                }
            }
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        try { Response.Redirect(btnPrevious.PostBackUrl, false); }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        try { Response.Redirect(btnNext.PostBackUrl, false); }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void grdChecklistsDocument_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gr = grdChecklistsDocument.Rows[Convert.ToInt32(e.CommandArgument.ToString())];
            FileUpload fp = (gr.FindControl("fuDocuments") as FileUpload);
            if (fp.HasFile && fp.FileBytes.Length > 0)
            {
                if (fp.PostedFile.ContentLength > 30000000)
                {
                    Failure.Visible = true;
                    lblmsg0.Text = " Please ensure that uploaded file size is Less than 30MB.";
                    return;
                }

                string path = Server.MapPath("") + "\\IncentivesAttachments\\" + Session["EntprIncentive"].ToString();
                if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
                fp.SaveAs(path + "\\" + fp.FileName);

                objDml.InsUpdDeltd_Incentive_Uploads(Convert.ToInt32(Session["EntprIncentive"].ToString()),
                                                        Convert.ToInt32((gr.FindControl("lblIncentiveID") as Label).Text),
                                                        Convert.ToInt32((gr.FindControl("lblattachmentID") as Label).Text),
                                                        fp.FileName,
                                                        path + "\\" + fp.FileName,
                                                        0
                                                    );

                (gr.FindControl("lhl") as HyperLink).Text = fp.FileName;
                (gr.FindControl("lhl") as HyperLink).NavigateUrl = "https://ipass.telangana.gov.in/IncentivesAttachments/" + Session["EntprIncentive"].ToString() + "/" + fp.FileName;
                //(gr.FindControl("lblAttachedFileName") as Label).Text = fp.FileName;
            }
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }
}   