using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class UI_TSiPASS_Departmentdrilldown_groundwater : System.Web.UI.Page
{
    Cls_OSGroundWater obj_dashboard = new Cls_OSGroundWater();

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
                lblMsg.Text = "Approved Applications";
            }
            else if (status == "B")
            {
                lblMsg.Text = "Rejected Applications";
            }
            else if (status == "C")
            {
                lblMsg.Text = "No of Applications Recommended by Ground water";
            }
            else if (status == "D")
            {
                lblMsg.Text = "No of Applications NOT Recommended by Ground water";
            }
            else if (status == "E")
            {
                lblMsg.Text = "Pre-Scrutiny Pending - Within";
            }
            else if (status == "F")
            {
                lblMsg.Text = "Pre-Scrutiny Pending - Beyond";
            }
            else if (status == "G")
            {
                lblMsg.Text = "Approval Pending - Beyond";
            }
            else if (status == "H")
            {
                lblMsg.Text = "Approval Pending - Beyond";
            }
            else if (status == "J")
            {
                lblMsg.Text = "No of Applications Recommended by TRANSCO Department";
            }
            else if (status == "K")
            {
                lblMsg.Text = "No of Applications Not Recommended by TRANSCO Department";
            }
            DataSet ds = obj_dashboard.GetMonthwiseStatusrptDrill_GroundwaterMRO(Deptid, status);

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