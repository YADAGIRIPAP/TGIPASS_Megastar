using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Threading;
using System.ComponentModel;
using System.Text;

public partial class Default3 : System.Web.UI.Page
{
   

    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session.Count != 0)
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();

                if (!Page.IsPostBack)
                    Session.Abandon();
            }

            txtUserId.Focus();



            if (Request.Browser.Browser.ToString().Trim().ToLower() == "firefox")
            {
                //lblmsg.Text = "Please use Internet Explorer or Google Chrome";
                btnSignIn.Enabled = false;
            }
        }
       

    }



    protected void BtnSave_Click(object sender, EventArgs e)
    {

        //if (RadioButtonList1.SelectedValue == "" || RadioButtonList1.SelectedValue == null)
        //{
        //    lblmsg.Text = "Please Select Department or Enterprenuer";
        //    return;
        //}

        String UserID = "", Password = "",Dept="";

        UserID = txtUserId.Text;
        Password = txtPwd.Text;
        Dept = RadioButtonList1.SelectedValue.ToString();

        General clsGeneral = new General();
        DataSet ds = clsGeneral.ValidateLogin(UserID, Password);//,Dept
        DataView dv = ds.Tables[0].DefaultView;

        if (dv.Table.Rows.Count > 0)
        {
            Session["uid"] = dv.Table.Rows[0]["intUserid"].ToString();
            Session["username"] = dv.Table.Rows[0]["User_name"].ToString();
            Session["user_id"] = dv.Table.Rows[0]["User_id"].ToString();
            Session["password"] = dv.Table.Rows[0]["password"].ToString();
            Session["userlevel"] = dv.Table.Rows[0]["User_level"].ToString();
            Session["user_type"] = dv.Table.Rows[0]["User_type"].ToString();
            Session["Type"] = dv.Table.Rows[0]["Fromname"].ToString();

            Session["DistrictID"] = dv.Table.Rows[0]["DistrictID"].ToString();
            Session["User_Code"] = dv.Table.Rows[0]["User_code"].ToString();
            if (Session["userlevel"].ToString().Trim() == "13")
            {
                Response.Redirect("UI/TSiPASS/Dashboard.aspx");
            }
            else if (Session["userlevel"].ToString().Trim() == "10")
            {
                Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
            }
            else
            {
                Response.Redirect("UI/TSiPASS/frmR1ReportKMR.aspx");
            }


        }
        else
        {
            lblmsg.Text = "Invalid UserID/Password";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "Invalid UserID/Password", true);
            return;
        }

            
    }
    protected void BtnSave4_Click(object sender, EventArgs e)
    {

        Response.Redirect("Index.aspx");
    }
}
