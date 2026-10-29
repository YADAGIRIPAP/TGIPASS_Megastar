using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_TSipassfeedbackPostApplnDraft : System.Web.UI.Page
{
    General Gen = new General();
   // TsipassFeedbackFormVOs objvo = new TsipassFeedbackFormVOs();

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
                        postapplslno =Convert.ToInt32(Request.QueryString["postapplslno"].ToString()) ;
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
            ds = Gen.GET_FEEDBACKPOSTAPPLN_DTLS_BY_POSTAPPLSLNO(postapplslno);
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


                if (ds.Tables[0].Rows[0]["PAoverallqltyrate"].ToString() != null && ds.Tables[0].Rows[0]["PAoverallqltyrate"].ToString() != "")
                {
                    rblOverallquality.SelectedValue = ds.Tables[0].Rows[0]["PAoverallqltyrate"].ToString();
                }
                else  {  rblOverallquality.SelectedValue = "";    }

                if (ds.Tables[0].Rows[0]["PAoverallqltyrateissues"].ToString() != null && ds.Tables[0].Rows[0]["PAoverallqltyrateissues"].ToString() != "")
                {
                    txtOverallQltyIssuesFaced.Text = ds.Tables[0].Rows[0]["PAoverallqltyrateissues"].ToString();
                }
                else { txtOverallQltyIssuesFaced.Text = ""; }


                if (ds.Tables[0].Rows[0]["PAinforateeaseoffinding"].ToString() != null && ds.Tables[0].Rows[0]["PAinforateeaseoffinding"].ToString() != "")
                {
                    rblEasefindInfo.SelectedValue = ds.Tables[0].Rows[0]["PAinforateeaseoffinding"].ToString();
                }
                else { rblEasefindInfo.SelectedValue = ""; }

                if (ds.Tables[0].Rows[0]["PAinforateqltycomplt"].ToString() != null && ds.Tables[0].Rows[0]["PAinforateqltycomplt"].ToString() != "")
                {
                    rblQltyCompInfo.SelectedValue = ds.Tables[0].Rows[0]["PAinforateqltycomplt"].ToString();
                }
                else { rblQltyCompInfo.SelectedValue = ""; }


                if (ds.Tables[0].Rows[0]["PAinforateissues"].ToString() != null && ds.Tables[0].Rows[0]["PAinforateissues"].ToString() != "")
                {
                    txtRateInformationIssuesFaced.Text = ds.Tables[0].Rows[0]["PAinforateissues"].ToString();
                }
                else { txtRateInformationIssuesFaced.Text = ""; }

                if (ds.Tables[0].Rows[0]["PAisupportsufficient"].ToString() != null && ds.Tables[0].Rows[0]["PAisupportsufficient"].ToString() != "")
                {
                    rblIsclarificationsSufficient.SelectedValue = ds.Tables[0].Rows[0]["PAisupportsufficient"].ToString();
                }
                else { rblIsclarificationsSufficient.SelectedValue = ""; }

                if (ds.Tables[0].Rows[0]["PAissupportsufficientissues"].ToString() != null && ds.Tables[0].Rows[0]["PAissupportsufficientissues"].ToString() != "")
                {
                    txtIsclarificationsSufficientissues.Text = ds.Tables[0].Rows[0]["PAissupportsufficientissues"].ToString();
                }
                else { txtIsclarificationsSufficientissues.Text = ""; }


                if (ds.Tables[0].Rows[0]["PAawaretimeines"].ToString() != null && ds.Tables[0].Rows[0]["PAawaretimeines"].ToString() != "")
                {
                    rblTimeLines.SelectedValue = ds.Tables[0].Rows[0]["PAawaretimeines"].ToString();
                }
                else { rblTimeLines.SelectedValue = ""; }

                if (ds.Tables[0].Rows[0]["PAawaretimeinesissues"].ToString() != null && ds.Tables[0].Rows[0]["PAawaretimeinesissues"].ToString() != "")
                {
                    txtTimeLinesIssuesFaced.Text = ds.Tables[0].Rows[0]["PAawaretimeinesissues"].ToString();
                }
                else { txtTimeLinesIssuesFaced.Text = ""; }


                if (ds.Tables[0].Rows[0]["PAabletodoapplnonline"].ToString() != null && ds.Tables[0].Rows[0]["PAabletodoapplnonline"].ToString() != "")
                {
                    rblApplnpymnt.SelectedValue = ds.Tables[0].Rows[0]["PAabletodoapplnonline"].ToString();
                }
                else { rblApplnpymnt.SelectedValue = ""; }

                if (ds.Tables[0].Rows[0]["PAabletodoapplnonlineissues"].ToString() != null && ds.Tables[0].Rows[0]["PAabletodoapplnonlineissues"].ToString() != "")
                {
                    txtApplnpymntIssuesfcaed.Text = ds.Tables[0].Rows[0]["PAabletodoapplnonlineissues"].ToString();
                }
                else { txtApplnpymntIssuesfcaed.Text = ""; }


                if (ds.Tables[0].Rows[0]["PAawaretsipassact"].ToString() != null && ds.Tables[0].Rows[0]["PAawaretsipassact"].ToString() != "")
                {
                    rblAwareTsipassAct.SelectedValue = ds.Tables[0].Rows[0]["PAawaretsipassact"].ToString();
                }
                else { rblAwareTsipassAct.SelectedValue = ""; }

                if (ds.Tables[0].Rows[0]["PAawaretsipassactissues"].ToString() != null && ds.Tables[0].Rows[0]["PAawaretsipassactissues"].ToString() != "")
                {
                    txtTsipassActIssuesFaced.Text = ds.Tables[0].Rows[0]["PAawaretsipassactissues"].ToString();
                }
                else { txtTsipassActIssuesFaced.Text = ""; }


                if (ds.Tables[0].Rows[0]["PAawaresinglewindow"].ToString() != null && ds.Tables[0].Rows[0]["PAawaresinglewindow"].ToString() != "")
                {
                    rblAwareSingleWindow.SelectedValue = ds.Tables[0].Rows[0]["PAawaresinglewindow"].ToString();
                }
                else { rblAwareSingleWindow.SelectedValue = ""; }

                if (ds.Tables[0].Rows[0]["PAawaresinglewindowissues"].ToString() != null && ds.Tables[0].Rows[0]["PAawaresinglewindowissues"].ToString() != "")
                {
                    txtrblAwareSingleWindowIssuesFaced.Text = ds.Tables[0].Rows[0]["PAawaresinglewindowissues"].ToString();
                }
                else { txtrblAwareSingleWindowIssuesFaced.Text = ""; }    

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