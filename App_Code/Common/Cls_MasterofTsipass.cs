using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;

using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for Cls_MasterofTsipass
/// </summary>
public class Cls_MasterofTsipass
{
    string strConnectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    //public Cls_MasterofTsipass()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    public DataSet GetallDistrictswithoutWarangal(string Createdby, string ApplicationType)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Master_DistrictswithoutWarangal", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Createdby.Trim() == "" || Createdby.Trim() == null)
                da.SelectCommand.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby.ToString();
            if (ApplicationType.Trim() == "" || ApplicationType.Trim() == null)
                da.SelectCommand.Parameters.Add("@ApplicationType", SqlDbType.VarChar).Value = " %";
            else
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
            con.Close();
        }
    }

}