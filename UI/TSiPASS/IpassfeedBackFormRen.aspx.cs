using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_IpassfeedBackFormRen : System.Web.UI.Page
{
    General Gen = new General();
    TsipassFeedbackFormVONews objvo = new TsipassFeedbackFormVONews();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int valid = 0;
        if (Request.QueryString["UserId"] != null && Request.QueryString["UserId"].ToString() != "")
        {
            objvo.Feedbackfrom = "CFEREN";
        }
        if (objvo.Feedbackfrom == "CFEREN")
        {
            if (rdb1.SelectedValue == "")
            {
                valid = 1;
            }
            if (rdb2.SelectedValue == "")
            {
                valid = 1;
            }
            if (rdb3.SelectedValue == "")
            {
                valid = 1;
            }
            if (rdb4.SelectedValue == "")
            {
                valid = 1;
            }
            if (rdb5.SelectedValue == "")
            {
                valid = 1;
            }
            if (rdb6.SelectedValue == "")
            {
                valid = 1;
            }
            if (rdb7.SelectedValue == "")
            {
                valid = 1;
            }
            if (rdb8.SelectedValue == "")
            {
                valid = 1;
            }
            if (rdb9.SelectedValue == "")
            {
                valid = 1;
            }
            if (rdb10.SelectedValue == "")
            {
                valid = 1;
            }
        }
        if (valid == 1)
        {
            string message = "alert('Please answer all questions.')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        objvo.Created_by = Request.QueryString["UserId"].ToString();
        objvo.Que1 = rdb1.SelectedValue;
        objvo.Que2 = rdb2.SelectedValue;
        objvo.Que3 = rdb3.SelectedValue;
        objvo.Que4 = rdb4.SelectedValue;
        objvo.Que5 = rdb5.SelectedValue;
        objvo.Que6 = rdb6.SelectedValue;
        objvo.Que7 = rdb7.SelectedValue;
        objvo.Que8 = rdb8.SelectedValue;
        objvo.Que9 = rdb9.SelectedValue;
        objvo.Que10 = rdb10.SelectedValue;
        try
        {
            string output = Gen.InsertTsipassFeedbackPostApplnNew(objvo);
            if (output == "Y")
            {
                string message = "alert('Thank you for taking time to participate in our survey. We truely value the information you have provided.')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                //Response.Redirect("HomeDashboard.aspx");
            }
        }
        catch (Exception ex)
        {
            string message = "alert('" + ex.Message + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        Response.Redirect("IpassfeedBackFormRen.aspx");
    }
}