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
using System.Xml;
using System.Xml.Linq;

/// <summary>
/// Summary description for GrievanceService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class GrievanceService : System.Web.Services.WebService
{

    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable dt;
    SqlDataAdapter myDataAdapter;
    comFunctions cmf = new comFunctions();
    General genogj = new General();

    public GrievanceService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //[WebMethod]
    //public string HelloWorld()
    //{
    //    return "Hello World";
    //}

    [WebMethod]
    public string updateGrievanceStatus(string Grievanceid, string Status, string Remarks, string Createdby,string QueryReplyFilePath, string QueryReplyFileType, string QueryReplyFileName, string ForwardTo,  string ForwardToMailId)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            if (Status == "")
            {
                dr = dt.NewRow();
                dr[0] = "5";
                dr[1] = "Please Enter Status";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (Grievanceid == "")
            {
                dr = dt.NewRow();
                dr[0] = "6";
                dr[1] = "Please Enter Grievance ID";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (Status == "Redressed")//|| ddlStatus.SelectedValue.ToString()=="9"
            {
                if (Remarks == "")
                {
                    dr = dt.NewRow();
                    dr[0] = "1";
                    dr[1] = "Please Enter Remarks";
                    dt.Rows.Add(dr);
                    valid = 1;
                }
            }
            if (Status == "Reject")
            {
                if (QueryReplyFilePath == "")
                {
                    dr = dt.NewRow();
                    dr[0] = "2";
                    dr[1] = "Please Enter File Path";
                    dt.Rows.Add(dr);
                    valid = 1;
                }
                if (QueryReplyFileType == "")
                {
                    dr = dt.NewRow();
                    dr[0] = "3";
                    dr[1] = "Please Enter File Type";
                    dt.Rows.Add(dr);
                    valid = 1;
                }
                if (QueryReplyFileName == "")
                {
                    dr = dt.NewRow();
                    dr[0] = "4";
                    dr[1] = "Please Enter File Name";
                    dt.Rows.Add(dr);
                    valid = 1;
                }
            }

            if (valid == 0)
            {
                // 1 –additional docs,2-additional payment,3-others
                int k = InsGrievStaus(Grievanceid, Status, Remarks, Createdby, QueryReplyFilePath, QueryReplyFileType, QueryReplyFileName, ForwardTo, ForwardToMailId);


            }

            if (valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "0";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
                //if (intStageid == "16")
                //{
                //    if (Query_Raised_Text == "")
                //    {
                //        dr = dt.NewRow();
                //        dr[0] = "2";
                //        dr[1] = "Please Enter Reason For Rejection";
                //        dt.Rows.Add(dr);
                //    }
                //}
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int InsGrievStaus(string intGrievanceid, string Status, string Remarks, string Created_by, string QueryReply_File_Path, string QueryReply_File_Type, string QueryReply_FileName, string ForwardTo, string ForwardToMailId)
    {
        int value = 0;
        try
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("InsGrievStaus_Websrv", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            if (intGrievanceid.Trim() == "" || intGrievanceid.Trim() == null)
                cmd.Parameters.Add("@intGrievanceid", SqlDbType.VarChar).Value = intGrievanceid.Trim();
            else
                cmd.Parameters.Add("@intGrievanceid", SqlDbType.VarChar).Value = intGrievanceid.Trim();

            if (Status.Trim() == "" || Status == null)
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();

            if (Remarks.Trim() == "" || Remarks.Trim() == null)
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks.Trim();
            else
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks.Trim();

            if (Created_by.Trim() == "" || Created_by.Trim() == null)
                cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

            if (ForwardTo.Trim() == "" || ForwardTo.Trim() == null)
                cmd.Parameters.Add("@ForwardTo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ForwardTo", SqlDbType.VarChar).Value = ForwardTo.Trim();

            if (QueryReply_File_Path != null && QueryReply_File_Path != "")
                cmd.Parameters.Add("@QueryReply_File_Path", SqlDbType.VarChar).Value = QueryReply_File_Path.Trim();

            if (QueryReply_File_Type != null && QueryReply_File_Type != "")
                cmd.Parameters.Add("@QueryReply_File_Type", SqlDbType.VarChar).Value = QueryReply_File_Type.Trim();

            if (QueryReply_FileName != null && QueryReply_FileName != "")
                cmd.Parameters.Add("@QueryReply_FileName", SqlDbType.VarChar).Value = QueryReply_FileName.Trim();

            if (ForwardToMailId != null && ForwardToMailId != "")
                cmd.Parameters.Add("@ForwardToMailId", SqlDbType.VarChar).Value = ForwardToMailId.Trim();

            return Convert.ToInt32(cmd.ExecuteScalar());
            con.CloseConnection();
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        return value;
    }

}
