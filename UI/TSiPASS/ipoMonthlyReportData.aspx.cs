using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;


public partial class UI_TSIPASS_ipoMonthlyReportData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            int year = DateTime.Now.Year - 5;

            for (int Y = year; Y <= DateTime.Now.Year; Y++)
            {

                ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
            }

           // ddlYear.SelectedValue =  DateTime.Now.Year.ToString();
           // ddlmonth.SelectedIndex =  DateTime.Now.Month - 1;
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
           
        }

        SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
        DataSet oDataSet = new DataSet();
        string gmID = Session["uid"].ToString();
        string Month = ddlmonth.SelectedValue.ToString();
        string Year = ddlYear.SelectedValue.ToString();
        //string districtname = "";
        //if (Request.QueryString["District"] != null && Request.QueryString["District"].ToString() != "" && Request.QueryString["District"].ToString() != "--Select--")
        //{
        //    districtname = Request.QueryString["District"].ToString();
        //}

        osqlConnection.Open();
        oSqlDataAdapter = new SqlDataAdapter("IPOGMlinkMonthly_District_data", osqlConnection);
        oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        if (gmID.Trim() == "" || gmID.Trim() == null)
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@distID", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@distID", SqlDbType.VarChar).Value = gmID.Trim();
        }

        if (Month.Trim() == "" || Month.Trim() == null)
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = Month.Trim();
        }

        if (Year.Trim() == "" || Year.Trim() == null)
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = Year.Trim();
        }



        oDataSet = new DataSet();
        oSqlDataAdapter.Fill(oDataSet);
        grdDetails.DataSource = oDataSet.Tables[0];
        grdDetails.DataBind();

        //sno = oDataSet.Tables[0].Rows[0]["sno"].ToString();
        //Session["impSno"] = sno.ToString();
        osqlConnection.Close();
        //osqlDataAdapter.SelectCommand.Com
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink");

        //string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FilePath"));

        //if (hyperLnk1 != "")
        //{
        //    h3.Text = "View";
        //    h3.Visible = true;


        //}

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ddlmonth.SelectedValue.ToString() == "2" && ddlYear.SelectedValue.ToString() == "2020")
            {
                HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink");
                grdDetails.Columns[5].Visible = true;
                grdDetails.Columns[6].Visible = false;
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
                grdDetails.Columns[5].Visible = false;
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
    }
}