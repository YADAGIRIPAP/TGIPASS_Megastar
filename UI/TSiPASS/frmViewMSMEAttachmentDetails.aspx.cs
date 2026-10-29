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


        //if (Request.QueryString["intMSMEGenid"] != null)
        //{
        //hdfFlagID0.Value = "1014";
        hdfFlagID0.Value = Request.QueryString["intMSMEid"];

            if (!IsPostBack)
            {
                FillDetails();
            }

      // }


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
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.ViewAttachmetsDataForMSME(hdfFlagID0.Value.ToString());



            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();

            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                GridView2.DataSource = ds.Tables[2];
                GridView2.DataBind();

            }
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

        }

    }






   
    protected void BtnClear_Click(object sender, EventArgs e)
    {
       // Response.Redirect("CFEPrint.aspx?intApplicationId=" + hdfFlagID0.Value);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //Response.Redirect("CFEPrint.aspx?intApplicationId=" + hdfFlagID0.Value);

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            HyperLink HypGVMCSurvey = (HyperLink)e.Row.Cells[2].Controls[0];
            //HypGVMCSurvey.NavigateUrl = "ViewPath.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intfarmerid")).Trim(); //+ "&mandid=" + Request.QueryString[0].ToString().Trim();// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            HypGVMCSurvey.NavigateUrl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "link")).Trim();
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            HyperLink HypGVMCSurvey = (HyperLink)e.Row.Cells[1].Controls[0];
            //HypGVMCSurvey.NavigateUrl = "ViewPath.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intfarmerid")).Trim(); //+ "&mandid=" + Request.QueryString[0].ToString().Trim();// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            HypGVMCSurvey.NavigateUrl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "link")).Trim();
        }
    }
}




