using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmLoanDetailsAdditionalView : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //I am writing this article on 9th January 2015  
        //Selection Date Start from 09th Jan 2005  
        //CalendarExtender2.StartDate = DateTime.Now.AddYears(-11);
        ////Current date can be select but not future date.  
        //CalendarExtender2.EndDate = DateTime.Now;
        if (IsPostBack == false)
        {
            txtFromDate.Text = "01-03-2020";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            fillgrid();

        }
    }



   //public void BindGrid()
   // {

   //     try
   //     {
   //         DataSet dsn = new DataSet();
   //         dsn = Gen.GetSanctionListDetls();
   //         if (dsn != null && dsn.Tables.Count > 0 && dsn.Tables[0].Rows.Count > 0)
   //         {
   //             GridView1.DataSource = dsn.Tables[0];
   //             GridView1.DataBind();
   //             GridView1.Visible = true;

   //         }
   //         else
   //         {
   //             GridView1.DataSource = null;
   //             GridView1.DataBind();
   //             GridView1.Visible = false;
   //             Failure.Visible = true;
   //             lblmsg.Text = "No Records Found";
   //         }
   //     }
   //     catch (Exception ex)
   //     {
   //         lblmsg.Text = ex.Message;
   //         Failure.Visible = true;
   //         success.Visible = false;
   //     }
   // }

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
            //string[] FromDt11 = txtFromDate.Text.Split('/');
            //FromdateforDB = FromDt11[2].ToString() + "/" + FromDt11[1].ToString() + "/" + FromDt11[0].ToString();
            //string[] ToDt11 = txtTodate.Text.Split('/');
            //TodateforDB = ToDt11[2].ToString() + "/" + ToDt11[1].ToString() + "/" + ToDt11[0].ToString();
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

           
        }
        dsnew = GetAppealApplications(FromdateforDB, TodateforDB);
        
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            
            GridView1.DataSource = dsnew.Tables[0];
            GridView1.DataBind();
            Failure.Visible = false;
            lblmsg0.Visible = false;
        }
        else
        {
            
            GridView1.DataSource = null;
            GridView1.DataBind();
            Failure.Visible = true;
            lblmsg0.Text = "No Records Found";
            string message = "alert('No records Found')";
            ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", message, true);
        }
    }

    public DataSet GetAppealApplications(string fromdate, string todate)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FROMDATE",SqlDbType.VarChar),
                new SqlParameter("@TODATE",SqlDbType.VarChar),

           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;


        Dsnew = Gen.GenericFillDs("Sp_GetBridgeLoanDetails", pp);
        return Dsnew;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        fillgrid();
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
}