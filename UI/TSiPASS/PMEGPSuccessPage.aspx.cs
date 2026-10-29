using System;
using System.Activities.Statements;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

//using static TSIPASSPropertiesModel;

public partial class UI_TSiPASS_PMEGPSuccessPage : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        if (!IsPostBack)
        {
            InitializeDataTable();
            BindDistricts();
            //ValidateLandControls();
        }
        btnPrint.Visible = false;

        if (!IsPostBack)
        {
            ddlEducation.Items.Add(new ListItem("--Select--", "0"));
            ddlEducation.Items.Add(new ListItem("10ᵗʰ", "1"));
            ddlEducation.Items.Add(new ListItem("Inter/Diploma", "2"));
            ddlEducation.Items.Add(new ListItem("Degree", "3"));
            ddlEducation.Items.Add(new ListItem("Graduate", "4"));
            ddlEducation.Items.Add(new ListItem("Post Graduate", "5"));
            ddlEducation.Items.Add(new ListItem("Others", "6"));
        }
        if (!IsPostBack)
        {
            ddlSpecialCategory.Items.Add(new ListItem("--Select--", "0"));
            ddlSpecialCategory.Items.Add(new ListItem("WOMEN", "1"));
            ddlSpecialCategory.Items.Add(new ListItem("EX-SERVICE MAN", "2"));
            ddlSpecialCategory.Items.Add(new ListItem("PHYSCIALLY HANDICAPPED", "3"));
            ddlSpecialCategory.Items.Add(new ListItem("TRANSGENDER", "4"));
            ddlSpecialCategory.Items.Add(new ListItem("None", "5"));
        }
        if (!IsPostBack)
        {
            ddlCaste.Items.Add(new ListItem("--Select--", "0"));
            ddlCaste.Items.Add(new ListItem("General", "1"));
            ddlCaste.Items.Add(new ListItem("OBC", "2"));
            ddlCaste.Items.Add(new ListItem("SC", "3"));
            ddlCaste.Items.Add(new ListItem("ST", "4"));
            ddlCaste.Items.Add(new ListItem("Minor", "5"));
        }
    }
    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistric.Items.Clear();
            dsd = gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistric.DataSource = dsd.Tables[0];
                ddlProp_intDistric.DataValueField = "District_Id";
                ddlProp_intDistric.DataTextField = "District_Name";
                ddlProp_intDistric.DataBind();
                ddlProp_intDistric.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlProp_intDistric.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
            //Response.Write(ex);
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void GVFamily_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["MyDataTable"];

        if (dt.Rows.Count > 0 && e.RowIndex < dt.Rows.Count)
        {
            dt.Rows.RemoveAt(e.RowIndex);

            GVFamily.DataSource = dt;
            GVFamily.DataBind();
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        InitializeDataTable();
        DropDownList1.SelectedIndex = 0;
        txtName.Text = "";
        TextBox1.Text = "";
        //   txtProfession.Text = "";
        txtProfession.SelectedIndex = 0;
    }

    protected void btnaddfamily_Click(object sender, EventArgs e)
    {
        //if(DropDownList1.SelectedValue=="0")
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please select Relation Type in Family Details Section.');", true);
        //    return;
        //}
        //if(txtName.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Name in Family Details Section.');", true);
        //    return;
        //}
        //if (TextBox1.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Age in Family Details Section.');", true);
        //    return;
        //}
        //if (txtProfession.SelectedValue == "0")
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Age in Profession Details Section.');", true);
        //    return;
        //}
        //DataTable dt = (DataTable)ViewState["MyDataTable"];
        //if(DropDownList1.SelectedValue == "0")
        //{
        //    GVFamily.DataSource = null;
        //    GVFamily.Visible = false;
        //}
        //else if (DropDownList1.SelectedValue != "0")
        //{
        if (DropDownList1.SelectedItem.Text != "--Select--" && TextBox1.Text != "" && txtName.Text != "" && txtProfession.SelectedItem.Text != "--Select--")
        {
            DataTable dt = (DataTable)ViewState["MyDataTable"];
            DataRow newRow = dt.NewRow();
            newRow["DropDownList1"] = DropDownList1.SelectedItem.Text;
            newRow["txtName"] = txtName.Text;
            newRow["TextBox1"] = TextBox1.Text;
            newRow["txtProfession"] = txtProfession.SelectedItem.Text;
            dt.Rows.Add(newRow);

            GVFamily.DataSource = dt;
            GVFamily.DataBind();
            GVFamily.Visible = true;
            gridview();
            DropDownList1.ClearSelection();
            TextBox1.Text = ""; txtName.Text = "";
            txtProfession.ClearSelection();
            DropDownList1.Focus();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter  All Family Details.');", true);
            //return;
        }

        //if (DropDownList1.SelectedItem.Text != "--Select--")
        //{
        //    DropDownList1.SelectedItem.Text = "--Select--";
        //    TextBox1.Text = "";
        //    txtProfession.SelectedItem.Text = "--Select--";
        //    DropDownList1.Focus();
        //}

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (fileUploadControl.HasFile && fileUpload1.HasFile && fileUploadControl.PostedFile.ContentType == "image/jpeg" && fileUpload1.PostedFile.ContentType == "image/jpeg")
        {
            //string fileName1 = Path.GetFileName(fileUploadControl.FileName);
            //string contentType1 = fileUploadControl.PostedFile.ContentType;

            //byte[] fileData1;
            //using (Stream inputStream = fileUploadControl.PostedFile.InputStream)
            //{
            //    using (MemoryStream memoryStream = new MemoryStream())
            //    {
            //        inputStream.CopyTo(memoryStream);
            //        fileData1 = memoryStream.ToArray();
            //    }
            //}

            //string fileName2 = Path.GetFileName(fileUpload1.FileName);
            //string contentType2 = fileUpload1.PostedFile.ContentType;

            //byte[] fileData2;
            //using (Stream inputStream = fileUpload1.PostedFile.InputStream)
            //{
            //    using (MemoryStream memoryStream = new MemoryStream())
            //    {
            //        inputStream.CopyTo(memoryStream);
            //        fileData2 = memoryStream.ToArray();
            //    }
            //}

            //string uploadDirectory = Server.MapPath("~/Uploads/");

            //if (!Directory.Exists(uploadDirectory))
            //{
            //    Directory.CreateDirectory(uploadDirectory);
            //}

            //string filePath1 = Path.Combine(uploadDirectory, fileName1);
            //File.WriteAllBytes(filePath1, fileData1);

            //string filePath2 = Path.Combine(uploadDirectory, fileName2);
            //File.WriteAllBytes(filePath2, fileData2);
            //!string.IsNullOrEmpty(txtatendprgrm.Text)
            string Errormsg = "";
            Errormsg = ValidateLandControls();

            //if (!string.IsNullOrEmpty(aplicantname.Text) && !string.IsNullOrEmpty(txtfname.Text) && ddlCaste.SelectedItem != null && !string.IsNullOrEmpty(txtage.Text) && ddlEducation.SelectedItem != null &&
            //ddlSpecialCategory.SelectedItem != null && !string.IsNullOrEmpty(txthno.Text) && !string.IsNullOrEmpty(txtstreet.Text) && ddlProp_intVillageid.SelectedItem !=null && ddlProp_intMandalid.SelectedItem !=null &&
            //ddlProp_intDistric.SelectedItem !=null && RadioButton.SelectedItem != null && !string.IsNullOrEmpty(txtpannber.Text) && !string.IsNullOrEmpty(txtrgnumber.Text) && !string.IsNullOrEmpty(txtrcnmber.Text) &&
            //!string.IsNullOrEmpty(txtpnenmber.Text) && !string.IsNullOrEmpty(txtmail.Text) && !string.IsNullOrEmpty(txtedpcerticte.Text) && txtatendprgrm.SelectedItem !=null&& !string.IsNullOrEmpty(txtatendprgrm1.Text) && txtedpcerticte1.SelectedItem !=null && !string.IsNullOrEmpty(txtedpcerticte.Text)&&
            //!string.IsNullOrEmpty(txtuitname.Text) && !string.IsNullOrEmpty(txtloakvt.Text) && !string.IsNullOrEmpty(txtpname.Text) && !string.IsNullOrEmpty(txtprodctonpa.Text) && ddl_Units.SelectedItem !=null && !string.IsNullOrEmpty(txtDateOfCommencement.Text) &&
            //!string.IsNullOrEmpty(txtemlynt.Text) && !string.IsNullOrEmpty(hfInvestment.Value) && !string.IsNullOrEmpty(txtbenfryctrion.Text) && !string.IsNullOrEmpty(txtbkloan.Text) &&
            //!string.IsNullOrEmpty(txtsubclaim.Text) && !string.IsNullOrEmpty(txtmmadjsmts.Text) && !string.IsNullOrEmpty(txtanalsales.Text) && !string.IsNullOrEmpty(txtannalprfit.Text) &&
            //txtrepament.SelectedItem !=null  && !string.IsNullOrEmpty(txtDate.Text) && !string.IsNullOrEmpty(TextBox2.Text) && !string.IsNullOrEmpty(TextBox3.Text) && !string.IsNullOrEmpty(TextBox4.Text) &&
            //!string.IsNullOrEmpty(TextBox5.Text) && !string.IsNullOrEmpty(TextBox6.Text) && !string.IsNullOrEmpty(TextBox7.Text) && ddlVehicleBefore.SelectedItem != null && ddlVehicleAfter.SelectedItem != null &&
            //ddlhealthbefore.SelectedItem != null && ddlhealthafter.SelectedItem != null && ddlchildeducationbefore.SelectedItem != null && ddlchildeducationafter.SelectedItem != null && fileUploadControl.HasFile && fileUpload1.HasFile)
            if (Errormsg != "")
            {
                DataTable PMEGP_DATA = new DataTable();
                DataTable dt = (DataTable)ViewState["MyDataTable"];
                int PmegpID;
                ClearErrorClasses();

                con.OpenConnection();
                using (SqlCommand command = new SqlCommand("DataBind_tbl_PMEGP", con.GetConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicantName", aplicantname.Text);
                    command.Parameters.AddWithValue("@FatherorSpouseName", txtfname.Text);
                    command.Parameters.AddWithValue("@Age", txtage.Text);
                    command.Parameters.AddWithValue("@Educationalqualifiaction", ddlEducation.SelectedItem.Text);
                    command.Parameters.AddWithValue("@SpecialCategory", ddlSpecialCategory.SelectedItem.Text);
                    command.Parameters.AddWithValue("@caste", ddlCaste.SelectedItem.Text);
                    command.Parameters.AddWithValue("@District", ddlProp_intDistric.SelectedItem.Text);
                    command.Parameters.AddWithValue("@Mandalmunicipality", ddlProp_intMandalid.SelectedItem.Text);
                    command.Parameters.AddWithValue("@VillageWard", ddlProp_intVillageid.SelectedItem.Text);
                    command.Parameters.AddWithValue("@HNO", txthno.Text);
                    command.Parameters.AddWithValue("@Street", txtstreet.Text);
                    command.Parameters.AddWithValue("@AreaorRegion", RadioButton.SelectedItem.Text);
                    command.Parameters.AddWithValue("@Aadharnumber", txtadhar.Text.Replace("-", ""));
                    command.Parameters.AddWithValue("@Pannumber", txtpannber.Text);
                    command.Parameters.AddWithValue("@Udayamregisternumber", txtrgnumber.Text);
                    command.Parameters.AddWithValue("@Rationcradnumber", txtrcnmber.Text);
                    command.Parameters.AddWithValue("@Contactnumber", txtpnenmber.Text);
                    command.Parameters.AddWithValue("@Emailid", txtmail.Text);
                    command.Parameters.AddWithValue("@PMEGP_ID_TSIPASS", PMEGP_ID_TSIPASS.Text);
                    command.Parameters.AddWithValue("@EDPcertifiacte", txtedpcerticte1.SelectedItem.Text);
                    //  command.Parameters.AddWithValue("@EDPcertifiacte",  txtedpcerticte1.SelectedItem.Text);
                    command.Parameters.AddWithValue("@EDP_Details", txtedpcerticte.Text);
                    command.Parameters.AddWithValue("@Anyotherprograms", txtatendprgrm.SelectedValue);
                    command.Parameters.AddWithValue("@Othertraining", txtatendprgrm1.Text);
                    command.Parameters.AddWithValue("@Unitname", txtuitname.Text);
                    command.Parameters.AddWithValue("@Lineofactivity", txtloakvt.Text);
                    command.Parameters.AddWithValue("@productname", txtpname.Text);
                    command.Parameters.AddWithValue("@productionPA", txtprodctonpa.Text);
                    command.Parameters.AddWithValue("@Units", ddl_Units.SelectedItem.Text);
                    command.Parameters.AddWithValue("@U_other", txtUnits.Text);
                    command.Parameters.AddWithValue("@Dateofcommencementproduction", (txtDateOfCommencement.Text).ToString());
                    command.Parameters.AddWithValue("@Employement", txtemlynt.Text);
                    command.Parameters.AddWithValue("@Investment", hfInvestment.Value);
                    command.Parameters.AddWithValue("@Bankloan", txtbkloan.Text);
                    command.Parameters.AddWithValue("@Benificarycontribution", txtbenfryctrion.Text);
                    command.Parameters.AddWithValue("@Subsidyclaim", txtsubclaim.Text);
                    command.Parameters.AddWithValue("@Mmadjustments", txtmmadjsmts.Text);
                    command.Parameters.AddWithValue("@Annualsales", txtanalsales.Text);
                    command.Parameters.AddWithValue("@Annualprofit", txtannalprfit.Text);
                    command.Parameters.AddWithValue("@Loanrepaymentcompleted", txtrepament.SelectedValue);
                    command.Parameters.AddWithValue("@Physicalvericationdate", (txtDate.Text).ToString());
                    command.Parameters.AddWithValue("@B_Assetvalue", TextBox2.Text);
                    command.Parameters.AddWithValue("@A_Assetvalue", TextBox3.Text);
                    command.Parameters.AddWithValue("@B_House", TextBox4.Text);
                    command.Parameters.AddWithValue("@A_House", TextBox5.Text);
                    command.Parameters.AddWithValue("@B_Land", TextBox6.Text);
                    command.Parameters.AddWithValue("@A_Land", TextBox7.Text);
                    command.Parameters.AddWithValue("@B_Vehicles", ddlVehicleBefore.SelectedItem.Text);
                    command.Parameters.AddWithValue("@A_Vehicles", ddlVehicleAfter.SelectedItem.Text);
                    command.Parameters.AddWithValue("@B_Health", ddlhealthbefore.SelectedItem.Text);
                    command.Parameters.AddWithValue("@A_Health", ddlhealthafter.SelectedItem.Text);
                    command.Parameters.AddWithValue("@B_Childreneducation", ddlchildeducationbefore.SelectedItem.Text);
                    command.Parameters.AddWithValue("@A_Childreneducation", ddlchildeducationafter.SelectedItem.Text);
                    command.Parameters.AddWithValue("@B_Reinvestments", TextBox14.Text);
                    command.Parameters.AddWithValue("@A_Reinvestments", TextBox15.Text);
                    //  command.Parameters.AddWithValue("@OtherEDP", txtedpcerticte.Text);
                    //command.Parameters.AddWithValue("@FileName", fileName1);
                    //command.Parameters.AddWithValue("@ContentType", contentType1);
                    //command.Parameters.AddWithValue("@Applicantphoto", filePath1);
                    //command.Parameters.AddWithValue("@Unit_FileName", fileName2);
                    //command.Parameters.AddWithValue("@Unit_ContentType", contentType2);
                    //command.Parameters.AddWithValue("@UnitPhoto", filePath2);
                    command.Parameters.AddWithValue("@Createdby", Session["uid"].ToString());
                    command.Parameters.AddWithValue("@DistrictID", Session["DistrictID"].ToString());

                    command.Parameters.Add("@PmegpID", SqlDbType.Int);
                    command.Parameters["@PmegpID"].Direction = ParameterDirection.Output;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(PMEGP_DATA);
                        PmegpID = (int)command.Parameters["@PmegpID"].Value;
                    }
                    con.CloseConnection();
                    ViewState["PmegpID"] = PmegpID;
                }
                if (fileUploadControl.HasFile && fileUpload1.HasFile)
                {
                    string serverpathAppl = HttpContext.Current.Server.MapPath("~\\PMEGPAttachments\\" + PmegpID + "\\Applicant\\");
                    if (!Directory.Exists(serverpathAppl))
                    {
                        Directory.CreateDirectory(serverpathAppl);
                    }
                    fileUploadControl.PostedFile.SaveAs(serverpathAppl + "\\" + fileUploadControl.PostedFile.FileName); //Applicant

                    string serverpathUnit = HttpContext.Current.Server.MapPath("~\\PMEGPAttachments\\" + PmegpID + "\\Unit\\");
                    if (!Directory.Exists(serverpathUnit))
                    {
                        Directory.CreateDirectory(serverpathUnit);
                    }
                    fileUpload1.PostedFile.SaveAs(serverpathUnit + "\\" + fileUpload1.PostedFile.FileName);//unit

                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString); ;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Sp_UpdatePMEGPAttachments", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PMEGPId", PmegpID);
                    cmd.Parameters.AddWithValue("@FileName", fileUploadControl.PostedFile.FileName);//appl file name
                    cmd.Parameters.AddWithValue("@Applicantphoto", serverpathAppl + fileUploadControl.PostedFile.FileName);
                    cmd.Parameters.AddWithValue("@ContentType", fileUploadControl.PostedFile.ContentType);

                    cmd.Parameters.AddWithValue("@Unit_FileName", fileUpload1.PostedFile.FileName);
                    cmd.Parameters.AddWithValue("@UnitPhoto", serverpathUnit + fileUpload1.PostedFile.FileName);
                    cmd.Parameters.AddWithValue("@Unit_ContentType", fileUpload1.PostedFile.ContentType);
                    cmd.Parameters.AddWithValue("@Createdby", Session["uid"].ToString());

                    cmd.ExecuteNonQuery();
                }

                if (GVFamily.Rows.Count > 0)
                {
                    using (SqlCommand command = new SqlCommand("Family_Details", con.GetConnection))
                    {
                        con.OpenConnection();
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (DataRow row in dt.Rows)
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@PmegpID", PmegpID);
                            command.Parameters.AddWithValue("@Person", row["DropDownList1"]);
                            command.Parameters.AddWithValue("@Name", row["txtName"]);
                            command.Parameters.AddWithValue("@Person_Age", row["TextBox1"]);
                            command.Parameters.AddWithValue("@Profession", row["txtProfession"]);
                            command.Parameters.AddWithValue("@Createdby", Session["uid"].ToString());

                            command.ExecuteNonQuery();
                        }
                        con.CloseConnection();
                        Session["PmegpID"] = PmegpID;
                        ViewState["PmegpID"] = PmegpID;
                    }
                }
                btnPrint.Visible = true;
                btnSubmit.Visible = true;
                btnSubmit.Visible = false;
                //ClearData();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SavedAlert", "alert('Details Saved successfully...');", true);
            }
            else
            {
                ValidateLandControls();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "SavedAlert", "alert('Details Saved successfully...');", true);
                //ClearErrorClasses();
                //ValidateAndHighlight(aplicantname); ValidateAndHighlight(txthno); ValidateAndHighlight(txtfname); ValidateAndHighlight(txtstreet); ValidateAndHighlight(txtage); ValidateAndHighlightdropdown(ddlProp_intVillageid);
                //ValidateAndHighlightdropdown(ddlProp_intMandalid); ValidateAndHighlightdropdown(ddlProp_intDistric); ValidateAndHighlight(txtadhar); ValidateAndHighlight(txtpannber); ValidateAndHighlight(txtrgnumber); ValidateAndHighlight(txtrcnmber);
                //ValidateAndHighlight(txtpnenmber); ValidateAndHighlight(txtmail); ValidateAndHighlight(txtedpcerticte); ValidateAndHighlight(txtatendprgrm1); ValidateAndHighlight(txtuitname); ValidateAndHighlight(txtloakvt);
                //ValidateAndHighlight(txtpname); ValidateAndHighlight(txtprodctonpa); ValidateAndHighlight(txtDateOfCommencement); ValidateAndHighlight(txtemlynt); ValidateAndHighlight(txtbenfryctrion); ValidateAndHighlight(txtbkloan);
                //ValidateAndHighlight(txtsubclaim); ValidateAndHighlight(txtmmadjsmts); ValidateAndHighlight(txtanalsales); ValidateAndHighlight(txtannalprfit); ValidateAndHighlight(txtrepament); ValidateAndHighlight(txtDate);
                //ValidateAndHighlight(TextBox2); ValidateAndHighlight(TextBox3); ValidateAndHighlight(TextBox4); ValidateAndHighlight(TextBox5); ValidateAndHighlight(TextBox6); ValidateAndHighlight(TextBox7); ValidateAndHighlight(TextBox14);
                //ValidateAndHighlight(TextBox15); ValidateAndHighlight(PMEGP_ID_TSIPASS); ValidateAndHighlightdropdown(ddlCaste); ValidateAndHighlightdropdown(ddlEducation); ValidateAndHighlightdropdown(ddlSpecialCategory);
                //ValidateAndHighlightdropdown(ddlVehicleBefore); ValidateAndHighlightdropdown(ddlVehicleAfter); ValidateAndHighlightdropdown(ddlhealthbefore); ValidateAndHighlightdropdown(ddlhealthafter); ValidateAndHighlightdropdown(ddlchildeducationbefore);
                //ValidateAndHighlightdropdown(ddlchildeducationafter); ValidateAndHighlightRadioBtn(RadioButton); ValidateAndHighlightfileupload(fileUploadControl); ValidateAndHighlightfileupload(fileUpload1);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Fill all the Sections Below to Proceed Further.');", true);
            }
        }
        else
        {
            ClearErrorClasses();
            ValidateAndHighlightfileupload(fileUploadControl); ValidateAndHighlightfileupload(fileUpload1);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter all details including Both the files in .jpg format to Proceed Further.');", true);
        }

    }


    public void clearcontrols()
    {
        Response.Redirect("~/UI/TSIPASS/PMEGPSuccessPage.aspx");
    }
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        clearcontrols();
    }

    private void InitializeDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("DropDownList1", typeof(string));
        dt.Columns.Add("txtName", typeof(string));
        dt.Columns.Add("TextBox1", typeof(string));
        dt.Columns.Add("txtProfession", typeof(string));

        GVFamily.DataSource = dt;
        GVFamily.DataBind();

        ViewState["MyDataTable"] = dt;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        int PmegpID = (int)ViewState["PmegpID"];
        string dataToPass = PmegpID.ToString();

        string redirectUrl = "PMEGP_SUCCESS_PRINT_PAGE.aspx?PmegpID=" + dataToPass;

        string script = "window.open('" + redirectUrl + "', '_blank', 'width=1500,height=1500');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", script, true);
    }

    protected void ValidateAndHighlight(TextBox textBox)
    {
        if (string.IsNullOrEmpty(textBox.Text))
        { textBox.CssClass = "error-border"; }
        else { textBox.CssClass = ""; }
    }

    protected void ValidateAndHighlightdropdown(DropDownList dropDownlist)
    {
        if (dropDownlist.SelectedItem.Text == "--Select--")
        { dropDownlist.CssClass = "error-border"; }
        else { dropDownlist.CssClass = ""; }
    }

    protected void ValidateAndHighlightfileupload(FileUpload fileUpload)
    {
        if (fileUpload.HasFile)
        { fileUpload.CssClass = ""; }
        else { fileUpload.CssClass = "error-border"; }
    }

    protected void ValidateAndHighlightRadioBtn(RadioButtonList radioButton)
    {
        if (radioButton.SelectedIndex >= 0)
        { radioButton.CssClass = ""; }
        else { radioButton.CssClass = "error-border"; }
    }
    protected void ClearErrorClasses()
    {
        aplicantname.CssClass = ""; txtfname.CssClass = ""; txthno.CssClass = ""; ddlCaste.CssClass = ""; txtage.CssClass = ""; ddlEducation.CssClass = ""; ddlSpecialCategory.CssClass = "";
        txtstreet.CssClass = ""; ddlProp_intVillageid.CssClass = ""; ddlProp_intMandalid.CssClass = ""; ddlProp_intDistric.CssClass = ""; RadioButton.CssClass = ""; txtadhar.CssClass = ""; txtpannber.CssClass = "";
        txtrgnumber.CssClass = ""; txtrcnmber.CssClass = ""; txtpnenmber.CssClass = ""; txtmail.CssClass = ""; txtedpcerticte1.CssClass = ""; txtatendprgrm.CssClass = ""; txtuitname.CssClass = "";
        txtloakvt.CssClass = ""; txtpname.CssClass = ""; txtprodctonpa.CssClass = ""; ddl_Units.CssClass = ""; txtDateOfCommencement.CssClass = ""; txtemlynt.CssClass = ""; txtbenfryctrion.CssClass = ""; txtbkloan.CssClass = "";
        txtsubclaim.CssClass = ""; txtmmadjsmts.CssClass = ""; txtanalsales.CssClass = ""; txtannalprfit.CssClass = ""; txtrepament.CssClass = ""; txtDate.CssClass = ""; TextBox2.CssClass = "";
        TextBox3.CssClass = ""; TextBox4.CssClass = ""; TextBox5.CssClass = ""; TextBox6.CssClass = ""; TextBox7.CssClass = ""; ddlVehicleBefore.CssClass = ""; ddlVehicleAfter.CssClass = "";
        ddlhealthbefore.CssClass = ""; ddlhealthafter.CssClass = ""; ddlchildeducationbefore.CssClass = ""; ddlchildeducationafter.CssClass = ""; TextBox14.CssClass = ""; TextBox15.CssClass = "";
        fileUploadControl.CssClass = ""; fileUpload1.CssClass = ""; PMEGP_ID_TSIPASS.CssClass = "";
    }
    protected void ClearData()
    {
        aplicantname.Text = ""; txtfname.Text = ""; txthno.Text = ""; ddlCaste.SelectedItem.Text = "--Select--"; txtage.Text = "";
        ddlEducation.CssClass = ""; ddlSpecialCategory.SelectedItem.Text = "Select"; txtstreet.Text = ""; ddlProp_intVillageid.SelectedItem.Text = "--Select--";
        ddlProp_intMandalid.SelectedItem.Text = "--Select--"; ddlProp_intDistric.SelectedItem.Text = "--Select--"; RadioButton.CssClass = ""; txtadhar.Text = ""; txtpannber.Text = "";
        txtrgnumber.Text = ""; txtrcnmber.Text = ""; txtpnenmber.Text = ""; txtmail.Text = ""; txtedpcerticte.Text = ""; txtedpcerticte1.Text = "";
        txtatendprgrm.Text = ""; txtatendprgrm1.Text = ""; txtuitname.Text = ""; txtloakvt.Text = ""; txtpname.Text = ""; txtprodctonpa.Text = ""; ddl_Units.SelectedItem.Text = "";
        txtDateOfCommencement.Text = ""; txtemlynt.Text = ""; txtbenfryctrion.Text = ""; txtbkloan.Text = ""; txtsubclaim.Text = "";
        txtmmadjsmts.Text = ""; txtanalsales.Text = ""; txtannalprfit.Text = ""; txtrepament.CssClass = ""; txtDate.Text = ""; TextBox2.Text = "";
        TextBox3.Text = ""; TextBox4.Text = ""; TextBox5.Text = ""; TextBox6.Text = ""; TextBox7.Text = "";
        ddlVehicleBefore.SelectedItem.Text = "--Select--"; ddlVehicleAfter.SelectedItem.Text = "--Select--";
        ddlhealthbefore.SelectedItem.Text = "--Select--"; ; ddlhealthafter.SelectedItem.Text = "--Select--";
        ddlchildeducationbefore.SelectedItem.Text = "--Select--"; ddlchildeducationafter.SelectedItem.Text = "--Select--";
        TextBox14.Text = ""; TextBox15.Text = ""; PMEGP_ID_TSIPASS.Text = ""; GVFamily.Visible = false;
    }
    protected void ddlProp_intMandalid_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtedpcerticte1
    }

    protected void ddlProp_intVillageid_SelectedIndexChanged(object sender, EventArgs e)
    {


    }



    protected void txtedpcerticte1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtedpcerticte1.SelectedValue == "Offline")
        {
            txtedpcerticte.Visible = true;
            lblcertice.Visible = true;
        }
        else
        {
            txtedpcerticte.Visible = false;
            lblcertice.Visible = false;

        }
    }

    protected void ddlProp_intMandalid_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //  txtdistrict.Text = string.Empty;

        // Check if the selected index is not the default one (index 0)
        if (ddlProp_intMandalid.SelectedIndex > 0)
        {
            // Get villages for the selected mandal
            DataSet dsv = gen.GetVillages(ddlProp_intMandalid.SelectedValue);

            // Check if there are villages
            if (dsv.Tables[0].Rows.Count > 0)
            {
                // Bind villages to the DropDownList
                ddlProp_intVillageid.DataSource = dsv.Tables[0];
                ddlProp_intVillageid.DataValueField = "Village_Id";
                ddlProp_intVillageid.DataTextField = "Village_Name";
                ddlProp_intVillageid.DataBind();
                ddlProp_intVillageid.Items.Insert(0, new ListItem("--Village--", string.Empty));
            }
            else
            {
                // If there are no villages, clear the DropDownList
                ddlProp_intVillageid.Items.Clear();
                ddlProp_intVillageid.Items.Insert(0, new ListItem("--Village--", string.Empty));
            }
        }
        else
        {
            // If the default index is selected, clear the DropDownList
            ddlProp_intVillageid.Items.Clear();
            ddlProp_intVillageid.Items.Insert(0, new ListItem("--Village--", string.Empty));
        }

    }

    protected void txtatendprgrm_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (txtatendprgrm.SelectedValue == "Y")
        {

            txtatendprgrm1.Visible = true;
            lblent.Visible = true;
            // txtatendprgrm1.Style["display"] = "block";
        }
        else
        {
            txtatendprgrm1.Visible = false;
            lblent.Visible = false;
            // txtatendprgrm1.Style["display"] = "none";
        }
    }

    protected void ddl_Units_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddl_Units.SelectedValue == "Other")
        {
            txtUnits.Visible = true;
            lblunits.Visible = true;
        }
        else
        {
            txtUnits.Visible = false;
            txtUnits.Text = "";
            lblunits.Visible = false;
        }
    }

    protected void ddlProp_intDistric_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //hdnfldtsiic.Value = "";
            //ddlLoc_of_unit.Items.Clear();
            //ddlLoc_of_unit.Items.Insert(0, new ListItem("--Select--", "0"));
            if (ddlProp_intDistric.SelectedIndex == 0)
            {
                ddlProp_intMandalid.Items.Clear();
                ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                ddlProp_intVillageid.Items.Clear();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");

                //ChkWater_reg_from.Items.Clear();
                //ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            }
            else
            {
                ddlProp_intVillageid.Items.Clear();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");

                ddlProp_intMandalid.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = gen.GetMandals(ddlProp_intDistric.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlProp_intMandalid.DataSource = dsm.Tables[0];
                    ddlProp_intMandalid.DataValueField = "Mandal_Id";
                    ddlProp_intMandalid.DataTextField = "Manda_lName";
                    ddlProp_intMandalid.DataBind();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlProp_intMandalid.Items.Clear();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                }
            }
            hdnfocus.Value = ddlProp_intDistric.ClientID;
            //if (ddlProp_intDistric.SelectedValue == "Y") //lavanya
            //{
            //    BindIndustrialParks();
            //}
            //   ddlProp_intDistrictid.Focus();
        }
        catch (Exception ex)
        {
            lbllabel.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }


    }


    protected void ddlhealthbefore_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public string ValidateLandControls()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (aplicantname.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant Name \\n";
            slno = slno + 1;
        }
        if (txtfname.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Father/Spouse Name \\n";
            slno = slno + 1;
        }
        if (txthno.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter H.NO \\n";
            slno = slno + 1;
        }
        if (txtstreet.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Street \\n";
            slno = slno + 1;
        }
        if (txtage.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Age \\n";
            slno = slno + 1;
        }
        if (ddlProp_intVillageid.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Village/Ward \\n";
            slno = slno + 1;
        }
        if (ddlProp_intMandalid.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Mandal/Municipality \\n";
            slno = slno + 1;
        }
        if (ddlProp_intDistric.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select District \\n";
            slno = slno + 1;
        }
        if (txtadhar.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Aadhar Card No \\n";
            slno = slno + 1;
        }
        if (txtpannber.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter PAN No \\n";
            slno = slno + 1;
        }
        if (txtrgnumber.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Udyam Registration No \\n";
            slno = slno + 1;
        }
        if (txtrcnmber.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Ration Card No \\n";
            slno = slno + 1;
        }
        if (txtpnenmber.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Phone No \\n";
            slno = slno + 1;
        }
        if (txtmail.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Email Id \\n";
            slno = slno + 1;
        }
        if (txtedpcerticte1.SelectedItem.Text == "Offline")
        {
            txtedpcerticte.Visible = true;
            //lblcertice.Visible = true;
        }
        else
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Training Enter Details \\n";
            slno = slno + 1;
            txtedpcerticte.Visible = false;
            //lblcertice.Visible = false;

        }
        //if (txtedpcerticte.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Training Enter Details \\n";
        //    slno = slno + 1;
        //}
        if (txtatendprgrm.SelectedValue == "Y")
        {

            txtatendprgrm1.Visible = true;
            //lblent.Visible = true;
            // txtatendprgrm1.Style["display"] = "block";
        }
        else
        {
            txtatendprgrm1.Visible = false;
            ErrorMsg = ErrorMsg + slno + ". Please Enter EDP Certificate Enter Details \\n";
            slno = slno + 1;
            //lblent.Visible = false;
            // txtatendprgrm1.Style["display"] = "none";
        }
        //if (txtatendprgrm1.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter EDP Certificate Enter Details \\n";
        //    slno = slno + 1;
        //}
        if (ddl_Units.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Units \\n";
            slno = slno + 1;
        }
        if (ddl_Units.SelectedValue == "Other")
        {
            txtUnits.Visible = true;
        }
        else
        {
            txtUnits.Visible = false;
            ErrorMsg = ErrorMsg + slno + ". Please Enter EDP Certificate Enter Details \\n";
            slno = slno + 1;
        }

        if (txtuitname.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Unit Name \\n";
            slno = slno + 1;
        }
        if (txtloakvt.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Line Of Activity \\n";
            slno = slno + 1;
        }
        if (txtpname.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Product Name \\n";
            slno = slno + 1;
        }
        if (txtprodctonpa.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Production Per Annum \\n";
            slno = slno + 1;
        }
        if (txtDateOfCommencement.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Date of Commencement of Production \\n";
            slno = slno + 1;
        }
        if (txtemlynt.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Employment \\n";
            slno = slno + 1;
        }
        if (txtbenfryctrion.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Beneficiary Contribution \\n";
            slno = slno + 1;
        }
        if (txtbkloan.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Bank Loan \\n";
            slno = slno + 1;
        }
        if (txtsubclaim.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Subsidy Claim \\n";
            slno = slno + 1;
        }
        if (txtmmadjsmts.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter MM Adjustments \\n";
            slno = slno + 1;
        }
        if (txtanalsales.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Annual Sales (Rs.in Lakhs) \\n";
            slno = slno + 1;
        }
        if (txtannalprfit.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Annual Profit (Rs.in Lakhs) \\n";
            slno = slno + 1;
        }
        if (txtrepament.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Loan Repayment Completed(Y/N) \\n";
            slno = slno + 1;
        }
        if (txtDate.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Physical Verification Date \\n";
            slno = slno + 1;
        }
        if (TextBox2.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Assets Value (Amount In Lakhs) \\n";
            slno = slno + 1;
        }
        if (TextBox3.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Assets Value (Amount In Lakhs) \\n";
            slno = slno + 1;
        }
        if (TextBox4.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter House (Area In Square Yards) \\n";
            slno = slno + 1;
        }
        if (TextBox5.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter House (Area In Square Yards) \\n";
            slno = slno + 1;
        }
        if (TextBox6.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Land (Area In Acres) \\n";
            slno = slno + 1;
        }
        if (TextBox7.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Land (Area In Acres) \\n";
            slno = slno + 1;
        }
        if (TextBox14.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Re-Investment (Expansion)(Amount In Lakhs) \\n";
            slno = slno + 1;
        }
        if (TextBox15.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Re-Investment (Expansion)(Amount In Lakhs) \\n";
            slno = slno + 1;
        }
        if (PMEGP_ID_TSIPASS.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter PMEGP ID \\n";
            slno = slno + 1;
        }
        if (ddlCaste.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Social Status \\n";
            slno = slno + 1;
        }
        if (ddlEducation.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Education Qualification \\n";
            slno = slno + 1;
        }
        if (ddlSpecialCategory.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Special Category \\n";
            slno = slno + 1;
        }
        if (ddlVehicleBefore.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Vehicles (2/4 Wheeler) \\n";
            slno = slno + 1;
        }
        if (ddlVehicleAfter.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Vehicles (2/4 Wheeler) \\n";
            slno = slno + 1;
        }
        if (ddlhealthbefore.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Health (Treatment From (GOVT/PVT) \\n";
            slno = slno + 1;
        }
        if (ddlhealthafter.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Health (Treatment From (GOVT/PVT) \\n";
            slno = slno + 1;
        }
        if (ddlchildeducationbefore.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Children Education (GOVT/PVT) \\n";
            slno = slno + 1;
        }
        if (ddlchildeducationafter.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Children Education (GOVT/PVT) \\n";
            slno = slno + 1;
        }
        if (RadioButton.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Region/Area \\n";
            slno = slno + 1;
        }
        if (fileUploadControl.HasFile)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Upload Applicant Photo here in this Section \\n";
            slno = slno + 1;
        }
        if (fileUpload1.HasFile)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Upload Unit Photo here in this Section \\n";
            slno = slno + 1;
        }
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Fill all the Sections Below to Proceed Further.');", true);
        return ErrorMsg;
    }
    public void gridview()
    {
        if (btnaddfamily.Text == "Add")
        {
            GVFamily.Visible = true;
        }
        else
        {
            GVFamily.Visible = false;
        }
    }
}