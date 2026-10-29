using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Collections.Generic;

public partial class UI_TSiPASS_frmtradeRenewal : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    TradeCls objtrade = new TradeCls();
    TradeRenewalProperties tradevo = new TradeRenewalProperties();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();
            dsnew = Gen.getdataofidentityRENAPPROVALID(Request.QueryString[0].ToString(), "119");//Session["Applid"].ToString()
            if (dsnew.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {
                    //Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    Response.Redirect("frmDrugRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                }
                else
                {
                    Response.Redirect("frmPoliceattachments_Ren.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                }
            }
        }
        if (!IsPostBack)
        {
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
            {

                ResetFormControl(this);

            }

            //DataSet ds = new DataSet();
            //ds = Gen.ViewAttachmentREN(Session["uid"].ToString());

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    FillDetails();
            //}
        }
       
        if (txttinNo.Text.Trim() == "")
        {
            txttinNo.Enabled = true;
            txttinNo.ReadOnly = false;
        }
        if (!IsPostBack)
        {

            DataSet ds = new DataSet();
            ds = objtrade.Getdata_TradeRenewalDetails(Session["Applid"].ToString(), Session["uid"].ToString().Trim(), "I");

            if (ds.Tables[0].Rows.Count > 0)
            {
                FillDetails();
            }
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

                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)c).Enabled = false;
                        break;
                }
            }
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            tradevo.AddressofOwner = txttradeaddress.Text;
            tradevo.ArrearGarbageCharges = txtagc.Text;
            tradevo.ArrearsAmountLicence = txtarreasfees.Text;
            tradevo.ArrearsAmountLicenseinterest = txtlicencesfeeinterst.Text;
            tradevo.CategoryID = "1";
            tradevo.CategoryName = txtCatogory.Text;
            tradevo.Created_by = Session["uid"].ToString();
            tradevo.CurrentGarbageCharges = Txtcgc.Text;
            tradevo.CurrentLicenceFee = txtcurrlience.Text;
            tradevo.CurrentLicenceFeeInterest = txtclfi.Text;
            tradevo.intApprovalid = "";
            tradevo.intCFOEnterpid = Session["uid"].ToString().Trim();
            tradevo.intDeptid = "";
            tradevo.intQuessionaireCFOid = Request.QueryString[0].ToString();
            tradevo.intStageid = "";
            tradevo.licenceValidFrom = "";
            tradevo.licenceValidUpto = "";
            tradevo.Modified_by = Session["uid"].ToString();
            tradevo.NameofOwner = txtownername.Text;
            tradevo.PlinthArea = Txtplinth.Text;
            tradevo.Reg_Id = "";
            tradevo.RoadTypeId = "1";
            tradevo.RoadTypeName = txtroadtype.Text;
            tradevo.SubCategory = Txtsubcatogory.Text;
            tradevo.SubCategoryID = "1";
            tradevo.TitleOfTrade = txttitletrade.Text;
            tradevo.TotalAmount = Txttotalamount.Text;
            tradevo.TradeAddress = txttradeaddress.Text;
            tradevo.TradeTinno = txttinNo.Text;
            tradevo.Uid_No = "";

            objtrade.InsertTradeRenewal(tradevo);
            lblmsg.Text = "<font color='green'>Submitted SuccessFully....!</font>";
            success.Visible = true;
            Failure.Visible = false;
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            tradevo.AddressofOwner = Txtowneradress.Text;
            tradevo.ArrearGarbageCharges = txtagc.Text;
            tradevo.ArrearsAmountLicence = txtarreasfees.Text;
            tradevo.ArrearsAmountLicenseinterest = txtlicencesfeeinterst.Text;
            tradevo.CategoryID = "1";
            tradevo.CategoryName = txtCatogory.Text;
            tradevo.Created_by = Session["uid"].ToString();
            tradevo.CurrentGarbageCharges = Txtcgc.Text;
            tradevo.CurrentLicenceFee = txtcurrlience.Text;
            tradevo.CurrentLicenceFeeInterest = txtclfi.Text;
            tradevo.intApprovalid = "";
            tradevo.intCFOEnterpid = Session["uid"].ToString().Trim();
            tradevo.intDeptid = "";
            tradevo.intQuessionaireCFOid = Request.QueryString[0].ToString();
            tradevo.intStageid = "";
            tradevo.licenceValidFrom = "";
            tradevo.licenceValidUpto = "";
            tradevo.Modified_by = Session["uid"].ToString();
            tradevo.NameofOwner = txtownername.Text;
            tradevo.PlinthArea = Txtplinth.Text;
            tradevo.Reg_Id = "";
            tradevo.RoadTypeId = "1";
            tradevo.RoadTypeName = txtroadtype.Text;
            tradevo.SubCategory = Txtsubcatogory.Text;
            tradevo.SubCategoryID = "1";
            tradevo.TitleOfTrade = txttitletrade.Text;
            tradevo.TotalAmount = Txttotalamount.Text;
            tradevo.TradeAddress = txttradeaddress.Text;
            tradevo.TradeTinno = txttinNo.Text;
            tradevo.Uid_No = "";

            objtrade.InsertTradeRenewal(tradevo);
            lblmsg.Text = "<font color='green'>Submitted SuccessFully....!</font>";
            success.Visible = true;
            Failure.Visible = false;
            try
            {
                //Response.Redirect("frmBoilerRenewalApproval.aspx?intApplicationId=" + Session["uid"].ToString().Trim());
                Response.Redirect("frmDrugRenewal.aspx?intApplicationId=" + Session["Applid"].ToString().Trim() + "&next=" + "N");
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.CssClass = "errormsg";
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPoliceattachments_Ren.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmtradeRenewal.aspx?intApplicationId=" + Session["Applid"].ToString().Trim() + "&next=" + "N");
    }

    protected void btnfeesdetails_Click(object sender, EventArgs e)
    {
        if (txttinNo.Text != "")
        {
            trtradelicence.Visible = true;
            trtradeduedate.Visible = true;
            trtradecode.Visible = true;
        }
    }

    void FillDetails()
    {
        DataSet dsdept = new DataSet();
        dsdept =objtrade.Getdata_TradeRenewalDetails(Session["Applid"].ToString(),Session["uid"].ToString().Trim(),"I");
        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
        {
            trtradelicence.Visible = true;
            trtradeduedate.Visible = true;
            trtradecode.Visible = true;
            txttradeaddress.Text = dsdept.Tables[0].Rows[0]["TradeAddress"].ToString();
            txtagc.Text = dsdept.Tables[0].Rows[0]["ArrearGarbageCharges"].ToString();
            txtarreasfees.Text = dsdept.Tables[0].Rows[0]["ArrearsAmountLicence"].ToString();
            txtlicencesfeeinterst.Text = dsdept.Tables[0].Rows[0]["ArrearsAmountLicenseinterest"].ToString();
            //tradevo.CategoryID = "1" = dsdept.Tables[0].Rows[0][""].ToString();
            txtCatogory.Text = dsdept.Tables[0].Rows[0]["CategoryName"].ToString();

            Txtcgc.Text = dsdept.Tables[0].Rows[0]["CurrentGarbageCharges"].ToString();
            txtcurrlience.Text = dsdept.Tables[0].Rows[0]["CurrentLicenceFee"].ToString();
            txtclfi.Text = dsdept.Tables[0].Rows[0]["CurrentLicenceFeeInterest"].ToString();

            txtownername.Text = dsdept.Tables[0].Rows[0]["NameofOwner"].ToString();
            Txtplinth.Text = dsdept.Tables[0].Rows[0]["PlinthArea"].ToString();

            txtroadtype.Text = dsdept.Tables[0].Rows[0]["RoadTypeName"].ToString();
            Txtsubcatogory.Text = dsdept.Tables[0].Rows[0]["SubCategory"].ToString();

            txttitletrade.Text = dsdept.Tables[0].Rows[0]["TitleOfTrade"].ToString();
            Txttotalamount.Text = dsdept.Tables[0].Rows[0]["TotalAmount"].ToString();
            txttradeaddress.Text = dsdept.Tables[0].Rows[0]["AddressofOwner"].ToString();
            txttinNo.Text = dsdept.Tables[0].Rows[0]["TradeTinno"].ToString();
        }
    }
}