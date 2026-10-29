using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{

    General clsGeneral = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        string pdfPath = "";
        string Decrypt = "";
        if (Request.QueryString["filepathnew"] != null)
        {
                        
            //string Decrypt = clsGeneral.Decrypt(Request.QueryString["filepathnew"].Replace(" ", "+"), "SYSTIME");
            if (Request.QueryString["Module"] != null)
            {
                DataSet ds = GetDepartmentViewNew("", Request.QueryString["Module"].ToString(), Request.QueryString["filepathnew"].ToString());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Decrypt = ds.Tables[0].Rows[0]["linkNew"].ToString();// LINKNEW
                }
                if (Decrypt.Contains(".pdf"))
                {
                    //pdfPath = Request.QueryString["filepathnew"].ToString();// @"D:/Madhuri/Projects/TSIPASS/TsipassFinal/Files/Mudassar_Khan.pdf";
                    View(Decrypt);
                }
            }
            pdfPath = Request.QueryString["filepathnew"].ToString();
            if(pdfPath.Contains(".aspx"))
            {
                pdfPath = pdfPath.Split(new string[] { ".aspx?filepathnew=" }, StringSplitOptions.None)[1];
            }
            if (pdfPath.Contains(".pdf"))
            {               
                View(pdfPath);
            }
            else if (pdfPath.ToLower().Contains(".png"))
            {                
                ViewImagePng(pdfPath);
            }
            else if (pdfPath.ToLower().Contains(".jpeg"))
            {              
                ViewImage(pdfPath);
            }
            else if (pdfPath.ToLower().Contains(".dwg"))
            {              
                ViewDWG(pdfPath);
            }
            else if (pdfPath.ToLower().Contains(".zip"))
            {
                ViewZip(pdfPath);
            }
            else if (pdfPath.ToLower().Contains(".rar"))
            {               
                ViewRar(pdfPath);
            }
            //View(pdfPath);
        }
    }
    public void View(string pdfPath)
    {
        //string embed = "Test";
        //ltEmbed.Text = string.Format(embed, ResolveUrl("~/Files/Mudassar_Khan.pdf"));

        // pdfPath = @"http://ipass.telangana.gov.in/TS-iPASSAttachments/Attachments/117178/PANorAADHAAR/adhar%20card%20&%20Pan%20Card.pdf";

        //Read the PDF file into a byte array
        if (!File.Exists(pdfPath))
        {
            throw new Exception("File not found : " + pdfPath);
        }
        byte[] pdfBytes = File.ReadAllBytes(pdfPath);

        //Set the response content type to PDF
        Response.ContentType = "application/pdf";

        //Set the content disposition to inline so the PDF opens within the browser
        Response.AppendHeader("Content-Disposition", "inline;filename=adhar card & Pan Card.pdf");

        //Write the PDF bytes to the response stream
        Response.BinaryWrite(pdfBytes);

        //End the response
        Response.End();
    }
    public void ViewImagePng(string imagePath)
    {
        //string imagePath = Server.MapPath("~/Files/sample.jpg");

        //Set the response content type to JPEG
        Response.ContentType = "image/png";

        //Write the image bytes to the response stream
        Response.WriteFile(imagePath);

        //End the response
        Response.End();
    }
    public void ViewImage(string imagePath)
    {
        //string imagePath = Server.MapPath("~/Files/sample.jpg");

        //Set the response content type to JPEG
        Response.ContentType = "image/jpeg";

        //Write the image bytes to the response stream
        Response.WriteFile(imagePath);

        //End the response
        Response.End();
    }
    public void ViewDWG(string filePath)
    {
        //string filePath = Server.MapPath("~/Files/myfile.zip");

        //Read the Excel file into a byte array
        byte[] fileBytes = File.ReadAllBytes(filePath);

        //Set the response content type to XLSX
        Response.ContentType = "application/dwg";

        //Set the content disposition to inline so the file opens within the browser
        Response.AppendHeader("Content-Disposition", "attachment; filename=myfile.dwg");

        //Write the file bytes to the response stream
        Response.BinaryWrite(fileBytes);

        //End the response
        Response.End();
        //.dwg
    }
    public void ViewZip(string filePath)
    {
        //string filePath = Server.MapPath("~/Files/myfile.zip");

        //Read the Excel file into a byte array
        byte[] fileBytes = File.ReadAllBytes(filePath);

        //Set the response content type to XLSX
        Response.ContentType = "application/zip";

        //Set the content disposition to inline so the file opens within the browser
        Response.AppendHeader("Content-Disposition", "attachment; filename=myfile.zip");

        //Write the file bytes to the response stream
        Response.BinaryWrite(fileBytes);

        //End the response
        Response.End();
        //.dwg
    }
    public void ViewRar(string filePath)
    {
        //string filePath = Server.MapPath("~/Files/myfile.zip");

        //Read the Excel file into a byte array
        byte[] fileBytes = File.ReadAllBytes(filePath);

        //Set the response content type to XLSX
        Response.ContentType = "application/x-rar-compressed";

        //Set the content disposition to inline so the file opens within the browser
        Response.AppendHeader("Content-Disposition", "attachment; filename=myfile.rar");

        //Write the file bytes to the response stream
        Response.BinaryWrite(fileBytes);

        //End the response
        Response.End();
        //.dwg
    }
    public void ViewText()
    {
        string filePath = Server.MapPath("~/Files/sample.txt");

        //Read the text file into a string
        string fileContent = File.ReadAllText(filePath);

        //Set the response content type to plain text
        Response.ContentType = "text/plain";

        //Write the file content to the response stream
        Response.Write(fileContent);

        //End the response
        Response.End();
    }

    public void ViewDocx()
    {
        string filePath = Server.MapPath("~/Files/sample.docx");

        //Read the Word file into a byte array
        byte[] fileBytes = File.ReadAllBytes(filePath);

        //Set the response content type to DOCX
        Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

        //Set the content disposition to inline so the file opens within the browser
        Response.AppendHeader("Content-Disposition", "inline;filename=sample.docx");

        //Write the file bytes to the response stream
        Response.BinaryWrite(fileBytes);

        //End the response
        Response.End();
    }

    public void ViewExcel()
    {
        string filePath = Server.MapPath("~/Files/sample.xlsx");

        //Read the Excel file into a byte array
        byte[] fileBytes = File.ReadAllBytes(filePath);

        //Set the response content type to XLSX
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        //Set the content disposition to inline so the file opens within the browser
        Response.AppendHeader("Content-Disposition", "inline;filename=sample.xlsx");

        //Write the file bytes to the response stream
        Response.BinaryWrite(fileBytes);

        //End the response
        Response.End();
        //.dwg
    }

    public DataSet GetDepartmentViewNew(string intCFEid, string MODULE, string FILEPATH)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_RetriveLinkBy_Department", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intCFEid.Trim() == "" || intCFEid.Trim() == null || intCFEid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = intCFEid.ToString();


            if (MODULE.Trim() == "" || MODULE.Trim() == null || MODULE.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@MODULE", SqlDbType.VarChar).Value = DBNull.Value;
            else
                //  da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = cmf.convertDateIndia(fromdate);
                da.SelectCommand.Parameters.Add("@MODULE", SqlDbType.VarChar).Value = (MODULE);

            if (FILEPATH.Trim() == "" || FILEPATH.Trim() == null || FILEPATH.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@FILEPATH", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@FILEPATH", SqlDbType.VarChar).Value = (FILEPATH);


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
    //protected void View(object sender, EventArgs e)
    //{
    //    //string embed = "Test";
    //    //ltEmbed.Text = string.Format(embed, ResolveUrl("~/Files/Mudassar_Khan.pdf"));

    //    string pdfPath = @"G:\TS-iPASSFinal\Attachments\117178\PANorAADHAAR\adhar card & Pan Card.pdf";


    //    //Read the PDF file into a byte array
    //    byte[] pdfBytes = File.ReadAllBytes(pdfPath);

    //    //Set the response content type to PDF
    //    Response.ContentType = "application/pdf";

    //    //Set the content disposition to inline so the PDF opens within the browser
    //    Response.AppendHeader("Content-Disposition", "inline;filename=adhar card & Pan Card.pdf");

    //    //Write the PDF bytes to the response stream
    //    Response.BinaryWrite(pdfBytes);

    //    //End the response
    //    Response.End();
    //}
}