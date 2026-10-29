using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmCoiDashboardSUPDT : System.Web.UI.Page
{
    General Gen = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (!IsPostBack)
            {
                if (Session["uid"].ToString() == "32951")
                {
                    trIncentivesHead.Visible = true;
                }
                fillDetails();
            }

        }
        else
        {
            Response.Redirect("~/ipasslogin.aspx");
        }
    }

    private void fillDetails()
    {
        DataSet ds = GetCoiIncetivePOSDetailsdeptClerk(Session["uid"].ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblAppl.Text = ds.Tables[0].Rows[0]["No_Applns_Rcvd"].ToString();
            Label1.Text = ds.Tables[0].Rows[0]["scrutny_pndg_wthn_tml"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["scrutny_pndg_bynd_tml"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["scrutny_pndg_bynd_total"].ToString();


            Label5.Text = ds.Tables[0].Rows[0]["Queries_Resp_pndg"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["Queries_Responded"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["Queries_RespondedWITHIN"].ToString();
            Label11.Text = ds.Tables[0].Rows[0]["Queries_RespondedBEYOND"].ToString();
            lblAbeyance.Text = ds.Tables[0].Rows[0]["HOLD"].ToString();
            lblAutorejected.Text = ds.Tables[0].Rows[0]["totalRerjected"].ToString();

            LabelForwarded.Text = ds.Tables[0].Rows[0]["TOTALAPPLFORWARDEDTOAD"].ToString();
            LabelQueryAD.Text = ds.Tables[0].Rows[0]["TOTALAPPLSUPTQUERYTOAD"].ToString();
            LabelJDReturned.Text = ds.Tables[0].Rows[0]["TOTALAPPLRETURNEDFROMAD"].ToString();
            lbladrecommended.Text = ds.Tables[0].Rows[0]["TOTALAPPLSUPTRECOMMENDTOAD"].ToString();
            lblqueryforwardedtojd.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDEDSUPTFORWARDEDTOAD"].ToString();
            lblqueryraisedbyforqiery.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDEDSUPTQUERYTOAD"].ToString();

            lblforwardedclerk.Text = ds.Tables[0].Rows[0]["TOTALAPPLRECEIVEDFROMCLERK"].ToString();
            lblclerkquery.Text = ds.Tables[0].Rows[0]["TOTALAPPLQUERYFROMCLERK"].ToString();
            lblqueryrespondedrecommendedbyclerk.Text = ds.Tables[0].Rows[0]["TOTALAPPLRECEIVEDFROMCLERKQUERYRES"].ToString();
            lblqueryrespondedqueryraisedbyclerk.Text = ds.Tables[0].Rows[0]["TOTALAPPLQUERYFROMCLERKQUERYRAISED"].ToString();
            //lblqueryraisedbyforqiery.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDEDADQUERY"].ToString();

        }




    }

    public DataSet GetCoiIncetivePOSDetailsdeptClerk(string UserId)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_COI_Dashboard_SUPTD]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = UserId;
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
}