using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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
    string rstages = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session.Count <= 0)
        {
           // Response.Redirect("../../frmUserLogin.aspx");
        }
       

        if (!IsPostBack)
        {
            GetDetails();

            
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            
        }
    }
    public void GetDetails()
    {

            if (Request.QueryString.Count > 0)
            {
                rstages = Request.QueryString[0].ToString().Trim();
               
                DataSet dsn = new DataSet();
                //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
                //return;
                dsn = Gen.GetShowDepartmentFilesCFOIndus(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());
                if (dsn.Tables[0].Rows.Count > 0)
                {
                    
                    grdDetails.DataSource = dsn.Tables[0];
                    grdDetails.DataBind();
                }
                else
                {
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                }
            }


            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0].ToString().Trim() == "5" || Request.QueryString[0].ToString().Trim() == "6")
                {
                }
                else
                {
                   // grdDetails.Columns[10].Visible = false;
                    //grdDetails.Columns[11].Visible = false;
                    grdDetails.Columns[11].Visible = false;
                    grdDetails.Columns[12].Visible = false;
                }
            }
            else
            {
                //grdDetails.Columns[10].Visible = false;
                //grdDetails.Columns[11].Visible = false;

                grdDetails.Columns[11].Visible = false;
                grdDetails.Columns[12].Visible = false;
            }

     
    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        GetDetails();

       
    }
    void clear()
    {

        
       
       
    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {

      

    }
    void FillDetails()
    {
        
          
    }    
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    void getcounties()
    {
       
    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    void getPayams()
    {
       
    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
            
        try
        {

           

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {

        }
    
    }

    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {

      


    }
  
    protected void BtnClear0_Click1(object sender, EventArgs e)
    {
      
    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }



    protected void GetNewRectoInsertdr()
    {
        
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[8].Controls[0];

            HyperLink h2 = (HyperLink)e.Row.Cells[9].Controls[0];
            HyperLink h3 = (HyperLink)e.Row.Cells[10].Controls[0];


            h1.Target = "_blank";
            h1.NavigateUrl = "ViewCFOPrint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
            h2.Target = "_blank";
            h2.NavigateUrl = "frmViewAttachmentDetailsCFO.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();

            h3.Target = "_blank";
            h3.NavigateUrl = "frmQurieResponseStatusCFO.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();
            DropDownList ddlStatus = (DropDownList)e.Row.Cells[11].FindControl("ddlStatus");

            TextBox txtPromotor = (TextBox)e.Row.Cells[11].FindControl("txtPromotor");

            Label Label378 = (Label)e.Row.Cells[11].FindControl("Label378");

            Label Label379 = (Label)e.Row.Cells[11].FindControl("Label379");

            TextBox txtAmount = (TextBox)e.Row.Cells[11].FindControl("txtAmount");

            HiddenField hdfApplID = (HiddenField)e.Row.Cells[12].FindControl("hdfApplID");
            hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireCFOid")).Trim();

            HiddenField hdfGroundedNo = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo");

            hdfGroundedNo.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();

            HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo0");

            hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();


            HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo1");

            hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();


            HiddenField hdfGroundedNo2 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo2");

            hdfGroundedNo2.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LastDateofPreScrutiy")).Trim();


            HiddenField hdfGroundedNo3 = (HiddenField)e.Row.Cells[12].FindControl("hdfGroundedNo3");

            //hdfGroundedNo3.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStatusid")).Trim();


            //if (ddlStatus.SelectedValue.ToString() == "8")
            //{
            //    txtPromotor.Visible = true;
            //    Label378.Visible = true;

            //}
            //else
            //{
            //    txtPromotor.Visible = false;
            //    Label378.Visible = false;


            //}


            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();

            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";






        }




    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList ddlStatus = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");

        Label Label378 = (Label)row.FindControl("Label378");

        TextBox txtAmount = (TextBox)row.FindControl("txtAmount");

        Label Label379 = (Label)row.FindControl("Label379");

        //DropDownList ddlCorporation1 = (DropDownList)row.FindControl("ddlCorporation");
        //DropDownList ddlWard = (DropDownList)row.FindControl("ddlWard");
        //GetWards(ddlWard, ddlCorporation1.SelectedValue);

        ////DropDownList ddlStatus = (DropDownList).FindControl("ddlStatus");
        //Button BtnSave = (Button)sender;
        //GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        //DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
      

        if (ddlStatus.SelectedValue.ToString() == "5")
        {
            txtPromotor.Visible = true;
            Label378.Visible = true;

            Label379.Visible = false;
            txtAmount.Visible = false;
    
        }
        else if (ddlStatus.SelectedValue.ToString() == "7")
        {

            txtPromotor.Visible = true;
            Label378.Visible = true;
            Label379.Visible = true;
            txtAmount.Visible = true;
        }

        else if (ddlStatus.SelectedValue.ToString() == "10")
        {
            txtPromotor.Visible = false;
            Label378.Visible = false;
            Label379.Visible = true;
            txtAmount.Visible = true;
        }
        else
        {
            txtPromotor.Visible = false;
            Label378.Visible = false;
            Label379.Visible = false;
            txtAmount.Visible = false;

        }
       
        // if(ddlStatus.)

        //if()


    }
    protected void BtnSave_Click1(object sender, EventArgs e)
    {

        Button BtnSave = (Button)sender;

        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");

        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");

        TextBox txtAmount = (TextBox)row.FindControl("txtAmount");

        HyperLink h1 = (HyperLink)row.FindControl("h1");

        HyperLink h2 = (HyperLink)row.FindControl("h2");

        HyperLink h3 = (HyperLink)row.FindControl("h3");

        HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
        HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
        HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");

        HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");

        HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");


        if (ddlStatus.SelectedValue.ToString() == "--Select--")
        {
            Failure.Visible = true;

            success.Visible = false;

            lblmsg.Text = "Please Select Status";


        }

        int result = 0;
        result = Gen.insertDepartmentProcessCFO(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value, ddlStatus.SelectedValue.ToString(), hdfGroundedNo2.Value, Session["uid"].ToString().Trim());


        if (ddlStatus.SelectedValue.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
        {
            //HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
            //hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();


            ////HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");

            ////hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();


            ////HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");

            ////hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();

            int j = Gen.UpdateAdditionalpaymentsCFO(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());

            int i = Gen.insertQueryResponsedataCFO(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text, "Y", Session["uid"].ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, hdfApplID.Value);


            if (i > 0)
            {
                GetDetails();
            }


        }
        else if (ddlStatus.SelectedValue.ToString() == "7")
        {

            int i = Gen.insertQueryResponsedataCFO(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, hdfApplID.Value);

            int j = Gen.UpdateAdditionalpaymentsCFO(hdfGroundedNo.Value, txtAmount.Text, "Y", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
        }
        else if (ddlStatus.SelectedValue.ToString() == "10")
        {
            int j = Gen.UpdateAdditionalpaymentsCFO(hdfGroundedNo.Value, txtAmount.Text, "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());

        }
        else if (ddlStatus.SelectedValue.ToString() == "12")
        {
            int j = Gen.UpdateAdditionalpaymentsCFO(hdfGroundedNo.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hdfGroundedNo0.Value, hdfGroundedNo1.Value, getclientIP());
        }

        if (result > 0)
        {



            ddlStatus.SelectedIndex = 0;
            txtAmount.Text = "";
            txtPromotor.Text = "";


            success.Visible = true;
            Failure.Visible = false;
            lblmsg.Text = "Successfully Registered";


        }
        else
        {

            success.Visible = false;
            Failure.Visible = true;
            lblmsg.Text = "Failed..";


        }

        GetDetails();

        //else if (ddlStatus.SelectedValue.ToString() == "--Select--")
        //{
        //    Failure.Visible = true;

        //    success.Visible = false;

        //    lblmsg.Text = "Please Select Status";


        //}
    }
    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }
}
