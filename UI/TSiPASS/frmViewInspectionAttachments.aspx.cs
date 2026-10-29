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
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    HyperLink[] h = new HyperLink[100];
    Label[] lab = new Label[100];
    static DataTable dtMyTable;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }


        if (Request.QueryString["intInspectionid"] != null)
        {
            hdfFlagID0.Value = Request.QueryString["intInspectionid"];

            if (!IsPostBack)
            {
                FillDetails();
            }

        }


        if (!IsPostBack)
        {
            //  hdfFlagID.Value = "1073";
            //dtMyTableCertificate = createtablecrtificate();
            //Session["CertificateTb"] = dtMyTableCertificate;
            // FillDetails();

        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }



    void clear()
    {




    }



    void FillDetails()
    {
        // hdfFlagID.Value = "1072";RetriveLinkForDD
        DataSet ds = new DataSet();


        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.ViewInspectionAttachmets(hdfFlagID0.Value.ToString());


            //----------------------------------------------------------
            if (ds.Tables[0].Rows[0]["File_Link1"].ToString() == null)
            {
                HyperLink1.Text = "No Attachment";
            }
            else
            {
                HyperLink1.Text = "View";
                HyperLink1.NavigateUrl = Convert.ToString(ds.Tables[0].Rows[0]["File_Link1"].ToString()).Trim();
                HyperLink1.Target = "_blank";

            }
            if (ds.Tables[0].Rows[0]["File_Link2"].ToString() == null)
            {
                HyperLink2.Text = "No Attachment";
            }
            else
            {
                HyperLink2.Text = "View";
                HyperLink2.NavigateUrl = Convert.ToString(ds.Tables[0].Rows[0]["File_Link2"].ToString()).Trim();
                HyperLink2.Target = "_blank";

            }

            if (ds.Tables[0].Rows[0]["File_Link3"].ToString() == null)
            {
                HyperLink3.Text = "No Attachment";
            }
            else
            {
                HyperLink3.Text = "View";
                HyperLink3.NavigateUrl = Convert.ToString(ds.Tables[0].Rows[0]["File_Link3"].ToString()).Trim();
                HyperLink3.Target = "_blank";
            }

            if (ds.Tables[0].Rows[0]["File_Link4"].ToString() == null)
            {
                HyperLink4.Text = "No Attachment";
            }
            else
            {
                HyperLink4.Text = "View";
                HyperLink4.NavigateUrl = Convert.ToString(ds.Tables[0].Rows[0]["File_Link4"].ToString()).Trim();
                HyperLink4.Target = "_blank";
            }

        }


        catch (Exception ex)
        {
            // lblmsg.Text = ex.ToString();

        }
        finally
        {

        }

    }






    protected void GetNewRectoInsertdr()
    {

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFEPrint.aspx?intApplicationId=" + hdfFlagID0.Value);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFEPrint.aspx?intApplicationId=" + hdfFlagID0.Value);

    }
}




