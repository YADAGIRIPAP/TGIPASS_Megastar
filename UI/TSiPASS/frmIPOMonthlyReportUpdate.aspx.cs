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

public partial class UI_TSiPASS_frmIPOMonthlyReportUpdate : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    public class IPOMonthlyReport
    {
        public string Createdby { get; set; }
        public string Month { get; set; }
        public string year { get; set; }
        public string Success { get; set; }


    }

    General Gen = new General();
    IPOMonthlyReport objvo1 = new IPOMonthlyReport();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {

            // lblStatus.InnerText = "Ramana";

            if (Session["uid"].ToString() != null)
            {
                Label439.Text = Session["user_id"].ToString();
                int UserId = Convert.ToInt32(Session["uid"]);



                int year = DateTime.Now.Year - 5;

                for (int Y = year; Y <= DateTime.Now.Year; Y++)
                {

                    ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
                }

                //ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                //ddlmonth.SelectedIndex =DateTime.Now.Month - 1;
                if ((System.DateTime.Now.Month) == 1)
                {
                    ddlmonth.SelectedValue = "12";
                    ddlYear.Enabled = false;
                    ddlmonth.Enabled = false;
                    ddlYear.SelectedValue = ddlYear.Items.FindByValue((System.DateTime.Now.Year - 1).ToString()).Value;
                }
                else
                {
                    ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
                    ddlYear.Enabled = false;

                    ddlmonth.SelectedValue = ddlmonth.Items.FindByValue((System.DateTime.Now.Month - 1).ToString()).Value;
                    ddlmonth.Enabled = false;

                }
                ddlYear.Enabled = false;
                ddlmonth.Enabled = false;
                DataSet dscheck = new DataSet();

                dscheck = getiporeport(ddlmonth.SelectedValue, ddlYear.SelectedValue,Session["uid"].ToString());
                if (dscheck != null && dscheck.Tables[0].Rows[0]["VALID"].ToString() == "1")
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Report Already Submitted";
                    lblmsg0.Visible = true;
                    BtnSave1.Visible = false;
                 
                    
                   

                }
                else
                {
                    BtnSave1.Visible = true;
                }

                DataSet ds = new DataSet();
                ds = Gen.getIPOMONTHLYREPORT(Convert.ToInt32(Session["uid"].ToString()), ddlmonth.SelectedValue, ddlYear.SelectedValue);
                //ds = Gen.getIPOMONTHLYREPORT("9269", ddlmonth.SelectedValue, ddlYear.SelectedValue,);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblStressedassetbank.Text = ds.Tables[0].Rows[0]["Stressedassetbank"].ToString();
                        lblBANKVISITREPORT.Text = ds.Tables[0].Rows[0]["BANKVISITREPORT"].ToString();
                        lblVEHICLEINSPECTION.Text = ds.Tables[0].Rows[0]["VEHICLEINSPECTION"].ToString();
                        lblTSIPASS.Text = ds.Tables[0].Rows[0]["TSIPASS"].ToString();
                        lblPMEGPMUDRA.Text = ds.Tables[0].Rows[0]["PMEGPMUDRAREGISTRATION"].ToString();
                        lblAdvanceSubsidy.Text = ds.Tables[0].Rows[0]["AdvanceSubsidy"].ToString();
                        lblClosedUnits.Text = ds.Tables[0].Rows[0]["ClosedUnits"].ToString();
                        lblIndustrialCatalogue.Text = ds.Tables[0].Rows[0]["IndustrialCatalogue"].ToString();
                    }
                }
                MyLink.NavigateUrl = "IPOReportPrintPage.aspx?status=B&intUserid=" + UserId + "&Month=" + ddlmonth.SelectedValue.ToString() + "&Year=" + ddlYear.SelectedValue.ToString();

            }
        }

    }

    public DataSet getiporeport(string month, string year, string createdby)
    {
        DataSet ds = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@MONTH",SqlDbType.VarChar),
                 new SqlParameter("@YEAR",SqlDbType.VarChar),
                  new SqlParameter("@CREATEDBY",SqlDbType.VarChar)
            };
        pp[0].Value = month;
        pp[1].Value = year;
        pp[2].Value = createdby;

        ds = Gen.GenericFillDs("USP_CHECK_IPOMONTHScreenReport", pp);

        return ds;
    }

    public bool save()
    {
        try
        {           
                AssignValuestoVosFromcontrols();

                string valid = InsertIPOReportMonthly(objvo1);

                if (valid == "1")
                {
                    lblmsg.Text = "Submitted Successfully";
                    success.Visible = true;

                }
                    
        }
        catch (Exception ex)
        {

            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

        return true;
    }


    public string InsertIPOReportMonthly(IPOMonthlyReport objvo1)
    {
        string valid = "";
        osqlConnection.Open();
        SqlTransaction transaction = null;

        transaction = osqlConnection.BeginTransaction();

        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "IPOMonthlyScreenReportStatus";
            com.Transaction = transaction;
            com.Connection = osqlConnection;

            com.Parameters.AddWithValue("@Createdby", objvo1.Createdby);
            com.Parameters.AddWithValue("@M_Month", objvo1.Month);
            com.Parameters.AddWithValue("@Y_Year", objvo1.year);
            com.Parameters.AddWithValue("@Success", 'Y');


            com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();

            valid = com.Parameters["@Valid"].Value.ToString();

            transaction.Commit();
            osqlConnection.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
            osqlConnection.Dispose();
        }
        return valid;
    }

    public void AssignValuestoVosFromcontrols()
    {
        try
        {
            objvo1.Createdby = Session["uid"].ToString();
            objvo1.Month = ddlmonth.SelectedValue.ToString();
            objvo1.year = ddlYear.SelectedValue.ToString();
           

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        //validation as per...text
        if (lblStressedassetbank.Text== "Filled" && lblBANKVISITREPORT.Text == "Filled" && lblVEHICLEINSPECTION.Text == "Filled" && lblClosedUnits.Text == "Filled" && lblAdvanceSubsidy.Text == "Filled" && lblIndustrialCatalogue.Text == "Filled")
        {

            if (save())
            {

                string message = "alert('Submitted Succussfully')";

                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
              //  Response.Redirect("frmIPOMonthlyReportUpdate.aspx");
                success.Visible = true;
                lblmsg.Text = "Submitted Succussfully";
                BtnSave1.Enabled = false;
                Failure.Visible = false;

            }


        }
        else
        {
            Failure.Visible = true;
            success.Visible = false;
            BtnSave1.Enabled = true;
            lblmsg0.Text = "Please fill All the mandatory reports and Click on Submit!";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill All the mandatory reports and Click on Submit!');", true);
            return;
            
        }
    }
}