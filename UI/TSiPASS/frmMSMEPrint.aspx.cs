using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UI_TSiPASS_frmMSMEPrint : System.Web.UI.Page
{
    string msmeno = "";
    Cls_MSME Gen = new Cls_MSME();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString.Count>0)
        {
            if (!String.IsNullOrEmpty(Request.QueryString[0].ToString()))
            {
                msmeno = Request.QueryString[0].ToString();
                FILLDETAILS();
            }
        }
        else
        {
            Response.Redirect("MSME_DistrictwiseReport.aspx");
        }
        
    }
    public void FILLDETAILS()
    {
        DataSet dscheck = new DataSet();
      
        dscheck = Gen.GetMSMEOLDNEWDATA(msmeno);
        if (dscheck.Tables.Count > 0)
        {
            if (dscheck.Tables.Count >= 2)
            {
                if (dscheck.Tables[1].Rows.Count > 0)
                {
                    #region old 
                    lblNameOfUndertaker.Text = dscheck.Tables[1].Rows[0]["UNIT_NAME"].ToString();
                    lbludyogaadharno.Text = dscheck.Tables[1].Rows[0]["UAM_ID"].ToString();
                    lblcategory.Text = dscheck.Tables[1].Rows[0]["EnterpriseName"].ToString();
                    lbldistrict.Text = dscheck.Tables[1].Rows[0]["District_Name"].ToString();

                    lblindusestateornot.Text = dscheck.Tables[1].Rows[0]["UNITS_IE_OR_NOT"].ToString();
                    trindustryparkname.Visible = false;
                    if (dscheck.Tables[1].Rows[0]["UNITS_IE_OR_NOT"].ToString() == "NO")
                    {
                        trindustryparkname.Visible = false;

                    }
                    else
                    {
                        trindustryparkname.Visible = true;
                        lblindustryparkname.Text = dscheck.Tables[1].Rows[0]["IndustrialParkID"].ToString();
                    }
                    lbldistrict.Text = dscheck.Tables[1].Rows[0]["District_Name"].ToString();
                    lblmandal.Text = dscheck.Tables[1].Rows[0]["Manda_lName"].ToString();
                    lblvillage.Text = dscheck.Tables[1].Rows[0]["Village_Name"].ToString();

                    lblhouseno.Text = dscheck.Tables[1].Rows[0]["HouseNo"].ToString();
                    lbllocality.Text = dscheck.Tables[1].Rows[0]["Locality"].ToString();
                    lblstreet.Text = dscheck.Tables[1].Rows[0]["Street"].ToString();
                    lbllandmark.Text = dscheck.Tables[1].Rows[0]["LandMark"].ToString();
                    lblcompleteunitaddress.Text = dscheck.Tables[1].Rows[0]["CompleteAddress"].ToString();
                    lblinvestment.Text = dscheck.Tables[1].Rows[0]["Investment"].ToString();
                    lblEmployment.Text = dscheck.Tables[1].Rows[0]["EMPLOYMENT"].ToString();
                    if (!string.IsNullOrEmpty(dscheck.Tables[1].Rows[0]["PresentStatus"].ToString()))
                    {
                        if (dscheck.Tables[1].Rows[0]["PresentStatus"].ToString() == "Working")
                            lblpresentstatus.Text = "Working";
                        else if (dscheck.Tables[1].Rows[0]["PresentStatus"].ToString() == "Closed")
                            lblpresentstatus.Text = "Closed";
                        else if (dscheck.Tables[1].Rows[0]["PresentStatus"].ToString() == "Other")
                            lblpresentstatus.Text = "Other";

                    }

                    trotherstatus.Visible = false;
                    if (lblpresentstatus.Text == "Other")
                    {
                        lblotherstatus.Text = dscheck.Tables[1].Rows[0]["OtherPresentStatus"].ToString();
                    }
                    lblindustrytype.Text = dscheck.Tables[1].Rows[0]["TYPEOFINDUSTRY"].ToString();
                    lbl_dcp.Text = dscheck.Tables[1].Rows[0]["DATEOFCOMMENCEMENT"].ToString();
                    lblconnection.Text = dscheck.Tables[1].Rows[0]["TYPEOFCONNECTION"].ToString();

                    lblunitexport.Text = dscheck.Tables[1].Rows[0]["EXPORT"].ToString();
                    trexportcontry.Visible = false;
                    if (Convert.ToString(dscheck.Tables[1].Rows[0]["EXPORT"]) == "Yes")
                    {
                        trexportcontry.Visible = true;
                        lblexportcountry.Text = dscheck.Tables[1].Rows[0]["EXPORTCOUNTRY"].ToString();
                    }
                    //  lbl_dcp.Text = dscheck.Tables[1].Rows[0]["DateofCapture"].ToString();


                    lblentrepname.Text = dscheck.Tables[1].Rows[0]["NAME_OF_ENTREPRENEUR"].ToString();
                    lblmobileno.Text = dscheck.Tables[1].Rows[0]["MOBILE_NO"].ToString();
                    lblemailid.Text = dscheck.Tables[1].Rows[0]["EMAIL_ID"].ToString();
                    lblcaste.Text = dscheck.Tables[1].Rows[0]["SOCAILSTATUS"].ToString();
                    lblisdiffabled.Text = dscheck.Tables[1].Rows[0]["PROMOTERDISABLED"].ToString();
                    lblpromoterwomen.Text = dscheck.Tables[1].Rows[0]["PROMOTERWOMEN"].ToString();



                    lblsector.Text = dscheck.Tables[1].Rows[0]["SECTOR"].ToString();

                    lblLOA.Text = dscheck.Tables[1].Rows[0]["LineofActivity_Name"].ToString();
                    lblpcbcat.Text = dscheck.Tables[1].Rows[0]["PCBCATEGORY"].ToString();
                    //txtProductSpec.Text = dscheck.Tables[1].Rows[0]["PRODUCT_SPEC"].ToString();

                    //trrawdistrict.Visible = false;
                    //trrawstate.Visible = false;
                    //trrawcontry.Visible = true;

                    if (Convert.ToString(dscheck.Tables[1].Rows[0]["RAWMATERIALPROCURED"]) == "From the State")
                    {
                        trrawdistrict.Visible = true;
                        trrawstate.Visible = false;
                        trrawcontry.Visible = false;
                        lblrawmatfrom.Text = "From the State";
                        lblrawdistrict.Text = dscheck.Tables[1].Rows[0]["LocationDetails"].ToString();
                    }
                    else if (Convert.ToString(dscheck.Tables[1].Rows[0]["RAWMATERIALPROCURED"]) == "Outside the State")
                    {
                        trrawdistrict.Visible = false;
                        trrawstate.Visible = true;
                        trrawcontry.Visible = false;
                        lblrawmatfrom.Text = "Outside the State";
                        lblrawmaterialprocredstate.Text = dscheck.Tables[1].Rows[0]["LocationDetails"].ToString();
                    }
                    else if (Convert.ToString(dscheck.Tables[1].Rows[0]["RAWMATERIALPROCURED"]) == "Outside the Country")
                    {
                        trrawdistrict.Visible = false;
                        trrawstate.Visible = false;
                        trrawcontry.Visible = true;
                        lblrawmatfrom.Text = "Outside the Country";
                        //div_rawcountry.Visible = true;
                        lblrawmaterialproccountry.Text = dscheck.Tables[1].Rows[0]["RAWMATERIALCOUNTRY"].ToString();
                    }


                    lblremarks.Text = dscheck.Tables[1].Rows[0]["REMARKS"].ToString();




                    #endregion
                }
            }

            if (dscheck.Tables.Count >=1)
            {
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    //New/latest Main Table Data                 
                    #region Update
                    lblupdatedindustryname.Text = dscheck.Tables[0].Rows[0]["UNIT_NAME"].ToString();
                    lblupdatedudyogaadharno.Text = dscheck.Tables[0].Rows[0]["UAM_ID"].ToString();
                    lblupdatedcategory.Text = dscheck.Tables[0].Rows[0]["EnterpriseName"].ToString();
                    lblupdateddist.Text = dscheck.Tables[0].Rows[0]["District_Name"].ToString();

                    lblupdatedindusestateornot.Text = dscheck.Tables[0].Rows[0]["UNITS_IE_OR_NOT"].ToString();
                    trindustryparkname.Visible = false;
                    if (dscheck.Tables[0].Rows[0]["UNITS_IE_OR_NOT"].ToString() == "NO")
                    {
                        trindustryparkname.Visible = false;

                    }
                    else
                    {
                        trindustryparkname.Visible = true;
                        //need to add master in database procedure
                        lblindustryparkname_new.Text = dscheck.Tables[0].Rows[0]["IndustrialParkID"].ToString();
                    }
                    lblupdateddist.Text = dscheck.Tables[0].Rows[0]["District_Name"].ToString();
                    lblupdatedmandal.Text = dscheck.Tables[0].Rows[0]["Manda_lName"].ToString();
                    lblupdatedvillage.Text = dscheck.Tables[0].Rows[0]["Village_Name"].ToString();

                    lblupdthouseno.Text = dscheck.Tables[0].Rows[0]["HouseNo"].ToString();
                    lbllocality_new.Text = dscheck.Tables[0].Rows[0]["Locality"].ToString();
                    lblstreet_new.Text = dscheck.Tables[0].Rows[0]["Street"].ToString();
                    lbllandmark_new.Text = dscheck.Tables[0].Rows[0]["LandMark"].ToString();
                    lblcompleteunitaddress_new.Text = dscheck.Tables[0].Rows[0]["CompleteAddress"].ToString();
                    lblinvestment_new.Text = dscheck.Tables[0].Rows[0]["Investment"].ToString();
                    lblEmployment_new.Text = dscheck.Tables[0].Rows[0]["EMPLOYMENT"].ToString();
                    if (!string.IsNullOrEmpty(dscheck.Tables[0].Rows[0]["PresentStatus"].ToString()))
                    {
                        if (dscheck.Tables[0].Rows[0]["PresentStatus"].ToString() == "Working")
                            lblpresentstatus_new.Text = "Working";
                        else if (dscheck.Tables[0].Rows[0]["PresentStatus"].ToString() == "Closed")
                            lblpresentstatus_new.Text = "Closed";
                        else if (dscheck.Tables[0].Rows[0]["PresentStatus"].ToString() == "Other")
                            lblpresentstatus_new.Text = "Other";

                    }

                    trotherstatus.Visible = false;
                    if (lblpresentstatus_new.Text == "Other")
                    {
                        lblotherstatus_new.Text = dscheck.Tables[0].Rows[0]["OtherPresentStatus"].ToString();
                    }
                    lblindustrytype_new.Text = dscheck.Tables[0].Rows[0]["TYPEOFINDUSTRY"].ToString();
                    lbldcp_new.Text = dscheck.Tables[0].Rows[0]["DATEOFCOMMENCEMENT"].ToString();
                    lblconnection_new.Text = dscheck.Tables[0].Rows[0]["TYPEOFCONNECTION"].ToString();

                    lblunitexport_new.Text = dscheck.Tables[0].Rows[0]["EXPORT"].ToString();
                    trexportcontry.Visible = false;
                    if (Convert.ToString(dscheck.Tables[0].Rows[0]["EXPORT"]) == "Yes")
                    {
                        trexportcontry.Visible = true;
                        lblexportcountry_new.Text = dscheck.Tables[0].Rows[0]["EXPORTCOUNTRY"].ToString();
                    }
                    //  lbl_dcp.Text = dscheck.Tables[1].Rows[0]["DateofCapture"].ToString();


                    lblentrepname_new.Text = dscheck.Tables[0].Rows[0]["NAME_OF_ENTREPRENEUR"].ToString();
                    lblmobileno_new.Text = dscheck.Tables[0].Rows[0]["MOBILE_NO"].ToString();
                    lblemailid_new.Text = dscheck.Tables[0].Rows[0]["EMAIL_ID"].ToString();
                    lblcaste_new.Text = dscheck.Tables[0].Rows[0]["SOCAILSTATUS"].ToString();
                    lblisdiffabled_new.Text = dscheck.Tables[0].Rows[0]["PROMOTERDISABLED"].ToString();
                    lblpromoterwomen_new.Text = dscheck.Tables[0].Rows[0]["PROMOTERWOMEN"].ToString();



                    lblsector_new.Text = dscheck.Tables[0].Rows[0]["SECTOR"].ToString();

                    lblLOA_new.Text = dscheck.Tables[0].Rows[0]["LineofActivity_Name"].ToString();
                    lblpcbcat_new.Text = dscheck.Tables[0].Rows[0]["PCBCATEGORY"].ToString();
                    //txtProductSpec.Text = dscheck.Tables[1].Rows[0]["PRODUCT_SPEC"].ToString();

                    //trrawdistrict.Visible = false;
                    //trrawstate.Visible = false;
                    //trrawcontry.Visible = false;

                    if (Convert.ToString(dscheck.Tables[0].Rows[0]["RAWMATERIALPROCURED"]) == "From the State")
                    {
                        trrawdistrict.Visible = true;
                        trrawcontry.Visible = false;
                        trrawstate.Visible = false;
                        lblrawmatfrom_new.Text = "From the State";
                        lblrawdistrict_new.Text = dscheck.Tables[0].Rows[0]["LocationDetails"].ToString();
                    }
                    else if (Convert.ToString(dscheck.Tables[0].Rows[0]["RAWMATERIALPROCURED"]) == "Outside the State")
                    {
                        trrawdistrict.Visible = false;
                        trrawstate.Visible = true;
                        trrawcontry.Visible = false;
                        lblrawmatfrom_new.Text = "Outside the State";
                        lblrawmaterialprocredstate_new.Text = dscheck.Tables[1].Rows[0]["LocationDetails"].ToString();
                    }
                    else if (Convert.ToString(dscheck.Tables[0].Rows[0]["RAWMATERIALPROCURED"]) == "Outside the Country")
                    {
                        trrawdistrict.Visible = false;
                        trrawstate.Visible = false;
                        trrawcontry.Visible = true;
                        lblrawmatfrom_new.Text = "Outside the Country";
                        //div_rawcountry.Visible = true;
                        lblrawmaterialproccountry_new.Text = dscheck.Tables[0].Rows[0]["RAWMATERIALCOUNTRY"].ToString();
                    }


                    lblremarks_new.Text = dscheck.Tables[0].Rows[0]["REMARKS"].ToString();

                    #endregion
                }
            }
           

            if (dscheck.Tables.Count >= 3)
            {              
                if (dscheck.Tables[2].Rows.Count > 0)
                {
                    //New Manfacture
                    grd_manufacturedproducts_NEW.DataSource = dscheck.Tables[2];
                    grd_manufacturedproducts_NEW.DataBind();
                }
                else
                {
                    grd_manufacturedproducts_NEW.DataSource = null;
                    grd_manufacturedproducts_NEW.DataBind();
                }
            }
            
            if (dscheck.Tables.Count >= 4)
            {
                if (dscheck.Tables[3].Rows.Count > 0)
                {
                    //OLD Manufacture
                    grd_manufacturedproducts.DataSource = dscheck.Tables[3];
                }
                else
                {
                    grd_manufacturedproducts.DataSource = null;
                    grd_manufacturedproducts.DataBind();
                }
                
                grd_manufacturedproducts.DataBind();
            }
            if (dscheck.Tables.Count >= 5)
            {
                if (dscheck.Tables[4].Rows.Count > 0)
                {
                    //New
                    grd_rawmaterial_NEW.DataSource = dscheck.Tables[4];
                }
                else
                {
                    grd_rawmaterial_NEW.DataSource = null;
                }

                grd_rawmaterial_NEW.DataBind();
            }
            if (dscheck.Tables.Count >= 6)
            {
                if (dscheck.Tables[5].Rows.Count > 0)
                {
                    //old
                    grd_rawmaterial.DataSource = dscheck.Tables[5];
                }
                else
                {
                    grd_rawmaterial.DataSource = null;
                }

                grd_rawmaterial.DataBind();
            }
            
            
        
        
        }
    }
}