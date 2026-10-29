using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

 


public partial class UI_TSIPASS_IncentiveWiseListGMSLC : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    General gen = new General();
    string code = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataSet ds = new DataSet();
            DataSet ods = new DataSet();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            Label1.Text = Request.QueryString[0].ToString();

            if (Request.QueryString["code"] != null)
                code = Request.QueryString[1].ToString();
            if (code != null && code != "")
            {
                Session["code"] = code;
                osqlConnection.Open();

                try
                {
                    // USP_GET_LIST_INCENTIVEWISE_GM_ABSTRACT
                    // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_GM", con.GetConnection);
                    oSqlDataAdapter = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_GM_ABSTRACT_testing", osqlConnection);
                    oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    oSqlDataAdapter.SelectCommand.Parameters.Add("@slcno", SqlDbType.VarChar).Value = Request.QueryString[0].ToString();
                    oSqlDataAdapter.SelectCommand.Parameters.Add("@Distid", SqlDbType.VarChar).Value = Session["DistrictID"].ToString().Trim();
                    oSqlDataAdapter.SelectCommand.Parameters.Add("@code", SqlDbType.VarChar).Value = code;
                    oSqlDataAdapter.Fill(ods);
                    //grdDetailsPavallavaddiSC.DataSource = ods.Tables[0];
                    //grdDetailsPavallavaddiSC.DataBind();
                    //grdAgreementCases.DataSource = ods.Tables[1];
                    //grdAgreementCases.DataBind();
                    osqlConnection.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    osqlConnection.Close();
                }
            }
            else
            {

                ds = gen.getincentiveslclistGM(Request.QueryString[0].ToString(), Session["DistrictID"].ToString().Trim());

                //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                //{
                // SC CAtegoty
                grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
                grdDetailsPavallavaddiSC.DataBind();
                grdAgreementCases.DataSource = ds.Tables[1];
                grdAgreementCases.DataBind();
            }


            //gvInvestmentSubsidySC.DataSource = ds.Tables[1];
            //gvInvestmentSubsidySC.DataBind();

            //gvGeneralSC.DataSource = ds.Tables[2];
            //gvGeneralSC.DataBind();

            //// ST CAtegoty
            //gvPavallavaddiST.DataSource = ds.Tables[3];
            //gvPavallavaddiST.DataBind();

            //gvInvestmentSubsidyST.DataSource = ds.Tables[4];
            //gvInvestmentSubsidyST.DataBind();

            //gvGeneralST.DataSource = ds.Tables[5];
            //gvGeneralST.DataBind();

            //// General CAtegoty
            //gvPavallavaddiGeneral.DataSource = ds.Tables[6];
            //gvPavallavaddiGeneral.DataBind();

            //gvInvestmentSubsidyGeneral.DataSource = ds.Tables[7];
            //gvInvestmentSubsidyGeneral.DataBind();

            //gvGeneralGeneral.DataSource = ds.Tables[8];
            //gvGeneralGeneral.DataBind();
            // }
        }
    }
    // SC CAtegory


    protected void grdDetailsPavallavaddiSC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("Label3") as Label);
            Button Button1 = (e.Row.FindControl("agreemnentButton") as Button);

            if (enterid.Text == "")
            {
                Button1.Visible = false;
            }
        }
    }

    protected void grdAgreementCases_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("Label3") as Label);
            Button Button2 = (e.Row.FindControl("agrementNotUpload") as Button);

            if (enterid.Text == "")
            {
                Button2.Visible = false;
            }
        }
    }



    protected void agreemnentButton_Click(object sender, EventArgs e)
    {
        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
        string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
        //string Sactionnumber = Request.QueryString[0].ToString();
        // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
        string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;
        string lblsubinctype = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblSubIncTypeId")).Text;

        Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncTypeId=" + lblsubinctype + "&Agreement=Y");
    }

    protected void agrementNotUpload_Click(object sender, EventArgs e)
    {
        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
        string lblMstIncentiveId = ((Label)grdAgreementCases.Rows[indexing].FindControl("Label3")).Text;
        //string Sactionnumber = Request.QueryString[0].ToString();
        // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
        string lblCategory1 = ((Label)grdAgreementCases.Rows[indexing].FindControl("lblCategory1")).Text;
        string lblsubinctype = ((Label)grdAgreementCases.Rows[indexing].FindControl("lblSubIncTypeId")).Text;

        Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId +
            "&SubIncTypeId=" + lblsubinctype + "&Agreement=N");
    }
}