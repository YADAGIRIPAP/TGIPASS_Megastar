using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class UI_TSiPASS_IPORptCommonDraft : System.Web.UI.Page
{
    IncentiveVosIncetForms objvoA = new IncentiveVosIncetForms();
    General Gen = new General();
    BusinessLogic.DML objDml = new BusinessLogic.DML();
    DataSet ds = new DataSet();

    string IncentiveId = "";
    string MstIncentiveId = "";
    string createdby = "";
    string subsidytype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //IncentiveId = "12345";
        //createdby = "5050";
        //MstIncentiveId = "1";

        try
        {
            if (Session["uid"] != null)
            {
                createdby = Session["uid"].ToString();
                if (Request.QueryString[0] != null)
                {
                    IncentiveId = Request.QueryString[0];
                }
                if (Request.QueryString[0] != null)
                {
                    MstIncentiveId = Request.QueryString[1];
                }
                DataSet ds = new DataSet();
                ds = Gen.GetIPORecommendationOfficerDetails(IncentiveId, MstIncentiveId, createdby);
                string strscheme = ds.Tables[0].Rows[0]["Scheme"].ToString();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["UnitName"].ToString() != null)
                    {
                        lblunitname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["applicationno"].ToString() != null)
                    {
                        lblapplicantno.Text = ds.Tables[0].Rows[0]["applicationno"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["ApplciantName"].ToString() != null)
                    {
                        lblapplicantname.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                    }

                    if (ds.Tables[0].Rows[0]["IncentiveName"].ToString() != null)
                    {
                        lblsubsidytype.Text = ds.Tables[0].Rows[0]["IncentiveName"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["AmountPaid"].ToString() != null)
                    {
                        lblamountclamed.Text = ds.Tables[0].Rows[0]["AmountPaid"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Inspection_RecommAmnt"].ToString() != null)
                    {
                        lblamountrecommended.Text = ds.Tables[0].Rows[0]["Inspection_RecommAmnt"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Remarks"].ToString() != null)
                    {
                        lblremarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["IsDlcOrSlc"].ToString() != null)
                    {
                        lblslcdlc.Text = ds.Tables[0].Rows[0]["IsDlcOrSlc"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["EmpName"].ToString() != null)
                    {
                        lblName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString() + "</br>" + ds.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + ds.Tables[0].Rows[0]["Dist"].ToString();
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (strscheme == "IIPP 2005-10" || strscheme == "IIPP 2010-15")
                        {
                            lblheadTPRIDE.Text = "<center>" + strscheme.ToString() + "</center>";
                            lblSchemesCheck.Text = strscheme.ToString();

                        }
                        else if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y") //   if (caste == "3" || caste == "4")   //SC, ST
                        {
                            lblheadTPRIDE.Text = "<center>T-PRIDE (TSCP)</center>";
                            lblSchemesCheck.Text = "T-PRIDE";
                        }
                        else if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                        {
                            lblheadTPRIDE.Text = "<center>T-PRIDE (TSP)</center>";
                            lblSchemesCheck.Text = "T-PRIDE";
                        }
                        else if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                        {
                            lblheadTPRIDE.Text = "<center>T-IDEA</center>";
                            lblSchemesCheck.Text = "T-IDEA";
                        }

                        if (ds.Tables[0].Rows[0]["claimedfinyear"].ToString() != null && ds.Tables[0].Rows[0]["claimedfinyear"].ToString() != "")
                        {
                            lblclaimedfinyeardtls.Text = ds.Tables[0].Rows[0]["claimedfinyear"].ToString();
                            trfinyear.Visible = true;
                        }
                        else
                        {
                            trfinyear.Visible = false;
                        }
                    }
                    if (ds.Tables[0].Rows[0]["MSME_Applied"].ToString() == "Y")
                    {

                        lblheadTPRIDE.Text = lblheadTPRIDE.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");
                        lblSchemesCheck.Text = lblSchemesCheck.Text.Replace("T-PRIDE", "MSME-2024 ").Replace("T-IDEA", "MSME-2024 ");


                    }

                }


                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {

                    GridView3att.DataSource = ds.Tables[1];
                    GridView3att.DataBind();
                    trinspattach.Visible = true;
                    trinspattachgrid.Visible = true;

                }


            }
        }
        catch (Exception ex)
        {
            lblerrormsg.Text = ex.Message;
        }
    }


    protected void GridView3att_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (e.Row.FindControl("lbl") as Label);
            HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
            //Label lblAttachmentName = (e.Row.FindControl("lbl") as Label);
            //HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
            //Label enterid = (e.Row.FindControl("lblverified") as Label);
            if (lbl.Text != "")
            {
                string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                if (filepathnew != "")
                {
                    string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                    HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                }
                else
                {
                    HyperLinkSubsidy.Visible = false;
                }
            }

            if (lbl.Text == "")
            {
                //e.Row.Cells[1].ColumnSpan = 2;
                //e.Row.Cells.RemoveAt(2);
                HyperLinkSubsidy.Visible = false;
                e.Row.Font.Bold = true;
            }
            if (HyperLinkSubsidy.NavigateUrl == "")
            {
                HyperLinkSubsidy.Visible = false;
            }

        }
    }
}