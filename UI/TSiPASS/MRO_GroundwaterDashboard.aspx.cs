using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class UI_TSiPASS_MRO_GroundwaterDashboard : System.Web.UI.Page
{
    Cls_OSGroundWater obj_dashboard = new Cls_OSGroundWater();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/tshome.aspx");
        }

        if (!IsPostBack)
        {
            FillDetails();

            try
            {
                DataSet ds = obj_dashboard.GetDepartmentApplications_GroundwaterMRO(Session["User_Code"].ToString().Trim());
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
        DataSet ds = obj_dashboard.GetDepartmentDashboardDetails_GroundwaterMRO(Session["User_Code"].ToString().Trim());
        if(ds!=null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_noofapplicationreceived.Text = ds.Tables[0].Rows[0]["No of Application Received"].ToString();
                lbl_completedwithin3days.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Within 2 Days"].ToString();
                lbl_completedbeyond3days.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Beyond 2 Days"].ToString();
                lbl_completedtotal.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Total"].ToString();
                lblMROTotalQueryRaisedforNoofApplications.Text = ds.Tables[0].Rows[0]["Total no of Queries raised for the applications"].ToString();
                lblMRONoofApplicationsQueryResponded.Text = ds.Tables[0].Rows[0]["No of Applications Querey Responded"].ToString();

                lblrejectedatprescrutiny.Text = ds.Tables[0].Rows[0]["No of Applications Rejected"].ToString();

                lbl_fwdtogwwithin3days.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Within 2 Days"].ToString();
                lbl_fwdtogwbeyond3days.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Beyond 2 Days"].ToString();
                lbl_fwdtogwtotal.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Total"].ToString();
                lblMRONoofApplicationsAwaitingforQueryResponse.Text = ds.Tables[0].Rows[0]["No of Applications Awaiting for Querey Response"].ToString();

                lblgw_NoofApplicationsForwardtoGroundwater.Text = ds.Tables[0].Rows[0]["Total Applications forward to GW from MRO"].ToString();
                lbl_recommendedbygw.Text = ds.Tables[0].Rows[0]["No of Applications Recommended by GW"].ToString();
                lbl_notrecommendedbygw.Text = ds.Tables[0].Rows[0]["No of Applications Not Recommended by GW"].ToString();
                lblDGWO_TotalQueryRaisedforNoofApplicationsbyGroundwater.Text = ds.Tables[0].Rows[0]["Total Query raised for Applications by GW"].ToString();
                lblDGWO_NoofApplicationsQueryRespondedtoGroundwater.Text = ds.Tables[0].Rows[0]["No of applications query responsed to Groundwater"].ToString();
                lblDGWO_NoofApplicationsAwaitingforQueryResponsebyGroundwater.Text = ds.Tables[0].Rows[0]["No of Applications Awaiting queryResponse by GW"].ToString();


                lbl_approvalwithintimelimits.Text = ds.Tables[0].Rows[0]["Approval Under Process-Within Time Limits"].ToString();
                lbl_approvalbeyondtimelimits.Text = ds.Tables[0].Rows[0]["Approval Under Process-Beyond Time Limits"].ToString();
                lbl_approvalundertotal.Text = ds.Tables[0].Rows[0]["Approval Under Process-Total"].ToString();
                lblDWGO_totalApplicationsRejectedbyDistrictGroundwater.Text = ds.Tables[0].Rows[0]["No of Applications Rejected by GW"].ToString();
                lblDWGO_TotalLetterstobeuploadwhichrejetcedbyDistrictGroundWater.Text = ds.Tables[0].Rows[0]["Total Rejected applications by GW awaiting for letter upload"].ToString();

                lbl_approvalissuedwithintimelimits.Text = ds.Tables[0].Rows[0]["Approval Issued-Within Time Limits"].ToString();
                lbl_approvalissuedbeyondtimelimits.Text = ds.Tables[0].Rows[0]["Approval Issued-Beyond Time Limits"].ToString();
                lbl_approvalissuedtotal.Text = ds.Tables[0].Rows[0]["Approval Issued-Total"].ToString();
                lbl_approvalisssuedrejected.Text = ds.Tables[0].Rows[0]["No of Applications Approvals Rejected"].ToString();
                lbl_TotalUploadedLettersforRejetcedApplicationsbyDistrictGroundWater.Text = ds.Tables[0].Rows[0]["Total Rejected applications by GW letter uploaded"].ToString();

                lblTransco_NoofApplicationsForwardtoTransco.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total Applications forward to TRANSCO from MRO"]);
                lbl_recommendedbytransco.Text = Convert.ToString(ds.Tables[0].Rows[0]["No of Applications Recommended by TRANSCO"]);
                lbl_notrecommendedbytransco.Text = Convert.ToString(ds.Tables[0].Rows[0]["No of Applications Not Recommended by TRANSCO"]);

                lblTRANSCO_TotalQueryRaisedforNoofApplicationsbyTRANSCO.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total Query raised for Applications by TRANSCO"]);
                lblTRANSCO_NoofApplicationsQueryRespondedtoTRANSCO.Text = Convert.ToString(ds.Tables[0].Rows[0]["No of applications query responsed to TRANSCO"]);
                lbltransco_NoofApplicationsAwaitingforQueryResponsebytransco.Text = Convert.ToString(ds.Tables[0].Rows[0]["No of Applications Awaiting queryResponse by TRANSCO"]);

            }
        }
          
        
    }
   
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h9 = (HyperLink)e.Row.Cells[1].Controls[0];
            if (h9.Text != "0")
            {
                h9.NavigateUrl = "Departmentdrilldown_groundwater.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=J";
            }

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "Departmentdrilldown_groundwater.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=A";
            }
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "Departmentdrilldown_groundwater.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=B";
            }
            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "Departmentdrilldown_groundwater.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=C";
            }
            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "Departmentdrilldown_groundwater.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=D";
            }

            HyperLink h10 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h10.Text != "0")
            {
                h10.NavigateUrl = "Departmentdrilldown_groundwater.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=J";
            }
            HyperLink h11 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h11.Text != "0")
            {
                h11.NavigateUrl = "Departmentdrilldown_groundwater.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=K";
            }

            HyperLink h5 = (HyperLink)e.Row.Cells[8].Controls[0];
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "Departmentdrilldown_groundwater.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=E";
            }
            HyperLink h6 = (HyperLink)e.Row.Cells[9].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "Departmentdrilldown_groundwater.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=F";
            }
            HyperLink h7 = (HyperLink)e.Row.Cells[10].Controls[0];
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "Departmentdrilldown_groundwater.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=G";
            }
            HyperLink h8 = (HyperLink)e.Row.Cells[11].Controls[0];
            if (h8.Text != "0")
            {
                h8.NavigateUrl = "Departmentdrilldown_groundwater.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=H";
            }

        }


    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.GridView1.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 6 || i == 7 || i == 8 || i == 9)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }

            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Pre-Scrutiny Pending";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Approval Pending";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage1);
        }
    }

}