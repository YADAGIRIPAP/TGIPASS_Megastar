using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cls_NSWSDashboard
/// </summary>
public class Cls_NSWSDashboard
{
    DB.DB con = new DB.DB();
    public Cls_NSWSDashboard()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int InsertNSWSDashboardResponseOutput(CompanyInfo CompanyVO)
    {
        int valid = 0;
        con.OpenConnection();
        SqlCommand cmd = null;
        try
        {
            cmd = new SqlCommand("USP_INSERT_NSWSDASHBOARD", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PanNumber", Convert.ToString(CompanyVO.PanNumber));
            cmd.Parameters.AddWithValue("@NameAsPerPan", Convert.ToString(CompanyVO.NameAsPerPan));
            cmd.Parameters.AddWithValue("@GstIn", Convert.ToString(CompanyVO.GstIn));
            cmd.Parameters.AddWithValue("@CinNumber", CompanyVO.CinNumber);
            cmd.Parameters.AddWithValue("@SwsId", CompanyVO.SwsId);
            cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
            cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            valid = (Int32)cmd.Parameters["@Valid"].Value;

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
    public int UpdateAckNSWSDashboard(string SWSID, string PANNO, string AckStatusCode, string AckMsg, string AckResponse, string Valid)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPD_NSWSDASHBOARD_ACKNOWLEDGEMENT";

        if (SWSID == "" || SWSID == null)
            com.Parameters.Add("@SWSID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@SWSID", SqlDbType.VarChar).Value = SWSID.Trim();

        if (PANNO == "" || PANNO == null)
            com.Parameters.Add("@PANNO", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PANNO", SqlDbType.VarChar).Value = PANNO.Trim();

        if (AckStatusCode == "" || AckStatusCode == null)
            com.Parameters.Add("@AckStatusCode", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AckStatusCode", SqlDbType.VarChar).Value = AckStatusCode.Trim();

        if (AckResponse == "" || AckResponse == null)
            com.Parameters.Add("@AckResponse", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AckResponse", SqlDbType.VarChar).Value = AckResponse.Trim();

        if (AckMsg == "" || AckMsg == null)
            com.Parameters.Add("@AckMsg", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AckMsg", SqlDbType.VarChar).Value = AckMsg.Trim();

        if (Valid == "" || Valid == null)
            com.Parameters.Add("@Valid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Valid", SqlDbType.VarChar).Value = Valid.Trim();

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

    public DataSet GetNSWSDashboardUsers()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_NSWSDASHBOARDUSERS", con.GetConnection);
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
}
public class NSWSParams
{
    public string Emailid { get; set; }
    public string Password { get; set; }
}
public class TokenResponse
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("refresh_expires_in")]
    public int RefreshExpiresIn { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    [JsonProperty("not-before-policy")]
    public int NotBeforePolicy { get; set; }

    [JsonProperty("session_state")]
    public string SessionState { get; set; }

    [JsonProperty("scope")]
    public string Scope { get; set; }
}

public class ApiResponse
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public List<CompanyInfo> Data { get; set; }
}

public class CompanyInfo
{
    public string PanNumber { get; set; }
    public string CinNumber { get; set; }
    public string SwsId { get; set; }
    public string NameAsPerPan { get; set; }
    public string GstIn { get; set; }
}
public class Approval
{
    public string addressOfTheBranch { get; set; }
    public string appliedOn { get; set; }
    public string approvalCertificate { get; set; }
    public string approvalDate { get; set; }
    public string approvalName { get; set; }
    public string approvalStatus { get; set; }
    public string approvalSubStatus { get; set; }
    public string branchName { get; set; }
    public string branchPinCode { get; set; }
    public string licenseCertificateNumber { get; set; }
    public string licenseId { get; set; }
    public string stateId { get; set; }
    public string swsId { get; set; }

}
public class UpdateLicenseStatus
{
    public string approvalCertificate { get; set; }
    public string approvalStatus { get; set; }
    public string approvalSubStatus { get; set; }
    public string licenseReqId { get; set; }
}
public class PushDocument
{
    public string documentId { get; set; }
    public string documentName { get; set; }
    public string approvalId { get; set; }
    public string swsId { get; set; }
    public string investorReqId { get; set; }
    public string mnstryDprtmntId { get; set; }
}
