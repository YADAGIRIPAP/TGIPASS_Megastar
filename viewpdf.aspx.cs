using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public partial class viewpdf : System.Web.UI.Page
{
    General clsGeneral = new General();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["filepathnew"] != null)
        {
            string Decrypt = Request.QueryString["filepathnew"].ToString();

            if (Decrypt.Contains(".pdf"))
            {
                string path = Decrypt;
                View(path);
            }
            else if (Decrypt.Contains(".zip"))
            {
                string path = Decrypt;
                ViewZip(path);
            }
            else if (Decrypt.Contains(".jpeg"))
            {
                string path = Decrypt;
                ViewImage(path);
            }
            else if (Decrypt.Contains(".PDF"))
            {
                string path = Decrypt;
                View(path);
            }
            else if (Decrypt.Contains(".JPG"))
            {
                string path = Decrypt;
                ViewImage(path);
            }
            else if (Decrypt.Contains(".jpg"))
            {
                string path = Decrypt;
                ViewImage(path);
            }
            else if (Decrypt.Contains(".JPEG"))
            {
                string path = Decrypt;
                ViewImage(path);
            }
            else if (Decrypt.Contains(".PNG"))
            {
                string path = Decrypt;
                ViewImagePng(path);
            }
            else if (Decrypt.Contains(".png"))
            {
                string path = Decrypt;
                ViewImagePng(path);
            }
            else if (Decrypt.Contains(".txt"))
            {
                string path = Decrypt;
                ViewText(path);
            }
            else if (Decrypt.Contains(".docx"))
            {
                string path = Decrypt;
                ViewDocx(path);
            }
        }
    }
    public void View(string pdfPath)
    {
        //string embed = "Test";
        //ltEmbed.Text = string.Format(embed, ResolveUrl("~/Files/Mudassar_Khan.pdf"));

        // pdfPath = @"http://ipass.telangana.gov.in/TS-iPASSAttachments/Attachments/117178/PANorAADHAAR/adhar%20card%20&%20Pan%20Card.pdf";

        //Read the PDF file into a byte array
        byte[] pdfBytes = File.ReadAllBytes(pdfPath);

        //Set the response content type to PDF
        Response.ContentType = "application/pdf";

        //Set the content disposition to inline so the PDF opens within the browser
        Response.AppendHeader("Content-Disposition", "inline;filename=filename.pdf");

        //Write the PDF bytes to the response stream
        Response.BinaryWrite(pdfBytes);

        //End the response
        Response.End();
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
    public void ViewImage(string imagePath)
    {
        if (imagePath != null)
        {


            //string imagePath = Server.MapPath("~/Files/sample.jpg");

            //Set the response content type to JPEG
            Response.ContentType = "image/jpeg";

            //Write the image bytes to the response stream
            if (File.Exists(imagePath))
            {
                Response.WriteFile(imagePath);
            }

            //End the response
            Response.End();
        }
    }

    public void ViewImagePng(string imagePath)
    {
        if (imagePath != null)
        {
            //string imagePath = Server.MapPath("~/Files/sample.jpg");

            //Set the response content type to JPEG
            Response.ContentType = "image/png";

            //Write the image bytes to the response stream
            Response.WriteFile(imagePath);

            //End the response
            Response.End();
        }
    }

    public void ViewText(string filePath)
    {
        if (filePath != null)
        {
            //string filePath = Server.MapPath("~/Files/sample.txt");

            //Read the text file into a string
            string fileContent = File.ReadAllText(filePath);

            //Set the response content type to plain text
            Response.ContentType = "text/plain";

            //Write the file content to the response stream
            Response.Write(fileContent);

            //End the response
            Response.End();
        }
    }

    public void ViewDocx(string filePath)
    {
        if (filePath != null)
        {
            //string filePath = Server.MapPath("~/Files/sample.docx");

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
    }

    public void ViewExcel()
    {
        string filePath = Server.MapPath("~/Files/sample.xlsx");
        if (filePath != null)
        {
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
        }
        //.dwg
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