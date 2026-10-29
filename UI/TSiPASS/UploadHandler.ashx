<%@ WebHandler Language="C#" Class="UploadHandler" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

public class UploadHandler : IHttpHandler {
    
   public void ProcessRequest(HttpContext context)
        {
            try
            {

                ArrayList al = new ArrayList();
                string Serverpath = HttpContext.Current.Server.MapPath("Uploads");

                var postedFile = context.Request.Files[0];

                string file;
                string filename = Path.GetFileNameWithoutExtension(postedFile.FileName);

                // System.IO.Path.GetFileName(dbf_File);
                //For IE to get file name

                if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                {
                    string[] files = postedFile.FileName.Split(new char[] { '\\' });
                    file = files[files.Length - 1];
                }
                else
                {
                    file = postedFile.FileName;
                }

                if (!Directory.Exists(Serverpath))
                    Directory.CreateDirectory(Serverpath);

                string fileDirectory = Serverpath;

                //if (File.Exists(fileDirectory + "\\" + file))
                //{
                //    File.Delete(fileDirectory + "\\" + file);
                //}

                string ext = Path.GetExtension(fileDirectory + "\\" + file);
                file = filename.Replace(" ", "_")+"_"+Guid.NewGuid() + ext;

                fileDirectory = Serverpath + "\\" + file;

                postedFile.SaveAs(fileDirectory);

                context.Response.AddHeader("Vary", "Accept");
                try
                {
                    if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                        context.Response.ContentType = "application/json";
                    else
                        context.Response.ContentType = "text/plain";
                }
                catch
                {
                    context.Response.ContentType = "text/plain";
                }
                var Filepath = "/Uploads/"+ file +"";
                List<string> list = new List<string>();
                list.Add("sucess");
                list.Add(filename);
                list.Add(Filepath);
                list.Add(file);
                
                context.Response.Write(JsonConvert.SerializeObject(list));
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

}