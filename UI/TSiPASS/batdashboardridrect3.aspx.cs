//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_batdashboardridrect3 : System.Web.UI.Page
{

    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    DB.DB con=new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["user"] != null && Session["user"] != "")
        //{ }
        //else
        //{
        //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //}
        DataSet ds = new DataSet();
        string status = Request.QueryString[1].ToString().Trim();
        string id = Request.QueryString[0].ToString().Trim();
        string batdealerid = "";
        //if (Request.QueryString[1].ToString().Trim() != null && Request.QueryString[1].ToString().Trim() != "")
        //{
        //    intquestionnaireid = Request.QueryString[2].ToString().Trim();
        //}
        DataSet dscheck1 = new DataSet();
        dscheck1 = GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
        if  (dscheck1 != null && dscheck1.Tables.Count > 0 && dscheck1.Tables[0].Rows.Count > 0) // dscheck1.Tables[0].Rows.Count > 0)
        {
            batdealerid = dscheck1.Tables[0].Rows[0]["BatdealerID"].ToString().Trim();
        }
        else
        {
            batdealerid = "0";
        }


        if (!IsPostBack)
        {
            ds = getEnterprenuerbatdealerdashboarddrilldown(Session["uid"].ToString().Trim(), status, Request.QueryString[0].ToString().Trim(), "");

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                if (status == "Approval - Issued")
                {

                    grdDetails.Columns[15].Visible = true;
                    grdDetails.Columns[16].Visible = false;
                    grdDetails.Columns[17].Visible = false;
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
                    int c = ds.Tables[0].Rows.Count;
                    int i = 0;
                    while (i < c)
                    {
                        if (ds.Tables[0].Rows[i]["intapprovalid"].ToString() == "55")
                        {
                            grdDetails.Columns[21].Visible = true;
                        }
                        else
                        {
                            grdDetails.Columns[21].Visible = false;
                        }
                        i++;
                    }
                }
                else
                {

                    grdDetails.Columns[15].Visible = false;
                    grdDetails.Columns[16].Visible = false;
                    grdDetails.Columns[17].Visible = false;
                    grdDetails.Columns[21].Visible = false;
                }

            }
        }


    }
    public DataSet getEnterprenuerbatdealerdashboarddrilldown(string intEntid, string status, string intQuessionaireid, string createddt)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getEnterprenuerbatdealerdashboarddrilldown", con.GetConnection);
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
                da.SelectCommand.Parameters.Add("@BatdealerID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@BatdealerID", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

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
            con.CloseConnection();
        }
    }

    public DataSet GetShowRenewalQuestionaries(string Created_by, string INTAPPLICATIONID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GetShowbatdealer]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Created_by.Trim() == "" || Created_by.Trim() == null)
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.ToString();

            if (INTAPPLICATIONID.Trim() == "" || INTAPPLICATIONID.Trim() == null)
                da.SelectCommand.Parameters.Add("@batdealerID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@batdealerID", SqlDbType.VarChar).Value = INTAPPLICATIONID.ToString();
            
            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
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

        try
        {



        }
        catch (Exception ex)
        {
            // lblmsg.Text = ex.ToString();
        }
        finally
        {

        }

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
            string createdby = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Created_by"));
            string Commondetatilsupdated = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CommonDetailsUpdatedFlag"));
            //string NICApplicationno = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NICApplicationno"));
            HyperLink h1 = (HyperLink)e.Row.Cells[15].Controls[0];

            h1.Target = "_blank";
            h1.NavigateUrl = "frmViewAttachmentDetailsRenewal.aspx?BatdealerID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BatdealerID")).Trim();

            HyperLink h2 = (HyperLink)e.Row.Cells[16].Controls[0];

            h2.Target = "_blank";
           

          
                if (Request.QueryString[1].ToString().Trim() == "Queries -Yet to Respond")
                {
                    //h2.NavigateUrl = "frmResponceQueriesRenewal.aspx?intApplicationid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQueryTrnsid")).Trim();
                    //h2.Text = "Respond";

                    h2.NavigateUrl = "batdealqueryresponce.aspx?BatdealerID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BatdealerID")).Trim();
                    h2.Text = "Respond";

                }
              
                else
                {
                    if (Commondetatilsupdated != "" && Commondetatilsupdated == "Y")
                    {
                        //h2.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHome?swiftApplicationNo=" + createdby + "&applicationNo=" + NICApplicationno; 
                        //h2.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHomeNew?swiftApplicationNo=" + createdby + "&applicationNo=" + NICApplicationno;
                        //h2.Text = "Click here to Appeal";
                        //if (Letter != null && Letter != "")
                        //{
                        //    grdDetails.Columns[19].Visible = true;
                        //}
                        //else
                        //{
                        //    grdDetails.Columns[19].Visible = false;
                        //}
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

        //string pageurl = "~/UI/TSIPASS/AcknowledgmentEntrPrint.aspx?id=" + Request.QueryString[0].ToString().Trim();

        //Response.Write("<script> window.open( '" + pageurl + "','_blank' ); </script>");

        //Response.End();

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/UI/TSIPASS/AcknowledgmentEntrPrint.aspx?id=" + Request.QueryString[0].ToString().Trim() + "','_newtab');");
    }
}
