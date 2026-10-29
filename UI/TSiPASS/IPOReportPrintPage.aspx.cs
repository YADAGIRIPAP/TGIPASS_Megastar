using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

public partial class Default2 : System.Web.UI.Page
{
    General clsGeneral = new General();
    DataSet ds = new DataSet();
    General Gen = new General();
    
    string intUserid = "";
    string Month = "";
    string Year = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (Session.Count == 0)
        {
            // Response.Redirect("frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

       

        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString[0].ToString() != "")
            {
                intUserid = Request.QueryString["intUserid"].ToString();
                Month = Request.QueryString["Month"].ToString();
                lblMonth.Text = Request.QueryString["Month"].ToString();
                lblYear.Text = Request.QueryString["Year"].ToString();
                Year = Request.QueryString["Year"].ToString();
                FillGrid();
            }
        }
    }
    public void FillGrid()
    {
        intUserid = Request.QueryString["intUserid"].ToString();
        Month = Request.QueryString["Month"].ToString();
        Year = Request.QueryString["Year"].ToString();
        

        ds = getiporeport(Month, Year, intUserid);

        if (ds.Tables.Count != 0)
        {

            //lblUidNo.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
            //lblNameOfUndertaker.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();

            //lblNameOfPromoter.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString();
            //lblSonOf.Text = ds.Tables[0].Rows[0]["SoWo"].ToString();

            if (ds.Tables[0].Rows.Count > 0)
            {              
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                GridView1d.Visible = true;
                
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                GridBankvisitRept.DataSource = ds.Tables[1];
                GridBankvisitRept.DataBind();
                GridBankvisitReptd.Visible = true;
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                GridVehicleInspctn.DataSource = ds.Tables[2];
                GridVehicleInspctn.DataBind();
                GridVehicleInspctnd.Visible = true;
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                GridClosedUnits.DataSource = ds.Tables[3];
                GridClosedUnits.DataBind();
                GridClosedUnitsd.Visible = true;
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                GridAdvanceSubsidy.DataSource = ds.Tables[4];
                GridAdvanceSubsidy.DataBind();
                GridAdvanceSubsidyd.Visible = true;
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                GridIndCatelog.DataSource = ds.Tables[5];
                GridIndCatelog.DataBind();
                GridIndCatelogd.Visible = true;
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                GridTsipass.DataSource = ds.Tables[6];
                GridTsipass.DataBind();
                GridTsipassd.Visible = true;
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                GridMudraReg.DataSource = ds.Tables[7];
                GridMudraReg.DataBind();
                GridMudraRegd.Visible = true;
            }

            if (ds.Tables[8].Rows.Count > 0)
            {
                lblNameofOfficer.Text = ds.Tables[8].Rows[0]["Emp_Name"].ToString();
                lbldesignation.Text = ds.Tables[8].Rows[0]["Designation"].ToString();
                lblDistrictOffcr.Text = ds.Tables[8].Rows[0]["Dist_Name"].ToString();

            }

        }
    }

    public DataSet getiporeport(string month, string year, string createdby)
    {
        DataSet ds = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@MONTH",SqlDbType.VarChar),
                 new SqlParameter("@YEAR",SqlDbType.VarChar),
                  new SqlParameter("@USERID",SqlDbType.VarChar)
            };
        pp[0].Value = month;
        pp[1].Value = year;
        pp[2].Value = createdby;

        ds = Gen.GenericFillDs("USP_GET_IPOREPORTWISEDATATEST", pp);

        return ds;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink");

        string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FilePath"));

        if (hyperLnk1 != "")
        {
            h3.Text = "View";
            h3.Visible = true;


        }
    }

    protected void GridIndCatelog_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink");

        string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FilePath"));

        if (hyperLnk1 != "")
        {
            h3.Text = "View";
            h3.Visible = true;


        }
    }

    protected void GridVehicleInspctn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink");

        string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FilePath"));

        if (hyperLnk1 != "")
        {
            h3.Text = "View";
            h3.Visible = true;


        }
    }
}
