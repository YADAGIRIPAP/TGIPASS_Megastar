using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class UI_TSiPASS_MonthlyReportGMIpo : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
    DataSet oDataSet = new DataSet();
    string checkSno;
    string sno;
    //General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
     //   FILLGRIDVIEW();
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("../../Index.aspx");
        //}
        //if (!IsPostBack)
        //{
        //    int year = DateTime.Now.Year - 5;

        //    for (int Y = year; Y <= DateTime.Now.Year; Y++)
        //    {

        //        ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
        //    }

        //    ddlYear.SelectedValue = DateTime.Now.Year.ToString();
        //    ddlmonth.SelectedIndex = DateTime.Now.Month;
        //    string textCheck = DateTime.Now.Month.ToString();
        //    ddlYear.Enabled = true;
        //    ddlmonth.Enabled = true;

           getIPOS();

       //DataSet ds1 = ApplicantData(Session["uid"].ToString());

        //}

    }

    //public void FILLGRIDVIEW()
    //{
    //    osqlConnection.Open();
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        //conn.Open();
    //        SqlCommand cmd = new SqlCommand("SELECT sno,Name_of_unit,aadhar_number,mobile_numnber,district,bank_name,branch_name,loan_application_date,created_date,created_by,Loan_Amount from TV_FRM_INDUSTRY_LONE", osqlConnection);
    //        SqlDataAdapter da = new SqlDataAdapter();
    //        da.SelectCommand = cmd;
    //        da.Fill(ds);
    //        grdDetails.DataSource = ds;
    //        grdDetails.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //        //Exception Message
    //    }
    //    finally
    //    {
    //        osqlConnection.Close();
    //        //conn.Close();
    //        //conn.Dispose();
    //    }
    //}
    protected void getIPOS()
    {
        DataSet dsnew = new DataSet();
        dsnew = ApplicantData(Session["uid"].ToString());
        
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
            Failure.Visible = false;
        }

        if(dsnew.Tables[0].Rows.Count<=0)
        {
            Failure.Visible = true;
            lblmsg0.Text = "No records found";
        }       
    }

    public DataSet ApplicantData(string created_by)
    {
        try
        {
            osqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter("GETDETAILS", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (created_by.Trim() == "" || created_by.Trim() == null)
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@created_by", SqlDbType.VarChar).Value = created_by.Trim();
            }

            

            oDataSet = new DataSet();
            oSqlDataAdapter.Fill(oDataSet);
            //sno = oDataSet.Tables[0].Rows[0]["sno"].ToString();
            //Session["impSno"] = sno.ToString();
            osqlConnection.Close();
            //osqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }
        return oDataSet;
    }


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //RadioButtonList RdWhetherAlreadyApproved = (RadioButtonList)sender;
        Button btnSave = (Button)sender;
        GridViewRow row = (GridViewRow)btnSave.NamingContainer;
        TextBox txtTxtReject = (TextBox)row.FindControl("TxtReject");
        int Rowindex = row.RowIndex;
        string mainSno = grdDetails.Rows[Rowindex].Cells[0].Text.ToString();
        //TextBox txtTxtReject = (TextBox)grdDetails.Rows[Rowindex].FindControl("TxtReject");
        string k= txtTxtReject.Text;
        int insertCheck = 0;
        string test = Session["uid"].ToString();
        if (txtTxtReject.Text=="")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please enter remarks for record id : "+ mainSno;
        }

        if ( txtTxtReject.Text != "")
        {
            Failure.Visible = false;
            osqlConnection.Open();
            SqlCommand oSqlCommand = new SqlCommand("UPDATESTATUS");
            oSqlCommand.Connection = osqlConnection;
            oSqlCommand.CommandType = CommandType.StoredProcedure;
            oSqlCommand.CommandText = "UPDATESTATUS";
            oSqlCommand.Parameters.AddWithValue("@Remarks", txtTxtReject.Text);
            oSqlCommand.Parameters.AddWithValue("@created_by", Session["uid"].ToString());
            oSqlCommand.Parameters.AddWithValue("@sno", mainSno.ToString());
            oSqlCommand.Parameters.Add("@valid", SqlDbType.Int, 500);
            
            oSqlCommand.Parameters["@valid"].Direction = ParameterDirection.Output;
            oSqlCommand.ExecuteNonQuery();
            insertCheck = (Int32)oSqlCommand.Parameters["@valid"].Value;   
            if(insertCheck==1)
            {
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Updated successfully!";
                string message = "alert('Updated successfully!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            else if (insertCheck == 2)
            {
                Failure.Visible = true;
                success.Visible = false;
                lblmsg0.Text = "Details not updated.Please try again!";
                string message = "alert('Details not updated.Please try again!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }

        }



        //string sno= (string)grdDetails.Rows.
    }

    protected void BtnReject_Click(object sender, EventArgs e)
    {
        Button btnSave = (Button)sender;
        GridViewRow row = (GridViewRow)btnSave.NamingContainer;
        int Rowindex = row.RowIndex;
        string mainSno = grdDetails.Rows[Rowindex].Cells[0].Text.ToString();
        TextBox txtTxtReject = (TextBox)grdDetails.Rows[Rowindex].FindControl("TxtReject");
        int insertCheck = 0;

        if (txtTxtReject.Text == "")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please enter remarks for record id : " + mainSno;
        }

        if (mainSno != "" && txtTxtReject.Text != "")
        {
            Failure.Visible = false;
            osqlConnection.Open();
            SqlCommand oSqlCommand = new SqlCommand("updateIPOGMlinkMonthly");
            oSqlCommand.Connection = osqlConnection;
            oSqlCommand.CommandType = CommandType.StoredProcedure;
            oSqlCommand.CommandText = "updateIPOGMlinkMonthly";
            oSqlCommand.Parameters.AddWithValue("@gmRemarks", txtTxtReject.Text);
            oSqlCommand.Parameters.AddWithValue("@gmID", Session["uid"].ToString());
            oSqlCommand.Parameters.AddWithValue("@recordID", mainSno);
            oSqlCommand.Parameters.AddWithValue("@status", 3);
            //oSqlCommand.Parameters.Add("@valid", SqlDbType.Int, 500);
            oSqlCommand.Parameters.Add("@valid", SqlDbType.Int, 500);
            oSqlCommand.Parameters["@valid"].Direction = ParameterDirection.Output;

            oSqlCommand.ExecuteNonQuery();

            //cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
            //cmd.ExecuteNonQuery();
            insertCheck = (Int32)oSqlCommand.Parameters["@Valid"].Value;
            if (insertCheck == 1)
            {
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Updated successfully!";
                string message = "alert('Updated successfully!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            else if (insertCheck == 2)
            {
                Failure.Visible = true;
                success.Visible = false;
                lblmsg0.Text = "Details not updated.Please try again!";
                string message = "alert('Details not updated.Please try again!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }

        }

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink");
     
        //string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FilePath"));

        //  if (hyperLnk1 != "")
        //{
        //    h3.Text = "View";
        //    h3.Visible = true;
          
            
        //}

    }
}