using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic;

public partial class UI_TSiPASS_IncentiveSingleUploadsNew : System.Web.UI.Page
{
    comFunctions objCmf = new comFunctions();
    BusinessLogic.DML objDml = new BusinessLogic.DML();
    BusinessLogic.Fetch objFetch = new BusinessLogic.Fetch();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                if (Session["dtIncentiveTypes"] != null)
                {
                    DataTable dtInctypes = new DataTable();
                    DataTable dt = new DataTable();
                    DataTable dtUploads = new DataTable();

                    btnNext.Visible = btnPrevious.Visible = false;

                    dtInctypes = objFetch.FetchIncentiveTypes();
                    dt = (Session["dtIncentiveTypes"] as DataTable);

                    if (Request.QueryString.Count > 0 && Request.QueryString["q"] != null)
                    {
                        //dtUploads = objFetch.FetchIncentiveUploads(Convert.ToInt32(Session["EntprIncentive"].ToString()), Convert.ToInt32(Request.QueryString["q"]));

                        int str = Convert.ToInt32(Request.QueryString["q"]);
                        dtUploads = objFetch.FetchIncentiveUploadsNewINCType(Convert.ToInt32(Session["EntprIncentive"].ToString()), Convert.ToInt32(Request.QueryString["q"]));

                        lblIncHeaderType.Text = lblIncentivetype.Text = dtInctypes.AsEnumerable()
                                                                                  .Where(r => r.Field<int>("ID") == Convert.ToInt32(Request.QueryString["q"].ToString()))
                                                                                  .CopyToDataTable().Rows[0][1].ToString();

                        objCmf.FillGrid(dtUploads, grdChecklistsDocument, true);
                        //lblIncTitle.Text = dtUploads.Rows[0]["IncentiveName"].ToString();
                        string q = Request.QueryString["q"].ToString().Trim();
                        if (dt.Rows[0][0].ToString().Trim() == Request.QueryString["q"].ToString().Trim())
                        {
                            btnPrevious.Visible = true;
                            btnPrevious.PostBackUrl = "../../UI/Tsipass/TypeOfIncentivesNew.aspx";
                            if (dt.Rows.Count > 1)
                            {
                                //btnNext.PostBackUrl = "../../UI/Tsipass/InscentiveViewNew.aspx?q=" + dt.Rows[1][0];    // commented on 22.06.2017
                                btnNext.PostBackUrl = "../../UI/Tsipass/IncetivesDraft.aspx?q=" + dt.Rows[1][0];
                                btnNext.Visible = true;
                                //btnsave.Enabled = false;
                            }
                            else
                            {
                                btnsave.Enabled = true;
                            }
                        }
                        else
                        {
                            if (dt.Rows.Count > 1)
                            {
                                for (int i = 1; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i][0].ToString().Trim() == Request.QueryString["q"].ToString().Trim())
                                    {
                                        btnPrevious.Visible = true;
                                        btnPrevious.PostBackUrl = "../../UI/Tsipass/TypeOfIncentivesNew.aspx?q=" + dt.Rows[i - 1][0].ToString();
                                        btnNext.Visible = false;
                                        if (dt.Rows.Count > i + 1)
                                        {
                                            btnNext.PostBackUrl = "../../UI/Tsipass/InscentiveViewNew.aspx?q=" + dt.Rows[i + 1][0].ToString();
                                            btnNext.Visible = true;
                                            btnsave.Enabled = false;
                                        }
                                        else
                                        {
                                            btnsave.Enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //DataSet ds = new DataSet();
                //btnNext.Visible = false;
                //if (Request.QueryString.Count > 0 && Request.QueryString["q"] != null)
                //{
                //    //ds = objFetch.FetchIncentiveUploads(Convert.ToInt32(Session["EntprIncentive"].ToString()), Convert.ToInt32(Request.QueryString["q"]));
                //    if (Convert.ToInt32(Request.QueryString["q"]) == 1)
                //    {
                //        btnPrevious.Visible = true;
                //        lblIncHeaderType.Text = lblIncentivetype.Text = @"One time Incentive Uploads";
                //        btnPrevious.PostBackUrl = "~/TypeOfIncentives.aspx";
                //        btnNext.PostBackUrl = "~/IncentiveSingleUploads.aspx?q=0";
                //        //btnNext.Visible = (ds!=null && ds.Tables[0].Rows.Count == 0);
                //        btnNext.Visible = true;
                //    }
                //    else
                //    {
                //        btnPrevious.Visible = true;
                //        btnPrevious.PostBackUrl = "~/IncentiveSingleUploads.aspx?q=1";
                //        lblIncHeaderType.Text = lblIncentivetype.Text = "Regular Uploads";
                //    }
                //}
                //else
                //{
                //    ds = null;
                //}
                //if (ds == null) objCmf.FillGrid(null, grdChecklistsDocument, true); else objCmf.FillGrid(ds.Tables[0], grdChecklistsDocument, true);
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Failure.Visible = success.Visible = false;
            bool isValid = true;
            foreach (GridViewRow gr in grdChecklistsDocument.Rows)
                if ((gr.FindControl("lblAttachedFileName") as Label).Text.Trim() == ""
                        && (gr.FindControl("lblisMandatoryDoc") as Label).Text.Trim().ToLower() == "yes")
                {
                    isValid = false;
                    Failure.Visible = true;
                    lblmsg0.Text = "Please upload Mandatory Document(s).";
                    gr.BackColor = System.Drawing.Color.Pink;
                }
            if (isValid)
            {
                //if (Request.QueryString["q"].ToString() == "1")
                //{
                btnNext.Visible = true;
                //    btnNext.PostBackUrl = "~/InscentiveViewNew.aspx?q=0";
                //    success.Visible = true;
                //}
                //else if (btnNext.Visible == true)
                //{
                //    Response.Redirect(btnNext.PostBackUrl, false);
                //}
                //else
                //{
                //    //btnNext.Visible = Visible = 
                grdChecklistsDocument.Visible = false;
                btnsave.Enabled = false;
                //    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Documents uploaded successfully');", true);
                Session["EmUdyog"] = null;
                //    //Response.Redirect("../../UI/Tsipass/InscentiveViewNew.aspx", false);
                //}
                success.Visible = true;
                lblmsg.Text = "Incentive applied successfully.";
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        try { Response.Redirect(btnPrevious.PostBackUrl, false); }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            //btnNext.PostBackUrl = "";
            Response.Redirect(btnNext.PostBackUrl, false);
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }

    protected void grdChecklistsDocument_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gr = grdChecklistsDocument.Rows[Convert.ToInt32(e.CommandArgument.ToString())];
            FileUpload fp = (gr.FindControl("fuDocuments") as FileUpload);
            if (fp.HasFile && fp.FileBytes.Length > 0)
            {
                if (fp.PostedFile.ContentLength > 30000000)
                {
                    Failure.Visible = true;
                    lblmsg0.Text = " Please ensure that uploaded file size is Less than 30MB.";
                    return;
                }
                string path = Server.MapPath("") + "\\IncentivesAttachments\\" + Session["EntprIncentive"].ToString();
                if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
                fp.SaveAs(path + "\\" + fp.FileName);

                objDml.InsUpdDeltd_Incentive_UploadsNew(Convert.ToInt32(Session["EntprIncentive"].ToString()),
                                                        Convert.ToInt32((gr.FindControl("lblIncentiveID") as Label).Text),
                                                        Convert.ToInt32((gr.FindControl("lblattachmentID") as Label).Text),
                                                        fp.FileName,
                                                        path + "\\" + fp.FileName,
                                                        Convert.ToInt32(Session["uid"].ToString())
                                                    );
                (gr.FindControl("lblAttachedFileName") as Label).Text = fp.FileName;
                (gr.FindControl("lhl") as HyperLink).Text = fp.FileName;
                (gr.FindControl("lhl") as HyperLink).NavigateUrl = "https://ipass.telangana.gov.in/IncentivesAttachments/" + Session["EntprIncentive"].ToString() + "/" + fp.FileName;
                (gr.FindControl("lhl") as HyperLink).Target = "_blank";
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }
}