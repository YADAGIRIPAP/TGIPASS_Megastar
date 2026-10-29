using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSIPASS_PcbRedirectionPageCfo : System.Web.UI.Page
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
            //    Response.Redirect("frmCAFLINEOFMANUFACTURE.aspx?intApplicationId=" + QuestioneryID);
            //}
            //else
            //{
            DataSet ds = GetPcbLoginDetails(QuestioneryID, "CFO");//,Dept
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
                Session["Role_Code"] = dv.Table.Rows[0]["Role_Code"].ToString();          //added by lavanya
                Session["DistrictID"] = dv.Table.Rows[0]["DistrictID"].ToString();
                Session["User_Code"] = dv.Table.Rows[0]["User_code"].ToString();
                Session["intDeptid"] = dv.Table.Rows[0]["intDeptid"].ToString();
                Session["Visibleflag"] = dv.Table.Rows[0]["Visibleflag"].ToString();
                intCFEEnterpid = dv.Table.Rows[0]["intCFOEnterpid"].ToString();
                Response.Redirect("frmCAFLINEOFMANUFACTURE.aspx?intApplicationId=" + intCFEEnterpid);
            }
            //}
        }
    }
    public DataSet GetPcbLoginDetails(string userid, string ApplicatonType)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@userid",SqlDbType.VarChar),
               new SqlParameter("@ApplicatonType",SqlDbType.VarChar)
               
           };
        pp[0].Value = userid;
        pp[1].Value = ApplicatonType;
        Dsnew = clsGeneral.GenericFillDs("[sp_ValidUser_PCB_CFO]", pp);
        return Dsnew;
    }
}