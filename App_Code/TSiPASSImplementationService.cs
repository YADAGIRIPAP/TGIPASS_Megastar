using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Linq;

/// <summary>
/// Summary description for TSiPASSImplementationService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TSiPASSImplementationService : System.Web.Services.WebService {

    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable dt;
    SqlDataAdapter myDataAdapter;
    comFunctions cmf = new comFunctions();
    General genogj = new General();

    public TSiPASSImplementationService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]

    public DataSet ImplementationstatusReport()
    {
        DataSet dsuidno = new DataSet();
        try
        {

            dsuidno = GetImplementationData();


        }
        catch (Exception ex)
        {
        }

        return dsuidno;
    }



    public DataSet GetImplementationData()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("FetchStageOfImplementationwise_New_New_SERVICE", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //if (uidno.Trim() != "" || uidno.Trim() != null)
            //{
            //    da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            //}
            //else
            //{
            //    da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            //}
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
