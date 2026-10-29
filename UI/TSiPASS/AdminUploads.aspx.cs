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

public partial class UI_TSiPASS_AdminUploads : System.Web.UI.Page
{
    CommonBL objcommon = new CommonBL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["uid"] != null)
            {
                if (MyFileUpload.PostedFile.FileName != "")
                {
                    Byte[] bytes = null;
                    Stream fs = MyFileUpload.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    bytes = br.ReadBytes((Int32)fs.Length);
                    int Result = objcommon.UpdateUserPassword("Gallery", bytes, null, "GALLERY", null, Session["uid"].ToString(), "GALLERY");
                    if (Result == 1)
                    {
                        lblmsg.Text = "  Image Uploaded";
                        success.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("../../Home2.aspx");
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg.Text = ex.Message;
        }
    }
    protected void btnpostnews_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["uid"] != null)
            {
                string news = txtnews.InnerText.TrimStart().Trim();
                if (!string.IsNullOrEmpty(news))
                {
                    int Result = objcommon.UpdateUserPassword("NEWS", null, null, "NEWS", news, Session["uid"].ToString(), "NEWS");
                    if (Result == 1)
                    {
                        lblmsg.Text = "  News Posted";
                        success.Visible = true;
                        txtnews.InnerText = "";
                    }
                }
            }
            else
            {
                Response.Redirect("../../Home2.aspx");
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg.Text = ex.Message;
        }
    }
    protected void btnCMupload_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["uid"] != null)
            {
                if (CMphoto.PostedFile.FileName != "")
                {
                    Byte[] bytes = null;
                    Stream fs = CMphoto.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    bytes = br.ReadBytes((Int32)fs.Length);
                    int Result = objcommon.UpdateUserPassword("CM", bytes, null, "CM", null, Session["uid"].ToString(), "CM");
                    if (Result == 1)
                    {
                        lblmsg.Text = "  Image Uploaded";
                        success.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("../../Home2.aspx");
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg.Text = ex.Message;
        }
    }
    protected void btnitminster_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["uid"] != null)
            {
                if (ITminsterphoto.PostedFile.FileName != "")
                {
                    Byte[] bytes = null;
                    Stream fs = ITminsterphoto.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    bytes = br.ReadBytes((Int32)fs.Length);
                    int Result = objcommon.UpdateUserPassword("ITM", bytes, null, "ITM", null, Session["uid"].ToString(), "ITM");
                    if (Result == 1)
                    {
                        lblmsg.Text = "  Image Uploaded";
                        success.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("../../Home2.aspx");
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg.Text = ex.Message;
        }
    }
}