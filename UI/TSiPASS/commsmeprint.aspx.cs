using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
public partial class UI_TSiPASS_commsmeprint : System.Web.UI.Page
{
    General clsGeneral = new General();
    DataSet ds = new DataSet();
    General Gen = new General();
    string MsmeNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString[0].ToString() != "")
            {
                MsmeNo = Request.QueryString[0].ToString().Trim();

                FillGrid();
            }
        }

      


        if (Session.Count == 0)
        {
            // Response.Redirect("frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");

        }
    }
    public void FillGrid()
    {

        //MsmeNo = "1107";
        ds = clsGeneral.GetMSMEDetails(MsmeNo);
        
        if (ds.Tables[0].Rows.Count != 0)
        {
            lblUnitName.Text = ds.Tables[0].Rows[0]["UNIT_NAME"].ToString();
            lblUAM.Text = ds.Tables[0].Rows[0]["UAM_ID"].ToString();
            lblDistrict0.Text = ds.Tables[0].Rows[0]["District_Name"].ToString();
            lblMandal0.Text = ds.Tables[0].Rows[0]["Manda_lName"].ToString();
            lblUnitAddress.Text = ds.Tables[0].Rows[0]["CompleteAddress"].ToString();
            lblinvestment.Text = ds.Tables[0].Rows[0]["Investment"].ToString();
            lblEmployment.Text = ds.Tables[0].Rows[0]["EMPLOYMENT"].ToString();
            lblUnitIE.Text = ds.Tables[0].Rows[0]["UNITS_IE_OR_NOT"].ToString();
            //lblDateofCapture.Text = ds.Tables[0].Rows[0]["DateofCapture"].ToString();
            lblPresentstatus.Text = ds.Tables[0].Rows[0]["PresentStatus"].ToString();
            lblTypeofIndustry.Text = ds.Tables[0].Rows[0]["TYPEOFINDUSTRY"].ToString();
            lblDateofCommencement.Text = ds.Tables[0].Rows[0]["DATEOFCOMMENCEMENT"].ToString();
            lblCategoryPCB.Text = ds.Tables[0].Rows[0]["PCBCATEGORY"].ToString();
            lblTypeofConnection.Text = ds.Tables[0].Rows[0]["TYPEOFCONNECTION"].ToString();
            lblUnitExport.Text = ds.Tables[0].Rows[0]["EXPORT"].ToString();

            lblEntrepreneur.Text = ds.Tables[0].Rows[0]["NAME_OF_ENTREPRENEUR"].ToString();
            lblMobileNo.Text = ds.Tables[0].Rows[0]["MOBILE_NO"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["EMAIL_ID"].ToString();
            lblSocialStatus.Text = ds.Tables[0].Rows[0]["SOCAILSTATUS"].ToString();
            lblPromoterDiffAbled.Text = ds.Tables[0].Rows[0]["PROMOTERDISABLED"].ToString();
            lblPromoterWomen.Text = ds.Tables[0].Rows[0]["PROMOTERWOMEN"].ToString();

            lblSector.Text = ds.Tables[0].Rows[0]["SECTOR"].ToString();
            lblLineofActivity.Text = ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString();
            lblrawprocured.Text= ds.Tables[0].Rows[0]["RAWMATERIALPROCURED"].ToString();
            lblLocation.Text = ds.Tables[0].Rows[0]["LocationDetails"].ToString();
           
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            GridView1.DataSource = ds.Tables[1];
            GridView1.DataBind();


        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            GridView2.DataSource = ds.Tables[2];
            GridView2.DataBind();


        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink");

        string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MANF_UNIT_PHOTO"));

        if (hyperLnk1 != "")
        {
            h3.Text = "View";
            h3.Visible = true;


        }
    }
}