using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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
            Response.Redirect("~/Index.aspx");
        }
        //string status = Request.QueryString[0].ToString().Trim();
        //string distid = Session["DistrictID"].ToString().Trim();

        if (Request.QueryString.Count > 0)
        {
           

            if (!IsPostBack)
            {
               
                //grdDetails.Columns[7].Visible = false;
                //grdDetails.Columns[8].Visible = false;
            }
        }
        else
        {
           
           
        }

        if (!IsPostBack)
        {
            //getdistricts();
            fetchIncentivedet();

        }


    }
    protected void GetDepartment()
    {
        
    }
    
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        fetchIncentivedet();
    }
    protected void fetchIncentivedet()
    {
        DataSet ds = new DataSet();

        ds = Gen.GetTSiPASSReport4TOIpo(ddlMonth.SelectedValue, ddlYear.SelectedValue, Session["uid"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblMsg.Text = ds.Tables[0].Rows.Count.ToString() + " Records found.";
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            //if (Request.QueryString.Count > 0)
            //{
               
            //        if (Session["uid"].ToString() == "1213" || (Convert.ToInt32(Session["User_Code"].ToString()) >= 46 && Convert.ToInt32(Session["User_Code"].ToString()) <= 55))
            //        {
            //            grdDetails.Columns[15].Visible = false;
            //        }
            //        else
            //        {
            //            grdDetails.Columns[15].Visible = true;
            //        }
            //  }
            //    else
            //    {
            //        grdDetails.Columns[15].Visible = false;
            //    }
            
        }
        else
        {
            lblMsg.Text = ds.Tables[0].Rows.Count.ToString() + " Records found.";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
       // ddlstatus.SelectedIndex = 0;
       // ddlDistrict.SelectedIndex = 0;
        //TxtIndname.Text = "";
        fetchIncentivedet();
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;
        fetchIncentivedet();
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField HdfintApplicationid = (HiddenField)e.Row.FindControl("HdfintApplicationid");
            HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTSiPASSid"));
            DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");

            ddlStatus.Items.Clear();
            ddlStatus.Items.Add("--Select--");
            ddlStatus.Items.Add("Accepted");
            ddlStatus.Items.Add("Rejected");
           // ddlStatus.Items.Add("Rejected");


            //btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
           // HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[11].FindControl("HdfintApplicationid");
           // HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intAdvanceSubsidyid")).Trim();
          //  DropDownList ddlStatus = (DropDownList)e.Row.Cells[12].FindControl("ddlDeptname");
        }
    }
    protected void BtnSaveg_Click(object sender, EventArgs e)
    {
        Button BtnSaveg = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

        HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");

        if (ddlStatus.SelectedIndex == 0)
        {
            lblresult.Text = "Please Select Status";
        }
        else
        {
            //lblresult.Text = "Status Updated";


            int returnValue = Gen.UpdateTSiPASSReport4Status(HdfintApplicationid.Value, Session["uid"].ToString(), ddlStatus.SelectedValue.ToString().Trim());

            if (returnValue != 999)
            {

                lblresult.Text = "Status Updated";
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);

                // fillgrid();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

                lblresult.Text = "Status Not Updated";

            }


        }
       // int returnValue = cnn.ChangestatusAppl(HdfintApplicationid.Value, ddlStatusg.SelectedValue.ToString().Trim(), Session["uid"].ToString());


        fetchIncentivedet();

    }

    
}
