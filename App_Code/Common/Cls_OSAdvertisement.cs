using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for Cls_OSAdvertisement
/// </summary>
public class Cls_OSAdvertisement
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
    public Cls_OSAdvertisement()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region
    public Response InsertAdvertisementSOA(AdvertismentDetailsobj obj, out int advertisementid)
    {

        Response objRes = new Response();

        int valid = 0;
        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("SOA_INSERT_ADVERTISEMENTDETAILS", con.GetConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            if (obj.Wheatherhoardinggornonhoarding.ToString().Trim() == "" || obj.Wheatherhoardinggornonhoarding.ToString().Trim() == null)
                cmd.Parameters.Add("@Wheatherhoardinggornonhoarding", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Wheatherhoardinggornonhoarding", SqlDbType.VarChar).Value = obj.Wheatherhoardinggornonhoarding.Trim();

            if (obj.Ulbname_cdma.ToString().Trim() == "0" || obj.Ulbname_cdma.ToString().Trim() == null || obj.Ulbname_cdma.ToString().Trim() == "--Select--")
                cmd.Parameters.Add("@Ulbname_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Ulbname_cdma", SqlDbType.VarChar).Value = obj.Ulbname_cdma.Trim();

            if (obj.Landmark_cdma.ToString().Trim() == "" || obj.Landmark_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Landmark_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Landmark_cdma", SqlDbType.VarChar).Value = obj.Landmark_cdma.Trim();

            if (obj.Ownername_cdma.ToString().Trim() == "" || obj.Ownername_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Ownername_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Ownername_cdma", SqlDbType.VarChar).Value = obj.Ownername_cdma.Trim();

            if (obj.Doornumber_cdma.ToString().Trim() == "" || obj.Doornumber_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Doornumber_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Doornumber_cdma", SqlDbType.VarChar).Value = obj.Doornumber_cdma.Trim();

            if (obj.Address_cdma.ToString().Trim() == "" || obj.Address_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Address_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Address_cdma", SqlDbType.VarChar).Value = obj.Address_cdma.Trim();

            if (obj.Assesmentnumber_cdma.ToString().Trim() == "" || obj.Assesmentnumber_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Assesmentnumber_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Assesmentnumber_cdma", SqlDbType.VarChar).Value = obj.Assesmentnumber_cdma.Trim();

            if (obj.city_cdma.ToString().Trim() == "" || obj.city_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@city_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@city_cdma", SqlDbType.VarChar).Value = obj.city_cdma.Trim();

            if (obj.Advertisementcategoery_cdma.ToString().Trim() == "0" || obj.Advertisementcategoery_cdma.ToString().Trim() == null || obj.Advertisementcategoery_cdma.ToString().Trim() == "--Select--")
                cmd.Parameters.Add("@Advertisementcategoery_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Advertisementcategoery_cdma", SqlDbType.VarChar).Value = obj.Advertisementcategoery_cdma.Trim();

            if (obj.Advertisementsubcategoery_cdma.ToString().Trim() == "0" || obj.Advertisementsubcategoery_cdma.ToString().Trim() == null || obj.Advertisementsubcategoery_cdma.ToString().Trim() == "--Select--")
                cmd.Parameters.Add("@Advertisementsubcategoery_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Advertisementsubcategoery_cdma", SqlDbType.VarChar).Value = obj.Advertisementsubcategoery_cdma.Trim();

            if (obj.Unitname_cdma.ToString().Trim() == "" || obj.Unitname_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Unitname_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Unitname_cdma", SqlDbType.VarChar).Value = obj.Unitname_cdma.Trim();

            if (obj.Landownership_cdma.ToString().Trim() == "0" || obj.Landownership_cdma.ToString().Trim() == null || obj.Landownership_cdma.ToString().Trim() == "--Select--")
                cmd.Parameters.Add("@Landownership_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Landownership_cdma", SqlDbType.VarChar).Value = obj.Landownership_cdma.Trim();

            if (obj.Lengthinmtrs_cdma.ToString().Trim() == "" || obj.Lengthinmtrs_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Lengthinmtrs_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Lengthinmtrs_cdma", SqlDbType.VarChar).Value = obj.Lengthinmtrs_cdma.Trim();

            if (obj.Widthinmtrs_cdma.ToString().Trim() == "" || obj.Widthinmtrs_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Widthinmtrs_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Widthinmtrs_cdma", SqlDbType.VarChar).Value = obj.Widthinmtrs_cdma.Trim();

            if (obj.Totalarea_cdma.ToString().Trim() == "" || obj.Totalarea_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Totalarea_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Totalarea_cdma", SqlDbType.VarChar).Value = obj.Totalarea_cdma.Trim();

            if (obj.Details_cdma.ToString().Trim() == "" || obj.Details_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Details_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Details_cdma", SqlDbType.VarChar).Value = obj.Details_cdma.Trim();

            if (obj.Startdate_cdma.ToString().Trim() == "" || obj.Startdate_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Startdate_cdma", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Startdate_cdma", SqlDbType.DateTime).Value = obj.Startdate_cdma;

            if (obj.Enddate_cdma.ToString().Trim() == "" || obj.Enddate_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Enddate_cdma", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Enddate_cdma", SqlDbType.DateTime).Value = obj.Enddate_cdma;

            if (obj.Anyotherperticulars.ToString().Trim() == "" || obj.Anyotherperticulars.ToString().Trim() == null)
                cmd.Parameters.Add("@Anyotherperticulars", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Anyotherperticulars", SqlDbType.VarChar).Value = obj.Anyotherperticulars.Trim();

            if (obj.Facing_cdma.ToString().Trim() == "0" || obj.Facing_cdma.ToString().Trim() == null || obj.Facing_cdma.ToString().Trim() == "--Select--")
                cmd.Parameters.Add("@Facing_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Facing_cdma", SqlDbType.VarChar).Value = obj.Facing_cdma.Trim();

            if (obj.Advertisement_CDMAFLAG.ToString().Trim() == "" || obj.Advertisement_CDMAFLAG.ToString().Trim() == null)
                cmd.Parameters.Add("@Advertisement_CDMAFLAG", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Advertisement_CDMAFLAG", SqlDbType.VarChar).Value = obj.Advertisement_CDMAFLAG.Trim();

            //if (obj.advertisementid.ToString().Trim() == "" || obj.advertisementid.ToString().Trim() == null)
            //    cmd.Parameters.Add("@advertisementid", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    cmd.Parameters.Add("@advertisementid", SqlDbType.VarChar).Value = obj.advertisementid.Trim();

            if (obj.Created_by.ToString().Trim() == "" || obj.Created_by.ToString().Trim() == null)
                cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = obj.Created_by.Trim();

            if (obj.Email.ToString().Trim() == "" || obj.Email.ToString().Trim() == null)
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = obj.Email.Trim();
            if (obj.MobileNumber.ToString().Trim() == "" || obj.MobileNumber.ToString().Trim() == null)
                cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = obj.MobileNumber.Trim();
            if (obj.AddressWithContact.ToString().Trim() == "" || obj.AddressWithContact.ToString().Trim() == null)
                cmd.Parameters.Add("@AddressWithContact", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AddressWithContact", SqlDbType.VarChar).Value = obj.AddressWithContact.Trim();

            if (obj.Created_IP.ToString().Trim() == "" || obj.Created_IP.ToString().Trim() == null)
                cmd.Parameters.Add("@Created_IP", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Created_IP", SqlDbType.VarChar).Value = obj.Created_IP.Trim();

            if (obj.ApplicantDoorNo.ToString().Trim() == "" || obj.ApplicantDoorNo.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantDoorNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantDoorNo", SqlDbType.VarChar).Value = obj.ApplicantDoorNo.Trim();

            if (obj.ApplicantStreetName.ToString().Trim() == "" || obj.ApplicantStreetName.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantStreetName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantStreetName ", SqlDbType.VarChar).Value = obj.ApplicantStreetName.Trim();

            if (obj.ApplicantCity.ToString().Trim() == "" || obj.ApplicantCity.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantCity", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantCity", SqlDbType.VarChar).Value = obj.ApplicantCity.Trim();

            if (obj.ApplicantSurName.ToString().Trim() == "" || obj.ApplicantSurName.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantSurName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantSurName", SqlDbType.VarChar).Value = obj.ApplicantSurName.Trim();

            if (obj.ApplicantName.ToString().Trim() == "" || obj.ApplicantName.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = obj.ApplicantName.Trim();

            if (obj.ApplicantPanNumber.ToString().Trim() == "" || obj.ApplicantPanNumber.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantPanNumber", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantPanNumber", SqlDbType.VarChar).Value = obj.ApplicantPanNumber.Trim();

            if (obj.ApplicantAdharno.ToString().Trim() == "" || obj.ApplicantAdharno.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantAdharno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantAdharno", SqlDbType.VarChar).Value = obj.ApplicantAdharno.Trim();
            if (obj.ApplicantDistID.ToString().Trim() == "" || obj.ApplicantDistID.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantDistID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantDistID ", SqlDbType.VarChar).Value = obj.ApplicantDistID.Trim();

            if (obj.ApplicantMandalID.ToString().Trim() == "" || obj.ApplicantMandalID.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantMandalID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantMandalID ", SqlDbType.VarChar).Value = obj.ApplicantMandalID.Trim();

            if (obj.ApplicantVillageID.ToString().Trim() == "" || obj.ApplicantVillageID.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantVillageID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantVillageID ", SqlDbType.VarChar).Value = obj.ApplicantVillageID.Trim();

            if (obj.ApplicantDistName.ToString().Trim() == "" || obj.ApplicantDistName.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantDistName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantDistName", SqlDbType.VarChar).Value = obj.ApplicantDistName.Trim();

            if (obj.ApplicantMandaltName.ToString().Trim() == "" || obj.ApplicantMandaltName.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantMandaltName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantMandaltName", SqlDbType.VarChar).Value = obj.ApplicantMandaltName.Trim();
            if (obj.ApplicantVillageName.ToString().Trim() == "" || obj.ApplicantVillageName.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantVillageName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantVillageName ", SqlDbType.VarChar).Value = obj.ApplicantVillageName.Trim();

            if (obj.istradelicencse.ToString().Trim() == "" || obj.istradelicencse.ToString().Trim() == null)
                cmd.Parameters.Add("@istradelicencse", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@istradelicencse ", SqlDbType.VarChar).Value = obj.istradelicencse.Trim();

            if (obj.ghmcadvphoto.ToString().Trim() == "" || obj.ghmcadvphoto.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvphoto", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvphoto ", SqlDbType.VarChar).Value = obj.ghmcadvphoto.Trim();
            if (obj.ghmcadvfee.ToString().Trim() == "" || obj.ghmcadvfee.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvfee", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvfee ", SqlDbType.VarChar).Value = obj.ghmcadvfee.Trim();
            if (obj.ghmcadvertismentrate.ToString().Trim() == "" || obj.ghmcadvertismentrate.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvertismentrate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvertismentrate ", SqlDbType.VarChar).Value = obj.ghmcadvertismentrate.Trim();
            if (obj.IS_ghmcfirsttime.ToString().Trim() == "" || obj.IS_ghmcfirsttime.ToString().Trim() == null)
                cmd.Parameters.Add("@IS_ghmcfirsttime", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@IS_ghmcfirsttime", SqlDbType.VarChar).Value = obj.IS_ghmcfirsttime.Trim();

            if (obj.ghmctradename.ToString().Trim() == "" || obj.ghmctradename.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmctradename", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmctradename ", SqlDbType.VarChar).Value = obj.ghmctradename.Trim();
            if (obj.iswithoutlicencse.ToString().Trim() == "" || obj.iswithoutlicencse.ToString().Trim() == null)
                cmd.Parameters.Add("@iswithoutlicencse", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@iswithoutlicencse ", SqlDbType.VarChar).Value = obj.iswithoutlicencse.Trim();
            if (obj.isprovisionallicencse.ToString().Trim() == "" || obj.isprovisionallicencse.ToString().Trim() == null)
                cmd.Parameters.Add("@isprovisionallicencse", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@isprovisionallicencse ", SqlDbType.VarChar).Value = obj.isprovisionallicencse.Trim();



            if (obj.ghmctradelicensenumber.ToString().Trim() == "" || obj.ghmctradelicensenumber.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmctradelicensenumber", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmctradelicensenumber ", SqlDbType.VarChar).Value = obj.ghmctradelicensenumber.Trim();

            if (obj.ghmcaddress.ToString().Trim() == "" || obj.ghmcaddress.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcaddress", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcaddress ", SqlDbType.VarChar).Value = obj.ghmcaddress.Trim();

            if (obj.ghmcarea.ToString().Trim() == "" || obj.ghmcarea.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcarea", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcarea ", SqlDbType.VarChar).Value = obj.ghmcarea.Trim();

            if (obj.ghmclocality.ToString().Trim() == "" || obj.ghmclocality.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmclocality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmclocality ", SqlDbType.VarChar).Value = obj.ghmclocality.Trim();

            if (obj.ghmcheightofbuilding.ToString().Trim() == "" || obj.ghmcheightofbuilding.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcheightofbuilding", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcheightofbuilding ", SqlDbType.VarChar).Value = obj.ghmcheightofbuilding.Trim();
            if (obj.ghmcwidthofbuilding.ToString().Trim() == "" || obj.ghmcwidthofbuilding.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcwidthofbuilding", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcwidthofbuilding ", SqlDbType.VarChar).Value = obj.ghmcwidthofbuilding.Trim();

            if (obj.ghmctradepermisearea.ToString().Trim() == "" || obj.ghmctradepermisearea.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmctradepermisearea", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmctradepermisearea ", SqlDbType.VarChar).Value = obj.ghmctradepermisearea.Trim();

            if (obj.ghmcadvertismenttype.ToString().Trim() == "" || obj.ghmcadvertismenttype.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvertismenttype", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvertismenttype ", SqlDbType.VarChar).Value = obj.ghmcadvertismenttype.Trim();

            if (obj.ghmcadvertismentcontent.ToString().Trim() == "" || obj.ghmcadvertismentcontent.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvertismentcontent", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvertismentcontent ", SqlDbType.VarChar).Value = obj.ghmcadvertismentcontent.Trim();

            if (obj.ghmccategory.ToString().Trim() == "" || obj.ghmccategory.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmccategory", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmccategory ", SqlDbType.VarChar).Value = obj.ghmccategory.Trim();

            if (obj.ghmcemd.ToString().Trim() == "" || obj.ghmcemd.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcemd", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcemd ", SqlDbType.VarChar).Value = obj.ghmcemd.Trim();

            if (obj.ghmcadvehight.ToString().Trim() == "" || obj.ghmcadvehight.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvehight", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvehight ", SqlDbType.VarChar).Value = obj.ghmcadvehight.Trim();

            if (obj.ghmcadvwidth.ToString().Trim() == "" || obj.ghmcadvwidth.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvwidth", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvwidth ", SqlDbType.VarChar).Value = obj.ghmcadvwidth.Trim();
            if (obj.tradelicenseno.ToString().Trim() == "" || obj.tradelicenseno.ToString().Trim() == null)
                cmd.Parameters.Add("@tradelicenseno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@tradelicenseno ", SqlDbType.VarChar).Value = obj.tradelicenseno.Trim();

            cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
            cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            advertisementid = (Int32)cmd.Parameters["@Valid"].Value;


            if (advertisementid > 0)
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
            cmd.Dispose();
            con.CloseConnection();
        }


        return objRes;
    }

    #endregion


    //#region 24 dec-2020 changed
    //public string InsertAdvertisementSOA(AdvertismentDetailsobj obj)
    //{
    //    string valid = "";

    //    con.OpenConnection();
    //    SqlCommand cmd = new SqlCommand("SOA_INSERT_ADVERTISEMENTDETAILS", con.GetConnection);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    try
    //    {

    //        if (obj.Wheatherhoardinggornonhoarding.ToString().Trim() == "" || obj.Wheatherhoardinggornonhoarding.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Wheatherhoardinggornonhoarding", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Wheatherhoardinggornonhoarding", SqlDbType.VarChar).Value = obj.Wheatherhoardinggornonhoarding.Trim();

    //        if (obj.Ulbname_cdma.ToString().Trim() == "0" || obj.Ulbname_cdma.ToString().Trim() == null || obj.Ulbname_cdma.ToString().Trim() == "--Select--")
    //            cmd.Parameters.Add("@Ulbname_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Ulbname_cdma", SqlDbType.VarChar).Value = obj.Ulbname_cdma.Trim();

    //        if (obj.Landmark_cdma.ToString().Trim() == "" || obj.Landmark_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Landmark_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Landmark_cdma", SqlDbType.VarChar).Value = obj.Landmark_cdma.Trim();

    //        if (obj.Ownername_cdma.ToString().Trim() == "" || obj.Ownername_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Ownername_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Ownername_cdma", SqlDbType.VarChar).Value = obj.Ownername_cdma.Trim();

    //        if (obj.Doornumber_cdma.ToString().Trim() == "" || obj.Doornumber_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Doornumber_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Doornumber_cdma", SqlDbType.VarChar).Value = obj.Doornumber_cdma.Trim();

    //        if (obj.Address_cdma.ToString().Trim() == "" || obj.Address_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Address_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Address_cdma", SqlDbType.VarChar).Value = obj.Address_cdma.Trim();

    //        if (obj.Assesmentnumber_cdma.ToString().Trim() == "" || obj.Assesmentnumber_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Assesmentnumber_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Assesmentnumber_cdma", SqlDbType.VarChar).Value = obj.Assesmentnumber_cdma.Trim();

    //        if (obj.city_cdma.ToString().Trim() == "" || obj.city_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@city_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@city_cdma", SqlDbType.VarChar).Value = obj.city_cdma.Trim();

    //        if (obj.Advertisementcategoery_cdma.ToString().Trim() == "0" || obj.Advertisementcategoery_cdma.ToString().Trim() == null || obj.Advertisementcategoery_cdma.ToString().Trim() == "--Select--")
    //            cmd.Parameters.Add("@Advertisementcategoery_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Advertisementcategoery_cdma", SqlDbType.VarChar).Value = obj.Advertisementcategoery_cdma.Trim();

    //        if (obj.Advertisementsubcategoery_cdma.ToString().Trim() == "0" || obj.Advertisementsubcategoery_cdma.ToString().Trim() == null || obj.Advertisementsubcategoery_cdma.ToString().Trim() == "--Select--")
    //            cmd.Parameters.Add("@Advertisementsubcategoery_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Advertisementsubcategoery_cdma", SqlDbType.VarChar).Value = obj.Advertisementsubcategoery_cdma.Trim();

    //        if (obj.Unitname_cdma.ToString().Trim() == "" || obj.Unitname_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Unitname_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Unitname_cdma", SqlDbType.VarChar).Value = obj.Unitname_cdma.Trim();

    //        if (obj.Landownership_cdma.ToString().Trim() == "0" || obj.Landownership_cdma.ToString().Trim() == null || obj.Landownership_cdma.ToString().Trim() == "--Select--")
    //            cmd.Parameters.Add("@Landownership_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Landownership_cdma", SqlDbType.VarChar).Value = obj.Landownership_cdma.Trim();

    //        if (obj.Lengthinmtrs_cdma.ToString().Trim() == "" || obj.Lengthinmtrs_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Lengthinmtrs_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Lengthinmtrs_cdma", SqlDbType.VarChar).Value = obj.Lengthinmtrs_cdma.Trim();

    //        if (obj.Widthinmtrs_cdma.ToString().Trim() == "" || obj.Widthinmtrs_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Widthinmtrs_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Widthinmtrs_cdma", SqlDbType.VarChar).Value = obj.Widthinmtrs_cdma.Trim();

    //        if (obj.Totalarea_cdma.ToString().Trim() == "" || obj.Totalarea_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Totalarea_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Totalarea_cdma", SqlDbType.VarChar).Value = obj.Totalarea_cdma.Trim();

    //        if (obj.Details_cdma.ToString().Trim() == "" || obj.Details_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Details_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Details_cdma", SqlDbType.VarChar).Value = obj.Details_cdma.Trim();

    //        if (obj.Startdate_cdma.ToString().Trim() == "" || obj.Startdate_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Startdate_cdma", SqlDbType.DateTime).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Startdate_cdma", SqlDbType.DateTime).Value = obj.Startdate_cdma;

    //        if (obj.Enddate_cdma.ToString().Trim() == "" || obj.Enddate_cdma.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Enddate_cdma", SqlDbType.DateTime).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Enddate_cdma", SqlDbType.DateTime).Value = obj.Enddate_cdma;

    //        if (obj.Anyotherperticulars.ToString().Trim() == "" || obj.Anyotherperticulars.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Anyotherperticulars", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Anyotherperticulars", SqlDbType.VarChar).Value = obj.Anyotherperticulars.Trim();

    //        if (obj.Facing_cdma.ToString().Trim() == "0" || obj.Facing_cdma.ToString().Trim() == null || obj.Facing_cdma.ToString().Trim() == "--Select--")
    //            cmd.Parameters.Add("@Facing_cdma", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Facing_cdma", SqlDbType.VarChar).Value = obj.Facing_cdma.Trim();

    //        if (obj.Advertisement_CDMAFLAG.ToString().Trim() == "" || obj.Advertisement_CDMAFLAG.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Advertisement_CDMAFLAG", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Advertisement_CDMAFLAG", SqlDbType.VarChar).Value = obj.Advertisement_CDMAFLAG.Trim();

    //        //if (obj.advertisementid.ToString().Trim() == "" || obj.advertisementid.ToString().Trim() == null)
    //        //    cmd.Parameters.Add("@advertisementid", SqlDbType.VarChar).Value = DBNull.Value;
    //        //else
    //        //    cmd.Parameters.Add("@advertisementid", SqlDbType.VarChar).Value = obj.advertisementid.Trim();

    //        if (obj.Created_by.ToString().Trim() == "" || obj.Created_by.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = obj.Created_by.Trim();

    //        if (obj.Email.ToString().Trim() == "" || obj.Email.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = obj.Email.Trim();
    //        if (obj.MobileNumber.ToString().Trim() == "" || obj.MobileNumber.ToString().Trim() == null)
    //            cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = obj.MobileNumber.Trim();
    //        if (obj.AddressWithContact.ToString().Trim() == "" || obj.AddressWithContact.ToString().Trim() == null)
    //            cmd.Parameters.Add("@AddressWithContact", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@AddressWithContact", SqlDbType.VarChar).Value = obj.AddressWithContact.Trim();

    //        if (obj.Created_IP.ToString().Trim() == "" || obj.Created_IP.ToString().Trim() == null)
    //            cmd.Parameters.Add("@Created_IP", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@Created_IP", SqlDbType.VarChar).Value = obj.Created_IP.Trim();

    //        if (obj.ApplicantDoorNo.ToString().Trim() == "" || obj.ApplicantDoorNo.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantDoorNo", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantDoorNo", SqlDbType.VarChar).Value = obj.ApplicantDoorNo.Trim();

    //        if (obj.ApplicantStreetName.ToString().Trim() == "" || obj.ApplicantStreetName.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantStreetName", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantStreetName ", SqlDbType.VarChar).Value = obj.ApplicantStreetName.Trim();

    //        if (obj.ApplicantCity.ToString().Trim() == "" || obj.ApplicantCity.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantCity", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantCity", SqlDbType.VarChar).Value = obj.ApplicantCity.Trim();

    //        if (obj.ApplicantSurName.ToString().Trim() == "" || obj.ApplicantSurName.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantSurName", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantSurName", SqlDbType.VarChar).Value = obj.ApplicantSurName.Trim();

    //        if (obj.ApplicantName.ToString().Trim() == "" || obj.ApplicantName.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = obj.ApplicantName.Trim();

    //        if (obj.ApplicantPanNumber.ToString().Trim() == "" || obj.ApplicantPanNumber.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantPanNumber", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantPanNumber", SqlDbType.VarChar).Value = obj.ApplicantPanNumber.Trim();

    //        if (obj.ApplicantAdharno.ToString().Trim() == "" || obj.ApplicantAdharno.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantAdharno", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantAdharno", SqlDbType.VarChar).Value = obj.ApplicantAdharno.Trim();
    //        if (obj.ApplicantDistID.ToString().Trim() == "" || obj.ApplicantDistID.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantDistID", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantDistID ", SqlDbType.VarChar).Value = obj.ApplicantDistID.Trim();

    //        if (obj.ApplicantMandalID.ToString().Trim() == "" || obj.ApplicantMandalID.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantMandalID", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantMandalID ", SqlDbType.VarChar).Value = obj.ApplicantMandalID.Trim();

    //        if (obj.ApplicantVillageID.ToString().Trim() == "" || obj.ApplicantVillageID.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantVillageID", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantVillageID ", SqlDbType.VarChar).Value = obj.ApplicantVillageID.Trim();

    //        if (obj.ApplicantDistName.ToString().Trim() == "" || obj.ApplicantDistName.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantDistName", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantDistName", SqlDbType.VarChar).Value = obj.ApplicantDistName.Trim();

    //        if (obj.ApplicantMandaltName.ToString().Trim() == "" || obj.ApplicantMandaltName.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantMandaltName", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantMandaltName", SqlDbType.VarChar).Value = obj.ApplicantMandaltName.Trim();
    //        if (obj.ApplicantVillageName.ToString().Trim() == "" || obj.ApplicantVillageName.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ApplicantVillageName", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ApplicantVillageName ", SqlDbType.VarChar).Value = obj.ApplicantVillageName.Trim();


    //        if (obj.locality.ToString().Trim() == "" || obj.locality.ToString().Trim() == null)
    //            cmd.Parameters.Add("@locality", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@locality ", SqlDbType.VarChar).Value = obj.locality.Trim();

    //        if (obj.zone.ToString().Trim() == "" || obj.zone.ToString().Trim() == null)
    //            cmd.Parameters.Add("@zone", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@zone ", SqlDbType.VarChar).Value = obj.zone.Trim();

    //        if (obj.ward.ToString().Trim() == "" || obj.ward.ToString().Trim() == null)
    //            cmd.Parameters.Add("@ward", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@ward ", SqlDbType.VarChar).Value = obj.ward.Trim();

    //        if (obj.blockno.ToString().Trim() == "" || obj.blockno.ToString().Trim() == null)
    //            cmd.Parameters.Add("@blockno", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            cmd.Parameters.Add("@blockno ", SqlDbType.VarChar).Value = obj.blockno.Trim();
    //        cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
    //        cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
    //        cmd.ExecuteNonQuery();
    //        int res = (Int32)cmd.Parameters["@Valid"].Value;
    //        valid = Convert.ToString(res);

    //        con.CloseConnection();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        cmd.Dispose();
    //        con.CloseConnection();
    //    }


    //    return valid;
    //}

    //#endregion


    public DataSet GetAdvertisementPrint(int AdvertisementId)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GET_ADVERTISEMENTDETAILS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@@Advertisementid", SqlDbType.Int).Value = AdvertisementId;
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

    public DataSet RetriveAdvertisement(string intCFOEnterpid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SAO_RetriveAdvertisement", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intCFOEnterpid.Trim() == "" || intCFOEnterpid.Trim() == null)
                da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = intCFOEnterpid.ToString();
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

    public DataSet GetAdvertisementAppIDbyuserid(int UserID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SOA_GetAdvertisementAppIDbyuserid", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
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

    public DataSet GetShowApprovalandFees_AdvertisemsntOther(string AdvertisementID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SOAGetShowApprovalandFees_Advertisement", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (AdvertisementID.Trim() == "" || AdvertisementID.Trim() == null)
                da.SelectCommand.Parameters.Add("@AdvertisementID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@AdvertisementID", SqlDbType.VarChar).Value = AdvertisementID.ToString();
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

    public DataSet GetAdvertisementPayDetailsAddtionalPayment(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SOA_GetAdvertisementPayDetails_AddtionalPayment", con.GetConnection);
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

    public int UpdateUIDAdvertisementSOA(string UID_no, string intQuessionaireid)
    {
        int valid = 0;

        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("SOAUpdateUIDAdverisement", con.GetConnection);
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


    public int insertDepartmentAprroval_AdvertisementSOA(string intQuessionaireid, string intDeptid, string intApprovalid, string Approval_Fee, string IsPayment, string Created_by, string IsOffline)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insDepartmentApprovals_Advertisement";

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


    public DataSet getAdvertisementtdatabyQues(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SOAgetAdvertisementdatabyQues", con.GetConnection);
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

    public int InsertPaymentBillDesk_AdvertisementSOA(string UidNo, string intCFEEnterpid, string OnlineOrderNo, string intDeptid, string Online_Amount, string Created_by, string intApprovalid, string ApplType, string AdditionalPayment)
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



    public DataSet GetAdvertisementpaymentDtls(string UID, string Orderno, string AdditionalPaymentflg)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_Builldesc_PaymentDtls_Advertisement_DESE", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = UID.Trim();
            da.SelectCommand.Parameters.Add("@OnlineOrderNo", SqlDbType.VarChar).Value = Orderno.Trim();
            da.SelectCommand.Parameters.Add("@AdditionalPaymentflg", SqlDbType.VarChar).Value = AdditionalPaymentflg.Trim();
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

    public DataSet GetDistricts_adv()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SOA_GetDistricts", con.GetConnection);
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
            con.CloseConnection();
        }
    }

    public DataSet GetMandalsbydistid_adv(string District)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SOA_GetMandalsbyDistid", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (District.Trim() == "" || District.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = District.ToString();
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

    public DataSet GetVillagesbymandalid_adv(string Mandal)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SOA_GetVillagesbymandalid", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Mandal.Trim() == "" || Mandal.Trim() == null || Mandal.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@inMandalid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@inMandalid", SqlDbType.VarChar).Value = Mandal.ToString();

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
    public DataSet RetriveAdvertisement_renewal(string intCFOEnterpid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SAO_RetriveAdvertisement_RENEWAL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intCFOEnterpid.Trim() == "" || intCFOEnterpid.Trim() == null)
                da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = intCFOEnterpid.ToString();
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

    public Response InsertAdvertisementSOA_renewal(AdvertismentDetailsobj_renewal obj, out int advertisementid)
    {

        Response objRes = new Response();

        int valid = 0;
        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("SOA_INSERT_ADVERTISEMENTDETAILS_RENEWAL", con.GetConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            if (obj.Wheatherhoardinggornonhoarding.ToString().Trim() == "" || obj.Wheatherhoardinggornonhoarding.ToString().Trim() == null)
                cmd.Parameters.Add("@Wheatherhoardinggornonhoarding", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Wheatherhoardinggornonhoarding", SqlDbType.VarChar).Value = obj.Wheatherhoardinggornonhoarding.Trim();

            if (obj.Ulbname_cdma.ToString().Trim() == "0" || obj.Ulbname_cdma.ToString().Trim() == null || obj.Ulbname_cdma.ToString().Trim() == "--Select--")
                cmd.Parameters.Add("@Ulbname_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Ulbname_cdma", SqlDbType.VarChar).Value = obj.Ulbname_cdma.Trim();

            if (obj.Landmark_cdma.ToString().Trim() == "" || obj.Landmark_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Landmark_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Landmark_cdma", SqlDbType.VarChar).Value = obj.Landmark_cdma.Trim();

            if (obj.Ownername_cdma.ToString().Trim() == "" || obj.Ownername_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Ownername_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Ownername_cdma", SqlDbType.VarChar).Value = obj.Ownername_cdma.Trim();

            if (obj.Doornumber_cdma.ToString().Trim() == "" || obj.Doornumber_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Doornumber_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Doornumber_cdma", SqlDbType.VarChar).Value = obj.Doornumber_cdma.Trim();

            if (obj.Address_cdma.ToString().Trim() == "" || obj.Address_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Address_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Address_cdma", SqlDbType.VarChar).Value = obj.Address_cdma.Trim();

            if (obj.Assesmentnumber_cdma.ToString().Trim() == "" || obj.Assesmentnumber_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Assesmentnumber_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Assesmentnumber_cdma", SqlDbType.VarChar).Value = obj.Assesmentnumber_cdma.Trim();

            if (obj.city_cdma.ToString().Trim() == "" || obj.city_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@city_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@city_cdma", SqlDbType.VarChar).Value = obj.city_cdma.Trim();

            if (obj.Advertisementcategoery_cdma.ToString().Trim() == "0" || obj.Advertisementcategoery_cdma.ToString().Trim() == null || obj.Advertisementcategoery_cdma.ToString().Trim() == "--Select--")
                cmd.Parameters.Add("@Advertisementcategoery_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Advertisementcategoery_cdma", SqlDbType.VarChar).Value = obj.Advertisementcategoery_cdma.Trim();

            if (obj.Advertisementsubcategoery_cdma.ToString().Trim() == "0" || obj.Advertisementsubcategoery_cdma.ToString().Trim() == null || obj.Advertisementsubcategoery_cdma.ToString().Trim() == "--Select--")
                cmd.Parameters.Add("@Advertisementsubcategoery_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Advertisementsubcategoery_cdma", SqlDbType.VarChar).Value = obj.Advertisementsubcategoery_cdma.Trim();

            if (obj.Unitname_cdma.ToString().Trim() == "" || obj.Unitname_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Unitname_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Unitname_cdma", SqlDbType.VarChar).Value = obj.Unitname_cdma.Trim();

            if (obj.Landownership_cdma.ToString().Trim() == "0" || obj.Landownership_cdma.ToString().Trim() == null || obj.Landownership_cdma.ToString().Trim() == "--Select--")
                cmd.Parameters.Add("@Landownership_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Landownership_cdma", SqlDbType.VarChar).Value = obj.Landownership_cdma.Trim();

            if (obj.Lengthinmtrs_cdma.ToString().Trim() == "" || obj.Lengthinmtrs_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Lengthinmtrs_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Lengthinmtrs_cdma", SqlDbType.VarChar).Value = obj.Lengthinmtrs_cdma.Trim();

            if (obj.Widthinmtrs_cdma.ToString().Trim() == "" || obj.Widthinmtrs_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Widthinmtrs_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Widthinmtrs_cdma", SqlDbType.VarChar).Value = obj.Widthinmtrs_cdma.Trim();

            if (obj.Totalarea_cdma.ToString().Trim() == "" || obj.Totalarea_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Totalarea_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Totalarea_cdma", SqlDbType.VarChar).Value = obj.Totalarea_cdma.Trim();

            if (obj.Details_cdma.ToString().Trim() == "" || obj.Details_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Details_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Details_cdma", SqlDbType.VarChar).Value = obj.Details_cdma.Trim();

            if (obj.Startdate_cdma.ToString().Trim() == "" || obj.Startdate_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Startdate_cdma", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Startdate_cdma", SqlDbType.DateTime).Value = obj.Startdate_cdma;

            if (obj.Enddate_cdma.ToString().Trim() == "" || obj.Enddate_cdma.ToString().Trim() == null)
                cmd.Parameters.Add("@Enddate_cdma", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Enddate_cdma", SqlDbType.DateTime).Value = obj.Enddate_cdma;

            if (obj.Anyotherperticulars.ToString().Trim() == "" || obj.Anyotherperticulars.ToString().Trim() == null)
                cmd.Parameters.Add("@Anyotherperticulars", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Anyotherperticulars", SqlDbType.VarChar).Value = obj.Anyotherperticulars.Trim();

            if (obj.Facing_cdma.ToString().Trim() == "0" || obj.Facing_cdma.ToString().Trim() == null || obj.Facing_cdma.ToString().Trim() == "--Select--")
                cmd.Parameters.Add("@Facing_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Facing_cdma", SqlDbType.VarChar).Value = obj.Facing_cdma.Trim();

            if (obj.Advertisement_CDMAFLAG.ToString().Trim() == "" || obj.Advertisement_CDMAFLAG.ToString().Trim() == null)
                cmd.Parameters.Add("@Advertisement_CDMAFLAG", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Advertisement_CDMAFLAG", SqlDbType.VarChar).Value = obj.Advertisement_CDMAFLAG.Trim();

            //if (obj.advertisementid.ToString().Trim() == "" || obj.advertisementid.ToString().Trim() == null)
            //    cmd.Parameters.Add("@advertisementid", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    cmd.Parameters.Add("@advertisementid", SqlDbType.VarChar).Value = obj.advertisementid.Trim();

            if (obj.Created_by.ToString().Trim() == "" || obj.Created_by.ToString().Trim() == null)
                cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = obj.Created_by.Trim();

            if (obj.Email.ToString().Trim() == "" || obj.Email.ToString().Trim() == null)
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = obj.Email.Trim();
            if (obj.MobileNumber.ToString().Trim() == "" || obj.MobileNumber.ToString().Trim() == null)
                cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = obj.MobileNumber.Trim();
            if (obj.AddressWithContact.ToString().Trim() == "" || obj.AddressWithContact.ToString().Trim() == null)
                cmd.Parameters.Add("@AddressWithContact", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AddressWithContact", SqlDbType.VarChar).Value = obj.AddressWithContact.Trim();

            if (obj.Created_IP.ToString().Trim() == "" || obj.Created_IP.ToString().Trim() == null)
                cmd.Parameters.Add("@Created_IP", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Created_IP", SqlDbType.VarChar).Value = obj.Created_IP.Trim();

            if (obj.ApplicantDoorNo.ToString().Trim() == "" || obj.ApplicantDoorNo.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantDoorNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantDoorNo", SqlDbType.VarChar).Value = obj.ApplicantDoorNo.Trim();

            if (obj.ApplicantStreetName.ToString().Trim() == "" || obj.ApplicantStreetName.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantStreetName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantStreetName ", SqlDbType.VarChar).Value = obj.ApplicantStreetName.Trim();

            if (obj.ApplicantCity.ToString().Trim() == "" || obj.ApplicantCity.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantCity", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantCity", SqlDbType.VarChar).Value = obj.ApplicantCity.Trim();

            if (obj.ApplicantSurName.ToString().Trim() == "" || obj.ApplicantSurName.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantSurName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantSurName", SqlDbType.VarChar).Value = obj.ApplicantSurName.Trim();

            if (obj.ApplicantName.ToString().Trim() == "" || obj.ApplicantName.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = obj.ApplicantName.Trim();

            if (obj.ApplicantPanNumber.ToString().Trim() == "" || obj.ApplicantPanNumber.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantPanNumber", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantPanNumber", SqlDbType.VarChar).Value = obj.ApplicantPanNumber.Trim();

            if (obj.ApplicantAdharno.ToString().Trim() == "" || obj.ApplicantAdharno.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantAdharno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantAdharno", SqlDbType.VarChar).Value = obj.ApplicantAdharno.Trim();
            if (obj.ApplicantDistID.ToString().Trim() == "" || obj.ApplicantDistID.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantDistID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantDistID ", SqlDbType.VarChar).Value = obj.ApplicantDistID.Trim();

            if (obj.ApplicantMandalID.ToString().Trim() == "" || obj.ApplicantMandalID.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantMandalID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantMandalID ", SqlDbType.VarChar).Value = obj.ApplicantMandalID.Trim();

            if (obj.ApplicantVillageID.ToString().Trim() == "" || obj.ApplicantVillageID.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantVillageID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantVillageID ", SqlDbType.VarChar).Value = obj.ApplicantVillageID.Trim();

            if (obj.ApplicantDistName.ToString().Trim() == "" || obj.ApplicantDistName.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantDistName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantDistName", SqlDbType.VarChar).Value = obj.ApplicantDistName.Trim();

            if (obj.ApplicantMandaltName.ToString().Trim() == "" || obj.ApplicantMandaltName.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantMandaltName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantMandaltName", SqlDbType.VarChar).Value = obj.ApplicantMandaltName.Trim();
            if (obj.ApplicantVillageName.ToString().Trim() == "" || obj.ApplicantVillageName.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantVillageName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantVillageName ", SqlDbType.VarChar).Value = obj.ApplicantVillageName.Trim();

            if (obj.istradelicencse.ToString().Trim() == "" || obj.istradelicencse.ToString().Trim() == null)
                cmd.Parameters.Add("@istradelicencse", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@istradelicencse ", SqlDbType.VarChar).Value = obj.istradelicencse.Trim();

            if (obj.ghmcadvphoto.ToString().Trim() == "" || obj.ghmcadvphoto.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvphoto", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvphoto ", SqlDbType.VarChar).Value = obj.ghmcadvphoto.Trim();
            if (obj.ghmcadvfee.ToString().Trim() == "" || obj.ghmcadvfee.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvfee", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvfee ", SqlDbType.VarChar).Value = obj.ghmcadvfee.Trim();
            if (obj.ghmcadvertismentrate.ToString().Trim() == "" || obj.ghmcadvertismentrate.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvertismentrate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvertismentrate ", SqlDbType.VarChar).Value = obj.ghmcadvertismentrate.Trim();
            if (obj.IS_ghmcfirsttime.ToString().Trim() == "" || obj.IS_ghmcfirsttime.ToString().Trim() == null)
                cmd.Parameters.Add("@IS_ghmcfirsttime", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@IS_ghmcfirsttime", SqlDbType.VarChar).Value = obj.IS_ghmcfirsttime.Trim();

            if (obj.ghmctradename.ToString().Trim() == "" || obj.ghmctradename.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmctradename", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmctradename ", SqlDbType.VarChar).Value = obj.ghmctradename.Trim();
            if (obj.iswithoutlicencse.ToString().Trim() == "" || obj.iswithoutlicencse.ToString().Trim() == null)
                cmd.Parameters.Add("@iswithoutlicencse", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@iswithoutlicencse ", SqlDbType.VarChar).Value = obj.iswithoutlicencse.Trim();
            if (obj.isprovisionallicencse.ToString().Trim() == "" || obj.isprovisionallicencse.ToString().Trim() == null)
                cmd.Parameters.Add("@isprovisionallicencse", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@isprovisionallicencse ", SqlDbType.VarChar).Value = obj.isprovisionallicencse.Trim();



            if (obj.ghmctradelicensenumber.ToString().Trim() == "" || obj.ghmctradelicensenumber.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmctradelicensenumber", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmctradelicensenumber ", SqlDbType.VarChar).Value = obj.ghmctradelicensenumber.Trim();

            if (obj.ghmcaddress.ToString().Trim() == "" || obj.ghmcaddress.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcaddress", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcaddress ", SqlDbType.VarChar).Value = obj.ghmcaddress.Trim();

            if (obj.ghmcarea.ToString().Trim() == "" || obj.ghmcarea.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcarea", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcarea ", SqlDbType.VarChar).Value = obj.ghmcarea.Trim();

            if (obj.ghmclocality.ToString().Trim() == "" || obj.ghmclocality.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmclocality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmclocality ", SqlDbType.VarChar).Value = obj.ghmclocality.Trim();

            if (obj.ghmcheightofbuilding.ToString().Trim() == "" || obj.ghmcheightofbuilding.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcheightofbuilding", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcheightofbuilding ", SqlDbType.VarChar).Value = obj.ghmcheightofbuilding.Trim();
            if (obj.ghmcwidthofbuilding.ToString().Trim() == "" || obj.ghmcwidthofbuilding.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcwidthofbuilding", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcwidthofbuilding ", SqlDbType.VarChar).Value = obj.ghmcwidthofbuilding.Trim();

            if (obj.ghmctradepermisearea.ToString().Trim() == "" || obj.ghmctradepermisearea.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmctradepermisearea", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmctradepermisearea ", SqlDbType.VarChar).Value = obj.ghmctradepermisearea.Trim();

            if (obj.ghmcadvertismenttype.ToString().Trim() == "" || obj.ghmcadvertismenttype.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvertismenttype", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvertismenttype ", SqlDbType.VarChar).Value = obj.ghmcadvertismenttype.Trim();

            if (obj.ghmcadvertismentcontent.ToString().Trim() == "" || obj.ghmcadvertismentcontent.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvertismentcontent", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvertismentcontent ", SqlDbType.VarChar).Value = obj.ghmcadvertismentcontent.Trim();

            if (obj.ghmccategory.ToString().Trim() == "" || obj.ghmccategory.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmccategory", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmccategory ", SqlDbType.VarChar).Value = obj.ghmccategory.Trim();

            if (obj.ghmcemd.ToString().Trim() == "" || obj.ghmcemd.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcemd", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcemd ", SqlDbType.VarChar).Value = obj.ghmcemd.Trim();

            if (obj.ghmcadvehight.ToString().Trim() == "" || obj.ghmcadvehight.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvehight", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvehight ", SqlDbType.VarChar).Value = obj.ghmcadvehight.Trim();

            if (obj.ghmcadvwidth.ToString().Trim() == "" || obj.ghmcadvwidth.ToString().Trim() == null)
                cmd.Parameters.Add("@ghmcadvwidth", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ghmcadvwidth ", SqlDbType.VarChar).Value = obj.ghmcadvwidth.Trim();
            if (obj.tradelicenseno.ToString().Trim() == "" || obj.tradelicenseno.ToString().Trim() == null)
                cmd.Parameters.Add("@tradelicenseno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@tradelicenseno ", SqlDbType.VarChar).Value = obj.tradelicenseno.Trim();

            cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
            cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            advertisementid = (Int32)cmd.Parameters["@Valid"].Value;


            if (advertisementid > 0)
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
            cmd.Dispose();
            con.CloseConnection();
        }


        return objRes;
    }

}

public class AdvertismentDetailsobj
{
    public string tradelicenseno { get; set; }
    public string istradelicencse { get; set; }
    public string isprovisionallicencse { get; set; }
    public string iswithoutlicencse { get; set; }
    public string ghmctradename { get; set; }
    public string ghmctradelicensenumber { get; set; }
    public string ghmcaddress { get; set; }
    public string ghmcarea { get; set; }
    public string ghmclocality { get; set; }
    public string ghmcheightofbuilding { get; set; }
    public string ghmcwidthofbuilding { get; set; }
    public string ghmctradepermisearea { get; set; }
    public string ghmcadvertismenttype { get; set; }
    public string ghmcadvertismentcontent { get; set; }
    public string ghmccategory { get; set; }
    public string ghmcemd { get; set; }
    public string ghmcadvehight { get; set; }
    public string ghmcadvwidth { get; set; }
    public string IS_ghmcfirsttime { get; set; }
    public string ghmcadvertismentrate { get; set; }
    public string ghmcadvfee { get; set; }
    public string ghmcadvphoto { get; set; }

    public string Wheatherhoardinggornonhoarding { get; set; }
    public string Ulbname_cdma { get; set; }
    public string Landmark_cdma { get; set; }
    public string Ownername_cdma { get; set; }

    public string Doornumber_cdma { get; set; }

    public string Address_cdma { get; set; }
    public string Assesmentnumber_cdma { get; set; }

    public string city_cdma { get; set; }

    public string Advertisementcategoery_cdma { get; set; }

    public string Advertisementsubcategoery_cdma { get; set; }

    public string Unitname_cdma { get; set; }

    public string Landownership_cdma { get; set; }
    public string Lengthinmtrs_cdma { get; set; }

    public string Widthinmtrs_cdma { get; set; }

    public string Totalarea_cdma { get; set; }

    public string Details_cdma { get; set; }

    public string Startdate_cdma { get; set; }

    public string Enddate_cdma { get; set; }

    public string Anyotherperticulars { get; set; }

    public string Facing_cdma { get; set; }

    public string Advertisement_CDMAFLAG { get; set; }

    public string advertisementid { get; set; }

    public string Created_by { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string AddressWithContact { get; set; }
    public string Created_IP { get; set; }
    public string ApplicantDoorNo { get; set; }
    public string ApplicantStreetName { get; set; }
    public string ApplicantCity { get; set; }
    public string ApplicantSurName { get; set; }
    public string ApplicantName { get; set; }
    public string ApplicantPanNumber { get; set; }
    public string ApplicantAdharno { get; set; }
    public string ApplicantDistID { get; set; }
    public string ApplicantMandalID { get; set; }
    public string ApplicantVillageID { get; set; }
    public string ApplicantDistName { get; set; }
    public string ApplicantMandaltName { get; set; }
    public string ApplicantVillageName { get; set; }
    public string locality { get; set; }
    public string zone { get; set; }
    public string ward { get; set; }
    public string blockno { get; set; }
}
public class AdvertismentDetailsobj_renewal
{
    public string tradelicenseno { get; set; }
    public string istradelicencse { get; set; }
    public string isprovisionallicencse { get; set; }
    public string iswithoutlicencse { get; set; }
    public string ghmctradename { get; set; }
    public string ghmctradelicensenumber { get; set; }
    public string ghmcaddress { get; set; }
    public string ghmcarea { get; set; }
    public string ghmclocality { get; set; }
    public string ghmcheightofbuilding { get; set; }
    public string ghmcwidthofbuilding { get; set; }
    public string ghmctradepermisearea { get; set; }
    public string ghmcadvertismenttype { get; set; }
    public string ghmcadvertismentcontent { get; set; }
    public string ghmccategory { get; set; }
    public string ghmcemd { get; set; }
    public string ghmcadvehight { get; set; }
    public string ghmcadvwidth { get; set; }
    public string IS_ghmcfirsttime { get; set; }
    public string ghmcadvertismentrate { get; set; }
    public string ghmcadvfee { get; set; }
    public string ghmcadvphoto { get; set; }

    public string Wheatherhoardinggornonhoarding { get; set; }
    public string Ulbname_cdma { get; set; }
    public string Landmark_cdma { get; set; }
    public string Ownername_cdma { get; set; }

    public string Doornumber_cdma { get; set; }

    public string Address_cdma { get; set; }
    public string Assesmentnumber_cdma { get; set; }

    public string city_cdma { get; set; }

    public string Advertisementcategoery_cdma { get; set; }

    public string Advertisementsubcategoery_cdma { get; set; }

    public string Unitname_cdma { get; set; }

    public string Landownership_cdma { get; set; }
    public string Lengthinmtrs_cdma { get; set; }

    public string Widthinmtrs_cdma { get; set; }

    public string Totalarea_cdma { get; set; }

    public string Details_cdma { get; set; }

    public string Startdate_cdma { get; set; }

    public string Enddate_cdma { get; set; }

    public string Anyotherperticulars { get; set; }

    public string Facing_cdma { get; set; }

    public string Advertisement_CDMAFLAG { get; set; }

    public string advertisementid { get; set; }

    public string Created_by { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string AddressWithContact { get; set; }
    public string Created_IP { get; set; }
    public string ApplicantDoorNo { get; set; }
    public string ApplicantStreetName { get; set; }
    public string ApplicantCity { get; set; }
    public string ApplicantSurName { get; set; }
    public string ApplicantName { get; set; }
    public string ApplicantPanNumber { get; set; }
    public string ApplicantAdharno { get; set; }
    public string ApplicantDistID { get; set; }
    public string ApplicantMandalID { get; set; }
    public string ApplicantVillageID { get; set; }
    public string ApplicantDistName { get; set; }
    public string ApplicantMandaltName { get; set; }
    public string ApplicantVillageName { get; set; }
    public string locality { get; set; }
    public string zone { get; set; }
    public string ward { get; set; }
    public string blockno { get; set; }
}