using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class UI_TSiPASS_frmDistrictReformsForm : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDepartments();
        }
       
    }

    public void BindDepartments()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddldepartments.Items.Clear();
            dsd = Gen.GetDepartments();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddldepartments.DataSource = dsd.Tables[0];
                ddldepartments.DataValueField = "Dept_Id";
                ddldepartments.DataTextField = "Dept_Name";
                ddldepartments.DataBind();
                ddldepartments.Items.Insert(0, "--Select--");
            }
            else
            {
                ddldepartments.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
           
        }
    }


    protected void ddldepartments_SelectedIndexChanged(object sender, EventArgs e)
    {
       string i= ddldepartments.SelectedValue;
        DataSet ds = new DataSet();
        ds = Gen.GetApprovalsByDept(ddldepartments.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvcfefaileddata.DataSource = ds.Tables[0];
            gvcfefaileddata.DataBind();
           
        }
        else
        {
           
        }

    }

    protected void gvcfefaileddata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblapprovalid = (Label)e.Row.FindControl("lblApprovalid");
            string ApprovalId = lblapprovalid.Text;
            Label lbldeptId = (Label)e.Row.FindControl("lblDeptId");
            string deptId = lbldeptId.Text;

            HyperLink h1 = (HyperLink)e.Row.FindControl("ApplyHere");
            h1.NavigateUrl = "districtreforms.aspx?ApprovalId="+ApprovalId+ "&deptId="+deptId;

            if (ApprovalId == "83")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/SSLR-17.Demarcation(HYD)Service Application Form1.pdf";
            }
            if (ApprovalId == "84")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/civil supplies -FPShop.pdf";
            }

            if (ApprovalId == "89")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/RegistrationunderPC&PNDTAct.docx";
            }
            if (ApprovalId == "90")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/Cinematographic license.pdf";
            }
            if (ApprovalId == "85")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/civilsupplies-petroleumproducts.pdf";
            }

            if (ApprovalId == "86")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/RegistrationofCO-Operative_Societies.pdf";
            }

            if (ApprovalId == "96")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/Licence in FORM-DM2 (MGO)- bottling unit.doc";
            }

            if (ApprovalId == "95")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/Form DM1- bottling unit.docx";
            }

            if (ApprovalId == "94")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/Application in FORM-MB- Micro brewery.dot";
            }

            if (ApprovalId == "97")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/police-explosives.JPG";
            }

            if (ApprovalId == "98")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/agriculture-license for insecticides.docx";
            }

            if (ApprovalId == "99")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/PCPNANDD_T.docx";
            }

            if (ApprovalId == "100")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Download");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/SaleofCrackers.JPEG";
            }
            if (ApprovalId == "87")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Instructions");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/19, 20 EFST GO.pdf";
            }
            if (ApprovalId == "88")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("Instructions");
                h2.NavigateUrl = "~/UI/TSiPASS/OtherServicesDocs/19, 20 EFST GO.pdf";
            }
        }

    }
}