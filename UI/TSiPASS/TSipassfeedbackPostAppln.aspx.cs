using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_TSipassfeedbackPostAppln : System.Web.UI.Page
{
    General Gen = new General();
    TsipassFeedbackFormVOs objvo = new TsipassFeedbackFormVOs();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["uid"] != null)
                {
                    

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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AssignControlstoVOs();
        string output = Gen.InsertTsipassFeedbackPostAppln(objvo);
        if (output == "Y")
        {
            string message = "alert('Thank you for taking time to participate in our survey. We truly value the information you have provided.')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSiPASS/TSipassfeedbackPostAppln.aspx");
    }

    public void AssignControlstoVOs()
    {
        //Post Application
        if (rblOverallquality.SelectedItem.Selected == true)
            objvo.PAoverallqltyrate = Convert.ToInt16(rblOverallquality.SelectedValue);
        objvo.PAoverallqltyrateissues = txtOverallQltyIssuesFaced.Text.Trim();

        if (rblEasefindInfo.SelectedItem.Selected == true)
            objvo.PAinforateeaseoffinding = Convert.ToInt16(rblEasefindInfo.SelectedValue);
        if (rblQltyCompInfo.SelectedItem.Selected == true)
            objvo.PAinforateqltycomplt = Convert.ToInt16(rblQltyCompInfo.SelectedValue);
        objvo.PAinforateissues = txtRateInformationIssuesFaced.Text.Trim();

        if (rblIsclarificationsSufficient.SelectedItem.Selected == true)
            objvo.PAisupportsufficient = Convert.ToInt16(rblIsclarificationsSufficient.SelectedValue);
        objvo.PAissupportsufficientissues = txtIsclarificationsSufficientissues.Text.Trim();

        if (rblTimeLines.SelectedItem.Selected == true)
            objvo.PAawaretimeines = rblTimeLines.SelectedValue.ToString();
        objvo.PAawaretimeinesissues = txtTimeLinesIssuesFaced.Text.Trim();

        if (rblApplnpymnt.SelectedItem.Selected == true)
            objvo.PAabletodoapplnonline = rblApplnpymnt.SelectedValue.ToString();
        objvo.PAabletodoapplnonlineissues = txtApplnpymntIssuesfcaed.Text.Trim();

        if (rblAwareTsipassAct.SelectedItem.Selected == true)
            objvo.PAawaretsipassact = rblAwareTsipassAct.SelectedValue.ToString();
        objvo.PAawaretsipassactisses = txtTsipassActIssuesFaced.Text.Trim();

        if (rblAwareSingleWindow.SelectedItem.Selected == true)
            objvo.PAawaresinglewindow = rblAwareSingleWindow.SelectedValue.ToString();
        objvo.PAawaresinglewindowissues = txtrblAwareSingleWindowIssuesFaced.Text.Trim();

        objvo.createdby = Convert.ToInt16(Session["uid"].ToString());
    }

  
}