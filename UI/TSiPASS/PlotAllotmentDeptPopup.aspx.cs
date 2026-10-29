using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UI_TSiPASS_PlotAllotmentDeptPopup : System.Web.UI.Page
{
    cls_plotallotmentadmin Gen = new cls_plotallotmentadmin();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    FillGrid();
                   
                }
            }
                
            
          
        }
        catch (Exception ex)
        {
           
        }
    }

    public void FillGrid()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Gen.GePlotallotmentEnterprenuerDetailsNew_popup(Request.QueryString[0].ToString().Trim());
            if (ds.Tables[0].Rows.Count != 0)
            {
                lblUidNo.Text = ds.Tables[0].Rows[0]["UIDNo"].ToString();
                lbl_indusrtialpark.Text = ds.Tables[0].Rows[0]["IndustrialParkId"].ToString();
                lblNameOfPromoter.Text = ds.Tables[0].Rows[0]["NameOftheFirm_Applicant"].ToString();
                lbl_District.Text = ds.Tables[0].Rows[0]["District_Name"].ToString();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[1];
                    grdDetails.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        if (e.Row.Cells[5].Text == "Red")
        //        {
        //            e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
        //            e.Row.Cells[5].Text = "";
        //        }
        //        else if (e.Row.Cells[5].Text == "Green")
        //        {
        //            e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
        //            e.Row.Cells[5].Text = "";
        //        }
        //        else
        //        {
        //            e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
        //            e.Row.Cells[5].Text = "";
        //        }

        //        if (e.Row.Cells[7].Text == "Red")
        //        {
        //            e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
        //            e.Row.Cells[7].Text = "";
        //        }
        //        else if (e.Row.Cells[7].Text == "Green")
        //        {
        //            e.Row.Cells[7].BackColor = System.Drawing.Color.Green;
        //            e.Row.Cells[7].Text = "";
        //        }
        //        else
        //        {
        //            e.Row.Cells[7].BackColor = System.Drawing.Color.White;
        //            e.Row.Cells[7].Text = "";
        //        }

        //        if (e.Row.Cells[8].Text == "Red")
        //        {
        //            e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
        //            e.Row.Cells[8].Text = "";
        //        }
        //        else if (e.Row.Cells[8].Text == "Green")
        //        {
        //            e.Row.Cells[8].BackColor = System.Drawing.Color.Green;
        //            e.Row.Cells[8].Text = "";
        //        }
        //        else
        //        {
        //            e.Row.Cells[8].Text = "";
        //        }

        //        if (e.Row.Cells[9].Text == "Pre-Scrutiny Stage" || e.Row.Cells[9].Text == "Approval Stage")
        //        {
        //            e.Row.Cells[9].BackColor = System.Drawing.Color.Red;
        //        }
        //        else
        //        {
        //            e.Row.Cells[9].Text = "";
        //        }



        //        if (e.Row.Cells[3].Text == "Yes" || e.Row.Cells[4].Text == "No")
        //        {

        //            e.Row.Cells[5].BackColor = System.Drawing.Color.White;
        //            e.Row.Cells[5].Text = "";
        //            e.Row.Cells[6].BackColor = System.Drawing.Color.White;
        //            e.Row.Cells[6].Text = "";
        //            if (e.Row.Cells[3].Text == "Yes")
        //            {
        //                e.Row.Cells[8].BackColor = System.Drawing.Color.Green;
        //                e.Row.Cells[8].Text = "";

        //                e.Row.Cells[3].BackColor = System.Drawing.Color.Orange;
        //                e.Row.Cells[3].Text = "";
        //            }
        //            else
        //            {

        //                if (e.Row.Cells[4].Text == "No")
        //                {
                           
        //                }
        //            }
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
           
        //}

    }

   
}