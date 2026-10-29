using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_frmknowledgingsharing : System.Web.UI.Page
{
    General Gen = new General();
    string Section_File_Path, Section_File_Type, Section_File_Name;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SectionType();
            DescrptionType();
        }

    }
    protected void SectionType()
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlConnection scon = new SqlConnection(connectionstring);
        SqlDataAdapter adpt = new SqlDataAdapter("Get_sectiontypes", scon);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        ddldept0.DataSource = dt;
        ddldept0.DataBind();
        ddldept0.DataTextField = "Name of Section";
        ddldept0.DataValueField = "Id";
        ddldept0.DataBind();
        ddldept0.Items.Insert(0, "--Select--");
    }
    protected void DescrptionType()
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlConnection scon = new SqlConnection(connectionstring);
        SqlDataAdapter adpt = new SqlDataAdapter("Get_Descriptiontype", scon);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        ddldoc.DataSource = dt;
        ddldoc.DataBind();
        ddldoc.DataTextField = "Description of Document";
        ddldoc.DataValueField = "Id";
        ddldoc.DataBind();
        ddldoc.Items.Insert(0, "--Select--");
    }


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        // int i;
        Section_File_Path = "";
        Section_File_Type = "";
        Section_File_Name = "";


        string newPath = "";
        string sFileDir = Server.MapPath("~\\Upload");

        General t1 = new General();
        if (FileUpload.HasFile)
        {
            if ((FileUpload.PostedFile != null) && (FileUpload.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, "1000");
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString());
                        //////////////
                        Section_File_Name = sFileName;
                        Section_File_Path = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                        Section_File_Type = fileType[i - 1].ToUpper().Trim();
                        if (!Directory.Exists(Section_File_Path))
                        {
                            //System.IO.Directory.CreateDirectory(Section_File_Path);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Section_File_Path);
                            //int count = dir.GetFiles().Length;
                            FileUpload.PostedFile.SaveAs(Section_File_Path + "\\" + Section_File_Name);
                        }
                        else
                        {
                            string[] Files = Directory.GetFiles(Section_File_Path);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload.PostedFile.SaveAs(Section_File_Path + "\\" + Section_File_Name);
                        }                 

                    }
                    else
                    {
                        Failure.Visible = true;
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        lblFileName1.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                    }
                }
                catch (Exception)
                {
                    //DeleteFile(newPath + "\\" + sFileName);
                }


            }
        }

        int j = 0;
        j = InsGrievStaus(ddldoc.SelectedItem.Text, txtDesc.Text.Trim(), ddldept0.SelectedItem.Text.Trim(), FileUpload.FileName, "1234", Section_File_Path, Section_File_Type, Section_File_Name, txtuidno.Text.Trim(), null);


        string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(conString);
        SqlDataAdapter adapt = new SqlDataAdapter("select * from tbl_KnowledgeSharing", con);
        con.Open();
        adapt.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {
            Gridview.DataSource = dt;
            Gridview.DataBind();
            success.Visible = true;
        }
        else
        {
            Failure.Visible = true;
            lblmsg0.Text = "Showing Error...!";
        }

    }
   

    public int InsGrievStaus(string DescriptionofDocument, string Remarkmultiline, string NameofSection, string AppliedDocument, string Created_by, string Section_File_Path, string Section_File_Type, string Section_File_Name, string Others, object p)
    {
        // cmd.CommandType = CommandType.StoredProcedure;
        int value = 0;
        try
        {

            string con = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
            SqlConnection scon = new SqlConnection(con);
            //  SqlCommand cmd = new SqlCommand("sp_Remark", scon);

            scon.Open();
            SqlCommand cmd = new SqlCommand("sp_Remark", scon); //sp_Remark
            cmd.CommandType = CommandType.StoredProcedure;


            //if (intGrievanceid.Trim() == "" || intGrievanceid.Trim() == null)
            //    cmd.Parameters.Add("@intGrievanceid", SqlDbType.VarChar).Value = intGrievanceid.Trim();
            //else
            //    cmd.Parameters.Add("@intGrievanceid", SqlDbType.VarChar).Value = intGrievanceid.Trim();



            if (DescriptionofDocument.Trim() == "" || DescriptionofDocument.Trim() == null)
                cmd.Parameters.Add("@DescriptionofDocument", SqlDbType.VarChar).Value = DescriptionofDocument.Trim();
            else
                cmd.Parameters.Add("@DescriptionofDocument", SqlDbType.VarChar).Value = DescriptionofDocument.Trim();

            if (Remarkmultiline.Trim() == "" || Remarkmultiline.Trim() == null)
                cmd.Parameters.Add("@Remarkmultiline", SqlDbType.VarChar).Value = Remarkmultiline.Trim();
            else
                cmd.Parameters.Add("@Remarkmultiline", SqlDbType.VarChar).Value = Remarkmultiline.Trim();
            if (NameofSection.Trim() == "" || NameofSection.Trim() == null)
                cmd.Parameters.Add("@NameofSection", SqlDbType.VarChar).Value = NameofSection.Trim();
            else
                cmd.Parameters.Add("@NameofSection", SqlDbType.VarChar).Value = NameofSection.Trim();
            if (@AppliedDocument.Trim() == "" || @AppliedDocument.Trim() == null)
                cmd.Parameters.Add("@AppliedDocument", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AppliedDocument", SqlDbType.VarChar).Value = @AppliedDocument.Trim();

            if (Created_by.Trim() == "" || Created_by.Trim() == null)
                cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "1234";
            else
                cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "1234";

            //if (ForwardTo.Trim() == "" || ForwardTo.Trim() == null)
            //    cmd.Parameters.Add("@ForwardTo", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    cmd.Parameters.Add("@ForwardTo", SqlDbType.VarChar).Value = ForwardTo.Trim();

            if (Section_File_Path != null && Section_File_Path != "")
                cmd.Parameters.Add("@Section_File_Path", SqlDbType.VarChar).Value = Section_File_Path.Trim();

            if (Section_File_Type != null && Section_File_Type != "")
                cmd.Parameters.Add("@Section_File_Type", SqlDbType.VarChar).Value = Section_File_Type.Trim();

            if (Section_File_Name != null && Section_File_Name != "")
                cmd.Parameters.Add("@Section_File_Name", SqlDbType.VarChar).Value = Section_File_Name.Trim();

            //if (ForwardToMailId != null && ForwardToMailId != "")
            //    cmd.Parameters.Add("@ForwardToMailId", SqlDbType.VarChar).Value = ForwardToMailId.Trim();
            if (Others.Trim() == "" || Others == null)
                cmd.Parameters.Add("@Others", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Others", SqlDbType.VarChar).Value = Others.Trim();

            return Convert.ToInt32(cmd.ExecuteScalar());
            scon.Close();
        }
        catch (Exception ex)
        {
            // con.CloseConnection();

            throw ex;
        }
        return value;
    }




    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ddldept0.ClearSelection();
        ddldoc.ClearSelection();
        txtuidno.Text = string.Empty;
        txtDesc.Text = string.Empty;
        FileUpload.Dispose();
    }

    protected void ddldoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldoc.SelectedValue == "5")
        {
            trotherdesc.Visible = true;
        }
        else
        {
            trotherdesc.Visible = false;
        }
    }
    //protected void main()
    // {
    //     //try
    //     //{
    //     string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    //    // SqlConnection con = new SqlConnection(conString);
    //     //    con.Open();
    //     //    SqlDataAdapter da = new SqlDataAdapter("select Name of Section,DescriptionofDocument,Remarkmultiline,Section_File_Path from tbl_KnowledgeSharing", con);
    //     //  //  DataTable dt = new DataTable()


    //     //    DataSet ds = new DataSet();

    //     //    da.Fill(ds);
    //     //    Gridview.DataSource = ds;
    //     //    Gridview.DataBind();
    //     ////    Report.Visible = true;
    //     //    con.Close();

    //     //}
    //     //catch (Exception Ex)
    //     //{ throw Ex; }
    //     DataTable dt = new DataTable();
    //     SqlConnection con = new SqlConnection(conString);
    //     SqlDataAdapter adapt = new SqlDataAdapter("select Name of Section,DescriptionofDocument,Remarkmultiline,Section_File_Path from tbl_KnowledgeSharing", con);
    //     con.Open();
    //     adapt.Fill(dt);
    //     con.Close();
    //     if (dt.Rows.Count > 0)
    //     {
    //         Gridview.DataSource = dt;
    //         Gridview.DataBind();
    //     }

    // }




    //}

    //protected void BtnUpload_Click(object sender, EventArgs e)
    //{


    //}

    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        lblHeading.Visible = true;
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                Gridview.AllowPaging = false;

                // this.fillgrid();

                Gridview.HeaderRow.ForeColor = System.Drawing.Color.Black;
                Gridview.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                Gridview.FooterRow.ForeColor = System.Drawing.Color.Black;
                // grdExport.Columns[1].Visible = false;
                Gridview.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=R6.1:TSiPASS-TotalReportold2NewReport" + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }


    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void ExportToExcel()
    {
        try
        {
            lblHeading.Visible = true;
            // grdsupport.Columns[6].Visible = false;
            Response.Clear();
            Response.Buffer = true;
            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                Government.Visible = true;
                Gridview.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                Gridview.RenderControl(hw);
                string label1text = Label560.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            //Button1.Visible = true;
            //Button2.Visible = true;
        }
        catch (Exception e)
        {

        }
    }
}
//txtuidno.Text = "Submited Successfully..!";
//success.Visible = true;
//Failure.Visible = false;
//int deptid = 0;
//if (ddldept0.SelectedValue != "--select--") ;
//deptid = Convert.ToInt32(ddldept0.SelectedValue);
//DataSet dsdata = new DataSet();
//dsdata = Gen.GetGreivanceAck_Data(j, deptid);
//if (dsdata != null && dsdata.Tables.Count > 0 && dsdata.Tables[0].Rows.Count > 0)
//{
//    string SectionNo = j.ToString();
//    //string msg = "", body = "";
//    string Created_by = dsdata.Tables[0].Rows[0]["Created_by"].ToString();
//    string NameOfSection = dsdata.Tables[0].Rows[0]["NameOfSection"].ToString();
//    string Remark = dsdata.Tables[0].Rows[0]["Remark"].ToString();
//    string DescriptionOfDocument = dsdata.Tables[0].Rows[0]["DescriptionOfDocument"].ToString();
//    try
//    {
//        lblFileName1.Text = "success";
//    }
//    catch (Exception)
//    {

//    }
//    txtuidno.Text = "";
//    txtDesc.Text = "";
//    ddldept0.SelectedIndex = 0;
//    ddldoc.SelectedIndex = 0;

//}


//string con = ConfigurationManager.ConnectionStrings["Testcon"].ConnectionString;
//SqlConnection scon = new SqlConnection(con);
//SqlCommand cmd = new SqlCommand("sp_Remark", scon);
//cmd.CommandType = CommandType.StoredProcedure;
//cmd.Parameters.AddWithValue("NameofSection", ddldept0.SelectedItem.Text);
//cmd.Parameters.AddWithValue("DescriptionofDocument", ddldoc.SelectedItem.Text);
//cmd.Parameters.AddWithValue("AppliedDocument", FileUpload.FileName);
//cmd.Parameters.AddWithValue("Others", txtuidno.Text);
//cmd.Parameters.AddWithValue("Remarkmultiline", txtDesc.Text);
//scon.Open();
//int i = cmd.ExecuteNonQuery();
//scon.Close();
//if (i >= 1)
//{
//    txtuidno.Text = "success";
//}
//else
//{
//    txtuidno.Text = "Not success";
//}