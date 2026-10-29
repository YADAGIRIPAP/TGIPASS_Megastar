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
using System.Linq;
using Org.BouncyCastle.Asn1.Ocsp;

public partial class UI_TSiPASS_IncentiveWiselistALLCategory : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if(Request.QueryString.Count>0)
            {
                txtFromDate.Text = Convert.ToString(DateTime.ParseExact(Convert.ToString(Request.QueryString["Fromdate"]), "MM-dd-yyyy", null).ToString("dd-MM-yyyy"));  //Convert.ToString( Request.QueryString["Fromdate"]);
                txtTodate.Text = Convert.ToString(DateTime.ParseExact(Convert.ToString(Request.QueryString["Todate"]), "MM-dd-yyyy", null).ToString("dd-MM-yyyy"));  //Convert.ToString(Request.QueryString["Todate"]);
                ddlEnterPriseType.SelectedValue= Convert.ToString(Request.QueryString["Category"]);

            }
            else
            {
                txtFromDate.Text = "01-01-2015";
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
            }
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + DateTime.Now;
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
            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            Response.Redirect("ReleasePendingViewALLCategory.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncId=" + lblSubIncType +
           "&Category=" + ddlEnterPriseType.SelectedValue + "&Fromdate=" + FromdateforDB + "&Todate=" + TodateforDB);
        }
        catch (Exception ex)
        {

        }
    }

    protected void grdDetailsPavallavaddiSC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblince") as Label);
            Button Button1 = (e.Row.FindControl("Button1") as Button);
            if (enterid.Text == "")
            {
                Button1.Visible = false;
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string Distid = "";
        if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
        {
            Distid = Session["DistrictID"].ToString().Trim();
        }
        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        ds = getincentiveslclist(FromdateforDB, TodateforDB, ddlEnterPriseType.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //ddlApplicationMode.SelectedValue = "0";
        //ddlworkingstatus.SelectedValue = "0";
        grdDetailsPavallavaddiSC.DataSource = null;
        grdDetailsPavallavaddiSC.DataBind();
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();

    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;

            string FileName = lblHeading.Text.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename="
                + FileName + DateTime.Now.ToString("yyyyMMdd") + ".xls");

            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                // Remove button column (View)
                foreach (GridViewRow row in grdDetailsPavallavaddiSC.Rows)
                {
                    row.Cells[5].Controls.Clear(); // adjust index if needed
                }

                // Render ONLY panel
                pnlExport.RenderControl(hw);

                string headerTable = @"<table width='100%'>
            <tr><td align='center'><h4>" + lblHeading.Text + @"</h4></td></tr>
            <tr><td align='center'><h4>" + Label1.Text + @"</h4></td></tr>
        </table>";

                Response.Write(headerTable);
                Response.Output.Write(sw.ToString());

                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
        }
    }
    public DataSet getincentiveslclist(string fromdate, string todate, string EnterPriseType)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE", con.GetConnection);
            // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_ABSTRACT", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_ABSTRACT_NEW_ALL_CATEGORY", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure; 
            da.SelectCommand.Parameters.Add("@Fromdate", SqlDbType.VarChar).Value = fromdate.ToString();
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate.ToString();
            if(EnterPriseType=="0")
            {
                da.SelectCommand.Parameters.Add("@Category", SqlDbType.VarChar).Value = '%';

            }
            else
            { da.SelectCommand.Parameters.Add("@Category", SqlDbType.VarChar).Value = EnterPriseType.ToString(); }
                

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
    protected void ddlEnterPriseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button2_Click(sender, e);

    }
}