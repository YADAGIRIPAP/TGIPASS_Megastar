using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


public partial class UI_TSiPASS_frmRDOPaymentDrillDown : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal NumberofApprovalsappliedfor1;
    DB.DB con = new DB.DB();
    string within;
    //string within;
    protected void Page_Load(object sender, EventArgs e)
    {
        // string rdo_Flag = Request.QueryString["rdoFlag"].ToString();
        if (!IsPostBack)
        {
            //if (rdo_Flag == "Y")
            //{
            Label1.Text = "Report as on date " + DateTime.Now.ToString() + "";

            rdoPayments.Visible = true;
            lblHeading.Text = "RDO Payments transfer pending";
            DataSet ds_RDO = new DataSet();
            ds_RDO = getRDOPaymentDet(Request.QueryString[0].ToString());
            grdRDOPayments.Visible = true;
            grdRDOPayments.DataSource = ds_RDO.Tables[0];
            grdRDOPayments.DataBind();
            //}
        }
    }

    protected void grdRDOPayments_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdRDOPayments_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {


    }


    public DataSet getRDOPaymentDet(string intDeptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_PAYMENT_ABSTRACT_DTLS_ONLINE_RDOKOTAKSPLIT", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@DEPTID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@DEPTID", SqlDbType.VarChar).Value = intDeptid.ToString();
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

    protected void grdRDOPayments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
}