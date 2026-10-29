using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmQurieResponseStatus_PlotAllotment : System.Web.UI.Page
{
    cls_plotallotmentadmin Gen = new cls_plotallotmentadmin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }
        if(Request.QueryString.Count>0)
        {
            string eid = Request.QueryString[0].ToString().Trim();
            if (!IsPostBack)
            {
                DataSet ds = Gen.GetQueryResponseDetail_plotallotment(eid);
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink h3 = (HyperLink)e.Row.Cells[10].Controls[0];
            h3.Target = "_blank";
            string path = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryAttachmentFilePath")).Trim();
            path = path.Replace(@"\", @"/");
            if (path != "")
            {
                h3.NavigateUrl = path.Replace(path.Substring(0, path.IndexOf(@"/Tsiicresponseattachments")), "~") + "/" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryAttachmentFileName")).Trim();
            }
            else
            {
                h3.Text = "No Document";
            }
        }
    }
  

}