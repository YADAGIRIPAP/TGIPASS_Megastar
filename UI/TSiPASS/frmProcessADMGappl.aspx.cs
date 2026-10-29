using iTextSharp.text.pdf.hyphenation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class UI_TSiPASS_frmProcessADMGappl : System.Web.UI.Page
{
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (Request.QueryString.Count > 0)
        {
            // FillADMGApprovalDetails();
        }
        if (!IsPostBack)
        {
            GetDetails();
        }


    }
    public void GetDetails()
    {
        string ADMGID = Request.QueryString[0].ToString();
        string ID = Request.QueryString[1].ToString();

        DataSet dsn = new DataSet();

        dsn = GetADMGApplDetails(ID, ADMGID);

        if (dsn.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = dsn.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
    public DataSet GetADMGApplDetails(string ID, string ADMGID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        da = new SqlDataAdapter("GetADMGApplDetails_ToProcess", con.GetConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;


        if (ID.Trim() == "" || ID.Trim() == null)
            da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = "%";
        else
            da.SelectCommand.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID.ToString();

        if (ADMGID.Trim() == "" || ADMGID.Trim() == null)
            da.SelectCommand.Parameters.Add("@ADMGID", SqlDbType.VarChar).Value = "%";
        else
            da.SelectCommand.Parameters.Add("@ADMGID", SqlDbType.VarChar).Value = ADMGID.ToString();

        da.Fill(ds);
        return ds;

    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedValue.ToString() == "13")
        {
            trNOC.Visible = true;
            trDGPS.Visible = true;
            trReject.Visible = false;


        }
        if (ddlStatus.SelectedValue.ToString() == "16")
        {
            trReject.Visible = true;
            trNOC.Visible = false;
            trDGPS.Visible = false;
        }
    }


    protected void BTNNOC_Click(object sender, EventArgs e)
    {
        try
        {

            string newPath = "";

            string sFileDir = Server.MapPath("~\\ADMandGATTACHMENTS");


            //General t1 = new General();
            if ((FUPNOC.PostedFile != null) && (FUPNOC.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FUPNOC.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPNOC.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    //if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[1].ToString() + "\\NOC");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FUPNOC.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FUPNOC.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        result = InsertImagedata(Request.QueryString[1].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(),
                            newPath, sFileName, "NOC", "Y", Session["uid"].ToString(), DateTime.Now.ToString());
                        if (result > 0)
                        {

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HYPNOC.Text = FUPNOC.FileName;
                            HYPNOC.Visible = true;
                            LBLNOC.Text = FUPNOC.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;

                        }

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;

                    }
                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        catch (Exception ex)
        {

            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            // DeleteFile(newPath + "\\" + sFileName);
        }

    }

    protected void BTNSignedDGPS_Click(object sender, EventArgs e)
    {
        try
        {

            string newPath = "";

            string sFileDir = Server.MapPath("~\\ADMandGATTACHMENTS");

            if ((FUPSignedDGPS.PostedFile != null) && (FUPSignedDGPS.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FUPSignedDGPS.PostedFile.FileName);
                try
                {
                    string[] fileType = FUPSignedDGPS.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    //if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\SignedDGPSMap");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FUPSignedDGPS.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FUPSignedDGPS.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        result = InsertImagedata(Request.QueryString[1].ToString(), Request.QueryString[0].ToString(),
                            fileType[i - 1].ToUpper(), newPath, sFileName, "SignedDGPS", "Y", Session["uid"].ToString(), DateTime.Now.ToString());
                        if (result > 0)
                        {
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HYPSignedDGPS.Text = FUPSignedDGPS.FileName;
                            HYPSignedDGPS.Visible = true;
                            LBLSignedDGPS.Text = FUPSignedDGPS.FileName;
                            success.Visible = true;
                            Failure.Visible = false;

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;

                        }

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF  files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;

                    }
                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        catch (Exception ex)
        {

            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            // DeleteFile(newPath + "\\" + sFileName);
        }
    }

    public int InsertImagedata(string ID, string ADMGID, string FileType, string FilePath, string FileName, string FileDescription,
   string Approval, string Modified_by, string Modified_dt)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertNOC_ADMandG", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (ID.Trim() == "" || ID.Trim() == null || ID.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(ID.Trim());
            }

            if (ID.Trim() == "" || ID.Trim() == null || ID.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = Int32.Parse(ID.Trim());
            }


            if (ADMGID.Trim() == "" || ADMGID.Trim() == null || ADMGID.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ADM_G_MineralID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ADM_G_MineralID", SqlDbType.VarChar).Value = ADMGID.Trim();
            }


            if (FileType.Trim() == "" || FileType.Trim() == null || FileType.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = FileType.Trim();
            }

            if (FilePath.Trim() == "" || FilePath.Trim() == null || FilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath.Trim();
            }

            if (FileName.Trim() == "" || FileName.Trim() == null || FileName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName.Trim();
            }

            if (FileDescription.Trim() == "" || FileDescription.Trim() == null || FileDescription.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }

            if (Approval.Trim() == "" || Approval.Trim() == null || Approval.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ApprovalAttachment", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ApprovalAttachment", SqlDbType.VarChar).Value = Approval.Trim();
            }

            if (Modified_by.Trim() == "" || Modified_by.Trim() == null || Modified_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = Int32.Parse(Modified_by.Trim());
            }

            if (Modified_dt.Trim() == "" || Modified_dt.Trim() == null || Modified_dt.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_dt", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_dt", SqlDbType.DateTime).Value = Modified_dt.Trim();
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
    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlStatus.SelectedValue.ToString() == "16")
            {
                string RjctReason = txtRjctReasn.Text;
                if (RjctReason != "")
                {
                    int valid = UpdateADMGRejectStatus(Session["uid"].ToString(), Request.QueryString[0].ToString().Trim(), Request.QueryString[1].ToString().Trim(), RjctReason, getclientIP());
                    if (valid == 1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Rejection Status updated Successfully');", true);
                    }
                }

            }
            if (ddlStatus.SelectedValue.ToString() == "13")
            {
                if (HYPSignedDGPS.Text == "" || HYPSignedDGPS.Text == null)
                {
                    lblmsg0.Text = "<font color='red'>Please Upload SignedDGPS in PDF format and Click Upload..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
                else if (HYPNOC.Text == "" || HYPNOC.Text == null)
                {
                    lblmsg0.Text = "<font color='red'>Please Upload NOC in PDF format and Click Upload..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
                else
                {
                    int valid = UpdateADMGApprovalStatus(Session["uid"].ToString(), Request.QueryString[0].ToString().Trim(), Request.QueryString[1].ToString().Trim(), getclientIP(), DateTime.Now.ToString());
                    if (valid >= 1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Completed Successfully');", true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public int UpdateADMGRejectStatus(string createdby, string ADMGID, string ID, String RjctReason, string IPaddress)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlConnection connection = new SqlConnection(str);
        connection.Open();
        int valid = 0;
        SqlTransaction trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("USP_UPDATE_ADMandG_RejectSTATUS", connection);
        command.CommandType = CommandType.StoredProcedure;

        try
        {
            command.Parameters.AddWithValue("@Createdby", createdby);
            command.Parameters.AddWithValue("@ADMGID", ADMGID);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@RjctReason", RjctReason);
            command.Parameters.AddWithValue("@IPaddress", IPaddress);


            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();

        }
        return valid;
    }
    //cmf.convertDateIndia
    public int UpdateADMGApprovalStatus(string createdby, string ADMGID, string ID, string IPaddress, string ApprovalDate)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("USP_UPDATE_ADMGapprovalSTATUS", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (createdby.Trim() == "" || createdby.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@createdby", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@createdby", SqlDbType.Int).Value = Int32.Parse(createdby.Trim());
            }
            if (ID.Trim() == "" || ID.Trim() == null || ID.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = Int32.Parse(ID.Trim());
            }


            if (ADMGID.Trim() == "" || ADMGID.Trim() == null || ADMGID.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ADMGID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ADMGID", SqlDbType.VarChar).Value = ADMGID.Trim();
            }

            if (IPaddress.Trim() == "" || IPaddress.Trim() == null || IPaddress.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@IPaddress", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@IPaddress", SqlDbType.VarChar).Value = IPaddress.Trim();
            }

            if (ApprovalDate.Trim() == "" || ApprovalDate.Trim() == null || ApprovalDate.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ApprovalDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ApprovalDate", SqlDbType.DateTime).Value = ApprovalDate.Trim();
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
        //string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        //SqlConnection connection = new SqlConnection(str);
        //connection.Open();
        //int valid = 0;
        //SqlTransaction trans = connection.BeginTransaction();
        //SqlCommand command = new SqlCommand("USP_UPDATE_ADMGapprovalSTATUS", connection);
        //command.CommandType = CommandType.StoredProcedure;

        //try
        //{
        //    command.Parameters.AddWithValue("@Createdby", createdby);
        //    command.Parameters.AddWithValue("@ADMGID", ADMGID);
        //    command.Parameters.AddWithValue("@ID ", ID);
        //    command.Parameters.AddWithValue("@IPaddress ", IPaddress);
        //    command.Parameters.AddWithValue("@ApprovalDate ", ApprovalDate);


        //    command.Parameters.Add("@VALID", SqlDbType.Int, 500);
        //    command.Parameters["@VALID"].Direction = ParameterDirection.Output;

        //    command.Transaction = trans;
        //    command.ExecuteNonQuery();
        //    valid = (Int32)command.Parameters["@VALID"].Value;

        //    trans.Commit();
        //    connection.Close();

        //}

        //catch (Exception ex)
        //{
        //    trans.Rollback();

        //    throw ex;
        //}
        //finally
        //{
        //    command.Dispose();
        //    connection.Close();
        //    connection.Dispose();

        //}
        //return valid;
    }



    protected void btnclear_Click(object sender, EventArgs e)
    {
        try
        {
            ddlStatus.SelectedIndex = 0;
            txtRjctReasn.Text = "";


        }
        catch (Exception ex)
        {

            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }
}