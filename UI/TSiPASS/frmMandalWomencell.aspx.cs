using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmMandalWomencell : System.Web.UI.Page
{
    General Gen = new General();

    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null || Session["uid"].ToString() == "")
        {
            Response.Redirect("~/TSHome.aspx");

        }
        else
        {

            if (!IsPostBack)
            {
                BindDistricts();

                if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
                {
                    ddldistrict.SelectedValue = Session["DistrictID"].ToString().Trim();

                    ddldistrict.Enabled = false;
                }
                BtnGetData_Click(sender, e);

            }


        }

    }
    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {

        }
    }
    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddldistrict.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = dsd.Tables[0];
                ddldistrict.DataValueField = "District_Id";
                ddldistrict.DataTextField = "District_Name";
                ddldistrict.DataBind();
                // ddlProp_intDistrictid.Items.Insert(0, "--Select--");
                AddSelect(ddldistrict);
            }
            else
            {
                // ddlProp_intDistrictid.Items.Insert(0, "--Select--");
                AddSelect(ddldistrict);
            }
        }
        catch (Exception ex)
        {

            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void BtnGetData_Click(object sender, EventArgs e)
    {

        { binddata(ddldistrict.SelectedValue); }

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/frmMandalWomencell.aspx");
    }
    protected void binddata(string district)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_GET_MANDALLEVEL_WOMENCELL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (district == null || district == "" || district == "-Select" || district == "0")
            {
                da.SelectCommand.Parameters.Add("@district", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                da.SelectCommand.Parameters.Add("@district", SqlDbType.VarChar).Value = district;
            }
            da.Fill(ds);
            con.CloseConnection();
            lblForGrid.Visible = true;
            grdwomencells.DataSource = ds;
            grdwomencells.DataBind();

        }
        catch (Exception Ex)
        { throw Ex; }

    }


    protected void grdwomencells_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h4 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "frmMandalFacilitatorsdrilldown.aspx?DistrictId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&Mandal=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MANDALID")).Trim();

            }


        }
    }
}