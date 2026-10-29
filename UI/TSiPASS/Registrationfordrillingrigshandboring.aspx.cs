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

public partial class UI_TSiPASS_Registrationfordrillingrigshandboring : System.Web.UI.Page
{
    Cls_DrillingRigs obj_masterdata = new Cls_DrillingRigs();

    int insertgrdcount = 0;
    int grdcountbind = 0;
    //General.FileResult objfileResult = new General.FileResult();
    //DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (!IsPostBack)
            {
                BindDistricts();
                BindRTODistricts();
                FillDetails();
            }
        }
    }


    #region fill incomplete details
    public void FillDetails()
    {
        tr_gridview.Visible = false;
        ddl_rtodistrict.Enabled = true;
        string ConditionID = "1";
        DataSet ds = obj_masterdata.DB_GETDrillingRigscompletedetailsbyuserid(Convert.ToInt32(Session["uid"]));
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["AppStatus"])))
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["AppStatus"]) == "2")
                    {
                        hf_applicantregridid.Value= Convert.ToString(ds.Tables[0].Rows[0]["RegRigID"]);
                        rd_applicationtype.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Applicationtypeid"]);
                        ConditionID= Convert.ToString(ds.Tables[0].Rows[0]["Applicationtypeid"]);
                        txtNameOfApplicant.Text = Convert.ToString(ds.Tables[0].Rows[0]["Nameoftheapplicant"]);
                        ddlDIst.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AddDistrictId"]);
                        BindMandal();
                        ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AddMandalid"]);
                        BindVillage();
                        ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AddVillageid"]);
                        txtHouseNO.Text = Convert.ToString(ds.Tables[0].Rows[0]["Houseno"]);
                        txtStreet.Text = Convert.ToString(ds.Tables[0].Rows[0]["Street"]);
                        txtregistrationvehiclenno.Text = Convert.ToString(ds.Tables[0].Rows[0]["regvehicleno"]);
                        txt_placeofrtoregistration.Text = Convert.ToString(ds.Tables[0].Rows[0]["rtoplaceofregvehicle"]);
                        ddl_rtodistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RTODistrictID"]);
                        ddl_rtodistrict.Enabled = false;
                        txt_despofdrillingrig.Text = Convert.ToString(ds.Tables[0].Rows[0]["Descofdrillrigs"]);
                        txt_maxdiameterdepth.Text = Convert.ToString(ds.Tables[0].Rows[0]["maxdiameterdepth"]);
                        txt_areaofoperation.Text = Convert.ToString(ds.Tables[0].Rows[0]["Areaofoperation"]);
                        txt_contactmobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantMobileno"]);
                        txt_contactemailid.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantEmailID"]);

                        //                        RegRigID,Applicationtype,AddDistrictName,AddMandalname,AddVillagename,RTODistrictName,Isactive,CreatedOn,CreatedBy,CreatedIP,ModifiedOn,
                        //ModifiedBy,ModifiedIP,AppStatus,Stageid,PaymentDate,UIDNO,DWGODeptid,DWGOApprovalid,FeeAmount,PaymentDone

                    }
                }
            }
            
        }
        string RegRigID = "";
        if (!string.IsNullOrEmpty(hf_applicantregridid.Value))
        {
            RegRigID = Convert.ToString(hf_applicantregridid.Value);
            tr_gridview.Visible = true;
            Binddocumetmaster("1", ConditionID, Convert.ToString(Session["uid"]), RegRigID);
        }
       
    }

    #endregion

    #region Masters

    protected void rd_applicationtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        tr_gridview.Visible = false;
        string RegRigID = "";
       if (!string.IsNullOrEmpty(hf_applicantregridid.Value))
        {
            RegRigID = Convert.ToString(hf_applicantregridid.Value);
            tr_gridview.Visible = true;
            Binddocumetmaster("1", rd_applicationtype.SelectedValue, Convert.ToString(Session["uid"]), RegRigID);
        }
       
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    public void BindDistricts()
    {
        try
        {
            ddlDIst.Items.Clear();
            DataTable dsd = obj_masterdata.DB_getdistricts();
            if (dsd != null && dsd.Rows.Count > 0)
            {
                ddlDIst.DataSource = dsd;
                ddlDIst.DataValueField = "District_Id";
                ddlDIst.DataTextField = "District_Name";
                ddlDIst.DataBind();
                AddSelect(ddlDIst);
            }
            else
            {

                AddSelect(ddlDIst);
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void ddlDIst_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMandal.Items.Clear();
        if (ddlMandal.SelectedIndex == 0)
        {
            AddSelect(ddlMandal);
        }
        else
        {
            BindMandal();
        }
    }
    public void BindMandal()
    {
        DataTable dsm = obj_masterdata.DB_getmadals(ddlDIst.SelectedValue);
        if (dsm.Rows.Count > 0)
        {
            ddlMandal.DataSource = dsm;
            ddlMandal.DataValueField = "Mandal_Id";
            ddlMandal.DataTextField = "Manda_lName";
            ddlMandal.DataBind();
            AddSelect(ddlMandal);
        }
        else
        {
            ddlMandal.Items.Clear();
            AddSelect(ddlMandal);
        }
        BindVillage();
    }
    public void BindVillage()
    {
        try
        {
            ddlVillage.Items.Clear();
            DataTable dsv = obj_masterdata.DB_GetVillages(ddlMandal.SelectedValue);
            if (dsv.Rows.Count > 0)
            {
                ddlVillage.DataSource = dsv;
                ddlVillage.DataValueField = "Village_Id";
                ddlVillage.DataTextField = "Village_Name";
                ddlVillage.DataBind();
                AddSelect(ddlVillage);
            }
            else
            {
                ddlVillage.Items.Clear();
                AddSelect(ddlVillage);
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMandal.SelectedIndex == 0)
        {
            ddlVillage.Items.Clear();
            AddSelect(ddlVillage);
        }
        else
        {

            BindVillage();
        }
    }
    public void BindRTODistricts()
    {
        try
        {
            ddl_rtodistrict.Items.Clear();
            DataTable dsd = obj_masterdata.DB_getdistricts();
            if (dsd != null && dsd.Rows.Count > 0)
            {
                ddl_rtodistrict.DataSource = dsd;
                ddl_rtodistrict.DataValueField = "District_Id";
                ddl_rtodistrict.DataTextField = "District_Name";
                ddl_rtodistrict.DataBind();
                AddSelect(ddlDIst);
            }
            else
            {

                AddSelect(ddlDIst);
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void Binddocumetmaster(string ApplicationTypeID, string ConditionID, string userid,string RegRigID)
    {
        try
        {
            DataTable dsd = obj_masterdata.DB_documetmaster(ApplicationTypeID,ConditionID,userid, RegRigID);
            if (dsd != null && dsd.Rows.Count > 0)
            {
                grid_data.DataSource = dsd;
                grid_data.DataBind();
               
            }
        }
        catch (Exception ex)
        {

        }
    }

    #endregion


    #region Submit,payment

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        tr_check.Visible = false;
        btm_Payment.Visible = false;
        string errormsg = ValidateControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            if (save().ToUpper().ToString() != "" || save().ToUpper().ToString() != "0")
            {

                string message = "alert('Application Submitted Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                BtnSave.Enabled = false;
                //btm_Payment.Visible = true;
                tr_check.Visible = true;
            }
            else
            {
                string message = "alert('Application Submitted Failed')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }
       
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registrationfordrillingrigshandboring.aspx");
    }

    protected void chk_declare_CheckedChanged(object sender, EventArgs e)
    {
        btm_Payment.Visible = false;
        BtnSave.Visible = true;
        if (chk_declare.Checked == true)
        {
            string errormsg = ValidateControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                chk_declare.Checked = false;
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);              
                return;
            }
            else
            {
                //  BtnSave.Visible = true;
                btm_Payment.Visible = true;
            }
           
        }
       
    }

    protected void btm_Payment_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        if (save().ToUpper().ToString() != "" || save().ToUpper().ToString() != "0")
        {
            string intApplicationId = save().ToUpper().ToString();
            string message = "alert('Application Submitted Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            Response.Redirect("frmDepartmentRegistrationfordrillingrigsborewellPaymentDetails.aspx?intApplicationId=" + intApplicationId);

            //payment redrecit
        }
        else
        {
            string message = "alert('Application Submitted Failed')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
    }

    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (rd_applicationtype.SelectedValue == "0" || rd_applicationtype.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Application Type \\n";
            slno = slno + 1;
        }
        if (txtNameOfApplicant.Text == "0" || txtNameOfApplicant.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant Name \\n";
            slno = slno + 1;
        }
        if (ddlDIst.SelectedValue == "0" || ddlDIst.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select District  details\\n";
            slno = slno + 1;
        }
        if (ddlMandal.SelectedValue == "0" || ddlMandal.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Mandal details \\n";
            slno = slno + 1;
        }
        if (ddlVillage.SelectedValue == "0" || ddlVillage.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select village details \\n";
            slno = slno + 1;
        }
        if (txtHouseNO.Text == "0" || txtHouseNO.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter House No \\n";
            slno = slno + 1;
        }
        if (txtStreet.Text == "0" || txtStreet.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Street Name \\n";
            slno = slno + 1;
        }
        if (txtregistrationvehiclenno.Text == "0" || txtregistrationvehiclenno.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Registration No. of the vehicle\\n";
            slno = slno + 1;
        }
        //if (txt_placeofrtoregistration.Text == "0" || txt_placeofrtoregistration.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Place of registration with RTO \\n";
        //    slno = slno + 1;
        //}
        if (ddl_rtodistrict.SelectedValue == "0" || ddl_rtodistrict.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Select In which District RTO registration is Done \\n";
            slno = slno + 1;
        }
        if (txt_despofdrillingrig.Text == "0" || txt_despofdrillingrig.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Description of the drilling rig\\n";
            slno = slno + 1;
        }
        if (txt_maxdiameterdepth.Text == "0" || txt_maxdiameterdepth.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Max Diameter Depth(In inchs) \\n";
            slno = slno + 1;
        }
        if (txt_areaofoperation.Text == "0" || txt_areaofoperation.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Area of operation\\n";
            slno = slno + 1;
        }
        if (txt_contactmobileno.Text == "0" || txt_areaofoperation.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Contact Mobile No\\n";
            slno = slno + 1;
        }
        if (txt_contactemailid.Text == "0" || txt_areaofoperation.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Contact EmailID\\n";
            slno = slno + 1;
        }

        if (!string.IsNullOrEmpty(hf_applicantregridid.Value))
        {
            for (int i = 0; i < grid_data.Rows.Count; i++)
            {
                Label lbl_grddocname = grid_data.Rows[i].FindControl("lbl_grddocname") as Label;
                HiddenField hfform = grid_data.Rows[i].FindControl("hfform") as HiddenField;
                if (string.IsNullOrEmpty(hfform.Value))
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter" + lbl_grddocname.Text + "\\n";
                    slno = slno + 1;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(hfform.Value))
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter" + lbl_grddocname.Text + "\\n";
                        slno = slno + 1;
                    }
                    else
                    {
                        if (Convert.ToString(hfform.Value).Trim() == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter" + lbl_grddocname.Text + "\\n";
                            slno = slno + 1;
                        }
                    }

                }
            }

        }

        return ErrorMsg;
    }


    public string save()
    {
        string result = "";
        try
        {
            RegistrationDrillingRigspro objpro = new RegistrationDrillingRigspro();
            objpro.Applicationtypeid = Convert.ToInt32(rd_applicationtype.SelectedValue);
            objpro.Applicationtype = Convert.ToString(rd_applicationtype.SelectedItem.Text);
            objpro.Nameoftheapplicant = Convert.ToString(txtNameOfApplicant.Text);
            objpro.AddDistrictId = Convert.ToInt32(ddlDIst.SelectedValue);
            objpro.AddDistrictName = Convert.ToString(ddlDIst.SelectedItem.Text);
            objpro.AddMandalid = Convert.ToInt32(ddlMandal.SelectedValue);
            objpro.AddMandalname = Convert.ToString(ddlMandal.SelectedItem.Text);
            objpro.AddVillageid = Convert.ToInt32(ddlVillage.SelectedValue);
            objpro.AddVillagename = Convert.ToString(ddlVillage.SelectedItem.Text);
            objpro.Street = Convert.ToString(txtStreet.Text);
            objpro.Houseno = Convert.ToString(txtHouseNO.Text);
            objpro.regvehicleno = Convert.ToString(txtregistrationvehiclenno.Text);
            objpro.rtoplaceofregvehicle = Convert.ToString(txt_placeofrtoregistration.Text);
            objpro.RTODistrictID = Convert.ToInt32(ddl_rtodistrict.SelectedValue);
            objpro.RTODistrictName = Convert.ToString(ddl_rtodistrict.SelectedItem.Text);
            objpro.Descofdrillrigs = Convert.ToString(txt_despofdrillingrig.Text);
            objpro.maxdiameterdepth = Convert.ToDecimal(txt_maxdiameterdepth.Text);
            objpro.Areaofoperation = Convert.ToString(txt_areaofoperation.Text);
            objpro.ApplicantMobileno = Convert.ToString(txt_contactmobileno.Text);
            objpro.ApplicantEmailID = Convert.ToString(txt_contactemailid.Text);

            objpro.CreatedBy = Convert.ToString(Session["uid"]);
            objpro.CreatedIP = Request.ServerVariables["Remote_Addr"];
            //objpro.FileUploadPaths = GetFiles();
            result = obj_masterdata.DB_InsertDrillingRigs(objpro);
            if (result.ToUpper().ToString() != "" || result.ToUpper().ToString() != "0")
            {
                hf_applicantregridid.Value = result;
                FillDetails();
                //RegistrationDrillingRigsfileuploadspro objfileuploads = new RegistrationDrillingRigsfileuploadspro();
                //objfileuploads.ApplicationID = result;
                //objfileuploads.Created_by = Convert.ToString(Session["uid"]);
                //for (int i = 0; i < grid_data.Rows.Count; i++)
                //{
                //    HiddenField hfgrd_filetype = grid_data.Rows[i].FindControl("hfgrd_filetype") as HiddenField;
                //    HiddenField hfgrd_filename = grid_data.Rows[i].FindControl("hfgrd_filename") as HiddenField;
                //    HiddenField hfform = grid_data.Rows[i].FindControl("hfform") as HiddenField;
                //    Label lbl_grddocname = grid_data.Rows[i].FindControl("lbl_grddocname") as Label;

                //    objfileuploads.FileType = hfgrd_filetype.Value;
                //    objfileuploads.FilePath = hfform.Value;
                //    objfileuploads.FileName = hfgrd_filename.Value;
                //    objfileuploads.FileDescription = lbl_grddocname.Text;
                //    obj_masterdata.DB_InsertGroundwaterDrillingRigsattachments(objfileuploads);
                //}
                lblmsg.Text = "Submitted Successfully";
                success.Visible = true;
            }
            else
            {
                lblmsg.Text = "Submitted Failed";
                Failure.Visible = true;
            }
        }
        catch (Exception ex)
        {

            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

        return result;
    }

    #endregion


    #region Upload file
    protected void grid_data_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btnupdate = (e.Row.FindControl("btnupdate") as Button);
            HyperLink hyplink_grdview = (e.Row.FindControl("hyplink_grdview") as HyperLink);
            HiddenField hfform = (HiddenField)e.Row.FindControl("hfform");
            FileUpload File_formcontent = (FileUpload)e.Row.FindControl("File_formcontent");

            string CertificatePath = DataBinder.Eval(e.Row.DataItem, "FilePath").ToString();
            if (!string.IsNullOrEmpty(CertificatePath))
            {
                hfform.Value = CertificatePath;
                hyplink_grdview.Visible = true;
            }
            else
            {
                hfform.Value = "";
            }
        }
    }
    protected void grid_data_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Save")
        {
            //obj.CreatedBy = Convert.ToString(Session["UserName"]);
            //obj.CreatedIP = Request.ServerVariables["Remote_Addr"];

            string CandidateIDsno = Convert.ToString(e.CommandArgument);
            string[] arg = new string[2];
            arg = CandidateIDsno.Split(';');
            string CandidateID = Convert.ToString(arg[0]);
            int sno = Convert.ToInt32(arg[1]);

            Label lbl_grddocname = grid_data.Rows[sno].FindControl("lbl_grddocname") as Label;
            HyperLink hyplink_grdview = grid_data.Rows[sno].FindControl("hyplink_grdview") as HyperLink;
            HiddenField hfgrd_filetype = grid_data.Rows[sno].FindControl("hfgrd_filetype") as HiddenField;
            HiddenField hfgrd_filename = grid_data.Rows[sno].FindControl("hfgrd_filename") as HiddenField;
            HiddenField hfform = grid_data.Rows[sno].FindControl("hfform") as HiddenField;

            FileUpload File_formcontent = grid_data.Rows[sno].FindControl("File_formcontent") as FileUpload;
            if (File_formcontent.HasFile)
            {
                string extension = System.IO.Path.GetExtension(File_formcontent.FileName).ToLower();

                if (extension == ".pdf")
                {
                    if (File_formcontent.FileContent.Length <= 10000000)
                    {
                        try
                        {
                            //string subfoldername = Convert.ToString(Session["uid"]);
                            //string filename = File_formcontent.FileName;
                            string sFileDir = ConfigurationManager.AppSettings["RIGfilePath"];
                            string subfoldername = Convert.ToString(hf_applicantregridid.Value);
                            string filename = "";
                            filename = lbl_grddocname.Text + extension;
                            if (!Directory.Exists(Server.MapPath(@"~\Attachments\RigsHandboring\" + subfoldername)))
                            {
                                Directory.CreateDirectory(Server.MapPath(@"~\Attachments\RigsHandboring\" + subfoldername));
                            }
                            filename = filename.Trim();
                            filename = filename.Replace(' ', '_');
                            filename = filename.Replace('/', '_');
                            String filepath = Server.MapPath(@"~\Attachments\RigsHandboring\" + subfoldername + @"\" + filename);


                            File_formcontent.SaveAs(filepath);
                            string Uploaddetails = @"~\Attachments\RigsHandboring\" + subfoldername + @"\" + filename;

                            hfform.Value = Uploaddetails;
                        
                            hfgrd_filetype.Value = extension;
                            hfgrd_filename.Value = filename;
                            hyplink_grdview.NavigateUrl = Uploaddetails;
                            hyplink_grdview.Visible = true;


                            RegistrationDrillingRigsfileuploadspro objfileuploads = new RegistrationDrillingRigsfileuploadspro();
                            objfileuploads.ApplicationID =Convert.ToString(hf_applicantregridid.Value);
                            objfileuploads.Created_by = Convert.ToString(Session["uid"]);
                                objfileuploads.FileType = hfgrd_filetype.Value;
                                objfileuploads.FilePath = hfform.Value;
                                objfileuploads.FileName = hfgrd_filename.Value;
                                objfileuploads.FileDescription = lbl_grddocname.Text;
                             bool resultfileuplaid=obj_masterdata.DB_InsertGroundwaterDrillingRigsattachments(objfileuploads);



                            if (resultfileuplaid==true)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Successfully')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Failed')", true);
                              
                            }

                            //if (string.IsNullOrEmpty(hfform.Value))
                            //{
                            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Failed')", true);
                            //}
                            //else
                            //{
                            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Successfully')", true);
                            //}
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Failed')", true);
                        }
                    }
                    else
                    {
                        //lbl_msg.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Maximum Size Exceeded 10KB')", true);
                    }
                }
                else
                {
                    //lbl_msg.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('File Format not Supported')", true);
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Successfully')", true);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : Please choose file again')", true);

            }

        }
    }
    protected void grid_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_data.PageIndex = e.NewPageIndex;

    }

    #endregion



}