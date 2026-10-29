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
using BusinessLogic;

public partial class InscentiveView_Attachments : System.Web.UI.Page
{
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {
            
            if (Session.Count <= 0)
            {
                Response.Redirect("../../Index.aspx",false);
                return;
            }
            if (!Page.IsPostBack)
            {
                //if (Request.QueryString.Count > 0 && Request.QueryString["EntrpId"] != null)
                //{
                    obcmf.FillGrid(objFetch.FetchIncentiveTypesView(Convert.ToInt32(Request.QueryString["EntrpId"].ToString())), gvIncetiveTypes, false);
                //}
                //obcmf.FillGrid(objFetch.FetchIncentiveView(Convert.ToInt32(Session["uid"].ToString())), gvDetails, false);
            }
            //if (Session["EntprIncentive"] != null)
            //{
                Fetch obj = new Fetch();
                DataTable dt = obj.FetchIncentiveDtlsbyIncentiveID(Request.QueryString["EntrpId"].ToString());
                lblEmNo.Text = dt.Rows[0]["EMiUdyogAadhar"].ToString();
                lblUnitName.Text = dt.Rows[0]["UnitName"].ToString();
                lblApplicantname.Text = dt.Rows[0]["ApplciantName"].ToString();
                lblGender.Text = dt.Rows[0]["Gender"].ToString();
                lblCaste.Text = dt.Rows[0]["Caste"].ToString();
                lblMobileNumber.Text = dt.Rows[0]["MobileNo"].ToString();
                lblEmail.Text = dt.Rows[0]["EmailID"].ToString();
                lblCategory.Text = dt.Rows[0]["Category"].ToString();
                lblLandValue.Text = dt.Rows[0]["Landvalue"].ToString();
                lblPlantValue.Text = dt.Rows[0]["PlantMachineryValue"].ToString();
                lblBuldingValue.Text = dt.Rows[0]["BuildingValue"].ToString();
                lblEuipmentvalue.Text = dt.Rows[0]["EquipmentValue"].ToString();
                lblSector.Text = dt.Rows[0]["sector"].ToString();
                lblDate.Text = dt.Rows[0]["DateOfApplication"].ToString();
                lblvillage.Text = dt.Rows[0]["Village"].ToString();
                lblMandal.Text = dt.Rows[0]["Mandal"].ToString();
                lblDistrict.Text = dt.Rows[0]["District"].ToString();
                lblState.Text = dt.Rows[0]["StateName"].ToString();
            
                obcmf.FillGrid(objFetch.FetchIncetiveUploadsView(Convert.ToInt32(Request.QueryString["EntrpId"].ToString()),
                                                                    0),
                                gvAttachments, false);
                

                //lblMeeSevaTransacNo.Text = dt.Rows[0]["MeeSevaTransactionNo"].ToString();
                //lblTsiPassTransacNo.Text = dt.Rows[0]["IncentiveId"].ToString();
           // }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void lbtIncentive_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gr = (((LinkButton)sender).Parent.Parent as GridViewRow);           
            obcmf.FillGrid(objFetch.FetchIncentiveTypesView(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text)),gvIncetiveTypes,false);
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void lbtAttachments_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gr = (((LinkButton)sender).Parent.Parent as GridViewRow);
            obcmf.FillGrid(objFetch.FetchIncetiveUploadsView(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text),0), gvAttachments, false);
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void lbtVwatt_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gr = (((LinkButton)sender).Parent.Parent as GridViewRow);
            obcmf.FillGrid(objFetch.FetchIncetiveUploadsView(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text),
                                                                Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).ToolTip)),
                            gvAttachments, false);
            //tblAttachments.Visible = true;
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
}
