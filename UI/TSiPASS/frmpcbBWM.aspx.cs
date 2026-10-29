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

public partial class UI_TSiPASS_frmpcbBWM : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    BMWClass ObjBMW = new BMWClass();
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
            dscheck = ObjBMW.GetShowBWMQuestionaries2(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
            if (dscheck != null && dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["HCEID"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }
            DataSet dspcb = new DataSet();
            dspcb = ObjBMW.GetdataRedirectionurltopcbBWM(Session["Applid"].ToString(), "");
            if (dspcb != null && dspcb.Tables.Count > 0 && dspcb.Tables[0].Rows.Count > 0)
            {

                
                //string myParameters = "indName=" + "Covin + HealthCare" + "&indDistrict=" + "SANGAREDDY" + "&indAddress=" + "ashNGAREDDY+I, Zahirabad,Hothi+K,94A+95A,HOTHI+K,502320" + "&cafUniqueNo=" + "80003" +
                //    "&indPhoneNo=" + "9000443968" + "&indEmail=" + "asrpharma18@gmail.com"
                //     + "&serviceId=21" + "&indPin=" + "502320" + "&village1=" + "Hothi K"
                //     + "&indSfNo=" + "94A 95A" + "&indRegNum=" + "TS25A011111"
                //     + "&indCapInvt=" + "10.00" + "&indNewCapInvt=" + "20.00"
                //     + "&indStatus=" + "Proposed" + "&regdOfficeAddress=" + "Sangareddy, Zahirabad, Hothi+K,SYNO94A + 95A,zahirabad,502320"
                //     + "&occPin=" + "502320" + "&nationality=" + ""
                //     + "&occPhoneCode=" + "" + "&occPhoneNo=" + ""
                //     + "&occMobile=" + "9000443968" + "&occEmail=" + "asrpharma18@gmail.com"
                //     + "&industryUnit=" + "Small" + "&occName=" + "GAJJISWATHI"
                //     + "&tehsil=" + "Zahirabad" + "&jurisdictionOffice=" + "Nizamabad"
                //     + "&buildArea=" + "800.00" + "&industryTypeId=" + "3130923" +
                //     "&categoryId=" + "3130924"
                //     + "&uniqueUserId=" + "sand8000003";
                string myParameters = "indName=" + dspcb.Tables[0].Rows[0]["insustryName"].ToString() + "&indDistrict=" + dspcb.Tables[0].Rows[0]["industryDistrict"].ToString().Trim() + "&indAddress=" + dspcb.Tables[0].Rows[0]["industryAddress"].ToString() + "&cafUniqueNo=" + dspcb.Tables[0].Rows[0]["cafUniqueNo"].ToString() +
                    "&indPhoneNo=" + dspcb.Tables[0].Rows[0]["industryMobile"].ToString() + "&indEmail=" + dspcb.Tables[0].Rows[0]["industryEmail"].ToString()
                     + "&serviceId=21" + "&indPin=" + dspcb.Tables[0].Rows[0]["indPin"].ToString() + "&village1=" + dspcb.Tables[0].Rows[0]["village1"].ToString()
                     + "&indSfNo=" + dspcb.Tables[0].Rows[0]["indSfNo"].ToString() + "&indRegNum=" + dspcb.Tables[0].Rows[0]["indRegNum"].ToString()
                     + "&indCapInvt=100" + //dspcb.Tables[0].Rows[0]["indCapInvt"].ToString() +
                     "&indNewCapInvt=200" //+ dspcb.Tables[0].Rows[0]["indNewCapInvt"].ToString()
                     + "&indStatus=" + dspcb.Tables[0].Rows[0]["indStatus"].ToString() + "&regdOfficeAddress=" + dspcb.Tables[0].Rows[0]["regdOfficeAddress"].ToString()
                     + "&occPin=" + dspcb.Tables[0].Rows[0]["occPin"].ToString() + "&nationality=" + dspcb.Tables[0].Rows[0]["nationality"].ToString()
                     + "&occPhoneCode=" + dspcb.Tables[0].Rows[0]["occPhoneCode"].ToString() + "&occPhoneNo=" + dspcb.Tables[0].Rows[0]["occPhoneNo"].ToString()
                     + "&occMobile=" + dspcb.Tables[0].Rows[0]["occMobile"].ToString() + "&occEmail=" + dspcb.Tables[0].Rows[0]["occEmail"].ToString()
                     + "&industryUnit=" + dspcb.Tables[0].Rows[0]["industryUnit"].ToString() + "&occName=" + dspcb.Tables[0].Rows[0]["occName"].ToString()
                     + "&tehsil=" + dspcb.Tables[0].Rows[0]["tehsil"].ToString() + "&jurisdictionOffice=" + dspcb.Tables[0].Rows[0]["jurisdictionOffice"].ToString()
                     + "&buildArea=800" + //dspcb.Tables[0].Rows[0]["buildArea"].ToString() + 
                     "&industryTypeId=3130996" + //dspcb.Tables[0].Rows[0]["industryTypeId"].ToString() +
                     "&categoryId=3130997" //+ dspcb.Tables[0].Rows[0]["categoryId"].ToString()
                     + "&uniqueUserId=" + dspcb.Tables[0].Rows[0]["uniqueUserId"].ToString() + "&intQuessionaireid=" + dspcb.Tables[0].Rows[0]["HCEID"].ToString() + "&applicationType=fresh";

                //Response.Redirect("http://164.100.163.19/TSPCB/industryRegMaster/doLoginWithDetails?" + myParameters);
                Response.Redirect("http://tsocmms.nic.in/TLNPCB/industryRegMaster/doLoginWithDetails?" + myParameters.ToString().Replace("\n\r", ""));

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