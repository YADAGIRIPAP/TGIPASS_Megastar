using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_Tourismevent_ApplicationTrakerDetailed : System.Web.UI.Page
{
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1;
    #region Declaration
    General Gen = new General();
    int Sno = 0;
    DataSet ds;
    DataTable dt;
    DataSet dslist;

    Cls_TourismDashboard obj_dashboard = new Cls_TourismDashboard();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack) 
            {

                DataSet dscheck = new DataSet();
                if (Request.QueryString.Count > 0)
                {
                    dscheck = obj_dashboard.tourismevent_GetApplicationTrackerDetailed(Request.QueryString[0].ToString().Trim());
                }
                else
                {
                    dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                    if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
                    {
                        Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                        dscheck = obj_dashboard.tourismevent_GetApplicationTrackerDetailed(dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim());
                    }
                    else
                    {
                        Response.Redirect("frmQuesstionniareReg.aspx");
                    }
                }

                if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                    Session["intCFEEnterpid"] = dscheck.Tables[3].Rows[0]["intCFEEnterpid"].ToString().Trim();
                }
                else
                {
                    Session["Applid"] = "0";
                    Session["intCFEEnterpid"] = dscheck.Tables[3].Rows[0]["intCFEEnterpid"].ToString().Trim();
                }

                ds = Gen.GetApplicationTrackerDetailed2(Session["Applid"].ToString());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    lblUID.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
                    labUidNumber.Attributes["href"] = "CFEPrint.aspx?intApplid=" + Session["intCFEEnterpid"].ToString();
                    HyperLinkSubsidy.NavigateUrl = "frmViewAttachmentDetails.aspx?intApplicationId=" + ds.Tables[0].Rows[0]["INTCFEENTERPID"].ToString();
                    labNameandAddress.Text = ds.Tables[0].Rows[0]["Name of the Industry"].ToString();
                    labLineofActivity.Text = ds.Tables[0].Rows[0]["Line of Activity"].ToString();
                    lblSector.Text = ds.Tables[0].Rows[0]["Sector"].ToString();
                    lblDistrict.Text = ds.Tables[0].Rows[0]["District_Name"].ToString();

                    labDOA.Text = ds.Tables[0].Rows[0]["Date of Application of  industry"].ToString();
                    labCategoryofIndustry.Text = ds.Tables[0].Rows[0]["CategoryOfIndustry"].ToString();
                    labTotalInvestment.Text = ds.Tables[0].Rows[0]["Investment"].ToString() + " Crore "; //+ ds.Tables[0].Rows[0]["CurrencyType"].ToString();
                    labNameandAddress0.Text = ds.Tables[0].Rows[0]["PropAddress"].ToString();
                    lblpolution.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    lblEmploymenttot.Text = ds.Tables[0].Rows[0]["Employment"].ToString();


                    if (Session["username"].ToString() == "KCSBabu" || Session["username"].ToString() == "cmsnikhil")  //new nikhil
                    {
                        hprcoipaynetdtls.NavigateUrl = "RptPaymentDetails.aspx?intApplicationId=" + lblUID.Text.ToString() + "";
                    }
                    else
                    {
                        hprcoipaynetdtls.NavigateUrl = "TrackerDtls.aspx?intQuessionaireid=" + ds.Tables[0].Rows[0]["intQuessionaireid"].ToString() + "&intStageid=2&intApprovalid=33";
                    }


                    if (ds.Tables[0].Rows[0]["Consolidatecert"].ToString() != "")
                    {
                        trcoicertificate.Visible = true;
                        HyperLinkcoi.Target = "_blank";

                        HyperLinkcoi.NavigateUrl = ds.Tables[0].Rows[0]["Consolidatecert"].ToString();
                    }
                }
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg.Text = ex.Message;

        }
    }


    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Statusid = DataBinder.Eval(e.Row.DataItem, "intStageid").ToString();
                if (Statusid != "")
                {
                    int Statusidnew = Convert.ToInt32(Statusid);
                    if (Statusidnew == 13 || Statusidnew == 14 || Statusidnew == 15 || Statusidnew == 16 || Statusidnew == 22 || Statusidnew == 11)
                    {
                        e.Row.FindControl("lblverified").Visible = false;
                        e.Row.FindControl("HyperLinkSubsidy").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lblverified").Visible = true;
                        e.Row.FindControl("HyperLinkSubsidy").Visible = false;
                    }
                    if (((HyperLink)e.Row.FindControl("HyperLinkSubsidy")).NavigateUrl == "")
                    {
                        e.Row.FindControl("lblverified").Visible = true;
                        e.Row.FindControl("HyperLinkSubsidy").Visible = false;
                    }
                    if (((HyperLink)e.Row.FindControl("hplpscstataus")).NavigateUrl == "")
                    {
                        e.Row.FindControl("lblpscstataus").Visible = true;
                        e.Row.FindControl("hplpscstataus").Visible = false;
                    }
                    if (((HyperLink)e.Row.FindControl("hplCheckAppeal")).NavigateUrl == "")
                    {
                        e.Row.FindControl("hplCheckAppeal").Visible = false;

                    }
                }
                if ((Session["uid"].ToString() == "1222" || Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "3377"))
                {
                    string intApprovalid = DataBinder.Eval(e.Row.DataItem, "intApprovalid").ToString();
                    if ((intApprovalid == "6" || intApprovalid == "45") && Statusid != "22" && Statusid != "2" && Statusid != "1")
                    {
                        e.Row.FindControl("lblapprovalname").Visible = false;
                        e.Row.FindControl("hplkapprovalsname").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lblapprovalname").Visible = true;
                        e.Row.FindControl("hplkapprovalsname").Visible = false;
                    }
                }
                else
                {
                    e.Row.FindControl("lblapprovalname").Visible = true;
                    e.Row.FindControl("hplkapprovalsname").Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg.Text = ex.Message;

        }

    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


                TableCell HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "";
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "";
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);
                HeaderCell = new TableCell();



                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "";
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "";
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 4;
                HeaderCell.RowSpan = 1;
                HeaderCell.Font.Bold = true;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "Prescrutiny Status";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                //HeaderCell.Text = "Additions";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                //HeaderCell.Text = "Additions";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.RowSpan = 1;
                HeaderCell.Font.Bold = true;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "Approval Stage";
                HeaderCell.Visible = true;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);

                grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg.Text = ex.Message;

        }
    }


}