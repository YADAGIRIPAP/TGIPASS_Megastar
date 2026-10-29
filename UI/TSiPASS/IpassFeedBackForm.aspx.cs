using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class UI_TSiPASS_IpassFeedBackForm : System.Web.UI.Page
{
    General Gen = new General();
    TsipassFeedbackFormVONews objvo = new TsipassFeedbackFormVONews();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["uid"] != null)
                {
                    if (Request.QueryString["Rfrom"] != null && Request.QueryString["Rfrom"] != "")
                    {
                        string Rfrom = Request.QueryString["Rfrom"].ToString();

                        if (Rfrom.Trim() == "2")
                        {
                            tr6.Visible = false;
                            tr7.Visible = false;
                            tr8.Visible = false;
                            tr9.Visible = false;
                            tr10.Visible = false;
                            trinspection.Visible = false;
                        }
                        else if (Rfrom.Trim() == "3")
                        {
                            tr1.Visible = false;
                            tr2.Visible = false;
                            tr3.Visible = false;
                            tr4.Visible = false;
                            tr5.Visible = false;

                            td6.InnerHtml = "1";
                            td7.InnerHtml = "2";
                            td8.InnerHtml = "3";
                            td9.InnerHtml = "4";
                            td10.InnerHtml = "5";
                        }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int valid = 0;
        if (Request.QueryString["Rfrom"] != null && Request.QueryString["Rfrom"] != "")
        {
            string Rfrom = Request.QueryString["Rfrom"].ToString();
            if (Rfrom.Trim() == "1")
            {
                objvo.Feedbackfrom = "ALL";
            }
            else if (Rfrom.Trim() == "2")
            {
                objvo.Feedbackfrom = "CFE";
            }
            else if (Rfrom.Trim() == "3")
            {
                objvo.Feedbackfrom = "CFO";
            }
        }
        else
        {
            objvo.Feedbackfrom = "ALL";
        }
        if (objvo.Feedbackfrom == "ALL")
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
        else if (objvo.Feedbackfrom == "CFE")
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
        }
        else if (objvo.Feedbackfrom == "CFO")
        {
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
        objvo.Created_by = Session["uid"].ToString();
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
        objvo.Ip = getclientIP();
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
        Response.Redirect("IpassFeedBackForm.aspx");
    }
    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }
}