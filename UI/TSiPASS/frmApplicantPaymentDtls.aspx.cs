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

public partial class UI_TSiPASS_frmApplicantPaymentDtls : System.Web.UI.Page
{
    General Gen = new General();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                    Session["UIDNO"] = dscheck.Tables[2].Rows[0]["UID_No"].ToString().Trim();
                    Session["intCFEEnterpid"] = dscheck.Tables[3].Rows[0]["intCFEEnterpid"].ToString().Trim();
                }
                else
                {
                    Session["Applid"] = "0";
                }

                DataSet dspay = new DataSet();
                // dspay = Gen.GetEnterPreniourPayDetailsNew(Session["Applid"].ToString().Trim());
                dspay = GetAppealApplications(Session["Applid"].ToString().Trim());
                if (dspay != null && dspay.Tables.Count > 1 && dspay.Tables[1].Rows.Count > 0)
                {
                    grdDetails.DataSource = dspay.Tables[1];
                    grdDetails.DataBind();

                    foreach (GridViewRow row in grdDetails.Rows)
                    {
                        //foreach (TableCell cell in row.Cells)
                        //{
                        row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                        row.Cells[3].Attributes.CssStyle["Width"] = "100px";
                        //}
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    public DataSet GetAppealApplications(string intQuessionaireid)
    {
        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@intQuessionaireid",SqlDbType.VarChar),
           };
            pp[0].Value = intQuessionaireid;
            Dsnew = Gen.GenericFillDs("GetEnterPreniourPayDetailsPaidDetNew", pp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        return Dsnew;
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if ((e.Row.RowType == DataControlRowType.DataRow))
            {
                decimal TotalFee1 = Convert.ToDecimal(e.Row.Cells[3].Text);
                TotalFee = TotalFee + TotalFee1;
            }
            if ((e.Row.RowType == DataControlRowType.Footer))
            {
                e.Row.Cells[2].Text = "Total Fee";
                e.Row.Cells[3].Text = Convert.ToDecimal(TotalFee.ToString()).ToString("#,##0");
                e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}