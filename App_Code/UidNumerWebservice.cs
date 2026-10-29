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

/// <summary>
/// Summary description for UidNumerWebservice
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class UidNumerWebservice : System.Web.Services.WebService {

    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable dt;
    SqlDataAdapter myDataAdapter;
    comFunctions cmf = new comFunctions();

    public UidNumerWebservice () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public string GetdataonUIDnumber(string uidno)
    {
        string lblmsg = "";
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("GetCFEEnterprenuerDetailsNew_Service_INSPECTION", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() == "" || uidno.Trim() == null || uidno.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@uidno", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@uidno", SqlDbType.VarChar).Value = uidno;
            }
           
            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
            lblmsg = ds.GetXml();

            //return lblmsg;
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();

        }
        return lblmsg;
    }
}
