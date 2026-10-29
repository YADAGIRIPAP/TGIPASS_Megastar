using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class UI_TSiPASS_frmBankIndustrySt : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            BindDistricts();
            GET_LINE_OF_ACTIVE();
            rbtTSIPASS_SelectedIndexChanged(sender, e);
        }

    }


    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
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
            ex.Message.ToString();
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
            //Response.Write(ex);
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProp_intDistrictid.SelectedIndex == 0)
            {
                ddlProp_intMandalid.Items.Clear();
                ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
            }
            else
            {
                ddlProp_intMandalid.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = gen.GetMandals(ddlProp_intDistrictid.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlProp_intMandalid.DataSource = dsm.Tables[0];
                    ddlProp_intMandalid.DataValueField = "Mandal_Id";
                    ddlProp_intMandalid.DataTextField = "Manda_lName";
                    ddlProp_intMandalid.DataBind();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlProp_intMandalid.Items.Clear();
                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
                }
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
            //Response.Write(ex);
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }


    }
    public void GET_LINE_OF_ACTIVE()
    {
        try
        {
            //DataTable dtLineOfActive = gen.GetTypeofSector();

            //if (dtLineOfActive != null && dtLineOfActive.Rows.Count > 0)
            //{
            //    ddlintLineofActivity.DataSource = dtLineOfActive;
            //    ddlintLineofActivity.DataTextField = "SectorName";
            //    ddlintLineofActivity.DataValueField = "SectorName";
            //    ddlintLineofActivity.DataBind();
            //    ddlintLineofActivity.Items.Insert(0, "--Select--");
            //}
            //else
            //{
            //    ddlintLineofActivity.ClearSelection();
            //    ddlintLineofActivity.Items.Insert(0, "--Select--");
            //}

            DataSet dsd = new DataSet();
            //ddlFinYear.Items.Clear();
            dsd = gen.GetTypeofSector();
            //ListItem ITEM=new ListItem
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlintLineofActivity.DataSource = dsd.Tables[0];
                ddlintLineofActivity.DataValueField = "SectorName";
                ddlintLineofActivity.DataTextField = "SectorName";
                ddlintLineofActivity.DataBind();
                //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                //{
                //    AddAll(ddlFinYear);
                //}
            }


            ddlintLineofActivity.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (rbtTSIPASS.SelectedValue == "1")
            {
                if (txtDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select   date');", true);
                    return;
                }
                if (txtLoanDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select Loan Sanctioned date');", true);
                    return;
                }
                decimal strTot_PrjCost = 0;
                try
                {
                    strTot_PrjCost = Convert.ToDecimal(txtLoanAmount.Text);
                    if (strTot_PrjCost < 500000)
                    {
                        Failure.Visible = true;
                        lblmsg0.Visible = true;
                        lblmsg0.Text = "Loan Amount Should be Greater than Rs.5 Lakhs";
                    }
                }
                catch (Exception ex)
                {
                }
            }
            BANKINDUSTRYSTATUS objbankstatus = new BANKINDUSTRYSTATUS();
            objbankstatus.IndustrySick = rbtTSIPASS.SelectedValue;

            objbankstatus.NAME_OF_THE_UNIT = txtUnitName.Text.Trim();
            objbankstatus.LINE_OF_ACTIVITY = ddlintLineofActivity.SelectedValue.ToString().Trim();
            objbankstatus.DISTRICT_ID = ddlProp_intDistrictid.SelectedValue.ToString().Trim();
            objbankstatus.MANDAL_ID = ddlProp_intMandalid.SelectedValue.ToString().Trim();
            objbankstatus.CONTACT_NO = txtcontact.Text.Trim();
            objbankstatus.GMAIL_ID = txtemail.Text.Trim();
            objbankstatus.TYPE = ddlType.SelectedValue.ToString().Trim();
            if (txtDate.Text == "" || txtDate.Text == null)
            {
                objbankstatus.DATE = null;
            }
            else
            {
                string[] ConvertedDt11 = txtDate.Text.Split('/');
                objbankstatus.DATE = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
            }
            if (txtLoanDate.Text == "" || txtLoanDate.Text == null)
            {
                objbankstatus.loan_application_date = null;
            }
            else
            {
                string[] ConvertedDtloan = txtLoanDate.Text.Split('/');
                objbankstatus.loan_application_date = ConvertedDtloan[2].ToString() + "/" + ConvertedDtloan[1].ToString() + "/" + ConvertedDtloan[0].ToString();
            }
            objbankstatus.Loan_Amount = txtLoanAmount.Text;
            objbankstatus.CREATED_BY = Session["uid"].ToString();
            //objbankstatus.DATE = txtDate.Text.Trim();
            General gen = new General();
            int i = gen.InsertBankStatus(objbankstatus);
            if (i == 1)
            {
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "RECORD INSERTED SUCCESSFULLY";
                BtnSave1.Enabled = false;
                //ClearAllControls();
                //BindDistricts();
                //BindBankNames();
                //Bindbranchname(ddl_banknames.SelectedValue.ToString().ToUpper());
            }
            else
            {
                Failure.Visible = true;
                success.Visible = false;
                lblmsg0.Text = "RECORD NOT INSERTED";
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }



    }


    public void CLEARALLCONTROLS()
    {
        Response.Redirect("frmBankIndustrySt.aspx");
    }


    protected void btnclear_Click(object sender, EventArgs e)
    {
        CLEARALLCONTROLS();
    }

    protected void txtLoanAmount_TextChanged(object sender, EventArgs e)
    {
        decimal strTot_PrjCost = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        lblmsg0.Visible = false;
        try
        {
            strTot_PrjCost = Convert.ToDecimal(txtLoanAmount.Text);
            if (strTot_PrjCost < 500000)
            {
                Failure.Visible = true;
                lblmsg0.Visible = true;
                lblmsg0.Text = "Loan Amount Should be Greater than Rs.5 Lakhs";
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void rbtTSIPASS_SelectedIndexChanged(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;
        if (rbtTSIPASS.SelectedValue == "1")
        {
            cfeid.Visible = true;
            // rbtTSIPASS.Enabled = false;
        }
        else
        {
            cfeid.Visible = false;
        }
    }

}


