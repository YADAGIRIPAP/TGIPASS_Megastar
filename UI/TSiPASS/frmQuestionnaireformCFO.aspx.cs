using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmQuestionnaireformCFO : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString.Count > 0)
        //{
        QuesionerVO questionnaireobj = new QuesionerVO();
        questionnaireobj = (QuesionerVO)Session["CFOQuestionnaire"];
        //Session["Grid"] = grdDetails;

        //DataSet ds = new DataSet();
        //ds = Gen.GetCFOQuestionereisReceiptDetails(Request.QueryString[0].ToString().Trim());
        //if (ds.Tables[0].Rows.Count > 0)
        //{

        LblSectionofExterprise.Text = questionnaireobj.Sector_Ent;
        txtDistrict.Text = questionnaireobj.Prop_intDistrictid;
        lblMandal.Text = questionnaireobj.Prop_intMandalid;
        lblVillage.Text = questionnaireobj.Prop_intVillageid;
        txtValueOfLand.Text = questionnaireobj.Val_Land;
        txtValueOfBulding.Text = questionnaireobj.Val_Plant;
        txtValueOfPlant.Text = questionnaireobj.Val_Plant; // ds.Tables[0].Rows[0]["Val_Plant"].ToString().Trim();
        txtTotalValue.Text = questionnaireobj.Tot_PrjCost; //ds.Tables[0].Rows[0]["Tot_PrjCost"].ToString().Trim();
        if (questionnaireobj.Hight_Build == "Y")
            txtBuildingHeight.Text = "Yes";
        else
            txtBuildingHeight.Text = "No";
        //if (questionnaireobj.) == "Y")
        //    txtNOCFormFire.Text = "Yes";
        //else
        //    txtNOCFormFire.Text = "No";
        //if (ds.Tables[0].Rows[0]["HaveyourTakePolution"].ToString().Trim() == "Y")
        //    lblCfePCB.Text = "Yes";
        //else
        //    lblCfePCB.Text = "No";
        //txtActivity.Text = ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString().Trim();
        //txtPolutionCategory.Text = ds.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim();
        //if (ds.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "O")
        //    txtPolutionCategory.Text = "Orange";
        //else if (ds.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
        //    txtPolutionCategory.Text = "Green";
        //else if (ds.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
        //    txtPolutionCategory.Text = "White";
        //else
        //    txtPolutionCategory.Text = "Red";

        //if (ds.Tables[0].Rows[0]["License_Factory"].ToString().Trim() == "Y")
        //    txtLicence.Text = "Yes";
        //else
        //    txtLicence.Text = "No";
        //if (ds.Tables[0].Rows[0]["High_Tension_Meter"].ToString().Trim() == "Y")
        //    txtHtMeter.Text = "Yes";
        //else
        //    txtHtMeter.Text = "No";
        //if (ds.Tables[0].Rows[0]["NOC_Fire"].ToString().Trim() == "Y")
        //    txtNOCFormFire.Text = "Yes";
        //else
        //    txtNOCFormFire.Text = "No";
        //if (ds.Tables[0].Rows[0]["Product_Drugs"].ToString().Trim() == "Y")
        //    txtDrugsRelated.Text = "Yes";
        //else
        //    txtDrugsRelated.Text = "No";
        //if (ds.Tables[0].Rows[0]["Bioler_Industry"].ToString().Trim() == "Y")
        //    txtBoilerRequired.Text = "Yes";
        //else
        //    txtBoilerRequired.Text = "No";


        //grdDetails.DataSource = ds.Tables[1];
        //grdDetails.DataBind();
        //if (ds.Tables[0].Rows[0]["Appl_Type"].ToString().Trim() != "")
        //{
        //    if (ds.Tables[0].Rows[0]["Appl_Type"].ToString().Trim() == "1")
        //    {
        //        txtApplicationType.Text = "Change of Land Use";

        //    }
        //    else if (ds.Tables[0].Rows[0]["Appl_Type"].ToString().Trim() == "2")
        //    {
        //        txtApplicationType.Text = "Build Permission Approval";

        //    }
        //    else
        //    {
        //        txtApplicationType.Text = "Both";
        //    }
        //}
        //else
        //{
        //    txtApplicationType.Text = "";
        //}
    }



    //}


}