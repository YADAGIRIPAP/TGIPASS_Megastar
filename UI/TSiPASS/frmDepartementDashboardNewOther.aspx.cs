using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmDepartementDashboardNewOther : System.Web.UI.Page
{
    //designed by siva as on 29-1-2016 
    //Purpose : Report for Year wise dashboard
    //Tables used : All
    //Stored procedures Used :YearwiseDashboardforAdmin

    General Gen = new General();
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
                DataSet ds = new DataSet();
                ds = GetDepartentApplications(Session["User_Code"].ToString().Trim());
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
        //Label1.Text = "0";
        //Label2.Text = "0";
        //Label4.Text = "0";


        //Label6.Text = "0";
        //Label8.Text = "0";


        //Label11.Text = "0";
        //Label12.Text = "0";
        //Label13.Text = "0";

        //Label17.Text = "0";
        //Label9.Text = "0";

        //Label18.Text = "0";
        //Label3.Text = "0";
        //Label21.Text = "0";
        //Label22.Text = "0";
        //Label5.Text = "0";
        //Label7.Text = "0";
        //Label10.Text = "0";

        DataSet ds = new DataSet();
        DataSet dsMAUD = new DataSet();

        if (Session["user_code"].ToString().Trim() == "266")   //nikhil done
        {
            dsMAUD = Gen.GetDepartmentDashboardDetailsOtherService(Session["User_Code"].ToString().Trim());

            Label4.Text = dsMAUD.Tables[0].Rows[0]["No of Application Received"].ToString();

            Label17.Text = dsMAUD.Tables[0].Rows[0]["No of Applications Rejected"].ToString();
            Label2.Text = dsMAUD.Tables[0].Rows[0]["Approval Under Process-Beyond Time Limits"].ToString();
            Label1.Text = dsMAUD.Tables[0].Rows[0]["Approval Under Process-Within Time Limits"].ToString();

            Label7.Text = dsMAUD.Tables[0].Rows[0]["Approval Issued-Within Time Limits"].ToString();
            Label9.Text = dsMAUD.Tables[0].Rows[0]["Approval Issued-Beyond Time Limits"].ToString();
            Label5.Text = (Convert.ToInt32(dsMAUD.Tables[0].Rows[0]["Approval Under Process-Beyond Time Limits"].ToString()) + Convert.ToInt32(dsMAUD.Tables[0].Rows[0]["Approval Under Process-Within Time Limits"].ToString())).ToString();
            Label10.Text = (Convert.ToInt32(dsMAUD.Tables[0].Rows[0]["Approval Issued-Within Time Limits"].ToString()) + Convert.ToInt32(dsMAUD.Tables[0].Rows[0]["Approval Issued-Beyond Time Limits"].ToString())).ToString();
        }
        else
        {
            ds = Gen.GetDepartmentDashboardDetailsOtherService(Session["User_Code"].ToString().Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                //labUidNumber.Text = ds.Tables[0].Rows[0]["UID Number"].ToString();
                //labNameandAddress.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                //labLineofActivity.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString();
                //labTotalInvestment.Text = ds.Tables[0].Rows[0]["Total Investment"].ToString();
                //labCategoryofIndustry.Text = ds.Tables[0].Rows[0]["Category of Industry"].ToString();
                //labDOA.Text = ds.Tables[0].Rows[0]["Date of Application"].ToString();
                //labNameandAddress0.Text = ds.Tables[0].Rows[0]["PropAddress"].ToString();
                Label4.Text = ds.Tables[0].Rows[0]["No of Application Received"].ToString();
                Label12.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Within 3 Days"].ToString();
                Label18.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Beyond 3 Days"].ToString();
                Label3.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Total"].ToString();
                Label21.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Within 3 Days"].ToString();
                Label22.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Beyond 3 Days"].ToString();
                Label6.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Total"].ToString();
                Label8.Text = ds.Tables[0].Rows[0]["No of Applications Awaiting for Query Response"].ToString();
                Label1.Text = ds.Tables[0].Rows[0]["Approval Under Process-Within Time Limits"].ToString();
                Label2.Text = ds.Tables[0].Rows[0]["Approval Under Process-Beyond Time Limits"].ToString();
                Label5.Text = ds.Tables[0].Rows[0]["Approval Under Process-Total"].ToString();
                Label11.Text = ds.Tables[0].Rows[0]["No of Approvals Awaiting Payment"].ToString();
                Label7.Text = ds.Tables[0].Rows[0]["Approval Issued-Within Time Limits"].ToString();
                Label9.Text = ds.Tables[0].Rows[0]["Approval Issued-Beyond Time Limits"].ToString();
                Label10.Text = ds.Tables[0].Rows[0]["Approval Issued-Total"].ToString();
                Label17.Text = ds.Tables[0].Rows[0]["No of Applications Rejected"].ToString();
                Label13.Text = ds.Tables[0].Rows[0]["No of Applications appeal against Rejection"].ToString();

                lblrejectedatprescrutiny.Text = ds.Tables[0].Rows[0]["No of Applications Rejected PSC"].ToString();
            }
        }


        // DataSet ds = Gen.YearwiseDashboardforAdmin("2016");
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    lbl0.Text = ds.Tables[0].Rows[0]["cnt"].ToString();
        //    lbl1.Text = ds.Tables[1].Rows[0]["cnt"].ToString();
        //    lbl2.Text = ds.Tables[2].Rows[0]["cnt"].ToString();
        //    lbl3.Text = ds.Tables[3].Rows[0]["cnt"].ToString();
        //    lbl4.Text = ds.Tables[4].Rows[0]["cnt"].ToString();
        //    lbl5.Text = ds.Tables[5].Rows[0]["cnt"].ToString();
        //    lbl6.Text = ds.Tables[6].Rows[0]["cnt"].ToString();
        //    lbl7.Text = ds.Tables[7].Rows[0]["cnt"].ToString();
        //    lbl8.Text = ds.Tables[8].Rows[0]["cnt"].ToString();
        //    lbl9.Text = ds.Tables[9].Rows[0]["cnt"].ToString();
        //    lbl10.Text = ds.Tables[10].Rows[0]["cnt"].ToString();
        //    lbl11.Text = ds.Tables[11].Rows[0]["cnt"].ToString();
        //    lbl12.Text = ds.Tables[12].Rows[0]["cnt"].ToString();
        //    lbl13.Text = ds.Tables[13].Rows[0]["cnt"].ToString();


        //}
    }

    public DataSet GetDepartentApplications(string Deptid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@intDeptid",SqlDbType.VarChar),
           };
        pp[0].Value = Deptid;
        Dsnew = Gen.GenericFillDs("[USP_CFE_DASHBOARD_DEPARTMENT]", pp);
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