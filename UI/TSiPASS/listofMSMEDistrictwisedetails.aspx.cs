using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UI_TSiPASS_listofMSMEDistrictwisedetails : System.Web.UI.Page
{
    Cls_MSME obj_msme = new Cls_MSME();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = "Report as on date " + DateTime.Now;

            if (Request.QueryString["DistrictID"] != null && Request.QueryString["Status"] != "")
            {
                //Request.QueryString["DistrictID"].ToString().Trim();
                //Request.QueryString["Status"].ToString().Trim();
                lblHead2.Text = "MSME Report-  " + Convert.ToString(Request.QueryString["District"])+ " - " + Convert.ToString(Request.QueryString["Status"]);
                FillDetails();
            }
            else
            {
                Response.Redirect("MSME_DistrictwiseReport.aspx");
            }

        }
    }

    void FillDetails()
    {
        try
        {
            string DistrictID = Convert.ToString(Request.QueryString["DistrictID"]);
            string Status = Convert.ToString(Request.QueryString["Status"]);
            //string DistrictID = "5";
            //string Status = "Noofunits";
            DataSet ds = obj_msme.GetpopupMSMEApplicationsbydistrictidstatus(DistrictID, Status);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillDetails();
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                string MSMENo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "msmeNo")).Trim();
                //HyperLink hyp_view = (HyperLink)e.Row.FindControl("hyp_view");
                // string msmeNo = DataBinder.Eval(e.Row.DataItem, "msmeNo").ToString();
                // hyp_view.NavigateUrl = "frmMSMEPrint.aspx?MSMENo=" + MSMENo;
               // hyp_view.NavigateUrl = "javascript:return Popup('" + MSMENo + "')";

                LinkButton hyp_view = (LinkButton)e.Row.FindControl("hyp_view");
                hyp_view.OnClientClick = "javascript:return Popup('" + MSMENo + "')";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}