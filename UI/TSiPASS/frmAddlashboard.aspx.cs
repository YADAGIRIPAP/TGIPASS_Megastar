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

public partial class UI_TSiPASS_frmAddlashboard : System.Web.UI.Page
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
        try
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("~/IpassLogin.aspx");
            }
            if (!IsPostBack)
            {
                // filldetailsforSA();
                Filldashbord();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    public void filldetailsforSA()
    {
        try
        {
            ds = Gen.GetIncetivePOSDetailsdept(Session["uid"].ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblAppl.Text = ds.Tables[0].Rows[0]["No_Applns_Rcvd"].ToString();
                Label1.Text = ds.Tables[0].Rows[0]["scrutny_pndg_wthn_tml"].ToString();
                Label2.Text = ds.Tables[0].Rows[0]["scrutny_pndg_bynd_tml"].ToString();

                Label3.Text = ds.Tables[0].Rows[0]["scrutny_dne_wthn_tml"].ToString();
                Label4.Text = ds.Tables[0].Rows[0]["scrutny_dne_bynd_tml"].ToString();



            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    public void Filldashbord()
    {
        try
        {
            ds = GetAddlDashboard(Session["uid"].ToString(), "ADDL");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
              //  lblDeptRetnd.Text = ds.Tables[0].Rows[0]["deptRetnd"].ToString();
              //  lblDeptprocessed.Text = ds.Tables[0].Rows[0]["deptProcessed"].ToString();

                lblPreSVC.Text = ds.Tables[0].Rows[0]["PreSVC"].ToString();
                lblNOofapplications.Text = ds.Tables[0].Rows[0]["No_Applications_FromJd"].ToString();
                lblPreSVC.Text = ds.Tables[0].Rows[0]["pscwithin"].ToString();
                lblpscbeyond.Text = ds.Tables[0].Rows[0]["pscbeyond"].ToString();

                lblPreSVCSSC.Text = ds.Tables[0].Rows[0]["pscwithinSSC"].ToString();
                lblpscbeyondSSC.Text = ds.Tables[0].Rows[0]["pscbeyondSSC"].ToString();
                lblsscinspectionreportupload.Text = ds.Tables[0].Rows[0]["SCRSSCREPORT"].ToString();
                lblsscinspectionreportuploadCOMP.Text = ds.Tables[0].Rows[0]["SCRSSCREPORTCOMP"].ToString();

                lblpsccomwithin.Text = ds.Tables[0].Rows[0]["pscwithincom"].ToString();
                lblpsccombeyond.Text = ds.Tables[0].Rows[0]["pscbeyondcom"].ToString();


                // SVC Dashboard

                lblsvcrecved.Text = ds.Tables[0].Rows[0]["No_Applications_TOSVC"].ToString();
                lblsvcwithin.Text = ds.Tables[0].Rows[0]["pscwithinsvcag"].ToString();
                lblsvcbeyond.Text = ds.Tables[0].Rows[0]["pscbeyondsvcag"].ToString();

                lbluploadwithin.Text = ds.Tables[0].Rows[0]["pscwithinsvc"].ToString();
                lbluploadBeyond.Text = ds.Tables[0].Rows[0]["pscbeyondsvc"].ToString();

                Label11.Text = ds.Tables[0].Rows[0]["pscwithincomsvc"].ToString();
                Label12.Text = ds.Tables[0].Rows[0]["pscbeyondcomsvc"].ToString();
                Label15.Text = ds.Tables[0].Rows[0]["Rejectedsvc"].ToString();
                Label28.Text = ds.Tables[0].Rows[0]["TotalSVC"].ToString();
                // SLC Dashboard

                lblslcrecved.Text = ds.Tables[0].Rows[0]["NoofapplicationsrecvdSLC"].ToString();
                lblslcwithin.Text = ds.Tables[0].Rows[0]["SCRwithinSLCag"].ToString();
                lblslcbeyond.Text = ds.Tables[0].Rows[0]["SCRBeyondSLCag"].ToString();
                lblslcupdwothin.Text = ds.Tables[0].Rows[0]["SCRwithinSLC"].ToString();
                lblslcupdbeyond.Text = ds.Tables[0].Rows[0]["SCRBeyondSLC"].ToString();

                lblslccomwithin.Text = ds.Tables[0].Rows[0]["SCRwithinCOMSLC"].ToString();
                lblslccombeyond.Text = ds.Tables[0].Rows[0]["SCRBeyondCOMSLC"].ToString();
                slcrejected.Text = ds.Tables[0].Rows[0]["SCRRejectedCOMSLC"].ToString();

                // lblPostSVC.Text = ds.Tables[0].Rows[0]["POSTSVC"].ToString();
                //  lblPostSLC.Text = ds.Tables[0].Rows[0]["POSTSLC"].ToString();
                //  lblAssignSVCDt.Text = ds.Tables[0].Rows[0]["SVCDATE"].ToString();


                Label19.Text = ds.Tables[0].Rows[0]["Queries_Resp_pndg"].ToString();
                Label22.Text = ds.Tables[0].Rows[0]["Queries_Responded"].ToString();
                Label20.Text = ds.Tables[0].Rows[0]["Queries_RespondedWITHIN"].ToString();
                Label21.Text = ds.Tables[0].Rows[0]["Queries_RespondedBEYOND"].ToString();
                lblrej.Text = ds.Tables[0].Rows[0]["REJECTED"].ToString();


                Label23.Text = ds.Tables[0].Rows[0]["Hold"].ToString();

                lblReleasePendings.Text = ds.Tables[0].Rows[0]["TotalSLCApproved"].ToString();
                lblReleaseProceedings.Text = ds.Tables[0].Rows[0]["ReleaseProceedingsPending"].ToString();
                lblReleaseProceedingsCmpltdList.Text = ds.Tables[0].Rows[0]["ReleaseProceedingsTotal"].ToString();

                Label16.Text = ds.Tables[0].Rows[0]["UCCompleted"].ToString();
                Label9.Text = ds.Tables[0].Rows[0]["CheckListpending"].ToString();
                Label24.Text = ds.Tables[0].Rows[0]["UCPending"].ToString();

                Label25.Text = ds.Tables[0].Rows[0]["CheckListCompleted"].ToString();



                lblDIPCReleasePendings.Text = ds.Tables[0].Rows[0]["TotalSLCApprovedDIPC"].ToString();
                lblReleaseProcforDIPC.Text = ds.Tables[0].Rows[0]["ReleaseProceedingsPendingDIPC"].ToString();
                Label17.Text = ds.Tables[0].Rows[0]["ReleaseProceedingsTotalDIPC"].ToString();

                Label26.Text = ds.Tables[0].Rows[0]["UCCompletedDIPC"].ToString();
                Label27.Text = ds.Tables[0].Rows[0]["UCPendingDIPC"].ToString();

                lblGenCHeckListforDIPC.Text = ds.Tables[0].Rows[0]["CheckListpendingDIPC"].ToString();
                Label18.Text = ds.Tables[0].Rows[0]["CheckListCompletedDIPC"].ToString();
                Label29.Text = ds.Tables[0].Rows[0]["psctotalpending"].ToString();
                LBLCOMM_RET.Text = ds.Tables[0].Rows[0]["COMMISSIONERPROCESSED"].ToString();
                lblCommPending.Text = ds.Tables[0].Rows[0]["CommPending"].ToString();

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    public DataSet GetAddlDashboard(string UserCode, string USERTYPE)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ADDL_DASHBOARD", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@USERID", SqlDbType.VarChar).Value = UserCode;
            da.SelectCommand.Parameters.Add("@USERTYPE", SqlDbType.VarChar).Value = USERTYPE;
            da.SelectCommand.CommandTimeout = 1500;
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