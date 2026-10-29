using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class UI_TSiPASS_frmsign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string oath = Convert.ToString(ConfigurationManager.AppSettings["PANCertificatename"]);
            string password = Convert.ToString(ConfigurationManager.AppSettings["PANFXPassword"]);
            GetPANRequest(oath);
            // Load the certificate from the .pfx file with the correct password
            X509Certificate2 certificate = new X509Certificate2(oath, password);

            // Create content to be signed
            byte[] data = Encoding.UTF8.GetBytes("Sample data to sign.");
            ContentInfo contentInfo = new ContentInfo(data);

            // Create a signer
            CmsSigner signer = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, certificate);

            // Create a SignedCms object
            SignedCms signedCms = new SignedCms(contentInfo, detached: true);

            // Compute the signature
            signedCms.ComputeSignature(signer);

            // Encode the SignedCms object
            byte[] signedData = signedCms.Encode();
            string signature = Convert.ToBase64String(signedData);
            GetPANRequest(signature);
            // Verify the signature (optional)
            //signedCms.CheckSignature(true);

        }
        catch (CryptographicException ex)
        {
            GetPANRequest("CryptographicException");
            GetPANRequest(ex.Message);
        }
        catch (Exception ex)
        {
            GetPANRequest(ex.Message);
        }
    }

    public void GetPANRequest(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_PANREQUEST", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@Online", SqlDbType.VarChar).Value = "Online";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
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