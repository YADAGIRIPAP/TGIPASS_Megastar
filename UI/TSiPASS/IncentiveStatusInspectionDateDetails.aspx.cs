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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using BusinessLogic;

public partial class TSTBDCReg1 : System.Web.UI.Page
{
    
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session.Count <= 0)
        {
           // Response.Redirect("../../frmUserLogin.aspx");
        }
     //   string status = Request.QueryString[0].ToString().Trim();
      //  string distid = Session["DistrictID"].ToString().Trim();
        if (Request.QueryString.Count > 0)
        {
            
            //ddlstatus.SelectedValue = status;
            //ddlstatus.Enabled = false;
         //   ddlDistrict.SelectedValue = distid;
          //  ddlDistrict.Enabled = false;
            //grdDetails.Columns[7].Visible = false;
            //grdDetails.Columns[8].Visible = false;
        }
        else
        {
            //ddlstatus.SelectedIndex = 0;
            //ddlstatus.Enabled = true;
           // ddlDistrict.SelectedValue = distid;
           // ddlDistrict.Enabled = false;
        }

        if (!IsPostBack)
        {

            DataSet dsdist = new DataSet();
            dsdist = Gen.GetDistnamebylogin(Session["User_Code"].ToString());

            if (dsdist.Tables[0].Rows.Count > 0)
            {

                ddlDistrict.DataSource = dsdist.Tables[0];
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataBind();
                ddlDistrict.SelectedValue = ddlDistrict.Items.FindByValue(dsdist.Tables[0].Rows[0]["District_Id"].ToString().Trim()).Value;
                ddlDistrict.Enabled = false;
                //ddlDistrict.Items.Insert(0, "--Select--");


            }

          //  getdistricts();
            getincentives();
            fetchIncentivedet();
           
        }

    }
    protected void GetDepartment()
    {
        
    }

    protected void getincentives()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetIncentives();

        ddlIncentiveName.DataSource = dsnew.Tables[0];
        ddlIncentiveName.DataTextField = "IncentiveName";
        ddlIncentiveName.DataValueField = "IncentiveID";
        ddlIncentiveName.DataBind();
        ddlIncentiveName.Items.Insert(0, "--Select--");
    }




    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetDistrictsbystate("%");
        ddlDistrict.DataSource = dsnew.Tables[0];
        ddlDistrict.DataTextField = "District_Name";
        ddlDistrict.DataValueField = "District_Id";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, "--Select--");
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        fetchIncentivedet();
    }
    protected void fetchIncentivedet()
    {
        DataSet ds= new DataSet();

        ds = Gen.fetchIncentivedetIPO(Session["User_Code"].ToString(), Request.QueryString[0].ToString().Trim(), ddlIncentiveName.SelectedValue, TxtIndname.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0].ToString().Trim() == "3" )
                {
                    grdDetails.Columns[14].Visible = true;
                }
                else
                {
                    grdDetails.Columns[14].Visible = false;
                }
            }
        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
             
        
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ddlstatus.SelectedIndex = 0;
        ddlDistrict.SelectedIndex = 0;
        TxtIndname.Text = "";
        fetchIncentivedet();
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        fetchIncentivedet();
        grdDetails.PageIndex = e.NewPageIndex;
        grdDetails.DataBind();
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //DropDownList ddlDeptname = (e.Row.FindControl("ddlDeptname") as DropDownList);
            //DataSet dsnew = new DataSet();

            //dsnew = Gen.GetDepartment();
            //ddlDeptname.DataSource = dsnew.Tables[0];
            //ddlDeptname.DataTextField = "Dept_Name";
            //ddlDeptname.DataValueField = "Dept_Id";
            //ddlDeptname.DataBind();
            //ddlDeptname.Items.Insert(0, "--Select--");
            //GetDepartment();
            //string IncentiveId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID")).Trim();
            //LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            //btn.Text = "View";


            //btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
            HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[11].FindControl("HdfintApplicationid");
            HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId")).Trim();

            //HiddenField HdfEmailID = (HiddenField)e.Row.FindControl("hdfEmailID");
            //HiddenField HdfMobile = (HiddenField)e.Row.FindControl("hdfMobileNo");
            //HdfMobile.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo")).Trim();
            //HdfEmailID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EmailID")).Trim();
          
        }
    }
    protected void BtnSaveg_Click(object sender, EventArgs e)
    {
        Button BtnSaveg = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

        //HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
        //TextBox txtInspectionDate = (TextBox)row.FindControl("txtInspectionDate");

        HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
        HiddenField HdfEmailID = (HiddenField)row.FindControl("hdfEmailID");
        HiddenField HdfMobile = (HiddenField)row.FindControl("hdfMobileNo");
        HiddenField hdfApplName = (HiddenField)row.FindControl("hdfApplName");
        TextBox txtInspectionDate = (TextBox)row.FindControl("txtInspectionDate");

        DateTime date1;
        try { date1 = cmf.convertDateIndia(txtInspectionDate.Text); }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Please select Date..');", true);
            lblresult.Text = "Date is Not Updated";
            return;
        }


        if (txtInspectionDate.Text=="")
        {
            lblresult.Text = "Please Enter Date";
        }
        else
        {
            //  lblresult.Text = "Status Updated";


           int returnValue = Gen.UpdateInspectionDate(HdfintApplicationid.Value, txtInspectionDate.Text, Session["uid"].ToString());
            
            if (returnValue != 999)
            {
                DataTable dtMandt = objFetch.FetchIncentiveMandatoryDocuments(Convert.ToInt32(HdfintApplicationid.Value));

                System.Text.StringBuilder strMandt = new System.Text.StringBuilder();

                for (int i = 0; i < dtMandt.Rows.Count - 1; i++) strMandt.Append(dtMandt.Rows[i]["AttachmentName"].ToString() + "<br />");

                //for testing un comment below line
              //  HdfEmailID.Value = "fss.srikanth@gmail.com";

                cmf.SendMailIncentive(HdfEmailID.Value, "Dear " + hdfApplName.Value + "  :<br/><br/>Incentive Inspection Due Diligence for :<br /><br/><b> Incentive inspection is scheduled on Dated:" + date1.ToString("dd-MMMM-yyyy") + ". </b><br/><br/>Please Ensure that you are carrrying all the original Mandatory documents with you on " + date1.ToString("dd-MMMM-yyyy") + ".<br/><br /> <b>Mandatory Documents List</b> <br /> " + strMandt.ToString() + "<br /><br />  Thank You,<br /> Commissioner of Industries - Telangana.");

                //for testing un comment below line
           //     HdfMobile.Value = "9247492919";
                cmf.SendSingleSMS(HdfMobile.Value, "Dear " + hdfApplName.Value + ", TS-iPASS Incentive Inspection is scheduled on " + date1.ToString("dd-MMMM-yyyy") + "Please ensure to carry all your Mandatory Documents,the same is also emailed to " + HdfEmailID.Value + ". Thank You, Commissioner of Industries - Telangana.");


                lblresult.Text = "Date is Updated";
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);

               // fillgrid();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

                lblresult.Text = "Date is Not Updated";

            }


        }
        fetchIncentivedet();
       // int returnValue = cnn.ChangestatusAppl(HdfintApplicationid.Value, ddlStatusg.SelectedValue.ToString().Trim(), Session["uid"].ToString());




    }
    protected void txtInspectionDate_TextChanged(object sender, EventArgs e)
    {
        TextBox txtInspectionDate = (TextBox)sender;
        GridViewRow row = (GridViewRow)txtInspectionDate.NamingContainer;



        Label lblm = (Label)row.FindControl("lblm");


        if (cmf.convertDateIndia(txtInspectionDate.Text).DayOfWeek == DayOfWeek.Sunday)
        {
            lblm.Text = "Sunday is not selectable and Please Select Another day";
            txtInspectionDate.Text = "";
        }
        else
        {
            lblm.Text = "";
        }
    }
    
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    
    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Total Applications Received " + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                //grdDetails.Columns[1].Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                string status = Request.QueryString[0].ToString().Trim();
                DataSet ds = new DataSet();
                ds = Gen.fetchIncentivedetIPO( Session["User_Code"].ToString(),Request.QueryString[0].ToString().Trim(),ddlIncentiveName.SelectedValue,TxtIndname.Text
                    );

                grdExport.DataSource = ds.Tables[0];
                grdExport.DataBind();

                grdExport.RenderControl(hw);
                //grdDetails.Columns.RemoveAt("View");
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    
}
