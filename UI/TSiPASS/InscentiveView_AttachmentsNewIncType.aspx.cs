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
using Org.BouncyCastle.Asn1.Ocsp;

public partial class InscentiveView_AttachmentsNewIncType : System.Web.UI.Page
{
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session.Count <= 0)
            {
                Response.Redirect("Index.aspx", false);
                return;
            }
            if (!Page.IsPostBack)
            {
                //if (Request.QueryString.Count > 0 && Request.QueryString["EntrpId"] != null)
                //{
                //obcmf.FillGrid(objFetch.FetchIncentiveTypesView_NewIncType(Convert.ToInt32(Request.QueryString["EntrpId"].ToString())), gvIncetiveTypes, false);
                obcmf.FillGrid(objFetch.FetchIncentiveTypesView_NewIncType(Convert.ToInt32(Request.QueryString["EntrpId"].ToString()), "0"), gvIncetiveTypes, false);
                //}
                //obcmf.FillGrid(objFetch.FetchIncentiveView(Convert.ToInt32(Session["uid"].ToString())), gvDetails, false);
            }
            //if (Session["EntprIncentive"] != null)
            //{
            Fetch obj = new Fetch();
            DataTable dt = obj.FetchIncentiveDtlsbyIncentiveID_NewIncType(Request.QueryString["EntrpId"].ToString());
            lblEmNo.Text = dt.Rows[0]["EMiUdyogAadhar"].ToString();
            lblUnitName.Text = dt.Rows[0]["UnitName"].ToString();
            lblApplicantname.Text = dt.Rows[0]["ApplciantName"].ToString();
            lblGender.Text = dt.Rows[0]["Gender"].ToString();
            lblCaste.Text = dt.Rows[0]["Caste"].ToString();
            lblMobileNumber.Text = dt.Rows[0]["MobileNo"].ToString();
            lblEmailId.Text = dt.Rows[0]["EmailID"].ToString();
            lblCategory.Text = dt.Rows[0]["Category"].ToString();
            lblLandValue.Text = dt.Rows[0]["Landvalue"].ToString();
            lblPlantValue.Text = dt.Rows[0]["PlantMachineryValue"].ToString();
            lblBuldingValue.Text = dt.Rows[0]["BuildingValue"].ToString();
            lblEuipmentvalue.Text = dt.Rows[0]["EquipmentValue"].ToString();

            lbllandvalue_Expansion.Text = dt.Rows[0]["Landvalue_EXPANSION"].ToString();
            lblbuildingvalue_expansion.Text = dt.Rows[0]["BuildingValue_EXPANSION"].ToString();
            lblplantandmachinaryvalue_expansion.Text = dt.Rows[0]["PlantMachineryValue_EXPANSION"].ToString();

            lblSector.Text = dt.Rows[0]["sector"].ToString();
            LBLDISTRICT.Text = dt.Rows[0]["District_Name"].ToString();

            lblapplicationnumber.Text = dt.Rows[0]["IncentiveId"].ToString();
            lblDateofAppln.Text = dt.Rows[0]["lblDateofAppln"].ToString();
            obcmf.FillGrid(objFetch.FetchIncetiveUploadsViewNewIncType(Convert.ToInt32(Request.QueryString["EntrpId"].ToString()),
                                                                0),
                            gvAttachments, false);


            //lblMeeSevaTransacNo.Text = dt.Rows[0]["MeeSevaTransactionNo"].ToString();
            //lblTsiPassTransacNo.Text = dt.Rows[0]["IncentiveId"].ToString();
            // }
            DataSet dscaste = new DataSet();
            dscaste = Gen.GetIncentivesCaste(Session["uid"].ToString(), Request.QueryString["EntrpId"].ToString());
            if (dscaste != null && dscaste.Tables.Count > 0 && dscaste.Tables[0].Rows.Count > 0)
            {
                if (dscaste.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() != "")
                    if (dscaste.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() == "Y")
                        LBLSCHEMENAME.Text = "T-PRIDE(PHC)";  //ADDED..

                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() != "" && dscaste.Tables[0].Rows[0]["Scheme"].ToString() != null)
                    {
                        LBLSCHEMENAME.Text = "TIDEA, 2014";

                        if (dscaste.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y" && dscaste.Tables[0].Rows[0]["IDFOODPROCESSING"].ToString() != "Y") //   if (caste == "3" || caste == "4")   //SC, ST
                        {
                            LBLSCHEMENAME.Visible = true;

                            LBLSCHEMENAME.Text = "T-PRIDE ";
                            //LBLSCHEMENAME.ForeColor = System.Drawing.Color.White;
                        }
                        else if (dscaste.Tables[0].Rows[0]["TSPflag"].ToString() == "Y" && dscaste.Tables[0].Rows[0]["IDFOODPROCESSING"].ToString() != "Y")
                        {
                            LBLSCHEMENAME.Visible = true;

                            LBLSCHEMENAME.Text = "T-PRIDE ";
                        }

                        else if (dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y" && dscaste.Tables[0].Rows[0]["IDFOODPROCESSING"].ToString() != "Y")
                        {
                            LBLSCHEMENAME.Visible = true;

                            LBLSCHEMENAME.Text = "T-IDEA";
                        }
                        else if (dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y" && dscaste.Tables[0].Rows[0]["IDFOODPROCESSING"].ToString() == "Y")
                        {
                            LBLSCHEMENAME.Visible = true;

                            LBLSCHEMENAME.Text = "TFAP";
                        }

                    }
                   
                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2005-10")
                    {
                        LBLSCHEMENAME.Text = "IIPP Scheme 2005 - 2010";
                    }
                    else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2010-15")
                    {
                        LBLSCHEMENAME.Text = "IIPP Scheme 2010 - 2015";   // IIPP 2010-15
                    }
                     if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TFAP")
                    {
                        LBLSCHEMENAME.Visible = true;

                        LBLSCHEMENAME.Text = "TFAP";
                    }
                if (Convert.ToString(dscaste.Tables[0].Rows[0]["MSME_Applied"]) == "Y")
                { LBLSCHEMENAME.Text = "MSME Policy -2024"; }


            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void lbtIncentive_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gr = (((LinkButton)sender).Parent.Parent as GridViewRow);
            //obcmf.FillGrid(objFetch.FetchIncentiveTypesView_NewIncType(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text)), gvIncetiveTypes, false);
            obcmf.FillGrid(objFetch.FetchIncentiveTypesView_NewIncType(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text), "0"), gvIncetiveTypes, false);
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void lbtAttachments_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gr = (((LinkButton)sender).Parent.Parent as GridViewRow);
            obcmf.FillGrid(objFetch.FetchIncetiveUploadsViewNewIncType(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text), 0), gvAttachments, false);
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void lbtVwatt_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gr = (((LinkButton)sender).Parent.Parent as GridViewRow);
            obcmf.FillGrid(objFetch.FetchIncetiveUploadsViewNewIncType(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text),
                                                                Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).ToolTip)),
                            gvAttachments, false);
            //tblAttachments.Visible = true;
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
    protected void gvIncetiveTypes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string check = "";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label h3 = (Label)e.Row.Cells[0].FindControl("lblIncentiveName");

                if (h3.Text.Contains("AUTO REJECTED"))
                {
                    check = "Y";
                    autorejectedTR.Visible = true;
                    return;
                }

                else
                {
                    autorejectedTR.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}