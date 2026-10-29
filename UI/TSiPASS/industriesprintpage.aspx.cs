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
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;


public partial class UI_TSiPASS_industriesprintpage : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds= GetGMDelayApplications(Request.QueryString[0].ToString().Trim());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lbl_memno.Text = ds.Tables[0].Rows[0]["applicationno"].ToString();
            lbl_menodate.Text = ds.Tables[0].Rows[0]["MemoDate"].ToString();
            lbl_industryname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
            lbl_incentives.Text = ds.Tables[0].Rows[0]["IncentiveName"].ToString();
            lbl_refapplicationdate.Text = ds.Tables[0].Rows[0]["applicationno"].ToString();// +"Dated: " + ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
            lbl_applicationindustries.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
            lbl_incentiveapplicationtype.Text = ds.Tables[0].Rows[0]["IncentiveName"].ToString();
            lbl_District.Text = "DIC-" + ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            lbldistrictname.Text = "DIC-" + ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            lbl_todistrictname.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            lbl_coIaddress.Text = ds.Tables[0].Rows[0]["GMNamerecom"].ToString();
        }
    }

    public DataSet GetGMDelayApplications(string incentiveid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@IncentveID",SqlDbType.VarChar)
           };
        pp[0].Value = incentiveid;
        //pp[1].Value = todate;
        //pp[2].Value = districtid;
        //pp[3].Value = designation;


        Dsnew = Gen.GenericFillDs("USP_GET_GMSHOWCAUSE_NOTICE", pp);
        return Dsnew;
    }
}