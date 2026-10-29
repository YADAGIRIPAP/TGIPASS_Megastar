using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class AmendamentUserCommentsFinal : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString[0].ToString().Contains("http://120.138.9.236") || Request.QueryString[0].ToString().Contains("https://ipass.telangana.gov.in"))
                    {
                        IframePanel.Attributes["src"] = Request.QueryString[0];
                    }
                    else
                    {
                        IframePanel.Attributes["src"] = "#";
                    }
                    DataSet ds = new DataSet();
                    ds = Gen.GetUserCommentsofAmmendmentsid(Convert.ToInt32(Request.QueryString[2].ToString()));
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        gvComments.DataSource = ds.Tables[0];
                        gvComments.DataBind();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                    {
                        trlegal.Visible = true;
                        gridlegal.DataSource = ds.Tables[1];
                        gridlegal.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}