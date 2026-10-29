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

public partial class IndusAwards2018 : System.Web.UI.Page
{
    static DataTable dtMyTableCertificate;
    static DataTable dtMyTable;

    static DataTable dtMyTableCertificateQ4;
    static DataTable dtMyTableQ4;

    static DataTable dtMyTableCertificateQ5;
    static DataTable dtMyTableQ5;

    static DataTable dtMyTableCertificateQ6;
    static DataTable dtMyTableQ6;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb2"] = dtMyTableCertificate;

            dtMyTableCertificateQ4 = createtablecrtificate();
            Session["CertificateTb2Q4"] = dtMyTableCertificateQ4;

            dtMyTableCertificateQ5 = createtablecrtificate();
            Session["CertificateTb2Q5"] = dtMyTableCertificateQ5;

            dtMyTableCertificateQ6 = createtablecrtificate();
            Session["CertificateTb2Q6"] = dtMyTableCertificateQ6;

            ViewState["OnlineApplicantID"] = DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
        }
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        string newPath = "";
        gvCertificate.Visible = true;
        General t1 = new General();
        if (FileUpload10.HasFile)
        {
            string OnlineApplicantID = ViewState["OnlineApplicantID"].ToString();
            if ((FileUpload10.PostedFile != null) && (FileUpload10.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload10.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload10.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "PPT" || fileType[i - 1].ToUpper().Trim() == "PPTX" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX")
                    {
                        string serverpath = Server.MapPath("~\\Awards2018\\" + OnlineApplicantID + "\\" + "3");  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload10.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = "0";

                        string Path = serverpath;
                        string FileName = sFileName;

                        string Attachmentidnew = OnlineApplicantID + DateTime.Now.Minute + DateTime.Now.Second;
                        UploadFiles(OnlineApplicantID, "3", Attachmentidnew, sFileName, serverpath, getclientIP());
                        string File_Path_Text = System.IO.Path.GetFullPath(FileUpload10.PostedFile.FileName);
                        AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'> Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "Upload word, excel, pdf or ppt files only..!";
                        lblmsg0.Visible = true;
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
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }

        gvCertificate.Visible = true;
    }
    private void AddDataToTableCeertificate(string Filename, string filepath, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");
            Row["FileName"] = Filename;
            Row["filepath"] = filepath;
            myTable.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("FileName", typeof(string));
        dtMyTable.Columns.Add("filepath", typeof(string));
        return dtMyTable;
    }

    protected DataTable createtablecrtificate4()
    {
        dtMyTableQ4 = new DataTable("CertificateTb2Q4");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTableQ4.Columns.Add("FileName", typeof(string));
        dtMyTableQ4.Columns.Add("filepath", typeof(string));
        return dtMyTableQ4;
    }
    private void AddDataToTableCeertificate4(string Filename, string filepath, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2Q4");
            Row["FileName"] = Filename;
            Row["filepath"] = filepath;
            myTable.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    protected DataTable createtablecrtificate5()
    {
        dtMyTableQ5 = new DataTable("CertificateTb2Q5");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTableQ5.Columns.Add("FileName", typeof(string));
        dtMyTableQ5.Columns.Add("filepath", typeof(string));
        return dtMyTableQ5;
    }
    private void AddDataToTableCeertificate5(string Filename, string filepath, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2Q5");
            Row["FileName"] = Filename;
            Row["filepath"] = filepath;
            myTable.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    protected DataTable createtablecrtificate6()
    {
        dtMyTableQ6 = new DataTable("CertificateTb2Q6");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTableQ6.Columns.Add("FileName", typeof(string));
        dtMyTableQ6.Columns.Add("filepath", typeof(string));
        return dtMyTableQ6;
    }
    private void AddDataToTableCeertificate6(string Filename, string filepath, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2Q6");
            Row["FileName"] = Filename;
            Row["filepath"] = filepath;
            myTable.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    public void DeleteFile(string strFileName)
    {
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)
            {
                fi.Delete();
            }
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
    public void UploadFiles(string OnlineApplicantID, string Queid, string attachmentid, string filename, string filepath, string Sysip)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdEnj = new SqlCommand("[USP_UPLOAD_AWARDS2018]", connection);
            cmdEnj.CommandType = CommandType.StoredProcedure;
            cmdEnj.Transaction = transaction;
            cmdEnj.Connection = connection;

            //SqlDataAdapter da1 = new SqlDataAdapter(cmdEnj);
            cmdEnj.Parameters.AddWithValue("@CompanyId", SqlDbType.Int).Value = Convert.ToInt64(OnlineApplicantID);
            cmdEnj.Parameters.AddWithValue("@Queid", SqlDbType.Int).Value = Convert.ToInt64(Queid);
            cmdEnj.Parameters.AddWithValue("@AttachmentId", SqlDbType.Int).Value = Convert.ToInt64(attachmentid);
            cmdEnj.Parameters.AddWithValue("@FileNm", filename);
            cmdEnj.Parameters.AddWithValue("@FilePath", filepath);
            cmdEnj.Parameters.AddWithValue("@SysIp", Sysip);
            cmdEnj.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

    public string Companydtls(string OnlineApplicantID, string Nameadrres, string industype, string Sysip)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        int valid = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdEnj = new SqlCommand("[USP_INS_AWARDS2018]", connection);
            cmdEnj.CommandType = CommandType.StoredProcedure;
            cmdEnj.Transaction = transaction;
            cmdEnj.Connection = connection;

            //SqlDataAdapter da1 = new SqlDataAdapter(cmdEnj);
            cmdEnj.Parameters.AddWithValue("@CompanyId", SqlDbType.Int).Value = Convert.ToInt64(OnlineApplicantID);
            cmdEnj.Parameters.AddWithValue("@NameandAddress", Nameadrres);
            cmdEnj.Parameters.AddWithValue("@IndustryCategory", industype);
            cmdEnj.Parameters.AddWithValue("@SysIp", Sysip);
            cmdEnj.Parameters.Add("@VALID", SqlDbType.Int, 500);
            cmdEnj.Parameters["@VALID"].Direction = ParameterDirection.Output;
            cmdEnj.ExecuteNonQuery();
            valid = (Int32)cmdEnj.Parameters["@VALID"].Value;
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return valid.ToString();
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        string errormsg = RegisteredAddreecheck();
        if (errormsg.Trim().TrimStart() != "")
        {
            txtPromotor.Focus();

            lblmsg0.Text = "<font color='Red'> " + errormsg + "</font>";
            success.Visible = false;
            Failure.Visible = true;

            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        string SelectedValue = "";
        if (chkMicro.Checked == true)
        {
            SelectedValue = chkMicro.Text;
        }
        else if (chkSmall.Checked == true)
        {
            SelectedValue = chkSmall.Text;
        }
        else if (chkMedium.Checked == true)
        {
            SelectedValue = chkMedium.Text;
        }
        else if (chkLarge.Checked == true)
        {
            SelectedValue = chkLarge.Text;
        }

        string Valid = Companydtls(ViewState["OnlineApplicantID"].ToString(), txtPromotor.Text.TrimStart().Trim(), SelectedValue, getclientIP());
        if (Valid.Trim().TrimStart() == "1")
        {
            BtnSave1.Enabled = false;
            lblmsg.Text = "<font color='green'> Details Submitted Successfully..!</font>";
            success.Visible = true;
            Failure.Visible = false;

            string message = "alert('" + "Details Submitted Successfully" + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
        else
        {
            lblmsg0.Text = "<font color='green'> Please Try Again Later..!</font>";
            success.Visible = false;
            Failure.Visible = true;

            string message = "alert('" + "Please Try Again Later" + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
    }

    public string RegisteredAddreecheck()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (txtPromotor.Text.TrimStart().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the company and contact details \\n";
            slno = slno + 1;
        }

        int value = 0;
        if (chkMicro.Checked == true)
        {
            value = value + 1;
        }
        if (chkSmall.Checked == true)
        {
            value = value + 1;
        }
        if (chkMedium.Checked == true)
        {
            value = value + 1;
        }
        if (chkLarge.Checked == true)
        {
            value = value + 1;
        }

        if (value == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Industy Category \\n";
            slno = slno + 1;
        }
        if (value > 1)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Choose Only One Industy Category \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        GridView1.Visible = true;
        General t1 = new General();
        if (FileUpload1.HasFile)
        {
            string OnlineApplicantID = ViewState["OnlineApplicantID"].ToString();
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "PPT" || fileType[i - 1].ToUpper().Trim() == "PPTX" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX")
                    {
                        string serverpath = Server.MapPath("~\\Awards2018\\" + OnlineApplicantID + "\\" + "4");  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = "0";

                        string Path = serverpath;
                        string FileName = sFileName;

                        string Attachmentidnew = OnlineApplicantID + DateTime.Now.Minute + DateTime.Now.Second;
                        UploadFiles(OnlineApplicantID, "4", Attachmentidnew, sFileName, serverpath, getclientIP());
                        string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2Q4"]);
                        this.GridView1.DataSource = ((DataTable)Session["CertificateTb2Q4"]).DefaultView;
                        this.GridView1.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'> Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "Upload word, excel, pdf or ppt files only..!";
                        lblmsg0.Visible = true;
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
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }

        GridView1.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string newPath = "";
        GridView2.Visible = true;
        General t1 = new General();
        if (FileUpload2.HasFile)
        {
            string OnlineApplicantID = ViewState["OnlineApplicantID"].ToString();
            if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "PPT" || fileType[i - 1].ToUpper().Trim() == "PPTX" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX")
                    {
                        string serverpath = Server.MapPath("~\\Awards2018\\" + OnlineApplicantID + "\\" + "5");  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload2.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = "0";

                        string Path = serverpath;
                        string FileName = sFileName;

                        string Attachmentidnew = OnlineApplicantID + DateTime.Now.Minute + DateTime.Now.Second;
                        UploadFiles(OnlineApplicantID, "5", Attachmentidnew, sFileName, serverpath, getclientIP());
                        string File_Path_Text = System.IO.Path.GetFullPath(FileUpload2.PostedFile.FileName);
                        AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2Q5"]);
                        this.GridView2.DataSource = ((DataTable)Session["CertificateTb2Q5"]).DefaultView;
                        this.GridView2.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'> Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "Upload word, excel, pdf or ppt files only..!";
                        lblmsg0.Visible = true;
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
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }

        GridView2.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string newPath = "";
        GridView3.Visible = true;
        General t1 = new General();
        if (FileUpload3.HasFile)
        {
            string OnlineApplicantID = ViewState["OnlineApplicantID"].ToString();
            if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "PPT" || fileType[i - 1].ToUpper().Trim() == "PPTX" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX")
                    {
                        string serverpath = Server.MapPath("~\\Awards2018\\" + OnlineApplicantID + "\\" + "6");  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload3.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = "0";

                        string Path = serverpath;
                        string FileName = sFileName;

                        string Attachmentidnew = OnlineApplicantID + DateTime.Now.Minute + DateTime.Now.Second;
                        UploadFiles(OnlineApplicantID, "6", Attachmentidnew, sFileName, serverpath, getclientIP());
                        string File_Path_Text = System.IO.Path.GetFullPath(FileUpload3.PostedFile.FileName);
                        AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2Q6"]);
                        this.GridView3.DataSource = ((DataTable)Session["CertificateTb2Q6"]).DefaultView;
                        this.GridView3.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'> Attachment Successfully Added..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "Upload word, excel, pdf or ppt files only..!";
                        lblmsg0.Visible = true;
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
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }

        GridView3.Visible = true;
    }
}