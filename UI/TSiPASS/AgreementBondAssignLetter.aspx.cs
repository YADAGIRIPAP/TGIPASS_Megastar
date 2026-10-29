using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
//using System.Reflection.Emit;



public partial class UI_TSiPASS_AgreementBondAssignLetter : System.Web.UI.Page
{
    General Gen = new General();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dspay = new DataSet();
            string Enterid = "";
            if (Request.QueryString.Count > 0)
            {
                Enterid = Request.QueryString["EntrpId"].ToString();
            }

            dspay = Gen.GetEnterincetrackerForLatestDetailsUpdation(Enterid);
            if (dspay != null && dspay.Tables.Count > 0 && dspay.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dspay.Tables[0];
                grdDetails.DataBind();
            }
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblEnterperIncentiveID") as Label);
            Label MstIncentiveId = (e.Row.FindControl("lblIncentiveID") as Label);
            Label lblintstageid = (e.Row.FindControl("lblintstageid") as Label);
            HyperLink anchortagAgreementBond = (e.Row.FindControl("anchortagAgreementBond") as HyperLink);
            Label lblUnitDtlsUpdated = (e.Row.FindControl("lblUnitDtlsUpdated") as Label);

            
            if (lblintstageid.Text == "32")
            {
                anchortagAgreementBond.Visible = true; 
                anchortagAgreementBond.NavigateUrl = "AgreementBondUploadEnterpriseChanges.aspx?Enterid=" + enterid.Text + "&MstIncentiveId=" + MstIncentiveId.Text; 
            }
            else
            {
                anchortagAgreementBond.Visible = false; 
            }
        }
    }
}