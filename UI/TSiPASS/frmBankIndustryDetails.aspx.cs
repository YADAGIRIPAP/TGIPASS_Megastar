using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmBankIndustryDetails : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
    DataSet oDataSet = new DataSet();
    string checkSno;
    string sno;
    protected void Page_Load(object sender, EventArgs e)
    {
        GETBANKINDUSTRYDETAILS();
    }
    protected void GETBANKINDUSTRYDETAILS()
    {
        DataSet dsnew = new DataSet();
        dsnew = ApplicantData(Session["uid"].ToString());

        if (dsnew.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
            Failure.Visible = false;
        }

        if (dsnew.Tables[0].Rows.Count <= 0)
        {
            Failure.Visible = true;
            lblmsg0.Text = "No records found";
        }
    }

    public DataSet ApplicantData(string CREATED_BY)
    {
        try
        {
            osqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter("GETBANKINDUSTRYDETAILS", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (CREATED_BY.Trim() == "" || CREATED_BY.Trim() == null)
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = CREATED_BY.Trim();
            }



            oDataSet = new DataSet();
            oSqlDataAdapter.Fill(oDataSet);
            //sno = oDataSet.Tables[0].Rows[0]["sno"].ToString();
            //Session["impSno"] = sno.ToString();
            osqlConnection.Close();
            //osqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        catch (Exception ex)
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
        Button btnSave = (Button)sender;
        GridViewRow row = (GridViewRow)btnSave.NamingContainer;
        TextBox txtTxtReject = (TextBox)row.FindControl("TxtReject");
        int Rowindex = row.RowIndex;
        string mainSno = grdDetails.Rows[Rowindex].Cells[0].Text.ToString();
        //TextBox txtTxtReject = (TextBox)grdDetails.Rows[Rowindex].FindControl("TxtReject");
        string k = txtTxtReject.Text;
        int insertCheck = 0;
        string test = Session["uid"].ToString();
        if (txtTxtReject.Text == "")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please enter remarks for record id : " + mainSno;
        }

        if (txtTxtReject.Text != "")
        {
            Failure.Visible = false;
            osqlConnection.Open();
            SqlCommand oSqlCommand = new SqlCommand("BANKINDUSTRYSTATUS");
            oSqlCommand.Connection = osqlConnection;
            oSqlCommand.CommandType = CommandType.StoredProcedure;
            oSqlCommand.CommandText = "BANKINDUSTRYSTATUS";
            oSqlCommand.Parameters.AddWithValue("@Remarks", txtTxtReject.Text);
            oSqlCommand.Parameters.AddWithValue("@created_by", Session["uid"].ToString());
            oSqlCommand.Parameters.AddWithValue("@sno", mainSno.ToString());
            oSqlCommand.Parameters.Add("@valid", SqlDbType.Int, 500);

            oSqlCommand.Parameters["@valid"].Direction = ParameterDirection.Output;
            oSqlCommand.ExecuteNonQuery();
            insertCheck = (Int32)oSqlCommand.Parameters["@valid"].Value;
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

    protected void BtnReject_Click(object sender, EventArgs e)
    {
        Button btnSave = (Button)sender;
        GridViewRow row = (GridViewRow)btnSave.NamingContainer;
        TextBox txtTxtReject = (TextBox)row.FindControl("TxtReject");
        int Rowindex = row.RowIndex;
        string mainSno = grdDetails.Rows[Rowindex].Cells[0].Text.ToString();
        //TextBox txtTxtReject = (TextBox)grdDetails.Rows[Rowindex].FindControl("TxtReject");
        string k = txtTxtReject.Text;
        int insertCheck = 0;
        string test = Session["uid"].ToString();
        if (txtTxtReject.Text == "")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please enter remarks for record id : " + mainSno;
        }

        if (txtTxtReject.Text != "")
        {
            Failure.Visible = false;
            osqlConnection.Open();
            SqlCommand oSqlCommand = new SqlCommand("REJECTEDBANKINDUSTRYSTATUS");
            oSqlCommand.Connection = osqlConnection;
            oSqlCommand.CommandType = CommandType.StoredProcedure;
            oSqlCommand.CommandText = "REJECTEDBANKINDUSTRYSTATUS";
            oSqlCommand.Parameters.AddWithValue("@Remarks", txtTxtReject.Text);
            oSqlCommand.Parameters.AddWithValue("@created_by", Session["uid"].ToString());
            oSqlCommand.Parameters.AddWithValue("@sno", mainSno.ToString());
            oSqlCommand.Parameters.Add("@valid", SqlDbType.Int, 500);

            oSqlCommand.Parameters["@valid"].Direction = ParameterDirection.Output;
            oSqlCommand.ExecuteNonQuery();
            insertCheck = (Int32)oSqlCommand.Parameters["@valid"].Value;
            if (insertCheck == 1)
            {
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "YOUR DOCUMENT REJECTED!";
                string message = "alert('YOUR DOCUMENT REJECTED!')";
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

   
}