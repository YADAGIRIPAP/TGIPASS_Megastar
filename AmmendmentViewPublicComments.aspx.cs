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

public partial class AmmendmentViewPublicComments : System.Web.UI.Page
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
                    //IframePanel.Attributes["src"] = Request.QueryString[0];

                    DataSet ds = new DataSet();
                    ds = Gen.GetUserCommentsofAmmendmentsid(Convert.ToInt32(Request.QueryString[0].ToString()));
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        gvComments.DataSource = ds.Tables[0];
                        gvComments.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}