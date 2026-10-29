using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Cls_UserMobileTower
/// </summary>
public class Cls_UserMobileTower
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
    public Cls_UserMobileTower()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet ViewAttachmetsmobiltowerdata(string intEnterprenuerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_RetriveAttachmentsmobiletower", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();



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


    public DataSet RetriveMobileTowerApplicationDetails(string intCFOEnterpid, string createdby)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_RetriveMobileTowerApplicationDetails", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intCFOEnterpid.Trim() == "" || intCFOEnterpid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = intCFOEnterpid.ToString();

            if (createdby.Trim() == "" || createdby.Trim() == null)
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby.ToString();

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

    public Response InsertMobileTowerApplicationDetails(string intQuessionaireCFOid, string intCFOEnterpid,
             string ProviderCompanyname, string Door, string Road, string Area, string Mandal, string Distrct, string Pincode, string Email, string Plotno,
              string Layoutno, string Surveyno, string Wardno, string Blockno, string Doorno, string Streetroad, string Eelectionwardno,
             string Electionblockno, string Circle, string Locality, string Proposedarea, string Proposeddistrict, string Proposedmandal,
              string Gpsddegree, string Gpsmminit, string Gpsseconds,
            string Siteareaasperdocment_cdma, string Siteareaasperplan_cdma, string Roadwideningarea_cdma, string Netarea_cdma,
             string east, string west, string north, string south, string Proposals_cdma, string accessoryroom, string genaretorroom, string Proposedonbilding_cdma, string vacantlandtaxidno,
             string propertytaxidno, string Buildingpermissionno_cdma, string Occpancycertificateno_cdma, string towerconstruction, string ownername, string networkagency, string licenseagreement, string leaseyears, string AuthorisedAgent,
             string AuthorisedAgentName, string Architectname, string architectno, string architectaddress, string Engineername, string Engineerlicesenceno, string Engineeraddress, string Surveyorname, string Surveyorno,
            string Surveyoraddress, string Structuralengneer, string Structuralengneerlicno, string mobiletowerid, string Created_by, out int mobileid)
    {
        // Response objRes = new Response();
        //SqlCommand com = new SqlCommand();
        //com.CommandType = CommandType.StoredProcedure;
        //com.CommandText = "SP_INSERT_MOBILETOWERAPPLICATION_DETAILS";

        Response objRes = new Response();
        con.OpenConnection();
        SqlCommand com = new SqlCommand("SP_INSERT_MOBILETOWERAPPLICATION_DETAILS", con.GetConnection);
        com.CommandType = CommandType.StoredProcedure;

        try
        {

            if (intQuessionaireCFOid.ToString().Trim() == "" || intQuessionaireCFOid.ToString().Trim() == null)
                com.Parameters.Add("@intCFOQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@intCFOQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireCFOid.Trim();

            if (intCFOEnterpid.ToString().Trim() == "" || intCFOEnterpid.ToString().Trim() == null)
                com.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = intCFOEnterpid.Trim();

            if (ProviderCompanyname.ToString().Trim() == "" || ProviderCompanyname.ToString().Trim() == null)
                com.Parameters.Add("@ProviderCompanyname", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ProviderCompanyname", SqlDbType.VarChar).Value = ProviderCompanyname.Trim();

            if (Door.ToString().Trim() == "" || Door.ToString().Trim() == null)
                com.Parameters.Add("@Door", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Door", SqlDbType.VarChar).Value = Door.Trim();

            if (Road.ToString().Trim() == "" || Road.ToString().Trim() == null)
                com.Parameters.Add("@Road", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Road", SqlDbType.VarChar).Value = Road.Trim();

            if (Area.ToString().Trim() == "" || Area.ToString().Trim() == null)
                com.Parameters.Add("@Area", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Area", SqlDbType.VarChar).Value = Area.Trim();

            if (Mandal.ToString().Trim() == "" || Mandal.ToString().Trim() == null)
                com.Parameters.Add("@Mandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Mandal", SqlDbType.VarChar).Value = Mandal.Trim();

            if (Distrct.ToString().Trim() == "" || Distrct.ToString().Trim() == null)
                com.Parameters.Add("@Distrct", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Distrct", SqlDbType.VarChar).Value = Distrct.Trim();
            if (Pincode.ToString().Trim() == "" || Pincode.ToString().Trim() == null)
                com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = Pincode.Trim();

            if (Email.ToString().Trim() == "" || Email.ToString().Trim() == null)
                com.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email.Trim();

            if (Plotno.ToString().Trim() == "" || Plotno.ToString().Trim() == null)
                com.Parameters.Add("@Plotno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Plotno", SqlDbType.VarChar).Value = Plotno.Trim();

            if (Layoutno.ToString().Trim() == "" || Layoutno.ToString().Trim() == null)
                com.Parameters.Add("@Layoutno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Layoutno", SqlDbType.VarChar).Value = Layoutno.Trim();


            if (Surveyno.ToString().Trim() == "" || Surveyno.ToString().Trim() == null)
                com.Parameters.Add("@Surveyno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Surveyno", SqlDbType.VarChar).Value = Surveyno.Trim();

            if (Wardno.ToString().Trim() == "" || Wardno.ToString().Trim() == null)
                com.Parameters.Add("@Wardno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Wardno", SqlDbType.VarChar).Value = Wardno.Trim();

            if (Blockno.ToString().Trim() == "" || Blockno.ToString().Trim() == null)
                com.Parameters.Add("@Blockno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Blockno", SqlDbType.VarChar).Value = Blockno.Trim();

            if (Doorno.ToString().Trim() == "" || Doorno.ToString().Trim() == null)
                com.Parameters.Add("@Doorno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Doorno", SqlDbType.VarChar).Value = Doorno.Trim();

            if (Streetroad.ToString().Trim() == "" || Streetroad.ToString().Trim() == null)
                com.Parameters.Add("@Streetroad", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Streetroad", SqlDbType.VarChar).Value = Streetroad.Trim();

            if (Eelectionwardno.ToString().Trim() == "" || Eelectionwardno.ToString().Trim() == null)
                com.Parameters.Add("@Eelectionwardno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Eelectionwardno", SqlDbType.VarChar).Value = Eelectionwardno.Trim();

            if (Electionblockno.ToString().Trim() == "" || Electionblockno.ToString().Trim() == null)
                com.Parameters.Add("@Electionblockno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Electionblockno", SqlDbType.VarChar).Value = Electionblockno.Trim();


            if (Circle.ToString().Trim() == "0" || Circle.ToString().Trim() == null || Circle.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Circle", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Circle", SqlDbType.VarChar).Value = Circle.Trim();

            if (Locality.ToString().Trim() == "0" || Locality.ToString().Trim() == null || Locality.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Locality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Locality", SqlDbType.VarChar).Value = Locality.Trim();

            if (Proposedarea.ToString().Trim() == "" || Proposedarea.ToString().Trim() == null)
                com.Parameters.Add("@Proposedarea", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Proposedarea", SqlDbType.VarChar).Value = Proposedarea.Trim();

            if (Proposeddistrict.ToString().Trim() == "0" || Proposeddistrict.ToString().Trim() == null || Proposeddistrict.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Proposeddistrict", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Proposeddistrict", SqlDbType.VarChar).Value = Proposeddistrict.Trim();
            if (Proposedmandal.ToString().Trim() == "0" || Proposedmandal.ToString().Trim() == null || Proposedmandal.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Proposedmandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Proposedmandal", SqlDbType.VarChar).Value = Proposedmandal.Trim();

            

            if (Gpsddegree.ToString().Trim() == "" || Gpsddegree.ToString().Trim() == null)
                com.Parameters.Add("@Gpsddegree", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Gpsddegree", SqlDbType.VarChar).Value = Gpsddegree.Trim();
            if (Gpsmminit.ToString().Trim() == "" || Gpsmminit.ToString().Trim() == null)
                com.Parameters.Add("@Gpsmminit", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Gpsmminit", SqlDbType.VarChar).Value = Gpsmminit.Trim();
            if (Gpsseconds.ToString().Trim() == "" || Gpsseconds.ToString().Trim() == null)
                com.Parameters.Add("@Gpsseconds", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Gpsseconds", SqlDbType.VarChar).Value = Gpsseconds.Trim();


            if (Siteareaasperdocment_cdma.ToString().Trim() == "" || Siteareaasperdocment_cdma.ToString().Trim() == null)
                com.Parameters.Add("@Siteareaasperdocment_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Siteareaasperdocment_cdma", SqlDbType.VarChar).Value = Siteareaasperdocment_cdma.Trim();

            if (Siteareaasperplan_cdma.ToString().Trim() == "" || Siteareaasperplan_cdma.ToString().Trim() == null)
                com.Parameters.Add("@Siteareaasperplan_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Siteareaasperplan_cdma", SqlDbType.VarChar).Value = Siteareaasperplan_cdma.Trim();

            if (Roadwideningarea_cdma.ToString().Trim() == "" || Roadwideningarea_cdma.ToString().Trim() == null)
                com.Parameters.Add("@Roadwideningarea_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Roadwideningarea_cdma", SqlDbType.VarChar).Value = Roadwideningarea_cdma.Trim();

            if (Netarea_cdma.ToString().Trim() == "" || Netarea_cdma.ToString().Trim() == null)
                com.Parameters.Add("@Netarea_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Netarea_cdma", SqlDbType.VarChar).Value = Netarea_cdma.Trim();


            if (east.ToString().Trim() == "" || east.ToString().Trim() == null)
                com.Parameters.Add("@East_cdma)", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@East_cdma", SqlDbType.VarChar).Value = east.Trim();

            if (west.ToString().Trim() == "" || west.ToString().Trim() == null)
                com.Parameters.Add("@west_cdma)", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@west_cdma", SqlDbType.VarChar).Value = west.Trim();

            if (north.ToString().Trim() == "" || north.ToString().Trim() == null)
                com.Parameters.Add("@north_cdma)", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@north_cdma", SqlDbType.VarChar).Value = north.Trim();

            if (south.ToString().Trim() == "" || south.ToString().Trim() == null)
                com.Parameters.Add("@south_cdma)", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@south_cdma", SqlDbType.VarChar).Value = south.Trim();

            if (Proposals_cdma.ToString().Trim() == "0" || Proposals_cdma.ToString().Trim() == null || Proposals_cdma.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Proposals_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Proposals_cdma", SqlDbType.VarChar).Value = Proposals_cdma.Trim();

            if (Proposedonbilding_cdma.ToString().Trim() == "" || Proposedonbilding_cdma.ToString().Trim() == null)
                com.Parameters.Add("@Proposedonbilding_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Proposedonbilding_cdma", SqlDbType.VarChar).Value = Proposedonbilding_cdma.Trim();

            if (accessoryroom.ToString().Trim() == "" || accessoryroom.ToString().Trim() == null)
                com.Parameters.Add("@accessoryroom_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@accessoryroom_cdma", SqlDbType.VarChar).Value = accessoryroom.Trim();

            if (genaretorroom.ToString().Trim() == "" || genaretorroom.ToString().Trim() == null)
                com.Parameters.Add("@genaretorroom_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@genaretorroom_cdma", SqlDbType.VarChar).Value = genaretorroom.Trim();

            if (Buildingpermissionno_cdma.ToString().Trim() == "" || Buildingpermissionno_cdma.ToString().Trim() == null)
                com.Parameters.Add("@Buildingpermissionno_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Buildingpermissionno_cdma", SqlDbType.VarChar).Value = Buildingpermissionno_cdma.Trim();

            if (vacantlandtaxidno.ToString().Trim() == "" || vacantlandtaxidno.ToString().Trim() == null)
                com.Parameters.Add("@vacantlandtaxidno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@vacantlandtaxidno", SqlDbType.VarChar).Value = vacantlandtaxidno.Trim();

            if (propertytaxidno.ToString().Trim() == "" || propertytaxidno.ToString().Trim() == null)
                com.Parameters.Add("@propertytaxidno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@propertytaxidno", SqlDbType.VarChar).Value = propertytaxidno.Trim();

            if (Occpancycertificateno_cdma.ToString().Trim() == "" || Occpancycertificateno_cdma.ToString().Trim() == null)
                com.Parameters.Add("@Occpancycertificateno_cdma", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Occpancycertificateno_cdma", SqlDbType.VarChar).Value = Occpancycertificateno_cdma.Trim();



            if (towerconstruction.ToString().Trim() == "" || towerconstruction.ToString().Trim() == null)
                com.Parameters.Add("@towerconstruction", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@towerconstruction", SqlDbType.VarChar).Value = towerconstruction.Trim();

            if (ownername.ToString().Trim() == "" || ownername.ToString().Trim() == null)
                com.Parameters.Add("@ownername", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ownername", SqlDbType.VarChar).Value = ownername.Trim();
            if (networkagency.ToString().Trim() == "0" || networkagency.ToString().Trim() == null || networkagency.ToString().Trim() == "--Select--")
                com.Parameters.Add("@networkagency", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@networkagency", SqlDbType.VarChar).Value = networkagency.Trim();


            if (licenseagreement.ToString().Trim() == "" || licenseagreement.ToString().Trim() == null)
                com.Parameters.Add("@licenseagreement", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@licenseagreement", SqlDbType.VarChar).Value = licenseagreement.Trim();

            if (leaseyears.ToString().Trim() == "" || leaseyears.ToString().Trim() == null)
                com.Parameters.Add("@leaseyears", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@leaseyears", SqlDbType.VarChar).Value = leaseyears.Trim();

            if (AuthorisedAgent.ToString().Trim() == "" || AuthorisedAgent.ToString().Trim() == null)
                com.Parameters.Add("@AuthorisedAgent", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AuthorisedAgent", SqlDbType.VarChar).Value = AuthorisedAgent.Trim();

            if (AuthorisedAgentName.ToString().Trim() == "" || AuthorisedAgentName.ToString().Trim() == null)
                com.Parameters.Add("@AuthorisedAgentName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AuthorisedAgentName", SqlDbType.VarChar).Value = AuthorisedAgentName.Trim();



            if (architectno.ToString().Trim() == "" || architectno.ToString().Trim() == null)
                com.Parameters.Add("@architectno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@architectno", SqlDbType.VarChar).Value = architectno.Trim();

            if (Architectname.ToString().Trim() == "" || Architectname.ToString().Trim() == null)
                com.Parameters.Add("@Architectname", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Architectname", SqlDbType.VarChar).Value = Architectname.Trim();


            if (architectaddress.ToString().Trim() == "" || architectaddress.ToString().Trim() == null)
                com.Parameters.Add("@architectaddress", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@architectaddress", SqlDbType.VarChar).Value = architectaddress.Trim();

            //if (architectaddress.ToString().Trim() == "" || architectaddress.ToString().Trim() == null)
            //    com.Parameters.Add("@architectaddress", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@architectaddress", SqlDbType.VarChar).Value = architectaddress.Trim();

            if (Engineername.ToString().Trim() == "" || Engineername.ToString().Trim() == null)
                com.Parameters.Add("@Engineername", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Engineername", SqlDbType.VarChar).Value = Engineername.Trim();


            if (Engineerlicesenceno.ToString().Trim() == "" || Engineerlicesenceno.ToString().Trim() == null)
                com.Parameters.Add("@Engineerlicesenceno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Engineerlicesenceno", SqlDbType.VarChar).Value = Engineerlicesenceno.Trim();

            if (Engineeraddress.ToString().Trim() == "" || Engineeraddress.ToString().Trim() == null)
                com.Parameters.Add("@Engineeraddress", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Engineeraddress", SqlDbType.VarChar).Value = Engineeraddress.Trim();

            if (Surveyorname.ToString().Trim() == "" || Surveyorname.ToString().Trim() == null)
                com.Parameters.Add("@Surveyorname", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Surveyorname", SqlDbType.VarChar).Value = Surveyorname.Trim();


            if (Surveyorno.ToString().Trim() == "" || Surveyorno.ToString().Trim() == null)
                com.Parameters.Add("@Surveyorno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Surveyorno", SqlDbType.VarChar).Value = Surveyorno.Trim();


            if (Surveyoraddress.ToString().Trim() == "" || Surveyoraddress.ToString().Trim() == null)
                com.Parameters.Add("@Surveyoraddress", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Surveyoraddress", SqlDbType.VarChar).Value = Surveyoraddress.Trim();

            if (Structuralengneer.ToString().Trim() == "" || Structuralengneer.ToString().Trim() == null)
                com.Parameters.Add("@Structuralengneer", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Structuralengneer", SqlDbType.VarChar).Value = Structuralengneer.Trim();


            if (Structuralengneerlicno.ToString().Trim() == "" || Structuralengneerlicno.ToString().Trim() == null)
                com.Parameters.Add("@Structuralengneerlicno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Structuralengneerlicno", SqlDbType.VarChar).Value = Structuralengneerlicno.Trim();

            if (mobiletowerid.ToString().Trim() == "" || mobiletowerid.ToString().Trim() == null)
                com.Parameters.Add("@mobiletowerid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@mobiletowerid", SqlDbType.VarChar).Value = mobiletowerid.Trim();

            if (Created_by.ToString().Trim() == "" || Created_by.ToString().Trim() == null)
                com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

            com.Parameters.Add("@Valid", SqlDbType.Int, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            mobileid = (Int32)com.Parameters["@Valid"].Value;


            if (mobileid > 0)
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

    public int InsertImagedatamobiletower(string intQuessionaireid, string intCFEid, string FileType, string FilePath, string FileName, string FileDescription,
   string bu, string Created_by, string Created_dt, string UCODE)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertImagemobileTower", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }


            if (intCFEid.Trim() == "" || intCFEid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = Int32.Parse(intCFEid.Trim());
            }



            if (FileType.Trim() == "" || FileType.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = FileType.Trim();
            }

            if (FilePath.Trim() == "" || FilePath.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath.Trim();
            }

            if (FileName.Trim() == "" || FileName.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName.Trim();
            }

            if (FileDescription.Trim() == "" || FileDescription.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }

            if (bu.Trim() == "" || bu.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = bu.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }

            if (Created_dt.Trim() == "" || Created_dt.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = Created_dt.Trim();
            }


            if (UCODE.Trim() == "" || UCODE.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@UCODE", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@UCODE", SqlDbType.VarChar).Value = UCODE.Trim();
            }

            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
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

    }

    public DataSet GetMobileTowerAppIDbyuserid(int UserID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("MT_GetMobileTowerAppIDbyuserid", con.GetConnection);
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

    public DataSet GetShowApprovalandFees_MobileTower(string MobileTowerID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("MT_GetShowApprovalandFees_MobileTower", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (MobileTowerID.Trim() == "" || MobileTowerID.Trim() == null)
                da.SelectCommand.Parameters.Add("@mobiletowerid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@mobiletowerid", SqlDbType.VarChar).Value = MobileTowerID.ToString();
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


    public DataSet GetMobileTowerPayDetailsAddtionalPayment(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("MT_GetMobileTowerPayDetails_AddtionalPayment", con.GetConnection);
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

    public int UpdateUIDMobileTower(string UID_no, string intQuessionaireid)
    {
        int valid = 0;

        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("MT_UpdateUIDMobileTower", con.GetConnection);
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

    public int insertDepartmentAprroval_MobileTower(string intQuessionaireid, string intDeptid, string intApprovalid, string Approval_Fee, string IsPayment, string Created_by, string IsOffline)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insDepartmentApprovals_MobileTower";

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

    public DataSet getMobileTowerdatabyQues(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("MT_getMobileTowerdatabyQues", con.GetConnection);
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

    public int InsertPaymentBillDesk_MobileTower(string UidNo, string intCFEEnterpid, string OnlineOrderNo, string intDeptid, string Online_Amount, string Created_by, string intApprovalid, string ApplType, string AdditionalPayment)
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