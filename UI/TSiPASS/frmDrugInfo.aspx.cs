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

public partial class UI_TSiPASS_frmDrugInfo : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    PCBClass objPcb = new PCBClass();

    List<TechStaff_Drug> lstTechStaff = new List<TechStaff_Drug>();
 
    List<PRODUCTS_Drug> lstProductsDrug = new List<PRODUCTS_Drug>();
    List<DirectorDetails_Drug> lstDirectorsVo = new List<DirectorDetails_Drug>();
    //DurgTest.TSIPass_Eodb objdurgtest = new DurgTest.TSIPass_Eodb();
    string AttachmentFilepath = "", AttachmentFileName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //string username = "Tsipass";
        //string password = "Tsipass$Admin@123";
        ////DataSet ds = new DataSet();
        //string output= objdurgtest.LicenseDocuments(username, password);
        //StringReader str = new StringReader(output);
        ////dco.LoadXml(xml);
        ////DataSet dsout = dco.DataSet;
        //DataSet dsout = new DataSet();
        //dsout.ReadXml(str);
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {
                DataSet dsnew = new DataSet();
                dsnew = Gen.getdataofidentityCFONewApproval(Session["ApplidA"].ToString(), "17");
                if (dsnew.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {
                        Response.Redirect("manufactureRegistrations.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                    }
                    else
                    {
                        Response.Redirect("frmOccupencyCertificateHMDA.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "P");
                    }

                }

                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["ApplidA"] = dscheck.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                    if (dscheck.Tables[0].Rows[0]["Product_Drugs"].ToString() != null && dscheck.Tables[0].Rows[0]["Product_Drugs"].ToString() != "")
                    {
                        if (dscheck.Tables[0].Rows[0]["Product_Drugs"].ToString() != "Y")
                        {
                            if (Request.QueryString[1].ToString() == "N")
                            {
                                Response.Redirect("manufactureRegistrations.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                            }
                            else
                            {
                                Response.Redirect("frmOccupencyCertificateHMDA.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
                            }

                        }
                    }
                    else
                    {
                        

                    }


                }
                else
                {
                    Session["ApplidA"] = "0";
                }

                DataSet dsver = new DataSet();

                dsver = Gen.GetverifyofqueBoiler9CFO(Session["ApplidA"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
                    ////string res = Gen.RetriveStatus("1002");


                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);
                    }

                }
            }

            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];

                if (!IsPostBack)
                {
                    FillDetails();
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }


    protected void ddlLincensetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLincensetype.SelectedIndex == 1)
        {
            divtypeform.Visible = true;
            trattachment.Visible = true;
            trmanufacturerdoc.Visible = false;
        }
        else
        {
            trattachment.Visible = false;
            trmanufacturerdoc.Visible = true;
        }
    }

    protected DataTable BindgvProprietorGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Name");
        dt.Columns.Add("Designation");
        dt.Columns.Add("Address");
        dt.Columns.Add("IdProofNo");
        dt.Columns.Add("SelectDate");
        dt.Columns.Add("Gender");
        // dt.Columns.Add("CertificateDate");
        dt.Columns.Add("Upload");
        dt.Columns.Add("MobileNumber");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
        dr[6] = "";
        dr[7] = "";
        //dr[6] = "";
        dt.Rows.Add(dr);
        return dt;
    }
    protected DataTable BindgvTechStaff()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Name");
        dt.Columns.Add("Qualification");
        dt.Columns.Add("Designation");
        dt.Columns.Add("Experience");
        dt.Columns.Add("Section");
        dt.Columns.Add("CertificateDate");
        dt.Columns.Add("RPUpload");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
        dr[6] = "";
        dt.Rows.Add(dr);
        return dt;
    }

    protected DataTable BindgrdRPDetails()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Name");
        dt.Columns.Add("Qualification");
        dt.Columns.Add("IDProof");
        dt.Columns.Add("Experience");
        dt.Columns.Add("ApprovalSought");
        
        dt.Columns.Add("uploadRP");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
  
        dt.Rows.Add(dr);
        return dt;
    }
    protected DataTable BindgvDrugProducts()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Name");
        dt.Columns.Add("Composition");
        dt.Columns.Add("ExportDomestic");
        dt.Columns.Add("BrandName");
        dt.Columns.Add("ProductCategory");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    public void BindSections(DropDownList ddlSections)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlSections.Items.Clear();
            dsd = objPcb.GetDrugSections();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlSections.DataSource = dsd.Tables[0];
                ddlSections.DataValueField = "SectionId";
                ddlSections.DataTextField = "SectionDesc";
                ddlSections.DataBind();
                ddlSections.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlSections.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    void FillDetails()
    {

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();
        try
        {
            string QuestionnaireId = Session["ApplidA"].ToString();
            ds = objPcb.GetDrugDetails(QuestionnaireId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["SaleManufacturerType"].ToString().Trim() != "")
                    {
                        ddltypeoflicense.SelectedValue = ds.Tables[0].Rows[0]["SaleManufacturerType"].ToString().Trim();
                        ddltypeoflicense_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["Catogorylicensence"].ToString().Trim() != "")
                    {
                        divSalesfields.Visible = true;
                        ddlcatogorylicensen.SelectedValue = ds.Tables[0].Rows[0]["Catogorylicensence"].ToString().Trim();
                    }
                    if (ds.Tables[0].Rows[0]["Licensetype"].ToString().Trim() != "")
                    {
                        divtypeform.Visible = true;
                        ddlLincensetype.SelectedValue = ds.Tables[0].Rows[0]["Licensetype"].ToString().Trim();
                    }
                    if (ds.Tables[0].Rows[0]["type_form"].ToString().Trim() != "")
                    {
                        divtypeform.Visible = true;
                        ddltypeform.SelectedValue = ds.Tables[0].Rows[0]["type_form"].ToString().Trim();
                    }
                    ViewState["dtDirectorDtls"] = ds.Tables[0];
                    gvProprietor.DataSource = ds.Tables[0];
                    gvProprietor.DataBind();
                }
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["dtProducts"] = ds.Tables[1];
                    gvDrugProducts.DataSource = ds.Tables[1];
                    gvDrugProducts.DataBind();
                }
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    

                    if (ds.Tables[0].Rows[0]["SaleManufacturerType"].ToString().Trim() == "1")
                    {
                        gvTechStaff.DataSource = ds.Tables[2];
                        gvTechStaff.DataBind();
                        ViewState["dtTechStaff"] = ds.Tables[2];
                    }
                    else if (ds.Tables[0].Rows[0]["SaleManufacturerType"].ToString().Trim() == "2")
                    {
                        grdRPDetails.DataSource = ds.Tables[2];
                        grdRPDetails.DataBind();
                        ViewState["trRPDetails"] = ds.Tables[2];
                    }

                }
            }
            DataSet dsnew = new DataSet();
            dsnew = Gen.ViewAttachmentCFO(Session["uid"].ToString());

            if (dsnew.Tables[0].Rows.Count > 0)
            {
                int c = dsnew.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsnew.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");



                    //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                    //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");
                    if (sen1.Contains("CFOAttachments"))
                    {
                        sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/CFOAttachments")), "~/");

                        if (sen.Contains("StatutoryDrug"))
                        {
                            HyperLinkFileNameStatutory.NavigateUrl = sen;
                            HyperLinkFileNameStatutory.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //Label440.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                        if (sen.Contains("proprietorDeclarationDrug"))
                        {
                            HyperLinkproprietorDeclaration.NavigateUrl = sen;
                            HyperLinkproprietorDeclaration.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //Label440.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                        if (sen.Contains("PartnershipdeedDrug"))
                        {
                            HyperLinkPartnershipdeed.NavigateUrl = sen;
                            HyperLinkPartnershipdeed.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //Label440.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                        if (sen.Contains("AffidavitDrug"))
                        {
                            HyperLinkAffidavitDrug.NavigateUrl = sen;
                            HyperLinkAffidavitDrug.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //Label440.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                        if (sen.Contains("RegisteredPharmacistDrug"))
                        {
                            HyperLinkRegisteredPharmacist.NavigateUrl = sen;
                            HyperLinkRegisteredPharmacist.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //Label440.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                        if (sen.Contains("SelfattestedDrug"))
                        {
                            HyperLinkSelfattested.NavigateUrl = sen;
                            HyperLinkSelfattested.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //Label440.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                        if (sen.Contains("premisesindicatingDrug"))
                        {
                            HyperLinkpremisesindicating.NavigateUrl = sen;
                            HyperLinkpremisesindicating.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //Label440.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                        if (sen.Contains("PhotographownerDrug"))
                        {
                            HyperLinkPhotographowner.NavigateUrl = sen;
                            HyperLinkPhotographowner.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //Label440.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
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
                }
            }
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {

            //labouractvo.
            int valid = 0;
            valid = SaveDrugDetails();
            lblmsg0.Text = "<font color='green'>Drug Information Saved Successfully..!</font>";
            success.Visible = true;

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    private int SaveDrugDetails()
    {
        int QuestionnaireId = Convert.ToInt32(Session["ApplidA"].ToString());
        int intCFEEnterpid = Convert.ToInt32("2");//Convert.ToInt32(Request.QueryString[0].ToString());
        string Created_by = Session["uid"].ToString();
        var catogorylicensence = ddlcatogorylicensen.SelectedValue;
        var Licensetype = ddlLincensetype.SelectedValue;
        var typeform = ddltypeform.SelectedValue;
        var typeofLicene = ddltypeoflicense.SelectedValue;

        foreach (GridViewRow gvr in gvProprietor.Rows)
        {
            DirectorDetails_Drug directorVo = new DirectorDetails_Drug();
            TextBox txtPropName = (TextBox)gvr.FindControl("txtPropName");
            TextBox txtDesignation = (TextBox)gvr.FindControl("txtDesignation");
            TextBox txtPermAddr = (TextBox)gvr.FindControl("txtPermAddr");
            TextBox txtIDProof = (TextBox)gvr.FindControl("txtIDProof");
            TextBox txtSelectDate = (TextBox)gvr.FindControl("txtSelectDate");
            TextBox txtcertificateDate = (TextBox)gvr.FindControl("txtcertificateDate");
            TextBox txtMobileNumber = (TextBox)gvr.FindControl("txtMobileNumber");
            //FileUpload filetransformer = (FileUpload)gvr.FindControl("filetransferupload");
            DropDownList salemanufactuer = (DropDownList)gvr.FindControl("ddltypeoflicense");
            DropDownList ddlGender = (DropDownList)gvr.FindControl("ddlgender");
            Label filename = (Label)gvr.FindControl("fileloadupload");

            if (txtPropName.Text != "")
            {
                directorVo.Name = txtPropName.Text;
                directorVo.Designation = txtDesignation.Text;
                directorVo.Address = txtPermAddr.Text;
                directorVo.IdProofNo = txtIDProof.Text;
                directorVo.EffectiveDate = txtSelectDate.Text;
                //directorVo.CertificateDate = txtcertificateDate.Text;
                directorVo.transformerfilepath = filename.Text;
                directorVo.SalesManufacturer = ddltypeoflicense.SelectedValue;
                directorVo.Gender = ddlGender.SelectedValue;
                directorVo.MobileNo = txtMobileNumber.Text;
                lstDirectorsVo.Add(directorVo);
            }
        }
        foreach (GridViewRow gvr in gvDrugProducts.Rows)
        {
            PRODUCTS_Drug productVo = new PRODUCTS_Drug();

            TextBox txtProductName = (TextBox)gvr.FindControl("txtProductName");
            TextBox txtComposition = (TextBox)gvr.FindControl("txtComposition");
            DropDownList ddlExportorDomestic = (DropDownList)gvr.FindControl("ddlExportorDomestic");
            TextBox txtBrandName = (TextBox)gvr.FindControl("txtBrandName");
            DropDownList ddlProductCategory = (DropDownList)gvr.FindControl("ddlProductCategory");

            if (txtBrandName.Text != "")
            {
                productVo.BrandName = txtBrandName.Text;
                productVo.Composition = txtComposition.Text;
                productVo.ExportDomestic = ddlExportorDomestic.SelectedValue;
                productVo.Name = txtProductName.Text;
                productVo.ProductCategory = ddlProductCategory.SelectedValue;
                lstProductsDrug.Add(productVo);
            }
        }
        if (typeofLicene == "2")
        {
            foreach (GridViewRow gvr in gvTechStaff.Rows)
            {
                TechStaff_Drug techStaffVo = new TechStaff_Drug();
                TextBox txtStaffName = (TextBox)gvr.FindControl("txtStaffName");
                TextBox txtQualification = (TextBox)gvr.FindControl("txtQualification");
                TextBox txtDesignation = (TextBox)gvr.FindControl("txtDesignation");
                TextBox txtExperience = (TextBox)gvr.FindControl("txtExperience");
            
                DropDownList ddlSection = (DropDownList)gvr.FindControl("ddlSection");

                if (txtStaffName.Text != "")
                {
                    techStaffVo.Name = txtStaffName.Text;
                    techStaffVo.Qualification = txtQualification.Text;
                    techStaffVo.Designation = txtDesignation.Text;
                    techStaffVo.Experience = txtExperience.Text;
                    techStaffVo.Section = ddlSection.SelectedValue;
                    
                    lstTechStaff.Add(techStaffVo);
                }
            }
        }
        else if (typeofLicene == "1")
        {
            foreach (GridViewRow gvr in grdRPDetails.Rows)
            {
                TechStaff_Drug techStaffVo = new TechStaff_Drug();
                TextBox txtStaffName = (TextBox)gvr.FindControl("txtStaffName");
                TextBox txtQualification = (TextBox)gvr.FindControl("txtQualification");
                TextBox txtIDProof = (TextBox)gvr.FindControl("txtIDProof");
                TextBox txtExperience = (TextBox)gvr.FindControl("txtExperience");
                DropDownList ddlApprovalSought = (DropDownList)gvr.FindControl("ddlApprovalSought");
     

                if (txtStaffName.Text != "")
                {
                    techStaffVo.Name = txtStaffName.Text;
                    techStaffVo.Qualification = txtQualification.Text;
                    techStaffVo.IDProof = txtIDProof.Text;
                    techStaffVo.Experience = txtExperience.Text;
                    techStaffVo.ApprovalSought = ddlApprovalSought.SelectedValue;
                    lstTechStaff.Add(techStaffVo);
                }
            }
        }
           


        int valid = 0;
        valid = objPcb.InsertDrugDetails(Created_by, QuestionnaireId, lstDirectorsVo, lstProductsDrug, lstTechStaff, catogorylicensence, Licensetype, typeform, typeofLicene);
        return valid;
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N"); //lavanya new 
       // SaveDrugDetails();
        int valid = 0;
        valid = SaveDrugDetails();
        Response.Redirect("manufactureRegistrations.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("manufactureRegistrations.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmOccupencyCertificateHMDA.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

    }
    protected void gvProprietor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvProprietorGrid();
                String[] arraydata = new String[8];

                int gvrcnt = gvProprietor.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvProprietor.Rows[i];

                    TextBox txtPropName = (TextBox)gvr.FindControl("txtPropName");
                    arraydata[0] = txtPropName.Text;

                    TextBox txtDesignation = (TextBox)gvr.FindControl("txtDesignation");
                    arraydata[1] = txtDesignation.Text;

                    TextBox txtPermAddr = (TextBox)gvr.FindControl("txtPermAddr");
                    arraydata[2] = txtPermAddr.Text;
                    TextBox txtIDProof = (TextBox)gvr.FindControl("txtIDProof");
                    arraydata[3] = txtIDProof.Text;
                    TextBox txtSelectDate = (TextBox)gvr.FindControl("txtSelectDate");
                    arraydata[4] = txtSelectDate.Text;
                    DropDownList ddlGender = (DropDownList)gvr.FindControl("ddlgender");
                    arraydata[5] = ddlGender.SelectedValue.ToString();
                    //TextBox txtcertificateDate = (TextBox)gvr.FindControl("txtcertificateDate");
                    //arraydata[5] = txtcertificateDate.Text;

                    FileUpload fileloadupload = (FileUpload)gvr.FindControl("fileloadupload");
                    //arraydata[6] = fileloadupload.HasFile;

                    if (txtPropName.Text == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please Enter proprietor/partners / directors ";
                        lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                    }

                    string Type = "Upload Load Particulars";
                    string newPath = "";
                    string sFileDir = Server.MapPath("~\\CFOAttachments");

                    General t1 = new General();
                    if (fileloadupload.HasFile)
                    {
                        if ((fileloadupload.PostedFile != null) && (fileloadupload.PostedFile.ContentLength > 0))
                        {
                            //determine file name
                            string sFileName = System.IO.Path.GetFileName(fileloadupload.PostedFile.FileName);
                            try
                            {

                                string[] fileType = fileloadupload.PostedFile.FileName.Split('.');
                                int j = fileType.Length;
                                if (fileType[j - 1].ToUpper().Trim() == "PDF")
                                {
                                    //Create a new subfolder under the current active folder
                                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ConstitutionPhoto");
                                    // Create the subfolder
                                    if (!Directory.Exists(newPath))

                                        System.IO.Directory.CreateDirectory(newPath);
                                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                    int count = dir.GetFiles().Length;
                                    if (count == 0)
                                        fileloadupload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                    else
                                    {
                                        if (count == 1)
                                        {
                                            string[] Files = Directory.GetFiles(newPath);

                                            foreach (string file in Files)
                                            {
                                                File.Delete(file);
                                            }
                                            fileloadupload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    arraydata[6] = newPath + "\\" + fileloadupload.FileName;
                    TextBox txtMobileNumber = (TextBox)gvr.FindControl("txtMobileNumber");
                    arraydata[7] = txtMobileNumber.Text;
                    if (valid == 0)
                    {
                        dt.Rows[i].ItemArray = arraydata;
                        DataRow dRow;
                        dRow = null;
                        dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }
                }

                if (valid == 0)
                {
                    ViewState["dtDirectorDtls"] = dt;
                    gvProprietor.DataSource = dt;
                    gvProprietor.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvProprietor.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvProprietorGrid();
                    String[] arraydata = new String[6];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvProprietor.Rows[i];

                            TextBox txtPropName = (TextBox)gvr.FindControl("txtPropName");
                            arraydata[0] = txtPropName.Text;

                            TextBox txtDesignation = (TextBox)gvr.FindControl("txtDesignation");
                            arraydata[1] = txtDesignation.Text;

                            TextBox txtPermAddr = (TextBox)gvr.FindControl("txtPermAddr");
                            arraydata[2] = txtPermAddr.Text;
                            TextBox txtIDProof = (TextBox)gvr.FindControl("txtIDProof");
                            arraydata[3] = txtIDProof.Text;
                            TextBox txtSelectDate = (TextBox)gvr.FindControl("txtSelectDate");
                            arraydata[4] = txtSelectDate.Text;

                            //TextBox txtcertificateDate = (TextBox)gvr.FindControl("txtcertificateDate");
                            //arraydata[5] = txtcertificateDate.Text;

                            FileUpload fileloadupload = (FileUpload)gvr.FindControl("fileloadupload");
                            arraydata[6] = fileloadupload.FileName;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);
                        }
                    }
                    dt.Rows.RemoveAt(i - 1);
                    ViewState["dtDirectorDtls"] = dt;
                    gvProprietor.DataSource = dt;
                    gvProprietor.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvProprietor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtDirectorDtls"];
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtPropName = (TextBox)gvr.FindControl("txtPropName");
                        TextBox txtDesignation = (TextBox)gvr.FindControl("txtDesignation");
                        TextBox txtPermAddr = (TextBox)gvr.FindControl("txtPermAddr");
                        TextBox txtIDProof = (TextBox)gvr.FindControl("txtIDProof");
                        TextBox txtSelectDate = (TextBox)gvr.FindControl("txtSelectDate");
                        DropDownList ddlGender= (DropDownList)gvr.FindControl("ddlgender");
                        //TextBox txtcertificateDate = (TextBox)gvr.FindControl("txtcertificateDate");
                        FileUpload filetransferupload = (FileUpload)gvr.FindControl("filetransferupload");
                        Label filename = (Label)gvr.FindControl("LoadUpload");

                        txtPropName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        txtDesignation.Text = dt.Rows[e.Row.RowIndex]["Designation"].ToString();
                        txtPermAddr.Text = dt.Rows[e.Row.RowIndex]["Address"].ToString();
                        txtIDProof.Text = dt.Rows[e.Row.RowIndex]["IdProofNo"].ToString();
                        txtSelectDate.Text = dt.Rows[e.Row.RowIndex]["SelectDate"].ToString();
                        //txtcertificateDate.Text = dt.Rows[e.Row.RowIndex]["CertificateDate"].ToString();
                        filename.Text = dt.Rows[e.Row.RowIndex]["Upload"].ToString();
                        ddlGender.SelectedValue= dt.Rows[e.Row.RowIndex]["gender"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvTechStaff_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtTechStaff"];
                DropDownList ddlSection = (DropDownList)gvr.FindControl("ddlSection");
                BindSections(ddlSection);
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtStaffName = (TextBox)gvr.FindControl("txtStaffName");
                        txtStaffName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        TextBox txtQualification = (TextBox)gvr.FindControl("txtQualification");
                        txtQualification.Text = dt.Rows[e.Row.RowIndex]["Qualification"].ToString();

                        TextBox txtDesignation = (TextBox)gvr.FindControl("txtDesignation");
                        txtDesignation.Text = dt.Rows[e.Row.RowIndex]["Designation"].ToString();

                        TextBox txtExperience = (TextBox)gvr.FindControl("txtExperience");
                        txtExperience.Text = dt.Rows[e.Row.RowIndex]["Experience"].ToString();

                        ddlSection.SelectedValue = dt.Rows[e.Row.RowIndex]["Section"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvTechStaff_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvTechStaff();
                String[] arraydata = new String[7];

                int gvrcnt = gvTechStaff.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvTechStaff.Rows[i];

                    TextBox txtStaffName = (TextBox)gvr.FindControl("txtStaffName");
                    arraydata[0] = txtStaffName.Text;

                    TextBox txtQualification = (TextBox)gvr.FindControl("txtQualification");
                    arraydata[1] = txtQualification.Text;

                    TextBox txtDesignation = (TextBox)gvr.FindControl("txtDesignation");
                    arraydata[2] = txtDesignation.Text;

                    TextBox txtExperience = (TextBox)gvr.FindControl("txtExperience");
                    arraydata[3] = txtExperience.Text;

                    DropDownList ddlSection = (DropDownList)gvr.FindControl("ddlSection");
                    arraydata[4] = ddlSection.SelectedValue;

                    TextBox txtcertificateDate = (TextBox)gvr.FindControl("txtcertificateDate");
                    arraydata[5] = txtcertificateDate.Text;

                    FileUpload fileloaduploadRP = (FileUpload)gvr.FindControl("fileloaduploadRP");
                    //arraydata[6] = fileloadupload.HasFile;

                    string Type = "Upload RP Photo";
                    string newPath = "";
                    string sFileDir = Server.MapPath("~\\CFOAttachments");

                    General t1 = new General();
                    if (fileloaduploadRP.HasFile)
                    {
                        if ((fileloaduploadRP.PostedFile != null) && (fileloaduploadRP.PostedFile.ContentLength > 0))
                        {
                            //determine file name
                            string sFileName = System.IO.Path.GetFileName(fileloaduploadRP.PostedFile.FileName);
                            try
                            {

                                string[] fileType = fileloaduploadRP.PostedFile.FileName.Split('.');
                                int j = fileType.Length;
                                if (fileType[j - 1].ToUpper().Trim() == "PDF")
                                {
                                    //Create a new subfolder under the current active folder
                                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\RPCPPhoto");
                                    // Create the subfolder
                                    if (!Directory.Exists(newPath))

                                        System.IO.Directory.CreateDirectory(newPath);
                                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                    int count = dir.GetFiles().Length;
                                    if (count == 0)
                                        fileloaduploadRP.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                    else
                                    {
                                        if (count == 1)
                                        {
                                            string[] Files = Directory.GetFiles(newPath);

                                            foreach (string file in Files)
                                            {
                                                File.Delete(file);
                                            }
                                            fileloaduploadRP.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    arraydata[6] = newPath + "\\" + fileloaduploadRP.FileName;

                    if (txtStaffName.Text == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please Enter Technical Staff Details";
                        lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                    }
                    if (valid == 0)
                    {
                        dt.Rows[i].ItemArray = arraydata;
                        DataRow dRow;
                        dRow = null;
                        dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }
                }

                if (valid == 0)
                {
                    ViewState["dtTechStaff"] = dt;
                    gvTechStaff.DataSource = dt;
                    gvTechStaff.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvTechStaff.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvTechStaff();
                    String[] arraydata = new String[5];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvTechStaff.Rows[i];

                            TextBox txtStaffName = (TextBox)gvr.FindControl("txtStaffName");
                            arraydata[0] = txtStaffName.Text;

                            TextBox txtQualification = (TextBox)gvr.FindControl("txtQualification");
                            arraydata[1] = txtQualification.Text;

                            TextBox txtDesignation = (TextBox)gvr.FindControl("txtDesignation");
                            arraydata[2] = txtDesignation.Text;

                            TextBox txtExperience = (TextBox)gvr.FindControl("txtExperience");
                            arraydata[3] = txtExperience.Text;

                            DropDownList ddlSection = (DropDownList)gvr.FindControl("ddlSection");
                            arraydata[4] = ddlSection.SelectedValue;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtTechStaff"] = dt;
                    gvTechStaff.DataSource = dt;
                    gvTechStaff.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvDrugProducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvDrugProducts();
                String[] arraydata = new String[5];

                int gvrcnt = gvDrugProducts.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvr = gvDrugProducts.Rows[i];

                    TextBox txtProductName = (TextBox)gvr.FindControl("txtProductName");
                    arraydata[0] = txtProductName.Text;

                    TextBox txtComposition = (TextBox)gvr.FindControl("txtComposition");
                    arraydata[1] = txtComposition.Text;

                    DropDownList ddlExportorDomestic = (DropDownList)gvr.FindControl("ddlExportorDomestic");
                    arraydata[2] = ddlExportorDomestic.SelectedValue;
                    TextBox txtBrandName = (TextBox)gvr.FindControl("txtBrandName");
                    arraydata[3] = txtBrandName.Text;
                    DropDownList ddlProductCategory = (DropDownList)gvr.FindControl("ddlProductCategory");
                    arraydata[4] = ddlProductCategory.SelectedValue;

                    if (txtProductName.Text == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Product Details";
                        lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                    }
                    if (valid == 0)
                    {
                        dt.Rows[i].ItemArray = arraydata;
                        DataRow dRow;
                        dRow = null;
                        dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }
                }

                if (valid == 0)
                {
                    ViewState["dtProducts"] = dt;
                    gvDrugProducts.DataSource = dt;
                    gvDrugProducts.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvDrugProducts.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvDrugProducts();
                    String[] arraydata = new String[5];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvr = gvDrugProducts.Rows[i];


                            TextBox txtProductName = (TextBox)gvr.FindControl("txtProductName");
                            arraydata[0] = txtProductName.Text;

                            TextBox txtComposition = (TextBox)gvr.FindControl("txtComposition");
                            arraydata[1] = txtComposition.Text;

                            DropDownList ddlExportorDomestic = (DropDownList)gvr.FindControl("ddlExportorDomestic");
                            arraydata[2] = ddlExportorDomestic.SelectedValue;
                            TextBox txtBrandName = (TextBox)gvr.FindControl("txtBrandName");
                            arraydata[3] = txtBrandName.Text;
                            DropDownList ddlProductCategory = (DropDownList)gvr.FindControl("ddlProductCategory");
                            arraydata[4] = ddlProductCategory.SelectedValue;
                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtProducts"] = dt;
                    gvDrugProducts.DataSource = dt;
                    gvDrugProducts.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvDrugProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtProducts"];
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtProductName = (TextBox)gvr.FindControl("txtProductName");
                        txtProductName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();

                        TextBox txtComposition = (TextBox)gvr.FindControl("txtComposition");
                        txtComposition.Text = dt.Rows[e.Row.RowIndex]["Composition"].ToString();

                        DropDownList ddlExportorDomestic = (DropDownList)gvr.FindControl("ddlExportorDomestic");
                        ddlExportorDomestic.SelectedValue = dt.Rows[e.Row.RowIndex]["ExportDomestic"].ToString();
                        TextBox txtBrandName = (TextBox)gvr.FindControl("txtBrandName");
                        txtBrandName.Text = dt.Rows[e.Row.RowIndex]["BrandName"].ToString();
                        DropDownList ddlProductCategory = (DropDownList)gvr.FindControl("ddlProductCategory");
                        ddlProductCategory.SelectedValue = dt.Rows[e.Row.RowIndex]["ProductCategory"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void ddltypeoflicense_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddltypeoflicense.SelectedValue == "2") 
            {
                lblTechnicalStaff.Text = "RP DETAILS";
                BindLicenseSubtype(ddltypeoflicense);
                trconheading.Visible = true;
                trconstitutiongrid.Visible = true;
                trtechnicalstaff.Visible = true;
                trtechnicalstaffgrid.Visible = true;
                trManufactureCheckList.Visible = false;
                trSalesCheckList.Visible = true;
                trRPDetails.Visible = false;
                divSalesfields.Visible = true;
                trattachment.Visible = true;
                gvProprietor.DataSource = BindgvProprietorGrid();
                gvProprietor.DataBind();

                //gvDrugProducts.DataSource = BindgvDrugProducts();
                //gvDrugProducts.DataBind();

                gvTechStaff.DataSource = BindgvTechStaff();
                gvTechStaff.DataBind();
                trattachment.Visible = true;
                trmanufacturerdoc.Visible = false;
                if (ddlcatogorylicensen.SelectedValue == "1")
                {
                    trExperience.Visible=true;
                }
                else
                {
                    trExperience.Visible=false;
                }
            }
            else if (ddltypeoflicense.SelectedValue == "1")
            {
                lblTechnicalStaff.Text = "DETAILS OF THE TECHNICAL STAFF";
                trmanufacturerdoc.Visible = true;
                BindLicenseSubtype(ddltypeoflicense);
                trconheading.Visible = true;
                trconstitutiongrid.Visible = true;
                trtechnicalstaff.Visible = true;
                trtechnicalstaffgrid.Visible = false;
                trManufactureCheckList.Visible = true;
                trSalesCheckList.Visible = false;
                trRPDetails.Visible = true;
                trdrugproductgrid.Visible = true;
                trdrugproduct.Visible = true;
                trattachment.Visible = false;
                gvProprietor.DataSource = BindgvProprietorGrid();
                gvProprietor.DataBind();

                gvDrugProducts.DataSource = BindgvDrugProducts();
                gvDrugProducts.DataBind();

                grdRPDetails.DataSource = BindgrdRPDetails();
                grdRPDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
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
    protected void BtnStatutory_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

        General t1 = new General();
        if ((FileUploadStatutory.PostedFile != null) && (FileUploadStatutory.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadStatutory.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUploadStatutory.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\StatutoryDrug");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadStatutory.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadStatutory.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "StatutoryDrug");



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        LabelStatutory.Text = FileUploadStatutory.FileName;
                        HyperLinkFileNameStatutory.NavigateUrl = FileUploadStatutory.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    protected void btnproprietorDeclaration_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

        General t1 = new General();
        if ((FileUploadproprietorDeclaration.PostedFile != null) && (FileUploadproprietorDeclaration.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadproprietorDeclaration.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUploadproprietorDeclaration.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\proprietorDeclarationDrug");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadproprietorDeclaration.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadproprietorDeclaration.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "proprietorDeclarationDrug");



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        LabelproprietorDeclaration.Text = FileUploadproprietorDeclaration.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    protected void btnPartnershipdeed_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

        General t1 = new General();
        if ((FileUploadPartnershipdeed.PostedFile != null) && (FileUploadPartnershipdeed.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadPartnershipdeed.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUploadPartnershipdeed.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PartnershipdeedDrug");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadPartnershipdeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadPartnershipdeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "PartnershipdeedDrug");



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        LabelPartnershipdeed.Text = FileUploadPartnershipdeed.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    protected void btnAffidavitDrug_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

        General t1 = new General();
        if ((FileUploadAffidavitDrug.PostedFile != null) && (FileUploadAffidavitDrug.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadAffidavitDrug.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUploadAffidavitDrug.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\AffidavitDrug");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadAffidavitDrug.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadAffidavitDrug.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "AffidavitDrug");



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        LabelAffidavitDrug.Text = FileUploadAffidavitDrug.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    protected void btnRegisteredPharmacist_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

        General t1 = new General();
        if ((FileUploadRegisteredPharmacist.PostedFile != null) && (FileUploadRegisteredPharmacist.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadRegisteredPharmacist.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUploadRegisteredPharmacist.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\RegisteredPharmacistDrug");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadRegisteredPharmacist.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadRegisteredPharmacist.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "RegisteredPharmacistDrug");



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        LabelRegisteredPharmacist.Text = FileUploadRegisteredPharmacist.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    protected void btnSelfattested_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

        General t1 = new General();
        if ((FileUploadSelfattested.PostedFile != null) && (FileUploadSelfattested.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadSelfattested.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUploadSelfattested.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\SelfattestedDrug");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadSelfattested.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadSelfattested.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "SelfattestedDrug");



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        LabelSelfattested.Text = FileUploadSelfattested.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    protected void btnuploadpremisesindicating_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

        General t1 = new General();
        if ((FileUploadpremisesindicating.PostedFile != null) && (FileUploadpremisesindicating.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadpremisesindicating.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUploadpremisesindicating.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\premisesindicatingDrug");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadpremisesindicating.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadpremisesindicating.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "premisesindicatingDrug");



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Labelpremisesindicating.Text = FileUploadpremisesindicating.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    protected void BtnPhotographowner_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

        General t1 = new General();
        if ((FileUploadPhotographowner.PostedFile != null) && (FileUploadPhotographowner.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadPhotographowner.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUploadPhotographowner.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PhotographownerDrug");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadPhotographowner.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadPhotographowner.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "PhotographownerDrug");



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        LabelPhotographowner.Text = FileUploadPhotographowner.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    protected void btnExperiencecertificate_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

        General t1 = new General();
        if ((FileUploadExperiencecertificate.PostedFile != null) && (FileUploadExperiencecertificate.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadExperiencecertificate.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUploadExperiencecertificate.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ExperiencecertificateDurg");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadExperiencecertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadExperiencecertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ExperiencecertificateDurg");



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        LabelExperiencecertificate.Text = FileUploadExperiencecertificate.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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

    public void BindLicenseSubtype(DropDownList ddl)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlcatogorylicensen.Items.Clear();
            dsd = Gen.GetLicenseSubType(ddltypeoflicense.SelectedValue);
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlcatogorylicensen.DataSource = dsd.Tables[0];
                ddlcatogorylicensen.DataValueField = "LicenseSubType_Code";
                ddlcatogorylicensen.DataTextField = "LicenseSubType_Name";
                ddlcatogorylicensen.DataBind();
                ddlcatogorylicensen.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlcatogorylicensen.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\drugForm24");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

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

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                        //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "drugForm24");



                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label14.Text = FileUpload1.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\drugMCAdecl");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

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

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                        //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "drugMCAdecl");



                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label16.Text = FileUpload2.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\drugPartnerDeed");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

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

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                       
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "drugPartnerDeed"); 
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label18.Text = FileUpload3.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if ((FileUpload4.PostedFile != null) && (FileUpload4.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload4.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUpload4.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\drugSelfAttested");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

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

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                        //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "drugSelfAttested");



                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label20.Text = FileUpload4.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\drugRentLeaseDeed");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

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

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                        //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "drugRentLeaseDeed");



                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label22.Text = FileUpload5.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if ((FileUpload6.PostedFile != null) && (FileUpload6.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload6.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUpload6.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\drugOwnerShipDeed");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

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

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                        //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "drugOwnerShipDeed");



                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label24.Text = FileUpload6.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if ((FileUpload7.PostedFile != null) && (FileUpload7.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload7.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUpload7.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\drugPlanLayout");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

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

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                        //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "drugPlanLayout");



                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label26.Text = FileUpload7.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if ((FileUpload8.PostedFile != null) && (FileUpload8.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload8.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUpload8.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\drugAnalytical");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

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

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                        //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "drugAnalytical");



                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label28.Text = FileUpload8.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if ((FileUpload9.PostedFile != null) && (FileUpload9.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload9.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUpload9.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\drugTechnical");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

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

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                        //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "drugTechnical");



                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label30.Text = FileUpload9.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if ((FileUpload10.PostedFile != null) && (FileUpload10.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload10.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUpload10.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\drugMuncipal");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

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

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                        //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "drugMuncipal");



                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label32.Text = FileUpload10.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



 
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\CFOAttachments");

            General t1 = new General();
            if ((FileUpload11.PostedFile != null) && (FileUpload11.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload11.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUpload11.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\drugForm46");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

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

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                        //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "drugForm46");



                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label34.Text = FileUpload11.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    }

    protected void grdRPDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvTechStaff();
                String[] arraydata = new String[7];

                int gvrcnt = grdRPDetails.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {

                    GridViewRow gvrDP = grdRPDetails.Rows[i];

                    TextBox txtStaffName = (TextBox)gvrDP.FindControl("txtStaffName");
                    arraydata[0] = txtStaffName.Text;

                    TextBox txtQualification = (TextBox)gvrDP.FindControl("txtQualification");
                    arraydata[1] = txtQualification.Text;

                    TextBox txtIDProof = (TextBox)gvrDP.FindControl("txtIDProof");
                    arraydata[2] = txtIDProof.Text;

                    TextBox txtExperience = (TextBox)gvrDP.FindControl("txtExperience");
                    arraydata[3] = txtExperience.Text;

                    DropDownList ddlApprovalSought = (DropDownList)gvrDP.FindControl("ddlApprovalSought");
                    arraydata[4] = ddlApprovalSought.SelectedValue; 

                    FileUpload fileloaduploadRP = (FileUpload)gvrDP.FindControl("fileloaduploadRP");
                    //arraydata[6] = fileloadupload.HasFile;

                    string Type = "ID Proof Attachments";
                    string newPath = "";
                    string sFileDir = Server.MapPath("~\\CFOAttachments");

                    General t1 = new General();
                    if (fileloaduploadRP.HasFile)
                    {
                        if ((fileloaduploadRP.PostedFile != null) && (fileloaduploadRP.PostedFile.ContentLength > 0))
                        {
                            //determine file name
                            string sFileName = System.IO.Path.GetFileName(fileloaduploadRP.PostedFile.FileName);
                            try
                            {

                                string[] fileType = fileloaduploadRP.PostedFile.FileName.Split('.');
                                int j = fileType.Length;
                                if (fileType[j - 1].ToUpper().Trim() == "PDF")
                                {
                                    //Create a new subfolder under the current active folder
                                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\idproofStaff");
                                    // Create the subfolder
                                    if (!Directory.Exists(newPath))

                                        System.IO.Directory.CreateDirectory(newPath);
                                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                    int count = dir.GetFiles().Length;
                                    if (count == 0)
                                        fileloaduploadRP.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                    else
                                    {
                                        if (count == 1)
                                        {
                                            string[] Files = Directory.GetFiles(newPath);

                                            foreach (string file in Files)
                                            {
                                                File.Delete(file);
                                            }
                                            fileloaduploadRP.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    arraydata[6] = newPath + "\\" + fileloaduploadRP.FileName;

                    if (txtStaffName.Text == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please Enter All details";
                        lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                    }
                    if (valid == 0)
                    {
                        dt.Rows[i].ItemArray = arraydata;
                        DataRow dRow;
                        dRow = null;
                        dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }
                }

                if (valid == 0)
                {
                    ViewState["trRPDetails"] = dt;
                    grdRPDetails.DataSource = dt;
                    grdRPDetails.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvTechStaff.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvTechStaff();
                    String[] arraydata = new String[5];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvrDP = gvTechStaff.Rows[i];

                            TextBox txtStaffName = (TextBox)gvrDP.FindControl("txtStaffName");
                            arraydata[0] = txtStaffName.Text;

                            TextBox txtQualification = (TextBox)gvrDP.FindControl("txtQualification");
                            arraydata[1] = txtQualification.Text;

                            TextBox txtIDProof = (TextBox)gvrDP.FindControl("txtIDProof");
                            arraydata[2] = txtIDProof.Text;

                            TextBox txtExperience = (TextBox)gvrDP.FindControl("txtExperience");
                            arraydata[3] = txtExperience.Text;

                            DropDownList ddlApprovalSought = (DropDownList)gvrDP.FindControl("ddlApprovalSought");
                            arraydata[4] = ddlApprovalSought.SelectedValue;

                            FileUpload fileloaduploadRP = (FileUpload)gvrDP.FindControl("fileloaduploadRP");

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["trRPDetails"] = dt;
                    grdRPDetails.DataSource = dt;
                    grdRPDetails.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }

    protected void grdRPDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvrDP = e.Row;

                DataTable dt = (DataTable)ViewState["trRPDetails"];
                
                 if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtStaffName = (TextBox)gvrDP.FindControl("txtStaffName");
                        txtStaffName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        TextBox txtQualification = (TextBox)gvrDP.FindControl("txtQualification");
                        txtQualification.Text = dt.Rows[e.Row.RowIndex]["Qualification"].ToString();

                        TextBox txtIDProof = (TextBox)gvrDP.FindControl("txtIDProof");
                        txtIDProof.Text = dt.Rows[e.Row.RowIndex]["IDProof"].ToString();
                        TextBox txtExperience = (TextBox)gvrDP.FindControl("txtExperience");
                        txtExperience.Text = dt.Rows[e.Row.RowIndex]["Experience"].ToString();
                        DropDownList ddlApprovalSought = (DropDownList)gvrDP.FindControl("ddlApprovalSought");

                        ddlApprovalSought.SelectedValue = dt.Rows[e.Row.RowIndex]["Section"].ToString();
                         

                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }

    protected void ddlcatogorylicensen_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ddlcatogorylicensen_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcatogorylicensen.SelectedValue.ToString() == "1" && ddltypeoflicense.SelectedValue.ToString()=="2")
        {
            Label387.Text = "Statutory form – 19 for licenses in form (20B,21B)";
            Label5.Text = "Declaration by the proprietor / Partner / Director / Competent Persons / Regd. Pharmacist with proof of residential address(Present and Permanent) for proof of residential address – Aadhar Card, Pass Port, Voter ID.(In prescribed proforma)";
            Label9.Text = "Partnership deed in case of partnership firm / List of Directors downloaded from MCA website signed by Company Secretary / Managing Director(In case of company).";
            Label1.Text = "In case of company an Affidavit under Section 34 of Drugs and Cosmetics Act, 1940 on Rs.20 / -stamp paper signed by one of the Directors of the company.(In prescribed proforma).";
            Label6.Text = "Special declaration by Registered Pharmacist on Rs.20/- Non-Judicial stamp paper (in case of Registered Pharmacist is appointed as C.P).(In prescribed proforma).";
            Label8.Text = "Self attested copy of Registered Pharmacist certificate (renewal up to date) affixed with latest original photograph and signature of the candidate(in case Registered Pharmacist is appointed as C.P) / SSC / degree certificate(in case of candidate other than R.P).";
            Label11.Text = "Plan of the premises indicating the carpet area (specifying length and breadth in meters and area in Sq.m) with the signature of Building owner and the applicant (Prop / partners / Authorized signatory / Managing Director, etc,.) in a legal size.";
            Label13.Text = "Declaration of building owner (Photograph of the building owner with self attestation).(In prescribed proforma).Self attested photocopy of the document showing the proof of ownership of the building owner for the premises to be licensed(E.C / any other legal document showing the present ownership.";
            Label10.Text = "Experience certificate of Competent person.";

            trExperience.Visible = true;


        }
       else if (ddlcatogorylicensen.SelectedValue.ToString() == "2" && ddltypeoflicense.SelectedValue.ToString() == "2")
            {
            Label387.Text = "Statutory form – 19 for licenses in form (20,21)";
            Label5.Text = "Declaration by the proprietor / Partner / Director / Competent Persons /Regd.Pharmacist with proof of residential address(Present and Permanent) for proof of residential address – Aadhar Card, Pass Port, Driving License,Voter ID";
            Label9.Text = "Partnership deed in case of partnership firm/ List of Directors downloaded from MCA website signed by Company Secretary / Managing Director(In case of company).";
            Label1.Text = "In case of company an Affidavit under Section 34 of Drugs and Cosmetics Act, 1940 on Rs.20 / -stamp paper signed by one of the Directors of the company.(In prescribed proforma)";
            Label6.Text = "Special declaration by Registered Pharmacist on Rs.20/- Non-Judicial stamp paper.(In prescribed proforma).";
            Label8.Text = "Self attested copy of Registered Pharmacist certificate (renewal up to date) affixed with latest original photograph and signature of the candidate /original to be produced to the Drugs Inspector at the time of inspection for endorsement";
            Label11.Text = "Plan of the premises indicating the carpet area (specifying length and breadth in meters and area in Sq.m) with the signature of Building owner and the applicant(Prop / partners / Authorized signatory / Managing Director, etc,.) in a legal size";
            Label13.Text = "Declaration of building owner (Photograph of the building owner with self attestation).(In prescribed proforma).Self attested photocopy of the document showing the proof of ownership of the building owner for the premises to be licensed(E.C / any other legal document showing the present ownership.";
            Label10.Text = "Experience certificate of Competent person.";

            trExperience.Visible = false;


        }
        else if (ddltypeoflicense.SelectedValue.ToString() == "1")
        {
            Label12.Text = "Application (statutory) in Form-24/ 27/ 31/ 27D/24Bduly signed by the Proprietor / Managing Partner / Managing Director/ Person declared as responsible  under  Sec.34  /  Person  Authorized  by the  Board  of  Directors  accompanied  by Company Board Resolution";
            Label15.Text = "Declaration of the Proprietor / Partners / Directors etc. in Affidavit (as performat)&  List  of  Directors  downloaded  from  MCA  website  signed  by  Company  Secretary  / Managing Director (In case of company)";
            Label17.Text = "Partnership deed in case of Partnership firms";
            Label19.Text = "Self attested Copy of Aadhar card/Passport/Electoral card as proof of residentialaddress of the responsible person as mentioned in the Affidavit at Sl.No.2";
            Label21.Text = "Rent / Lease deed in case of Rentalpremises";
            Label23.Text = "Declaration  of  the  ownership  of  the  premises  if  premises  owned  by  the  applicant  firm  or company,  with  the  documentary  evidence  of  ownership  like  Registered  sale  deed  and/or proof of allotment of the site along with the latest property taxreceipt";
            Label25.Text = "Plan  and  layout  of  the  premises  showing  the  installation  of  Machinery  and  Equipment. preferably a Blue Print duly signed by the applicant who signed in the statutoryform";
            Label27.Text = "Detailed list of Manufacturing and AnalyticalEquipment";
            Label29.Text = "Application  for  approval  of  Technical  Staff  (in  the  prescribed  format)  with  enclosures  ofconsent  letter,  copies  of  qualification  certificates,  experience  certificates  of  proposed technical  staff  along  with  earlier  approvals,  if  any,  appointment  order  of  the  Technical staff";
            Label31.Text = "Permission  obtained  from  the  Municipal  Authorities/  Panchayat  authorities/  Industrial Local Authority,Certificate in conformity with Factories Act for construction and starting the Unit & PermissionfromT.S. Pollution Control Board clearance of the area for setting up the manufacturing facility";
            Label33.Text = "Form CT-22 (for APIs) / Form CT-23 (for Formulations) in case of ‘New Drugs’ as defined as per New Drugs & Clinical Trial Rules, 2019 (for New Drugs for Human Use) (or)Form 46/ Form 46-A in case of ‘New Drugs’ under Rule 122E of Drugs and Cosmetics Act and Rules made thereunder (for New Drugs for Veterinary Use)(or)NOC for specific quantity export of New Drugs";


            trExperience.Visible = false;


        }

    }
}