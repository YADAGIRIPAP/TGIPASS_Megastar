using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmDepartementDashboardNew_DrillingRigs : System.Web.UI.Page
{
    Cls_DrillingRigs obj_dashboard = new Cls_DrillingRigs();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            //    Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            FillDetails();

            try
            {
                   DataSet ds = obj_dashboard.GetDepartentApplications_DrillingRigsDept(Convert.ToString(Session["User_Code"]).Trim(), Convert.ToString(Session["DistrictID"]).Trim());
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }

    void FillDetails()
    {
        DataSet ds = obj_dashboard.GetDepartmentDashboardDetails_DrillingRigsDept(Convert.ToString(Session["User_Code"]).Trim(), Convert.ToString(Session["DistrictID"]).Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_noofapplicationreceived.Text = ds.Tables[0].Rows[0]["No of Application Received"].ToString();
            lbl_approvalwithintimelimits.Text = ds.Tables[0].Rows[0]["Approval Under Process-Within Time Limits"].ToString();
            lbl_approvalbeyondtimelimits.Text = ds.Tables[0].Rows[0]["Approval Under Process-Beyond Time Limits"].ToString();
            lbl_approvalundertotal.Text = ds.Tables[0].Rows[0]["Approval Under Process-Total"].ToString();

            lbl_approvalissuedwithintimelimits.Text = ds.Tables[0].Rows[0]["Approval Issued-Within Time Limits"].ToString();
            lbl_approvalissuedbeyondtimelimits.Text = ds.Tables[0].Rows[0]["Approval Issued-Beyond Time Limits"].ToString();
            lbl_approvalissuedtotal.Text = ds.Tables[0].Rows[0]["Approval Issued-Total"].ToString();
            lbl_approvalisssuedrejected.Text = ds.Tables[0].Rows[0]["No of Applications Approvals Rejected"].ToString();

            lbl_totalqueryraised.Text = ds.Tables[0].Rows[0]["Total Query Raised"].ToString();
            lbl_queryresponsepending.Text = ds.Tables[0].Rows[0]["Total Query Pending"].ToString();
            lbl_queryresponded.Text = ds.Tables[0].Rows[0]["Total Query Responded"].ToString();
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "Departmentdrilldown_DrillingRigs.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=A";
                
            }

            HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "Departmentdrilldown_DrillingRigs.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=B";
                
            }
            HyperLink h3 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "Departmentdrilldown_DrillingRigs.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=C";
            }
            
            HyperLink h4 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "Departmentdrilldown_DrillingRigs.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=D";
            }
            HyperLink h5 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "Departmentdrilldown_DrillingRigs.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=E";
            }
            HyperLink h6 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "Departmentdrilldown_DrillingRigs.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=F";
            }
            HyperLink h7 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "Departmentdrilldown_DrillingRigs.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=G";
            }
            HyperLink h8 = (HyperLink)e.Row.Cells[8].Controls[0];
            if (h8.Text != "0")
            {
                h8.NavigateUrl = "Departmentdrilldown_DrillingRigs.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=H";
            }

        }


    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //GridViewRow gvHeaderRow = e.Row;
            //GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            //this.GridView1.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            //int headerCellCount = gvHeaderRow.Cells.Count;
            //int cellIndex = 0;

            //for (int i = 0; i < headerCellCount; i++)
            //{
            //    if (i == 6 || i == 7)
            //    {
            //        cellIndex++;
            //    }
            //    else
            //    {
            //        TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
            //        tcHeader.RowSpan = 2;
            //        gvHeaderRowCopy.Cells.Add(tcHeader);
            //    }
            //}

            //TableCell tcMergePackage = new TableCell();
            //tcMergePackage.Text = "With in Time Limit";
            //tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage.ColumnSpan = 2;
            //gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage);

            //TableCell tcMergePackage1 = new TableCell();
            //tcMergePackage1.Text = "Approval Pending";
            //tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage1.ColumnSpan = 2;
            //gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage1);
        }
    }

}