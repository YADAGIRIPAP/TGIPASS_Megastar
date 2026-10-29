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

public partial class UI_TSiPASS_waltaform2 : System.Web.UI.Page
{

    Cls_OSGroundWater obj_insert = new Cls_OSGroundWater();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (!IsPostBack)
            {
                BindApplicationTypemaster();
                BindTypeofwellmaster();
                BindModeofwaterdrawingmaster();
                BindDistricts();
                FillDetails();
            }
        }
    }

    #region Master
    public void BindApplicationTypemaster()
    {
        try
        {
            ddlApplicationForDigging.Items.Clear();
            DataSet dsd = obj_insert.DB_ApplicationTypemaster();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlApplicationForDigging.DataSource = dsd.Tables[0];
                ddlApplicationForDigging.DataValueField = "GWAppltypeID";
                ddlApplicationForDigging.DataTextField = "GWApplicationtype";
                ddlApplicationForDigging.DataBind();
                AddSelect(ddlApplicationForDigging);
            }
            else
            {

                AddSelect(ddlApplicationForDigging);
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void BindTypeofwellmaster()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddltypeofwell.Items.Clear();
            dsd = obj_insert.DB_Typeofwellmaster();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddltypeofwell.DataSource = dsd.Tables[0];
                ddltypeofwell.DataValueField = "GWTypeofwellID";
                ddltypeofwell.DataTextField = "GWTypeofwell";
                ddltypeofwell.DataBind();
                AddSelect(ddltypeofwell);
            }
            else
            {

                AddSelect(ddltypeofwell);
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void BindModeofwaterdrawingmaster()
    {
        try
        {
            ddlmode.Items.Clear();
            DataSet dsd = obj_insert.DB_Modeofwaterdrawingmaster();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlmode.DataSource = dsd.Tables[0];
                ddlmode.DataValueField = "GWModeofwaterID";
                ddlmode.DataTextField = "GWModeofwater";
                ddlmode.DataBind();
                AddSelect(ddlmode);
            }
            else
            {

                AddSelect(ddlmode);
            }
        }
        catch (Exception ex)
        {

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
            DataTable dsd = obj_insert.DB_GWgetdistricts();
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

        if (ddlDIst.SelectedIndex == 0)
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
        ddlMandal.Items.Clear();
        DataTable dsm = obj_insert.DB_GWgetmadals(ddlDIst.SelectedValue);
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
    public void BindVillage()
    {
        try
        {
            ddlVillage.Items.Clear();
            DataTable dsv = obj_insert.DB_GWGetVillages(ddlMandal.SelectedValue);
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
    public void BindGWdocumetmaster(string ApplicationTypeID,string userid, string RegRigID)
    {
        try
        {
            DataTable dsd = obj_insert.DB_GWdocumetmaster(ApplicationTypeID,userid, RegRigID);
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

    #region fill incomplete details

    public void ResetFormControl(Control parent)
    {
        try
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
                            //if (((DropDownList)c).Items.Count > 0)
                            //{
                            ((DropDownList)c).Enabled = false;
                            // }
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
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void FillDetails()
    {
        tr_gridview.Visible = false;
        ddlApplicationForDigging.Enabled = true;
        ddlDIst.Enabled = true;
        ddlMandal.Enabled = true;
       
        DataSet ds = obj_insert.GETGroundwaterincompletedetailsbyuserid(Convert.ToInt32(Session["uid"]));
        if(ds.Tables.Count>0)
        {
            if(ds.Tables[0].Rows.Count>0)
            {
                if(!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["App_Status"])))
                {
                        if (Convert.ToString(ds.Tables[0].Rows[0]["App_Status"])=="2" || Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]) == "3")
                    {
                        hf_applicantregridid.Value = Convert.ToString(ds.Tables[0].Rows[0]["ID"]);
                        ddlApplicationForDigging.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ApplicationType_IndusorAgri"]);
                        ddlApplicationForDigging.Enabled = false;
                        txtNameOfApplicant.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantName"]);
                        ddlDIst.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DistrictID"]);
                        ddlDIst.Enabled = false;
                        BindMandal();
                        ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["MandalId"]);
                        BindVillage();
                        ddlMandal.Enabled = false;
                        ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["VillageId"]);
                        txtHouseNO.Text = Convert.ToString(ds.Tables[0].Rows[0]["HouseNo"]);
                        txtStreet.Text = Convert.ToString(ds.Tables[0].Rows[0]["Street"]);
                        txtlocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocationOfWell"]);
                        if(!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["TypeofWell"])))
                        {
                            ddltypeofwell.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TypeofWell"]);
                        }
                        if(!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["TypeOfDrwngWater"])))
                        {
                            ddlmode.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TypeOfDrwngWater"]);
                        }                        
                        txtSpecification.Text = Convert.ToString(ds.Tables[0].Rows[0]["SpecifactioncnOFPump"]);
                        txtdistance.Text = Convert.ToString(ds.Tables[0].Rows[0]["DistanceFromExistWell"]);
                        txt_contactmobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantMobileNO"]);
                        txt_contactemailid.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantEmailID"]);
                    }
                 
                    
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["StageId"])))
                    {
                        if(Convert.ToInt16(ds.Tables[0].Rows[0]["StageId"])>=4)
                        {
                            ResetFormControl(this);
                        }
                    }


                }


            }
        }

        string GroundwaterID = "";
        if (!string.IsNullOrEmpty(hf_applicantregridid.Value))
        {
            GroundwaterID = Convert.ToString(hf_applicantregridid.Value);
            tr_gridview.Visible = true;
            BindGWdocumetmaster("2", Convert.ToString(Session["uid"]), GroundwaterID);
        }
    }

    #endregion

    #region button click
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("waltaform2.aspx");
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
        else
        {
            if (save().ToUpper().ToString() != "" || save().ToUpper().ToString() != "0")
            {
                string intApplicationId = save().ToUpper().ToString();
                string message = "alert('Application Submitted Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                Response.Redirect("frmDepartmentGroundwaterPaymentDetails.aspx?intApplicationId=" + intApplicationId);

                //payment redrecit
            }
            else
            {
                string message = "alert('Application Submitted Failed')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }
    }
  
    #endregion

    #region Submit,payment
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (ddlApplicationForDigging.SelectedValue == "0" || ddlApplicationForDigging.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Application for digging a new well \\n";
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
        if (txtlocation.Text == "0" || txtlocation.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Location of Proposed Well \\n";
            slno = slno + 1;
        }
        if (ddltypeofwell.SelectedValue == "0" || ddltypeofwell.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Type of Well to be dug \\n";
            slno = slno + 1;
        }
        if (txtdistance.Text == "0" || txtdistance.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Distance from existing functional well \\n";
            slno = slno + 1;
        }
        if (txt_contactmobileno.Text == "0" || txt_contactmobileno.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant Contact Mobile Number \\n";
            slno = slno + 1;
        }
        if (txt_contactemailid.Text == "0" || txt_contactemailid.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant Contact EmailID \\n";
            slno = slno + 1;
        }
        //if (ddlmode.SelectedValue == "0" || ddlmode.SelectedItem.Text == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Mode of drawing water \\n";
        //    slno = slno + 1;
        //}
        //if (txtSpecification.Text == "0" || txtSpecification.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Specification of Pump \\n";
        //    slno = slno + 1;
        //}
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
                tr_check.Visible = true;
                btm_Payment.Visible = false;
            }
            else
            {
                string message = "alert('Application Submitted Failed')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }
    }
    public string save()
    {
        string result = "";
        WaltaApplDetailsproperties ObjWaltaApplDetails = new WaltaApplDetailsproperties();
        try
        {
            ObjWaltaApplDetails.ApplicationType_IndusorAgri =Convert.ToString(ddlApplicationForDigging.SelectedValue);
            ObjWaltaApplDetails.ApplicationType_IndusorAgriName = Convert.ToString(ddlApplicationForDigging.SelectedItem.Text);
            ObjWaltaApplDetails.ApplicantName = Convert.ToString(txtNameOfApplicant.Text);
            ObjWaltaApplDetails.DistrictID = Convert.ToString(ddlDIst.SelectedValue);
            ObjWaltaApplDetails.DistrictName = Convert.ToString(ddlDIst.SelectedItem.Text);
            ObjWaltaApplDetails.MandalId = Convert.ToString(ddlMandal.SelectedValue);
            ObjWaltaApplDetails.MandalName = Convert.ToString(ddlMandal.SelectedItem.Text);
            ObjWaltaApplDetails.VillageId = Convert.ToString(ddlVillage.SelectedValue);
            ObjWaltaApplDetails.VillageName = Convert.ToString(ddlVillage.SelectedItem.Text);
            ObjWaltaApplDetails.Street = Convert.ToString(txtStreet.Text);
            ObjWaltaApplDetails.HouseNo = Convert.ToString(txtHouseNO.Text);
            ObjWaltaApplDetails.LocationOfWell = Convert.ToString(txtlocation.Text);
            ObjWaltaApplDetails.TypeofWell = Convert.ToString(ddltypeofwell.SelectedValue);
            ObjWaltaApplDetails.TypeofWellName = Convert.ToString(ddltypeofwell.SelectedItem.Text);
            ObjWaltaApplDetails.TypeOfDrwngWater = Convert.ToString(ddlmode.SelectedValue);
            ObjWaltaApplDetails.TypeOfDrwngWaterName = Convert.ToString(ddlmode.SelectedItem.Text);
            ObjWaltaApplDetails.SpecifactioncnOFPump = Convert.ToString(txtSpecification.Text);
            ObjWaltaApplDetails.DistanceFromExistWell = Convert.ToString(txtdistance.Text);
            ObjWaltaApplDetails.ApplicantMobileNO = Convert.ToString(txt_contactmobileno.Text);
            ObjWaltaApplDetails.ApplicantEmailID = Convert.ToString(txt_contactemailid.Text);
            ObjWaltaApplDetails.GroundwaterID = Convert.ToString(hf_applicantregridid.Value);
            if (chk_declare.Checked == true)
            {
                ObjWaltaApplDetails.ChkAcceptence = "Y";
            }
            ObjWaltaApplDetails.Createdby = Convert.ToString(Session["uid"]);
            ObjWaltaApplDetails.CreatedIP = Request.ServerVariables["Remote_Addr"];

                result = obj_insert.insertWaltaApplicationDetails(ObjWaltaApplDetails);
                if (result.ToUpper().ToString() != "" || result.ToUpper().ToString() != "0")
                {
                hf_applicantregridid.Value = result;
                FillDetails();
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

    #region fileupload
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
                            string subfoldername = Convert.ToString(hf_applicantregridid.Value);
                            string filename = "";
                            filename = lbl_grddocname.Text + extension;
                            if (!Directory.Exists(Server.MapPath(@"~\Attachments\GroundWaterWaltForm\" + subfoldername)))
                            {
                                Directory.CreateDirectory(Server.MapPath(@"~\Attachments\GroundWaterWaltForm\" + subfoldername));
                            }
                            filename = filename.Trim();
                            filename = filename.Replace(' ', '_');
                            filename = filename.Replace('/', '_');
                            String filepath = Server.MapPath(@"~\Attachments\GroundWaterWaltForm\" + subfoldername + @"\" + filename);


                            File_formcontent.SaveAs(filepath);
                            string Uploaddetails = @"~\Attachments\GroundWaterWaltForm\" + subfoldername + @"\" + filename;

                            hfform.Value = Uploaddetails;

                            hfgrd_filetype.Value = extension;
                            hfgrd_filename.Value = filename;
                            hyplink_grdview.NavigateUrl = Uploaddetails;
                            hyplink_grdview.Visible = true;


                            WaltaApplfileuploadspro objfileuploads = new WaltaApplfileuploadspro();
                            objfileuploads.ApplicationID = Convert.ToString(hf_applicantregridid.Value);
                            objfileuploads.Created_by = Convert.ToString(Session["uid"]);
                            objfileuploads.FileType = hfgrd_filetype.Value;
                            objfileuploads.FilePath = hfform.Value;
                            objfileuploads.FileName = hfgrd_filename.Value;
                            objfileuploads.FileDescription = lbl_grddocname.Text;
                            bool resultfileuplaid = obj_insert.DB_InsertGroundwaterWaltapplattachments(objfileuploads);



                            if (resultfileuplaid == true)
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

    protected void ddlApplicationForDigging_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlApplicationForDigging.SelectedValue == "1")
        {
            //Response.Redirect("Category.aspx");
            Response.Redirect("frmQuesstionniareReg1.aspx");

        }
    }
}