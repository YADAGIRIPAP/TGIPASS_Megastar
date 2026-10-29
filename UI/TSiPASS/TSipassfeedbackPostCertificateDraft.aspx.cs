using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_TSipassfeedbackPostCertificateDraft : System.Web.UI.Page
{
    General Gen = new General();
    //TsipassFeedbackFormVOs objvo = new TsipassFeedbackFormVOs();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["uid"] != null)
                {

                    int postapplslno = 0;
                    if (Request.QueryString["postapplslno"] != null && Request.QueryString["postapplslno"].ToString() != "")
                    {
                        postapplslno = Convert.ToInt32(Request.QueryString["postapplslno"].ToString());
                        filldetails(postapplslno);
                        EnableDisableForm(Page.Controls, false);
                    }

                }
                else
                {
                    Response.Redirect("~/tshome.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }


    public void filldetails(int postapplslno)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Gen.GET_FEEDBACKPOST_DOWNLOAD_CERTIFICATE_DTLS_BY_POSTAPPLSLNO(postapplslno);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["UID_NO"].ToString() != null && ds.Tables[0].Rows[0]["UID_NO"].ToString() != "")
                {
                    lbluidno.Text = ds.Tables[0].Rows[0]["UID_NO"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString() != null && ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString() != "")
                {
                    lblUnitName.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NameofthePromoter"].ToString() != null && ds.Tables[0].Rows[0]["NameofthePromoter"].ToString() != "")
                {
                    lblEntrepreneurName.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MobileNumber"].ToString() != null && ds.Tables[0].Rows[0]["MobileNumber"].ToString() != "")
                {
                    lblMobileNo.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"].ToString() != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    lblUnitAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"].ToString() != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    LblEmailId.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                }


                if (ds.Tables[0].Rows[0]["PDgivenlicensewithintimelines"].ToString() != null && ds.Tables[0].Rows[0]["PDgivenlicensewithintimelines"].ToString() != "")
                {
                    rblLicenseApproval.SelectedValue = ds.Tables[0].Rows[0]["PDgivenlicensewithintimelines"].ToString();
                }
                else { rblLicenseApproval.SelectedValue = ""; }

                //if (ds.Tables[0].Rows[0]["PDgivenlicensewithintimelinesissues"].ToString() != null && ds.Tables[0].Rows[0]["PDgivenlicensewithintimelinesissues"].ToString() != "")
                //{
                //    txtLicenseApprovalIssuesFaced.Text = ds.Tables[0].Rows[0]["PDgivenlicensewithintimelinesissues"].ToString();
                //}
                //else { txtLicenseApprovalIssuesFaced.Text = ""; }


                if (ds.Tables[0].Rows[0]["PDtrackapplnstatus"].ToString() != null && ds.Tables[0].Rows[0]["PDtrackapplnstatus"].ToString() != "")
                {
                    rblTrackstatus.SelectedValue = ds.Tables[0].Rows[0]["PDtrackapplnstatus"].ToString();
                }
                else { rblTrackstatus.SelectedValue = ""; }


                if (ds.Tables[0].Rows[0]["PDtrackapplnstatusissues"].ToString() != null && ds.Tables[0].Rows[0]["PDtrackapplnstatusissues"].ToString() != "")
                {
                    txtTrackStatusIssuesFaced.Text = ds.Tables[0].Rows[0]["PDtrackapplnstatusissues"].ToString();
                }
                else { txtTrackStatusIssuesFaced.Text = ""; }

                if (ds.Tables[0].Rows[0]["PDaskedOfflineinfodocs"].ToString() != null && ds.Tables[0].Rows[0]["PDaskedOfflineinfodocs"].ToString() != "")
                {
                    rblOfflineInfoasked.SelectedValue = ds.Tables[0].Rows[0]["PDaskedOfflineinfodocs"].ToString();
                }
                else { rblOfflineInfoasked.SelectedValue = ""; }

                if (ds.Tables[0].Rows[0]["PDaskedOfflineinfodocsissues"].ToString() != null && ds.Tables[0].Rows[0]["PDaskedOfflineinfodocsissues"].ToString() != "")
                {
                    txtOfflineInfoaskedIssuesFaced.Text = ds.Tables[0].Rows[0]["PDaskedOfflineinfodocsissues"].ToString();
                }
                else { txtOfflineInfoaskedIssuesFaced.Text = ""; }


                if (ds.Tables[0].Rows[0]["PDInspectionpremisesfeedback"].ToString() != null && ds.Tables[0].Rows[0]["PDInspectionpremisesfeedback"].ToString() != "")
                {
                    rblInspectionFeedback.SelectedValue = ds.Tables[0].Rows[0]["PDInspectionpremisesfeedback"].ToString();
                }
                else { rblInspectionFeedback.SelectedValue = ""; }

                //if (ds.Tables[0].Rows[0]["PDInspectionpremisesfeedbackissues"].ToString() != null && ds.Tables[0].Rows[0]["PDInspectionpremisesfeedbackissues"].ToString() != "")
                //{
                //    txtInspectionFeedbackIssuesfaced.Text = ds.Tables[0].Rows[0]["PDInspectionpremisesfeedbackissues"].ToString();
                //}
                //else { txtInspectionFeedbackIssuesfaced.Text = ""; }


                if (ds.Tables[0].Rows[0]["PDfinalqltyofexp"].ToString() != null && ds.Tables[0].Rows[0]["PDfinalqltyofexp"].ToString() != "")
                {
                    rblrateQltyPost.SelectedValue = ds.Tables[0].Rows[0]["PDfinalqltyofexp"].ToString();
                }
                else { rblrateQltyPost.SelectedValue = ""; }

                if (ds.Tables[0].Rows[0]["PDFfnalqltyofexpissues"].ToString() != null && ds.Tables[0].Rows[0]["PDFfnalqltyofexpissues"].ToString() != "")
                {
                    txtrateqltyPostIssuesfaced.Text = ds.Tables[0].Rows[0]["PDFfnalqltyofexpissues"].ToString();
                }
                else { txtrateqltyPostIssuesfaced.Text = ""; }

            }

            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["questionid"].ToString() != null && ds.Tables[1].Rows[0]["questionid"].ToString() != "")
                {                   
                        gvCertificate.DataSource = null;
                        gvCertificate.DataBind();

                        gvCertificate.DataSource = ds.Tables[1];
                        gvCertificate.DataBind();
                   
                }              

            }


            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                if (ds.Tables[2].Rows[0]["questionid"].ToString() != null && ds.Tables[2].Rows[0]["questionid"].ToString() != "")
                {
                    gvCertificate4.DataSource = null;
                    gvCertificate4.DataBind();

                    gvCertificate4.DataSource = ds.Tables[2];
                    gvCertificate4.DataBind();

                }

            }


        }

        catch (Exception ex)
        {
            throw ex;
        }


    }

    public void EnableDisableForm(ControlCollection ctrls, bool status)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Enabled = status;

            // if (ctrl is Button)      // commented to enable the Button Controls
            //    ((Button)ctrl).Enabled = status;

            //else if (ctrl is DropDownList)
            //    ((DropDownList)ctrl).Enabled = status;

            //else if (ctrl is CheckBox)
            //    ((CheckBox)ctrl).Enabled = status;

            //else if (ctrl is RadioButton)
            //    ((RadioButton)ctrl).Enabled = status;

            else if (ctrl is RadioButtonList)
                ((RadioButtonList)ctrl).Enabled = status;

            //else if (ctrl is CheckBoxList)
            //    ((CheckBoxList)ctrl).Enabled = status;

            EnableDisableForm(ctrl.Controls, status);
        }
    }

}