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
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
public partial class UI_TSiPASS_IncentiveWisePendencylist : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    General gen = new General();
    int Slnorow = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Button2_Click(sender, e);
        }
    }
    // SC CAtegory
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;

            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;
            string lblSubIncType = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblSubIncType")).Text;

            Response.Redirect("ReleasePendingViewALL.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncId=" + lblSubIncType +
           "&APPMODE=" + ddlApplicationMode.SelectedValue + "&APPSTATUS=" + ddlworkingstatus.SelectedValue);
        }
        catch (Exception ex)
        {

        }
    }

    protected void grdDetailsPavallavaddiSC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblince = (Label)e.Row.FindControl("lblince");
            string NAME = e.Row.Cells[0].Text;
            Label lbl = (Label)e.Row.FindControl("Label1");
            Label lbl2 = (Label)e.Row.FindControl("Label2");
            e.Row.Cells[0].Text = (Slnorow + 1).ToString();
            Slnorow = (Slnorow + 1);
            if (lblince.Text.Trim() == "General" || lblince.Text.Trim() == "Head of Account- Incenives for Industrial Promotion" ||
                lblince.Text.Trim() == "Head of Account-Power Cost Reimbursement" || lblince.Text.Trim() == "Head of Account-Pavala Vaddi" ||
                    lblince.Text.Trim() == "PHC" || lblince.Text.Trim() == "SCP" || lblince.Text.Trim() == "TSP"

                )// || e.Row.Cells[1].Text == "CFE + CFO TOTAL" || e.Row.Cells[1].Text == "GRAND TOTAL" || e.Row.Cells[1].Text == "CFE - Total")
            {
                Slnorow = 0;
                e.Row.Cells[0].Text = lblince.Text;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                //e.Row.Cells[6].Visible = false;
                //e.Row.Cells[7].Visible = false;
                //e.Row.Cells[8].Visible = false;
                e.Row.Cells[0].ColumnSpan = 6;
                e.Row.Cells[0].Attributes.CssStyle["text-align"] = "center";
                e.Row.Font.Bold = true;
                //e.Row.BackColor = System.Drawing.Color.Yellow;
            }
            if (lblince.Text.Trim() == "Head of Account-Power Cost Reimbursement")
            {
                e.Row.Cells[0].RowSpan = 1;
                //e.Row.Cells[0].Text = "2";
            }
            if (lblince.Text.Contains("TOTAL"))
            {
                e.Row.Font.Bold = true;
                //e.Row.ForeColor = System.Drawing.Color.Red;
                e.Row.Attributes.CssStyle.Value = "color: RED";
                e.Row.BorderColor = System.Drawing.Color.Black;
                e.Row.Font.Size = 12;
                e.Row.Cells[0].Text = lblince.Text;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[0].ColumnSpan = 2;
            }
            if (lblince.Text.Contains("Sub-Total"))
            {
                e.Row.Font.Bold = true;
                //e.Row.ForeColor = System.Drawing.Color.Red;
                e.Row.BorderColor = System.Drawing.Color.Black;
            }
            if (lblince.Text.Trim() == "General" || lblince.Text.Trim() == "PHC" || lblince.Text.Trim() == "SCP" || lblince.Text.Trim() == "TSP")
            {
                e.Row.Font.Bold = true;
                e.Row.Font.Size = 15;
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (e.Row.RowIndex >= 0)
        //    {
        //        int colSpanValue = 2;
        //        for (int i = 0; i < e.Row.Cells.Count; i++)
        //        {
        //            if (i + 1 < e.Row.Cells.Count)
        //            {
        //                if (e.Row.Cells[i].Text == "GENERAL")
        //                {
        //                    e.Row.Cells[i].BackColor = System.Drawing.Color.Beige;
        //                    e.Row.Cells[i].ColumnSpan = colSpanValue;
        //                    e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
        //                    e.Row.Cells[i + 1].Visible = false;
        //                    colSpanValue++;
        //                }
        //            }
        //        }
        //    }

        //    Label enterid = (e.Row.FindControl("lblince") as Label);
        //    Button Button1 = (e.Row.FindControl("Button1") as Button);
        //    if (enterid.Text == "")
        //    {
        //        Button1.Visible = false;
        //    }
        //}
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string Distid = "";
        if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
        {
            Distid = Session["DistrictID"].ToString().Trim();
        }
        ds = getincentiveslclist(Distid, ddlApplicationMode.SelectedValue, ddlworkingstatus.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        ddlApplicationMode.SelectedValue = "0";
        ddlworkingstatus.SelectedValue = "0";
        grdDetailsPavallavaddiSC.DataSource = null;
        grdDetailsPavallavaddiSC.DataBind();
    }

    public DataSet getincentiveslclist(string slcno, string APPMODE, string APPSTATUS)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE", con.GetConnection);
            // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_ABSTRACT", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_ABSTRACT_NEW_ALL_BUDGETHEADS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@APPMODE", SqlDbType.VarChar).Value = APPMODE;
            da.SelectCommand.Parameters.Add("@APPSTATUS", SqlDbType.VarChar).Value = APPSTATUS;
            da.SelectCommand.Parameters.Add("@slcno", SqlDbType.VarChar).Value = slcno;
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
}