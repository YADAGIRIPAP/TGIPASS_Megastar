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

public partial class Default2 : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString.Count>0)
        {

            DataSet ds = new DataSet();
            ds = Gen.GetCFOQuestionereisReceiptDetails(Request.QueryString[0].ToString().Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {

                LblSectionofExterprise.Text = ds.Tables[0].Rows[0]["sectorEnterprise"].ToString().Trim();
                txtDistrict.Text = ds.Tables[0].Rows[0]["District_Name"].ToString().Trim();
                lblMandal.Text = ds.Tables[0].Rows[0]["Manda_lName"].ToString().Trim();
                lblVillage.Text = ds.Tables[0].Rows[0]["Village_Name"].ToString().Trim();
                //txtValueOfLand.Text = ds.Tables[0].Rows[0]["Val_Land"].ToString().Trim();
                //txtValueOfBulding.Text = ds.Tables[0].Rows[0]["Val_Build"].ToString().Trim();
                //txtValueOfPlant.Text = ds.Tables[0].Rows[0]["Val_Plant"].ToString().Trim();
                txtTotalValue.Text = ds.Tables[0].Rows[0]["Tot_PrjCost"].ToString().Trim();

                if (ds.Tables[0].Columns.Count == 3)  //wip
                    txtTotalValue.Text = ds.Tables[0].Rows[0]["Tot_PrjCostExpansion"].ToString().Trim();

                if (ds.Tables[0].Rows[0]["Building_Height"].ToString().Trim() == "Y")
                    txtBuildingHeight.Text = "Yes";
                else
                    txtBuildingHeight.Text = "No";
                if (ds.Tables[0].Rows[0]["NOC_Fire"].ToString().Trim() == "Y")
                    txtNOCFormFire.Text = "Yes";
                else
                    txtNOCFormFire.Text = "No";
                if (ds.Tables[0].Rows[0]["HaveyourTakePolution"].ToString().Trim() == "Y")
                lblCfePCB.Text = "Yes";
                else
                lblCfePCB.Text = "No";
                txtActivity.Text = ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString().Trim();
                txtPolutionCategory.Text = ds.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "O")
                    txtPolutionCategory.Text = "Orange";
                else if (ds.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
                    txtPolutionCategory.Text = "Green";
                else if (ds.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
                    txtPolutionCategory.Text = "White";
                else
                    txtPolutionCategory.Text = "Red";
                
                if (ds.Tables[0].Rows[0]["License_Factory"].ToString().Trim() == "Y")
                   txtLicence.Text = "Yes";
                else
                   txtLicence.Text = "No";
                if (ds.Tables[0].Rows[0]["High_Tension_Meter"].ToString().Trim() == "Y")
                   txtHtMeter.Text = "Yes";
                else
                 txtHtMeter.Text = "No";
                if(ds.Tables[0].Rows[0]["NOC_Fire"].ToString().Trim()=="Y")
                    txtNOCFormFire.Text="Yes";
                else 
                    txtNOCFormFire.Text="No";
                if(ds.Tables[0].Rows[0]["Product_Drugs"].ToString().Trim()=="Y")
                     txtDrugsRelated.Text="Yes";
                else
                     txtDrugsRelated.Text="No";
                if (ds.Tables[0].Rows[0]["Bioler_Industry"].ToString().Trim() == "Y")
                    txtBoilerRequired.Text = "Yes";
                else
                    txtBoilerRequired.Text = "No";

                if (ds.Tables[0].Rows[0]["BiolerManufactuer_Industry"].ToString().Trim() == "Y")
                    txtBoilerRequired.Text = "Yes";
                else
                    txtBoilerRequired.Text = "No";


                grdDetails.DataSource = ds.Tables[1];
                grdDetails.DataBind();

                GvProjectdtls.DataSource = ds.Tables[3];
                GvProjectdtls.DataBind();

                GvProjectdtls.Rows[GvProjectdtls.Rows.Count - 1].Style["font-weight"] = "bold";

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
            else
            {
            }
            
            
        }
        
    }
    //protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    //protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    //if ((e.Row.RowType == DataControlRowType.DataRow))
    //    //{
    //    //    decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
    //    //    TotalFee = TotalFee + TotalFee1;



           
    //    //}
    //    //if ((e.Row.RowType == DataControlRowType.Footer))
    //    //{
    //    //    e.Row.Cells[2].Text = "Total Fee";
    //    //    e.Row.Cells[3].Text = TotalFee.ToString();
    //    //}
    //}
}
