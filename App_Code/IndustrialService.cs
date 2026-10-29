using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
/// <summary>
/// Summary description for IndustrialService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class IndustrialService : System.Web.Services.WebService
{
    DB.DB con = new DB.DB();
    DataSet ds;
    public IndustrialService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string IndustrialClearances()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_INDUSTRIAL_CLEARANCES_SERVICE]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
            string data= ds.GetXml();
            //XmlDocument document = new XmlDocument();
            //document.LoadXml(data);
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
    public string IndustrialClearancesChecking(string uid, string status)
    {
        if (uid.Trim() != null && uid.Trim() != "") {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[USP_INS_Industrial_Cls_Checking_Service]";

            com.Parameters.Add("@Uid", SqlDbType.VarChar).Value = uid.Trim();

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
        } else { return "Error Occured"; }
        
    }



}
