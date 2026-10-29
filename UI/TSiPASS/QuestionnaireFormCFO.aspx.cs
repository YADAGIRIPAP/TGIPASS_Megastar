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

public partial class UI_TSiPASS_QuestionnaireFormCFO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CFOQuestionnaire"] != null)
        {
            DataSet ds = new DataSet();
            QuesionerVO Questionnaireobj = (QuesionerVO)Session["CFOQuestionnaire"];

            LblSectionofExterprise.Text = Questionnaireobj.nameofunit;
            txtDistrict.Text = Questionnaireobj.Prop_intDistrictid;
            lblMandal.Text = Questionnaireobj.Prop_intMandalid;
            lblVillage.Text = Questionnaireobj.Prop_intVillageid;
            //txtValueOfLand.Text = ds.Tables[0].Rows[0]["Val_Land"].ToString().Trim();
            //txtValueOfBulding.Text = ds.Tables[0].Rows[0]["Val_Build"].ToString().Trim();
            //txtValueOfPlant.Text = ds.Tables[0].Rows[0]["Val_Plant"].ToString().Trim();
            txtTotalValue.Text = Questionnaireobj.Tot_PrjCost;
            if (Questionnaireobj.Hight_Build== "Y")
                txtBuildingHeight.Text = "Yes";
            else
                txtBuildingHeight.Text = "No";
            //if (Questionnaireobj.NOC == "Y")
            //    txtNOCFormFire.Text = "Yes";
            //else
            //    txtNOCFormFire.Text = "No";
            //if (ds.Tables[0].Rows[0]["HaveyourTakePolution"].ToString().Trim() == "Y")
            //    lblCfePCB.Text = "Yes";
            //else
            //    lblCfePCB.Text = "No";
            txtActivity.Text = Questionnaireobj.intLineofActivity;
            txtPolutionCategory.Text = Questionnaireobj.Pol_Category;
            if ( Questionnaireobj.Pol_Category == "O")
                txtPolutionCategory.Text = "Orange";
            else if ( Questionnaireobj.Pol_Category == "G")
                txtPolutionCategory.Text = "Green";
            else if ( Questionnaireobj.Pol_Category == "W")
                txtPolutionCategory.Text = "White";
            else
                txtPolutionCategory.Text = "Red";

            //if ( Questionnaireobj.Pol_Category == "Y")
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

            txtActivity.Text = Questionnaireobj.intLineofActivity;
            txtPolutionCategory.Text = Questionnaireobj.Pol_Category;
            if (Questionnaireobj.Pol_Category == "O")
                txtPolutionCategory.Text = "Orange";
            else if (Questionnaireobj.Pol_Category == "G")
                txtPolutionCategory.Text = "Green";
            else if (Questionnaireobj.Pol_Category == "W")
                txtPolutionCategory.Text = "White";
            else
                txtPolutionCategory.Text = "Red";

            if (Questionnaireobj.Pol_Category == "Y")
                txtLicence.Text = "Yes";
            else
                txtLicence.Text = "No";
            if (Questionnaireobj.HTMeter == "Y")
                txtHtMeter.Text = "Yes";
            else
                txtHtMeter.Text = "No";
            if (Questionnaireobj.FireCFO == "Y")
                txtNOCFormFire.Text = "Yes";
            else
                txtNOCFormFire.Text = "No";
            if (Questionnaireobj.DurgCFO == "Y")
                txtDrugsRelated.Text = "Yes";
            else
                txtDrugsRelated.Text = "No";
            if (Questionnaireobj.BoilerCFO == "Y")
                txtBoilerRequired.Text = "Yes";
            else
                txtBoilerRequired.Text = "No";
            if (Questionnaireobj.PCBCFO == "Y")
            {
                lblCfePCB.Text = "Yes";
            }
            else
            {
                lblCfePCB.Text = "No";
            }
            DataSet dsdeptapprova = new DataSet();
            DataTable dt = new DataTable();

            if (Session["DeptApprovalCFO"] != null)
            {

                dt = (DataTable)Session["DeptApprovalCFO"];
            }

            grdDetails.DataSource = dt; //dsdeptapprova.Tables[0];
            grdDetails.DataBind();

            if (Session["CFOexp"] != null)
            {
                dsdeptapprova = (DataSet)Session["CFOexp"];
                GvProjectdtls.DataSource = dsdeptapprova.Tables[0];
                GvProjectdtls.DataBind();
            }

            //GvProjectdtls.Rows[GvProjectdtls.Rows.Count - 1].Style["font-weight"] = "bold";

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
    }
}