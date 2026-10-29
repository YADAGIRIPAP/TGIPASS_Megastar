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
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
public partial class UI_TSiPASS_MSMEDistrictPDLSReport : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";
    decimal Nounits;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            BindDistricts();
            txtFromDate.Text = "01-03-2020";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            Label1.Text = "Report as on date " + DateTime.Now;
            if (Session["userlevel"].ToString().Trim() != "13")
            {
                if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
                {
                    ddlProp_intDistrictid.SelectedValue = Session["DistrictID"].ToString().Trim();
                    ddlProp_intDistrictid.Enabled = false;
                }
                else
                {
                    ddlProp_intDistrictid.SelectedIndex = 0;
                }

                fillgrid();
            }

            if (Session["userlevel"].ToString().Trim() == "13")
            {
                Response.Redirect("~/Index.aspx");
            }
        }
    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
            else
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
        }
    }

    public void fillgrid()
    {
        DataSet dsnew = new DataSet();
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        if (valid == 0)
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        dsnew = GetMSMEApplications(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue);
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {


    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal Nounits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITS"));
            Nounits = Nounits1 + Nounits;
            HyperLink h1 = (HyperLink)e.Row.FindControl("HyNoofClaimsFiled");
            h1.NavigateUrl = "Msmeunitsbydistrictforproformalplds.aspx?fromdt=" + txtFromDate.Text + "&todt=" + txtTodate.Text + "&Districtid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim();
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            HyperLink nounitstotal = new HyperLink();
            nounitstotal.Text = Nounits.ToString();
            e.Row.Cells[2].Text = Nounits.ToString();
            e.Row.Cells[2].Controls.Add(nounitstotal);
            nounitstotal.ForeColor = System.Drawing.Color.White;
            nounitstotal.NavigateUrl = "Msmeunitsbydistrictforproformalplds.aspx?fromdt=" + txtFromDate.Text + "&todt=" + txtTodate.Text + "&Districtid=ALL";
        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }


 
    protected void BtnSave1_Click(object sender, EventArgs e)
    {        
        int valid = 0;
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }       
        if (valid == 0)
        {
            fillgrid();
        }
        
    }

    public DataSet GetMSMEApplications(string fromdate, string todate, string districtid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FromDate",SqlDbType.VarChar),
                new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@DISTRICTID",SqlDbType.VarChar)

           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        pp[2].Value = districtid;


        Dsnew = Gen.GenericFillDs("MSME_GET_MSME_REPORT_NEW_PDLS", pp);
        return Dsnew;
    }
}