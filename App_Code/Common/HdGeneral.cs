using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Globalization;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Summary description for HdGeneral
/// </summary>
public class HdGeneral
{

    #region Global


    private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

    public static IDbConnection GetConncetion
    {
        get { return new SqlConnection(_connectionString); }
    }





    #endregion





    public HdGeneral()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    #region DatabaseOperations



    public DataSet FillDataSetwithProcedure ( string ProcedureName,SqlParameter sp) 
    {
        DataSet ds = new DataSet();
        return ds;
    }



    public DataSet FillIncList(string IncId, string Unitname, string dist)
    {
        DataSet ds = new DataSet();
        GetConncetion.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        try
        {
            da = new SqlDataAdapter("usp_get_hd_inc_list", GetConncetion.ConnectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@incid", SqlDbType.VarChar).Value = IncId.ToString();
            da.SelectCommand.Parameters.Add("@unitname", SqlDbType.VarChar).Value = Unitname.ToString();
            da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = dist;

            da.Fill(ds);

        }
        finally
        {
            GetConncetion.Close();
        }
        return ds;
    }


    public DataSet GetIncentivesDetails(string IncId, string Masterincentiveid)
    {
        DataSet ds = new DataSet();
        GetConncetion.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        try
        {
            da = new SqlDataAdapter("USP_GET_HD_INC_DETAILS", GetConncetion.ConnectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@Incid", SqlDbType.VarChar).Value = IncId.ToString();
            da.SelectCommand.Parameters.Add("@Masterincentiveid", SqlDbType.VarChar).Value = Masterincentiveid.ToString();
            da.Fill(ds);

        }
        finally
        {
            GetConncetion.Close();
        }
        return ds;
    }

    public DataSet GetIncentivesDetailsRollback(string IncId, string Masterincentiveid, string SLCorDLC)
    {
        DataSet ds = new DataSet();
        GetConncetion.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        try
        {
            da = new SqlDataAdapter("USP_GET_ROLLBACKLEVELS", GetConncetion.ConnectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@EnprIncentiveId", SqlDbType.VarChar).Value = IncId.ToString();
            da.SelectCommand.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = Masterincentiveid.ToString();
            da.SelectCommand.Parameters.Add("@SLCorDLC", SqlDbType.VarChar).Value = SLCorDLC.ToString();
            da.Fill(ds);
        }
        finally
        {
            GetConncetion.Close();
        }
        return ds;
    }

    public DataSet GetIncentives(string IncId)
    {
        DataSet ds = new DataSet();
        GetConncetion.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        try
        {
            da = new SqlDataAdapter("USP_GET_HD_INCLIST_BY_ID", GetConncetion.ConnectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@EnprIncentiveId", SqlDbType.VarChar).Value = IncId.ToString();

            da.Fill(ds);

        }
        finally
        {
            GetConncetion.Close();
        }
        return ds;
    }

    public int ApplicantCasteChange(int EnpreId, int caste)
    {
        SqlConnection con = new SqlConnection(GetConncetion.ConnectionString);
        SqlCommand Com = new SqlCommand("USP_HD_CHANGE_CASTE", con);

        Com.CommandType = CommandType.StoredProcedure;


        Com.Parameters.Add("@EnprIncentiveId", SqlDbType.Int).Value = EnpreId;
        Com.Parameters.Add("@Caste", SqlDbType.Int).Value = caste;
        Com.Parameters.Add("@Result", SqlDbType.Int).Value = 0;
        Com.Parameters["@Result"].Direction = ParameterDirection.Output;
        
        con.Open();
        try
        {
            Com.ExecuteNonQuery();
            return Convert.ToInt32(Com.Parameters["@Result"].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Com.Dispose();
            con.Close();
        }
    }

    public int IncentiveAmountChange(int EnpreId,int MstIncId ,int role,string Amount)
    {
        SqlConnection con = new SqlConnection(GetConncetion.ConnectionString);
        SqlCommand Com = new SqlCommand("USP_HD_CHANGE_AMOUNT_BY_ROLE", con);

        Com.CommandType = CommandType.StoredProcedure;

        Com.Parameters.Add("@EnprIncentiveId", SqlDbType.Int).Value = EnpreId;
        Com.Parameters.Add("@MstIncentiveId", SqlDbType.Int).Value = MstIncId;
        Com.Parameters.Add("@Role", SqlDbType.Int).Value = role;
        Com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount;
        Com.Parameters.Add("@Result", SqlDbType.Int).Value = 0;
        Com.Parameters["@Result"].Direction = ParameterDirection.Output;

        con.Open();
        try
        {
            Com.ExecuteNonQuery();
            return Convert.ToInt32(Com.Parameters["@Result"].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Com.Dispose();
            con.Close();
        }
    }

    public string ApplicationRollback(string module, string EnprIncId, string MstincId, string Trasntype, string ModifiedBy, string Remarks, string HdId,string Ipaddress)
    {
        string Result = "";
        SqlConnection con = new SqlConnection(GetConncetion.ConnectionString);
        SqlCommand Com = new SqlCommand("USP_SOLUTIONUPDTAES_NEW", con);

        Com.CommandType = CommandType.StoredProcedure;
        Com.Parameters.Add("@MODULE", SqlDbType.VarChar).Value = module;
        Com.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = EnprIncId;
        Com.Parameters.Add("@MSTINCENTIVEID", SqlDbType.VarChar).Value = MstincId;
        Com.Parameters.Add("@TRANSACTIONTYPE", SqlDbType.VarChar).Value = Trasntype;
        Com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = ModifiedBy;
        Com.Parameters.Add("@HDREMARKS", SqlDbType.VarChar).Value = Remarks;
        Com.Parameters.Add("@HdId", SqlDbType.VarChar).Value = HdId;
        Com.Parameters.Add("@Ipaddress", SqlDbType.VarChar).Value = Ipaddress;
        Com.Parameters.Add("@Result", SqlDbType.VarChar).Value = "0";
        Com.Parameters["@Result"].Direction = ParameterDirection.Output;

        con.Open();
        try
        {
            Com.ExecuteNonQuery();
            Result = Com.Parameters["@Result"].Value.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Com.Dispose();
            con.Close();
        }

        return Result;
    }



    public DataSet testGridData()
    {
        DataSet ds = new DataSet();
        GetConncetion.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        try
        {
            da = new SqlDataAdapter("SELECT top 5 * FROM dbo.Incentives_Application_Common_Details iacd   ", GetConncetion.ConnectionString);
            da.SelectCommand.CommandType = CommandType.Text;

            //da.SelectCommand.Parameters.Add("@incid", SqlDbType.VarChar).Value = IncId.ToString();
            //da.SelectCommand.Parameters.Add("@unitname", SqlDbType.VarChar).Value = Unitname.ToString();
            //da.SelectCommand.Parameters.Add("@dist", SqlDbType.Int).Value = dist;

            da.Fill(ds);

        }
        finally
        {
            GetConncetion.Close();
        }
        return ds;
    }



    public DataSet GetDistrictsbystate(string intstateid)
    {
        GetConncetion.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getDistrictsbystate", GetConncetion.ConnectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@intstateid", SqlDbType.VarChar).Value = "%";

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            GetConncetion.Close();
        }

    }


    public DataSet GetTableNames()
    {
        GetConncetion.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_HD_TABLES", GetConncetion.ConnectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            GetConncetion.Close();
        }

    }

    

    public DataSet GetTableColumnNames(string table)
    {
        GetConncetion.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_HD_TABLE_COLUMNS", GetConncetion.ConnectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Table", SqlDbType.VarChar).Value = table;

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            GetConncetion.Close();
        }

    }

    public DataSet GetGrid(string table,string column,string value)
    {
        GetConncetion.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_HD_GRIDLIST", GetConncetion.ConnectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@BASETABLE", SqlDbType.VarChar).Value = table;
            da.SelectCommand.Parameters.Add("@BASECOLUMN", SqlDbType.VarChar).Value = column;
            da.SelectCommand.Parameters.Add("@VALUE", SqlDbType.VarChar).Value = value;

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            GetConncetion.Close();
        }

    }


    public int UpdateGrid(string query, string table, string column, string value,string tblcols,string oldvalues,string newvalues)
    {
        SqlConnection con = new SqlConnection(GetConncetion.ConnectionString);
        SqlCommand Com = new SqlCommand("USP_HD_SOLUTION", con);

        Com.CommandType = CommandType.StoredProcedure;


        Com.Parameters.Add("@QUERY", SqlDbType.VarChar).Value = query;
        Com.Parameters.Add("@MODUSER", SqlDbType.VarChar).Value = "1";
        Com.Parameters.Add("@BASETABLE", SqlDbType.VarChar).Value = table;
        Com.Parameters.Add("@BASECOLUMN", SqlDbType.VarChar).Value = column;
        Com.Parameters.Add("@BASEVALUE", SqlDbType.VarChar).Value = value;
        Com.Parameters.Add("@IPADDR", SqlDbType.VarChar).Value = "1.1.1.1";
        Com.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = "Test Remarks by ch9nna";
        Com.Parameters.Add("@COLNAMES", SqlDbType.VarChar).Value = tblcols;
        Com.Parameters.Add("@COLOLDVALUES", SqlDbType.VarChar).Value = oldvalues;
        Com.Parameters.Add("@COLNEWVALUES", SqlDbType.VarChar).Value = newvalues;


        con.Open();
        try
        {
            return Com.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Com.Dispose();
            con.Close();
        }
    }








    #endregion




    #region Common Operations


    public string DataTableToJSONWithStringBuilder(DataTable table)
    {
        var JSONString = new StringBuilder();
        if (table.Rows.Count > 0)
        {
            JSONString.Append("[");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                JSONString.Append("{");
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (j < table.Columns.Count - 1)
                    {
                        JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                    }
                    else if (j == table.Columns.Count - 1)
                    {
                        JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                    }
                }
                if (i == table.Rows.Count - 1)
                {
                    JSONString.Append("}");
                }
                else
                {
                    JSONString.Append("},");
                }
            }
            JSONString.Append("]");
        }
        return JSONString.ToString();
    }


    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);
            }
            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }


    public string DataTableToJSONWithJSONNet(DataTable table)
    {
        string JSONString = string.Empty;
        JSONString = JsonConvert.SerializeObject(table);
        return JSONString;
    }


    public string DataSetToJsonWithJSONNet(DataSet ds)
    {
        string JSONString = string.Empty;
        JSONString = JsonConvert.SerializeObject(ds,Formatting.Indented);
        return JSONString;
    }


    #endregion


    #region Helpdesk Operations











    #endregion


}