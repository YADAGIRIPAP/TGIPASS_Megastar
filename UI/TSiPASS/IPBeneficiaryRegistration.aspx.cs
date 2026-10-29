using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CheckPOITD : System.Web.UI.Page
{
    //designing and developed by siva as on 27-02-2016

    //Purpose : To Add Beneficiary Details
    //Tables used : tbl_BeneficiaryDet
    //Stored procedures Used : InsUpdBenDetails,sp_getCounties,sp_getPayams,getBomasbyID

    General Gen = new General();

    byte[] Photo = new byte[1];
    string PhotoFileName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }
        if (!IsPostBack)
        {
            Gen.getVulnerbility(ddlDisability);
            Gen.getStates(ddlState);
            Gen.getIpDet(ddlIP);
            if (Session["user_type"].ToString() == "IP")
            {
                ddlIP.SelectedValue = ddlIP.Items.FindByValue(Session["User_Code"].ToString()).Value;
                ddlIP.Enabled = false;
            }

            for (int i = 15; i <= 100; i++)
            {
                //ddlAge.Items.Insert("--Select--", 0);
                ddlAge.Items.Add(i.ToString());

            }

            Session["Photo"] = Photo;
            Session["PhotoFileName"] = "";
            
            if (FileUpload1.HasFile)
            {
                Session["FileUpload11"] = FileUpload1;
                hdfUploadFile1.Value = FileUpload1.FileName;
            }
            else if (Session["FileUpload11"] != null)
            {
                FileUpload1 = (FileUpload)Session["FileUpload11"];
                hdfUploadFile1.Value = FileUpload1.FileName;
            }



        }

        if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
        {
            if (FileUpload1.PostedFile.ContentLength <= 307200)
            {
                lblmsg.Text = "";
                //lblFileName.Text = "";
                UploadImage();

            }
            else
                lblmsg.Text = "Trainee image should be less than 300 KB";
        }

            if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            {
                FillDetails();
                if (Session["userlevel"].ToString() == "1")
                {
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
                BtnSave1.Text = "Update";
                
            }

            
    }



    void UploadImage()
    {

        //PhotoFilename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        Session["PhotoFileName"] = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);

        try
        {
            string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
            int letterI = fileType.Length;
            //Photo = new byte[FileUpload1.PostedFile.ContentLength];

            //    Session["Photo"] = new byte[FileUpload1.PostedFile.ContentLength];

            if (
                fileType[letterI - 1].ToUpper().Trim() == "PNG" ||
                fileType[letterI - 1].ToUpper().Trim() == "JPG" ||
                fileType[letterI - 1].ToUpper().Trim() == "GIF" ||
                fileType[letterI - 1].ToUpper().Trim() == "JPEG")
            {
                //Photo = new byte[FileUpload1.PostedFile.ContentLength];

                Session["Photo"] = new byte[FileUpload1.PostedFile.ContentLength];
                HttpPostedFile Image = FileUpload1.PostedFile;
                //Image.InputStream.Read(Photo, 0, (int)FileUpload1.PostedFile.ContentLength);
                //lblFileName.Text = PhotoFilename;
                //  ObjectToByteArray(Session["Photo"]);
                Image.InputStream.Read((byte[])Session["Photo"], 0, (int)FileUpload1.PostedFile.ContentLength);
                lblFileName.Text = Session["PhotoFileName"].ToString();

                //   Session["Photo"] = Photo;
                //   Session["PhotoFileName"] = PhotoFilename;

                Image1.ImageUrl = "ScanImage.aspx";



            }
            else
            {
                lblmsg.Text = "Image format should be JPG or JPEG or GIF or PNG";

            }

        }
        catch (Exception ex)
        {

            lblmsg.Text = "An Error Occured. Please Try Again!" + ex.Message;

        }

        finally
        {

        }


        FileUpload1.Focus();

    }

    void FillDetails()
    {
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();


        ds = Gen.GetBenficiaryDetByID(hdfID.Value.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlIP.SelectedValue = ddlIP.Items.FindByValue(ds.Tables[0].Rows[0]["intIP"].ToString()).Value;
            ddlIP.Enabled = false;
            if (ds.Tables[0].Rows[0]["Age"].ToString()!="")
            ddlAge.SelectedValue = ds.Tables[0].Rows[0]["Age"].ToString();

            txtSourceIncome.Text = ds.Tables[0].Rows[0]["SOurceofIncome"].ToString();

            txtHomePhone.Text = ds.Tables[0].Rows[0]["SecondLineHome"].ToString();
            txtEnrollment.Text = ds.Tables[0].Rows[0]["EnrollmentNo"].ToString();
            txtHeadName.Text = ds.Tables[0].Rows[0]["NameofHousehold"].ToString();
            txtFamilySize.Text = ds.Tables[0].Rows[0]["FamilySize"].ToString();
            ddlSex.SelectedValue = ddlSex.Items.FindByValue(ds.Tables[0].Rows[0]["Sex"].ToString()).Value;
            txtSpouse.Text = ds.Tables[0].Rows[0]["NameofSpouse"].ToString();
            txtNoofAdults.Text = ds.Tables[0].Rows[0]["NoofAdult"].ToString();
            txtdependents.Text = ds.Tables[0].Rows[0]["NoofDependents"].ToString();
            txtIncome.Text = ds.Tables[0].Rows[0]["FamilyIncome"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtContactNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

            ddlIsdisability.SelectedValue = ddlIsdisability.Items.FindByValue(ds.Tables[0].Rows[0]["IsDisability"].ToString()).Value;
            if (ds.Tables[0].Rows[0]["intDisability"].ToString()!="")
            ddlDisability.SelectedValue = ddlDisability.Items.FindByValue(ds.Tables[0].Rows[0]["intDisability"].ToString()).Value;
            txtBiometric.Text = ds.Tables[0].Rows[0]["BiometricNo"].ToString();
            txtBankName.Text = ds.Tables[0].Rows[0]["NameofBank"].ToString();
            txtAccNo.Text = ds.Tables[0].Rows[0]["AccountNo"].ToString();
            if (ds.Tables[0].Rows[0]["LegalStatus"].ToString()!="")
            ddlLegalStatus.SelectedValue = ds.Tables[0].Rows[0]["LegalStatus"].ToString();
            txtReAccNo.Text = ds.Tables[0].Rows[0]["AccountNo"].ToString();

            
            if (ds.Tables[0].Rows[0]["intStateid"].ToString() != "")
            {
                ddlState.SelectedValue = ds.Tables[0].Rows[0]["intStateid"].ToString();
                getcounties();
            }
            if (ds.Tables[0].Rows[0]["intCountieid"].ToString() != "")
            {
                ddlCounties.SelectedValue = ds.Tables[0].Rows[0]["intCountieid"].ToString();
                getPayams();
            }
            if (ds.Tables[0].Rows[0]["intPayamid"].ToString() != "")
            {
                ddlPayam.SelectedValue = ds.Tables[0].Rows[0]["intPayamid"].ToString();
                getBomas();
            }
            if (ds.Tables[0].Rows[0]["intBomasid"].ToString() != "")
                ddlBoma.SelectedValue = ds.Tables[0].Rows[0]["intBomasid"].ToString();

            if (ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["PhotoFileName"].ToString() != "" && ds.Tables[1].Rows[0]["PhotoFileName"] != null)
                {
                    lblFileName.Text = ds.Tables[1].Rows[0]["PhotoFileName"].ToString();
                    
                    Image1.ImageUrl = "viewAttachemnt.aspx?id=" + Convert.ToString(hdfID.Value.ToString()).Trim() + "&Type=Appicant Photo";

                     
                    if (ds.Tables[1].Rows[0]["Photo"].ToString().Trim() != "")
                    {
                        Photo = (byte[])ds.Tables[1].Rows[0]["Photo"];
                        Session["Photo"] = Photo;
                        Session["PhotoFileName"] = ds.Tables[1].Rows[0]["PhotoFileName"].ToString();
                    }
                    
                }
                else
                {
                    lblFileName.Text = "";
                }
            }



        }
    }    
    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (BtnSave1.Text == "Save")
        {
            int i = Gen.InsUpdBenDetails("0", ddlIP.SelectedValue, txtEnrollment.Text, txtHeadName.Text, txtFamilySize.Text, ddlSex.SelectedValue, txtSpouse.Text, txtNoofAdults.Text, txtdependents.Text, txtIncome.Text, ddlState.SelectedValue, ddlCounties.SelectedValue, ddlPayam.SelectedValue, ddlBoma.SelectedValue, txtAddress.Text, txtContactNo.Text, txtEmail.Text, txtHomePhone.Text, ddlIsdisability.SelectedValue, ddlDisability.SelectedValue, txtBiometric.Text, txtBankName.Text, txtAccNo.Text, Session["uid"].ToString(), ddlLegalStatus.SelectedValue, ddlAge.SelectedValue, txtSourceIncome.Text);
            if (i != 999)
            {
                int j = Gen.InsrtUpdAttachment(i.ToString(), (byte[])(Session["Photo"]), Session["PhotoFileName"].ToString().Trim(), "Appicant Photo", Session["uid"].ToString());


                lblmsg.Text = "Submited Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
            }
            else
            {
                lblmsg0.Text = "Already Exist. ";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        else
        {

            int i = Gen.InsUpdBenDetails(hdfID.Value, ddlIP.SelectedValue, txtEnrollment.Text, txtHeadName.Text, txtFamilySize.Text, ddlSex.SelectedValue, txtSpouse.Text, txtNoofAdults.Text, txtdependents.Text, txtIncome.Text, ddlState.SelectedValue, ddlCounties.SelectedValue, ddlPayam.SelectedValue, ddlBoma.SelectedValue, txtAddress.Text, txtContactNo.Text, txtEmail.Text, txtHomePhone.Text, ddlIsdisability.SelectedValue, ddlDisability.SelectedValue, txtBiometric.Text, txtBankName.Text, txtAccNo.Text, Session["uid"].ToString(), ddlLegalStatus.SelectedValue,ddlAge.SelectedValue,txtSourceIncome.Text);
            if (i != 999)
            {

                int j = Gen.InsrtUpdAttachment(hdfID.Value, (byte[])(Session["Photo"]), Session["PhotoFileName"].ToString().Trim(), "Appicant Photo", Session["uid"].ToString());

                lblmsg.Text = "Updated Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
            }
            else
            {
                lblmsg0.Text = "Already Exist. ";
                success.Visible = false;
                Failure.Visible = true;
                //lblmsg.Text = "Added Successfully..!";
            }
        }
    }

    void clear()
    {
        ddlLegalStatus.SelectedIndex = 0;
        txtSourceIncome.Text = "";
        Image1.ImageUrl = "~/Resource/Images/not-available.jpg";
        lblFileName.Text = "";
        BtnSave1.Text = "Save";
        txtReAccNo.Text = "";
        ddlAge.SelectedIndex = 0;
        txtHomePhone.Text = "";
        txtEnrollment.Text="";
        txtHeadName.Text="";
        txtFamilySize.Text="";
        ddlSex.SelectedIndex=0;
        txtSpouse.Text="";
        txtNoofAdults.Text="";
        txtdependents.Text="";
        txtIncome.Text="";
        txtAddress.Text="";
        txtContactNo.Text="";
        txtEmail.Text="";
        txtHomePhone.Text="";
        ddlIsdisability.SelectedIndex=0;
        ddlDisability.SelectedIndex=0;
        txtBiometric.Text="";
        txtBankName.Text="";
        txtAccNo.Text = "";

        ddlState.SelectedIndex = 0;
        ddlCounties.Items.Clear();
        ddlCounties.Items.Insert(0, "--Select--");
        ddlCounties.SelectedIndex = 0;

        ddlPayam.Items.Clear();
        ddlPayam.Items.Insert(0, "--Select--");
        ddlPayam.SelectedIndex = 0;

        ddlBoma.Items.Clear();

        ddlBoma.Items.Insert(0, "--Select--");
        ddlBoma.SelectedIndex = 0;
        BtnDelete.Visible = false;

        
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("IPBeneficiaryRegistration.aspx");
    }
    protected void DropDownList25_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIsdisability.SelectedValue == "Y")
        {
            trdisability.Visible = true;
        }
        else
        {
            trdisability.Visible = false;
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        getcounties();
    }
    void getcounties()
    {
        ddlCounties.Items.Clear();
        ddlPayam.Items.Clear();
        if (ddlState.SelectedIndex != 0)
        {
            Gen.getCounties(ddlCounties, ddlState.SelectedValue);
        }
        else
        {
            ddlCounties.Items.Insert(0, "--Select--");
            ddlPayam.Items.Insert(0, "--Select--");

        }
    }

    void getPayams()
    {
        ddlPayam.Items.Clear();
        if (ddlCounties.SelectedIndex != 0)
        {
            Gen.getPayams(ddlPayam, ddlCounties.SelectedValue);
        }
        else
        {
            ddlPayam.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {
        getPayams();
    }
    protected void ddlPayam_SelectedIndexChanged(object sender, EventArgs e)
    {
        getBomas();
    }
    void getBomas()
    {
        ddlBoma.Items.Clear();
        if (ddlPayam.SelectedIndex != 0)
        {
            Gen.getBomas(ddlBoma, ddlPayam.SelectedValue);
        }
        else
        {
            ddlBoma.Items.Insert(0, "--Select--");
        }
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {

    }
}
