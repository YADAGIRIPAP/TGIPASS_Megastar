using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using BusinessLogic;

public partial class CheckPOITD : System.Web.UI.Page
{

    Fetch objFetch = new Fetch();
    comFunctions objCmf = new comFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                objCmf.BindCtlto(true, ddlCategory, objFetch.FetchCategory(), 1, 0, false);
                
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void ddlCaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { VehicleVisible(); }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { VehicleVisible(); }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void cbphysicalHandicapped_CheckedChanged(object sender, EventArgs e)
    {
        try { VehicleVisible(); }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    private void VehicleVisible()
    {
        try
        {
            Label4.Visible = rblVehicleIncetive.Visible = false;
            if ((ddlCaste.SelectedValue == "3" || ddlCaste.SelectedValue == "4" || cbphysicalHandicapped.Checked) && ddlSector.SelectedValue == "1")
                Label4.Visible = rblVehicleIncetive.Visible = true;
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                DataTable dt = new DataTable();
                if (Page.IsValid && ddlCaste.SelectedIndex > 0 && ddlCategory.SelectedIndex > 0 && ddlSector.SelectedIndex > 0)
                    dt = objFetch.FetchEligibleIncentives(Convert.ToInt32(ddlCaste.SelectedValue),
                                                                    Convert.ToInt32(ddlSector.SelectedValue),
                                                                    (rblGHMC.SelectedValue == "0" ? true : false),
                                                                    Convert.ToInt32(rblSelection.SelectedValue),
                                                                    Convert.ToInt32(ddlCategory.SelectedValue),
                                                                    cbphysicalHandicapped.Checked,
                                                                    (rblVehicleIncetive.SelectedValue == "1" ? true : false)
                                                        );
                else
                    dt = null;

                objCmf.FillGrid_EmptyDatatext(dt, grdDetails);
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void grdDetails_RowDataBound(object sender, EventArgs e)
    {
        try
        {
            for (int rowIndex = grdDetails.Rows.Count - 2;
                                               rowIndex >= 0; rowIndex--)
            {
                GridViewRow gvRow = grdDetails.Rows[rowIndex];
                GridViewRow gvPreviousRow = grdDetails.Rows[rowIndex + 1];
                for (int cellCount = 0; cellCount < gvRow.Cells.Count - 1;
                                                              cellCount++)
                {
                    if (gvRow.Cells[cellCount].Text ==
                                           gvPreviousRow.Cells[cellCount].Text)
                    {
                        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        {
                            gvRow.Cells[cellCount].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[cellCount].RowSpan =
                                gvPreviousRow.Cells[cellCount].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[cellCount].Visible = false;
                    }
                }
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }
    
}
