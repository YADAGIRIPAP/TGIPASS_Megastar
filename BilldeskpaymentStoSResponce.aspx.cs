using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BilldeskpaymentStoSResponce : System.Web.UI.Page
{
    General objgen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Request.Form["msg"] != null)
                {
                    string BilldeskResponse = Request.Form["msg"];
                    try
                    {
                        //string msg = "COITS|Bill20170429110241|ICIT5328013130|498871-002887|2.00|CIT|516640|03|INR|DIRECT|NA|NA|00000000.00|29-04-2017 11:04:39|0300|NA|4714|MEG01800494415|CFO|NODEPT|txtadditional5| txtadditional6| txtadditional7|NA|Success|58BB0DF9AC4FA97402AF8341DBFFB539594629D3C7C34BEFCEECFD8B082AD697";
                        UpdatechildRecords(BilldeskResponse);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            // LogErrorToText(ex);
        }
    }

    public int UpdatechildRecords(string Response)
    {
        int valid = 0;
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Response",SqlDbType.VarChar),
              
               new SqlParameter("@Outresponse",SqlDbType.VarChar)
           };
            pp[0].Value = Response;
            pp[1].Value = "0";
            pp[1].Direction = ParameterDirection.Output;

            valid = objgen.GenericExecuteNonQuery("USP_UPDATE_BILLDESKCHILDPAMENT_DTLS", pp);
            //return valid;
        }
        catch (Exception ex)
        {

        }
        return valid;
    }
}