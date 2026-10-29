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
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }
        if (!IsPostBack)
        {
            int year = DateTime.Now.Year - 5;

            for (int Y = year; Y <= DateTime.Now.Year; Y++)
            {

                ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
            }

           // ddlYear.SelectedValue =DateTime.Now.Year.ToString();
           // ddlmonth.SelectedIndex = DateTime.Now.Month - 1;
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
            string textCheck = DateTime.Now.Month.ToString();
            ddlYear.Enabled = false;
          ddlmonth.Enabled = false;

            getIPOS();

            //DataSet ds1 = getIPOGMMonthlyReport(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedIndex.ToString(), Session["uid"].ToString());

        }

    }


    protected void getIPOS()
    {
        DataSet dsnew = new DataSet();
        string month = ddlmonth.SelectedValue.ToString();
        
        string year = ddlYear.SelectedItem.Text.ToString();
        dsnew = getIPOGMMonthlyReport(Session["uid"].ToString(), month, year);

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

    public DataSet getIPOGMMonthlyReport(string gmID, string monthh, string year)
    {
        try
        {
            osqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter("IPOGMlinkMonthly", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (gmID.Trim() == "" || gmID.Trim() == null)
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@intGMid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@intGMid", SqlDbType.VarChar).Value = gmID.Trim();
            }

            if (monthh.Trim() == "" || monthh.Trim() == null)
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = monthh.Trim();
            }
            if (year.Trim() == "" || year.Trim() == null)
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year.Trim();
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

    public DataSet getIPOStaus(string gmID, string monthh, string year)
    {
        try
        {
            osqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter("SP_IPOstatus", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (gmID.Trim() == "" || gmID.Trim() == null)
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@intIPOId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@intIPOId", SqlDbType.VarChar).Value = gmID.Trim();
            }

            if (monthh.Trim() == "" || monthh.Trim() == null)
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = monthh.Trim();
            }
            if (year.Trim() == "" || year.Trim() == null)
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                oSqlDataAdapter.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year.Trim();
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

    //public DataSet getIPOGMMonthlyReport(string gmID)
    //{
    //    try
    //    {
    //        osqlConnection.Open();
    //        oSqlDataAdapter = new SqlDataAdapter("IPOGMlinkMonthly_District_dataTest", osqlConnection);
    //        oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        if (gmID.Trim() == "" || gmID.Trim() == null)
    //        {
    //            oSqlDataAdapter.SelectCommand.Parameters.Add("@distID", SqlDbType.VarChar).Value = DBNull.Value;
    //        }
    //        else
    //        {
    //            oSqlDataAdapter.SelectCommand.Parameters.Add("@distID", SqlDbType.VarChar).Value = gmID.Trim();
    //        }



    //        oDataSet = new DataSet();
    //        oSqlDataAdapter.Fill(oDataSet);
    //        //sno = oDataSet.Tables[0].Rows[0]["sno"].ToString();
    //        //Session["impSno"] = sno.ToString();
    //        osqlConnection.Close();
    //        //osqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        osqlConnection.Close();
    //    }
    //    return oDataSet;
    //}


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //RadioButtonList RdWhetherAlreadyApproved = (RadioButtonList)sender;
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
            oSqlCommand.Parameters.AddWithValue("@status", 2);
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

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ddlmonth.SelectedValue.ToString() == "2" && ddlYear.SelectedValue.ToString() == "2020")
            {
                HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink");
                grdDetails.Columns[5].Visible = true;
                string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FilePath"));

                if (hyperLnk1 != "")
                {
                    h3.Text = "View";
                    h3.Visible = true;

                }
            }
            else
            {
                grdDetails.Columns[6].Visible = true;
                HyperLink h1 = (HyperLink)e.Row.FindControl("HyperLink2");
                string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApplicationStatus"));
                if (hyperLnk1 != "")
                {
                    h1.Text = "View";
                    h1.Visible = true;
                    h1.NavigateUrl = "IPOReportPrintPage.aspx?status=B&intUserid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intUserid")).Trim() + "&Month=" + ddlmonth.SelectedValue.ToString() + "&Year=" + ddlYear.SelectedValue.ToString();
                    

                }
              
                
            }

        }


        Label lbl = (Label)e.Row.FindControl("lbluserid");
        TextBox txtGmRemarks = (TextBox)e.Row.FindControl("TxtReject");
        
        string lbluserid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intUserid"));

        string month = ddlmonth.SelectedValue.ToString();
        string year = ddlYear.SelectedItem.Text.ToString();
        CheckBox ChkApproval = (CheckBox)e.Row.FindControl("ChkApproval");

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = getIPOStaus(lbluserid, month, year);
        if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["StatusId"].ToString() == "2")
            {

                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
               
                txtGmRemarks.Text = ds.Tables[0].Rows[0]["GMRemarks"].ToString();
                txtGmRemarks.Enabled = false;
            }
            else
            {
                ChkApproval.Checked = false;
                txtGmRemarks.Enabled = true;
            }
        }

      




    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int cnt = 0;
        int insertCheck = 0;
        foreach (GridViewRow row in grdDetails.Rows)
        {
            if (((CheckBox)row.FindControl("ChkApproval")).Checked)
            {
                cnt = cnt + 1;
            }
        }

        if (cnt < 1)
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please Select Atleaset One Record  for further Process";
            lblmsg0.Visible = true;
        }
        else
        {

            Failure.Visible = false;
            lblmsg0.Text = "";
            lblmsg0.Visible = false;
              
            foreach (GridViewRow row in grdDetails.Rows)
            {
                if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                {
                    int Rowindex = row.RowIndex;
                    string mainSno = grdDetails.Rows[Rowindex].Cells[0].Text.ToString();
                    //string txtTxtReject= grdDetails.Rows[Rowindex].Cells[6].Text.ToString();
                   // string txtTxtReject = ((TextBox)row.FindControl("TxtReject")).ToString();
                    TextBox txtTxtReject = row.FindControl("TxtReject") as TextBox;
                    string gmremarks = txtTxtReject.Text;
                    //TextBox txtTxtReject = (TextBox)grdDetails.Rows[Rowindex].FindControl("TxtReject");
                    Label lblUser = (Label)grdDetails.Rows[Rowindex].FindControl("lbluserid");
                    string user = lblUser.Text.ToString();
                    string k = ddlmonth.SelectedValue.ToString();
                    //    string remarks= ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();

                    //string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                    //string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                    //string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                    //string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                    //string RdWhetherAlreadyApproved = ((RadioButtonList)row.FindControl("RdWhetherAlreadyApproved")).SelectedValue.ToString().Trim();


                    //   int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);

                    Failure.Visible = false;
                    osqlConnection.Open();
                    SqlCommand oSqlCommand = new SqlCommand("updateIPOGMlinkMonthlyTEST");
                    oSqlCommand.Connection = osqlConnection;
                    oSqlCommand.CommandType = CommandType.StoredProcedure;
                    oSqlCommand.CommandText = "updateIPOGMlinkMonthlyTEST";
                    oSqlCommand.Parameters.AddWithValue("@gmRemarks", gmremarks);
                    oSqlCommand.Parameters.AddWithValue("@gmID", Session["uid"].ToString());
                    oSqlCommand.Parameters.AddWithValue("@recordID", mainSno);

                    oSqlCommand.Parameters.AddWithValue("@M_Month", ddlmonth.SelectedValue.ToString());
                    oSqlCommand.Parameters.AddWithValue("@Y_Year", ddlYear.SelectedValue.ToString());
                    oSqlCommand.Parameters.AddWithValue("@intIPOId", user);

                    oSqlCommand.Parameters.AddWithValue("@status", 2);
                    //oSqlCommand.Parameters.Add("@valid", SqlDbType.Int, 500);
                    oSqlCommand.Parameters.Add("@valid", SqlDbType.Int, 500);
                    oSqlCommand.Parameters["@valid"].Direction = ParameterDirection.Output;
                    
                    oSqlCommand.ExecuteNonQuery();
                    osqlConnection.Close();
                    insertCheck = (Int32)oSqlCommand.Parameters["@valid"].Value;
                    getIPOS();





                }
                else
                {
                    //string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                    //string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                    //string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                    //string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                    //string RdWhetherAlreadyApproved = ((RadioButtonList)row.FindControl("RdWhetherAlreadyApproved")).SelectedValue.ToString().Trim();

                    //// int s = Gen.UpdDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);
                }
            }
            if (insertCheck == 1)
            {
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Verified successfully!";
                
                string message = "alert('Verified successfully!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
               
            }
           
        }

    }

   
}