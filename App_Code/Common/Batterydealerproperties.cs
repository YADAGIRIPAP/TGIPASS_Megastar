using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Batterydealerproperties
/// </summary>
public class Batterydealerproperties
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();

    public Batterydealerproperties()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public Response InsertBatterydealer(Batterydealervo bd)

    {
        Response objRes = new Response();
        con.OpenConnection();
        SqlCommand com = new SqlCommand("SP_Insert_Batterydealer", con.GetConnection);
        com.CommandType = CommandType.StoredProcedure;
        try
        {


            if (bd.BatteryDealername.ToString().Trim() == "" || bd.BatteryDealername.ToString().Trim() == null)
                com.Parameters.Add("@Nameofdealer", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Nameofdealer", SqlDbType.VarChar).Value = bd.BatteryDealername.Trim();

            //if (bd.batstate.ToString().Trim() == "0" || bd.batstate.ToString().Trim() == null || bd.batstate.ToString().Trim() == "--Select--")
            //    com.Parameters.Add("@BatState", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@BatState", SqlDbType.VarChar).Value = bd.batstate.Trim();
            
            if (bd.batdistrict.ToString().Trim() == "" || bd.batdistrict.ToString().Trim() == null || bd.batdistrict.ToString().Trim() == "--Select--")
                com.Parameters.Add("@BatDistrict", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@BatDistrict", SqlDbType.VarChar).Value = bd.batdistrict.Trim();

            if (bd.batmandal.ToString().Trim() == "" || bd.batmandal.ToString().Trim() == null || bd.batmandal.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Batmandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Batmandal", SqlDbType.VarChar).Value = bd.batmandal.Trim();

            if (bd.batvillage.ToString().Trim() == "" || bd.batvillage.ToString().Trim() == null || bd.batvillage.ToString().Trim() == "--Select--")
                com.Parameters.Add("@BatVillage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@BatVillage", SqlDbType.VarChar).Value = bd.batvillage.Trim();

            if (bd.doorno.ToString().Trim() == "" || bd.doorno.ToString().Trim() == null)
                com.Parameters.Add("@BatDoorno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@BatDoorno", SqlDbType.VarChar).Value = bd.doorno.Trim();

            if (bd.pincode.ToString().Trim() == "" || bd.pincode.ToString().Trim() == null)
                com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = bd.pincode.Trim();

            if (bd.latitude.ToString().Trim() == "" || bd.latitude.ToString().Trim() == null)
                com.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = bd.latitude.Trim();

            if (bd.Longitude.ToString().Trim() == "0" || bd.Longitude.ToString().Trim() == null )
                com.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = bd.Longitude.Trim();

            if (bd.Email.ToString().Trim() == "" || bd.Email.ToString().Trim() == null)
                com.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Email", SqlDbType.VarChar).Value = bd.Email.Trim();

            if (bd.telno.ToString().Trim() == "" || bd.telno.ToString().Trim() == null)
                com.Parameters.Add("@Telphoneno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Telphoneno", SqlDbType.VarChar).Value = bd.telno.Trim();

            if (bd.Valregdate.ToString().Trim() == "" || bd.Valregdate.ToString().Trim() == null)
                com.Parameters.Add("@valregdate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                com.Parameters.Add("@valregdate", SqlDbType.DateTime).Value =  bd.Valregdate;

            if (bd.gstnumber.ToString().Trim() == "0" || bd.gstnumber.ToString().Trim() == null)
                com.Parameters.Add("@GStnum", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@GStnum", SqlDbType.VarChar).Value = bd.gstnumber.Trim();

            
            com.Parameters.Add("@Valid", SqlDbType.Int, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            bd.BatdealerID = (Int32)com.Parameters["@Valid"].Value;


            if (bd.BatdealerID > 0)
                objRes.ResponseVal = true;

            else
                objRes.ResponseVal = false;
            con.CloseConnection();
        }


        catch (Exception ex)
        {
            throw ex;

        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
        return objRes;

    }

    
}
public class Batterydealervo
{
    public string BatteryDealername { get; set; }
    public string batstate { get; set; }
    public string batdistrict { get; set; }
    public string batmandal { get; set; }
    public string batvillage { get; set; }
    public string doorno { get; set; }
    public string pincode { get; set; }
    public string latitude { get; set; }
    public string Longitude { get; set; }
    public string Email { get; set; }
    public string telno { get; set; }
    public DateTime Valregdate { get; set; }
    public string gstnumber { get; set; }
    public string Created_by { get; set; }

    //public datet Created_dt { get; set; }
    public string Appstatus { get; set; }
    public int BatdealerID { get; set; }




}