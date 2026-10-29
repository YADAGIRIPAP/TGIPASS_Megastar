using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_ReleaseProcedingsStep2CompletedListPrintDrill : System.Web.UI.Page
{
    General gen = new General();
    string linkfile = "";
    int lastRowIndex = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Cast = Request.QueryString[0].ToString();
        string IncentiveType = Request.QueryString[1].ToString();
        string GONO = Request.QueryString[2].ToString();
        string SubIncType = Request.QueryString[3].ToString();
        h1heading.InnerHtml = Cast + " Category";

        DataSet ds = new DataSet();
        ds = gen.GET_AMOUNTALLOTEDLIST_ON_GONUMBER_CASTEWISE_INCENTIVEWISE(Cast, IncentiveType, GONO, SubIncType);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            linkfile = ds.Tables[0].Rows[0]["LinkFile"].ToString();
            tdinvestments.InnerHtml = "--> " + ds.Tables[0].Rows[0]["IncentiveName"].ToString();
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            if (linkfile != "")
            {
                grdDetails.Columns[10].Visible = true;
            }

         //   lblremaingAmount.Text = ds.Tables[1].Rows[0]["RemainingAmount"].ToString();
         //if (linkfile != "")
         //{
         //    foreach (GridViewRow grv in grdDetails.Rows)
         //    {
         //        if (grv.RowType == DataControlRowType.DataRow)
         //        {
         //            if (grv.RowIndex > lastRowIndex)
         //            {
         //                //getting the last data row index
         //                lastRowIndex = grv.RowIndex;                            
         //            }
         //        }
         //    }
         //    //dgTest.Rows[lastRowIndex].CssClass = "lastRowClass";


                //    grdDetails.Rows[lastRowIndex].Cells[7].FindControl("lnkFile").Visible = false;
                //}



        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lbl = (e.Row.FindControl("lbl") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("lnkFile") as HyperLink);
                if (HyperLinkSubsidy.Text != "")
                {
                    //grdDetails.Rows[lastRowIndex].Cells[7].FindControl("lnkFile").Visible = tr;
                    string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LinkFile"));
                    if (filepathnew != "")
                    {
                        string encpassword = gen.Encrypt(filepathnew, "SYSTIME");
                        HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    }
                    else
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lbl.Text = ex.Message;
            //Failure.Visible = true;
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }      
    }
}