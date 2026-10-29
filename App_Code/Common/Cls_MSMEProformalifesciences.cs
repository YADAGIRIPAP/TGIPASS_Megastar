using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Cls_MSMEProformalifesciences
/// </summary>
public class Cls_MSMEProformalifesciences
{
    string strConnectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

    //public Cls_MSMEProformalifesciences()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}


    public DataSet getmsmeunitsbydistrictforproformalplds(string DistrictID,string Category,string fromdate, string todate)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("msme_getmsmeunitsbydistrictforproformalplds", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DistrictID.Trim() == "" || DistrictID.Trim() == null)
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DistrictID.ToString();
            if (Category.Trim() == "" || Category.Trim() == null)
                da.SelectCommand.Parameters.Add("@Category", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Category", SqlDbType.VarChar).Value = Category.ToString();
            if (fromdate.Trim() == "" || fromdate.Trim() == null)
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = fromdate.ToString();
            if (todate.Trim() == "" || todate.Trim() == null)
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = todate.ToString();
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

    #region Master    
    public DataTable DB_PDLSLegalStatusOfOrgMaster()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("MSME_PDLSLegalStatusOfOrgMaster", con);
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
            con.Close();
        }
    }
    public DataTable DB_PDLSOrganizationtypeMaster()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("MSME_PDLSOrganizationtypeMaster", con);
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
            con.Close();
        }
    }
    public DataTable DB_PDLSFocusSectorMaster()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("MSME_PDLSFocusSectorMaster", con);
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
            con.Close();
        }
    }
    public DataTable DB_PDLSCoreCapabilitiesmaster()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("MSME_PDLSCoreCapabilitiesmaster", con);
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
            con.Close();
        }
    }
    public DataTable DB_PDLSGlobalPartnershipMaster()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("MSME_PDLSGlobalPartnershipMaster", con);
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
            con.Close();
        }
    }

    #endregion

    #region getdetails
    public DataSet getdetailsproformaofdirectorlifesciencesbymsmeno(string MSMENO)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("MSME_getdetailsproformaofdirectorlifesciencesbymsmeno", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (MSMENO.Trim() == "" || MSMENO.Trim() == null)
                da.SelectCommand.Parameters.Add("@MSMENO", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MSMENO", SqlDbType.VarChar).Value = MSMENO.ToString();
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


    #endregion

    #region Insert applicant details
    public string insertupdatemsmeproformaofdirectorlifesciences(msmeproformalifesciencesproperties obj_msmeproformapro)
    {
        int valid = 0;
        string resp = "";
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        SqlCommand com = new SqlCommand("msme_insertupdatemsmeproformaofdirectorlifesciences", connection);
        com.CommandType = CommandType.StoredProcedure;
        com.Transaction = transaction;
        try
        {
          
            if (obj_msmeproformapro.PDLSID == null)
            {
                com.Parameters.Add("@PDLSID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@PDLSID", SqlDbType.VarChar).Value = obj_msmeproformapro.PDLSID;
            }
            if (obj_msmeproformapro.MSMENO == null)
            {
                com.Parameters.Add("@MSMENO", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@MSMENO", SqlDbType.VarChar).Value = obj_msmeproformapro.MSMENO;
            }
            if (obj_msmeproformapro.Createdby == "" || obj_msmeproformapro.Createdby == null)
            {
                com.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = obj_msmeproformapro.Createdby.Trim();
            }
            if (obj_msmeproformapro.CreatedIP == "" || obj_msmeproformapro.CreatedIP == null)
            {
                com.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = obj_msmeproformapro.CreatedIP.Trim();
            }
            if (obj_msmeproformapro.Organizationname == "" || obj_msmeproformapro.Organizationname == null)
            {
                com.Parameters.Add("@Organizationname", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Organizationname", SqlDbType.VarChar).Value = obj_msmeproformapro.Organizationname.Trim();
            }
            if (obj_msmeproformapro.Telephonenumber == "" || obj_msmeproformapro.Telephonenumber == null)
            {
                com.Parameters.Add("@Telephonenumber", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Telephonenumber", SqlDbType.VarChar).Value = obj_msmeproformapro.Telephonenumber.Trim();
            }
            if (obj_msmeproformapro.fax == "" || obj_msmeproformapro.fax == null)
            {
                com.Parameters.Add("@fax", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@fax", SqlDbType.VarChar).Value = obj_msmeproformapro.fax.Trim();
            }
            if (obj_msmeproformapro.website == "" || obj_msmeproformapro.website == null)
            {
                com.Parameters.Add("@website", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@website", SqlDbType.VarChar).Value = obj_msmeproformapro.website.Trim();
            }
            if (obj_msmeproformapro.yearofest == null)
            {
                com.Parameters.Add("@yearofest", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@yearofest", SqlDbType.VarChar).Value = obj_msmeproformapro.yearofest;
            }

            if (obj_msmeproformapro.noofemptot == null)
            {
                com.Parameters.Add("@noofemptot", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@noofemptot", SqlDbType.VarChar).Value = obj_msmeproformapro.noofemptot;
            }
            if (obj_msmeproformapro.noofempintelangana == null)
            {
                com.Parameters.Add("@noofempintelangana", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@noofempintelangana", SqlDbType.VarChar).Value = obj_msmeproformapro.noofempintelangana;
            }
            if (obj_msmeproformapro.scirntificworkforce == "" || obj_msmeproformapro.scirntificworkforce == null)
            {
                com.Parameters.Add("@scirntificworkforce", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@scirntificworkforce", SqlDbType.VarChar).Value = obj_msmeproformapro.scirntificworkforce.Trim();
            }
            if (obj_msmeproformapro.headquarteraddress == "" || obj_msmeproformapro.headquarteraddress == null)
            {
                com.Parameters.Add("@headquarteraddress", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@headquarteraddress", SqlDbType.VarChar).Value = obj_msmeproformapro.headquarteraddress.Trim();
            }
            if (obj_msmeproformapro.headquarterpincode == "" || obj_msmeproformapro.headquarterpincode == null)
            {
                com.Parameters.Add("@headquarterpincode", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@headquarterpincode", SqlDbType.VarChar).Value = obj_msmeproformapro.headquarterpincode.Trim();
            }
            if (obj_msmeproformapro.plantaddress1 == "" || obj_msmeproformapro.plantaddress1 == null)
            {
                com.Parameters.Add("@plantaddress1", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@plantaddress1", SqlDbType.VarChar).Value = obj_msmeproformapro.plantaddress1.Trim();
            }
            if (obj_msmeproformapro.plantaddress1pincode == "" || obj_msmeproformapro.plantaddress1pincode == null)
            {
                com.Parameters.Add("@plantaddress1pincode", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@plantaddress1pincode", SqlDbType.VarChar).Value = obj_msmeproformapro.plantaddress1pincode.Trim();
            }
            if (obj_msmeproformapro.plantaddress2 == "" || obj_msmeproformapro.plantaddress2 == null)
            {
                com.Parameters.Add("@plantaddress2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@plantaddress2", SqlDbType.VarChar).Value = obj_msmeproformapro.plantaddress2.Trim();
            }
            if (obj_msmeproformapro.plantaddress2pincode == "" || obj_msmeproformapro.plantaddress2pincode == null)
            {
                com.Parameters.Add("@plantaddress2pincode", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@plantaddress2pincode", SqlDbType.VarChar).Value = obj_msmeproformapro.plantaddress2pincode.Trim();
            }
            if (obj_msmeproformapro.plantaddress3 == "" || obj_msmeproformapro.plantaddress3 == null)
            {
                com.Parameters.Add("@plantaddress3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@plantaddress3", SqlDbType.VarChar).Value = obj_msmeproformapro.plantaddress3.Trim();
            }
            if (obj_msmeproformapro.plantaddress3pincode == "" || obj_msmeproformapro.plantaddress3pincode == null)
            {
                com.Parameters.Add("@plantaddress3pincode", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@plantaddress3pincode", SqlDbType.VarChar).Value = obj_msmeproformapro.plantaddress3pincode.Trim();
            }
            if (obj_msmeproformapro.additionaladdresses == "" || obj_msmeproformapro.additionaladdresses == null)
            {
                com.Parameters.Add("@additionaladdresses", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@additionaladdresses", SqlDbType.VarChar).Value = obj_msmeproformapro.additionaladdresses.Trim();
            }
            if (obj_msmeproformapro.senleadercontactnname1 == "" || obj_msmeproformapro.senleadercontactnname1 == null)
            {
                com.Parameters.Add("@senleadercontactnname1", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@senleadercontactnname1", SqlDbType.VarChar).Value = obj_msmeproformapro.senleadercontactnname1.Trim();
            }
            if (obj_msmeproformapro.senleadercontactndesignation1 == "" || obj_msmeproformapro.senleadercontactndesignation1 == null)
            {
                com.Parameters.Add("@senleadercontactndesignation1", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@senleadercontactndesignation1", SqlDbType.VarChar).Value = obj_msmeproformapro.senleadercontactndesignation1.Trim();
            }
            if (obj_msmeproformapro.senleadercontactmobileno1 == "" || obj_msmeproformapro.senleadercontactmobileno1 == null)
            {
                com.Parameters.Add("@senleadercontactmobileno1", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@senleadercontactmobileno1", SqlDbType.VarChar).Value = obj_msmeproformapro.senleadercontactmobileno1.Trim();
            }
            if (obj_msmeproformapro.senleadercontactemailid1 == "" || obj_msmeproformapro.senleadercontactemailid1 == null)
            {
                com.Parameters.Add("@senleadercontactemailid1", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@senleadercontactemailid1", SqlDbType.VarChar).Value = obj_msmeproformapro.senleadercontactemailid1.Trim();
            }
            if (obj_msmeproformapro.senleadercontactnname2 == "" || obj_msmeproformapro.senleadercontactnname2 == null)
            {
                com.Parameters.Add("@senleadercontactnname2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@senleadercontactnname2", SqlDbType.VarChar).Value = obj_msmeproformapro.senleadercontactnname2.Trim();
            }
            if (obj_msmeproformapro.senleadercontactndesignation2 == "" || obj_msmeproformapro.senleadercontactndesignation2 == null)
            {
                com.Parameters.Add("@senleadercontactndesignation2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@senleadercontactndesignation2", SqlDbType.VarChar).Value = obj_msmeproformapro.senleadercontactndesignation2.Trim();
            }
            if (obj_msmeproformapro.senleadercontactmobileno2 == "" || obj_msmeproformapro.senleadercontactmobileno2 == null)
            {
                com.Parameters.Add("@senleadercontactmobileno2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@senleadercontactmobileno2", SqlDbType.VarChar).Value = obj_msmeproformapro.senleadercontactmobileno2.Trim();
            }
            if (obj_msmeproformapro.senleadercontactemailid2 == "" || obj_msmeproformapro.senleadercontactemailid2 == null)
            {
                com.Parameters.Add("@senleadercontactemailid2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@senleadercontactemailid2 ", SqlDbType.VarChar).Value = obj_msmeproformapro.senleadercontactemailid2.Trim();
            }
            if (obj_msmeproformapro.senleadercontactnname3 == "" || obj_msmeproformapro.senleadercontactnname3 == null)
            {
                com.Parameters.Add("@senleadercontactnname3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@senleadercontactnname3", SqlDbType.VarChar).Value = obj_msmeproformapro.senleadercontactnname3.Trim();
            }
            if (obj_msmeproformapro.senleadercontactndesignation3 == "" || obj_msmeproformapro.senleadercontactndesignation3 == null)
            {
                com.Parameters.Add("@senleadercontactndesignation3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@senleadercontactndesignation3", SqlDbType.VarChar).Value = obj_msmeproformapro.senleadercontactndesignation3.Trim();
            }
            if (obj_msmeproformapro.senleadercontactmobileno3 == "" || obj_msmeproformapro.senleadercontactmobileno3 == null)
            {
                com.Parameters.Add("@senleadercontactmobileno3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@senleadercontactmobileno3", SqlDbType.VarChar).Value = obj_msmeproformapro.senleadercontactmobileno3.Trim();
            }
            if (obj_msmeproformapro.senleadercontactemailid3 == "" || obj_msmeproformapro.senleadercontactemailid3 == null)
            {
                com.Parameters.Add("@senleadercontactemailid3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@senleadercontactemailid3", SqlDbType.VarChar).Value = obj_msmeproformapro.senleadercontactemailid3.Trim();
            }
            if (obj_msmeproformapro.Contactpersonname == "" || obj_msmeproformapro.Contactpersonname == null)
            {
                com.Parameters.Add("@Contactpersonname", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Contactpersonname", SqlDbType.VarChar).Value = obj_msmeproformapro.Contactpersonname.Trim();
            }
            if (obj_msmeproformapro.Contactpersondesignation == "" || obj_msmeproformapro.Contactpersondesignation == null)
            {
                com.Parameters.Add("@Contactpersondesignation", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Contactpersondesignation", SqlDbType.VarChar).Value = obj_msmeproformapro.Contactpersondesignation.Trim();
            }
            if (obj_msmeproformapro.Contactpersonmobileo == "" || obj_msmeproformapro.Contactpersonmobileo == null)
            {
                com.Parameters.Add("@Contactpersonmobileo", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Contactpersonmobileo", SqlDbType.VarChar).Value = obj_msmeproformapro.Contactpersonmobileo.Trim();
            }
            if (obj_msmeproformapro.Contactpersonemailid == "" || obj_msmeproformapro.Contactpersonemailid == null)
            {
                com.Parameters.Add("@Contactpersonemailid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Contactpersonemailid", SqlDbType.VarChar).Value = obj_msmeproformapro.Contactpersonemailid.Trim();
            }
            if (obj_msmeproformapro.finicalyear1turnoverincr == null)
            {
                com.Parameters.Add("@finicalyear1turnoverincr", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@finicalyear1turnoverincr", SqlDbType.VarChar).Value = obj_msmeproformapro.finicalyear1turnoverincr;
            }
            if (obj_msmeproformapro.finicalyear2turnoverincr == null)
            {
                com.Parameters.Add("@finicalyear2turnoverincr", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@finicalyear2turnoverincr", SqlDbType.VarChar).Value = obj_msmeproformapro.finicalyear2turnoverincr;
            }

            if (obj_msmeproformapro.finicalyear3turnoverincr == null)
            {
                com.Parameters.Add("@finicalyear3turnoverincr", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@finicalyear3turnoverincr", SqlDbType.VarChar).Value = obj_msmeproformapro.finicalyear3turnoverincr;

            }
            if (obj_msmeproformapro.IsregisteredinmsmeID == "" || obj_msmeproformapro.IsregisteredinmsmeID == null)
            {
                com.Parameters.Add("@IsregisteredinmsmeID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@IsregisteredinmsmeID", SqlDbType.VarChar).Value = obj_msmeproformapro.IsregisteredinmsmeID.Trim();
            }
            if (obj_msmeproformapro.Isregisteredinmsmename == "" || obj_msmeproformapro.Isregisteredinmsmename == null)
            {
                com.Parameters.Add("@Isregisteredinmsmename", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Isregisteredinmsmename", SqlDbType.VarChar).Value = obj_msmeproformapro.Isregisteredinmsmename.Trim();
            }
            if (obj_msmeproformapro.udyogaadharnumber == "" || obj_msmeproformapro.udyogaadharnumber == null)
            {
                com.Parameters.Add("@udyogaadharnumber", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@udyogaadharnumber", SqlDbType.VarChar).Value = obj_msmeproformapro.udyogaadharnumber.Trim();
            }
            if (obj_msmeproformapro.legalstatusoforgid == null)
            {
                com.Parameters.Add("@legalstatusoforgid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@legalstatusoforgid", SqlDbType.VarChar).Value = obj_msmeproformapro.legalstatusoforgid;
            }
            if (obj_msmeproformapro.legalstatusoforgname == "" || obj_msmeproformapro.legalstatusoforgname == null)
            {
                com.Parameters.Add("@legalstatusoforgname", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@legalstatusoforgname", SqlDbType.VarChar).Value = obj_msmeproformapro.legalstatusoforgname.Trim();
            }
            if (obj_msmeproformapro.fsorganizationtypeid == null)
            {
                com.Parameters.Add("@fsorganizationtypeid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@fsorganizationtypeid", SqlDbType.VarChar).Value = obj_msmeproformapro.fsorganizationtypeid;
            }
            if (obj_msmeproformapro.fsorganizationtypename == "" || obj_msmeproformapro.fsorganizationtypename == null)
            {
                com.Parameters.Add("@fsorganizationtypename", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@fsorganizationtypename", SqlDbType.VarChar).Value = obj_msmeproformapro.fsorganizationtypename.Trim();
            }
            if (obj_msmeproformapro.fsfocussectorid == null)
            {
                com.Parameters.Add("@fsfocussectorid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@fsfocussectorid", SqlDbType.VarChar).Value = obj_msmeproformapro.fsfocussectorid;
            }
            if (obj_msmeproformapro.fsfocussectorname == "" || obj_msmeproformapro.fsfocussectorname == null)
            {
                com.Parameters.Add("@fsfocussectorname", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@fsfocussectorname", SqlDbType.VarChar).Value = obj_msmeproformapro.fsfocussectorname.Trim();
            }
            if (obj_msmeproformapro.fssubsectordefine == "" || obj_msmeproformapro.fssubsectordefine == null)
            {
                com.Parameters.Add("@fssubsectordefine", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@fssubsectordefine", SqlDbType.VarChar).Value = obj_msmeproformapro.fssubsectordefine.Trim();
            }
            if (obj_msmeproformapro.rdfocustherapeuticareas == "" || obj_msmeproformapro.rdfocustherapeuticareas == null)
            {
                com.Parameters.Add("@rdfocustherapeuticareas", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@rdfocustherapeuticareas", SqlDbType.VarChar).Value = obj_msmeproformapro.rdfocustherapeuticareas.Trim();
            }
            if (obj_msmeproformapro.rdcroservices == "" || obj_msmeproformapro.rdcroservices == null)
            {
                com.Parameters.Add("@rdcroservices", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@rdcroservices", SqlDbType.VarChar).Value = obj_msmeproformapro.rdcroservices.Trim();
            }
            if (obj_msmeproformapro.rdocrocapabilities == "" || obj_msmeproformapro.rdocrocapabilities == null)
            {
                com.Parameters.Add("@rdocrocapabilities", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@rdocrocapabilities", SqlDbType.VarChar).Value = obj_msmeproformapro.rdocrocapabilities.Trim();
            }
            if (obj_msmeproformapro.manfservicmareaoffocus == "" || obj_msmeproformapro.manfservicmareaoffocus == null)
            {
                com.Parameters.Add("@manfservicmareaoffocus", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@manfservicmareaoffocus", SqlDbType.VarChar).Value = obj_msmeproformapro.manfservicmareaoffocus.Trim();
            }
            if (obj_msmeproformapro.manfservicmcapacity == "" || obj_msmeproformapro.manfservicmcapacity == null)
            {
                com.Parameters.Add("@manfservicmcapacity", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@manfservicmcapacity", SqlDbType.VarChar).Value = obj_msmeproformapro.manfservicmcapacity.Trim();
            }
            if (obj_msmeproformapro.manfservicaccreditationscertificationfdamhra == "" || obj_msmeproformapro.manfservicaccreditationscertificationfdamhra == null)
            {
                com.Parameters.Add("@manfservicaccreditationscertificationfdamhra", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@manfservicaccreditationscertificationfdamhra", SqlDbType.VarChar).Value = obj_msmeproformapro.manfservicaccreditationscertificationfdamhra.Trim();
            }
            if (obj_msmeproformapro.manfservexportvalueincr == null)
            {
                com.Parameters.Add("@manfservexportvalueincr", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@manfservexportvalueincr", SqlDbType.VarChar).Value = obj_msmeproformapro.manfservexportvalueincr;
            }
            if (obj_msmeproformapro.manfservexportvalueintonnes == null)
            {
                com.Parameters.Add("@manfservexportvalueintonnes", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@manfservexportvalueintonnes", SqlDbType.VarChar).Value = obj_msmeproformapro.manfservexportvalueintonnes;
            }
            if (obj_msmeproformapro.manfservcmoservices == "" || obj_msmeproformapro.manfservcmoservices == null)
            {
                com.Parameters.Add("@manfservcmoservices", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@manfservcmoservices", SqlDbType.VarChar).Value = obj_msmeproformapro.manfservcmoservices.Trim();
            }
            if (obj_msmeproformapro.manfservcmocorecapabilitiesID == null)
            {
                com.Parameters.Add("@manfservcmocorecapabilitiesID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@manfservcmocorecapabilitiesID", SqlDbType.VarChar).Value = obj_msmeproformapro.manfservcmocorecapabilitiesID;
            }
            if (obj_msmeproformapro.manfservcmocorecapabilitiesname == "" || obj_msmeproformapro.manfservcmocorecapabilitiesname == null)
            {
                com.Parameters.Add("@manfservcmocorecapabilitiesname", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@manfservcmocorecapabilitiesname", SqlDbType.VarChar).Value = obj_msmeproformapro.manfservcmocorecapabilitiesname.Trim();
            }
            if (obj_msmeproformapro.manfservcmoinfrastructurehighlighrs == "" || obj_msmeproformapro.manfservcmoinfrastructurehighlighrs == null)
            {
                com.Parameters.Add("@manfservcmoinfrastructurehighlighrs", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@manfservcmoinfrastructurehighlighrs", SqlDbType.VarChar).Value = obj_msmeproformapro.manfservcmoinfrastructurehighlighrs.Trim();
            }
            if (obj_msmeproformapro.manfservcmoaccreditationscertifications == "" || obj_msmeproformapro.manfservcmoaccreditationscertifications == null)
            {
                com.Parameters.Add("@manfservcmoaccreditationscertifications", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@manfservcmoaccreditationscertifications", SqlDbType.VarChar).Value = obj_msmeproformapro.manfservcmoaccreditationscertifications.Trim();
            }
            if (obj_msmeproformapro.manfservcmonoofinternationalclient == null)
            {
                com.Parameters.Add("@manfservcmonoofinternationalclient", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@manfservcmonoofinternationalclient", SqlDbType.VarChar).Value = obj_msmeproformapro.manfservcmonoofinternationalclient;
            }
            if (obj_msmeproformapro.listofancillaryexcelfilepath == "" || obj_msmeproformapro.listofancillaryexcelfilepath == null)
            {
                com.Parameters.Add("@listofancillaryexcelfilepath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@listofancillaryexcelfilepath", SqlDbType.VarChar).Value = obj_msmeproformapro.listofancillaryexcelfilepath.Trim();
            }
            if (obj_msmeproformapro.Glopresencecountrynames == "" || obj_msmeproformapro.Glopresencecountrynames == null)
            {
                com.Parameters.Add("@Glopresencecountrynames", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Glopresencecountrynames", SqlDbType.VarChar).Value = obj_msmeproformapro.Glopresencecountrynames.Trim();
            }
            if (obj_msmeproformapro.Glopresencenoofempoutsideindia == null)
            {
                com.Parameters.Add("@Glopresencenoofempoutsideindia", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Glopresencenoofempoutsideindia", SqlDbType.VarChar).Value = obj_msmeproformapro.Glopresencenoofempoutsideindia;
            }
            if (obj_msmeproformapro.Comtrackrecordofferachievements == "" || obj_msmeproformapro.Comtrackrecordofferachievements == null)
            {
                com.Parameters.Add("@Comtrackrecordofferachievements", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Comtrackrecordofferachievements", SqlDbType.VarChar).Value = obj_msmeproformapro.Comtrackrecordofferachievements.Trim();
            }
            if (obj_msmeproformapro.Comtrackrecordglobalparthershipid == null)
            {
                com.Parameters.Add("@Comtrackrecordglobalparthershipid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Comtrackrecordglobalparthershipid ", SqlDbType.VarChar).Value = obj_msmeproformapro.Comtrackrecordglobalparthershipid;
            }
            if (obj_msmeproformapro.Comtrackrecordglobalparthershipname == "" || obj_msmeproformapro.Comtrackrecordglobalparthershipname == null)
            {
                com.Parameters.Add("@Comtrackrecordglobalparthershipname", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Comtrackrecordglobalparthershipname", SqlDbType.VarChar).Value = obj_msmeproformapro.Comtrackrecordglobalparthershipname.Trim();
            }
            if (obj_msmeproformapro.Comtrackrecorddescription == "" || obj_msmeproformapro.Comtrackrecorddescription == null)
            {
                com.Parameters.Add("@Comtrackrecorddescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Comtrackrecorddescription", SqlDbType.VarChar).Value = obj_msmeproformapro.Comtrackrecorddescription.Trim();
            }
            if (obj_msmeproformapro.organizationlogopath == "" || obj_msmeproformapro.organizationlogopath == null)
            {
                com.Parameters.Add("@organizationlogopath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@organizationlogopath", SqlDbType.VarChar).Value = obj_msmeproformapro.organizationlogopath.Trim();
            }
            if (obj_msmeproformapro.Comtrackrecordpolicysuggstategovt == "" || obj_msmeproformapro.Comtrackrecordpolicysuggstategovt == null)
            {
                com.Parameters.Add("@Comtrackrecordpolicysuggstategovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Comtrackrecordpolicysuggstategovt", SqlDbType.VarChar).Value = obj_msmeproformapro.Comtrackrecordpolicysuggstategovt.Trim();
            }
            if (obj_msmeproformapro.isdeclared == null)
            {
                com.Parameters.Add("@isdeclared", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@isdeclared", SqlDbType.VarChar).Value = obj_msmeproformapro.isdeclared;
            }
            com.Parameters.Add("@valid", SqlDbType.Int, 500);
            com.Parameters["@valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            valid = (Int32)com.Parameters["@valid"].Value;
            resp = Convert.ToString(valid);
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            com.Dispose();
            connection.Close();
        }
        return resp;
    }
    #endregion

    #region getdetails
    public DataSet printproformaofdirectorlifesciencesbymsmeno(string MSMENO)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("MSME_printproformaofdirectorlifesciencesbymsmeno", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (MSMENO.Trim() == "" || MSMENO.Trim() == null)
                da.SelectCommand.Parameters.Add("@MSMENO", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MSMENO", SqlDbType.VarChar).Value = MSMENO.ToString();
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


    #endregion

}

public class msmeproformalifesciencesproperties
{

    public int PDLSID { get; set; }
    public int MSMENO { get; set; }
    public bool Isactive { get; set; }
    public DateTime CreatedOn { get; set; }
    public string Createdby { get; set; }
    public string CreatedIP { get; set; }
    public DateTime ModifiedOn { get; set; }
    public string Modifiedby { get; set; }
    public string ModifiedIP { get; set; }
    public string Organizationname { get; set; }
    public string Telephonenumber { get; set; }
    public string fax { get; set; }
    public string website { get; set; }
    public int yearofest { get; set; }
    public int noofemptot { get; set; }
    public int noofempintelangana { get; set; }
    public string scirntificworkforce { get; set; }
    public string headquarteraddress { get; set; }
    public string headquarterpincode { get; set; }
    public string plantaddress1 { get; set; }
    public string plantaddress1pincode { get; set; }
    public string plantaddress2 { get; set; }
    public string plantaddress2pincode { get; set; }
    public string plantaddress3 { get; set; }
    public string plantaddress3pincode { get; set; }
    public string additionaladdresses { get; set; }
    public string senleadercontactnname1 { get; set; }
    public string senleadercontactndesignation1 { get; set; }
    public string senleadercontactmobileno1 { get; set; }
    public string senleadercontactemailid1 { get; set; }
    public string senleadercontactnname2 { get; set; }
    public string senleadercontactndesignation2 { get; set; }
    public string senleadercontactmobileno2 { get; set; }
    public string senleadercontactemailid2 { get; set; }
    public string senleadercontactnname3 { get; set; }
    public string senleadercontactndesignation3 { get; set; }
    public string senleadercontactmobileno3 { get; set; }
    public string senleadercontactemailid3 { get; set; }
    public string Contactpersonname { get; set; }
    public string Contactpersondesignation { get; set; }
    public string Contactpersonmobileo { get; set; }
    public string Contactpersonemailid { get; set; }
    public decimal finicalyear1turnoverincr { get; set; }
    public decimal finicalyear2turnoverincr { get; set; }
    public decimal finicalyear3turnoverincr { get; set; }
    public string IsregisteredinmsmeID { get; set; }
    public string Isregisteredinmsmename { get; set; }
    public string udyogaadharnumber { get; set; }
    public int legalstatusoforgid { get; set; }
    public string legalstatusoforgname { get; set; }
    public int fsorganizationtypeid { get; set; }
    public string fsorganizationtypename { get; set; }
    public int fsfocussectorid { get; set; }
    public string fsfocussectorname { get; set; }
    public string fssubsectordefine { get; set; }
    public string rdfocustherapeuticareas { get; set; }
    public string rdcroservices { get; set; }
    public string rdocrocapabilities { get; set; }
    public string manfservicmareaoffocus { get; set; }
    public string manfservicmcapacity { get; set; }
    public string manfservicaccreditationscertificationfdamhra { get; set; }
    public decimal manfservexportvalueincr { get; set; }
    public decimal manfservexportvalueintonnes { get; set; }
    public string manfservcmoservices { get; set; }
    public int manfservcmocorecapabilitiesID { get; set; }
    public string manfservcmocorecapabilitiesname { get; set; }
    public string manfservcmoinfrastructurehighlighrs { get; set; }
    public string manfservcmoaccreditationscertifications { get; set; }
    public int manfservcmonoofinternationalclient { get; set; }
    public string listofancillaryexcelfilepath { get; set; }
    public string Glopresencecountrynames { get; set; }
    public int Glopresencenoofempoutsideindia { get; set; }
    public string Comtrackrecordofferachievements { get; set; }
    public int Comtrackrecordglobalparthershipid { get; set; }
    public string Comtrackrecordglobalparthershipname { get; set; }
    public string Comtrackrecorddescription { get; set; }
    public string organizationlogopath { get; set; }
    public string Comtrackrecordpolicysuggstategovt { get; set; }
    public bool isdeclared { get; set; }
}