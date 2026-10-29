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

public partial class UI_TSiPASS_frmMiningDetails : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    static DataTable dtMyTable;
    static DataTable dtMyTableCertificate;
    List<minerals> lstminerals = new List<minerals>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                dtMyTableCertificate = createtablecrtificate();
                Session["CertificateTb2"] = dtMyTableCertificate;
            }
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            //DataSet dsver = new DataSet();

            //dsver = Gen.Getverifyofque5(Session["Applid"].ToString());

            //if (dsver.Tables[0].Rows.Count > 0)
            //{
            //    string res = Gen.RetriveStatus(Session["Applid"].ToString());
            //    ////string res = Gen.RetriveStatus("1002");


            //    if (res == "3" || Convert.ToInt32(res) >= 3)
            //    {
            //        ResetFormControl(this);
            //    }

            //}


            // }
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();

            dsnew = Gen.getdataofidentity(Session["Applid"].ToString(), "424");

            if (dsnew.Tables[0].Rows.Count > 0)
            {

            }
            //else
            //{

            //    if (Request.QueryString[1].ToString() == "N")
            //    {

            //        Response.Redirect("frmattachmentdetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

            //    }

            //    else
            //    {

            //        Response.Redirect("frmprofessiontax.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

            //    }
            //}


        }

       



        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {
                BindRequestDays();
                BindLandCategoeries();
                FillDetails();
            }
        }
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }

        if (!IsPostBack)
        {
            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque5(Session["Applid"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatus(Session["Applid"].ToString());
                ////string res = Gen.RetriveStatus("1002");


                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    foreach (GridViewRow row in gvCertificate.Rows)
                    {
                        DataControlFieldCell editable = (DataControlFieldCell)row.Controls[0];
                        editable.Enabled = false;
                    }
                    if (gvCertificate.Rows.Count > 0)
                    {
                        BtnSave2.Enabled = false;
                    }
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

            ds = Gen.RetriveMiningData(hdfFlagID0.Value.ToString());


            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnid.Value= Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    gvCertificate.DataSource = ds.Tables[1];
                    gvCertificate.DataBind();
                    // Session["CertificateTb2"] = ds.Tables[1];
                }
                ddlApplicanttype.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Application_type"]);
                if(ds.Tables[0].Rows[0]["Application_type"].ToString()=="2")
                {
                    ddlprofessiontype.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["profession_type"]);
                }
                else
                {
                    ddlprofessiontype.SelectedItem.Text = "--Select--";
                }
                txtgst.Text = Convert.ToString(ds.Tables[0].Rows[0]["Gst_number"].ToString().Trim());
                ddlrequestdays.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["Request_days"].ToString().Trim());
                ddlregionaloffice.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["Regional_office"].ToString().Trim());
                ddllandcategoery.SelectedValue=Convert.ToString(ds.Tables[0].Rows[0]["Land_categoery"].ToString().Trim());
                if (ds.Tables[0].Rows[0]["Land_categoery"].ToString() == "3")
                {
                    trdivision.Visible = true;
                    trrange.Visible = true;
                    trcompartmentno.Visible = true;
                    txtcompartmentnumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["compartment_no"].ToString().Trim());
                    txtdivision.Text = Convert.ToString(ds.Tables[0].Rows[0]["division"].ToString().Trim());
                    txtrangge.Text = Convert.ToString(ds.Tables[0].Rows[0]["range"].ToString().Trim());
                }
            }
            DataSet dsattachment = new DataSet();
            dsattachment = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

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

                    if (sen.Contains("ApplicantPhoto"))
                    {
                        hyperapplntphoto.NavigateUrl = sen;
                            hyperapplntphoto.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblapplntpohoto.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("LandDocment"))
                    {
                        Hyperlanddocument.NavigateUrl = sen;
                            Hyperlanddocument.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lbllanddocument.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("OtherDocuments"))
                    {
                        hyperotherdocuments.NavigateUrl = sen;
                            hyperotherdocuments.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblotherdocuments.Text = dsattachment.Tables[0].Rows[i][1].ToString();
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
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (ddlApplicanttype.SelectedValue == "0" || ddlApplicanttype.SelectedItem.Text == "Select")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Applicant Type. \\n";
            slno = slno + 1;
        }
        if(ddlApplicanttype.SelectedValue=="2")
        {
            if(ddlprofessiontype.SelectedValue=="0"||ddlprofessiontype.SelectedValue== "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Profession Type. \\n";
                slno = slno + 1;
            }
        }
        if(txtgst.Text=="")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter GST number  \\n";
            slno = slno + 1;
        }
        if (ddlrequestdays.SelectedValue == "--Select--" || ddlrequestdays.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Request Days. \\n";
            slno = slno + 1;
        }
        if (ddlregionaloffice.SelectedValue == "0" || ddlregionaloffice.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Regional office \\n";
            slno = slno + 1;
        }
        if (ddllandcategoery.SelectedValue == "0" || ddllandcategoery.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select land categoery. \\n";
            slno = slno + 1;
        }
        if(ddllandcategoery.SelectedValue=="3")
        {
            if(txtcompartmentnumber.Text=="")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter compartment number. \\n";
                slno = slno + 1;
            }
            if (txtdivision.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter division . \\n";
                slno = slno + 1;
            }
            if (txtrangge.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter range . \\n";
                slno = slno + 1;
            }
           
        }
        if (lblapplntpohoto.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please upload applicant photo(In JPG/JPEG format) . \\n";
            slno = slno + 1;
        }

        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (BtnSave1.Text == "Save")
        {
            string errormsg = ValidateControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            if (gvCertificate.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter mineral details and Click add new Button </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            lstminerals.Clear();
            foreach (GridViewRow gvrow in gvCertificate.Rows)
            {
                minerals fromvo = new minerals();
                int rowIndex = gvrow.RowIndex;
                fromvo.mineralid = ((Label)gvrow.FindControl("lblmineralid")).Text.ToString();
                fromvo.mineral = gvCertificate.Rows[rowIndex].Cells[1].Text;
                fromvo.quantity = gvCertificate.Rows[rowIndex].Cells[2].Text;
                fromvo.unitid= ((Label)gvrow.FindControl("lblunitsid")).Text.ToString();
                fromvo.units = gvCertificate.Rows[rowIndex].Cells[3].Text;
                fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                fromvo.Created_By = Session["uid"].ToString();
                lstminerals.Add(fromvo);
            }
            

                int result = 0;
                
                result = Gen.InsertMiningDetails( Session["Applid"].ToString(), Request.QueryString[0].ToString(),ddlApplicanttype.SelectedValue,ddlprofessiontype.SelectedValue,
                    txtgst.Text.ToString(),ddlrequestdays.SelectedValue,ddlregionaloffice.SelectedValue,ddllandcategoery.SelectedValue,txtcompartmentnumber.Text.ToString(),txtdivision.Text.ToString(),txtrangge.Text.ToString(),
               hdnid.Value,Session["uid"].ToString(),  Session["uid"].ToString(),  lstminerals);
                if (result > 0)
                {
                if (hdnid.Value == "0" || hdnid.Value == "null")
                {
                    //ResetFormControl(this);
                    lblmsg.Text = "<font color='green'>mining Details Saved Successfully..!</font>";
                    //  this.Clear();
                    BtnSave1.Enabled = false;
                    success.Visible = true;
                    Failure.Visible = false;
                }
                else
                {
                    lblmsg.Text = "<font color='green'>mining Details updated Successfully..!</font>";
                    //  this.Clear();
                    BtnSave1.Enabled = false;
                    success.Visible = true;
                    Failure.Visible = false;
                }
                // by rajinikar
                DataSet dsdatenew = new DataSet();
                dsdatenew = Gen.RetriveMiningData(hdfFlagID0.Value.ToString());


                if (dsdatenew.Tables[0].Rows.Count > 0)
                {
                    if (dsdatenew != null && dsdatenew.Tables.Count > 1 && dsdatenew.Tables[1].Rows.Count > 0)
                    {
                        gvCertificate.DataSource = dsdatenew.Tables[1];
                        gvCertificate.DataBind();
                    }
                }
                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                //fillNews(userid);
            }
                //else if (result == 0)
                //{

                //    lblmsg.Text = "<font color='green'>Fire Details updated Successfully..!</font>";
                //    //this.Clear();
                //    success.Visible = true;
                //    Failure.Visible = false;

                //}

                else
                {
                    lblmsg0.Text = "<font color='red'>Fire Details Submission Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }

            }
           
        

        
    }
    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
            this.gvCertificate.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();

        }
        finally
        {

        }
    }
    public string ValidateMineralControls()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (ddlmineral.SelectedValue == "0" || ddlmineral.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Mineral Type. \\n";
            slno = slno + 1;
        }
        
        if (txtestimatedquantity.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Estimated Qantity\\n";
            slno = slno + 1;
        }
        if (ddlunits.SelectedValue == "--Select--" || ddlunits.SelectedValue == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select units. \\n";
            slno = slno + 1;
        }
        

        return ErrorMsg;
    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        string errormsg = ValidateMineralControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        
        gvCertificate.Visible = true;
        try
        {
            AddDataToTableCeertificate(ddlmineral.SelectedItem.Text, txtestimatedquantity.Text, ddlmineral.SelectedValue, ddlunits.SelectedItem.Text, ddlunits.SelectedValue, (DataTable)Session["CertificateTb2"]);
            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
            this.gvCertificate.DataBind();
            lblmsg.Text = "";
            ddlmineral.ClearSelection();
            ddlunits.ClearSelection();
            txtestimatedquantity.Text = "";
        }
        catch (Exception ee)
        {
            ////lbldtvalid.Text = "Please enter correct Date.";
            ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
        }

        gvCertificate.Visible = true;
    }
    private void AddDataToTableCeertificate(string mineral, string estimatedquantity, string mineralid, string units, string unitid, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");
            Row["Minerals"] = mineral;
            Row["Quantity"] = estimatedquantity;
            Row["MineralId"] = mineralid;
            Row["Units"] = units;
            Row["Unitsid"] = unitid;
            Row["id"] = "";
            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("Minerals", typeof(string));
        dtMyTable.Columns.Add("Quantity", typeof(string));
        dtMyTable.Columns.Add("MineralId", typeof(string));
        dtMyTable.Columns.Add("Units", typeof(string));
        dtMyTable.Columns.Add("Unitsid", typeof(string));
        dtMyTable.Columns.Add("id", typeof(string));

        return dtMyTable;
    }
    public void BindRequestDays()
    {
        DataSet dsreqdays = new DataSet();
        dsreqdays = GetRequestDays();
        if (dsreqdays.Tables[0].Rows.Count > 0)
        {
            ddlrequestdays.DataSource = dsreqdays.Tables[0];
            ddlrequestdays.DataTextField = "RequestDays_count";
            ddlrequestdays.DataValueField = "RequestDaysID";
            ddlrequestdays.DataBind();

            ddlrequestdays.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    public DataSet GetRequestDays()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GetRequestDays");
        return Dsnew;
    }
    public void BindLandCategoeries()
    {
        DataSet dsland = new DataSet();
        dsland = GetLandCategoeries();
        if (dsland.Tables[0].Rows.Count > 0)
        {
            ddllandcategoery.DataSource = dsland.Tables[0];
            ddllandcategoery.DataTextField = "landcategorytype";
            ddllandcategoery.DataValueField = "Landcategoryid";
            ddllandcategoery.DataBind();

            ddllandcategoery.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    public DataSet GetLandCategoeries()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GetLandCategories");
        return Dsnew;
    }
    protected void ddlApplicanttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if(ddlApplicanttype.SelectedValue=="2")
        {
            trprofessiontype.Visible = true;
            DataSet ds = new DataSet();
            ds = GetProfessiontypebyApplicanttypeId(ddlApplicanttype.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlprofessiontype.DataSource = ds.Tables[0];
                ddlprofessiontype.DataTextField = "professiontype";
                ddlprofessiontype.DataValueField = "Professionid";
                ddlprofessiontype.DataBind();

                ddlprofessiontype.Items.Insert(0, new ListItem("Select", "0"));

            }
        }
        else
        {
            trprofessiontype.Visible = false;
        }
    }
    public DataSet GetProfessiontypebyApplicanttypeId(string applicanttypeid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@ApplicanttypeID",SqlDbType.VarChar)
    };
        pp[0].Value = applicanttypeid;
        Dsnew = Gen.GenericFillDs("GetProfessionTypebyApplicanttypeID", pp);
        return Dsnew;
    }

    protected void ddllandcategoery_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddllandcategoery.SelectedValue=="1"|| ddllandcategoery.SelectedValue == "2" || ddllandcategoery.SelectedValue == "4")
        {
            trdivision.Visible = false;
            trrange.Visible = false;
            trcompartmentno.Visible = false;
            txtdivision.Text = "";
            txtrangge.Text = "";
            txtcompartmentnumber.Text = "";
        }
        if(ddllandcategoery.SelectedValue=="3")
        {
            trdivision.Visible = true;
            trrange.Visible = true;
            trcompartmentno.Visible = true;
            txtdivision.Text = "";
            txtrangge.Text = "";
            txtcompartmentnumber.Text = "";
        }
    }

    protected void btnapplntphoto_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if ((fupapplntphoto.PostedFile != null) && (fupapplntphoto.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fupapplntphoto.PostedFile.FileName);
            try
            {
                string[] fileType = fupapplntphoto.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\ApplicantPhoto");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fupapplntphoto.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fupapplntphoto.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "ApplicantPhoto", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hyperapplntphoto.Text = fupapplntphoto.FileName;
                        lblapplntpohoto.Text = fupapplntphoto.FileName;
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
  

    protected void btnlanddocument_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if ((fuplanddocument.PostedFile != null) && (fuplanddocument.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fuplanddocument.PostedFile.FileName);
            try
            {
                string[] fileType = fuplanddocument.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\LandDocment");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fuplanddocument.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fuplanddocument.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "LandDocument", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Hyperlanddocument.Text = fuplanddocument.FileName;
                        lbllanddocument.Text = fuplanddocument.FileName;
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

    protected void btnotherdocuments_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if ((fupotherdocments.PostedFile != null) && (fupotherdocments.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fupotherdocments.PostedFile.FileName);
            try
            {
                string[] fileType = fupotherdocments.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\OtherDocuments");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fupotherdocments.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fupotherdocments.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "OtherDocments", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hyperotherdocuments.Text = fupotherdocments.FileName;
                        lblotherdocuments.Text = fupotherdocments.FileName;
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
}