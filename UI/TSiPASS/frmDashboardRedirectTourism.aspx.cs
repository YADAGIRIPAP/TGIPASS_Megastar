using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID


public partial class UI_TSiPASS_frmDashboardRedirectTourism : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
   // General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["user"] != null && Session["user"] != "")
        //{ }
        //else
        //{
        //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //}

        //DataSet ds = new DataSet();
        //string status = Request.QueryString[1].ToString().Trim();
        //string id = Request.QueryString[0].ToString().Trim();

        string intquestionnaireid = "";
        string id = "";
        DataSet ds = new DataSet();
        string status = Request.QueryString[1].ToString().Trim();
        intquestionnaireid = Request.QueryString[0].ToString().Trim();

        //if(Request.QueryString[2]!=null)
        //{
        //    string check = Request.QueryString[2].ToString().Trim();
        //}
        //string intquestionnaireid = "";
        //if (Request.QueryString[1].ToString().Trim() != null && Request.QueryString[1].ToString().Trim() != "")
        //{
        //    intquestionnaireid = Request.QueryString[2].ToString().Trim();
        //}
        //DataSet dscheck1 = new DataSet();
        //dscheck1 = Gen.GetShowRenewalQuestionaries(id);
        //if (dscheck1.Tables[0].Rows.Count > 0)
        //{
        //    intquestionnaireid = dscheck1.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
        //}
        //else
        //{
        //    intquestionnaireid = "0";
        //}


        if (!IsPostBack)
        {
            //ds = Gen.getEnterprenuerRenewaldashboarddrilldown(id, status, Session["Applid"].ToString(), "");
            ds = getEnterprenuerRenewaldashboarddrilldown(Session["uid"].ToString().Trim(), status, Request.QueryString[0].ToString().Trim(), "");

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                if (status == "Approval - Issued")
                {

                    grdDetails.Columns[15].Visible = true;
                    grdDetails.Columns[16].Visible = false;
                    grdDetails.Columns[17].Visible = false;
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                           trcoicertificate.Visible = true;
                            HyperLinkcoi.Target = "_blank";
                            //HyperLinkcoi.NavigateUrl = "CFECertificate.aspx?intCFEEnterpid=" + Convert.ToString(id).Trim();
                            HyperLinkcoi.NavigateUrl = "TOURISM_EVENTS.aspx?intCFEEnterpid=" + Convert.ToString(ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString()).Trim();
                        
                    }
                }


                else if (status == "Approval - Rejected")
                {
                    grdDetails.Columns[15].Visible = false;
                    //grdDetails.Columns[16].Visible = false;  commented on 24.01.2019. Not to uncomment
                    grdDetails.Columns[16].Visible = true;
                    grdDetails.Columns[17].Visible = false;
                   
                }


                else if (status == "Pre-Scrutiny - Rejected")
                {
                    grdDetails.Columns[15].Visible = false;
                    grdDetails.Columns[16].Visible = true;
                    grdDetails.Columns[17].Visible = false;
                }
                else if (status == "Queries -Yet to Respond")
                {
                    grdDetails.Columns[15].Visible = false;
                    grdDetails.Columns[16].Visible = true;
                    grdDetails.Columns[17].Visible = false;
                }
                else if (status == "Approval - Pending")
                {
                    grdDetails.Columns[15].Visible = false;
                    grdDetails.Columns[16].Visible = false;
                    grdDetails.Columns[17].Visible = false;
                    //grdDetails.Columns[21].Visible = true;
                    
                }
                else
                {

                    grdDetails.Columns[15].Visible = false;
                    grdDetails.Columns[16].Visible = false;
                    grdDetails.Columns[17].Visible = false;
                   // grdDetails.Columns[21].Visible = false;
                }

            }
        }


    }
    public DataSet getEnterprenuerRenewaldashboarddrilldown(string intEntid, string status, string intQuessionaireid, string createddt)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        con.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getEnterprenuer_Tourismdashboarddrilldown", con );
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (status.Trim() == "" || status.Trim() == null)
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = status.ToString();

            if (intEntid.Trim() == "" || intEntid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = intEntid.ToString();

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

            if (createddt.Trim() == "" || createddt.Trim() == null)
                da.SelectCommand.Parameters.Add("@createddt", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@createddt", SqlDbType.VarChar).Value = createddt.ToString();
            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            //throw ex;
            return null;
        }
        finally
        {
            con.Close();
        }
    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {



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


    }



    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField HdfApprovalid = (HiddenField)e.Row.FindControl("HdfApprovalid");
            HdfApprovalid.Value = DataBinder.Eval(e.Row.DataItem, "intApprovalid").ToString().Trim();
            string createdby = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Createdby"));
            string Commondetatilsupdated = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CommonDetailsUpdatedFlag"));
            string NICApplicationno = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NICApplicationno"));
            HyperLink h1 = (HyperLink)e.Row.Cells[15].Controls[0];

            h1.Target = "_blank";
            h1.NavigateUrl = "frmViewAttachmentDetailsTourism.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            HyperLink h2 = (HyperLink)e.Row.Cells[16].Controls[0];

            h2.Target = "_blank";

            if (HdfApprovalid.Value == "53")
            {
                if (NICApplicationno != "" && NICApplicationno != null)
                {
                    if (Request.QueryString[1].ToString().Trim() == "Queries -Yet to Respond")
                    {
                        if (Commondetatilsupdated != "" && Commondetatilsupdated == "Y")
                        {
                            h2.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHomeNew?swiftApplicationNo=" + createdby + "&applicationNo=" + NICApplicationno;
                            h2.Text = "Respond";
                        }
                        else
                        {
                            h2.NavigateUrl = "frmResponceQueriesTourism.aspx?intApplicationid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQueryTrnsid")).Trim();
                            h2.Text = "Respond";
                        }
                    }
                    else
                    {
                        if (Commondetatilsupdated != "" && Commondetatilsupdated == "Y")
                        {
                            //h2.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHome?swiftApplicationNo=" + createdby + "&applicationNo=" + NICApplicationno; 
                            h2.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHomeNew?swiftApplicationNo=" + createdby + "&applicationNo=" + NICApplicationno;
                            h2.Text = "Click here to Appeal";
                        }
                    }

                }
            }
            else
            {
                if (Request.QueryString[1].ToString().Trim() == "Queries -Yet to Respond")
                {

                    h2.NavigateUrl = "frmResponceQueriesTourism.aspx?intApplicationid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQueryTrnsid")).Trim();
                    h2.Text = "Respond";

                }
                else if (Request.QueryString[1].ToString().Trim() == "Approval - Pending")
                {
                    if (HdfApprovalid.Value == "55")
                    {
                        HyperLink bolierlink = (HyperLink)e.Row.Cells[21].Controls[0];
                        grdDetails.Columns[21].Visible = true;
                        bolierlink.Target = "_blank";
                        bolierlink.NavigateUrl = "frmBoilerInspectionUpload.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                    }
                    else
                    {
                      //  grdDetails.Columns[21].Visible = false;
                    }
                }
                else
                {
                    if (Commondetatilsupdated != "" && Commondetatilsupdated == "Y")
                    {
                        //h2.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHome?swiftApplicationNo=" + createdby + "&applicationNo=" + NICApplicationno; 
                        h2.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHomeNew?swiftApplicationNo=" + createdby + "&applicationNo=" + NICApplicationno;
                        h2.Text = "Click here to Appeal";

                    }
                }
            }
        }
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/AcknowledgmentEntrPrint.aspx?id=" + Request.QueryString[0].ToString().Trim());
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}