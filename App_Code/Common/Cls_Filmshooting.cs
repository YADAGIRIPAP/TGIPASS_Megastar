using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Cls_Filmshooting
/// </summary>
public class Cls_Filmshooting
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
    public Cls_Filmshooting()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GetFilmShootingDetails(int filmshootingid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("Get_FilmShooting_Print", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@filmshootingid", SqlDbType.Int).Value = filmshootingid;
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

    public Response InsertFilmShootingDetails(string CompanyGSTIN,
            string Produccername, string Tradebody, string Tradebodydetails, string Filmtitle, string Filmlanguage,
            string Otherlanguage, string Filmtype, string Othertype, string Shootingtime,
            string Director, string Cameraman, string Mainartists, string Totalcrewno, string Proposedshootingschedule,
            out int intfilmshootingid, string Locationname, string LocationnameId,
            string Fromdate, string Todate, string Blockingdays, string Shootingdays, string Noofpolicepersions, string Priceperlocation, string Shootingfee, string Cautionfee,
            string Servicefee, string Policefee, string Gst, string Extrahoursamount, string Totalamount, string Created_by, string FilmDevelopmentCorporationFLAG,
string ParticularsFurnishedFLAG, string ReimbursetheDamageFLAG, string Departmentname_termsconditionsFLAG, string Departmentid, string Departmentname,
string ProductionAgencyName, string Permanent_District, string Permanent_Mandal, string Permanent_Village,
string Permanent_PlotNo, string Permanent_PINCODE, string CkeckSameasaddress, string Temperory_District,
string Temperory_Mandal, string Temperory_Village, string Temperory_PlotNo, string Temperory_PINCODE,
string AgencyPhno1, string AgencyPhno2, string ProducerDistrict, string ProducerMandal, string ProducerVillage,
string ProducerPlotNo, string ProducerPINCODE, string ProducerPhno1, string ProducerPhno2, string ProducerEmailId, string ApplicantName,
string ApplicantMobileNo)
    {
        Response objRes = new Response();
        con.OpenConnection();
        SqlCommand com = new SqlCommand("SP_INSERT_FILMSHOOTINGDETAILS", con.GetConnection);
        com.CommandType = CommandType.StoredProcedure;

        try
        {
            if (ApplicantName.ToString().Trim() == "" || ApplicantName.ToString().Trim() == null)
                com.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = ApplicantName.Trim();

            if (ApplicantMobileNo.ToString().Trim() == "" || ApplicantMobileNo.ToString().Trim() == null)
                com.Parameters.Add("@ApplicantMobileNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicantMobileNo", SqlDbType.VarChar).Value = ApplicantMobileNo.Trim();

            if (ProductionAgencyName.ToString().Trim() == "" || ProductionAgencyName.ToString().Trim() == null)
                com.Parameters.Add("@ProductionAgencyName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ProductionAgencyName", SqlDbType.VarChar).Value = ProductionAgencyName.Trim();

            if (Permanent_District.ToString().Trim() == "0" || Permanent_District.ToString().Trim() == null || Permanent_District.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Permanent_District", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Permanent_District", SqlDbType.VarChar).Value = Permanent_District.Trim();

            if (Permanent_Mandal.ToString().Trim() == "0" || Permanent_Mandal.ToString().Trim() == null || Permanent_Mandal.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Permanent_Mandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Permanent_Mandal", SqlDbType.VarChar).Value = Permanent_Mandal.Trim();

            if (Permanent_Village.ToString().Trim() == "0" || Permanent_Village.ToString().Trim() == null || Permanent_Village.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Permanent_Village", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Permanent_Village", SqlDbType.VarChar).Value = Permanent_Village.Trim();

            if (Permanent_PlotNo.ToString().Trim() == "" || Permanent_PlotNo.ToString().Trim() == null)
                com.Parameters.Add("@Permanent_PlotNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Permanent_PlotNo", SqlDbType.VarChar).Value = Permanent_PlotNo.Trim();

            if (Permanent_PINCODE.ToString().Trim() == "" || Permanent_PINCODE.ToString().Trim() == null)
                com.Parameters.Add("@Permanent_PINCODE", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Permanent_PINCODE", SqlDbType.VarChar).Value = Permanent_PINCODE.Trim();

            if (CkeckSameasaddress.ToString().Trim() == "" || CkeckSameasaddress.ToString().Trim() == null)
                com.Parameters.Add("@CkeckSameasaddress", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@CkeckSameasaddress", SqlDbType.VarChar).Value = CkeckSameasaddress.Trim();

            if (Temperory_District.ToString().Trim() == "0" || Temperory_District.ToString().Trim() == null || Temperory_District.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Temperory_District", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Temperory_District", SqlDbType.VarChar).Value = Temperory_District.Trim();

            if (Temperory_Mandal.ToString().Trim() == "0" || Temperory_Mandal.ToString().Trim() == null || Temperory_Mandal.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Temperory_Mandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Temperory_Mandal", SqlDbType.VarChar).Value = Temperory_Mandal.Trim();

            if (Temperory_Village.ToString().Trim() == "0" || Temperory_Village.ToString().Trim() == null || Temperory_Village.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Temperory_Village", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Temperory_Village", SqlDbType.VarChar).Value = Temperory_Village.Trim();

            if (Temperory_PlotNo.ToString().Trim() == "" || Temperory_PlotNo.ToString().Trim() == null)
                com.Parameters.Add("@Temperory_PlotNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Temperory_PlotNo", SqlDbType.VarChar).Value = Temperory_PlotNo.Trim();

            if (Temperory_PINCODE.ToString().Trim() == "" || Temperory_PINCODE.ToString().Trim() == null)
                com.Parameters.Add("@Temperory_PINCODE", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Temperory_PINCODE", SqlDbType.VarChar).Value = Temperory_PINCODE.Trim();

            if (AgencyPhno1.ToString().Trim() == "" || AgencyPhno1.ToString().Trim() == null)
                com.Parameters.Add("@AgencyPhno1", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AgencyPhno1", SqlDbType.VarChar).Value = AgencyPhno1.Trim();

            if (AgencyPhno2.ToString().Trim() == "" || AgencyPhno2.ToString().Trim() == null)
                com.Parameters.Add("@AgencyPhno2", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AgencyPhno2", SqlDbType.VarChar).Value = AgencyPhno2.Trim();


            if (ProducerDistrict.ToString().Trim() == "0" || ProducerDistrict.ToString().Trim() == null || ProducerDistrict.ToString().Trim() == "--Select--")
                com.Parameters.Add("@ProducerDistrict", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ProducerDistrict", SqlDbType.VarChar).Value = ProducerDistrict.Trim();

            if (ProducerMandal.ToString().Trim() == "0" || ProducerMandal.ToString().Trim() == null || ProducerMandal.ToString().Trim() == "--Select--")
                com.Parameters.Add("@ProducerMandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ProducerMandal", SqlDbType.VarChar).Value = ProducerMandal.Trim();

            if (ProducerVillage.ToString().Trim() == "0" || ProducerVillage.ToString().Trim() == null || ProducerVillage.ToString().Trim() == "--Select--")
                com.Parameters.Add("@ProducerVillage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ProducerVillage", SqlDbType.VarChar).Value = ProducerVillage.Trim();

            if (ProducerPlotNo.ToString().Trim() == "" || ProducerPlotNo.ToString().Trim() == null)
                com.Parameters.Add("@ProducerPlotNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ProducerPlotNo", SqlDbType.VarChar).Value = ProducerPlotNo.Trim();

            if (ProducerPINCODE.ToString().Trim() == "" || ProducerPINCODE.ToString().Trim() == null)
                com.Parameters.Add("@ProducerPINCODE", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ProducerPINCODE", SqlDbType.VarChar).Value = ProducerPINCODE.Trim();

            if (ProducerPhno1.ToString().Trim() == "" || ProducerPhno1.ToString().Trim() == null)
                com.Parameters.Add("@ProducerPhno1", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ProducerPhno1", SqlDbType.VarChar).Value = ProducerPhno1.Trim();

            if (ProducerPhno2.ToString().Trim() == "" || ProducerPhno2.ToString().Trim() == null)
                com.Parameters.Add("@ProducerPhno2", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ProducerPhno2", SqlDbType.VarChar).Value = ProducerPhno2.Trim();


            if (ProducerEmailId.ToString().Trim() == "" || ProducerEmailId.ToString().Trim() == null)
                com.Parameters.Add("@ProducerEmailId", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ProducerEmailId", SqlDbType.VarChar).Value = ProducerEmailId.Trim();



            if (CompanyGSTIN.ToString().Trim() == "" || CompanyGSTIN.ToString().Trim() == null)
                com.Parameters.Add("@CompanyGSTIN", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@CompanyGSTIN", SqlDbType.VarChar).Value = CompanyGSTIN.Trim();

            if (Produccername.ToString().Trim() == "" || Produccername.ToString().Trim() == null)
                com.Parameters.Add("@Produccername", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Produccername", SqlDbType.VarChar).Value = Produccername.Trim();

            if (Tradebody.ToString().Trim() == "" || Tradebody.ToString().Trim() == null || Tradebody.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Tradebody", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Tradebody", SqlDbType.VarChar).Value = Tradebody.Trim();

            if (Tradebodydetails.ToString().Trim() == "" || Tradebodydetails.ToString().Trim() == null)
                com.Parameters.Add("@Tradebodydetails", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Tradebodydetails", SqlDbType.VarChar).Value = Tradebodydetails.Trim();

            if (Filmtitle.ToString().Trim() == "" || Filmtitle.ToString().Trim() == null)
                com.Parameters.Add("@Filmtitle", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Filmtitle", SqlDbType.VarChar).Value = Filmtitle.Trim();

            if (Filmlanguage.ToString().Trim() == "" || Filmlanguage.ToString().Trim() == null || Filmlanguage.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Filmlanguage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Filmlanguage", SqlDbType.VarChar).Value = Filmlanguage.Trim();

            if (Otherlanguage.ToString().Trim() == "" || Otherlanguage.ToString().Trim() == null || Otherlanguage.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Otherlanguage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Otherlanguage", SqlDbType.VarChar).Value = Otherlanguage.Trim();

            if (Filmtype.ToString().Trim() == "" || Filmtype.ToString().Trim() == null || Filmtype.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Filmtype", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Filmtype", SqlDbType.VarChar).Value = Filmtype.Trim();

            if (Othertype.ToString().Trim() == "" || Othertype.ToString().Trim() == null || Othertype.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Othertype", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Othertype", SqlDbType.VarChar).Value = Othertype.Trim();

            if (Shootingtime.ToString().Trim() == "" || Shootingtime.ToString().Trim() == null || Shootingtime.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Shootingtime", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Shootingtime", SqlDbType.VarChar).Value = Shootingtime.Trim();


            if (Director.ToString().Trim() == "" || Director.ToString().Trim() == null)
                com.Parameters.Add("@Director", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Director", SqlDbType.VarChar).Value = Director.Trim();

            if (Cameraman.ToString().Trim() == "" || Cameraman.ToString().Trim() == null)
                com.Parameters.Add("@Cameraman", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Cameraman", SqlDbType.VarChar).Value = Cameraman.Trim();

            if (Mainartists.ToString().Trim() == "" || Mainartists.ToString().Trim() == null)
                com.Parameters.Add("@Mainartists", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Mainartists", SqlDbType.VarChar).Value = Mainartists.Trim();

            if (Totalcrewno.ToString().Trim() == "" || Totalcrewno.ToString().Trim() == null)
                com.Parameters.Add("@Totalcrewno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Totalcrewno", SqlDbType.VarChar).Value = Totalcrewno.Trim();

            if (Proposedshootingschedule.ToString().Trim() == "" || Proposedshootingschedule.ToString().Trim() == null)
                com.Parameters.Add("@Proposedshootingschedule", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Proposedshootingschedule", SqlDbType.VarChar).Value = Proposedshootingschedule.Trim();



            if (Locationname.ToString().Trim() == "" || Locationname.ToString().Trim() == null || Locationname.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Locationname", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Locationname", SqlDbType.VarChar).Value = Locationname.Trim();
            if (LocationnameId.ToString().Trim() == "" || LocationnameId.ToString().Trim() == null || LocationnameId.ToString().Trim() == "--Select--")
                com.Parameters.Add("@LocationnameId", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@LocationnameId", SqlDbType.VarChar).Value = LocationnameId.Trim();

            if (Fromdate.ToString().Trim() == "" || Fromdate.ToString().Trim() == null)
                com.Parameters.Add("@Fromdate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                com.Parameters.Add("@Fromdate", SqlDbType.DateTime).Value = cmf.convertDateIndia(Fromdate.Trim());

            if (Todate.ToString().Trim() == "" || Todate.ToString().Trim() == null)
                com.Parameters.Add("@Todate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                com.Parameters.Add("@Todate", SqlDbType.DateTime).Value = cmf.convertDateIndia(Todate.Trim());

            if (Blockingdays.ToString().Trim() == "" || Blockingdays.ToString().Trim() == null)
                com.Parameters.Add("@Blockingdays", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Blockingdays", SqlDbType.VarChar).Value = Blockingdays.Trim();

            if (Shootingdays.ToString().Trim() == "" || Shootingdays.ToString().Trim() == null)
                com.Parameters.Add("@Shootingdays", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Shootingdays", SqlDbType.VarChar).Value = Shootingdays.Trim();

            if (Noofpolicepersions.ToString().Trim() == "" || Noofpolicepersions.ToString().Trim() == null)
                com.Parameters.Add("@Noofpolicepersions", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Noofpolicepersions", SqlDbType.VarChar).Value = Noofpolicepersions.Trim();

            if (Priceperlocation.ToString().Trim() == "" || Priceperlocation.ToString().Trim() == null)
                com.Parameters.Add("@Priceperlocation", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Priceperlocation", SqlDbType.VarChar).Value = Priceperlocation.Trim();

            if (Shootingfee.ToString().Trim() == "" || Shootingfee.ToString().Trim() == null)
                com.Parameters.Add("@Shootingfee", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Shootingfee", SqlDbType.VarChar).Value = Shootingfee.Trim();

            if (Cautionfee.ToString().Trim() == "" || Cautionfee.ToString().Trim() == null)
                com.Parameters.Add("@Cautionfee", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Cautionfee", SqlDbType.VarChar).Value = Cautionfee.Trim();

            if (Servicefee.ToString().Trim() == "" || Servicefee.ToString().Trim() == null)
                com.Parameters.Add("@Servicefee", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Servicefee", SqlDbType.VarChar).Value = Servicefee.Trim();

            if (Policefee.ToString().Trim() == "" || Policefee.ToString().Trim() == null)
                com.Parameters.Add("@Policefee", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Policefee", SqlDbType.VarChar).Value = Policefee.Trim();

            if (Gst.ToString().Trim() == "" || Gst.ToString().Trim() == null)
                com.Parameters.Add("@Gst", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Gst", SqlDbType.VarChar).Value = Gst.Trim();

            if (Extrahoursamount.ToString().Trim() == "" || Extrahoursamount.ToString().Trim() == null)
                com.Parameters.Add("@Extrahoursamount", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Extrahoursamount", SqlDbType.VarChar).Value = Extrahoursamount.Trim();

            if (Totalamount.ToString().Trim() == "" || Totalamount.ToString().Trim() == null)
                com.Parameters.Add("@Totalamount", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Totalamount", SqlDbType.VarChar).Value = Totalamount.Trim();






            if (Created_by.ToString().Trim() == "" || Created_by.ToString().Trim() == null)
                com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();


            if (FilmDevelopmentCorporationFLAG.Trim() == "" || FilmDevelopmentCorporationFLAG.Trim() == null)
                com.Parameters.Add("@FilmDevelopmentCorporationFLAG", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@FilmDevelopmentCorporationFLAG", SqlDbType.VarChar).Value = FilmDevelopmentCorporationFLAG.ToString();

            if (ParticularsFurnishedFLAG.Trim() == "" || ParticularsFurnishedFLAG.Trim() == null)
                com.Parameters.Add("@ParticularsFurnishedFLAG", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ParticularsFurnishedFLAG", SqlDbType.VarChar).Value = ParticularsFurnishedFLAG.ToString();

            if (ReimbursetheDamageFLAG.Trim() == "" || ReimbursetheDamageFLAG.Trim() == null)
                com.Parameters.Add("@ReimbursetheDamageFLAG", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ReimbursetheDamageFLAG", SqlDbType.VarChar).Value = ReimbursetheDamageFLAG.ToString();

            if (Departmentname_termsconditionsFLAG.Trim() == "" || Departmentname_termsconditionsFLAG.Trim() == null)
                com.Parameters.Add("@Departmentname_termsconditionsFLAG", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Departmentname_termsconditionsFLAG", SqlDbType.VarChar).Value = Departmentname_termsconditionsFLAG.ToString();

            if (Departmentid.Trim() == "" || Departmentid.Trim() == null)
                com.Parameters.Add("@Departmentid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Departmentid", SqlDbType.VarChar).Value = Departmentid.ToString();


            if (Departmentname.Trim() == "" || Departmentname.Trim() == null)
                com.Parameters.Add("@Departmentname", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Departmentname", SqlDbType.VarChar).Value = Departmentname.ToString();

            com.Parameters.Add("@Valid", SqlDbType.Int, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            intfilmshootingid = (Int32)com.Parameters["@Valid"].Value;
            if (intfilmshootingid > 0)
                objRes.ResponseVal = true;
            else
            {
                objRes.ResponseVal = false;
            }
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
    public DataSet RetriveFilmShootingDetails(int createdby, string applicationid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_Retrivefilmshootingdetails", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@created_by", SqlDbType.VarChar).Value = createdby;
            if (applicationid.Trim() == "" || applicationid.Trim() == null)
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = applicationid.ToString();
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


    public DataSet GetFilmshootingAppIDbyuserid(int UserID, string applicationid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("FS_GetFilmshootingAppIDbyuserid", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            if (applicationid.Trim() == "" || applicationid.Trim() == null)
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = applicationid.ToString();
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

    public DataSet GetShowApprovalandFees_Filmshooting(string AdvertisementID, string applicationid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("FS_GetShowApprovalandFees_filmshooting", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (AdvertisementID.Trim() == "" || AdvertisementID.Trim() == null)
                da.SelectCommand.Parameters.Add("@AdvertisementID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@AdvertisementID", SqlDbType.VarChar).Value = AdvertisementID.ToString();
            if (applicationid.Trim() == "" || applicationid.Trim() == null)
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = applicationid.ToString();
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


    public DataSet GetFilmshootingPayDetailsAddtionalPayment(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SOA_GetfilmshootingPayDetails_AddtionalPayment", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();
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

    public int UpdateUIDFilmshooting(string UID_no, string intQuessionaireid)
    {
        int valid = 0;

        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("FS_UpdateUIDfilmshooting", con.GetConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@UID_no", UID_no);
            cmd.Parameters.AddWithValue("@intQuessionaireid", intQuessionaireid);
            cmd.ExecuteNonQuery();
            con.CloseConnection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Dispose();
            con.CloseConnection();
        }

        return valid;
    }

    public int insertDepartmentAprroval_Filmshooting(string intQuessionaireid, string intDeptid, string intApprovalid, string Approval_Fee, string IsPayment, string Created_by, string IsOffline)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insDepartmentApprovals_filmshooting";

        if (intQuessionaireid == "" || intQuessionaireid == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (Approval_Fee == "" || Approval_Fee == null)
            com.Parameters.Add("@Approval_Fee", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval_Fee", SqlDbType.Decimal).Value = Convert.ToDecimal(Approval_Fee.Trim());

        if (IsPayment == "" || IsPayment == null)
            com.Parameters.Add("@IsPayment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IsPayment", SqlDbType.VarChar).Value = IsPayment;

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (IsOffline == "" || IsOffline == null)
            com.Parameters.Add("@IsOffline", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IsOffline", SqlDbType.VarChar).Value = IsOffline.Trim();
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

    public DataSet getFilmshootingdatabyQues(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("FS_getfilmshootingdatabyQues", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();
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

    public int InsertPaymentBillDesk_Filmshooting(string UidNo, string intCFEEnterpid, string OnlineOrderNo, string intDeptid, string Online_Amount, string Created_by, string intApprovalid, string ApplType, string AdditionalPayment)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_INSERT_Builldesc_PaymentDtls";

        if (UidNo.Trim() == "" || UidNo.Trim() == null)
        {
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = UidNo.Trim();
        }
        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());

        if (OnlineOrderNo == "" || OnlineOrderNo == null)
            com.Parameters.Add("@OnlineOrderNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@OnlineOrderNo", SqlDbType.VarChar).Value = OnlineOrderNo.Trim();


        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());


        if (Online_Amount == "" || Online_Amount == null)
            com.Parameters.Add("@Online_Amount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Online_Amount", SqlDbType.VarChar).Value = Convert.ToDecimal(Online_Amount.Trim());


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
        {
            com.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
        }
        if (AdditionalPayment == "" || AdditionalPayment == null)
            com.Parameters.Add("@AdditionalPayment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdditionalPayment", SqlDbType.VarChar).Value = AdditionalPayment.Trim();

        com.Parameters.Add("@ApplType", SqlDbType.VarChar).Value = ApplType.Trim();
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








}