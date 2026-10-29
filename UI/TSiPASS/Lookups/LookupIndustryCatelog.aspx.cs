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
using System.Globalization;
//creted by suresh on 14-1-2016 for lookup boma Development Comitte 
//table:td_BDCDet,Procedures:getBDCSearch

public partial class LookupBDC : System.Web.UI.Page
{
    #region Declaration
    General Gen = new General();
    
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }
        if (!IsPostBack)
        {
            //Gen.getStates(ddlState);


            for (int i = 1990; i <= DateTime.Now.Year; i++)
            {
                ddlYear.Items.Add((new ListItem(i.ToString(), i.ToString())));
            }




            string year = "";
            year = System.DateTime.Now.Year.ToString();

            ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;

            // ddlYear.SelectedItem.Text = year.ToString();
            // ddlYear.Enabled = false;
            string month = "";
            month = System.DateTime.Now.Month.ToString();
            ddlMonth.SelectedValue = ddlMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Value;


            //DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);

            //int year = DateTime.Now.Year - 5;

            //for (int Y = year; Y <= DateTime.Now.Year; Y++)
            //{

            //    ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
            //} 
   //         GetBanks();
        }
    }

    #endregion

   

   
    void fillgrid()
    {
        string User = "";
        User = Session["uid"].ToString();




      //  DataSet ds = Gen.GetBankVisit(txtBankBranchName.Text, ddlBank.SelectedValue, ddlMonth.SelectedValue, ddlYear.SelectedItem.ToString() ,User);

        DataSet ds = Gen.getIndustryCatelogLookUp(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString());

        
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblMsg.Text = ds.Tables[0].Rows.Count.ToString() + " Records found.";
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            lblMsg.Text = "No Records found.";
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {

            ((LinkButton)e.Row.FindControl("LinkButton1")).Attributes.Add("onclick", "javascript:GetRowValue('" + DataBinder.Eval(e.Row.DataItem, "intIndustrialCatalogueid") + "')");
        }
    }
   

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdDetails_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
}
