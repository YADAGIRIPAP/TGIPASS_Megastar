using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSIPASS_Default2 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }
        


        if (!IsPostBack)
        {
            if (Session["userlevel"].ToString().Trim() != "2" && Session["userlevel"].ToString().Trim() != "1")   //changed from igolf error 16.1.2019
                Response.Redirect("~/Index.aspx");       
                
           
      
            DataSet ds = new DataSet();
            ds = Gen.GenericFillDs("GetIncentives");
            ddlquantityper.DataSource = ds.Tables[0];
            ddlquantityper.DataTextField = "IncentiveName";//
            ddlquantityper.DataValueField = "IncentiveID";
            ddlquantityper.DataBind();
            ddlquantityper.Items.Insert(0, new ListItem("--Select--", "0"));
            //fillGrid();
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }

    public DataSet Get_Incentive(string Unitname, string Incentive, string ApplicationNO)
    {

        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UnitName",SqlDbType.VarChar),
               new SqlParameter("@Incentive",SqlDbType.VarChar),
               new SqlParameter("@ApplicationNo",SqlDbType.VarChar),
           };

            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = (Unitname == "") ? "%" : "%" + Unitname.ToString() + "%";
            pp[1].Value = (Incentive == "") ? "%" : "%" + Incentive + "%";
            pp[2].Value = (ApplicationNO == "") ? "%" : "%" + ApplicationNO + "%";

            //if(Session["uid"].ToString()== "34668" || Session["uid"].ToString() == "103827" || Session["uid"].ToString() == "34670" || Session["uid"].ToString() == "77233" || Session["uid"].ToString() == "194556"|| Session["uid"].ToString() =="200451" )
            Dsnew = Gen.GenericFillDs("[INCENTIVES_APPLICATION_TRACKER_I_Test2403]", pp);

         //else
         //       Dsnew = Gen.GenericFillDs("[INCENTIVES_APPLICATION_TRACKER_I_Test2403]", pp);
         //   //Dsnew = Gen.GenericFillDs("[INCENTIVES_APPLICATION_TRACKER_I]", pp);

             


        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        return Dsnew;
    }

    void fillGrid()
    {
        try
        {
            #region comment


            //DataSet dsn = new DataSet();


            //// dsn = Gen.GetApplicationTracker(txtnameofUnit.Text, txtUID.Text,ddlquantityper.SelectedValue.ToString());
            //dsn = Getchildandparentdata(txtnameofUnit.Text.TrimStart().TrimEnd(), txtUID.Text.TrimStart().TrimEnd(), ddlquantityper.SelectedValue.ToString());
            //if (ddlquantityper.SelectedValue.ToString() == "CFE")
            //{

            //    if (dsn.Tables[0].Rows.Count > 0)
            //    {

            //        grdDetails.DataSource = dsn.Tables[0];
            //        grdDetails.DataBind();
            //        grdDetails0.Visible = false;
            //        grdDetails0.DataSource = null;
            //        grdDetails0.DataBind();
            //    }
            //    else
            //    {
            //        lblrecords.Text = "NO RECORD TO DISPLAY";
            //        grdDetails.DataSource = null;
            //        grdDetails.DataBind();
            //    }
            //}
            //else if (ddlquantityper.SelectedValue.ToString() == "CFO")
            //{


            //    if (dsn.Tables[0].Rows.Count > 0)
            //    {

            //        grdDetails0.DataSource = dsn.Tables[0];
            //        grdDetails0.DataBind();
            //        grdDetails.Visible = false;
            //        grdDetails.DataSource = null;
            //        grdDetails.DataBind();
            //    }
            //    else
            //    {
            //        lblrecords.Text = "NO RECORD TO DISPLAY";
            //        grdDetails0.DataSource = null;
            //        grdDetails0.DataBind();
            //    }


            //}
            #endregion
            grdDetails.Visible = true;
            DataSet dspay = new DataSet();
            string UnitName = "", Incentive = "", ApplicationNo = "";
            switch (ddlTypeofsearch.SelectedValue.ToString().Trim())
            {
                case "UnitName":
                    UnitName = txtnameofUnit.Text.Trim();
                    break;
                case "ApplicationNo":
                    ApplicationNo = txtnameofUnit.Text.Trim();
                    break;
            }
            if (ddlquantityper.SelectedIndex > 0)
            {
                Incentive = ddlquantityper.SelectedItem.Text.Trim();
            }
            dspay = Get_Incentive(UnitName, Incentive, ApplicationNo);
            //dspay = Gen.GetEnterincetracker(UnitName, Incentive, ApplicationNo);
            //if (dspay.Tables[0].Rows.Count > 0)
            //{
            grdDetails.DataSource = dspay.Tables[0];
            Session["dspay"] = dspay.Tables[0];
            grdDetails.DataBind();
            //}
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }

    public DataSet Getchildandparentdata(string Unitname, string Uid, string Appstype)
    {

        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UnitName",SqlDbType.VarChar),
               new SqlParameter("@UID",SqlDbType.VarChar),
               new SqlParameter("@ApplType",SqlDbType.VarChar),
           };

            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = (Unitname == "") ? "%" : "%" + Unitname.ToString() + "%";
            pp[1].Value = (Uid == "") ? "%" : Uid;
            pp[2].Value = (Appstype == "") ? "%" : Appstype;

            Dsnew = Gen.GenericFillDs("[USP_GET_GetApplicationTracker]", pp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        return Dsnew;
    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            fillGrid();
            //if (txtnameofUnit.Text != "")
            //{
             
            //}
            //else
            //{
            //    lblError.Visible = true;
            //}
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {



    }
    void FillDetails()
    {


    }
    //public void ResetFormControl(Control parent)
    //{
    //    foreach (Control c in parent.Controls)
    //    {
    //        if (c.Controls.Count > 0)
    //        {
    //            ResetFormControl(c);
    //        }
    //        else
    //        {
    //            switch (c.GetType().ToString())
    //            {
    //                case "System.Web.UI.WebControls.TextBox":
    //                    ((TextBox)c).Text = "";
    //                    break;

    //                case "System.Web.UI.WebControls.DropDownList":

    //                    if (((DropDownList)c).Items.Count > 0)
    //                    {
    //                        ((DropDownList)c).SelectedIndex = 0;
    //                    }
    //                    break;
    //            }
    //        }
    //    }
    //}
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        comFunctions cf = new comFunctions();
        cf.ResetFormControl(this);
        grdDetails.Visible = false;
        grdDetails.DataSource = null;
        grdDetails.DataBind();
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getcounties()
    {

    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getPayams()
    {

    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {

        try
        {



        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {

        }

    }

    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {




    }

    protected void BtnClear0_Click1(object sender, EventArgs e)
    {

    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }



    protected void GetNewRectoInsertdr()
    {

    }

    protected void grdDetails_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (Session["uid"].ToString() == "34668" || Session["uid"].ToString() == "103827" || Session["uid"].ToString() == "34670" || Session["uid"].ToString() == "77233" || Session["uid"].ToString() == "194556" || Session["uid"].ToString() == "200451")
                //{

                    grdDetails.Columns[8].Visible = true;
                    grdDetails.Columns[9].Visible = true;
                    int indexing = e.Row.RowIndex;
                    DataTable dtpay = (DataTable)Session["dspay"];


                    LinkButton lnkAutorej = e.Row.FindControl("lnkAutorej") as LinkButton;
                    string autoRej = e.Row.Cells[8].Text.ToString();
                    autoRej = dtpay.Rows[indexing]["autorejecteDate"].ToString();
                    if (autoRej == "" || autoRej == "&nbsp;")
                    {
                        //e.Row.Cells[8].Text = "";
                        lnkAutorej.Visible = false;
                        //grdDetails.Rows[indexing].Cells[9].Controls.Clear();

                    }
                //}
                //else
                //{


                //    grdDetails.Columns[8].Visible = false;
                //    grdDetails.Columns[9].Visible = false;


                //}

            }
            else
            {


                //grdDetails.Columns[8].Visible = false;
                //grdDetails.Columns[9].Visible = false;

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void ddlquantityper_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void grdDetails0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("hypLetter0");
                h2.NavigateUrl = "ApplicationTrakerDetailedCFO.aspx?ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireCFOid"));
                h2.Text = "Click Here";
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {

        //LinkButton lb = (LinkButton)sender;
        //GridViewRow row = (GridViewRow)lb.NamingContainer;
        //if (row != null)
        //{
        //    string name = row.Cells[2].Text.Trim();
        //    Response.Redirect("ApplicantIncentiveDtlsDraftView.aspx?EntrpId=" + name + "&Sts=1");
        //}
        LinkButton lb = (LinkButton)sender;
        GridViewRow row = (GridViewRow)lb.NamingContainer;

        if (row != null)
        {
            string name = row.Cells[2].Text.Trim();
            string url = "ApplicantIncentiveDtlsDraftView.aspx?EntrpId=" + name + "&Sts=1";

            // Open in new tab
            string script = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenNewTab", script, true);
        }
        //string name = ((Label)rown.FindControl("lblCreatedByid")).Text.ToString();
    }
    protected void Unnamed_Click1(object sender, EventArgs e)
    {

        LinkButton lb = (LinkButton)sender;
        GridViewRow row = (GridViewRow)lb.NamingContainer;
        if (row != null)
        {
            string name = row.Cells[2].Text.Trim();
            Response.Redirect("ApplicantIncentiveDtls.aspx?EntrpId=" + name + "&Sts=91");
            //
        }

        //string name = ((Label)rown.FindControl("lblCreatedByid")).Text.ToString();
    }

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;
        this.fillGrid(); 
    }

 
}