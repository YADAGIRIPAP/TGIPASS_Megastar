using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

public partial class UI_TSiPASS_FRMMOBILETOWERTSROWATTACHMENTS : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DB.DB con = new DB.DB();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            HDNMOBILETOWERID.Value = Request.QueryString["mobiletowerid"];
            FillAttachmentsDetails();
        }
    }
    void FillAttachmentsDetails()
    {
        DataSet ds = new DataSet();

        ds = FillMobiletowerAttachmentsDetails(HDNMOBILETOWERID.Value);

        if (ds != null  && ds.Tables[0].Rows.Count > 0)
        {
            int c = ds.Tables[0].Rows.Count;
            string sen, sen1, sen2;
            int i = 0;

            while (i < c)
            {
                sen2 = ds.Tables[0].Rows[i][0].ToString();
                sen1 = sen2.Replace(@"\", @"/");


                if (sen1.ToUpper().Contains("AGENCY"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("AGENCY"))
                    {
                        Hypagencynetwork.Visible = true;
                        Hypagencynetwork.Text = ds.Tables[0].Rows[i][1].ToString();
                        Hypagencynetwork.NavigateUrl = sen;
                       // lblagencynetwork.Text = ds.Tables[0].Rows[i][1].ToString();
                    }
                }
                if (sen1.ToUpper().Contains("PROPERTYTAX"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("PROPERTYTAX"))
                    {
                        Hyppropertytaxreceipt.Visible = true;
                        Hyppropertytaxreceipt.Text = ds.Tables[0].Rows[i][1].ToString();
                        Hyppropertytaxreceipt.NavigateUrl = sen;
                    }
                }
                if (sen1.ToUpper().Contains("SSCCERTIFICATE"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("SSCCERTIFICATE"))
                    {
                        Hypssccertificate.Visible = true;
                        Hypssccertificate.Text = ds.Tables[0].Rows[i][1].ToString();
                        Hypssccertificate.NavigateUrl = sen;
                    }
                }
                if (sen1.ToUpper().Contains("ELEVATION"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("ELEVATION"))
                    {
                        Hypelevationplanandsections.Visible = true;
                        Hypelevationplanandsections.Text = ds.Tables[0].Rows[i][1].ToString();
                        Hypelevationplanandsections.NavigateUrl = sen;
                    }
                }
                if (sen1.ToUpper().Contains("SACFA"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("SACFA"))
                    {
                        HypSACFA.Visible = true;
                        HypSACFA.Text = ds.Tables[0].Rows[i][1].ToString();
                        txtacknowledgeid.Text = ds.Tables[0].Rows[i][2].ToString();
                        HypSACFA.NavigateUrl = sen;
                    }
                }
                if (sen1.ToUpper().Contains("LOCATIONORSITE"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("LOCATIONORSITE"))
                    {
                        Hyplocationorsiteplan.Visible = true;
                        Hyplocationorsiteplan.Text = ds.Tables[0].Rows[i][1].ToString();
                        Hyplocationorsiteplan.NavigateUrl = sen;
                    }
                }
                if (sen1.ToUpper().Contains("OWNERSHIP"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("OWNERSHIP"))
                    {
                        Hypownershipdocument.Visible = true;
                        Hypownershipdocument.Text = ds.Tables[0].Rows[i][1].ToString();
                        Hypownershipdocument.NavigateUrl = sen;
                    }
                }
                if (sen1.ToUpper().Contains("LEASE"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("LEASE"))
                    {
                        Hypleaseagreement.Visible = true;
                        Hypleaseagreement.Text = ds.Tables[0].Rows[i][1].ToString();
                        Hypleaseagreement.NavigateUrl = sen;
                    }
                }
                if (sen1.ToUpper().Contains("VICINITY"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("VICINITY"))
                    {
                        Hypvicinitycertificate.Visible = true;
                        Hypvicinitycertificate.Text = ds.Tables[0].Rows[i][1].ToString();
                        Hypvicinitycertificate.NavigateUrl = sen;
                    }
                }
                if (sen1.ToUpper().Contains("INDEMNITY"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("INDEMNITY"))
                    {
                        Hypindemnitybond.Visible = true;
                        Hypindemnitybond.Text = ds.Tables[0].Rows[i][1].ToString();
                        Hypindemnitybond.NavigateUrl = sen;
                    }
                }
                if (sen1.ToUpper().Contains("NOCFROM"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("NOCFROM"))
                    {
                        Hypownernoc.Visible = true;
                        Hypownernoc.Text = ds.Tables[0].Rows[i][1].ToString();
                        Hypownernoc.NavigateUrl = sen;
                    }
                }
                if (sen1.ToUpper().Contains("BUILDINGPER"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("BUILDINGPER"))
                    {
                        Hypbuildingpermission.Visible = true;
                        Hypbuildingpermission.Text = ds.Tables[0].Rows[i][1].ToString();
                        Hypbuildingpermission.NavigateUrl = sen;
                    }
                }
                if (sen1.ToUpper().Contains("OCCUPANCYCERT"))
                {

                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.ToUpper().Contains("OCCUPANCYCERT"))
                    {
                        Hypoccupancy.Visible = true;
                        Hypoccupancy.Text = ds.Tables[0].Rows[i][1].ToString();
                        Hypoccupancy.NavigateUrl = sen;
                    }
                }
                i++;
            }

        }

    }
    public DataSet FillMobiletowerAttachmentsDetails(string MobileTowerID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetmobileTowerAttachmentDetails_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@MobileTowerid", SqlDbType.VarChar).Value = MobileTowerID;

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
    protected void btnagencynetwork_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fupagencynetwork.HasFile)
            {
                if ((fupagencynetwork.PostedFile != null) && (fupagencynetwork.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupagencynetwork.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupagencynetwork.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\AgencyNetwordagreement");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupagencynetwork.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupagencynetwork.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "AgencyNetwordagreement", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), "", "30");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hypagencynetwork.Text = fupagencynetwork.FileName;
                                // lblagencynetwork.Text = fupagencynetwork.FileName;
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
                    catch (Exception ex)//in case of an error
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

    protected void btnpropertytaxreceipt_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fuppropertytaxreceipt.HasFile)
            {
                if ((fuppropertytaxreceipt.PostedFile != null) && (fuppropertytaxreceipt.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fuppropertytaxreceipt.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fuppropertytaxreceipt.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\propertytaxReceipt");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fuppropertytaxreceipt.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fuppropertytaxreceipt.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "propertytaxReceipt", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), "", "36");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hyppropertytaxreceipt.Text = fuppropertytaxreceipt.FileName;
                                // lblpropertytaxreceipt.Text = fuppropertytaxreceipt.FileName;
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
                    catch (Exception ex)//in case of an error
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

    protected void btnssccertificate_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fupssccertificate.HasFile)
            {
                if ((fupssccertificate.PostedFile != null) && (fupssccertificate.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupssccertificate.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupssccertificate.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\ssccertificate");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupssccertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupssccertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "ssccertificate", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), "", "12");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hypssccertificate.Text = fupssccertificate.FileName;
                                //lblssccertificate.Text = fupssccertificate.FileName;
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
                    catch (Exception ex)//in case of an error
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

    protected void btnelevationplanandsections_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fupelevationplanandsections.HasFile)
            {
                if ((fupelevationplanandsections.PostedFile != null) && (fupelevationplanandsections.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupelevationplanandsections.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupelevationplanandsections.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\ElevationPlanandSections");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupelevationplanandsections.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupelevationplanandsections.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "ElevationPlanandSections", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), "", "11");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hypelevationplanandsections.Text = fupelevationplanandsections.FileName;
                                //lblelevationplanandsections.Text = fupelevationplanandsections.FileName;
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
                    catch (Exception ex)//in case of an error
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

    protected void btnSACFA_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fupSACFA.HasFile)
            {
                if ((fupSACFA.PostedFile != null) && (fupSACFA.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupSACFA.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupSACFA.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\SACFA");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupSACFA.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupSACFA.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "SACFA", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), txtacknowledgeid.Text, "9");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                HypSACFA.Text = fupSACFA.FileName;
                                //lblSACFA.Text = fupSACFA.FileName;
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
                    catch (Exception ex)//in case of an error
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

    protected void btnlocationorsiteplan_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fuplocationorsiteplan.HasFile)
            {
                if ((fuplocationorsiteplan.PostedFile != null) && (fuplocationorsiteplan.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fuplocationorsiteplan.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fuplocationorsiteplan.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\Locationorsiteplan");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fuplocationorsiteplan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fuplocationorsiteplan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "Locationorsiteplan", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), "", "10");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hyplocationorsiteplan.Text = fuplocationorsiteplan.FileName;
                                //lbllocationorsiteplan.Text = fuplocationorsiteplan.FileName;
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
                    catch (Exception ex)//in case of an error
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

    protected void btnownershipdocument_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fupownershipdocument.HasFile)
            {
                if ((fupownershipdocument.PostedFile != null) && (fupownershipdocument.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupownershipdocument.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupownershipdocument.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\OwnershipDocument");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupownershipdocument.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupownershipdocument.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "OwnershipDocument", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), "", "28");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hypownershipdocument.Text = fupownershipdocument.FileName;
                                //lblownershipdocument.Text = fupownershipdocument.FileName;
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
                    catch (Exception ex)//in case of an error
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

    protected void btnleaseagreement_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fupleaseagreement.HasFile)
            {
                if ((fupleaseagreement.PostedFile != null) && (fupleaseagreement.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupleaseagreement.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupleaseagreement.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\LeaseAgreement");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupleaseagreement.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupleaseagreement.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "LeaseAgreement", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), "", "29");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hypleaseagreement.Text = fupleaseagreement.FileName;
                                // lblleaseagreement.Text = fupleaseagreement.FileName;
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
                    catch (Exception ex)//in case of an error
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

    protected void btnvicinitycertificate_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fupvicinitycertificate.HasFile)
            {
                if ((fupvicinitycertificate.PostedFile != null) && (fupvicinitycertificate.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupvicinitycertificate.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupvicinitycertificate.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\VicinityCertificate");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupvicinitycertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupvicinitycertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "VicinityCertificate", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), "", "31");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hypvicinitycertificate.Text = fupvicinitycertificate.FileName;
                                // lblvicinitycertificate.Text = fupvicinitycertificate.FileName;
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
                    catch (Exception ex)//in case of an error
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

    protected void btnindemnitybond_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fupindemnitybond.HasFile)
            {
                if ((fupindemnitybond.PostedFile != null) && (fupindemnitybond.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupindemnitybond.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupindemnitybond.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\IndemnityBond");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupindemnitybond.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupindemnitybond.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "IndemnityBond", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), "", "32");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hypindemnitybond.Text = fupindemnitybond.FileName;
                                // lblindemnitybond.Text = fupindemnitybond.FileName;
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
                    catch (Exception ex)//in case of an error
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

    protected void btnownernoc_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fupownernoc.HasFile)
            {
                if ((fupownernoc.PostedFile != null) && (fupownernoc.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupownernoc.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupownernoc.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\NOCfromOwner");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupownernoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupownernoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "NOCfromOwner", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), "", "33");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hypownernoc.Text = fupownernoc.FileName;
                                //lblownernoc.Text = fupownernoc.FileName;
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
                    catch (Exception ex)//in case of an error
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

    protected void btnbuildingpermission_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fupbuildingpermission.HasFile)
            {
                if ((fupbuildingpermission.PostedFile != null) && (fupbuildingpermission.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupbuildingpermission.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupbuildingpermission.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\BuildingPermission");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupbuildingpermission.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupbuildingpermission.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "BuildingPermission", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), "", "34");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hypbuildingpermission.Text = fupbuildingpermission.FileName;
                                //lblbuildingpermission.Text = fupbuildingpermission.FileName;
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
                    catch (Exception ex)//in case of an error
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

    protected void btnoccupancy_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\MOBILETOWERATACHMENTS");

            General t1 = new General();
            if (fupoccupancy.HasFile)
            {
                if ((fupoccupancy.PostedFile != null) && (fupoccupancy.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupoccupancy.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupoccupancy.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, HDNMOBILETOWERID.Value + "\\OccupancyCertificate");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupoccupancy.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupoccupancy.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = InsertImagedataMOBILETOWER_TSROW(HDNMOBILETOWERID.Value, HDNMOBILETOWERID.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "OccupancyCertificate", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), "", "35");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Hypoccupancy.Text = fupoccupancy.FileName;
                                //lbloccupancy.Text = fupoccupancy.FileName;
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
                    catch (Exception ex)//in case of an error
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
    public int InsertImagedataMOBILETOWER_TSROW(string Maintableid, string MOBILETOWEREnterpid, string FileType, string FilePath, string FileName, string FileDescription,
     string bu, string Created_by, string Created_dt, string Modified_by, string Modified_dt, string Acknowledgementid, string ATTACHMENTID)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertATTACHMENTS_TSROWMOBILETOWER", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Maintableid.Trim() == "" || Maintableid.Trim() == null || Maintableid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Maintableid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Maintableid", SqlDbType.Int).Value = Int32.Parse(Maintableid.Trim());
            }


            if (MOBILETOWEREnterpid.Trim() == "" || MOBILETOWEREnterpid.Trim() == null || MOBILETOWEREnterpid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@MOBILETOWEREnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@MOBILETOWEREnterpid", SqlDbType.Int).Value = Int32.Parse(MOBILETOWEREnterpid.Trim());
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
            if (Acknowledgementid.Trim() == "" || Acknowledgementid.Trim() == null || Acknowledgementid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Acknowledgementid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Acknowledgementid", SqlDbType.VarChar).Value = Acknowledgementid.Trim();
            }
            if (ATTACHMENTID.Trim() == "" || ATTACHMENTID.Trim() == null || ATTACHMENTID.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ATTACHMENTID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ATTACHMENTID", SqlDbType.VarChar).Value = ATTACHMENTID.Trim();
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
    public string ValidateFileUploads()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (Hypagencynetwork.Text == "" || Hypagencynetwork.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Agency Network/Infrastructure Provider Agreement \\n";
            slno = slno + 1;
        }
        if (Hyppropertytaxreceipt.Text == "" || Hyppropertytaxreceipt.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Property Tax Receipt \\n";
            slno = slno + 1;
        }
        if (Hypssccertificate.Text == "" || Hypssccertificate.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Structural Stability Certificate (SSC) \\n";
            slno = slno + 1;
        }
        if (Hypelevationplanandsections.Text == "" || Hypelevationplanandsections.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Elevation Plan and Sections \\n";
            slno = slno + 1;
        }
        if (txtacknowledgeid.Text == "" || txtacknowledgeid.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter AcknowledgementID \\n";
            slno = slno + 1;
        }
        if (HypSACFA.Text == "" || HypSACFA.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Permission based on SACFA \\n";
            slno = slno + 1;
        }
        if (Hyplocationorsiteplan.Text == "" || Hyplocationorsiteplan.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Location/Site Plan \\n";
            slno = slno + 1;
        }
        if (Hypownershipdocument.Text == "" || Hypownershipdocument.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Ownership Doc with Attestation \\n";
            slno = slno + 1;
        }
        if (Hypleaseagreement.Text == "" || Hypleaseagreement.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Lease Agreement Between Building/Site Owner and Applicant \\n";
            slno = slno + 1;
        }
        if (Hypvicinitycertificate.Text == "" || Hypvicinitycertificate.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Vicinity Certificate \\n";
            slno = slno + 1;
        }
        if (Hypindemnitybond.Text == "" || Hypindemnitybond.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Indemnity Bond \\n";
            slno = slno + 1;
        }
        if (Hypownernoc.Text == "" || Hypownernoc.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload NOC from House/Site Owner \\n";
            slno = slno + 1;
        }
        if (Hypbuildingpermission.Text == "" || Hypbuildingpermission.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Building Permission \\n";
            slno = slno + 1;
        }
        if (Hypoccupancy.Text == "" || Hypoccupancy.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Occupancy Certificate \\n";
            slno = slno + 1;
        }


        return ErrorMsg;
    }
    protected void btnpayment_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateFileUploads();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        if (HDNMOBILETOWERID.Value.ToString().Trim() == "" || HDNMOBILETOWERID.Value.Trim() == "0")
        {
            Response.Redirect("frmMobileTowesTSROW.aspx");
        }
        else
        {
            Response.Redirect("frmPaymentMobiletowerTSROW.aspx?intApplicationId=" + HDNMOBILETOWERID.Value);
        }
    }
}