using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for IndustrialIncentiveService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class IndustrialIncentiveService : System.Web.Services.WebService
{
    DB.DB con = new DB.DB();
    DataSet ds;
    public IndustrialIncentiveService()
    {
    }


    [WebMethod]
    public string IndustrialIncentives()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_INDUSTRIAL_INCENTIVES_WEBSERVICE]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
            string data = ds.GetXml();
            XmlDocument document = new XmlDocument();
            document.LoadXml(data);
            return data;
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



    [WebMethod]
    public string IndustrialIncentiveUpdate(string applicationNo, string status)
    {
        if (applicationNo.Trim() != null && applicationNo.Trim() != "")
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[USP_INS_Industrial_Incentives]";

            com.Parameters.Add("@Uid", SqlDbType.VarChar).Value = applicationNo.Trim();

            if (status.Trim() == "" || status.Trim() == null)
                com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Status", SqlDbType.VarChar).Value = status.Trim();


            con.OpenConnection();
            com.Connection = con.GetConnection;

            try
            {
                return Convert.ToInt32(com.ExecuteScalar()) == 0 ? "Success" : "Error Occured";
            }
            catch (Exception ex)
            {

                throw ex;
                return "Error Occured";
            }
            finally
            {
                com.Dispose();
                con.CloseConnection();
            }
        }
        else { return "Error Occured"; }

    }


}
