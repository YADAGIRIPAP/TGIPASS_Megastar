using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_QueryResponse : System.Web.UI.Page
{
    public static string ApplicationId { get; set; }
    General Gen = new General();
    public static DataSet GDs { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        ApplicationId = Request.QueryString["Appid"].ToString();
      
        if (!IsPostBack)
        {
            bindData(ApplicationId);
        }
    }

    public void bindData(string appId)
    {
        SqlParameter[] p = new SqlParameter[] {
           new SqlParameter("@APPID",SqlDbType.Int),
        };


        p[0].Value = ApplicationId;

        GDs = Gen.GenericFillDs("USP__PLot_applicantquerylist", p);


        gvdetailsnew.DataSource = GDs.Tables[0];
        gvdetailsnew.DataBind();
    }

    protected void lnkQueryCount_Click(object sender, EventArgs e)
    {
        var lb = (LinkButton)sender;
        var row = (GridViewRow)lb.NamingContainer;
        if (row != null)
        {
            Label lblrmid = row.FindControl("lblRMId") as Label;

            
            string appid = lblrmid.Text;


Response.Redirect("ApplicantQueryResponse.aspx?appid=" + appid + "");


        }
    }
}