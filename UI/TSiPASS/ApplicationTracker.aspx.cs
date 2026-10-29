using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//using System.Reflection.Emit;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
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
        if (Session["username"] == null)
        {
            Response.Redirect("~/IpassLogin.aspx");
        }
        if (!IsPostBack)
        {
            if (Session["userlevel"].ToString().Trim() != "2" || Session["userlevel"].ToString().Trim() != "1")   //changed from igolf error 16.1.2019
                IAT.Visible = false;
            if (Session["userlevel"].ToString().Trim() == "2" || Session["userlevel"].ToString().Trim() == "1")
                IAT.Visible = true;
            if (Session["userlevel"].ToString().Trim() == "24" || Session["userlevel"].ToString().Trim() == "25" || Session["userlevel"].ToString().Trim() == "20" || Session["userlevel"].ToString().Trim() == "13" || Session["userlevel"].ToString().Trim() == "12")
                Response.Redirect("~/Index.aspx");

            //fillGrid();
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }



    void fillGrid()
    {
        try
        {
            DataSet dsn = new DataSet();


            // dsn = Gen.GetApplicationTracker(txtnameofUnit.Text, txtUID.Text,ddlquantityper.SelectedValue.ToString());
            dsn = Getchildandparentdata(txtnameofUnit.Text.TrimStart().TrimEnd(), txtUID.Text.TrimStart().TrimEnd(), ddlquantityper.SelectedValue.ToString());
            if (ddlquantityper.SelectedValue.ToString() == "CFE")
            {

                if (dsn.Tables[0].Rows.Count > 0)
                {
                    grdDetails.Visible = true;
                    grdDetails.DataSource = dsn.Tables[0];
                    grdDetails.DataBind();

                    grdDetails0.Visible = false;
                    grdDetails0.DataSource = null;
                    grdDetails0.DataBind();

                    grdRenewal.Visible = false;
                    grdRenewal.DataSource = null;
                    grdRenewal.DataBind();
                }
                else
                {
                    lblrecords.Text = "NO RECORD TO DISPLAY";
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();

                    grdDetails0.Visible = false;
                    grdDetails0.DataSource = null;
                    grdDetails0.DataBind();

                    grdRenewal.Visible = false;
                    grdRenewal.DataSource = null;
                    grdRenewal.DataBind();
                }
            }
            else if (ddlquantityper.SelectedValue.ToString() == "CFO")
            {


                if (dsn.Tables[0].Rows.Count > 0)
                {
                    grdDetails0.Visible = true;
                    grdDetails0.DataSource = dsn.Tables[0];
                    grdDetails0.DataBind();

                    grdDetails.Visible = false;
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();

                    grdRenewal.Visible = false;
                    grdRenewal.DataSource = null;
                    grdRenewal.DataBind();
                }
                else
                {
                    lblrecords.Text = "NO RECORD TO DISPLAY";
                    grdDetails0.DataSource = null;
                    grdDetails0.DataBind();

                    grdDetails.Visible = false;
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();

                    grdRenewal.Visible = false;
                    grdRenewal.DataSource = null;
                    grdRenewal.DataBind();
                }


            }
            else if (ddlquantityper.SelectedValue.ToString() == "RENEWAL")
            {
                if (dsn.Tables[0].Rows.Count > 0)
                {
                    grdRenewal.DataSource = dsn.Tables[0];
                    grdRenewal.DataBind();

                    grdDetails.Visible = false;
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();

                    grdDetails0.Visible = false;
                    grdDetails0.DataSource = null;
                    grdDetails0.DataBind();
                }
                else
                {
                    lblrecords.Text = "NO RECORD TO DISPLAY";
                    grdRenewal.DataSource = null;
                    grdRenewal.DataBind();
                   
                    grdDetails.Visible = false;
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();

                    grdDetails0.Visible = false;
                    grdDetails0.DataSource = null;
                    grdDetails0.DataBind();
                }
            }
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
            if (txtnameofUnit.Text != "" || txtUID.Text != "")
            {
                //fillGrid();
                if (ddlquantityper.SelectedItem.Text == "PLOT")
                {
                    bindplots();
                }
                else
                {
                    fillGrid();
                }
            }
            else
            {
                lblError.Visible = true;
            }
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
    protected void BtnClear_Click(object sender, EventArgs e)
    {

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

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink h1 = (HyperLink)e.Row.FindControl("hypLetter");
                h1.NavigateUrl = "ApplicationTrakerDetailed.aspx?ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid"));
                h1.Text = "Click Here";
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
                h2.NavigateUrl = "ApplicationTrakerDetailedCFO.aspx?ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid"));
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
    protected void grdRenewal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                // https://ipass.telangana.gov.in/UI/TSiPASS/RptApplicationWiseDetailedTrakerREN.aspx?intqnreid=116070
                HyperLink h2 = (HyperLink)e.Row.FindControl("hypLetter0");
                h2.NavigateUrl = "RptApplicationWiseDetailedTrakerREN.aspx?ntqnreid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid"));
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

    public void bindplots()
    {
        SqlParameter[] p = new SqlParameter[] {
           new SqlParameter("@ApplicationID",SqlDbType.Int),
        };


        //p[0].Value = Convert.ToInt32(Session["uid"].ToString());
        p[0].Value = txtUID.Text.Substring(12);

        DataSet GDs = Gen.GenericFillDs("USP_userdashboardPlot", p);


        string gghf = GDs.Tables[0].Columns[7].ToString();

        if (GDs.Tables[0].Rows.Count > 0)
        {
            grdPlot.DataSource = GDs.Tables[0];
            grdPlot.DataBind();

        }
        else
        {
            lblrecords.Text = "NO RECORD TO DISPLAY";
            grdRenewal.DataSource = null;
            grdRenewal.DataBind();
        }
    }
    protected void grdPlot_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            ViewState["ApplicationId"] = e.Row.Cells[1].Text;


            Label lblA = e.Row.FindControl("lblRmTypeid") as Label;

            ViewState["lblid"] = lblA.Text;

            Button lblAssId = e.Row.FindControl("anchortaglin") as Button;

            Button lblAd = e.Row.FindControl("anchortagli") as Button;
            if (lblA.Text.ToString() == "3")
            {
                lblAssId.Text = "Complete Application";
                lblAssId.Visible = true;

            }
            else
            {
                lblAssId.Text = "Incomplete Application";
                lblAssId.Visible = true;
                lblAssId.Enabled = false;
            }

        }
    }

    protected void anchortaglin_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        string id = row.Cells[1].Text;
        Label TypeId = (Label)row.FindControl("lblRmTypeid");

        if (TypeId.Text.ToString() == "2")
        {
            string newurl = "frmtsiicplotallotment.aspx?AppId=" + id;
            Response.Redirect(newurl);
        }
        else
        {
            string newurl = "UserFormView_plotallotment.aspx?intApplid=" + id;
            Response.Redirect(newurl);
        }
    }

    protected void anchortagli_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        string id = row.Cells[1].Text;
    }

}
