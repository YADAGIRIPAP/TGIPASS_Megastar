using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using BusinessLogic;

public partial class RawMaterial_ : System.Web.UI.Page
{
General Gen = new General();
comFunctions cmf = new comFunctions();
    //string strConn = ConfigurationManager.ConnectionStrings["RawConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
           Response.Redirect("~/WebiPASS.aspx",false);
        }

        if(!Page.IsPostBack)
        {
        getdistricts();
        }
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        getMandals();
    }

    //protected void ddlAllotment_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddlUOM.Enabled = false;
    //    if (ddlAllotment.SelectedIndex > 0)
    //    {
    //        switch (ddlAllotment.SelectedValue)
    //        { 
    //            case "1":
    //            case "2":
    //                ddlUOM.SelectedValue = "1";
    //                break;                
    //            case "3":
    //            case "4":
    //                ddlUOM.SelectedValue = "2";
    //                break;
    //            default:
    //                ddlUOM.SelectedIndex = 0;
    //                break;
    //        }
    //    }
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        Insert();
    }
    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistrictsbystate("31");
        ddlDistrict.DataSource = dsnew.Tables[0];
        ddlDistrict.DataTextField = "District_Name";
        ddlDistrict.DataValueField = "District_Id";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, "--Select--");

    }

    void getMandals()
    {

        DataSet dsnew = new DataSet();
        
        dsnew = Gen.Getmandalsbydistrict(ddlDistrict.SelectedValue.ToString());
        ddlMandal.DataSource = dsnew.Tables[0];
        ddlMandal.DataTextField = "Manda_lName";
        ddlMandal.DataValueField = "Mandal_Id";
        ddlMandal.DataBind();
        ddlMandal.Items.Insert(0, "--Select--");


    }

    public void Insert()
    {
        string filename1 = string.Empty; string filename2 = string.Empty; string filename3 = string.Empty; string filename4 = string.Empty; string filename5 = string.Empty; string filename6 = string.Empty; string filename7 = string.Empty;
        string EmNo = txtEmNo.Text.Trim();
        string ApplicationType = rbtType.SelectedItem.Text;
        string UnitName = txtUnitName.Text.Trim();
        string District = ddlDistrict.SelectedItem.Value;
        string Mandal = ddlMandal.SelectedItem.Value;
        string Address = txtAddress.Text.Trim();
        string Allotment = ddlAllotment.SelectedItem.Value;
        string Requirement = txtRequirement.Text.Trim();
        string Usage = txtUsage.Text.Trim();

        string dirpath = Server.MapPath("").ToString() + "\\RawMaterialUploads\\" + Session["uid"].ToString();
        if(!Directory.Exists(dirpath)) Directory.CreateDirectory(dirpath);

        if (fileExisting.HasFile)
        {            
           fileExisting.SaveAs(dirpath + "\\" + fileExisting.FileName);
           filename1 = fileExisting.FileName;
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale41", "alert('Please Upload Mandatory Documents');", true);
            return;
        }

        if (fileCFO.HasFile)
        {
            fileCFO.SaveAs(dirpath + "\\" + fileCFO.FileName);
            filename2 = fileCFO.FileName;
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale41", "alert('Please Upload Mandatory Documents');", true);
            return;
        }

        if (fileBoiler.HasFile)
        {
                fileBoiler.SaveAs(dirpath + "\\" + fileBoiler.FileName);
                 filename3 = fileBoiler.FileName;
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale41", "alert('Please Upload Mandatory Documents');", true);
            return;
        }

        if (fileproduction.HasFile)
        {
            fileproduction.SaveAs(dirpath + "\\" + fileproduction.FileName);
                 filename4 = fileproduction.FileName;

         
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale41", "alert('Please Upload Mandatory Documents');", true);
            return;
        }

        if (fileVAT.HasFile)
        {
            fileVAT.SaveAs(dirpath + "\\" + fileVAT.FileName);
                 filename5 = fileVAT.FileName;

            
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale41", "alert('Please Upload Mandatory Documents');", true);
            return;
        }

        if (fileRG1.HasFile)
        {
          fileRG1.SaveAs(dirpath + "\\" + fileRG1.FileName);
                 filename6 = fileRG1.FileName;

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale41", "alert('Please Upload Mandatory Documents');", true);
            return;
        }

        if (fileFlowChart.HasFile)
        {
            fileFlowChart.SaveAs(dirpath + "\\" + fileFlowChart.FileName);
                 filename7 = fileFlowChart.FileName;

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ale41", "alert('Please Upload Mandatory Documents');", true);
            return;
        }

        BusinessLogic.DML objDml=new BusinessLogic.DML();
        DataSet dss = new DataSet();
      dss=  objDml.InsUpdDelRawmaterial("I", 0, EmNo, ApplicationType, UnitName, District, Mandal, Address, Allotment, Requirement, Usage, filename1, filename2, filename3, filename4, filename5, filename6, filename7, Session["uid"].ToString(), DateTime.Now, "", DateTime.Now,(ddlUOM.SelectedIndex>0?ddlUOM.SelectedValue:"0"));

      cmf.SendMailTSiPASSRaw(Session["Email"].ToString().Trim(), "Dear " + UnitName + "  :<br/><br/> Your Application has been registered vide number <b>" + System.DateTime.Now.Year.ToString() + "-RAW-" + dss.Tables[0].Rows[0][0].ToString() + "</b>. Thank You.");


     
        ClientScript.RegisterStartupScript(this.GetType(), "ale1", "alert('Submitted Successfully');", true);


        txtEmNo.Text = "";
        txtUnitName.Text = "";
        ddlDistrict.SelectedIndex = 0;
        ddlMandal.SelectedIndex = 0;
        txtAddress.Text = "";
        ddlAllotment.SelectedIndex = 0;
        txtRequirement.Text = "";
        ddlUOM.SelectedIndex = 0;
        txtUsage.Text = "";




        }


    }
