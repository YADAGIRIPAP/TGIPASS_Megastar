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

public partial class UI_TSiPASS_frmCinematographLicenseRenewal : System.Web.UI.Page
{
    General Gen = new General();
    List<Screendetails> lstscreendetails = new List<Screendetails>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();
            dsnew = Gen.getdataofidentityRENAPPROVALID(Request.QueryString[0].ToString(), "135");//Session["Applid"].ToString()
            if (dsnew.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {
                    //Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    //  Response.Redirect("frmFireDetailRen.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                    //Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                    Response.Redirect("frmPoliceattachments_Ren.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                }

                else
                {
                    Response.Redirect("frmapplicationForLicenceRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                }
            }
        }
        if (!IsPostBack)
        {

            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }
            DataSet dscheck1 = new DataSet();
            dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
            if (dscheck1.Tables[0].Rows.Count > 0)
            {
                Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
            }
            else
            {
                Session["ApplidA"] = "0";
            }
            if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
            {

                ResetFormControl(this);

            }
           
            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];

                if (!IsPostBack)
                {
                    //BindScreenDetails();
                    BindExperienceYears();
                    BindCommissionerates();
                    FillDetails();

                }
            }

            //DataSet dsver = new DataSet();

            //dsver = Gen.Getverifyofque5CFO(Session["ApplidA"].ToString());

            //if (dsver.Tables[0].Rows.Count > 0)
            //{
            //    string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
            //    ////string res = Gen.RetriveStatus("1002");


            //    if (res == "3" || Convert.ToInt32(res) >= 3)
            //    {
            //        ResetFormControl(this);
            //    }

