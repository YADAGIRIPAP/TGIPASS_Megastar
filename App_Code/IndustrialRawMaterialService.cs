using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

/// <summary>
/// Summary description for IndustrialRawMaterialService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class IndustrialRawMaterialService : System.Web.Services.WebService
{
    DB.DB con = new DB.DB();
    DataSet ds;
    public IndustrialRawMaterialService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string IndustrialRawMaterial()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_INDUSTRIAL_RAWMATERIAL]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
            string data = ds.GetXml();
           // XmlDocument document = new XmlDocument();
           // document.LoadXml(data);
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
    public string IndustrialRawMaterialUpdate(string UdyogAadhaar, string status)
    {
        if (UdyogAadhaar.Trim() != null && UdyogAadhaar.Trim() != "")
        { 
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[USP_INS_Industrial_RawMaterial]";

            com.Parameters.Add("@Uid", SqlDbType.VarChar).Value = UdyogAadhaar.Trim();

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
