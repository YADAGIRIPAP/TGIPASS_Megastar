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
public partial class UI_TSIPASS_frmPoliceAttachments : System.Web.UI.Page
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
    // string id="17083";
    static DataTable dtMyTable;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();
            dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "117");
            if (dsnew.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {
                    Response.Redirect("frmTradeLicenseDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                }
                else
                {
                    Response.Redirect("frmCinematographLicense.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
                }
            }
        }
    }

    protected void rdbBarRest_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbBarRest.SelectedValue.ToString() == "Y")
        {
            trExciseLicense.Visible = true;
        }
        else
        {
            trExciseLicense.Visible = false;
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

    protected void BtnSaleDeed_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if (fupRentalDeed.HasFile)
            {
                if ((fupRentalDeed.PostedFile != null) && (fupRentalDeed.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupRentalDeed.PostedFile.FileName);
                    try
                    {

                        string[] fileType = fupRentalDeed.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\cfoRentalDeed");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupRentalDeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupRentalDeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "cfoRentalDeed");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                LblRental.Text = fupRentalDeed.FileName;
                                hplRental.Text = fupRentalDeed.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

    protected void BtnSitePlan_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if (fupsiteplan.HasFile)
            {
                if ((fupsiteplan.PostedFile != null) && (fupsiteplan.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupsiteplan.PostedFile.FileName);
                    try
                    {

                        string[] fileType = fupsiteplan.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\cfoSitePlan");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupsiteplan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupsiteplan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "cfoSitePlan");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                lblSiteplan.Text = fupsiteplan.FileName;
                                hplSiteplan.Text = fupsiteplan.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

    protected void BtnTradeLic_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if (fupTradeLic.HasFile)
            {
                if ((fupTradeLic.PostedFile != null) && (fupTradeLic.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupTradeLic.PostedFile.FileName);
                    try
                    {

                        string[] fileType = fupTradeLic.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\cfoTradeLic");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupTradeLic.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupTradeLic.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "cfoTradeLic");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                lblTradeLic.Text = fupTradeLic.FileName;
                                hpllblTradeLic.Text = fupTradeLic.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

    protected void BtnFire_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if (fupDfo.HasFile)
            {
                if ((fupDfo.PostedFile != null) && (fupDfo.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupDfo.PostedFile.FileName);
                    try
                    {

                        string[] fileType = fupDfo.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\cfoFireAppr");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupDfo.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupDfo.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "cfoFireAppr");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                lblDFO.Text = fupDfo.FileName;
                                hplDFO.Text = fupDfo.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

    protected void btnExcise_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if (fupExcise.HasFile)
            {
                if ((fupExcise.PostedFile != null) && (fupExcise.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupExcise.PostedFile.FileName);
                    try
                    {

                        string[] fileType = fupExcise.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\cfoExciseLic");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupExcise.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupExcise.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "cfoExciseLic");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                lblExciseLic.Text = fupExcise.FileName;
                                hplExciseLic.Text = fupExcise.FileName;
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
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (rdbBarRest.SelectedIndex == 0 || rdbWhetherAll.SelectedIndex == 1)
        {
            if (rdbWhetherAll.SelectedIndex == 0 || rdbWhetherAll.SelectedIndex == 1)
            {
                SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
                osqlConnection.Open();
                string valid = "";
                
                SqlTransaction transaction = null;

                transaction = osqlConnection.BeginTransaction();

                try
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "USP_InsertPoliceAttachmentDet";
                    com.Transaction = transaction;
                    com.Connection = osqlConnection;

                    com.Parameters.AddWithValue("@barRest", rdbBarRest.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@DOCNocLic", rdbWhetherAll.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@intQnreID", (Session["ApplidA"].ToString()));

                    com.ExecuteNonQuery();

                    transaction.Commit();
                    osqlConnection.Close();
                    lblmsg.Text = "<font color='green'>Saved Successfully..!</font>";
                    lblDFO.Text = fupDfo.FileName;
                    hplDFO.Text = fupDfo.FileName;
                    success.Visible = true;
                    Failure.Visible = false;
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
            }
            else
            {
                string message = "alert('Please select Whether all the Documents/NOC/License are in the name of the applicant')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            }

        }
        else
        {
            string message = "alert('Please select Whether your Establishment has Bar/Restaurant')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

        }



    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmTradeLicenseDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
    }

    protected void BtnDelete0_Click(object sender, EventArgs e)
    {

        Response.Redirect("frmCinematographLicense.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
    }
}