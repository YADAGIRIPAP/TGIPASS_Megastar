using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class UI_TSiPASS_Departmentdrilldown_DrillingRigs : System.Web.UI.Page
{
    Cls_DrillingRigs obj_dashboard = new Cls_DrillingRigs();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Deptid = Request.QueryString["Deptid"].ToString();
            string Status = Request.QueryString["Status"].ToString();

            FillGridDetails(Deptid, Status);
        }
    }


    public void FillGridDetails(string Deptid, string status)
    {
        try
        {
            
            if (status == "A")
            {
                lblMsg.Text = "Total Applications";
           
            }
            else if (status == "B")
            {
                lblMsg.Text = "Total Query raised for Applications";
            }
            else if (status == "C")
            {
                lblMsg.Text = "	No. of Applications Awaiting for Response";
            }
            else if (status == "D")
            {
                lblMsg.Text = "Total Applications Responded";
            }
            if (status == "E")
            {
                lblMsg.Text = "Approved Applications";
            }
            if (status == "F")
            {
                lblMsg.Text = "Rejected Applications";
            }
            else if (status == "G")
            {
                lblMsg.Text = "Approved-Within";
            }
            else if (status == "H")
            {
                lblMsg.Text = "Approved- Beyond";
            }

            DataSet ds = obj_dashboard.GetMonthwiseStatusrptDrill_DrillingRigs(Deptid, status);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Controls[2].Visible = false;// column 2
            e.Row.Controls[e.Row.Controls.Count - 1].Visible = false;
        }
    }
}