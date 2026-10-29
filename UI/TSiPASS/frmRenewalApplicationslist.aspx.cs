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
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
//using TSIPassBE;
//using TSIPassBL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;

public partial class UI_TSiPASS_frmRenewalApplicationslist : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string constring = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet dsnew = new DataSet();
        dsnew = BindReceipt(Session["uid"].ToString());
        if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label enterid = (e.Row.FindControl("lblquestionID") as Label);
                //Label lblanchortaglinkPendingQueriesAtLevel = (e.Row.FindControl("anchortaglinkPendingQueriesAtLevel") as Label);
                //Label lblanchortaglink = (e.Row.FindControl("anchortaglink") as Label);

                (e.Row.FindControl("anchortaglinkAcknowledgement") as HyperLink).NavigateUrl = "AcknowledgmentEntrPrintREN.aspx?EntrpId=" + enterid.Text.Trim();
                (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "RenewalPrint.aspx?EntrpId=" + enterid.Text.Trim();
                //(e.Row.FindControl("anchortaglinkPendingQueriesAtLevel") as HyperLink).NavigateUrl = "AcknowledgmentEntrPrintREN.aspx?EntrpId=" + enterid.Text.Trim();
            }
        }
        catch (Exception ex)
        {

        }
    }

    private DataSet BindReceipt(string TranRefNo)
    {
        try
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("USP_GET_APPLICANT_RENEWALS_HISTORY", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@UserID", TranRefNo);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da1.Fill(ds);
            conn.Close();
            return ds;

        }
        catch (Exception ex)
        {

        }
        return null;
    }
}