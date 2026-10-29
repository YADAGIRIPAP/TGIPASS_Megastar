using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSIPASS_Departmentdrilldown : System.Web.UI.Page
{
    General Gen = new General();
    DB.DB con = new DB.DB();
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
            DataSet ds = new DataSet();

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
                lblMsg.Text = "Payment Pending";
            }
            else if (status == "D")
            {
                lblMsg.Text = "Query Response Pending";
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

            ds = GetMonthwiseStatusrptDrill(Deptid, status);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();

                // grdDetails.Columns[grdDetails.Columns.Count - 1].Visible = false;
            }
            else
            {
                // Label1.Text = "No Records Found ";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }


    public DataSet GetMonthwiseStatusrptDrill(string dept, string Status)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_CFE_DASHBOARD_DEPARTMENT_DRILL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = dept;
            da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = Status;
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
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[2].Visible = false;// column 2
            e.Row.Controls[2].Visible = false;// column 2
            e.Row.Controls[e.Row.Controls.Count - 1].Visible = false;
        }
    }
}