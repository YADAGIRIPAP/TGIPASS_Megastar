using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

//created by suresh as on 1-17-2016 for county adm lookup 
//tables td_CountyAdmDet,getCASearch


public partial class LookupCA : System.Web.UI.Page
{
    decimal NumberTotal, InvestmnetTotal, EmploymentTotal;
    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;

    
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }
        DataSet ds = new DataSet();
        ds = Gen.GetmodifiedDate();
        Label2.Text = "Last Updated by CoI on " + ds.Tables[0].Rows[0]["ModifiedDate"].ToString().Trim();
        if (!IsPostBack)
        {
            //BindGraphChart();
            //BindPieChart();
            fillgrid();
        }
        
    }
    #endregion

    //protected void getdistricts()
    //{
    //    DataSet dsnew = new DataSet();

    //    dsnew = Gen.GetDistricts();
    //    ddlConnectLoad.DataSource = dsnew.Tables[0];
    //    ddlConnectLoad.DataTextField = "District_Name";
    //    ddlConnectLoad.DataValueField = "District_Name";
    //    ddlConnectLoad.DataBind();
    //    ddlConnectLoad.Items.Insert(0, "--Select--");
    //}
    public void fillgrid()
    {

        DataSet dsnew = new DataSet();
        
        dsnew = Gen.GetRptGlance_New(ddlType.SelectedValue);
       // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            if (ddlType.SelectedValue == "3")
            {
                Label1.Text = "Report from 01-April-2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
                Label387.Text = "Number of Industries given Approvals";
            }
            else
            {
                Label1.Text = "Report from 01-Jan-2015 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
                Label387.Text = "Number of Industries given Approvals";
            }
            lblnumber.Text = dsnew.Tables[4].Rows[0]["Number"].ToString().Trim();
            lblinv.Text = dsnew.Tables[4].Rows[0]["Investment"].ToString().Trim();
            lblEmp.Text = dsnew.Tables[4].Rows[0]["Employment"].ToString().Trim();

            lblnumber1617.Text = dsnew.Tables[9].Rows[0]["Number1617"].ToString().Trim();
            lblInv1617.Text = dsnew.Tables[9].Rows[0]["Investment1617"].ToString().Trim();
            lblem1617.Text = dsnew.Tables[9].Rows[0]["Employment1617"].ToString().Trim();

            lblCO.Text = dsnew.Tables[0].Rows[0]["cmo"].ToString().Trim();
            lblas.Text = dsnew.Tables[1].Rows[0]["advstg"].ToString().Trim();
            lblis.Text = dsnew.Tables[2].Rows[0]["instg"].ToString().Trim();
            lblyet.Text = dsnew.Tables[3].Rows[0]["yetstart"].ToString().Trim();

            lblCom1617.Text = dsnew.Tables[5].Rows[0]["cmo1617"].ToString().Trim();
            lblads1617.Text = dsnew.Tables[6].Rows[0]["advstg1617"].ToString().Trim();
            lblIns1617.Text = dsnew.Tables[7].Rows[0]["instg1617"].ToString().Trim();
            lblYet1617.Text = dsnew.Tables[8].Rows[0]["yetstart1617"].ToString().Trim();
            
        }
        else
        {
            //lblMsg.Text = "";
            Label1.Text = "No Recards Found ";
            lblnumber.Text = "--";
            lblinv.Text = "--";
            lblEmp.Text = "--";
            lblCO.Text = "--";
            lblas.Text = "--";
            lblis.Text = "--";
            lblyet.Text = "--";
            lblnumber1617.Text = "--";
            lblInv1617.Text = "--";
            lblem1617.Text = "--";
            lblCom1617.Text = "--";
            lblads1617.Text = "--";
            lblIns1617.Text = "--";
            lblYet1617.Text = "--";
        }

    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        StringWriter stringWriter = new StringWriter();
        HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        divPrint.RenderControl(htmlTextWriter);

        StringReader stringReader = new StringReader(stringWriter.ToString());
        Document Doc = new Document(PageSize.A4, 100f, 100f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(Doc);
        PdfWriter.GetInstance(Doc, Response.OutputStream);

        Doc.Open();
        htmlparser.Parse(stringReader);
        Doc.Close();
        Response.Write(Doc);
        Response.End();
    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
      //  ExportToExcel();

    }

   

    public override void VerifyRenderingInServerForm(Control control)
    {
    } 
}
