using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmDashboardRedirectTourismAgent : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string intquestionnaireid = "";
        string id = "";
        DataSet ds = new DataSet();
        string status = Request.QueryString[1].ToString().Trim();
        intquestionnaireid = Request.QueryString[0].ToString().Trim();
        if (!IsPostBack)
        {
            ds = getEnterprenuerTourismagentdashboarddrilldown(Session["uid"].ToString().Trim(), status, Request.QueryString[0].ToString().Trim(), "");

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
                        HyperLinkcoi.NavigateUrl = "TRAVEL_AGENCY.aspx?intCFEEnterpid=" + Convert.ToString(ds.Tables[0].Rows[0]["intQuessionaireid"].ToString()).Trim();

                    }
                }


                else if (status == "Approval - Rejected")
                {
                    grdDetails.Columns[15].Visible = false;
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
                    
                }
                else
                {

                    grdDetails.Columns[15].Visible = false;
                    grdDetails.Columns[16].Visible = false;
                    grdDetails.Columns[17].Visible = false;
                    //grdDetails.Columns[21].Visible = false;
                }

            }
        }
    }

    public DataSet getEnterprenuerTourismagentdashboarddrilldown(string intEntid, string status, string intQuessionaireid, string createddt)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        con.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getEnterprenuer_TourismAgentdashboarddrilldown", con);
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
            h1.NavigateUrl = "frmViewAttachmentDetailsTourismAgent_User.aspx?intApplicationId=" + Request.QueryString[0].ToString().Trim();
                //Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            HyperLink h2 = (HyperLink)e.Row.Cells[16].Controls[0];

            h2.Target = "_blank";

                if (Request.QueryString[1].ToString().Trim() == "Queries -Yet to Respond")
                {

                    h2.NavigateUrl = "frmResponceQueriesTourismAgent.aspx?intApplicationid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQueryTrnsid")).Trim();
                    h2.Text = "Respond";

                }
                else if (Request.QueryString[1].ToString().Trim() == "Approval - Pending")
                {
                        grdDetails.Columns[21].Visible = false;
                }
                else
                {
                    if (Commondetatilsupdated != "" && Commondetatilsupdated == "Y")
                    {
                        h2.NavigateUrl = "http://tsocmms.nic.in/TLNPCB/industryRegMaster/industryHomeNew?swiftApplicationNo=" + createdby + "&applicationNo=" + NICApplicationno;
                        h2.Text = "Click here to Appeal";

                    }
                }
            
        }
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/AcknowledgmentEntrPrint.aspx?id=" + Request.QueryString[0].ToString().Trim());
    }
}