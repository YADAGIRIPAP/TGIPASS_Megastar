using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmLabourDetails_Act3 : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {
                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                }
                else
                {
                    Session["Applid"] = "0";
                }

                DataSet dsver = new DataSet();
                dsver = Gen.GetverifyofqueLabour(Session["Applid"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatus(Session["Applid"].ToString());
                    ////string res = Gen.RetriveStatus("1002");
                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);
                    }
                }
                BindRegisteredActs();


                if (Request.QueryString["intApplicationId"] != null)
                {
                    hdfFlagID0.Value = Request.QueryString["intApplicationId"];

                    if (!IsPostBack)
                    {
                        FillDetails();

                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    void FillDetails()
    {

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();

        try
        {
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            ds = Gen.getLabourDetails(hdfFlagID0.Value.ToString(), QuestionnaireId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                ddlSchemAct3.SelectedValue = ds.Tables[0].Rows[0]["Form1_3_Registered_Act"].ToString();
                ddlSchemAct3_SelectedIndexChanged(this, EventArgs.Empty);
                txtRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();
                txtReRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    public void BindRegisteredActs()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlSchemAct3.Items.Clear();
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            dsd = Gen.getLabourRegisteredActs(hdfFlagID0.Value.ToString(), QuestionnaireId);
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlSchemAct3.DataSource = dsd.Tables[0];
                ddlSchemAct3.DataValueField = "Application_Id";
                ddlSchemAct3.DataTextField = "Application_Name";
                ddlSchemAct3.DataBind();
                ddlSchemAct3.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlSchemAct3.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public void ResetFormControl(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControl(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).ReadOnly = true;
                        break;

                    case "System.Web.UI.WebControls.DropDownList":

                        if (((DropDownList)c).Items.Count > 0)
                        {
                            ((DropDownList)c).Enabled = false;
                        }
                        break;
                    case "System.Web.UI.WebControls.FileUpload":
                        ((FileUpload)c).Enabled = false;
                        break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)c).Enabled = false;
                        break;
                }
            }
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        string number = "";

        if (hdfFlagID0.Value != "")
        {

            number = hdfpencode.Value;
        }

        if (btnNext.Text == "Next")
        {
            DataSet ds = new DataSet();

            int valid = 0;
            valid = SaveLabourDetails();

            Response.Redirect("frmAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

            lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";

            success.Visible = true;
            Failure.Visible = false;

        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmLabourDetails_Act3.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");

    }
    protected void btnNext0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //labouractvo.
            int valid = 0;
            valid = SaveLabourDetails();
            lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlSchemAct3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private int SaveLabourDetails()
    {
        LabourAct2VO2 labouractvo = new LabourAct2VO2();
        labouractvo.QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
        labouractvo.intCFEEnterpid = Convert.ToInt32(Request.QueryString[0].ToString());

        labouractvo.CreatedBy = Convert.ToInt32(Session["uid"].ToString().Trim());
        labouractvo.RegActId = ddlSchemAct3.SelectedValue;
        labouractvo.LicenseRegNo = txtRegLicAct3.Text;

        int valid = 0;
        valid = Gen.InsertLabourDetailsAct3(labouractvo);
        return valid;
    }
}