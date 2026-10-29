using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_QuestionnaireForm : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    CommonBL objcommon = new CommonBL();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal TotalFee = Convert.ToDecimal("0");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CFEQuestionnaire"] != null)
        {
            DataSet ds = new DataSet();
            DataSet dsexp= new DataSet();

            QuesionerVO Questionnaireobj = (QuesionerVO)Session["CFEQuestionnaire"];

            dsexp = (DataSet)Session["CFEexp"];
            txtTreesToBeFelled0.Text = Questionnaireobj.NoofTrees;
            LblSectionofExterprise.Text = Questionnaireobj.Sector_Ent;
            txtExtant.Text = Questionnaireobj.Tot_Extent;
            //txtValueOfLand.Text = ds.Tables[0].Rows[0]["Val_Land"].ToString().Trim();
            //txtValueOfBulding.Text = ds.Tables[0].Rows[0]["Val_Build"].ToString().Trim();
            //txtValueOfPlant.Text = ds.Tables[0].Rows[0]["Val_Plant"].ToString().Trim();
            //txtTotalValue.Text = ds.Tables[0].Rows[0]["Tot_PrjCost"].ToString().Trim();
            txtEnterprisesName.Text = Questionnaireobj.nameofunit + " Enterprise";
            txtActivity.Text = Questionnaireobj.intLineofActivity;
            txtPolutionCategory.Text = Questionnaireobj.Pol_Category;
            txtProposedEmployement.Text = Questionnaireobj.Prop_Emp;
            if (Questionnaireobj.Power_Req == "2")
            {
                txtPowerRequierement.Text = "Greater than 30 HP";
            }
            else if (Questionnaireobj.Power_Req == "3")
            {
                txtPowerRequierement.Text = "Greater than 500 HP";
            }
            else
            {
                txtPowerRequierement.Text = "Less than 30 HP";
            }
            //  txtPowerRequierement.Text = ds.Tables[0].Rows[0]["Power_Req"].ToString().Trim();
            txtLocationofUnit.Text = Questionnaireobj.Loc_of_unit;
            txtApplicationType.Text = "CFE";
            txtWaterRequiredFrom.Text = Questionnaireobj.Water_reg_from1 + "," + Questionnaireobj.Water_reg_from2 + "," + Questionnaireobj.Water_reg_from3;
            //ds.Tables[0].Rows[0]["Water_reg_from1"].ToString().Trim() + "," + ds.Tables[0].Rows[0]["Water_reg_from2"].ToString().Trim() + "," + ds.Tables[0].Rows[0]["Water_reg_from3"].ToString().Trim();
            txtWaterRequiredPerDay.Text = Questionnaireobj.Water_req_Perday;
            if (Questionnaireobj.Do_Store_Kerosine == "Y")
            {
                txtSpirit.Text = "Yes";
            }
            else
            {
                txtSpirit.Text = "No";
            }
            //   txtSpirit.Text = ds.Tables[0].Rows[0]["Do_Store_Kerosine"].ToString().Trim();
            txtConsitutionOfUnit.Text = Questionnaireobj.Const_of_unit;
            if (Questionnaireobj.Gen_Reqired == "Y")
            {
                txtGeneratorRequirement.Text = "Yes";
            }
            else
            {
                txtGeneratorRequirement.Text = "No";
            }
            // txtGeneratorRequirement.Text = ds.Tables[0].Rows[0]["Gen_Reqired"].ToString().Trim();
            txtHightOfBulding.Text = Questionnaireobj.Hight_Build;
            txtBuiltUpArea.Text = Questionnaireobj.Built_up_Area;
            if (Questionnaireobj.Fall_in_Municipal == "Y")
            //|| ds.Tables[0].Rows[0]["Fall_in_Municipal"].ToString().Trim() == "M")
            {
                txtAreaType.Text = "Municipal";
            }
            else
            {
                txtAreaType.Text = "Rural";
            }
            // txtAreaType.Text = ds.Tables[0].Rows[0]["Fall_in_Municipal"].ToString().Trim();
            //  txtFellTrees.Text = ds.Tables[0].Rows[0]["Prop_Site"].ToString().Trim();
            if (Questionnaireobj.Prop_Site == "Y")
            {
                txtFellTrees.Text = "Yes";
            }
            else
            {
                txtFellTrees.Text = "No";
            }
            txtTreesToBeFelled.Text = Questionnaireobj.NoofTrees;

            //DataSet dsdeptapprova = (DataSet)Session["DeptApproval"];

            DataSet dsdeptapprova = new DataSet();
            DataTable dt = new DataTable();
            if (Session["DeptApproval"] != null)
            {

                dt = (DataTable)Session["DeptApproval"];
            }

            grdDetails.DataSource = dt; //dsdeptapprova.Tables[0];
            grdDetails.DataBind();

            //grdDetails.DataSource = ds.Tables[1];
            //grdDetails.DataBind();
            if (dsexp != null)
            {
                GvProjectdtls.DataSource = dsexp.Tables[0];
                GvProjectdtls.DataBind();
            }

            //GvProjectdtls.Rows[GvProjectdtls.Rows.Count - 1].Style["font-weight"] = "bold";


            if (Questionnaireobj.Appl_Type != "")
            {
                if (Questionnaireobj.Appl_Type == "1")
                {
                    txtApplicationType.Text = "Change of Land Use";

                }
                else if (Questionnaireobj.Appl_Type == "2")
                {
                    txtApplicationType.Text = "Build Permission Approval";

                }
                else
                {
                    txtApplicationType.Text = "Both";
                }
            }
            else
            {
                txtApplicationType.Text = "";
            }

            
        }
        else
        {
        }

    }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GvProjectdtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // set formatting for the category cell
            TableCell cell = e.Row.Cells[0];
            cell.Width = new Unit("15px");

            TableCell cell1 = e.Row.Cells[1];
            cell1.Width = new Unit("280px");

            if (e.Row.Cells.Count == 5)
            {
                TableCell celllast = e.Row.Cells[e.Row.Cells.Count - 1];
                celllast.Width = new Unit("200px");
            }



            // cell.Style["border-right"] = "2px solid #666666";

            // set formatting for value cells
            //for (int i = 2; i < e.Row.Cells.Count; i++)
            //{
            //    cell = e.Row.Cells[i];
            //    // right-align each of the column cells after the first
            //    // and set the width
            //    cell.HorizontalAlign = HorizontalAlign.Right;
            //    cell.Width = new Unit("110px");
            //    // alternate background colors
            //    //if (i % 2 == 1)
            //    //    cell.BackColor
            //    //        = System.Drawing.ColorTranslator.FromHtml("#EFEFEF");
            //    // check value columns for a high enough value
            //    // (value >= 8000) and apply special highlighting
            //}
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                cell.Style["border-bottom"] = "2px solid #666666";
                cell.BackColor = System.Drawing.Color.LightGray;
            }
        }

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
            TotalFee = TotalFee + TotalFee1;

        }
        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            e.Row.Cells[2].Text = "Total Fee";
            e.Row.Cells[3].Text = TotalFee.ToString();
        }
    }


}