using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

public partial class UI_TSiPASS_InspectionreportStatus : System.Web.UI.Page
{
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindYears(ddlYear);
            }
        }
        catch (Exception)
        {
        }

    }
    public void BindYears(DropDownList ddlyears)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlYear.Items.Clear();
            dsd = Gen.GetYEARS();
            //ListItem ITEM=new ListItem
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlYear.DataSource = dsd.Tables[0];
                ddlYear.DataValueField = "Year";
                ddlYear.DataTextField = "Year";
                ddlYear.DataBind();
                //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                //{
                //    AddAll(ddlDistrict);
                //}
            }


        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int valid = 0;

            if (ddldepartment.SelectedValue == "")
            {
                lblmsg0.Text = "Please select Department";
                lblmsg0.Visible = true;
                valid = 1;
            }
            if (ddlYear.SelectedValue == "")
            {
                lblmsg0.Text = "Please select Year";
                lblmsg0.Visible = true;
                valid = 1;
            }
            if (txtrefno.Text == "")
            {
                lblmsg0.Text = "Please Enter Reference Number";
                lblmsg0.Visible = true;
                valid = 1;
            }
            DataSet ds = new DataSet();
            if (valid == 0)
            {
                ds = GetData(ddldepartment.SelectedValue, ddlYear.SelectedValue, txtrefno.Text.Trim());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grddetails.DataSource = ds.Tables[0];
                    grddetails.DataBind();
                    trinc.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("InspectionreportStatus.aspx");
    }

    public DataSet GetData(string department, string year, string referencenumber)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_INPSECTIONREPORT_CIS", con.GetConnection);
            da.SelectCommand.Parameters.Add("@DEPARTMENT", SqlDbType.VarChar).Value = department.ToString();
            da.SelectCommand.Parameters.Add("@REFERENCENUMBER", SqlDbType.VarChar).Value = referencenumber.ToString();
            da.SelectCommand.Parameters.Add("@YEAR", SqlDbType.VarChar).Value = year.ToString();

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
}