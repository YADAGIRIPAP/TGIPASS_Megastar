using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_PrintADMGappl : System.Web.UI.Page
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
        ds = GetADMGappl(Request.QueryString[0].ToString().Trim());

        if (ds.Tables[0].Rows.Count != 0)
        {
            lblApplNo.Text = ds.Tables[0].Rows[0]["ADM_G_MineralID"].ToString();
            lblNameOfMineral.Text = ds.Tables[0].Rows[0]["NameoftheMineral"].ToString();
            lblExtHctors.Text = ds.Tables[0].Rows[0]["ExtentinHectors"].ToString();
            lblDistrict.Text = ds.Tables[0].Rows[0]["MineralDistrict"].ToString();
            lblMandal.Text = ds.Tables[0].Rows[0]["MineralMandal"].ToString();
            lblVillage.Text = ds.Tables[0].Rows[0]["village"].ToString();
            lblSurveyNo.Text = ds.Tables[0].Rows[0]["MineralSurveyNo"].ToString();
            lblPartExtent.Text = ds.Tables[0].Rows[0]["PartExtent"].ToString();
            lblMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            lblAadhar.Text = ds.Tables[0].Rows[0]["AadharNo"].ToString();
            
        }
    }

    public DataSet GetADMGappl(string ADMGapplNo)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("GetADMGapplDetails", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (ADMGapplNo.Trim() == "" || ADMGapplNo.Trim() == null || ADMGapplNo.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ADM_G_MineralID", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ADM_G_MineralID", SqlDbType.VarChar).Value = ADMGapplNo;
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