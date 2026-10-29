using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AwardsAttachments : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString[0].ToString();
            DataSet ds = new DataSet();
            ds = GetAppealApplications(id);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvCertificate.DataSource = ds.Tables[0];
                gvCertificate.DataBind();
                TRQ3.Visible = true;
                TRQ3data.Visible = true;
            }
            else
            {
                TRQ3.Visible = false;
                TRQ3data.Visible = false;
            }
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[1];
                GridView1.DataBind();
                TRQ4.Visible = true;
                TRQ4DATA.Visible = true;
            }
            else
            {
                TRQ4.Visible = false;
                TRQ4DATA.Visible = false;
            }
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                GridView2.DataSource = ds.Tables[2];
                GridView2.DataBind();
                TRQ5.Visible = true;
                TRQ5DATA.Visible = true;
            }
            else
            {
                TRQ5.Visible = false;
                TRQ5DATA.Visible = false;
            }
            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                GridView3.DataSource = ds.Tables[3];
                GridView3.DataBind();
                TRQ6.Visible = true;
                TRQ6DATA.Visible = true;
            }
            else
            {
                TRQ6.Visible = false;
                TRQ6DATA.Visible = false;
            }
        }
    }

    public DataSet GetAppealApplications(string Appstype)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@APPTYPE",SqlDbType.VarChar),
           };
        pp[0].Value = Appstype;
        Dsnew = Gen.GenericFillDs("USP_GET_Awards2018ATTACHMENTS", pp);
        return Dsnew;
    }
}