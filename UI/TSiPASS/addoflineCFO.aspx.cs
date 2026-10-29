using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;


public partial class UI_TSIPASS_addoflineCFO : System.Web.UI.Page
{
    insertDataVO objinsertDataVO = new insertDataVO();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDistricts();
            BindLineofActivityName();
            if (Session["uid"].ToString() != "34670" && Session["uid"].ToString() != "55766" && Session["uid"].ToString() != "77233" && Session["uid"].ToString() != "200451" && Session["uid"].ToString() != "251974" && Session["uid"].ToString() != "309647")
            {
                Response.Redirect("../../Index.aspx");
            }
        }


    }
    public void BindLineofActivityName()
    {
        try
        {
            ddlintLineofActivity.Items.Clear();
            DataSet dsc = new DataSet();
            osqlConnection.Open();
            DataSet oDataSet = new DataSet();
            SqlDataAdapter osqlDataAdapter = new SqlDataAdapter("GetCategoryDetNew", osqlConnection);
            osqlDataAdapter.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = "34670";
            osqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            osqlDataAdapter.Fill(oDataSet);

            if (oDataSet != null && oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows.Count > 0)
            {
                ddlintLineofActivity.DataSource = oDataSet.Tables[0];
                ddlintLineofActivity.DataValueField = "intLineofActivityid";
                ddlintLineofActivity.DataTextField = "LineofActivity_Name";
                ddlintLineofActivity.DataBind();
                ddlintLineofActivity.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlintLineofActivity.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        finally
        {
            osqlConnection.Close();
        }
    }

    public void BindDistricts()
    {
        try
        {
            osqlConnection.Open();
            DataSet oDataSet = new DataSet();
            SqlDataAdapter osqlDataAdapter = new SqlDataAdapter("GetDistrictsHYD", osqlConnection);
            osqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            osqlDataAdapter.Fill(oDataSet);
            if (oDataSet != null && oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = oDataSet.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                ddlProp_intDistrictid.Items.Insert(0, "--District--");
            }
            else
            {
                ddlProp_intDistrictid.Items.Insert(0, "--District--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        finally
        {
            osqlConnection.Close();
        }
    }
    protected void ddlProp_intDistrictid_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            if (ddlProp_intDistrictid.SelectedIndex == 0)
            {
                ddlMandal.Items.Clear();
                ddlMandal.Items.Insert(0, "--Mandal--");
            }
            else
            {
                ddlMandal.Items.Clear();
                DataSet dsm = new DataSet();
                DataSet oDataSet = new DataSet();
                SqlDataAdapter osqlDataAdapter = new SqlDataAdapter("GetMandals", osqlConnection);
                osqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                osqlDataAdapter.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.Int).Value = ddlProp_intDistrictid.SelectedValue;
                osqlDataAdapter.Fill(oDataSet);
                if (oDataSet.Tables[0].Rows.Count > 0)
                {
                    ddlMandal.DataSource = oDataSet.Tables[0];
                    ddlMandal.DataValueField = "Mandal_Id";
                    ddlMandal.DataTextField = "Manda_lName";
                    ddlMandal.DataBind();
                    ddlMandal.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlMandal.Items.Clear();
                    ddlMandal.Items.Insert(0, "--Mandal--");
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
        finally
        {
            osqlConnection.Close();
        }
    }



    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (save())
        {

            //string message = "alert('Submitted Successfully')";

            //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            //Response.Redirect("IPOMonthlyReport.aspx");
            success.Visible = true;
            lblmsg.Text = "Submitted Successfully";
            Failure.Visible = false;

        }

    }
    public bool save()
    {
        AssignValuestoVosFromcontrols();
        //string message = 

        //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

        string valid = insertDAta(objinsertDataVO);
        lblUIDNo.Text = valid.ToString();
        uidTR.Visible = true;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Submitted successfully+" + valid + "');", true);
        if (valid != "")
        {
            lblmsg.Text = "Submitted Successfully";
            success.Visible = true;

        }
        return true;
    }

    public string insertDAta(insertDataVO oinsertDataVO)
    {
        string valid = "";
        osqlConnection.Open();
        SqlTransaction transaction = null;

        transaction = osqlConnection.BeginTransaction();

        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "insertOFflinedataCFO";
            com.Transaction = transaction;
            com.Connection = osqlConnection;
            com.Parameters.AddWithValue("@unitname", oinsertDataVO.txtUnitname);
            com.Parameters.AddWithValue("@address", oinsertDataVO.txtAdddress);
            com.Parameters.AddWithValue("@lineofactivuty", oinsertDataVO.ddlintLineofActivity);
            com.Parameters.AddWithValue("@district", oinsertDataVO.ddlProp_intDistrictid);
            com.Parameters.AddWithValue("@mandal", oinsertDataVO.ddlMandal);
            com.Parameters.AddWithValue("@investment", oinsertDataVO.txtCrores);
            com.Parameters.AddWithValue("@employees", oinsertDataVO.txtEmployment);
            com.Parameters.Add("@return", SqlDbType.NVarChar, 1000);
            com.Parameters["@return"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();

            valid = com.Parameters["@return"].Value.ToString();

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
    void AssignValuestoVosFromcontrols()
    {
        objinsertDataVO = new insertDataVO();
        objinsertDataVO.txtUnitname = txtUnitname.Text;
        objinsertDataVO.txtAdddress = txtAdddress.Text;
        objinsertDataVO.ddlintLineofActivity = ddlintLineofActivity.SelectedValue;
        objinsertDataVO.ddlProp_intDistrictid = ddlProp_intDistrictid.SelectedValue;
        //objinsertDataVO.ddlMandal = ddlMandal.SelectedValue;
        objinsertDataVO.ddlMandal = "1";
        objinsertDataVO.txtCrores = txtCrores.Text;
        objinsertDataVO.txtEmployment = txtEmployment.Text;

    }
    public class insertDataVO
    {
        public string txtUnitname { get; set; }
        public string txtAdddress { get; set; }
        public string ddlintLineofActivity { get; set; }
        public string ddlProp_intDistrictid { get; set; }
        public string ddlMandal { get; set; }
        public string txtCrores { get; set; }
        public string txtEmployment { get; set; }

    }
}