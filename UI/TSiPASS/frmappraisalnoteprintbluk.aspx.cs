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
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;


public partial class UI_TSiPASS_frmappraisalnoteprintbluk : System.Web.UI.Page
{
    General gen = new General();
    List<officerRemarks> lstremarks = new List<officerRemarks>();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";
    ArrayList arListApplno = new ArrayList();//Added By Jivesh
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../ipasslogin.aspx");
        }
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["username"]).Contains("GENERAL"))
            {
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("3"));
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("4"));
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("9"));
            }
            else if (Convert.ToString(Session["username"]).Contains("SCP"))
            {
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("1"));
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("4"));
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("9"));
            }
            else if (Convert.ToString(Session["username"]).Contains("TSP"))
            {
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("1"));
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("3"));
            }
            DataSet ds = new DataSet();
            ds = gen.getProposedSVClistconvened();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlapplicationto.DataSource = ds.Tables[0];
                ddlapplicationto.DataValueField = "ProposedSVCDATEnew";
                ddlapplicationto.DataTextField = "ProposedSVCDATE";
                ddlapplicationto.DataBind();
            }
            txtFromDate.Text = "25-08-2019";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            //fetchIncentivedetIPONewIncTypeAddlDirector();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        int index = 0;
        CheckBox selCheckBox;
        bool bLLRPrinted;
        string applicationNo = "";
        string llrNo = "";
        //OfflineLicenseApplicationBS licenseAppliBS = new OfflineLicenseApplicationBS();
        while (index < grdDetails.Rows.Count)
        {
            selCheckBox = new CheckBox();
            selCheckBox = (CheckBox)grdDetails.Rows[index].Cells[1].FindControl("chkSelect");

            if (selCheckBox.Checked)
            {
                if (grdDetails.Rows[index].Cells[5].Text.Trim() != "")
                {
                    if (grdDetails.Rows[index].Cells[7].Text.Trim() != "")
                    {
                        //if (grdDetails.Rows[index].Cells[7].Text.ToUpper() != "&NBSP;")
                        //{
                        applicationNo = grdDetails.Rows[index].Cells[7].Text;
                        llrNo = grdDetails.Rows[index].Cells[7].Text;

                        //bLLRPrinted = licenseAppliBS.getLLRPrintStatus(GVData.Rows[index].Cells[1].Text);
                        bLLRPrinted = true;
                        if (bLLRPrinted)
                        {
                            arListApplno.Add(applicationNo); //Added By Jivesh
                            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('LLRPrintFormat.aspx?AppNo=" + GVData.Rows[index].Cells[1].Text + "','null','height=600,width=900,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');</Script>", false);
                            //break;
                        }
                        //}
                        //else
                        //{
                        //    //lblMsg.Text = Resources.ErrorMessages.MSGMVILL003.ToString();
                        //    //lblMsg.CssClass = "errormsg";
                        //}

                    }
                }
                //break; //By Jivesh
            }
            index++;
        }
        //Added By Jivesh
        if (arListApplno.Count > 0)
        {
            Session["applicationNo"] = arListApplno;
            if(ddlincentivetype.SelectedValue=="6")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('appraisalNote2.aspx?AppNo=" + 0 + "','null','height=600,width=900,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');</Script>", false);
            }
            else if(ddlincentivetype.SelectedValue == "5")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('Appraisalnoteprint_salestax.aspx?AppNo=" + 0 + "','null','height=600,width=900,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');</Script>", false);
            }
            if (ddlincentivetype.SelectedValue == "14")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('appraisalnoteprint_stampland.aspx?AppNo=" + 0 + "','null','height=600,width=900,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');</Script>", false);
            }
            if (ddlincentivetype.SelectedValue == "15")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('appraisalnoteprint_motrgage.aspx?AppNo=" + 0 + "','null','height=600,width=900,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');</Script>", false);
            }
            if (ddlincentivetype.SelectedValue == "16")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('appraisalnoteprint_landconversion.aspx?AppNo=" + 0 + "','null','height=600,width=900,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');</Script>", false);
            }
            if (ddlincentivetype.SelectedValue == "17")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('appraisalnoteprint_landcost.aspx?AppNo=" + 0 + "','null','height=600,width=900,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');</Script>", false);
            }
            if (ddlincentivetype.SelectedValue == "3")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('apparaisalPowerTariff.aspx?AppNo=" + 0 + "','null','height=600,width=900,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');</Script>", false);
            }
            if (ddlincentivetype.SelectedValue == "1")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<Script>window.open('AppraisalNote_PV.aspx?AppNo=" + 0 + "','null','height=600,width=900,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');</Script>", false);
            }
        }
    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkAll = (CheckBox)grdDetails.HeaderRow.FindControl("chkAll");

        if (checkAll.Checked)
        {
            foreach (GridViewRow row in grdDetails.Rows)
            {
                CheckBox checkone = (CheckBox)row.FindControl("chkRow");
                checkone.Checked = true;
            }

        }
        else
        {
            foreach (GridViewRow row in grdDetails.Rows)
            {
                CheckBox checkone = (CheckBox)row.FindControl("chkRow");
                checkone.Checked = false;
            }
        }
    }

    public void fetchIncentivedetIPONewIncTypeAddlDirector()
    {
        DataSet dsnew = new DataSet();
        string ReleaseProceedingNo = "";
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        if (valid == 0)
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        dsnew = GetAppraisalprint(FromdateforDB, TodateforDB,ddlcategory.SelectedValue,ddlincentivetype.SelectedValue);
        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
            Button1.Visible = true;
            //bindgrdDetailsfooter(dsnew.Tables[0]);
        }
        else
        {
            //lblMsg.Text = "";
            // Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
            Button1.Visible = false;
        }
    }

    public DataSet GetAppraisalprint(string fromdate, string todate,string CASTEID, string MSTINCTYPEID)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FromDate",SqlDbType.VarChar),
                new SqlParameter("@ToDate",SqlDbType.VarChar),
                new SqlParameter("@MstIncentiveId",SqlDbType.VarChar),
                new SqlParameter("@CASTEID",SqlDbType.VarChar),
                 new SqlParameter("@SLCDate",SqlDbType.VarChar)
              // new SqlParameter("@DISTRICTID",SqlDbType.VarChar)
               
           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        pp[2].Value = MSTINCTYPEID;
        pp[3].Value = CASTEID;
        pp[4].Value = Convert.ToString(DateTime.ParseExact(ddlapplicationto.SelectedItem.Text, "dd/MM/yyyy", null).ToString("MM-dd-yyyy"));


        // Dsnew = gen.GenericFillDs("USP_GET_APPRAISAL_BLUK_TEST", pp);
        // Dsnew = gen.GenericFillDs("USP_GET_APPRAISAL_BLUK_NEW", pp);
        Dsnew = gen.GenericFillDs("USP_GET_APPRAISAL_BLUK_NEW_08052025", pp);
        return Dsnew;
    }

    protected void btngetdetails_Click(object sender, EventArgs e)
    {
        //txtFromDate.Text = "25-08-2021";
        //DateTime today = DateTime.Today;
        //txtTodate.Text = today.ToString("dd-MM-yyyy");
        fetchIncentivedetIPONewIncTypeAddlDirector();
    }
}