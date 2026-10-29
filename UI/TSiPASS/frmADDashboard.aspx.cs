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


public partial class frmADDashboard : System.Web.UI.Page
{
    General Gen = new General();
    DataSet ds = new DataSet();
    comFunctions cmf = new comFunctions();
    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                filldetailsforSA();
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
            ds = Gen.GetIncetivePOSDetailsdept(Session["User_Code"].ToString());
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
}