using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class UI_TSiPASS_ProformaSactionLetter : System.Web.UI.Page
{
    General Gen = new General();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    string inctiveID = "";

    DataSet dsCAF = new DataSet();
    string ApplClm = "";
    string consUnit = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (Session["uid"] != null)
        {
            if (Request.QueryString.Count > 0 && Request.QueryString["incentiveid"] != null)
            {
                string userid = Session["uid"].ToString();
                string incentiveid = "";
                incentiveid = Request.QueryString["incentiveid"].ToString();

                //DataSet ds2 = new DataSet();
                //ds2 = Gen.GetBasicUnitDetails(incentiveid);
                //binddata(ds2);

                string IncIDfrData = "1090";  //for testing

                DataSet ds = new DataSet();
                ds = Gen.GetIncentiveDeptDetails(IncIDfrData);
                // FillDetails(ds);

                DataSet dsInsp = new DataSet();
                dsInsp = Gen.GetIncentiveDeptDetails_InspReprt(IncIDfrData);
                // FillDetailsInsp(dsInsp);
                binddata(dsInsp);

            }

        }

    }
    #region getDetailsofInspReport
    public void getDetailsofInspReport()
    {
        DataSet ds;
        string IncentiveId = Request.QueryString["IncentiveId"].ToString();
        try
        {
            ds = Gen.GetIncentiveDeptDetails(IncentiveId);
            FillDetails(ds);

        }
        catch
        {

        }
    }
    #endregion

    public void FillDetails(DataSet ds)
    {
        string IncentID = "";
        DataSet oDataSet = new DataSet();
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //divCommonAppli.Visible = true;
                //IncentID = ds.Tables[0].Rows[0]["IncentveID"].ToString();

                // txtUnitname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();                

                string UnitDistName = ds.Tables[0].Rows[0]["UnitDistName"].ToString();
                // ddlConstOfUnit.Visible = false;
                string UNITMANDAL = ds.Tables[1].Rows[0]["UNITMANDAL"].ToString();
                string UNITVILLAGE = ds.Tables[1].Rows[0]["UNITVILLAGE"].ToString(); ;
                string UnitHNO = ds.Tables[1].Rows[0]["UnitHNO"].ToString();
                string UnitStreet = ds.Tables[1].Rows[0]["UnitStreet"].ToString();
                string str = ds.Tables[0].Rows[1]["IdsustryStatus"].ToString();
                ApplClm = ds.Tables[1].Rows[0]["created_dt"].ToString();
                //    txtRcptAppln.Text = (Convert.ToDateTime(ds.Tables[0].Rows[0]["created_dt"]).ToShortDateString());              

                string IncIDfrData = "1090";

            }

        }
    }

    //return IncentID;

    public void FillDetailsInsp(DataSet ds)
    {
        try
        {
            DataSet oDataSet = new DataSet();
            string IncIDfrData = "1090";

            oDataSet = Gen.GETINCENTIVESCAFDATA_INSP_Report(IncIDfrData);
            ds = Gen.GETINCENTIVESCAFDATA_INSP(IncIDfrData);

            //gvLOA.Visible = true;
            //gvLOA.DataSource = ds.Tables[1];
            //gvLOA.DataBind();
            //lblDCP.Text = oDataSet.Tables[0].Rows[0]["DCP"].ToString();
            //txtRcptAppln.Text = oDataSet.Tables[0].Rows[0]["ApplClm"].ToString();
            //txtDateShrtfall.Text = oDataSet.Tables[0].Rows[0]["DateShrtfall"].ToString();
            //txtDtShrtFallRcvd.Text = oDataSet.Tables[0].Rows[0]["DtShrtFallRcvd"].ToString();         



            //txtTotCstCmptdLand.Text = oDataSet.Tables[0].Rows[0]["totCstCmptdLand"].ToString();
            //txtTotCstCmptdBldg.Text = oDataSet.Tables[0].Rows[0]["TotCstCmptdBldg"].ToString();
            //txtTotCstCmptdPlntMach.Text = oDataSet.Tables[0].Rows[0]["TotCstCmptdPlntMach"].ToString();
            //txtTotCstCmptdTotal.Text = oDataSet.Tables[0].Rows[0]["TotCstCmptdTotal"].ToString();

            //txtInvSubsidyVal.Text = oDataSet.Tables[0].Rows[0]["InvSubsidyVal"].ToString();
            //txtAddnInvSubsdyWmn.Text = oDataSet.Tables[0].Rows[0]["addnInvSubsdyWmn"].ToString();
            //txtInvSubsdySCST.Text = oDataSet.Tables[0].Rows[0]["invSubsdySCS"].ToString();
            //txtAddnInvSbsdySc10Prcnt.Text = oDataSet.Tables[0].Rows[0]["addnInvSbsdySc10Prcnt"].ToString();
            ////txtTotalInv.Text= oDataSet.Tables[0].Rows[0]["TotInv"].ToString();

            //txtInvSubsidyVal.Text = oDataSet.Tables[0].Rows[0]["investmentSubs"].ToString();
            //txtPower.Text = oDataSet.Tables[0].Rows[0]["Powerr"].ToString();



        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void binddata(DataSet ds)
    {
        
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != "" || ds.Tables[1].Rows[0]["TIDEAflag"].ToString() != null)
            {
                if (ds.Tables[1].Rows[0]["TIDEAflag"].ToString() == "Y")
                {
                    lblTIdeaTPride1.Text = "T-IDEA";
                    lblTIDEATPRIDE.Text = "T-IDEA";
                }
            }
        if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() != "" || ds.Tables[1].Rows[0]["TSCPflag"].ToString() != null)
        {

            if (ds.Tables[1].Rows[0]["TSCPflag"].ToString() == "Y")
            {
                lblTIdeaTPride1.Text = "T-PRIDE(TSCP)";
                  lblTIDEATPRIDE.Text = "T-PRIDE(TSCP)";
            }
        }
        if (ds.Tables[1].Rows[0]["TSPflag"].ToString() != "" || ds.Tables[1].Rows[0]["TSPflag"].ToString() != null)
        {
            if (ds.Tables[1].Rows[0]["TSPflag"].ToString() == "Y")
            {
                lblTIdeaTPride1.Text = "T-PRIDE(TSP)";
                lblTIDEATPRIDE.Text = "T-PRIDE(TSP)";
            }
        }


        lblLetterNo.Text = "COI/" + ds.Tables[1].Rows[0]["EMiUdyogAadhar"].ToString();
       
        if (ds.Tables[1].Rows[0]["todaydate"].ToString() != null || ds.Tables[1].Rows[0]["todaydate"].ToString() != "")
        {
            lblLetterDate.Text = ds.Tables[1].Rows[0]["todaydate"].ToString();
        }
        if (ds.Tables[1].Rows[0]["ApplicationDate"].ToString() != null || ds.Tables[1].Rows[0]["ApplicationDate"].ToString() != "")
        {
           // lblDICMeetingDate.Text = ds.Tables[1].Rows[0]["ApplicationDate"].ToString();
        }
        if (ds.Tables[1].Rows[0]["UnitDtls"].ToString() != null || ds.Tables[1].Rows[0]["UnitDtls"].ToString() != "")
        {
            lblEnterpreneurDetails1.Text = ds.Tables[1].Rows[0]["UnitDtls"].ToString();
        }       

        

        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
        {
            //lblAmountSanc.Text = ds.Tables[2].Rows[0]["IntrestPaid"].ToString();
            //lblIncentiveType1.Text = ds.Tables[2].Rows[0]["IntrestPaid"].ToString();           


        }
    }

}