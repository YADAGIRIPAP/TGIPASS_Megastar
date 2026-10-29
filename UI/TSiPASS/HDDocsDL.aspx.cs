using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class HDDocsDL : System.Web.UI.Page
{
    SqlDataReader drHeads = null;
    DB.DB Dcon = new DB.DB();
    General t1 = new General();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillbinaryData();
        }
    }
    protected void FillbinaryData()
    {
        string searchQuery = "";
        if (Request.QueryString[0].ToString() == "2")
        {
            searchQuery = " SELECT     hd_uplddoc as ScanImage,hd_uplddocname as fileName FROM tm_Helpdesk WHERE     int_fbid= '" + Request.QueryString[1].ToString() + "'";
        }
        try
        {
            Dcon.OpenConnection();

           // drHeads = t1.ExecuteDReader(searchQuery, Dcon.GetConnection);
            drHeads = t1.ExecuteDReader(searchQuery, Dcon.GetConnection);
           
            
            while (drHeads.Read())
            {
                Response.ClearContent();
                Response.ClearHeaders();
                if (drHeads["scanImage"].ToString() != "")   
                {

                    string[] contentType = drHeads["fileName"].ToString().Split('.');

                    int i = contentType.Length;
                    switch (contentType[i - 1].ToUpper().Trim())
                    {
                        case "JPG":
                            Response.ContentType = "image/JPG";
                            Response.AddHeader("content-disposition", "attachment;filename=Tr.JPG");
                            break;
                        case "JPEG":
                            Response.ContentType = "image/JPEG";
                            Response.AddHeader("content-disposition", "attachment;filename=Tr.JPEG");
                            break;

                        case "GIF":
                            Response.ContentType = "image/GIF";
                            Response.AddHeader("content-disposition", "attachment;filename=Tr.GIF");
                            break; 
                        case "PDF":
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=Tr.pdf");
                            break;
                        case "DOC":
                            Response.ContentType = "application/vnd.ms-word";
                            Response.AddHeader("content-disposition", "attachment;filename=Tr.doc");
                            break;
                        case "DOCX":
                            Response.ContentType = "application/vnd.ms-word";
                            Response.AddHeader("content-disposition", "attachment;filename=Tr.doc");
                            break;
                        case "XLS":
                            Response.ContentType = "application/vnd.ms-excel";
                            Response.AddHeader("content-disposition", "attachment;filename=Tr.xls");
                            break;
                        case "XLSX":
                            Response.ContentType = "application/vnd.ms-excel";
                            Response.AddHeader("content-disposition", "attachment;filename=Tr.xls");
                            break;

                        case "PNG":
                            Response.ContentType = "application/vnd.ms-excel";
                            Response.AddHeader("content-disposition", "attachment;filename=Tr.png");
                            break;

                        case "RAR":
                            Response.ContentType = "application/vnd.ms-excel";
                            Response.AddHeader("content-disposition", "attachment;filename=Tr.rar");
                            break;

                        case "ZIP":
                            Response.ContentType = "application/vnd.ms-excel";
                            Response.AddHeader("content-disposition", "attachment;filename=Tr.ZIP");
                            break;

                       default:

                            break;
                    }

                    byte[] buffer = null;
                    buffer = (byte[])drHeads["scanImage"];
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(buffer);
                    Response.End();


                 
                }
                else
                    Response.Write("No Data with Specified Request");
                
            }
            
        }
        catch (Exception ex)
        {
            //lblResult.Text = ex.ToString();
        }
        finally
        {
            drHeads.Close();
            Dcon.CloseConnection();
            
        }

    }
   
}
