using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmDepartmentDashboardADMG : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
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
            }
    }
    void FillDetails()
    {
        DataSet ds = new DataSet();
        ds = GetDepartmentDashboardDetailsADMG(Session["DistrictID"].ToString().Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {
            
            lblTotAppl.Text = ds.Tables[0].Rows[0]["Total No of Applications"].ToString();
            lblApproved.Text = ds.Tables[0].Rows[0]["Approval Issued by Tahsildar"].ToString();
            LblPendng.Text= ds.Tables[0].Rows[0]["No of Applications Pending"].ToString();
            lblRejctd.Text = ds.Tables[0].Rows[0]["No of Applications Rejected"].ToString();

           
        }

    }

    public DataSet GetDepartmentDashboardDetailsADMG(String DistrictID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("sp_GetDepartmentDashboardDetailsCFO", con.GetConnection);
            da = new SqlDataAdapter("[sp_GetDepartmentDashboardDetails_ADMG]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (DistrictID.Trim() == "" || DistrictID.Trim() == null)
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DistrictID.ToString();

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