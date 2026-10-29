using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using iTextSharp.text;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class Downloads : System.Web.UI.Page
{
    General Gen = new General();
    CommonBL objcommon = new CommonBL();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataSet ds = new DataSet();
            ds = objcommon.GetHomepagecontete();
            if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            {
                lbllastupdat.Text = ds.Tables[4].Rows[0]["LastDate"].ToString();
            }
            BindDepartment();

            fillgrid();
        }
    }

    public void fillgrid()
    {
        DataSet dsnew = new DataSet();

        int deptid = 0;
        int actid = 0;

        string searchText = txtSearch.Text.Trim();

        if (ddlDepartment.SelectedValue != "0")
        {
            deptid = Convert.ToInt32(ddlDepartment.SelectedValue);
        }

        if (ddlActs.SelectedValue != "0")
        {
            actid = Convert.ToInt32(ddlActs.SelectedValue);
        }

        dsnew = GetActandRules(deptid, actid, searchText);

        if (dsnew != null &&
            dsnew.Tables.Count > 0 &&
            dsnew.Tables[0].Rows.Count > 0)
        {
            GVActsRules.DataSource = dsnew.Tables[0];
            GVActsRules.DataBind();
        }
        else
        {
            GVActsRules.DataSource = null;
            GVActsRules.DataBind();
        }

    }
    public void BindDepartment()
    {
        try
        {
            ddlDepartment.Items.Clear();
            DataSet dsSector = new DataSet();
            dsSector = GetDepartmentservice();
            if (dsSector != null && dsSector.Tables.Count > 0 && dsSector.Tables[0].Rows.Count > 0)
            {
                ddlDepartment.DataSource = dsSector.Tables[0];
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "Dept_id";
                ddlDepartment.DataBind();
                //AddSelect(ddlDepartment);
                ddlDepartment.Items.Insert(0,
             new System.Web.UI.WebControls.ListItem("--Select--", "0"));

                ddlDepartment.SelectedIndex = 0;
            }
            else
            {
                ddlDepartment.Items.Clear();
                AddSelect(ddlDepartment);
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
    }
    public void BindActRules()
    {
        try
        {
            int deptid = 0;
            int actid = 0;

            if (!string.IsNullOrEmpty(ddlDepartment.SelectedValue))
                deptid = Convert.ToInt32(ddlDepartment.SelectedValue);

            ddlActs.Items.Clear();
            DataSet dsSector = new DataSet();
            dsSector = GetActRules(deptid);
            if (dsSector != null && dsSector.Tables.Count > 0 && dsSector.Tables[0].Rows.Count > 0)
            {
                ddlActs.DataSource = dsSector.Tables[0];
                ddlActs.DataTextField = "ActRulesGONoMemoNoCircularNo";
                ddlActs.DataValueField = "SNo";
                ddlActs.DataBind();
                AddSelect(ddlActs);
            }
            else
            {
                ddlActs.Items.Clear();
                AddSelect(ddlActs);
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
    }
    public void AddSelect(DropDownList ddl)
    {
        System.Web.UI.WebControls.ListItem li =
            new System.Web.UI.WebControls.ListItem();

        li.Text = "--Select--";
        li.Value = "0";

        ddl.Items.Insert(0, li);
    }
    public DataSet GetDepartmentservice()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETDEPARTMENTS", con.GetConnection);
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //if (ddlDepartment.SelectedValue == "0" &&
        //ddlActs.SelectedValue == "0" &&
        //string.IsNullOrWhiteSpace(txtSearch.Text))
        //{
        //    lblmsg0.Text = "Please select Department or Act/Rule or enter Search Text.";
        //    Failure.Visible = true;
        //    return;
        //}

        //Failure.Visible = false;
        //fillgrid();

        if (ddlDepartment.SelectedValue == "0" &&
        ddlActs.SelectedValue == "0" &&
        string.IsNullOrWhiteSpace(txtSearch.Text))
        {
            lblmsg0.Text = "Please select Department or Act/Rule or enter search text.";
            Failure.Visible = true;

            // Clear GridView
            GVActsRules.DataSource = null;
            GVActsRules.DataBind();

            return;
        }

        lblmsg0.Text = "";
        Failure.Visible = false;

        fillgrid();
    }

    protected void GVActsRules_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    string filepath = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Filepath"));

            //    HyperLink hprlink = (HyperLink)e.Row.FindControl("lnkView");

            //    if (!string.IsNullOrEmpty(filepath))
            //    {
            //        hprlink.NavigateUrl = "viewpdf.aspx?filepathnew=" + Server.UrlEncode(filepath);
            //        hprlink.Text = "View";
            //        hprlink.Target = "_blank";
            //    }
            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GOCopy"));
                //string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                HyperLink h1 = (HyperLink)e.Row.FindControl("lnkView");
                h1.NavigateUrl = "viewpdf.aspx?filepathnew=" + filepathnew;
                // h1.Text = "Click Here";
            }
        }
        catch (Exception ex)
        {
            // Log Error
        }
    }
    public DataSet GetActandRules(int deptid, int acts, string searchText)
    {
        DataSet ds = new DataSet();

        try
        {
            con.OpenConnection();

            SqlDataAdapter da = new SqlDataAdapter("USP_GETDEPTACTRULES", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@DEPT_ID", SqlDbType.Int).Value = deptid;
            da.SelectCommand.Parameters.Add("@ACTRULES", SqlDbType.Int).Value = acts;
            if (string.IsNullOrWhiteSpace(searchText))
                da.SelectCommand.Parameters.Add("@SearchText", SqlDbType.VarChar, 200).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@SearchText", SqlDbType.VarChar, 200).Value = searchText.Trim();


            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }

        return ds;
    }


    public DataSet GetActRules(int deptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETACTRULES", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@dept_id", SqlDbType.Int).Value = deptid;
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
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtSearch.Text = "";
            lblmsg0.Text = "";
            Failure.Visible = false;
            success.Visible = false;

            ddlActs.Items.Clear();

            if (ddlDepartment.SelectedValue != "0")
            {
                BindActRules();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void ddlActs_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        lblmsg0.Text = "";
        Failure.Visible = false;
        success.Visible = false;
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        ddlDepartment.SelectedIndex = 0;
        ddlActs.SelectedIndex = 0;
    }
}