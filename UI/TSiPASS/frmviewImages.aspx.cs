using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
public partial class UI_TSIPASS_frmviewImages : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DataSet dscheck = new DataSet();
            string id = "";
            id = Request.QueryString["TSiPASSOldDataNewId"].ToString().Trim();

            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@ID",SqlDbType.VarChar),
            };

            pp[0].Value = id;

            dscheck = gen.GenericFillDs("USP_GET_UNITIMAGES", pp);

            if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
            {
                trquerydtls.Visible = true;
                Trqueryresponceattachemnts.Visible = true;
                gvqueryresponse.DataSource = dscheck.Tables[0];
                gvqueryresponse.DataBind();
            }
        }
    }
}