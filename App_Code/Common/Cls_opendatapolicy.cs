using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;
using System.Configuration;

/// <summary>
/// Summary description for Cls_opendatapolicy
/// </summary>
public class Cls_opendatapolicy
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    DataSet ds;
    comFunctions cmf = new comFunctions();
    public Cls_opendatapolicy()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataSet DBgetTSiPASSDataset(string FromDate, string ToDate)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("ODP_DistrictwiseDrildownNew_CFE", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (FromDate.Trim() == "" || FromDate.Trim() == null)
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromDate.ToString();
            if (ToDate.Trim() == "" || ToDate.Trim() == null)
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = ToDate.ToString();
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

    public DataSet DBgetTSiPASSMSMEDataset(string FromDate, string ToDate)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("ODP_GET_MSME_REPORT_DRILLDOWN_NEW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (FromDate.Trim() == "" || FromDate.Trim() == null)
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromDate.ToString();
            if (ToDate.Trim() == "" || ToDate.Trim() == null)
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = ToDate.ToString();
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

    public DataSet DBGetTsipassIncentivesDataset(string FromDate, string ToDate)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("ODP_GET_Incentives_ClaimedReportDrill", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (FromDate.Trim() == "" || FromDate.Trim() == null)
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromDate.ToString();
            if (ToDate.Trim() == "" || ToDate.Trim() == null)
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = ToDate.ToString();
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

    public DataSet DBGetTsipassIncentivesClaimApprovalReports(string FromDate, string ToDate)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("ODP_GET_Incentives_ClaimedReport", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (FromDate.Trim() == "" || FromDate.Trim() == null)
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromDate.ToString();
            if (ToDate.Trim() == "" || ToDate.Trim() == null)
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = ToDate.ToString();
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

    public DataSet DBGettsipassRawMaterial(string FromDate, string ToDate)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("ODP_GET_RM_JDDASHBOARDss4_DRILL_BYROLE", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (FromDate.Trim() == "" || FromDate.Trim() == null)
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromDate.ToString();
            if (ToDate.Trim() == "" || ToDate.Trim() == null)
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = ToDate.ToString();
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