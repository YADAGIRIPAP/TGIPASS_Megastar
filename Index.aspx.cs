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

public partial class index : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("~/tshome.aspx");
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


            
            if (Request.Browser.Browser.ToString().Trim().ToLower() == "internetexplorer")
            {
               // lblmsg.Text = "Please use Google Chrome";
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

       


    }
    protected void BtnSave4_Click(object sender, EventArgs e)
    {

        Response.Redirect("Index.aspx");
    }
    protected void btnSignIn_Click(object sender, ImageClickEventArgs e)
    {
        
        String UserID = "", Password = "", Dept = "";

        UserID = txtUserId.Text;
        Password = txtPwd.Text;
        Dept = "%";

        General clsGeneral = new General();
        DataSet ds = clsGeneral.ValidateLogin(UserID, Password);//,Dept
        DataView dv = ds.Tables[0].DefaultView;
        DataSet dsnew = new DataSet();

        dsnew = clsGeneral.UpdateCFOUID();

        if (dv.Table.Rows.Count > 0)
        {
            Session["uid"] = dv.Table.Rows[0]["intUserid"].ToString();
            Session["username"] = dv.Table.Rows[0]["User_name"].ToString();
            Session["user_id"] = dv.Table.Rows[0]["User_id"].ToString();
            Session["password"] = dv.Table.Rows[0]["password"].ToString();
            Session["userlevel"] = dv.Table.Rows[0]["User_level"].ToString();
            Session["user_type"] = dv.Table.Rows[0]["User_type"].ToString();
            Session["Type"] = dv.Table.Rows[0]["Fromname"].ToString();
            Session["MobileNumber"] = dv.Table.Rows[0]["MobileNumber"].ToString();
            Session["Email"] = dv.Table.Rows[0]["EmailE"].ToString();

            Session["DistrictID"] = dv.Table.Rows[0]["DistrictID"].ToString();
            Session["User_Code"] = dv.Table.Rows[0]["User_code"].ToString();
            if (Session["userlevel"].ToString().Trim() == "20" || Session["userlevel"].ToString().Trim() == "24")
            {
                //Response.Redirect("UI/TSiPASS/Dashboard.aspx");
                Response.Redirect("UI/TSiPASS/Home.aspx");
            } else 
            if (Session["userlevel"].ToString().Trim() == "13")
            {
                //Response.Redirect("UI/TSiPASS/Dashboard.aspx");
                Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
            }
            else if (Session["userlevel"].ToString().Trim() == "25")
            {
                Response.Redirect("UI/TSiPASS/Home.aspx");
            }
            else if (Session["userlevel"].ToString().Trim() == "12")
            {
                Response.Redirect("UI/TSiPASS/frmApprovelDocument.aspx");
            }
            else if (Session["userlevel"].ToString().Trim() == "10")
            {

                if (Session["uid"].ToString().Trim() == "1030")
                {

                    Response.Redirect("UI/TSiPASS/HomeIndusDashboard.aspx");

                }
               
                else
                {
                    if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150")
                    {
                        Response.Redirect("UI/TSiPASS/frmIPOIncentiveDashboard.aspx");
                    }
                    else
                    {
                        //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                        Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");
                    }


                    //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                    //  Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                }

                //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                //Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");
                
            }
            else
            {
                if (Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "kcsbabu" || Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "3378")
                {
                    Response.Redirect("UI/TSiPASS/HomeCommDashboard.aspx");
                }
                else if (Session["uid"].ToString().Trim() == "1622")
                {

                    Response.Redirect("UI/TSiPASS/Home.aspx");

                }
                else
                {
                    Response.Redirect("UI/TSiPASS/ReportsDashboard.aspx");
                }

            }


        }
        else
        {
            lblmsg.Text = "Invalid UserID/Password";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "Invalid UserID/Password", true);
            return;
        }
    }
}
