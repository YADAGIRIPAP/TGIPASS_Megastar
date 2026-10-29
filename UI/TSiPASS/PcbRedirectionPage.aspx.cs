using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_PcbRedirectionPage : System.Web.UI.Page
{
    General clsGeneral = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        string intCFEEnterpid = "";
        if (Request.QueryString.Count > 0)
        {
            string QuestioneryID = Request.QueryString[0].ToString().Trim();
            //if (Session["uid"] != null)
            //{
            //    Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + QuestioneryID);
            //}
            //else
            //{
                DataSet ds = clsGeneral.GetPcbLoginDetails(QuestioneryID,"CFE");//,Dept
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
                    Session["MobileNumber"] = dv.Table.Rows[0]["MobileNumber"].ToString();
                    Session["Email"] = dv.Table.Rows[0]["EmailE"].ToString();
                    Session["Role_Code"] = dv.Table.Rows[0]["Role_Code"].ToString();//added by lavanya
                    Session["DistrictID"] = dv.Table.Rows[0]["DistrictID"].ToString();
                    Session["User_Code"] = dv.Table.Rows[0]["User_code"].ToString();
                    Session["intDeptid"] = dv.Table.Rows[0]["intDeptid"].ToString();
                    Session["Visibleflag"] = dv.Table.Rows[0]["Visibleflag"].ToString();
                    intCFEEnterpid = dv.Table.Rows[0]["intCFEEnterpid"].ToString();
                    Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + intCFEEnterpid);
                }
                
           // }
        }
    }
}