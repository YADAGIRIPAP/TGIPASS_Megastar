using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;
public partial class UI_TSiPASS_OtherServicePrint : System.Web.UI.Page
{
    General clsGeneral = new General();
    DataSet ds = new DataSet();
    General Gen = new General();
    string IncentID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString[0].ToString() != "")
            {
                IncentID = Request.QueryString[0].ToString().Trim();

                FillDetails();
            }
        }

    }
    public void FillDetails()
    {
        ds = clsGeneral.GetOtherServiceDetails(IncentID);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                IncentID = ds.Tables[0].Rows[0]["IncentReformId"].ToString();

                txtudyogAadharNo.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                txtUnitname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                txtApplicantName.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                txtPanNumber.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                txtTinNumber.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();

                ddlCategory.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                ddltypeofOrg.Text = ds.Tables[0].Rows[0]["OrgType"].ToString();

               // ddlindustryStatus.Text = ds.Tables[0].Rows[0]["AppStatus"].ToString();

                txtDateofCommencement.Text = ds.Tables[0].Rows[0]["DCP"].ToString();

               

                //rblCaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                if(ds.Tables[0].Rows[0]["Caste"].ToString()== "OBC")
                {
                    subcste.Visible = true;
                    ddlsubcaste.Text = ds.Tables[0].Rows[0]["SubCaste"].ToString();
                    rblCaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                }
                else
                {
                    rblCaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                }
                lblcfeno.Text= ds.Tables[0].Rows[0]["UID_No"].ToString();
                lblPhc.Text= ds.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString();
                ddldistrictunit.Text = ds.Tables[0].Rows[0]["UnitDistName"].ToString();
                ddlUnitMandal.Text = ds.Tables[0].Rows[0]["UNITMANDAL"].ToString();
                ddlVillageunit.Text = ds.Tables[0].Rows[0]["UNITVILLAGE"].ToString(); ;
                txtunitaddhno.Text = ds.Tables[0].Rows[0]["UnitHNO"].ToString();
                txtstreetunit.Text = ds.Tables[0].Rows[0]["UnitStreet"].ToString();
                txtunitmobileno.Text = ds.Tables[0].Rows[0]["UnitMObileNo"].ToString();
                txtunitemailid.Text = ds.Tables[0].Rows[0]["UnitEmail"].ToString();

                ddldistrictoffc.Text = ds.Tables[0].Rows[0]["OFFCDISTNAME"].ToString();
                ddloffcmandal.Text = ds.Tables[0].Rows[0]["OFFCMANDAL"].ToString();
                ddlvilloffc.Text = ds.Tables[0].Rows[0]["OFFCVILLAGE"].ToString();
                txtoffaddhnno.Text = ds.Tables[0].Rows[0]["OffcHNO"].ToString();
                txtstreetoffice.Text = ds.Tables[0].Rows[0]["OffcStreet"].ToString();
                txtOffcMobileNO.Text = ds.Tables[0].Rows[0]["OffcMobileNO"].ToString();
                txtOffcEmail.Text = ds.Tables[0].Rows[0]["OffcEmail"].ToString();

            }
        }

    }
}