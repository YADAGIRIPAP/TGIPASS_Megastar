using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_frmCoiDashboard : System.Web.UI.Page
{
    General Gen = new General();
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
        DataSet ds = Gen.GetCoiIncetivePOSDetailsdept(Session["uid"].ToString());
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
            lblQueriesRespondedbyGM.Text = ds.Tables[0].Rows[0]["ADDQUERYJDYETTORESPOND"].ToString();
            lblAutorejected.Text = ds.Tables[0].Rows[0]["totalRerjected"].ToString();

            LabelForwarded.Text = ds.Tables[0].Rows[0]["TOTALAPPLFORWARDEDTOJD"].ToString();
            LabelQueryAD.Text = ds.Tables[0].Rows[0]["TOTALAPPLQUERYTOJD"].ToString();
            LabelJDReturned.Text = ds.Tables[0].Rows[0]["TOTALAPPLRETURNEDFROMJD"].ToString();
            lbladrecommended.Text = ds.Tables[0].Rows[0]["TOTALAPPLADRECOMMENDTOJD"].ToString();
            lblqueryforwardedtojd.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDEDADFORWARDED"].ToString();
            lblqueryraisedbyforqiery.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDEDADQUERY"].ToString();
            Label3.Text = ds.Tables[0].Rows[0]["APPRASIALPRINT"].ToString();

        }




    }
}