using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UI_TSiPASS_frmqueryresponseview_GroundwaterUser : System.Web.UI.Page
{
    Cls_OSGroundWater obj_dashboard = new Cls_OSGroundWater();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
             Response.Redirect("../../tshome.aspx");
        }
        string eid = Request.QueryString[0].ToString().Trim();
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString[0])))
                {
                    DataSet ds = obj_dashboard.GetquerresponsedetailsfordeptbyID_Groundwater(Convert.ToString(Request.QueryString[0]));
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            grdDetails.DataSource = ds.Tables[0];
                            grdDetails.DataBind();
                        }
                    }

                }
            }
        }
    }
}