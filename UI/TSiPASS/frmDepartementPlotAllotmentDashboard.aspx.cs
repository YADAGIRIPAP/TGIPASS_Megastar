using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class UI_TSiPASS_frmDepartementPlotAllotmentDashboard : System.Web.UI.Page
{
    General Gen = new General();
    cls_plotallotmentadmin obj_plot = new cls_plotallotmentadmin();
    protected void Page_Load(object sender, EventArgs e)
    {
       if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            FillDetails();
            try
            {
                //DataSet ds = new DataSet();
                //ds = GetDepartentApplications(Session["User_Code"].ToString().Trim());
                //GridView1.DataSource = ds.Tables[0];
                //GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }


    void FillDetails()
    {
        //2(Q - Submitted),3(Application Submitted and Payment Pending),5(Query Raised and Payment Pending),8 (Query Responded and Payment Pending),
        //13 (Approved by Department),16(Rejected),19(Deffered)


        //No of Application Received  Pre - Scrutiny - Pending - Within 3 Days 
        //Pre-Scrutiny - Pending - Beyond 3 Days Pre-Scrutiny - Pending - Total
        //No of Applications Awaiting for Query Response  No of Applications Rejected Approval Issued - Within Time Limits
        //Approval Issued - Beyond Time Limits  Approval Issued - Total 
        //Pre - Scrutiny - Deffered - Within 3 Days Pre - Scrutiny - Deffered - Beyond 3 Days Pre - Scrutiny - Completed - Total  
        //Pre - Scrutiny - CurrentinDefferedStatus - Total  Query - CurrentRespondedCount
        //    843 1   44  46  2   336 224 176 428 4   68  765 1   30
            
                    DataSet ds = new DataSet();
            ds = obj_plot.GetplotallotmentDepartmentDashboardDetails(Session["User_Code"].ToString().Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
            lbl_noofrecievedapplication.Text = ds.Tables[0].Rows[0]["No of Application Received"].ToString();
            lbl_defferedwithin3days.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Deffered-Within 3 Days"].ToString();
            lbl_defferedbeyond3days.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Deffered-Beyond 3 Days"].ToString();    
            lbl_deffereedtotal.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Total"].ToString();
            lbl_currentdefferedststatus.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-CurrentinDefferedStatus-Total"].ToString();
            lbl_prescrunitywithin3days.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Within 3 Days"].ToString();
            lbl_prescrunitybeyond3days.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Beyond 3 Days"].ToString();
            lbl_prescrunitytotal.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Total"].ToString();

            lbl_waitingforqueryrespone.Text = ds.Tables[0].Rows[0]["No of Applications Awaiting for Query Response"].ToString();
            lbl_queryresponded.Text = ds.Tables[0].Rows[0]["Query-CurrentRespondedCount"].ToString();
            lbl_approvedwithinlimit.Text = ds.Tables[0].Rows[0]["Approval Issued-Within Time Limits"].ToString();
            lbl_approvedbeyondlimit.Text = ds.Tables[0].Rows[0]["Approval Issued-Beyond Time Limits"].ToString();
            lbl_approvaltotal.Text = ds.Tables[0].Rows[0]["Approval Issued-Total"].ToString();
            lbl_noofrejected.Text = ds.Tables[0].Rows[0]["No of Applications Rejected"].ToString();
            }      
    }

    public DataSet GetDepartentApplications(string Deptid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@intDeptid",SqlDbType.VarChar),
           };
        pp[0].Value = Deptid;
        Dsnew = Gen.GenericFillDs("[USP_PlotAllotment_DASHBOARD_DEPARTMENT]", pp);
        return Dsnew;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h9 = (HyperLink)e.Row.Cells[1].Controls[0];
            if (h9.Text != "0")
            {
                h9.NavigateUrl = "Departmentdrilldown.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=J";
            }

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "Departmentdrilldown.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=A";
            }
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "Departmentdrilldown.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=B";
            }
            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "Departmentdrilldown.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=C";
            }
            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "Departmentdrilldown.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=D";
            }
            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "Departmentdrilldown.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=E";
            }
            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "Departmentdrilldown.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=F";
            }
            HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "Departmentdrilldown.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=G";
            }
            HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
            if (h8.Text != "0")
            {
                h8.NavigateUrl = "Departmentdrilldown.aspx?Deptid=" + Session["User_Code"].ToString().Trim() + "&Status=H";
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