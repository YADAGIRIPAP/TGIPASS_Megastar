using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Web.Services;
using System.Configuration;

public partial class UI_TSIPASS_frmtsiicattachments : System.Web.UI.Page
{



    General Gen = new General();
    TsiicProperties tsiic = new TsiicProperties();
    CommonBL objcommon = new CommonBL();
    //TSIICPLOT.Plot tsiicplotobj = new TSIICPLOT.Plot();
    DataSet dsplotdtls = new DataSet();
    DataSet ds = new DataSet();

    public Int64 Appid { get; set; }

    static DataSet GDs = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        Session["ApplicationId"] = Convert.ToInt64(Request.QueryString["appid"].ToString());



        Appid = Convert.ToInt64(Session["ApplicationId"]);



        if (!IsPostBack)
        {


            Gs(Convert.ToInt64(Session["uid"]), Appid);
            //bindatas();
            FillDetails();
            Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "addScript", "getDetails()", true);

            //if (dsplotdtls != null && dsplotdtls.Tables[4].Rows.Count > 0)
            //{
            //    FillDetails(dsplotdtls);

            //}

        }
    }

    public void FillDetails()
    {


        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            //ds = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

            dsplotdtls = GetSavedPlotdtls(Convert.ToInt64(Session["uid"]), Appid);
            DataSet ds = new DataSet();
            ds.Merge(dsplotdtls);
            if (ds.Tables[4].Rows.Count > 0)
            {
                int c = ds.Tables[4].Rows.Count;
                string sen, sen1, sen2, senPlanB, senid, sennew;

                int i = 0;


                DataTable dt1 = new DataTable();
                dt1.Columns.Add("link");
                dt1.Columns.Add("FileName");

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("link");
                dt2.Columns.Add("FileName");

                while (i < c)
                {
                    senid = ds.Tables[4].Rows[i][1].ToString();
                    sen2 = ds.Tables[4].Rows[i][2].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");//sen1.Replace(@"E:/Newfloder(2)\", "~/");
                    sennew = ds.Tables[4].Rows[i]["linkNew"].ToString();// LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                    if (senid.Contains("Processflowchart"))
                    {
                        HyperLink1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink1.Text = ds.Tables[4].Rows[i][1].ToString();
                        Label14.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label14.Visible = false;
                        // HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }


                    if (senid.Contains("UdyogAadharAcknowledgent"))
                    {
                        HyperLink2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink2.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label16.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label16.Visible = false;

                    }

                    if (senid.Contains("Partnershipdeed"))
                    {
                        HyperLink3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink3.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label3.Text = ds.Tables[4].Rows[i][1].ToString();

                    }

                    if (senid.Contains("Shareholderdetails"))
                    {
                        HyperLink13.NavigateUrl = sen;
                        HyperLink13.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label26.Text = ds.Tables[4].Rows[i][1].ToString();

                    }

                    if (senid.Contains("PlantandMachinery"))
                    {
                        HyperLink4.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink4.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label5.Text = ds.Tables[4].Rows[i][1].ToString();

                    }


                    if (senid.Contains("communityandcastecertificate"))
                    {
                        HyperLink5.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink5.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label7.Text = ds.Tables[4].Rows[i][1].ToString();

                    }

                    if (senid.Contains("CertificatecopyAddress"))
                    {
                        HyperLink6.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink6.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label9.Text = ds.Tables[4].Rows[i][1].ToString();

                    }


                    if (senid.Contains("Pancardaddress"))
                    {
                        HyperLink7.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink7.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label11.Text = ds.Tables[4].Rows[i][1].ToString();

                    }

                    if (senid.Contains("photographapplicant"))
                    {
                        HyperLink8.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink8.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label15.Text = ds.Tables[4].Rows[i][1].ToString();

                    }
                    if (senid.Contains("Financialclosure"))
                    {
                        HyperLink9.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink9.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label18.Text = ds.Tables[4].Rows[i][1].ToString();

                    }
                    if (senid.Contains("receiptapplicant"))
                    {
                        HyperLink10.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink10.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label20.Text = ds.Tables[4].Rows[i][1].ToString();

                    }
                    if (senid.Contains("GstRegistration"))
                    {
                        HyperLink11.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink11.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label23.Text = ds.Tables[4].Rows[i][1].ToString();

                    }
                    if (senid.Contains("otherrelevantdocuments"))
                    {
                        HyperLink12.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink12.Text = ds.Tables[4].Rows[i][1].ToString();

                        Label25.Text = ds.Tables[4].Rows[i][1].ToString();

                    }
                    if (senid.Contains("cancelledCheque"))
                    {
                        hypcancelledcheque.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        hypcancelledcheque.Text = ds.Tables[4].Rows[i][1].ToString();

                        lblcancelledcheque.Text = ds.Tables[4].Rows[i][1].ToString();

                    }

                    i++;

                }
            }




        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
        finally
        {

        }

    }

    public static DataSet GenericFillDs(string procedurename, SqlParameter[] sp)
    {

        string st = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlConnection con = new SqlConnection(st);
        con.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter(procedurename, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddRange(sp);

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }

    }


    public DataSet Gs(Int64 uid, Int64 appid)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@Createdby",SqlDbType.Int),
                    new SqlParameter("@Appid",SqlDbType.Int),


                };
            p[0].Value = uid;
            p[1].Value = Session["uid"].ToString();





            GDs = GenericFillDs("USP_GET_Tsiicattachments_USERID", p);

            List<TsiicAttachment> addl = new List<TsiicAttachment>();










            return GDs;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }



    public DataSet GetSavedPlotdtls(Int64 uid, Int64 appid)
    {
        try
        {

            SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@Createdby",SqlDbType.Int),
                new SqlParameter("@Appid",SqlDbType.Int),

                };
            p[0].Value = uid;
            p[1].Value = appid;

            ds = Gen.GenericFillDs("USP_GET_PLOTDETAILS_USERID", p);
            return ds;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //if (Label14.Text != "")
        //{
        //    Label14.Visible = false;
        //}
        //if (Label16.Text != "")
        //{
        //    Label16.Visible = false;
        //}
        //if (Label3.Text != "")
        //{
        //    Label3.Visible = false;
        //}
        //if (Label26.Text != "")
        //{
        //    Label26.Visible = false;
        //}
        //if (Label5.Text != "")
        //{
        //    Label5.Visible = false;
        //}
        //if (Label7.Text != "")
        //{
        //    Label7.Visible = false;
        //}
        //if (Label9.Text != "")
        //{
        //    Label9.Visible = false;
        //}
        //if (Label11.Text != "")
        //{
        //    Label11.Visible = false;
        //}
        //if (Label15.Text != "")
        //{
        //    Label15.Visible = false;
        //}
        //if (Label18.Text != "")
        //{
        //    Label18.Visible = false;
        //}
        //if (Label20.Text != "")
        //{
        //    Label20.Visible = false;
        //}
        //if (Label23.Text != "")
        //{
        //    Label23.Visible = false;
        //}
        ////validations
        //if (Label14.Text == "" || Label16.Text == "" || Label3.Text == "" || Label26.Text == "" ||
        //    Label5.Text == "" || Label7.Text == "" || Label9.Text == "" || Label11.Text == "" ||
        //    Label15.Text == "" || Label18.Text == "" || Label20.Text == "" || Label23.Text == "")
        //{
        //    if (Label14.Text == "")
        //    {
        //        Label14.Visible = true;
        //        Label14.Text = "<font color='red'>Please Select a file To Upload</font>";
        //    }
        //    if (Label16.Text == "")
        //    {
        //        Label16.Visible = true;
        //        Label16.Text = "<font color='red'>Please Select a file To Upload</font>";
        //    }
        //    if (Label3.Text == "")
        //    {
        //        Label3.Visible = true;
        //        Label3.Text = "<font color='red'>Please Select a file To Upload</font>";
        //    }
        //    if (Label26.Text == "")
        //    {
        //        Label26.Visible = true;
        //        Label26.Text = "<font color='red'>Please Select a file To Upload</font>";
        //    }
        //    if (Label5.Text == "")
        //    {
        //        Label5.Visible = true;
        //        Label5.Text = "<font color='red'>Please Select a file To Upload</font>";
        //    }
        //    if (Label7.Text == "")
        //    {
        //        Label7.Visible = true;
        //        Label7.Text = "<font color='red'>Please Select a file To Upload</font>";
        //    }
        //    if (Label9.Text == "")
        //    {
        //        Label9.Visible = true;
        //        Label9.Text = "<font color='red'>Please Select a file To Upload</font>";
        //    }
        //    if (Label11.Text == "")
        //    {
        //        Label11.Visible = true;
        //        Label11.Text = "<font color='red'>Please Select a file To Upload</font>";
        //    }
        //    if (Label15.Text == "")
        //    {
        //        Label15.Visible = true;
        //        Label15.Text = "<font color='red'>Please Select a file To Upload</font>";
        //    }
        //    if (Label18.Text == "")
        //    {
        //        Label18.Visible = true;
        //        Label18.Text = "<font color='red'>Please Select a file To Upload</font>";
        //    }
        //    if (Label20.Text == "")
        //    {
        //        Label20.Visible = true;
        //        Label20.Text = "<font color='red'>Please Select a file To Upload</font>";
        //    }
        //    if (Label23.Text == "")
        //    {
        //        Label23.Visible = true;
        //        Label23.Text = "<font color='red'>Please Select a file To Upload</font>";
        //    }
        //}
        //else
        //{

        //    Response.Redirect("frmtsiicpaymentdraft.aspx?Applicationid=" + Request.QueryString["Appid"].ToString());
        //}
        if (Label16.Text != "")
        {
            Label16.Visible = false;
        }

        if (Label15.Text != "")
        {
            Label15.Visible = false;
        }

        if (Label5.Text != "")
        {
            Label5.Visible = false;
        }

        if (Label9.Text != "")
        {
            Label9.Visible = false;
        }

        if (Label11.Text != "")
        {
            Label11.Visible = false;
        }

        if (Label18.Text != "")
        {
            Label18.Visible = false;
        }
        if (lblcancelledcheque.Text != "")
        {
            lblcancelledcheque.Visible = false;
        }
        if (HyperLink1.Text == "")
        {
            Label14.Visible = true;
            Label14.Text = "<font color='red'>Please Select a file To Upload</font>";

        }
        //if (orgtypeid == "2")
        //{
        //    if (Label3.Text == "")
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Copy of partnership deed/ articles of memorandum and association of the company/society registration as applicable')", true);
        //        //BtnSave.Enabled = false;
        //        return;
        //    }
        //}
        else if (HyperLink2.Text == "")
        {
            Label16.Visible = true;

            Label16.Text = "<font color='red'>Please Select a file To Upload</font>";

        }
        else if (HyperLink4.Text == "")
        {
            Label5.Visible = true;

            Label5.Text = "<font color='red'>Please Select a file To Upload</font>";

        }
        else if (HyperLink6.Text == "")
        {
            Label9.Visible = true;
            Label9.Text = "<font color='red'>Please Select a file To Upload</font>";

        }
        else if (HyperLink7.Text == "")
        {
            Label11.Visible = true;
            Label11.Text = "<font color='red'>Please Select a file To Upload</font>";

        }
        else if (HyperLink8.Text == "")
        {
            Label15.Visible = true;
            Label15.Text = "<font color='red'>Please Select a file To Upload</font>";

        }
        else if (HyperLink9.Text == "")
        {
            Label18.Visible = true;
            Label18.Text = "<font color='red'>Please Select a file To Upload</font>";

        }
        else if (hypcancelledcheque.Text == "")
        {
            lblcancelledcheque.Visible = true;
            lblcancelledcheque.Text = "<font color='red'>Please Select a file To Upload(Cancelled Cheque)</font>";

        }
        else
        {

            Response.Redirect("frmtsiicpaymentdraft.aspx?Applicationid=" + Request.QueryString["Appid"].ToString());
        }



    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmtsiicplotallotment.aspx?ApppId=" + Request.QueryString["Appid"].ToString());
    }

    protected void Btnshareholder_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];

        int j = 4;

        General t1 = new General();
        if (FileUpload13.HasFile)
        {
            if ((FileUpload13.PostedFile != null) && (FileUpload13.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload13.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload13.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\Shareholderdetails");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload13.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload13.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            // Label14.Visible = true;
                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink13.Text = FileUpload13.FileName;
                            Label26.Text = FileUpload13.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF files only   ')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    //
                    // DeleteFile(sFileDir + sFileName);
                }
            }

        }
        else
        {

            if (Label26.Text != "")
            {
                Label26.Visible = false;
            }
            else
            {
                Label26.Visible = true;
                Label26.Text = "<font color='red'>Please Select a file To Upload</font>";
            }


        }

    }


    protected void BtnLandRqrmnt_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 1;

        General t1 = new General();
        if (FileUpload1.HasFile)
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\Land_requirements");
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

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            // Label14.Visible = true;
                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink1.Text = FileUpload1.FileName;
                            Label14.Text = FileUpload1.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF files only   ')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception ex)//in case of an error
                {
                    LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    //
                    // DeleteFile(sFileDir + sFileName);
                }
            }

        }
        else
        {

            if (Label14.Text != "")
            {
                Label14.Visible = false;
            }
            else
            {
                Label14.Visible = true;
                Label14.Text = "<font color='red'>Please Select a file To Upload</font>";
            }


        }

    }

    protected void BtnAdhrAck_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 2;
        General t1 = new General();
        if (FileUpload2.HasFile)
        {
            if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\UdyogAadhar");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            //Label14.Visible = true;
                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink2.Text = FileUpload2.FileName;
                            Label16.Text = FileUpload2.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF files only   ')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";

                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {

            Label16.Visible = true;
            Label16.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //success.Visible = false;
            //Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }



    }

    protected void BtnPtnrshpDeed_Click(object sender, EventArgs e)
    {
        string newPath = "";
       // string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 3;
        General t1 = new General();
        if (FileUpload3.HasFile)
        {
            if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\Partnershipdeed");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            //Label14.Visible = true;
                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink3.Text = FileUpload3.FileName;
                            Label3.Text = FileUpload3.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF files only  ')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";

                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {
            //lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //success.Visible = false;
            //Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void BtnMchnryDtls_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 5;
        General t1 = new General();
        if (FileUpload4.HasFile)
        {
            if ((FileUpload4.PostedFile != null) && (FileUpload4.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload4.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload4.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\PlantandMachinery");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {

                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink4.Text = FileUpload4.FileName;
                            Label5.Text = FileUpload4.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF files only  ')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";

                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {
            //lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //success.Visible = false;
            //Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }


    protected void BtnCasteCertfct_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 6;

        General t1 = new General();
        if (FileUpload5.HasFile)
        {
            if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\communityandcastecertificate");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            //Label14.Visible = true;
                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink5.Text = FileUpload5.FileName;
                            Label7.Text = FileUpload5.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF files only   ')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";

                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {
            //lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //success.Visible = false;
            //Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }
    protected void BtnAddrsPrf_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 7;

        General t1 = new General();
        if (FileUpload6.HasFile)
        {
            if ((FileUpload6.PostedFile != null) && (FileUpload6.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload6.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload6.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\CertificatecopyAddress");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload6.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload6.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            //Label14.Visible = true;
                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink6.Text = FileUpload6.FileName;
                            Label9.Text = FileUpload6.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            //Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF files only')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";

                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {
            //lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //success.Visible = false;
            //Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void BtnPanIdnty_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 8;
        General t1 = new General();
        if (FileUpload7.HasFile)
        {
            if ((FileUpload7.PostedFile != null) && (FileUpload7.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload7.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload7.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\Pancardaddress");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload7.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload7.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            //Label14.Visible = true;
                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink7.Text = FileUpload7.FileName;
                            Label11.Text = FileUpload7.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF files only   ')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";

                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {
            //lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //success.Visible = false;
            //Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }
    protected void BtnphtogrpyApplcnt_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 9;
        General t1 = new General();
        if (FileUpload8.HasFile)
        {
            if ((FileUpload8.PostedFile != null) && (FileUpload8.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload8.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload8.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\photographapplicant");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload8.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload8.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            //Label14.Visible = true;
                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink8.Text = FileUpload8.FileName;
                            Label15.Text = FileUpload8.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload JPG ,PNG  only  ')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";

                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {
            //lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //success.Visible = false;
            //Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }
    protected void BtnBnkrLtr_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 10;

        General t1 = new General();
        if (FileUpload9.HasFile)
        {
            if ((FileUpload9.PostedFile != null) && (FileUpload9.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload9.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload9.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\Financialclosure");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload9.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload9.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            //Label14.Visible = true;
                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink9.Text = FileUpload9.FileName;
                            Label18.Text = FileUpload9.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF files only   ')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";

                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {
            //lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //success.Visible = false;
            //Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }
    protected void BtnPmntRcpt_Click(object sender, EventArgs e)
    {
        string newPath = "";
       // string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 11;

        General t1 = new General();
        if (FileUpload10.HasFile)
        {
            if ((FileUpload10.PostedFile != null) && (FileUpload10.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload10.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload10.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\receiptapplicant");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload10.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload10.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            //Label14.Visible = true;
                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink10.Text = FileUpload10.FileName;
                            Label20.Text = FileUpload10.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF  files only')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";

                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {
            //lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //success.Visible = false;
            //Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }
    protected void BtnGSTCrtfct_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 12;
        General t1 = new General();
        if (FileUpload11.HasFile)
        {
            if ((FileUpload11.PostedFile != null) && (FileUpload11.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload11.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload11.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\GstRegistration");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload11.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload11.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            //Label14.Visible = true;
                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink11.Text = FileUpload11.FileName;
                            Label23.Text = FileUpload11.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF files only')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";

                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {
            //lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //success.Visible = false;
            //Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }
    protected void BtnRlvntdoc_Click(object sender, EventArgs e)
    {
        string newPath = "";

        //string sFileDir = Server.MapPath("~\\UI/TSIPASS/plotattachments");
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 13;
        General t1 = new General();
        if (FileUpload12.HasFile)
        {
            if ((FileUpload12.PostedFile != null) && (FileUpload12.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload12.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload12.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\otherrelevantdocuments");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload12.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload12.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            //Label14.Visible = true;
                            //Label14.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink12.Text = FileUpload12.FileName;
                            Label25.Text = FileUpload12.FileName;
                            //success.Visible = true;
                            //Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {
                            //lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            //success.Visible = false;
                            //Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        //lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF files only')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";

                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        else
        {
            //lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //success.Visible = false;
            //Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }


    public int InsertplotAttachement(Int64 appid, string AttachmentFilename, string AttachmentFilePath, Int64 Created_by, int attachmentid)
    {
        try
        {

            string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("USP_INS_TsiicATTACHMENTS", con);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Convert.ToInt64(Session["ApplicationId"]) == 0 || Session["ApplicationId"] == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@appid", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@appid", SqlDbType.BigInt).Value = appid;
            }

            if (AttachmentFilename.Trim() == "" || AttachmentFilename.Trim() == null || AttachmentFilename.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = AttachmentFilename.Trim();
            }

            if (AttachmentFilePath.Trim() == "" || AttachmentFilePath.Trim() == null || AttachmentFilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = AttachmentFilePath.Trim();
            }

            if (attachmentid == 0 || attachmentid == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@attachmentid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@attachmentid", SqlDbType.VarChar).Value = Convert.ToInt32(attachmentid);
            }


            if (Created_by == 0 || Created_by == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Convert.ToInt64(Created_by);
            }

            myDataAdapter.SelectCommand.Parameters.Add("@Result", SqlDbType.VarChar, 500);
            myDataAdapter.SelectCommand.Parameters["@Result"].Direction = ParameterDirection.Output;

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

            throw ex;

        }
        finally
        {



        }
    }


    protected void btncancelledcheque_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["PlotfilePath"];
        int j = 16;
        General t1 = new General();
        if (fupcancelledcheque.HasFile)
        {
            if ((fupcancelledcheque.PostedFile != null) && (fupcancelledcheque.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(fupcancelledcheque.PostedFile.FileName);
                try
                {

                    string[] fileType = fupcancelledcheque.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Appid + "\\cancelledCheque");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupcancelledcheque.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupcancelledcheque.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = InsertplotAttachement(Convert.ToInt64(Session["ApplicationId"]), sFileName, newPath, Convert.ToInt64(Session["uid"]), j);


                        if (result > 0)
                        {
                            hypcancelledcheque.Text = fupcancelledcheque.FileName;
                            lblcancelledcheque.Text = fupcancelledcheque.FileName;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            FillDetails();
                        }
                        else
                        {

                        }

                    }
                    else
                    {

                        Response.Write("<script>alert('Upload PDF files only')</script> "); //+ fileType[1].Trim(); 
                    }

                }
                catch (Exception)//in case of an error
                {

                }
            }
        }
        else
        {

        }
    }

}


