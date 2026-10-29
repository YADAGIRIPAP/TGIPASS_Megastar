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

public partial class UI_TSIPASS_frmDashBoardSLC : System.Web.UI.Page
{
    General Gen = new General();
    DataSet ds = new DataSet();
    comFunctions cmf = new comFunctions();
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (!IsPostBack)
            {
               // filldetailsforSA();
                Filldashbord();
            }
        }
        else
        {
            Response.Redirect("~/ipasslogin.aspx");
        }
    }
    public void Filldashbord()
    {
        try
        {
            ds = Gen.GetAddlDashboard("21345", "ADDL");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                //Label12.Text = ds.Tables[0].Rows[0]["TotalSLCApproved"].ToString();
                //lblDIPCReleasePendings.Text = ds.Tables[0].Rows[0]["TotalSLCApprovedDIPC"].ToString();
                Label12.Text = ds.Tables[0].Rows[0]["TotalSLCApproved"].ToString();
                lblReleaseProceedingsCmpltdList.Text = ds.Tables[0].Rows[0]["ReleaseProceedingsTotal"].ToString();

                Label16.Text = ds.Tables[0].Rows[0]["UCCompleted"].ToString();
                Label13.Text = ds.Tables[0].Rows[0]["CheckListpending"].ToString();
                lblrollbackslc.Text = ds.Tables[0].Rows[0]["CheckListpending_ROLLBACKSLC"].ToString();

                Label24.Text = ds.Tables[0].Rows[0]["UCPending"].ToString();
                //lblabryanced_SLC.Text= ds.Tables[0].Rows[0]["UCABEYANCE_SLC"].ToString();
               // LBLABEYANCEDDIPC.Text = ds.Tables[0].Rows[0]["UCABEYANCE_DIPC"].ToString();
                Label25.Text = ds.Tables[0].Rows[0]["CheckListCompleted"].ToString();

                lblDIPCReleasePendings.Text = ds.Tables[0].Rows[0]["TotalSLCApprovedDIPC"].ToString();

                Label17.Text = ds.Tables[0].Rows[0]["ReleaseProceedingsTotalDIPC"].ToString();

                Label26.Text = ds.Tables[0].Rows[0]["UCCompletedDIPC"].ToString();
                Label27.Text = ds.Tables[0].Rows[0]["UCPendingDIPC"].ToString();

                lblGenCHeckListforDIPC.Text = ds.Tables[0].Rows[0]["CheckListpendingDIPC"].ToString();
                lblrollbackDIPC.Text = ds.Tables[0].Rows[0]["CheckListpendingDIPC_ROLLBACKED"].ToString();

                Label18.Text = ds.Tables[0].Rows[0]["CheckListCompletedDIPC"].ToString();

                //Label23.Text = ds.Tables[0].Rows[0]["Hold"].ToString();
                //lblrejadditional.Text = ds.Tables[0].Rows[0]["REJECTED"].ToString();
                //Label15.Text = ds.Tables[0].Rows[0]["Rejectedsvc"].ToString();
                //slcrejected.Text = ds.Tables[0].Rows[0]["SCRRejectedCOMSLC"].ToString();
               
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
}