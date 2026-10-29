using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class UI_TSiPASS_IPOMonthlyReport : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    public class IPOMonthlyReport
    {
        public string Createdby { get; set; }
        public string Month { get; set; }
        public string year { get; set; }
        public string Remarks { get; set; }
        public string sno { get; set; }

    }

    General Gen = new General();
    IPOMonthlyReport objvo1 = new IPOMonthlyReport();
    string sno;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }
        if (!IsPostBack)
        {
            int year = DateTime.Now.Year - 5;

            for (int Y = year; Y <= DateTime.Now.Year; Y++)
            {

                ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
            }

            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            ddlmonth.SelectedIndex = DateTime.Now.Month-1;
            ddlYear.Enabled = false;
            ddlmonth.Enabled = false;
            DataSet dscheck = new DataSet();

            dscheck = getiporeport(ddlmonth.SelectedValue, ddlYear.SelectedValue, Session["uid"].ToString());
            if (dscheck != null && dscheck.Tables[0].Rows[0]["VALID"].ToString() =="1")
            {
                Failure.Visible = true;
                lblmsg0.Text = "Report Already Uploaded";
                lblmsg0.Visible = true;
                BtnSave1.Visible = false;
                BtnSave3.Enabled = false;
                //trupload.Visible = true;
                //trremarks.Visible = true;

            }
            else
            {
                BtnSave1.Visible = true;
                //trupload.Visible = false;
                //trremarks.Visible = false;
               
            }
            getSno();
        }

    }



    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (lblFileName.Text != "")
        {

            if (save())
            {

                string message = "alert('Submitted Succussfully')";

                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                //Response.Redirect("IPOMonthlyReport.aspx");
                success.Visible = true;
                lblmsg.Text = "Submitted Succussfully";
                BtnSave1.Enabled = false;
                Failure.Visible = false;

            }


        }
        else
        {
            Failure.Visible = true;
            success.Visible = false;
            lblmsg0.Text = "Please upload document!";
            BtnSave1.Enabled = true;
        }

    }

    #region "Methods"
    public void getSno()
    {


        osqlConnection.Open();
        DataSet oDataSet = new DataSet();
        SqlDataAdapter osqlDataAdapter = new SqlDataAdapter("getMaxID", osqlConnection);


        osqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        osqlDataAdapter.Fill(oDataSet);
        sno = oDataSet.Tables[0].Rows[0]["sno"].ToString();
        Session["impSno"] = sno.ToString();
        osqlConnection.Close();

    }


    public string InsertIPOReportMonthly(IPOMonthlyReport objvo1)
    {
        string valid = "";
        osqlConnection.Open();
        SqlTransaction transaction = null;

        transaction = osqlConnection.BeginTransaction();

        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "insertIPOMonthlyReport";
            com.Transaction = transaction;
            com.Connection = osqlConnection;

            com.Parameters.AddWithValue("@Createdby", objvo1.Createdby);
            com.Parameters.AddWithValue("@M_Month", objvo1.Month);
            com.Parameters.AddWithValue("@Y_Year", objvo1.year);
            com.Parameters.AddWithValue("@Remarks", objvo1.Remarks);


            com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();

            valid = com.Parameters["@Valid"].Value.ToString();

            transaction.Commit();
            osqlConnection.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
            osqlConnection.Dispose();
        }
        return valid;
    }

    public int InsertIPORprtMonthlyAttachment(string intIPOId, string FileNm, string FilePath, string FileDescription, string Created_dt, string Createdby,
    string P_Month, string P_Year, string sno)
    {
        try
        {

            osqlConnection.Open();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertIPOMonthlyReportattch", osqlConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intIPOId.Trim() == "" || intIPOId.Trim() == null || intIPOId.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.Int).Value = Int32.Parse(intIPOId.Trim());
            }


            if (FileNm.Trim() == "" || FileNm.Trim() == null || FileNm.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileNm", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileNm", SqlDbType.VarChar).Value = FileNm.Trim();
            }



            if (FilePath.Trim() == "" || FilePath.Trim() == null || FilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath.Trim();
            }

            if (FileDescription.Trim() == "" || FileDescription.Trim() == null || FileDescription.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }

            if (Created_dt.Trim() == "" || Created_dt.Trim() == null || Created_dt.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = Created_dt.Trim();
            }



            if (P_Month.Trim() == "" || P_Month.Trim() == null || P_Month.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@P_Month", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@P_Month", SqlDbType.VarChar).Value = P_Month.Trim();
            }


            if (P_Month == "" || P_Month == null || P_Month == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@sno", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@sno", SqlDbType.VarChar).Value = P_Month;
            }

            if (P_Year.Trim() == "" || P_Year.Trim() == null || P_Year.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@P_Year", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@P_Year", SqlDbType.VarChar).Value = P_Year.Trim();
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
            osqlConnection.Close();
            throw ex;

        }
        finally
        {

            osqlConnection.Close();

        }

    }

    public bool save()
    {
        try
        {
            if (lblFileName.Text != "")
            {
                AssignValuestoVosFromcontrols();

                string valid = InsertIPOReportMonthly(objvo1);

                if (valid == "1")
                {
                    lblmsg.Text = "Submitted Successfully";
                    success.Visible = true;

                }
            }

            else
            {
                Failure.Visible = true;
                success.Visible = false;
                lblmsg0.Visible = true;
                //string message = "alert('Please upload the attachment!')";
                lblmsg0.Text = "Please Select a file To Upload..!";


            }

        }
        catch (Exception ex)
        {

            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

        return true;
    }
    public void AssignValuestoVosFromcontrols()
    {
        try
        {
            objvo1.Createdby = Session["uid"].ToString();
            objvo1.Month = ddlmonth.SelectedValue.ToString();
            objvo1.year = ddlYear.SelectedValue.ToString();
            objvo1.Remarks = txtRemarks.Text;
            objvo1.sno = Session["impSno"].ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";

            string sFileDir = Server.MapPath("~\\IPOMonthlyRprtAttachments");

            General t1 = new General();
            if (FileUpload1.HasFile)
            {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {

                    string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    try
                    {


                        string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {

                            newPath = System.IO.Path.Combine(sFileDir, ddlmonth.SelectedValue + "\\IPOMonthReport\\" + Session["uid"].ToString());

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }


                            int result = 0;
                            result = InsertIPORprtMonthlyAttachment(Session["uid"].ToString(), sFileName, newPath, "IPO Monthly Report Doc", DateTime.Now.ToString(), ddlmonth.SelectedValue, ddlmonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString(), sno);


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                BtnSave1.Enabled = true;
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                lblFileName.Text = FileUpload1.FileName;
                                Label444.Text = FileUpload1.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                lblFileName.Text = "View";
                                lblFileName.NavigateUrl = newPath + "/" + sFileName;
                                //lblFileName.NavigateUrl =newPath+ "~\\IPOMonthlyRprtAttachments" + "/" + Session["impSno"].ToString() + "/" + "IPOMonthReport" + "/" + sFileName;
                                //lblFileName.NavigateUrl = "https://ipass.telangana.gov.in/iPOMonthlyRprtAttachments/1062/MonthlyReport/bt%20road.pdf";
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
                    catch (Exception ex)//in case of an error
                    {
                        //lblError.Visible = true;
                        //lblError.Text = "An Error Occured. Please Try Again!";
                        //DeleteFile(newPath + "\\" + sFileName);
                        // DeleteFile(sFileDir + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        if (txtRemarks.Text != "" && lblFileName.Text != "")
        {
            BtnSave1.Enabled = true;
        }
    }

    public DataSet getiporeport(string month, string year, string createdby)
    {
        DataSet ds = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@MONTH",SqlDbType.VarChar),
                 new SqlParameter("@YEAR",SqlDbType.VarChar),
                  new SqlParameter("@CREATEDBY",SqlDbType.VarChar)
            };
        pp[0].Value = month;
        pp[1].Value = year;
        pp[2].Value = createdby;

        ds = Gen.GenericFillDs("USP_CHECK_IPOMONTHREPORT", pp);

        return ds;
    }
}