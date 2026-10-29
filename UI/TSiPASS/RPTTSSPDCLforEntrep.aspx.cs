using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class TSTBDCReg1 : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    BusinessLogic.Fetch objFetch = new BusinessLogic.Fetch();
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                DataSet dsEntpDtls = objFetch.GETEntrepreneurDetails(Session["uid"].ToString());
                if (dsEntpDtls != null && dsEntpDtls.Tables.Count > 0 && dsEntpDtls.Tables[0].Rows.Count > 0)
                {
                    ds = Gen.GetTSSPDCL(dsEntpDtls.Tables[0].Rows[0]["intCFEEnterpid"].ToString());

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];

                        lblNameofSubStation.Text = dt.Rows[0]["TSSPDCL NAMEOFSUBSTN"].ToString();
                        lblExisPtrCapacity.Text = dt.Rows[0]["TSSPDCL EXIS PTR CAPACITY"].ToString();
                        lblMDReached.Text = dt.Rows[0]["TSSPDCL MD REACHED"].ToString();
                        lblProLoadPTR.Text = dt.Rows[0]["TSSPDCL PROLOAD PTR"].ToString();
                        lblTOTPtr.Text = dt.Rows[0]["TSSPDCL TOT PTR"].ToString();
                        lblFromFeeder.Text = dt.Rows[0]["TSSPDCL FROMFEEDER"].ToString();
                        lblPresLoadFeeder.Text = dt.Rows[0]["TSSPDCL PRESLOAD FEEDER"].ToString();
                        lblNowPropFeeder.Text = dt.Rows[0]["TSSPDCL NOWPROP FEEDER"].ToString();
                        lblTOTFeeder.Text = dt.Rows[0]["TSSPDCL TOT FEEDER"].ToString();
                        lblDEDIFeeder.Text = dt.Rows[0]["TSSPDCL DEDI FEEDER"].ToString();
                        lblFromTSTransco.Text = dt.Rows[0]["TSSPDCL FROM TSTRANSCO"].ToString();
                        lblIssueDate.Text = dt.Rows[0]["TSSPDCL TF ISSUEDATE"].ToString();
                        lblDesgOfficer.Text = dt.Rows[0]["TSSPDCL DESIGN ISSUEOFFICER"].ToString();
                        lblADEOperation.Text = dt.Rows[0]["TSSPDCL ADE OPERATION"].ToString();
                        lblDEOperation.Text = dt.Rows[0]["TSSPDCL DE OPERATION"].ToString();
                        lblSEOperation.Text = dt.Rows[0]["TSSPDCL SE OPERATION"].ToString();
                        lblHTNO.Text = dt.Rows[0]["TSSPDCL HT NO"].ToString();
                        lblMobNo.Text = dt.Rows[0]["TSSPDCL MOBILE NO"].ToString();
                    }
                }
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }    
}
