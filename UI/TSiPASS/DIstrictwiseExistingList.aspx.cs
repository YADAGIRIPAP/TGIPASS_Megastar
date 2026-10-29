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
    string DistrictID = "0";
    int cnt = 0;
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


                DataSet dsn = new DataSet();
                //Response.Write(Session["User_Code"].ToString().Trim()  +  "_" +  rstages.ToString().Trim() + "-" + Session["DistrictID"].ToString().Trim());
                //return;
                dsn = Gen.GetShowDistrictwiseDataExisting(ddlConnectLoad.SelectedItem.Text.ToString(), ddlCategory.SelectedItem.Text.ToString(), ddlConnectLoad1.SelectedItem.Text.ToString(), ddlPCB.SelectedItem.Text.ToString(), ddlCurrentStatus.SelectedItem.Text.ToString(), ddldiffable.SelectedItem.Text.ToString(),ddlWomen.SelectedItem.Text.ToString(),ddltyofmuslim.SelectedItem.Text.ToString());
                if (dsn.Tables[0].Rows.Count > 0)
                {

                    lblstate11.Text = "Total Records Found : " + dsn.Tables[0].Rows.Count.ToString();
                    grdDetails.DataSource = dsn.Tables[0];
                    grdDetails.DataBind();
                }
                else
                {
                    lblstate11.Text = "No records Found";
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
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
        Response.Redirect("DIstrictwiseExistingList.aspx");
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

           // GridView grdDetailsnew=

                //GridViewRow row = (GridViewRow).NamingContainer;
            GridView grdDetailsnew = (e.Row.FindControl("grdDetailsnew") as GridView) ;
            GridViewRow row = (GridViewRow)grdDetailsnew.NamingContainer;
            
            HiddenField hdfFlagIDnew = (HiddenField)e.Row.Cells[10].FindControl("hdfFlagIDnew");
            hdfFlagIDnew.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "[Name of the unit]")).Trim();



            DataSet dslat = new DataSet();
            dslat = Gen.Getdataofinnerdatacells(hdfFlagIDnew.Value.ToString());

            if (dslat.Tables[0].Rows.Count > 0)
            {

                grdDetailsnew.DataSource = dslat.Tables[0];
                grdDetailsnew.DataBind();
                e.Row.Cells[9].Text = dslat.Tables[0].Rows.Count.ToString();

            }
            else
            {
                grdDetailsnew.DataSource = null;
                grdDetailsnew.DataBind();
                e.Row.Cells[9].Text = "0";
            }

            //cnt = cnt + 1;
            //e.Row.Cells[0].Text = cnt.ToString();

            


        }




    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        GetDetails();
    }
    protected void Bthsave4_Click(object sender, EventArgs e)
    {
        GetDetails();

    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       // grdDetails.PageIndex = e.NewPageIndex;
        //GetDetails();
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void ddlConnectLoad1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlConnectLoad1.SelectedItem.Text.ToString() == "Minority")
        {

            minry.Visible = true;
        }
        else
        {
            minry.Visible = false;
        }
        
    }
}
