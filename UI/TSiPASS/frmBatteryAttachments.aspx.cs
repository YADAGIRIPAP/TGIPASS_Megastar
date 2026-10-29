using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class UI_TSiPASS_frmBatteryAttachments : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    int n1;

    static DataTable dtMyTable;
    //Cls_Dharnidata obj_dharani = new Cls_Dharnidata();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btngst_Click1(object sender, EventArgs e)
    {
        try
        {
            //hdngst.Value = gstupload.PostedFile.FileName;
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\BatteryAttachments");

            //if (gstupload.PostedFile.FileName.Contains("'") == true || gstupload.PostedFile.FileName.Contains("/") == true
            //    || gstupload.PostedFile.FileName.Contains("*") == true || gstupload.PostedFile.FileName.Contains("$") == true
            //    || gstupload.PostedFile.FileName.Contains("^") == true || gstupload.PostedFile.FileName.Contains("#") == true)
            //{
            //    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#)..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
            General t1 = new General();
            if ((gstupload.PostedFile != null) && (gstupload.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(gstupload.PostedFile.FileName);
                try
                {
                    string[] fileType = gstupload.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\GST");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            gstupload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                gstupload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        result = InsertImagedata(Request.QueryString[0].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "GST", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblgstcert.Text = gstupload.FileName;
                            gstcertificate.Text = gstupload.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
           // DeleteFile(newPath + "\\" + sFileName);
        }
    }


    protected void btnbatdeal_Click1(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\BatteryAttachments");

            //if (batdealupload.PostedFile.FileName.Contains("'") == true || batdealupload.PostedFile.FileName.Contains("/") == true
            //    || batdealupload.PostedFile.FileName.Contains("*") == true || batdealupload.PostedFile.FileName.Contains("$") == true
            //    || batdealupload.PostedFile.FileName.Contains("^") == true || batdealupload.PostedFile.FileName.Contains("#") == true)
            //{
            //    lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#)..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
            General t1 = new General();
            if ((batdealupload.PostedFile != null) && (batdealupload.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(batdealupload.PostedFile.FileName);
                try
                {
                    string[] fileType = batdealupload.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\BatteryDealer");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            batdealupload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                batdealupload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        result = InsertImagedata(Request.QueryString[0].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "BatteryDealer Deed", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblbatdeareg.Text = batdealupload.FileName;
                            batterydealercertificate.Text = batdealupload.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }
                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    DeleteFile(newPath + "\\" + sFileName);
                    // DeleteFile(sFileDir + sFileName);
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
            int valid = UpdateBatteryCompletion(Session["uid"].ToString(),Request.QueryString[0].ToString());
            if (valid == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Completed Successfully');" , true);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int valid = UpdateBatteryCompletion(Session["uid"].ToString(), Request.QueryString[0].ToString());
            if (valid == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Completed Successfully');", true);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    public int InsertImagedata(string intQuessionaireid, string intCFEid, string FileType, string FilePath, string FileName, string FileDescription,
   string bu, string Created_by, string Created_dt, string Modified_by, string Modified_dt)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertImage_Battery", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null || intQuessionaireid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }


            if (intCFEid.Trim() == "" || intCFEid.Trim() == null || intCFEid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = Int32.Parse(intCFEid.Trim());
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

            if (bu.Trim() == "" || bu.Trim() == null || bu.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = bu.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }

            if (Created_dt.Trim() == "" || Created_dt.Trim() == null || Created_dt.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = Created_dt.Trim();
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

    public int UpdateBatteryCompletion(string createdby,string BatdealerID)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_BATERRY_APPSTATUS]", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            command.Parameters.AddWithValue("@BatdealerID", BatdealerID);
            command.Parameters.AddWithValue("@Created_by", createdby);
            
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
            //command1.Dispose();
        }
        return valid;
    }

}