            //}



        }

    }
    public void ResetFormControl(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControl(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).ReadOnly = true;
                        break;

                    case "System.Web.UI.WebControls.DropDownList":

                        if (((DropDownList)c).Items.Count > 0)
                        {
                            ((DropDownList)c).Enabled = false;
                        }
                        break;
                    case "System.Web.UI.WebControls.FileUpload":
                        ((FileUpload)c).Enabled = false;
                        break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)c).Enabled = false;
                        break;

                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)c).Enabled = false;
                        break;
                }
            }
        }
    }
    void FillDetails()
    {

        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.RetriveCinematographicDetailsRenewal(Request.QueryString[0].ToString());


            if (ds.Tables[0].Rows.Count > 0)



            {
                hdnidentityid.Value = Convert.ToString(ds.Tables[0].Rows[0]["cinemalicenseid"]);

                ddlexpyear.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ExpYear"]);

                txt9Bfileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fileno_9B"]);

                txtreferancedate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Rererancedate"]);

                txtlongevitydate.Text = Convert.ToString(ds.Tables[0].Rows[0]["LongevityCertificateDate"]);

                txtelectricalcertificatevaliddate.Text = Convert.ToString(ds.Tables[0].Rows[0]["ElectricalCertificateDate"]);

                txtfirenocvaliddate.Text = Convert.ToString(ds.Tables[0].Rows[0]["NocDate"]);

                ddlnoofshows.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Noofshows"]);

                ddlcommissionerate.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Commissionerate"]);
                ddlcommissionerate_SelectedIndexChanged(this, EventArgs.Empty);
                ddlzone.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Zone"]);
                ddlzone_SelectedIndexChanged(this, EventArgs.Empty);
                ddldivision.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Division"]);
                ddldivision_SelectedIndexChanged(this, EventArgs.Empty);
                ddlpolicestation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Policestation"]);
                ddltrafficzone.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TrafficZone"]);
                ddltrafficzone_SelectedIndexChanged(this, EventArgs.Empty);
                ddltrafficdivision.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TrafficDivision"]);
                ddltrafficdivision_SelectedIndexChanged(this, EventArgs.Empty);
                ddltrafficpolicestation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TrafficPolicestation"]);
                ddllicenseperiod.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["LicensePeriod"]);
                txtnoofscreens.Text= Convert.ToString(ds.Tables[0].Rows[0]["Noofscreens"]);

                int screencount = 0;
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Noofscreens"])))
                {
                    screencount = Convert.ToInt32(ds.Tables[0].Rows[0]["Noofscreens"]);
                }
                if (screencount == 1)
                {
                    rbttheatretype.SelectedValue = "Y";
                }
                else
                {
                    rbttheatretype.SelectedValue = "N";
                }

         
            }

            DataSet dsattachment = new DataSet();
            dsattachment = Gen.ViewAttachmentREN(Request.QueryString[0].ToString());

            if (dsattachment.Tables[0].Rows.Count > 0)
            {
                int c = dsattachment.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsattachment.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    if (sen.Contains("8BNOC"))
                    {
                        hyper8BNOC.NavigateUrl = sen;
                        hyper8BNOC.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lbl8BNOC.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("9BNOC"))
                    {
                        hyper9BNOC.NavigateUrl = sen;
                        hyper9BNOC.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lbl9BNOC.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("fireoccupancycertificate"))
                    {
                        hyperfireoccupancycertificate.NavigateUrl = sen;
                        hyperfireoccupancycertificate.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblfireoccupancycertificate.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("GHMCoccupancycertificate"))
                    {
                        hyperGHMCoccupancycertificate.NavigateUrl = sen;
                        hyperGHMCoccupancycertificate.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblGHMCoccupancycertificate.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("TSFTCANDTDCNOC"))
                    {
                        hyperTSFTCANDTDCNOC.NavigateUrl = sen;
                        hyperTSFTCANDTDCNOC.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblTSFTCANDTDCNOC.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("firmchambernoc"))
                    {
                        hyperfirmchambernoc.NavigateUrl = sen;
                        hyperfirmchambernoc.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblfirmchambernoc.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("firmdivision"))
                    {
                        hyperfirmdivision.NavigateUrl = sen;
                        hyperfirmdivision.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblfirmdivision.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("leaseagreement"))
                    {
                        hyperleaseagreement.NavigateUrl = sen;
                        hyperleaseagreement.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblleaseagreement.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("blueprint"))
                    {
                        hyperblueprint.NavigateUrl = sen;
                        hyperblueprint.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblblueprint.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("seatingdetails"))
                    {
                        hyperseatingdetails.NavigateUrl = sen;
                        hyperseatingdetails.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblseatingdetails.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    i++;
                }
            }

        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

        }

    }
    protected void btn8BNOC_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

            General t1 = new General();
            if (fup8BNOC.HasFile)
            {
                if ((fup8BNOC.PostedFile != null) && (fup8BNOC.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fup8BNOC.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fup8BNOC.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\8BNOC");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fup8BNOC.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fup8BNOC.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            //result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "8BNOC", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "8BNOC");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyper8BNOC.Text = fup8BNOC.FileName;
                                lbl8BNOC.Text = fup8BNOC.FileName;
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

    protected void txtnoofscreensoftheatre_TextChanged(object sender, EventArgs e)
    {
        dynamicgridbind();
    }
    public void dynamicgridbind()
    {
        int count = Convert.ToInt32(txtnoofscreens.Text);
        if (count > 0)
        {
            DataTable dtmain = new DataTable();
            dtmain.Columns.Add("number");
            for (int i = 0; i < count; i++)
            {
                DataRow drs = dtmain.NewRow();
                drs["number"] = "Screen-" + (i + 1);
                dtmain.Rows.Add(drs);
            }
            DataSet dsmain = new DataSet();
            dsmain.Tables.Add(dtmain);

            grd_dynamic.DataSource = dsmain;
            grd_dynamic.DataBind();
        }
    }

    protected void txt_seatcapcity_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)lnk_view.Parent.Parent;

        TextBox txt_seatcapcity = (TextBox)gvRow.FindControl("txt_seatcapcity");
        TextBox txt_screenfee = (TextBox)gvRow.FindControl("txt_screenfee");
        TextBox txt_totscreenfee = (TextBox)gvRow.FindControl("txt_totscreenfee");
        if (ddllicenseperiod.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select License Period..!');", true);
        }
        else
        {
            if (!string.IsNullOrEmpty(txt_seatcapcity.Text))
            {
                int Capcity = Convert.ToInt32(txt_seatcapcity.Text);
                decimal fee;
                if (Capcity <= 500)
                {
                    fee = 500;
                    decimal screenfee = fee * Convert.ToDecimal(ddllicenseperiod.SelectedValue);
                    txt_screenfee.Text = Convert.ToString(fee);
                    txt_totscreenfee.Text = Convert.ToString(screenfee);
                }
                if (Capcity > 500)
                {
                    fee = 1000;
                    decimal screenfee = fee * Convert.ToDecimal(ddllicenseperiod.SelectedValue);
                    txt_screenfee.Text = Convert.ToString(fee);
                    txt_totscreenfee.Text = Convert.ToString(screenfee);
                }

            }
        }

        totalfeeofseatcapcity();
    }


    void totalfeeofseatcapcity()
    {
        decimal conttot = 0;
        if (grd_dynamic.Rows.Count > 0)
        {
            for (int i = 0; i < grd_dynamic.Rows.Count; i++)
            {
                TextBox txt_totscreenfee = grd_dynamic.Rows[i].FindControl("txt_totscreenfee") as TextBox;
                decimal testcount = 0;

                if (!string.IsNullOrEmpty(txt_totscreenfee.Text))
                {
                    testcount = Convert.ToDecimal(txt_totscreenfee.Text);
                }
                conttot = conttot + testcount;
            }
        }
       // txtapprovalfeecinemalicense.Text = Convert.ToString(conttot);
    }


    protected void btn9BNOC_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

            General t1 = new General();
            if (fup9BNOC.HasFile)
            {
                if ((fup9BNOC.PostedFile != null) && (fup9BNOC.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fup9BNOC.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fup9BNOC.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\9BNOC");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fup9BNOC.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fup9BNOC.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "9BNOC", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "9BNOC");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyper9BNOC.Text = fup9BNOC.FileName;
                                lbl9BNOC.Text = fup9BNOC.FileName;
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

    protected void btnfireoccupancycertificate_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

            General t1 = new General();
            if (fupfireoccupancycertificate.HasFile)
            {
                if ((fupfireoccupancycertificate.PostedFile != null) && (fupfireoccupancycertificate.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupfireoccupancycertificate.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupfireoccupancycertificate.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\fireoccupancycertificate");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupfireoccupancycertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupfireoccupancycertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "fireoccupancycertificate", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "fireoccupancycertificate");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperfireoccupancycertificate.Text = fupfireoccupancycertificate.FileName;
                                lblfireoccupancycertificate.Text = fupfireoccupancycertificate.FileName;
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

    protected void btnGHMCoccupancycertificate_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

            General t1 = new General();
            if (fupGHMCoccupancycertificate.HasFile)
            {
                if ((fupGHMCoccupancycertificate.PostedFile != null) && (fupGHMCoccupancycertificate.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupGHMCoccupancycertificate.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupGHMCoccupancycertificate.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\GHMCoccupancycertificate");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupGHMCoccupancycertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupGHMCoccupancycertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "GHMCoccupancycertificate", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "GHMCoccupancycertificate");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperGHMCoccupancycertificate.Text = fupGHMCoccupancycertificate.FileName;
                                lblGHMCoccupancycertificate.Text = fupGHMCoccupancycertificate.FileName;
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

    protected void btnTSFTCANDTDCNOC_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

            General t1 = new General();
            if (fupTSFTCANDTDCNOC.HasFile)
            {
                if ((fupTSFTCANDTDCNOC.PostedFile != null) && (fupTSFTCANDTDCNOC.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupTSFTCANDTDCNOC.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupTSFTCANDTDCNOC.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\TSFTCANDTDCNOC");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupTSFTCANDTDCNOC.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupTSFTCANDTDCNOC.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "TSFTCANDTDCNOC", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "TSFTCANDTDCNOC");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperTSFTCANDTDCNOC.Text = fupTSFTCANDTDCNOC.FileName;
                                lblTSFTCANDTDCNOC.Text = fupTSFTCANDTDCNOC.FileName;
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

    protected void btnfirmchambernoc_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

            General t1 = new General();
            if (fupfirmchambernoc.HasFile)
            {
                if ((fupfirmchambernoc.PostedFile != null) && (fupfirmchambernoc.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupfirmchambernoc.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupfirmchambernoc.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\firmchambernoc");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupfirmchambernoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupfirmchambernoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "firmchambernoc", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "firmchambernoc");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperfirmchambernoc.Text = fupfirmchambernoc.FileName;
                                lblfirmchambernoc.Text = fupfirmchambernoc.FileName;
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

    protected void btnfirmdivision_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

            General t1 = new General();
            if (fupfirmdivision.HasFile)
            {
                if ((fupfirmdivision.PostedFile != null) && (fupfirmdivision.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupfirmdivision.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupfirmdivision.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\firmdivision");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupfirmdivision.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupfirmdivision.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "firmdivision", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "firmdivision");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperfirmdivision.Text = fupfirmdivision.FileName;
                                lblfirmdivision.Text = fupfirmdivision.FileName;
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

    protected void btnleaseagreement_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

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
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\leaseagreement");

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
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "leaseagreement", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "leaseagreement");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperleaseagreement.Text = fupleaseagreement.FileName;
                                lblleaseagreement.Text = fupleaseagreement.FileName;
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

    protected void btnblueprint_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

            General t1 = new General();
            if (fupblueprint.HasFile)
            {
                if ((fupblueprint.PostedFile != null) && (fupblueprint.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupblueprint.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupblueprint.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\blueprint");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupblueprint.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupblueprint.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "blueprint", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "blueprint");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperblueprint.Text = fupblueprint.FileName;
                                lblblueprint.Text = fupblueprint.FileName;
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

    protected void btnseatingdetails_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

            General t1 = new General();
            if (fupseatingdetails.HasFile)
            {
                if ((fupseatingdetails.PostedFile != null) && (fupseatingdetails.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupseatingdetails.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupseatingdetails.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\seatingdetails");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupseatingdetails.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupseatingdetails.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "seatingdetails", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "seatingdetails");

                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperseatingdetails.Text = fupseatingdetails.FileName;
                                lblseatingdetails.Text = fupseatingdetails.FileName;
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
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (ddlexpyear.SelectedValue == "0" || ddlexpyear.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Status and previous experience of the Applicant \\n";
            slno = slno + 1;
        }
        if (txt9Bfileno.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter 9B File Number of the building granted \\n";
            slno = slno + 1;
        }

        if (txtreferancedate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Date of the Reference in which permission for construction of the building granted \\n";
            slno = slno + 1;
        }
        if (txtlongevitydate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter The Date upto which the certificate of longevity of the building issued by the executive engineer (R&B) is valid \\n";
            slno = slno + 1;
        }

        if (txtelectricalcertificatevaliddate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter The date upto which the Electrical certificate in form -D is Valid \\n";
            slno = slno + 1;
        }

        if (txtfirenocvaliddate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter The date upto which the NOC of Fire Department is Valid \\n";
            slno = slno + 1;
        }
     
        
        if (ddllicenseperiod.SelectedValue == "0" || ddllicenseperiod.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select The period for which the license has to be granted \\n";
            slno = slno + 1;
        }
        if (rbttheatretype.SelectedValue == "" || rbttheatretype.SelectedValue == "null")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Type of Cinema Theatre \\n";
            slno = slno + 1;
        }
        if (txtnoofscreens.Text == ""|| txtnoofscreens.Text=="0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Number of Screens in multiplex \\n";
            slno = slno + 1;
        }
        if (ddlnoofshows.SelectedValue == "0" || ddlnoofshows.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Number of Shows proposed to be screened for single screen/Multiplex \\n";
            slno = slno + 1;
        }
        //if (ddlcommissionerate.SelectedValue == "0" || ddlcommissionerate.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Commissionerate \\n";
        //    slno = slno + 1;
        //}
        //if (ddlzone.SelectedValue == "0" || ddlzone.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Zone \\n";
        //    slno = slno + 1;
        //}
        //if (ddldivision.SelectedValue == "0" || ddldivision.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Division \\n";
        //    slno = slno + 1;
        //}
        //if (ddlpolicestation.SelectedValue == "0" || ddlpolicestation.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Police Station \\n";
        //    slno = slno + 1;
        //}
        //if (ddltrafficzone.SelectedValue == "0" || ddltrafficzone.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Traffic Zone \\n";
        //    slno = slno + 1;
        //}
        //if (ddltrafficdivision.SelectedValue == "0" || ddltrafficdivision.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Traffic Division \\n";
        //    slno = slno + 1;
        //}
        //if (ddltrafficpolicestation.SelectedValue == "0" || ddltrafficpolicestation.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Traffic Police Station \\n";
        //    slno = slno + 1;
        //}

        if (lbl8BNOC.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload 8B NOC. \\n";
            slno = slno + 1;
        }
        if (lbl9BNOC.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload 9B NOC. \\n";
            slno = slno + 1;
        }        

        if (lblfireoccupancycertificate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Fire Occupancy Certificate. \\n";
            slno = slno + 1;
        }

        if (lblGHMCoccupancycertificate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload GHMC Occupancy Certificate. \\n";
            slno = slno + 1;
        }

        if (lblTSFTCANDTDCNOC.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload NOC of TSFTV & TDC. \\n";
            slno = slno + 1;
        }

        if (lblfirmchambernoc.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload NOC of Film Chamber of Commerce. \\n";
            slno = slno + 1;
        }

        if (lblfirmdivision.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Film Division. \\n";
            slno = slno + 1;
        }

        if (lblleaseagreement.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Lease Agreement or any other relavent document. \\n";
            slno = slno + 1;
        }

        if (lblblueprint.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload Blue print of Cinema Theatre/Multiplex with Screens and seating Capacity. \\n";
            slno = slno + 1;
        }

        if (lblseatingdetails.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload 	Details with regard to Screens, seating and Ticket Rates proposed. \\n";
            slno = slno + 1;
        }
                
        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (BtnSave.Text == "Save")
        {
            string errormsg = ValidateControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

            for (int j = 0; j < grd_dynamic.Rows.Count; j++)
            {
                
                TextBox txt_seatcapcity = grd_dynamic.Rows[j].FindControl("txt_seatcapcity") as TextBox;
                TextBox txt_screenfee = grd_dynamic.Rows[j].FindControl("txt_screenfee") as TextBox;
                TextBox txt_totscreenfee = grd_dynamic.Rows[j].FindControl("txt_totscreenfee") as TextBox;
                try
                {
                    Screendetails fromvo = new Screendetails();
                    fromvo.ScreenNO = "Screen_" +j+1 ;
                    fromvo.SeatCapacity = txt_seatcapcity.Text;
                    fromvo.ScreenFee = txt_screenfee.Text;
                    fromvo.TotalFee = txt_totscreenfee.Text;
                    fromvo.Created_By = Session["uid"].ToString();
                    lstscreendetails.Add(fromvo);
                }
                catch (Exception ex)
                {

                }
            }

            int result = 0;
            result = Gen.InsertCinematographicLicenseDetailsRenewal(Request.QueryString[0].ToString(), Request.QueryString[0], ddlexpyear.SelectedValue, txt9Bfileno.Text,
                txtreferancedate.Text, txtlongevitydate.Text, txtelectricalcertificatevaliddate.Text, txtfirenocvaliddate.Text, ddllicenseperiod.SelectedValue,
                rbttheatretype.SelectedValue, txtnoofscreens.Text, ddlnoofshows.SelectedValue, ddlcommissionerate.SelectedValue,
            ddlzone.SelectedValue, ddldivision.SelectedValue, ddlpolicestation.SelectedValue, ddltrafficzone.SelectedValue,
           ddltrafficdivision.SelectedValue, ddltrafficpolicestation.SelectedValue, hdnidentityid.Value, Session["uid"].ToString(), lstscreendetails);

            if (result > 0)
            {
                if (result == 1)
                {
                    lblmsg.Text = "<font color='green'>Cinematographic license Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {
                    success.Visible = true;
                    Failure.Visible = false;
                    lblmsg.Text = "<font color='green'>Cinematographic license Details Updated Successflly..!</font>";
                }
            }
            else
            {

                success.Visible = false;
                Failure.Visible = true;
                lblmsg.Text = "<font color='green'>CFO Cinematographic license Details  Submission Failed..!</font>";

            }

        }


    }
    protected void btnNext0_Click(object sender, EventArgs e)
    {

        //Response.Redirect("frmPowerDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
        Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

        int result = 0;
        result = Gen.InsertCinematographicLicenseDetailsRenewal(Session["ApplidA"].ToString(), Request.QueryString[0], ddlexpyear.SelectedValue, txt9Bfileno.Text,
            txtreferancedate.Text, txtlongevitydate.Text, txtelectricalcertificatevaliddate.Text, txtfirenocvaliddate.Text, ddllicenseperiod.SelectedValue,
            rbttheatretype.SelectedValue, txtnoofscreens.Text, ddlnoofshows.SelectedValue, ddlcommissionerate.SelectedValue,
        ddlzone.SelectedValue, ddldivision.SelectedValue, ddlpolicestation.SelectedValue, ddltrafficzone.SelectedValue,
       ddltrafficdivision.SelectedValue, ddltrafficpolicestation.SelectedValue, hdnidentityid.Value, Session["uid"].ToString(), lstscreendetails);

        if (result > 0)
        {
            if (result == 1)
            {
                Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                lblmsg.Text = "<font color='green'>CFO Cinematographic license Details Saved Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;

            }
            else
            {
                Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "<font color='green'>CFO Cinematographic license Details Updated Successflly..!</font>";
            }
        }
        else
        {

            success.Visible = false;
            Failure.Visible = true;
            lblmsg.Text = "<font color='green'>CFO Cinematographic license Details  Submission Failed..!</font>";

        }

    }
    //public void BindScreenDetails()
    //{
    //    DataSet dsdetails = new DataSet();
    //   dsdetails = GetScreenDetails(Session["Applid"].ToString());
    //    if (dsdetails.Tables[0].Rows.Count > 0)
    //    {
    //        int screencount = 0;
    //        if (!string.IsNullOrEmpty(Convert.ToString(dsdetails.Tables[0].Rows[0]["Noofscreens"])))
    //        {
    //            screencount = Convert.ToInt32(dsdetails.Tables[0].Rows[0]["Noofscreens"]);
    //        }
    //        if (screencount == 1)
    //        {
    //            rbttheatretype.SelectedValue = "Y";
    //            txtnoofscreens.Text = Convert.ToString(screencount);
    //        }
    //        else
    //        {
    //            rbttheatretype.SelectedValue = "N";
    //            txtnoofscreens.Text = Convert.ToString(screencount);
    //        }
    //        ddllicenseperiod.SelectedValue = Convert.ToString(dsdetails.Tables[0].Rows[0]["LicensePeriod"]);
    //    }
    //}
    public DataSet GetScreenDetails(string quessionniarecfoid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@intQuessionaireCFOid",SqlDbType.VarChar)
        };
        pp[0].Value = quessionniarecfoid;
        Dsnew = Gen.GenericFillDs("GetFeeandSceenDetailsbyid", pp);
        return Dsnew;
    }
    public void BindExperienceYears()
    {
        DataSet dsexp = new DataSet();
        dsexp = GetEXpYearscinema();
        if (dsexp.Tables[0].Rows.Count > 0)
        {
            ddlexpyear.DataSource = dsexp.Tables[0];
            ddlexpyear.DataTextField = "noofexpyears";
            ddlexpyear.DataValueField = "expyearsid";
            ddlexpyear.DataBind();

            ddlexpyear.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetEXpYearscinema()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GetEXpYears_cinema");
        return Dsnew;
    }
    public void BindCommissionerates()
    {
        DataSet dscommission = new DataSet();
        dscommission = GetCommissionerates();
        if (dscommission.Tables[0].Rows.Count > 0)
        {
            ddlcommissionerate.DataSource = dscommission.Tables[0];
            ddlcommissionerate.DataTextField = "Commissionerate_Name";
            ddlcommissionerate.DataValueField = "Commissionerate_Id";
            ddlcommissionerate.DataBind();

            ddlcommissionerate.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetCommissionerates()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GETCOMMISSIONERATES");
        return Dsnew;
    }
    protected void ddlcommissionerate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dszone = new DataSet();
        dszone = GetZones(ddlcommissionerate.SelectedValue);
        if (dszone.Tables[0].Rows.Count > 0)
        {
            ddlzone.DataSource = dszone.Tables[0];
            ddlzone.DataTextField = "zone_name";
            ddlzone.DataValueField = "zone_id";
            ddlzone.DataBind();

            ddlzone.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        DataSet dstrafficzone = new DataSet();
        dstrafficzone = GetTrafficZones(ddlcommissionerate.SelectedValue);
        if (dstrafficzone.Tables[0].Rows.Count > 0)
        {
            ddltrafficzone.DataSource = dstrafficzone.Tables[0];
            ddltrafficzone.DataTextField = "Traffic_zone_name";
            ddltrafficzone.DataValueField = "Traffic_zone_id";
            ddltrafficzone.DataBind();

            ddltrafficzone.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetZones(string commissionerateid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATEID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        Dsnew = Gen.GenericFillDs("GETZONES", pp);
        return Dsnew;
    }
    public DataSet GetTrafficZones(string commissionerateid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATE_ID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        Dsnew = Gen.GenericFillDs("GETTRAFFICZONES", pp);
        return Dsnew;
    }

    protected void ddlzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsdivision = new DataSet();
        dsdivision = GetDivisions(ddlzone.SelectedValue);
        if (dsdivision.Tables[0].Rows.Count > 0)
        {
            ddldivision.DataSource = dsdivision.Tables[0];
            ddldivision.DataTextField = "division_name";
            ddldivision.DataValueField = "division_id";
            ddldivision.DataBind();

            ddldivision.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetDivisions(string zoneid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@ZONEID",SqlDbType.VarChar)
        };
        pp[0].Value = zoneid;
        Dsnew = Gen.GenericFillDs("GETDIVISIONS", pp);
        return Dsnew;
    }

    protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet dspolice = new DataSet();
        dspolice = GetPoliceStatioons(ddlcommissionerate.SelectedValue, ddldivision.SelectedValue);
        if (dspolice.Tables[0].Rows.Count > 0)
        {
            ddlpolicestation.DataSource = dspolice.Tables[0];
            ddlpolicestation.DataTextField = "policestation_name";
            ddlpolicestation.DataValueField = "policestation_id";
            ddlpolicestation.DataBind();

            ddlpolicestation.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetPoliceStatioons(string commissionerateid, string divisionid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATE_ID",SqlDbType.VarChar),
             new SqlParameter("@DIVISION_ID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        pp[1].Value = divisionid;
        Dsnew = Gen.GenericFillDs("GETPOLICESTATIONS", pp);
        return Dsnew;
    }

    protected void ddltrafficzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dstrafficdivision = new DataSet();
        dstrafficdivision = GetTrafficDivisions(ddltrafficzone.SelectedValue);
        if (dstrafficdivision.Tables[0].Rows.Count > 0)
        {
            ddltrafficdivision.DataSource = dstrafficdivision.Tables[0];
            ddltrafficdivision.DataTextField = "Traffic_division_name";
            ddltrafficdivision.DataValueField = "Traffic_division_id";
            ddltrafficdivision.DataBind();

            ddltrafficdivision.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetTrafficDivisions(string trafficzoneid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@TRAFFICZONE_ID",SqlDbType.VarChar)
        };
        pp[0].Value = trafficzoneid;
        Dsnew = Gen.GenericFillDs("GETTRAFFICDIVISIONS", pp);
        return Dsnew;
    }

    protected void ddltrafficdivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dspolice = new DataSet();
        dspolice = GetTrafficPoliceStatioons(ddlcommissionerate.SelectedValue, ddltrafficdivision.SelectedValue);
        if (dspolice.Tables[0].Rows.Count > 0)
        {
            ddltrafficpolicestation.DataSource = dspolice.Tables[0];
            ddltrafficpolicestation.DataTextField = "Traffic_policestation_name";
            ddltrafficpolicestation.DataValueField = "Traffic_policestation_id";
            ddltrafficpolicestation.DataBind();

            ddltrafficpolicestation.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetTrafficPoliceStatioons(string commissionerateid, string trafficdivisionid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATE_ID",SqlDbType.VarChar),
             new SqlParameter("@TRAFFICDIVISION_ID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        pp[1].Value = trafficdivisionid;
        Dsnew = Gen.GenericFillDs("GETTRAFFICPOLICESTATIONS", pp);
        return Dsnew;
    }
}