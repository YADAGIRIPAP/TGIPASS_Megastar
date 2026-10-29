using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using BusinessLogic;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmJDashboard : System.Web.UI.Page
{
    General Gen = new General();
    DataSet ds = new DataSet();
    comFunctions cmf = new comFunctions();
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    DB.DB con = new DB.DB();
    SqlDataAdapter myDataAdapter;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (!IsPostBack)
            {
                filldetailsforSA();
                Filldashbord();
            }
        }
        else
        {
            Response.Redirect("~/ipasslogin.aspx");
        }
    }

    public void filldetailsforSA()
    {

        string usercode = "";

        usercode = Session["uid"].ToString();


        ds = GetIncetivePOSDetailsdept(usercode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            //lblDeptprocessed.Text = ds.Tables[0].Rows[0]["deptProcessed"].ToString();
            LabelForwarded.Text = ds.Tables[0].Rows[0]["TOTALAPPLFORWARDEDTOJD"].ToString();
            LabelQueryAD.Text = ds.Tables[0].Rows[0]["TOTALAPPLQUERYTOJD"].ToString();
            LabelJDReturned.Text = ds.Tables[0].Rows[0]["TOTALAPPLRETURNEDFROMJD"].ToString();
            lbladrecommended.Text = ds.Tables[0].Rows[0]["TOTALAPPLADRECOMMENDTOJD"].ToString();
            lblqueryforwardedtojd.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDEDADFORWARDED"].ToString();
            lblqueryraisedbyforqiery.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDEDADQUERY"].ToString();

            lblAppl.Text = ds.Tables[0].Rows[0]["No_Applns_Rcvd"].ToString();
            Label1.Text = ds.Tables[0].Rows[0]["scrutny_pndg_wthn_tml"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["scrutny_pndg_bynd_tml"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["scrutny_pndg_bynd_total"].ToString();


            Label3.Text = ds.Tables[0].Rows[0]["scrutny_dne_wthn_tml"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["scrutny_dne_bynd_tml"].ToString();
            Label9.Text = ds.Tables[0].Rows[0]["scrutny_dne_TOTAL"].ToString();

            Label5.Text = ds.Tables[0].Rows[0]["Queries_Resp_pndg"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["Queries_Responded"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["Queries_RespondedWITHIN"].ToString();
            Label11.Text = ds.Tables[0].Rows[0]["Queries_RespondedBEYOND"].ToString();
            lblrej.Text = ds.Tables[0].Rows[0]["REJECTED"].ToString();
            lblAutorejected.Text = ds.Tables[0].Rows[0]["totalRerjected"].ToString();
            LBLAUTOREJECTEDGENERAL.Text = ds.Tables[0].Rows[0]["totalRerjected_GENERAL"].ToString();

            // Label7.Text = ds.Tables[0].Rows[0]["Tot_Qrs_rsd"].ToString();

            Label7.Text = ds.Tables[0].Rows[0]["Hold"].ToString();

            lbltotalqueryraisedaddl.Text = ds.Tables[0].Rows[0]["AddlTotalQuery"].ToString();
            lblQueriesRespondedbyGM.Text = ds.Tables[0].Rows[0]["AddlQueryGmrespondedPendingatjd"].ToString();
            lbladdlquerypendinggm.Text = ds.Tables[0].Rows[0]["AddlQueryPendingatGM"].ToString();
            lblQueriesRespondedbyJD.Text = ds.Tables[0].Rows[0]["AddlQueryGmresponded_jdresponded"].ToString();

            LabelForwardedDD.Text = ds.Tables[0].Rows[0]["TOTALAPPLFORWARDEDTODD"].ToString();
            LabelQueryDD.Text = ds.Tables[0].Rows[0]["TOTALAPPLQUERYTODD"].ToString();
            LabelJDReturnedDD.Text = ds.Tables[0].Rows[0]["TOTALAPPLRETURNEDFROMDD"].ToString();
            lblDDrecommended.Text = ds.Tables[0].Rows[0]["TOTALAPPLADRECOMMENDTODD"].ToString();
            lblqueryforwardedtodd.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDEDDDFORWARDED"].ToString();
            lblqueryraisedbyforqierydd.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDEDDDQUERY"].ToString();

            lbladdforwardedtotal.Text = ds.Tables[0].Rows[0]["TotalNoofapplicationsFORWARDEDADDD"].ToString();
            lbladddforwardedwithin.Text = ds.Tables[0].Rows[0]["TotalNoofapplicationsFORWARDEDADDDWITHIN"].ToString();
            lbladdforwardedbeyond.Text = ds.Tables[0].Rows[0]["TotalNoofapplicationsFORWARDEDADDDWITHINBEYOND"].ToString();
            lblqueryadddforwardedtotal.Text = ds.Tables[0].Rows[0]["TotalNoofapplicationsFORWARDEDQUERY"].ToString();
            lblqueryadddforwardedbeyond.Text = ds.Tables[0].Rows[0]["TotalNoofapplicationsFORWARDEDQUERYADDDBEYOND"].ToString();
            lblqueryadddforwardedwithin.Text = ds.Tables[0].Rows[0]["TotalNoofapplicationsFORWARDEDQUERYADDDWITHIN"].ToString();
            lblsvcreturned.Text = ds.Tables[0].Rows[0]["SVCDEPTRERURNEDAPPLICATIONS"].ToString();

        }
    }


    public void Filldashbord()
    {
        try
        {
            ds = Gen.GetAddlDashboard("21345", "ADDL");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                Label12.Text = ds.Tables[0].Rows[0]["TotalSLCApproved"].ToString();
                lblReleaseProceedingsCmpltdList.Text = ds.Tables[0].Rows[0]["ReleaseProceedingsTotal"].ToString();

                Label16.Text = ds.Tables[0].Rows[0]["UCCompleted"].ToString();
                Label13.Text = ds.Tables[0].Rows[0]["CheckListpending"].ToString();
                Label24.Text = ds.Tables[0].Rows[0]["UCPending"].ToString();

                Label25.Text = ds.Tables[0].Rows[0]["CheckListCompleted"].ToString();

                lblDIPCReleasePendings.Text = ds.Tables[0].Rows[0]["TotalSLCApprovedDIPC"].ToString();

                Label17.Text = ds.Tables[0].Rows[0]["ReleaseProceedingsTotalDIPC"].ToString();

                Label26.Text = ds.Tables[0].Rows[0]["UCCompletedDIPC"].ToString();
                Label27.Text = ds.Tables[0].Rows[0]["UCPendingDIPC"].ToString();

                lblGenCHeckListforDIPC.Text = ds.Tables[0].Rows[0]["CheckListpendingDIPC"].ToString();
                Label18.Text = ds.Tables[0].Rows[0]["CheckListCompletedDIPC"].ToString();

                Label23.Text = ds.Tables[0].Rows[0]["Hold"].ToString();
                lblrejadditional.Text = ds.Tables[0].Rows[0]["REJECTED"].ToString();
                Label15.Text = ds.Tables[0].Rows[0]["Rejectedsvc"].ToString();
                slcrejected.Text = ds.Tables[0].Rows[0]["SCRRejectedCOMSLC"].ToString();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    public DataSet GetIncetivePOSDetailsdept(string UserCode)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("[showSrcutnyDet_Coi_Inc]", con.GetConnection);
           // da = new SqlDataAdapter("[USP_GET_JD_Dashboard]", con.GetConnection);
            da = new SqlDataAdapter("[USP_GET_JD_Dashboard_Caste_based]", con.GetConnection); 
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@uid", SqlDbType.VarChar).Value = UserCode;
            da.SelectCommand.CommandTimeout = 950;
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