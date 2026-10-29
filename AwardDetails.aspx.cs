using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AwardDetails : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = GetAppealApplications(ddlEnterPriseType.SelectedValue);
            grdDetails.DataSource = ds;
            grdDetails.DataBind();
        }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = GetAppealApplications(ddlEnterPriseType.SelectedValue);
        grdDetails.DataSource = ds;
        grdDetails.DataBind();
    }

    public DataSet GetAppealApplications(string Appstype)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@APPTYPE",SqlDbType.VarChar),
           };
        pp[0].Value = Appstype;
        Dsnew = Gen.GenericFillDs("USP_GET_Awards2018Data", pp);
        return Dsnew;
    }
}