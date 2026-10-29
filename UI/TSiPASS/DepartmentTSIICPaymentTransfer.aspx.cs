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



public partial class UI_TSiPASS_DepartmentTSIICPaymentTransfer : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal NumberofApprovalsappliedfor1;
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = GetcfepaydetailsNew("406","", "", "","O", "","","Kotak","Plot");
        TSIICPLOT.PlotDetailsService PLOT = new TSIICPLOT.PlotDetailsService();
        TSIICLAND.TransactionDetails tran = new TSIICLAND.TransactionDetails();
        TSIICLAND.LandAllotmentService landservice = new TSIICLAND.LandAllotmentService();
        dt = ds.Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            tran.amount = Convert.ToDouble(dt.Rows[i]["Approval_Fee"].ToString());
            tran.amountSpecified = true;
            tran.ipassID = Convert.ToInt64(dt.Rows[i]["CFEID"].ToString());
            tran.ipassIDSpecified = true;
            tran.name = dt.Rows[i]["Name of Unit"].ToString();
            tran.ref_no = dt.Rows[i]["Transaction No"].ToString();
            tran.transaction_date = Convert.ToDateTime(dt.Rows[i]["BankTransactionDate"].ToString());
            tran.transaction_dateSpecified = true;
            tran.transaction_details = dt.Rows[i]["BankTransactionno"].ToString();

            string output = landservice.saveCreditedTransactionDetails(tran);

            if (output == "Data saved successfully....")
            {
                UpdateDepartwebserviceflagTransfer(dt.Rows[i]["BankTransactionno"].ToString(), "406", "C", output, "Y");
            }
        }

    }

    public int UpdateDepartwebserviceflagTransfer(string uidno, string deptid, string flag, string output, string statusflag)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPD_DEPTCOMMONFEILDS_TRANSFER";

        if (uidno == "" || uidno == null)
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.Trim();

        if (deptid == "" || deptid == null)
            com.Parameters.Add("@DEPTID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DEPTID", SqlDbType.VarChar).Value = deptid.Trim();

        if (flag == "" || flag == null)
            com.Parameters.Add("@FLAG", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@FLAG", SqlDbType.VarChar).Value = flag.Trim();

        if (statusflag == "" || statusflag == null)
            com.Parameters.Add("@STATUSFLAG", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@STATUSFLAG", SqlDbType.VarChar).Value = statusflag.Trim();

        if (output == "" || output == null)
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = output.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public DataSet GetcfepaydetailsNew(string intDeptid, string UID_No, string nameofunit, string District, string paymentmode, string fromdate, string todate, string BankName, string ApplicationType)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_PAYMENT_ABSTRACT_DTLS_ONLINE_DEPARTMENTTRANSFERED_TRANSFER", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();


            if (fromdate.Trim() == "" || fromdate.Trim() == null || fromdate.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                //  da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = cmf.convertDateIndia(fromdate);
                da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = (fromdate);

            if (todate.Trim() == "" || todate.Trim() == null || todate.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@todate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@todate", SqlDbType.VarChar).Value = (todate);

            if (paymentmode.Trim() == "" || paymentmode.Trim() == null || paymentmode.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@paymentmode", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@paymentmode", SqlDbType.VarChar).Value = paymentmode.ToString();

            if (District.Trim() == "" || District.Trim() == null || District.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = District.ToString();
            if (UID_No.Trim() == "" || UID_No.Trim() == null)
                da.SelectCommand.Parameters.Add("@UID_No", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@UID_No", SqlDbType.VarChar).Value = UID_No.ToString();

            if (nameofunit.Trim() == "" || nameofunit.Trim() == null)
                da.SelectCommand.Parameters.Add("@nameofunit", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@nameofunit", SqlDbType.VarChar).Value = nameofunit.ToString();

            if (BankName.Trim() == "" || BankName.Trim() == null || BankName.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@BankName", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName.ToString();

            da.SelectCommand.Parameters.Add("@ApplicationType", SqlDbType.VarChar).Value = ApplicationType.ToString();

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