using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_ProformaQueryRaiseShortFallLetterGMtoApplicantApproval : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["uid"] != null)
            {
                if (Request.QueryString.Count > 0 && Request.QueryString["incentiveid"] != null)
                {
                    string userid = Session["uid"].ToString();
                    string incentiveid = "";
                    string mstincentiveid = "";
                    incentiveid = Request.QueryString["incentiveid"].ToString();
                    if (Request.QueryString.Count > 1 && Request.QueryString[1] != null)
                    {
                        mstincentiveid = Request.QueryString["MstIncentiveId"].ToString();
                    }

                    DataSet ds = new DataSet();
                    ds = Gen.GetBasicUnitDetails(incentiveid);
                    binddata(ds);

                    DataSet dsname = new DataSet();
                    //dsname = Gen.GetIPORecommendationOfficerDetailsDIC(incentiveid, "6", "");
                    //if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
                    //{
                    //    if (dsname.Tables[0].Rows[0]["GMName"].ToString() != null)
                    //    {
                    //        lblName.Text = dsname.Tables[0].Rows[0]["GMName"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["GMDesignation"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["Dist"].ToString();
                    //        lblletterFrom.Text = dsname.Tables[0].Rows[0]["Dist"].ToString();
                    //    }
                    //}

                    dsname = Gen.GetIncentiveOfficerNamesForAll(incentiveid, mstincentiveid, userid, "", "GMQUERYAFTERINSPECTION");
                    if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
                    {
                        if (dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() != null)
                        {
                            lblName.Text = dsname.Tables[0].Rows[0]["GMNamerecom"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["Designation"].ToString() + "</br> DIC-" + dsname.Tables[0].Rows[0]["WorkingDistrict"].ToString();
                            lblletterFrom.Text = dsname.Tables[0].Rows[0]["WorkingDistrict"].ToString();
                        }
                    }
                }
            }
        }
    }

    public void binddata(DataSet ds)
    {
        if (ds.Tables[0].Rows[0]["Scheme"].ToString() != null || ds.Tables[0].Rows[0]["Scheme"].ToString() != "")
        {
            lblTIdeaTPride.Text = ds.Tables[0].Rows[0]["Scheme"].ToString();
        }
        // added on 17.02.2018 by chh
        if ((ds.Tables[0].Rows[0]["Scheme"].ToString()).Contains("IDEA"))
        {
            if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" || ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
            {
                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                {
                    lblTIdeaTPride.Text = "T-IDEA";
                }
            }
            if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
            {

                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                {
                    lblTIdeaTPride.Text = "T-PRIDE(TSCP)";

                }
            }
            if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
            {
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                {
                    lblTIdeaTPride.Text = "T-PRIDE(TSP)";
                }
            }
            if (ds.Tables[0].Rows[0]["MSME_Applied"].ToString() == "Y")
            {

                lblTIdeaTPride.Text = lblTIdeaTPride.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");


            }
        }


        if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null || ds.Tables[0].Rows[0]["unitdistrict"].ToString() != "")
        {
            lblEntDist.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            lblEntDist1.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
            lblhead2.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
        }
        lblRefLetterDate.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
        lblLetterNo.Text = "DIC/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();

      //  lblRefLetterNo.Text = "DIC/" + Request.QueryString["incentiveid"].ToString();

        if (ds.Tables[0].Rows[0]["applicationno"].ToString() != null && ds.Tables[0].Rows[0]["applicationno"].ToString() != "")
        {
            lblRefLetterNo.Text = ds.Tables[0].Rows[0]["applicationno"].ToString();
        }

        if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null || ds.Tables[0].Rows[0]["todaydate"].ToString() != "")
        {
            lblLetterDate.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
        }
        if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null || ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
        {
            lblEnterpreneurDetails.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
        }
        lblEnterpreneurDetails1.Text = "Sri. " + ds.Tables[0].Rows[0]["ApplciantName"].ToString() + ",<br/>" + ds.Tables[0].Rows[0]["UnitDtls"].ToString() + ",<br/>" + lblEntDist1.Text + " District";
        string incentiveid = "";
        incentiveid = Request.QueryString["incentiveid"].ToString();
        DataSet daquerie = new DataSet();

        string mstincentiveid = "";
        if (Request.QueryString.Count > 1 && Request.QueryString[1] != null && Request.QueryString[1].ToString() != null)
        {
            mstincentiveid = Request.QueryString[1].ToString();
            daquerie = Gen.GetQueryDetailsdeptApproval(Session["uid"].ToString(), incentiveid, mstincentiveid, "S");
        }
        else
        {
            daquerie = Gen.GetQueryDetailsdeptApproval(Session["uid"].ToString(), "", "", "ALL");
        }

       

        if (daquerie != null && daquerie.Tables.Count > 0 && daquerie.Tables[0].Rows.Count > 0)
        {
            if (mstincentiveid != "0" && mstincentiveid != "")
            {
                DataTable dt = FilterDataTableBasedOnIncentiveIds(daquerie, mstincentiveid, 0, "MstIncentiveId");
                daquerie.Tables.Add(dt);
                gvShortfalls.DataSource = daquerie.Tables["Table"];
                gvShortfalls.DataBind();
                Session["CertificateTb2"] = daquerie.Tables["Table"];
            }
            else
            {
                gvShortfalls.DataSource = daquerie.Tables[0];
                gvShortfalls.DataBind();
                Session["CertificateTb2"] = daquerie.Tables[0];
            }

           
            //gvShortfalls.DataSource = daquerie.Tables[0];
            //gvShortfalls.DataBind();
           
        }
    }

    public DataTable FilterDataTableBasedOnIncentiveIds(DataSet ds, string Incids, int index, string SearchText)
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        dt = ds.Tables[index];
        dt1 = ds.Tables[index].Clone();//IncentiveID
        DataRow[] dw = dt.Select("" + SearchText + " in (" + Incids + ")");
        ds.Tables.RemoveAt(index);
        dt1.Rows.Clear();
        foreach (DataRow dr in dw)
        {
            dt1.ImportRow(dr);
        }
        return dt1;
    }
}