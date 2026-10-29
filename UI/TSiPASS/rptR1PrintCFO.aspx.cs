using 
System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
//using TSIPassBE;
//using TSIPassBL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
       
       
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }


        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "PrintPanel()", true);
       
        if (!IsPostBack)
        {
            ScriptManager.RegisterStartupScript(this.Page, GetType(), "Javascript", "javascript:PrintPanel(); ", true);
            Label1.Text = "Report from 1st April to " + System.DateTime.Now.ToString("dd-MM-yyyy");
            DataSet ds = new DataSet();
            if (Session["DistrictID"].ToString().Trim() != "")
            {
                ds = Gen.GetR1ReportbyDistrictidCFO(Session["DistrictID"].ToString().Trim(),"","");
                DataSet dsd = new DataSet();
                dsd = Gen.GetDistrictbyID(Session["DistrictID"].ToString().Trim());


                lblHeading.Text = "CFO R1: " + dsd.Tables[0].Rows[0]["District_Name"].ToString().ToUpper() + " DISTRICT DASHBOARD";
            }
            else
            {
                ds = Gen.GetR1ReportbyDistrictidCFO("%", "", "");
                lblHeading.Text = "CFO R1: CM's DASHBOARD";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                LblProjCost.Text = "Total Capital Investment (Rs. in Crores) :";
                lbtProjCost.Text= ds.Tables[1].Rows[0][0].ToString().Trim();
               
                grdDetails0.DataSource = ds.Tables[2];
                grdDetails0.DataBind();

                grdDetails3.DataSource = null;
                grdDetails3.DataBind();

                grdDetails1.DataSource = ds.Tables[4];
                grdDetails1.DataBind();

                grdDetails2.DataSource = ds.Tables[5];
                grdDetails2.DataBind();
                grdDetails2.Visible = false;
                Label484.Visible = false;
                
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                grdDetails0.DataSource =null;
                grdDetails0.DataBind();
                grdDetails1.DataSource = null;
                grdDetails1.DataBind();
                grdDetails2.DataSource = null;
                grdDetails2.DataBind();
                grdDetails3.DataSource = null;
                grdDetails3.DataBind();
            }
        }
       // Page.ClientScript.RegisterStartupScript(this.GetType(), "Text", "PrintPanel()", true);
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void grdDetails0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[5].Text = Convert.ToString(Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "No Query but Pending")).Trim()) + Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query Raised")).Trim()) + Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Completed")).Trim()));
        }
    }
    protected void grdDetails2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       

    }
    protected void grdDetails1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[5].Text = Convert.ToString(Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Approved")).Trim()) + Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Under Process")).Trim()) + Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Rejected")).Trim()));
        }
       
    }
    protected void grdDetails3_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "PrintPanel()", true);
    }
    
}
