using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_PrintPattalandappl : System.Web.UI.Page
{
    //String ComplaintNo = "";
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString[0].ToString() != "")
            {
                //ComplaintNo = Request.QueryString[0].ToString();
                FillGrid();
            }
        }
    }
    public void FillGrid()
    {
        ds = GetPattalandappl(Request.QueryString[0].ToString().Trim());

        if (ds.Tables[0].Rows.Count != 0)
        {
            lblApplNo.Text = ds.Tables[0].Rows[0]["PATTADARID"].ToString();
            lblName.Text = ds.Tables[0].Rows[0]["PATTADARNAME"].ToString();
            lblDharaniNo.Text = ds.Tables[0].Rows[0]["DHARANINUMBER"].ToString();
            lblNameOfMineral.Text = ds.Tables[0].Rows[0]["MINERALNAME"].ToString();
            lblExtHctors.Text = ds.Tables[0].Rows[0]["EXTENTINHECTARE"].ToString();
            lblDistrict.Text = ds.Tables[0].Rows[0]["DistrictName"].ToString();
            lblMandal.Text = ds.Tables[0].Rows[0]["MandalName"].ToString();
            lblVillage.Text = ds.Tables[0].Rows[0]["VillageName"].ToString();
            lblSurveyNo.Text = ds.Tables[0].Rows[0]["SURVEYNO"].ToString();
            lblPartExtent.Text = ds.Tables[0].Rows[0]["PartExtent"].ToString();
            lblMobileNo.Text = ds.Tables[0].Rows[0]["MOBILENO"].ToString();
            lblPAN.Text = ds.Tables[0].Rows[0]["PANcardno"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            lblAadhar.Text = ds.Tables[0].Rows[0]["AadharNo"].ToString();
            
        }
    }

    public DataSet GetPattalandappl(string PATTADARID)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("SP_printPattalandAppl", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (PATTADARID.Trim() == "" || PATTADARID.Trim() == null || PATTADARID.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@PATTADARID", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@PATTADARID", SqlDbType.VarChar).Value = PATTADARID;
            }


            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();

        }
        return ds;
    }
}