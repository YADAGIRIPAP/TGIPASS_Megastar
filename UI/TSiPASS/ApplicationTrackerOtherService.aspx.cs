using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_ApplicationTrackerOtherService : System.Web.UI.Page
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
            //if (Session["userlevel"].ToString().Trim() != "2" || Session["userlevel"].ToString().Trim() != "1")   //changed from igolf error 16.1.2019
            //    IAT.Visible = false;
            //if (Session["userlevel"].ToString().Trim() == "2" || Session["userlevel"].ToString().Trim() == "1")
            //    IAT.Visible = true;
            //if (Session["userlevel"].ToString().Trim() == "24" || Session["userlevel"].ToString().Trim() == "25" || Session["userlevel"].ToString().Trim() == "20" || Session["userlevel"].ToString().Trim() == "13" || Session["userlevel"].ToString().Trim() == "12")
            //    Response.Redirect("~/Index.aspx");

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
            if (ddlquantityper.SelectedValue.ToString() == "OTHER")
            {

                if (dsn.Tables[0].Rows.Count > 0)
                {

                    grdDetails.DataSource = dsn.Tables[0];
                    grdDetails.DataBind();
                    grdDetails0.Visible = false;
                    grdDetails0.DataSource = null;
                    grdDetails0.DataBind();
                }
                else
                {
                    lblrecords.Text = "NO RECORD TO DISPLAY";
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
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

            Dsnew = Gen.GenericFillDs("[USP_GET_GetApplicationTracker_OTHERSERVICES]", pp);
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
                fillGrid();
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
                h1.NavigateUrl = "ApplicationTrakerDetailedOtherService.aspx?ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentReformId"));
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
}