using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();

    static DataTable dtMyTable;

    DataRow dtr;
    static DataTable dtMyTablepr;
    static DataTable dtMyTableCertificate;

    DataRow dtrdr1;
    DataTable myDtNewRecdr1 = new DataTable();

    static DataTable dtMyTable1;

    DataRow dtr1;
    static DataTable dtMyTablepr1;
    static DataTable dtMyTableCertificate1;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {

            lblIPOname.Text = Session["user_id"].ToString();


            BindDistricts();
            
            getIPOS();
        //    ddlMonth.SelectedIndex = System.DateTime.Now.Month - 1;
          //  ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
            if ((System.DateTime.Now.Month) == 1)
            {
                ddlMonth.SelectedValue = "12";
                ddlYear.Enabled = false;
                ddlMonth.Enabled = false;
                ddlYear.SelectedValue = ddlYear.Items.FindByValue((System.DateTime.Now.Year - 1).ToString()).Value;
            }
            else
            {
                ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
                ddlYear.Enabled = false;

                ddlMonth.SelectedValue = ddlMonth.Items.FindByValue((System.DateTime.Now.Month - 1).ToString()).Value;
                ddlMonth.Enabled = false;

            }
            ddlMonth.Enabled = false;
            ddlYear.Enabled = false;
        }

        if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "0")
        {
            ddlUnitMandal_SelectedIndexChanged(this, EventArgs.Empty);
            ddlUnitDIst_SelectedIndexChanged(this, EventArgs.Empty);
            Failure.Visible = false;
            success.Visible = false;
            FillDetails();

            BtnSave1.Text = "Update";
            //lblresult.Text = "";
            //Btnsave.Enabled = true;
            hdfFlagID.Value = "";
        }
    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlUnitDIst.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlUnitDIst.DataSource = dsd.Tables[0];
                ddlUnitDIst.DataValueField = "District_Id";
                ddlUnitDIst.DataTextField = "District_Name";
                ddlUnitDIst.DataBind();
                //ddlUnitDIst.Items.Insert(0, "--District--");
                AddSelect(ddlUnitDIst);
            }
            else
            {
                //ddlUnitDIst.Items.Insert(0, "--District--");
                AddSelect(ddlUnitDIst);
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public void FillDetails()
    {
        DataSet dsemp = new DataSet();

        dsemp = Gen.getTsipassreport4(hdfID.Value);

        if (dsemp.Tables[0].Rows.Count > 0)
        {
            //ddlIPOname.SelectedValue = dsemp.Tables[0].Rows[0]["intIPOid"].ToString();
            lblIPOname.Text = dsemp.Tables[0].Rows[0]["Emp_Name"].ToString();
            txtUidno.Text = dsemp.Tables[0].Rows[0]["UID_No"].ToString();
            txtUnitName.Text = dsemp.Tables[0].Rows[0]["NameofUnit"].ToString();
            txtaddressunit.Text = dsemp.Tables[0].Rows[0]["AddressofUnit"].ToString();
            txtDDDate.Text = Convert.ToDateTime(dsemp.Tables[0].Rows[0]["DateofApproval"].ToString()).ToString("dd-MM-yyyy");
            ddlcstatus.SelectedValue = dsemp.Tables[0].Rows[0]["CurrentStatus"].ToString();
            txtremark.Text = dsemp.Tables[0].Rows[0]["Remarks"].ToString();
            hdfID.Value = dsemp.Tables[0].Rows[0]["intTSiPASSid"].ToString();
            BtnSave1.Text = "Update";

            if (dsemp.Tables[0].Rows[0]["District_Id"].ToString() != "")
            {
                ddlUnitDIst.SelectedValue = dsemp.Tables[0].Rows[0]["District_Id"].ToString();
                ddlUnitDIst.Enabled = false;
                ddlUnitDIst_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (dsemp.Tables[0].Rows[0]["Mandal_Id"].ToString() != "")
            {
                //ddlUnitMandal.SelectedValue= ddlUnitMandal.Items.FindByValue(dsemp.Tables[0].Rows[0]["Mandal_Id"].ToString().Trim()).Value;
               ddlUnitMandal.SelectedValue = dsemp.Tables[0].Rows[0]["Mandal_Id"].ToString();
                ddlUnitMandal.Enabled = false;
                ddlUnitMandal_SelectedIndexChanged(this, EventArgs.Empty);
            }

            ddlVillageunit.SelectedValue = dsemp.Tables[0].Rows[0]["Village_Id"].ToString();

        }



    }
    protected void getIPOS()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetIPOS(Session["uid"].ToString());

        ddlIPOname.DataSource = dsnew.Tables[0];
        ddlIPOname.DataTextField = "Dept_Name";
        ddlIPOname.DataValueField = "intUserid";
        ddlIPOname.DataBind();
        ddlIPOname.Items.Insert(0, "--Select--");
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (BtnSave1.Text == "Save")
            {
                lblmsg.Text = "";

                int i = Gen.InsertTsipassIPO(txtUidno.Text, ddlIPOname.SelectedValue, txtUnitName.Text, txtaddressunit.Text, txtDDDate.Text, ddlcstatus.SelectedValue, txtremark.Text, Session["uid"].ToString(), "1", ddlMonth.SelectedValue, ddlYear.SelectedValue,ddlUnitDIst.SelectedValue,ddlUnitMandal.SelectedValue,ddlVillageunit.SelectedValue);
                if (i > 0)
                {

                    lblmsg.Text = "Added Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                    clear();
                }

            }

            else if (BtnSave1.Text == "Update")
            {
                lblmsg.Text = "";

                int i = Gen.InsertTsipassIPO(txtUidno.Text, ddlIPOname.SelectedValue, txtUnitName.Text, txtaddressunit.Text, txtDDDate.Text, ddlcstatus.SelectedValue, txtremark.Text, Session["uid"].ToString(), hdfID.Value, ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlUnitDIst.SelectedValue, ddlUnitMandal.SelectedValue, ddlVillageunit.SelectedValue);
                if (i > 0)
                {

                    lblmsg.Text = "Updated Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                    clear();
                }

            }
        }
        catch (Exception ex)
        {
            success.Visible = false;
            Failure.Visible = true;
            lblmsg0.Text = ex.ToString();
        }
    }
    void clear()
    {

        txtUnitName.Text = "";
        txtaddressunit.Text = "";
        txtDDDate.Text = "";
        ddlcstatus.SelectedIndex = 0;
        txtremark.Text = "";
        ddlIPOname.SelectedIndex = 0;
        txtUidno.Text = "";
        BtnSave1.Text = "Save";
        ddlUnitDIst.SelectedIndex = 0;
        ddlUnitMandal.SelectedIndex = 0;
        ddlVillageunit.SelectedIndex = 0;



    }

    protected void txtRawItem_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        clear();
    }



    protected void txtUnitName_TextChanged(object sender, EventArgs e)
    {

    }


    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtUidno_TextChanged(object sender, EventArgs e)
    {
        DataSet dsemp = new DataSet();

        dsemp = Gen.getTsipassreportDet(txtUidno.Text);
        if (dsemp.Tables[0].Rows.Count > 0)
        {
            //txtUidno.Text = dsemp.Tables[0].Rows[0]["UID_No"].ToString();
            txtUnitName.Text = dsemp.Tables[0].Rows[0]["nameofunit"].ToString();
            txtaddressunit.Text = dsemp.Tables[0].Rows[0]["Address"].ToString();
            if (dsemp.Tables[0].Rows[0]["Approval_Date"].ToString() == "" || dsemp.Tables[0].Rows[0]["Approval_Date"].ToString() == "NULL")
            {
                txtDDDate.Text = "";
            }
            else
            {
                txtDDDate.Text = Convert.ToDateTime(dsemp.Tables[0].Rows[0]["Approval_Date"].ToString()).ToString("dd-MM-yyyy");
            }

            if (dsemp.Tables[0].Rows[0]["District_Id"].ToString() != "")
            {
                ddlUnitDIst.SelectedValue = dsemp.Tables[0].Rows[0]["District_Id"].ToString();
                ddlUnitDIst.Enabled = false;
                ddlUnitDIst_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (dsemp.Tables[0].Rows[0]["Mandal_Id"].ToString() != "")
            {
                ddlUnitMandal.SelectedValue = dsemp.Tables[0].Rows[0]["Mandal_Id"].ToString();
                ddlUnitMandal.Enabled = false;
                ddlUnitMandal_SelectedIndexChanged(this, EventArgs.Empty);
            }

            ddlVillageunit.SelectedValue = dsemp.Tables[0].Rows[0]["Village_Id"].ToString();
            ddlVillageunit.Enabled = false;
        }
    }

    protected void ddlUnitDIst_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUnitDIst.SelectedIndex == 0)
        {
            ddlUnitMandal.Items.Clear();
            // ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlUnitMandal);
        }
        //else
        //{
        //    ddlUnitMandal.Items.Clear();

        //}
        DataSet dsm = new DataSet();
        dsm = Gen.GetMandals(ddlUnitDIst.SelectedValue);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddlUnitMandal.DataSource = dsm.Tables[0];
            ddlUnitMandal.DataValueField = "Mandal_Id";
            ddlUnitMandal.DataTextField = "Manda_lName";
            ddlUnitMandal.DataBind();
            // ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlUnitMandal);
        }
        else
        {
            ddlUnitMandal.Items.Clear();
            //ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlUnitMandal);
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    protected void ddlUnitMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUnitMandal.SelectedIndex == 0)
        {

            ddlVillageunit.Items.Clear();
            // ddlVillageunit.Items.Insert(0, "--Village--");
            AddSelect(ddlVillageunit);
        }
        else
        {
            ddlVillageunit.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlUnitMandal.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlVillageunit.DataSource = dsv.Tables[0];
                ddlVillageunit.DataValueField = "Village_Id";
                ddlVillageunit.DataTextField = "Village_Name";
                ddlVillageunit.DataBind();
                AddSelect(ddlVillageunit);
                //  ddlVillageunit.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlVillageunit.Items.Clear();
                // ddlVillageunit.Items.Insert(0, "--Village--");
                AddSelect(ddlVillageunit);
            }
        }
    }

}
