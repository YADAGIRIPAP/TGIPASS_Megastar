using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
//using TSIPassBE;
//using TSIPassBL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
public partial class UI_TSiPASS_frmLegalRedirection : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    BMWClass ObjBMW = new BMWClass();
    Legalverify objLegal = new Legalverify();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    int n1;

    static DataTable dtMyTable;
    //[getQuesssionerDetailsRen]


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            DataSet dscheck = new DataSet();
            dscheck = objLegal.GetenterpreneurdetailsLegalmetrology(Request.QueryString["intApplicationId"].ToString());
            if (dscheck != null && dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["LgvID"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }
            DataSet dslegal = new DataSet();
            dslegal = objLegal.GetenterpreneurdetailsLegalmetrology(Request.QueryString["intApplicationId"].ToString());
            //test url -https://qa8.cgg.gov.in/TSLM/TSIpassRegistration.do?
            if (dslegal != null && dslegal.Tables.Count > 0 && dslegal.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("https://tslm.cgg.gov.in/TSIpassRegistration.do?mode=saveTSiPassApplication&tsIpassUniqueId= "
                    + dslegal.Tables[0].Rows[0]["LgvID"].ToString() +
           "&registrationType=" + dslegal.Tables[0].Rows[0]["RegistrationType"].ToString() + "&districtId=" + dslegal.Tables[0].Rows[0]["District_Name"].ToString() +
           "&mandalId=" + dslegal.Tables[0].Rows[0]["mandal_name"].ToString() + "&villageId=" + dslegal.Tables[0].Rows[0]["village_name"].ToString()
           + "&emailId=" + dslegal.Tables[0].Rows[0]["Email"].ToString()
           + "&mobileNumber=" + dslegal.Tables[0].Rows[0]["MobileNo"].ToString());

                

            }
            else
            {

                Response.Redirect("frmDepartmentApprovalDetailsBMW.aspx?intApplicationId=" + Request.QueryString[0].ToString());

            }
            if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
            {

                //ResetFormControl(this);

            }

            //DataSet ds = new DataSet();
            //ds = Gen.ViewAttachmentREN(Session["Applid"].ToString());

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    FillDetails();
            //}
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();
            dsnew = ObjBMW.getdataofidentityBWM(Session["Applid"].ToString(), "1");
            if (dsnew.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {
                    Response.Redirect("frmLabourShopRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                }
                else
                {
                    Response.Redirect("frmRenewalDetail.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                }
            }
        }
    }


    protected void btnsave_Click(object sender, EventArgs e)
    {

    }
    protected void btnnext_Click(object sender, EventArgs e)
    {

        Response.Redirect("frmLabourShopRenewal.aspx?intApplicationId=" + Session["Applid"].ToString() + "&next=" + "N");// + hdfID.Value
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmRenewalDetail.aspx?intApplicationId=" + Session["Applid"].ToString() + "&next=" + "P");// + hdfID.Value
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmpcbrenewal.aspx");
    }
}