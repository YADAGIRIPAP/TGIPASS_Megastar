using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_CommencedUnitsStatus : System.Web.UI.Page
{
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["user_id"]) != "" && Convert.ToString(Session["Role_Code"]) == "GM")
        {
            if (!IsPostBack)
            {
                getdistricts();
                fillgrid();
            }
        }
        else { Response.Redirect("~/Tshome.aspx"); }
    }
    private void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddlDistricts.DataSource = dsnew.Tables[0];
        ddlDistricts.DataTextField = "District_Name";
        ddlDistricts.DataValueField = "District_Id";
        ddlDistricts.DataBind();
        ddlDistricts.Items.Insert(0, "--Select--");
        ddlDistricts.SelectedValue = Convert.ToString(Session["DistrictID"]);
        ddlDistricts.Enabled = false;

    }
    public void fillgrid()
    {
        DataSet dsnew = new DataSet();
        string District = ddlDistricts.SelectedItem.Text;

        Label1.Text = " Levle Update - Status of Implementation";


        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@District",SqlDbType.VarChar),
        };
        pp[0].Value = District;

        dsnew = Gen.GenericFillDs("GetCommnecedListToUpdatebeyond6months", pp);
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            lblMsg0.Text = "Total Records Found :" + dsnew.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            lblMsg0.Text = "Total Records Found : 0";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    protected void excel_button_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        Button btnUpdate=(Button)sender;
        GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;
        HyperLink hplUid=row.FindControl("hplUIDNo") as HyperLink;
        HyperLink hplUnitName = row.FindControl("hplUnitName") as HyperLink;
        Response.Redirect("UpdateCommencedUnitsStatus.aspx?UID="+ hplUid.Text+"&UnitName="+ hplUnitName.Text);

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string Uid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
        //    string UnitName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UnitName")).Trim();

        //    Button btn = (Button)e.Row.FindControl("btnUpdate");

        //    if (Uid != "0")
        //    {
        //        btn.OnClientClick = "javascript:return Popup('" + Uid + ", " + UnitName + "')";
        //    }
        //    else
        //    {
        //        btn.Text = "";
        //        btn.Enabled = false;
        //    }


        //}
    }
}