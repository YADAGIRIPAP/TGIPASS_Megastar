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

public partial class UI_TSiPASS_UserCommentsAmmendmentView : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string intPIAid = "0";
            if (Session["user_type"].ToString().Trim() == "MORD")
            {

                intPIAid = Session["uid"].ToString().Trim();
            }
            else
            {
                intPIAid = Session["intDeptid"].ToString().Trim();
            }
            BindAmmendments(intPIAid);
            DataSet ds = new DataSet();
            ds = Gen.GetUserCommentsofAmmendments(Convert.ToInt32(intPIAid), ddlammendments.SelectedValue);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvComments.DataSource = ds.Tables[0];
                gvComments.DataBind();
            }
        }
        //
    }
    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--All--";
            li.Value = "All";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {

        }
    }
    public void BindAmmendments(string intPIAid)
    {
        try
        {
            ddlammendments.Items.Clear();
            DataSet dsConstofunit = new DataSet();
            dsConstofunit = Gen.GetAmmendaments(intPIAid);
            if (dsConstofunit != null && dsConstofunit.Tables.Count > 0 && dsConstofunit.Tables[0].Rows.Count > 0)
            {
                ddlammendments.DataSource = dsConstofunit.Tables[0];
                ddlammendments.DataTextField = "Ammendment";
                ddlammendments.DataValueField = "Ammendment_Id";
                ddlammendments.DataBind();
                AddSelect(ddlammendments);
            }
            else
            {
                ddlammendments.Items.Clear();
                AddSelect(ddlammendments);
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;

        }
    }
    protected void GV_RowDataBound(object o, GridViewRowEventArgs e)
    {
        // apply custom formatting to data cells
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // set formatting for the category cell
            TableCell cell = e.Row.Cells[0];
            cell.Width = new Unit("500px");
            // cell.Style["border-right"] = "2px solid #666666";
            //cell.BackColor = System.Drawing.Color.LightGray;

            // set formatting for value cells
            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                cell = e.Row.Cells[i];

                // right-align each of the column cells after the first
                // and set the width
                cell.HorizontalAlign = HorizontalAlign.Left;
                cell.Width = new Unit("500px");
                //if (cell.Text.Contains("Comments"))
                //{
                //    cell.Width = new Unit("1000px");
                //}
                // alternate background colors
                //if (i % 2 == 1)
                //    cell.BackColor
                //      = System.Drawing.ColorTranslator.FromHtml("#EFEFEF");

                // check value columns for a high enough value
                // (value >= 8000) and apply special highlighting
                //if (GetCellValue(cell) >= 8000)
                //{
                // cell.Font.Bold = true;
                cell.BorderWidth = new Unit("1px");
                cell.BorderColor = System.Drawing.Color.Red;
                cell.BorderStyle = BorderStyle.Dotted;
                // cell.BackColor = System.Drawing.Color.Honeydew;

                //}

            }
        }

        // apply custom formatting to the header cells
        if (e.Row.RowType == DataControlRowType.Header)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                if (cell.Text.Contains("Comments"))
                {
                    cell.Width = new Unit("1000px");
                }
                // cell.Style["border-bottom"] = "2px solid #666666";
                //cell.BackColor = System.Drawing.Color.LightGray;
            }
        }

    }
    protected void ddlammendments_SelectedIndexChanged(object sender, EventArgs e)
    {
        string intPIAid = "0";
        if (Session["user_type"].ToString().Trim() == "MORD")
        {

            intPIAid = Session["uid"].ToString().Trim();
        }
        else
        {
            intPIAid = Session["intDeptid"].ToString().Trim();
        }

        DataSet ds = new DataSet();
        ds = Gen.GetUserCommentsofAmmendments(Convert.ToInt32(intPIAid), ddlammendments.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvComments.DataSource = ds.Tables[0];
            gvComments.DataBind();
        }
    }
}